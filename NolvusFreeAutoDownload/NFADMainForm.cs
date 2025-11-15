using System;
using Dark.Net;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            btn_Start.Enabled = false;
            btn_Pause.Enabled = false;
            btn_Stop.Enabled = false;
            _isPaused = false;

            tb_Path.Text = Properties.Settings.Default.lastFileDirection;
            btn_Start.Enabled = !string.IsNullOrEmpty(tb_Path.Text);
        }

        private Process _nolvusProcess;
        private DebugConnector _debugConnector;
        private CancellationTokenSource _loopCts;
        private int _wtnsec;
        private bool _isPaused;
        private int _consecutiveFailures;

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
                ofd.Filter = @"NolvusDashBoard (NolvusDashBoard.exe)|NolvusDashBoard.exe";
                ofd.Title = LanguageManager.T("SelectFile");
                ofd.CheckFileExists = true;
                ofd.Multiselect = false;
                ofd.FileName = "NolvusDashBoard.exe";

                if (ofd.ShowDialog() != DialogResult.OK) return;
                tb_Path.Text = ofd.FileName;
                Properties.Settings.Default.lastFileDirection = ofd.FileName;
                Properties.Settings.Default.Save();
                AppendOutput(LanguageManager.T("SelectedFile") + $" {ofd.FileName}", LanguageManager.T("Info"));
            }

            btn_Start.Enabled = true;
            btn_Pause.Enabled = false;
            btn_Stop.Enabled = false;
        }

        public void AppendOutput(string message, string level)
        {
            var timestamp = DateTime.Now.ToString("HH:mm:ss");
            rtb_Output.AppendText($"[{timestamp}] [{level}] {message}{Environment.NewLine}");
        }

        private async void btn_Start_Click(object sender, EventArgs e)
        {
            _isPaused = false;
            _consecutiveFailures = 0;

            btn_Start.Enabled = false;
            btn_Pause.Enabled = true;
            btn_Stop.Enabled = true;
            btn_Browse.Enabled = false;

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

                _loopCts = new CancellationTokenSource();

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
                    if (_consecutiveFailures <= 1)
                    {
                        AppendOutput(LanguageManager.T("ProcessStarting"), LanguageManager.T("Task"));
                    }

                    var result = await _debugConnector.ProcessSkyrimNexusAsync(_consecutiveFailures);

                    if (result)
                    {
                        AppendOutput(
                            LanguageManager.T("ProcessSuccess"),
                            LanguageManager.T("Ok")
                        );
                        _consecutiveFailures = 0;
                    }
                    else
                    {
                        _consecutiveFailures++;

                        if (_consecutiveFailures <= 1)
                        {
                            AppendOutput(
                                LanguageManager.T("ProcessFail"),
                                LanguageManager.T("Error")
                            );
                        }
                        else if (_consecutiveFailures == 2)
                        {
                            AppendOutput(LanguageManager.T("OutputDownloadTreeFull"), LanguageManager.T("Warning"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    AppendOutput(LanguageManager.T("LoopError") + $" {ex.Message}", LanguageManager.T("Error"));
                    _consecutiveFailures = 0;
                    btn_Start.Enabled = false;
                    btn_Pause.Enabled = false;
                    btn_Stop.Enabled = true;
                    btn_Browse.Enabled = false;
                }

                await Task.Delay(_wtnsec, token);
            }
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            if (_loopCts == null)
            {
                AppendOutput(LanguageManager.T("NoRunningProcess"), LanguageManager.T("Info"));

                btn_Start.Enabled = true;
                btn_Pause.Enabled = false;
                btn_Stop.Enabled = false;
                btn_Browse.Enabled = true;

                return;
            }
            if (!_loopCts.IsCancellationRequested)
            {
                _loopCts.Cancel();
                _isPaused = true;
                AppendOutput(LanguageManager.T("AppPaused"), LanguageManager.T("Ok"));
                btn_Pause.Text = LanguageManager.T("BtnResume");
            }
            else
            {
                _consecutiveFailures = 0;
                _loopCts = new CancellationTokenSource();
                _ = RunLoopAsync(_loopCts.Token);
                _isPaused = false;
                AppendOutput(LanguageManager.T("AppResume"), LanguageManager.T("Ok"));
                btn_Pause.Text = LanguageManager.T("BtnPause");
            }

            btn_Start.Enabled = false;
            btn_Pause.Enabled = true;
            btn_Stop.Enabled = true;
            btn_Browse.Enabled = false;
        }

        private async void btn_Stop_Click(object sender, EventArgs e)
        {
            if (_nolvusProcess == null || _nolvusProcess.HasExited)
            {
                AppendOutput(LanguageManager.T("NoRunningProcess"), LanguageManager.T("Info"));
                _isPaused = false;
                _consecutiveFailures = 0;
                _loopCts.Cancel();
                btn_Pause.Text = LanguageManager.T("BtnPause");
                btn_Start.Enabled = true;
                btn_Pause.Enabled = false;
                btn_Stop.Enabled = false;
                btn_Browse.Enabled = true;
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

                _isPaused = false;
                _consecutiveFailures = 0;
                btn_Start.Enabled = true;
                btn_Pause.Enabled = false;
                btn_Stop.Enabled = false;
                btn_Browse.Enabled = true;
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

            switch (_isPaused)
            {
                case true:
                    btn_Pause.Text = LanguageManager.T("BtnResume");
                    break;

                case false:
                    btn_Pause.Text = LanguageManager.T("BtnPause");
                    break;
            }
        }

        private void rtb_Output_TextChanged(object sender, EventArgs e)
        {
            rtb_Output.SelectionStart = rtb_Output.Text.Length;
            rtb_Output.ScrollToCaret();
        }
    }
}
