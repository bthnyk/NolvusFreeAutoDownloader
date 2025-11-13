# NolvusFreeAutoDownloader
![example](https://github.com/user-attachments/assets/ed8ad33c-86b6-46ac-b4ec-95cd3d52c0c9)


## English
### Quickstart
- To get started, simply select the Nolvus Dashboard executable file and hit the Start button. The program will launch the application with the `--remote-debugging-port=8088` flag and automatically monitor the download pages through this connection.
- You can set a wait timer between 5 and 10 seconds for the process interval. If you want to stop the process at any time, just press the Stop button.
- The program supports both Turkish and English languages and includes Dark and Light theme options so you can customize the interface to your preference.

The only requirement is that your system has .NET Framework 4.7.2 installed.

**How It Works**
- The program starts the selected Nolvus Dashboard executable with the `--remote-debugging-port=8088 parameter`. Then it automatically clicks the "Slow Download" buttons on the mod download pages opened via `http://localhost:8088/`, speeding up the download process.


## Türkçe
### Hızlı Başlangıç
- Programı kullanmak için sadece Nolvus Dashboard'un .exe dosyasını seçip Start butonuna tıklamanız yeterlidir. Program, seçilen uygulamayı otomatik olarak `--remote-debugging-port=8088` parametresiyle başlatır ve arka planda bu bağlantı üzerinden indirme sayfalarını kontrol eder.
- Programda ayrıca, işlem bekleme süresi için 5 ile 10 saniye arasında ayarlanabilen bir sayaç bulunmaktadır. İsterseniz işlemi durdurmak için Stop butonunu kullanabilirsiniz.
- Dil desteği Türkçe ve İngilizce olarak mevcuttur. Ayrıca Karanlık ve Aydınlık tema seçenekleri ile arayüzü istediğiniz gibi değiştirebilirsiniz.

Programın tek gereksinimi, sisteminizde .NET Framework 4.7.2'nin kurulu olmasıdır.

**Çalışma Prensibi**
- Program, seçilen Nolvus Dashboard uygulamasını `--remote-debugging-port=8088` parametresi ile başlatır. Ardından `http://localhost:8088/` adresinden açılan mod indirme sayfalarındaki "Slow Download" butonlarına otomatik olarak tıklayarak indirme işlemini hızlandırır.
