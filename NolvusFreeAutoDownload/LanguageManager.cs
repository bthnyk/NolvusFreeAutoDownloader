using System.Collections.Generic;
using System.Threading;

namespace NolvusFreeAutoDownloader
{
    public enum SupportedLanguage
    {
        English,
        Turkish
    }

    public static class LanguageManager
    {
        public static SupportedLanguage CurrentLanguage { get; private set; }

        private static Dictionary<string, string> _translations;

        public static void Initialize()
        {
            var culture = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;

            SetLanguage(culture == "tr" ? SupportedLanguage.Turkish : SupportedLanguage.English);
        }

        public static void SetLanguage(SupportedLanguage language)
        {
            CurrentLanguage = language;

            if (language == SupportedLanguage.Turkish)
            {
                _translations = new Dictionary<string, string>
                {
                    // Arayüz metinlerinin Türkçe çevirileri
                    { "AppTitle", "HeX | Nolvus Dashboard | Oto-indirici Sihirbazı" },
                    { "BtnBrowse", "Göz At" },
                    { "BtnStart", "Başlat" },
                    { "BtnPause", "Duraklat" },
                    { "BtnResume", "Devam Et" },
                    { "BtnStop", "Durdur" },
                    { "LblTitle", "HeX tarafından hazırlanmıştır!" },
                    { "LblDescribe", "Nolvus Dashboard için oto-indirme tıklaması yapmaktadır." },
                    { "LblPath", "Nolvus Dashboard Yolu :" },
                    { "LblWtn", "Beklenecek" },
                    { "LblSec", "saniye" },

                    // Seviye bilgilendirme mesajları
                    { "Info", "BILGI" },
                    { "Task", "GOREV" },
                    { "Ok", "TAMAM" },
                    { "Warning", "UYARI" },
                    { "Error", "HATA" },

                    // Çıktı mesajlarının Türkçe çevirileri
                    { "SelectFile", "Nolvus Dashboard yürütülebilir dosyasını seçin!" },
                    { "SelectedFile", "Seçilen dosya:"},
                    { "SelectExe", "Lütfen Nolvus Dashboard'ı seçin!" },
                    { "AppAlreadyRunning", "Uygulama zaten çalışıyor." },
                    { "AppStarted", "Nolvus Dashboard başlatıldı." },
                    { "ConnectorConnecting", "DebugConnector bağlanıyor..." },
                    { "ConnectorConnected", "DebugConnector bağlandı." },
                    { "ProcessStarting", "İşlem başlatılıyor..." },
                    { "ProcessSuccess", "İşlem başarılı." },
                    { "ProcessFail", "İşlem başarısız." },
                    { "OutputDownloadTreeFull", "Aktif ağaç maksimum indirme sayısına sahiptir." },
                    { "AppPaused", "Otomatik tıklama duraklatıldı." },
                    { "AppResume", "Otomatik tıklama devam etmekte." },
                    { "NoRunningProcess", "Çalışan bir süreç yok." },
                    { "AppStopped", "Nolvus Dashboard durduruldu." },
                    { "AppStopError", "Durdurulurken hata oluştu:" },
                    { "LoopError", "Döngü hatası:" },
                    { "LoopCancelled", "Döngü iptal edildi." },
                    { "ConnectorClosed", "DebugConnector bağlantısı kapatıldı." },
                    { "OutputSearch", "Aktif istek taranıyor..." },
                    { "OutputTargetFound", "Aktif istek bulundu:" },
                    { "OutputTargetNotFound", "Aktif istek bulunamadı. Açık sekme var mı?" },
                    { "OutputAdCheck", "Reklam kontrolü yapılıyor..." },
                    { "OutputAdClosed", "Reklam kapatıldı." },
                    { "OutputDownloadStarted", "İndirme başlatılıyor:" },
                    { "OutputShadowDOMSearch", "Shadow DOM içinde 'Slow download' text'ine sahip buton aranıyor..."},
                    { "OutputShadowDOMFounded", "ShadowDOM içinde aranan buton bulundu, tıklanıyor..."},
                    { "OutputDownloadButtonClicked", "İndirme isteği onaylandı." },
                    { "OutputShadowDOMError", "ShadowDOM içinde buton aranırken hata oluştu (muhtemelen bulunamadı): "},
                    { "ConnectAsyncError", "Önce ConnectAsync çağrılmalı."},
                    { "UnknownFileTitle", "Bilinmeyen Dosya "},
                };
            }
            else
            {
                _translations = new Dictionary<string, string>
                {
                    // English translations of UI texts
                    { "AppTitle", "HeX | Nolvus Dashboard | Autodownloader Wizard" },
                    { "BtnBrowse", "Browse" },
                    { "BtnStart", "Start" },
                    { "BtnPause", "Pause" },
                    { "BtnResume", "Resume" },
                    { "BtnStop", "Stop" },
                    { "LblTitle", "Made by HeX!" },
                    { "LblDescribe", "Nolvus Dashboard makes an autodownload click." },
                    { "LblPath", "Nolvus Dashboard Path :" },
                    { "LblWtn", "Seconds" },
                    { "LblSec", "to wait" },
                    
                    // Level information messages
                    { "Info", "INFO" },
                    { "Task", "TASK" },
                    { "Ok", "OK" },
                    { "Warning", "WARNING" },
                    { "Error", "ERROR" },

                    // English translations of functions
                    { "SelectFile", "Select Nolvus Dashboard executable!" },
                    { "SelectedFile", "Selected file:"},
                    { "SelectExe", "Please select Nolvus Dashboard!" },
                    { "AppAlreadyRunning", "Application is already running." },
                    { "AppStarted", "Nolvus Dashboard started." },
                    { "ConnectorConnecting", "DebugConnector connecting..." },
                    { "ConnectorConnected", "DebugConnector connected." },
                    { "ProcessStarting", "Process starting..." },
                    { "ProcessSuccess", "Process succeeded." },
                    { "ProcessFail", "Process failed." },
                    { "OutputDownloadTreeFull", "Active tree has maximum number of downloads." },
                    { "AppPaused", "Auto-click paused." },
                    { "AppResume", "Auto-click to resume." },
                    { "NoRunningProcess", "No running process." },
                    { "AppStopped", "Nolvus Dashboard stopped." },
                    { "AppStopError", "Error while stopping:" },
                    { "LoopError", "Error on loop:" },
                    { "LoopCancelled", "Loop cancelled." },
                    { "ConnectorClosed", "DebugConnector connection closed." },
                    { "OutputSearch", "Active request scanning..." },
                    { "OutputTargetFound", "Active request found:" },
                    { "OutputTargetNotFound", "Active request not found. Any open tabs?" },
                    { "OutputAdCheck", "Advertising control is in progress..." },
                    { "OutputAdClosed", "The advert is closed." },
                    { "OutputDownloadStarted", "Download initiating: " },
                    { "OutputShadowDOMSearch", "Searching for a button with the text ‘Slow download’ in the Shadow DOM..."},
                    { "OutputShadowDOMFounded", "The button found in ShadowDOM is being clicked..."},
                    { "OutputDownloadButtonClicked", "Download request approved." },
                    { "OutputShadowDOMError", "An error occurred while searching for a button in ShadowDOM (probably not found): "},
                    { "ConnectAsyncError", "ConnectAsync must be called first."},
                    { "UnknownFileTitle", "Unknown File"},
                };
            }
        }

        public static string T(string key)
        {
            return _translations.TryGetValue(key, out var value) ? value : $"[{key}]";
        }
    }
}
