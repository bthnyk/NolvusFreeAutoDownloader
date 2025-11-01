using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dark.Net;

namespace NolvusFreeAutoDownloader
{
    public partial class NfadMainForm : Form
    {
        public static NfadMainForm Instance;

        public NfadMainForm()
        {
            InitializeComponent();
            Instance = this;

            var isDark = DarkNet.Instance.EffectiveCurrentProcessThemeIsDark;
            btn_ToggleTheme.Text = isDark ? "☀️" : "🌙";
            btn_LangSwitch.Text = LanguageManager.CurrentLanguage == SupportedLanguage.English ? "TR" : "EN";

            if (isDark)
                DarkThemeHelper.ApplyDarkTheme(this);
            else
                DarkThemeHelper.ApplyLightTheme(this);
        }

        private Process _nolvusProcess;
        private DebugConnector _debugConnector;
        private CancellationTokenSource _loopCts;
        private int _wtnsec;

        private void btn_ToggleTheme_Click(object sender, EventArgs e)
        {
            var isDark = !DarkNet.Instance.EffectiveCurrentProcessThemeIsDark;

            if (isDark)
            {
                DarkNet.Instance.SetCurrentProcessTheme(Theme.Dark);
                DarkNet.Instance.SetWindowThemeForms(this, Theme.Dark);
                DarkThemeHelper.ApplyDarkTheme(this);
                btn_ToggleTheme.Text = @"☀️";
            }
            else
            {
                DarkNet.Instance.SetCurrentProcessTheme(Theme.Light);
                DarkNet.Instance.SetWindowThemeForms(this, Theme.Light);
                DarkThemeHelper.ApplyLightTheme(this);
                btn_ToggleTheme.Text = @"🌙";
            }

            Visible = false;
            Visible = true;
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = @"Executable Files|*.exe";
                ofd.Title = LanguageManager.T("SelectFile");

                if (ofd.ShowDialog() != DialogResult.OK) return;
                tb_Path.Text = ofd.FileName;
                AppendOutput(LanguageManager.T("SelectedFile") + $" {ofd.FileName}", LanguageManager.T("Info"));
            }
        }

        public void AppendOutput(string message, string level)
        {
            var timestamp = DateTime.Now.ToString("HH:mm:ss");
            rtb_Output.AppendText($"[{timestamp}] [{level}] {message}{Environment.NewLine}");
        }

        private async void btn_Start_Click(object sender, EventArgs e)
        {
            _wtnsec = (int)nud_WaitSeconds.Value * 1000;
            var exePath = tb_Path.Text.Trim();

            if (string.IsNullOrEmpty(exePath))
            {
                MessageBox.Show(LanguageManager.T("SelectExe"), LanguageManager.T("Warning"), MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (_nolvusProcess != null && !_nolvusProcess.HasExited)
            {
                AppendOutput(LanguageManager.T("AppAlreadyRunning"), LanguageManager.T("Warning"));
                return;
            }

            try
            {
                var exeDir = System.IO.Path.GetDirectoryName(exePath);

                if (exeDir != null)
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = exePath,
                        Arguments = "--remote-debugging-port=8088",
                        WorkingDirectory = exeDir,
                        UseShellExecute = true
                    };

                    _nolvusProcess = Process.Start(psi);
                    AppendOutput(LanguageManager.T("AppStarted"), LanguageManager.T("Task"));
                }

                _debugConnector = new DebugConnector();
                AppendOutput(LanguageManager.T("ConnectorConnecting"), LanguageManager.T("Task"));
                await _debugConnector.ConnectAsync();
                AppendOutput(LanguageManager.T("ConnectorConnected"), LanguageManager.T("Ok"));

                // Döngü için CancellationTokenSource oluştur
                _loopCts = new CancellationTokenSource();

                // Döngüyü başlat
                _ = RunLoopAsync(_loopCts.Token);

            }
            catch (Exception ex)
            {
                AppendOutput(LanguageManager.T("Error") + $" {ex.Message}", LanguageManager.T("Error"));
            }
        }

        private async Task RunLoopAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    AppendOutput(LanguageManager.T("ProcessStarting"), LanguageManager.T("Task"));
                    var result = await _debugConnector.ProcessSkyrimNexusAsync();
                    AppendOutput(
                        result ? LanguageManager.T("ProcessSuccess") : LanguageManager.T("ProcessFail"),
                        result ? LanguageManager.T("Ok") : LanguageManager.T("Error")
                    );
                }
                catch (Exception ex)
                {
                    AppendOutput(LanguageManager.T("LoopError") + $" {ex.Message}", LanguageManager.T("Error"));
                }

                await Task.Delay(_wtnsec, token);
            }
        }

        private async void btn_Stop_Click(object sender, EventArgs e)
        {
            if (_nolvusProcess == null || _nolvusProcess.HasExited)
            {
                AppendOutput(LanguageManager.T("NoRunningProcess"), LanguageManager.T("Info"));
                return;
            }

            try
            {
                _nolvusProcess.Kill();
                _nolvusProcess.WaitForExit();
                AppendOutput(LanguageManager.T("AppStopped"), LanguageManager.T("Ok"));

                if (_loopCts != null)
                {
                    _loopCts.Cancel();
                    _loopCts.Dispose();
                    _loopCts = null;
                    AppendOutput(LanguageManager.T("LoopCancelled"), LanguageManager.T("Ok"));
                }

                if (_debugConnector != null)
                {
                    await _debugConnector.DisconnectAsync();
                    _debugConnector.Dispose();
                    _debugConnector = null;
                    AppendOutput(LanguageManager.T("ConnectorClosed"), LanguageManager.T("Ok"));
                }
            }
            catch (Exception ex)
            {
                AppendOutput(LanguageManager.T("AppStopError") + $" {ex.Message}", LanguageManager.T("Error"));
            }
        }

        private void btn_LangSwitch_Click(object sender, EventArgs e)
        {
            var newLang = LanguageManager.CurrentLanguage == SupportedLanguage.Turkish
                ? SupportedLanguage.English
                : SupportedLanguage.Turkish;
            
            LanguageManager.SetLanguage(newLang);
            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            Text = LanguageManager.T("AppTitle");

            l_MTitle.Text = LanguageManager.T("LblTitle");
            l_Decs.Text = LanguageManager.T("LblDescribe");
            l_Path.Text = LanguageManager.T("LblPath");
            l_Wait.Text = LanguageManager.T("LblWtn");
            l_Secs.Text = LanguageManager.T("LblSec");

            btn_LangSwitch.Text = LanguageManager.CurrentLanguage == SupportedLanguage.English ? "EN" : "TR";

            btn_Browse.Text = LanguageManager.T("BtnBrowse");
            btn_Start.Text = LanguageManager.T("BtnStart");
            btn_Stop.Text = LanguageManager.T("BtnStop");
        }
    }
}
