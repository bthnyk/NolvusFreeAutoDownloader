using System;
using System.Threading;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace NolvusFreeAutoDownloader
{
    public class DebugConnector : IDisposable
    {
        private IBrowser _browser;
        private bool _isConnected;
        private readonly string _remoteDebuggingUrl;

        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public DebugConnector(string remoteDebuggingUrl = "http://localhost:8088")
        {
            _remoteDebuggingUrl = remoteDebuggingUrl;
        }

        public async Task ConnectAsync()
        {
            if (_isConnected) return;

            _browser = await Puppeteer.ConnectAsync(new ConnectOptions
            {
                BrowserURL = _remoteDebuggingUrl
            });

            _isConnected = true;
        }

        public async Task<bool> ProcessSkyrimNexusAsync(int consecutiveFailures)
        {
            if (!_isConnected)
                throw new InvalidOperationException(LanguageManager.T("ConnectAsyncError"));

            NfadMainForm.Instance?.AppendOutput(LanguageManager.T("OutputSearch"), LanguageManager.T("Task"));

            var pages = await _browser.PagesAsync();

            IPage targetPage = null;
            foreach (var page in pages)
            {
                var title = await page.EvaluateExpressionAsync<string>("document.title");
                if (title != null && title.Contains("Skyrim Special Edition Nexus"))
                {
                    targetPage = page;
                    NfadMainForm.Instance?.AppendOutput(LanguageManager.T("OutputTargetFound") + $" {title}", LanguageManager.T("Info"));
                    break;
                }
            }

            if (targetPage == null)
            {
                {
                    if (consecutiveFailures <= 1)
                        NfadMainForm.Instance?.AppendOutput(LanguageManager.T("OutputTargetNotFound"),
                            LanguageManager.T("Warning"));
                    return false;
                }
            }

            var downloadTitle = await targetPage.EvaluateExpressionAsync<string>("document.title");
            if (string.IsNullOrWhiteSpace(downloadTitle)) downloadTitle = LanguageManager.T("UnknownFileTitle");

            NfadMainForm.Instance?.AppendOutput(LanguageManager.T("OutputAdCheck"), LanguageManager.T("Task"));
            var adVisible = await targetPage.EvaluateExpressionAsync<bool>("!!document.querySelector('input.close-btn[type=\"checkbox\"]')");
            if (adVisible)
            {
                await targetPage.WaitForSelectorAsync("input.close-btn[type=\"checkbox\"]", new WaitForSelectorOptions { Visible = true });
                await targetPage.ClickAsync("input.close-btn[type=\"checkbox\"]");
                NfadMainForm.Instance?.AppendOutput(LanguageManager.T("OutputAdClosed"), LanguageManager.T("Ok"));
            }

            NfadMainForm.Instance?.AppendOutput(LanguageManager.T("OutputDownloadStarted") + $" {downloadTitle}", LanguageManager.T("Task"));
            
            try
            {
                NfadMainForm.Instance?.AppendOutput(LanguageManager.T("OutputShadowDOMSearch"), LanguageManager.T("Task"));

                string waitFunction = @"() => {
                    const host = document.querySelector('mod-file-download');
                    if (!host || !host.shadowRoot) {
                        return false;
                    }

                    const buttons = host.shadowRoot.querySelectorAll('button');
                    
                    for (const button of buttons) {
                        if (button.textContent.trim() === 'Slow download') {
                            return button;
                        }
                    }

                    return false;
                }";

                await targetPage.WaitForFunctionAsync(waitFunction, new WaitForFunctionOptions { Timeout = 30000 });

                NfadMainForm.Instance?.AppendOutput(LanguageManager.T("OutputShadowDOMFounded"), LanguageManager.T("Task"));

                string clickScript = @"() => {
                    const host = document.querySelector('mod-file-download');
                    const buttons = host.shadowRoot.querySelectorAll('button');
                    for (const button of buttons) {
                        if (button.textContent.trim() === 'Slow download') {
                            button.click();
                            return;
                        }
                    }
                }";

                await targetPage.EvaluateFunctionAsync(clickScript);
                
                NfadMainForm.Instance?.AppendOutput(LanguageManager.T("OutputDownloadButtonClicked"),
                    LanguageManager.T("Ok"));
                return true;
            }
            catch (Exception ex)
            {
                NfadMainForm.Instance?.AppendOutput(LanguageManager.T("OutputShadowDOMError") + ex.Message, LanguageManager.T("Error"));
                return false;
            }
        }

        private void StopLoop()
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }
        }

        public async Task DisconnectAsync()
        {
            StopLoop();

            if (_isConnected && _browser != null)
            {
                await _browser.CloseAsync();
                _isConnected = false;
            }
        }

        public void Dispose()
        {
            StopLoop();

            if (_browser != null)
            {
                _browser.CloseAsync().GetAwaiter().GetResult();
                _browser.Dispose();
            }
            _isConnected = false;
        }
    }
}
