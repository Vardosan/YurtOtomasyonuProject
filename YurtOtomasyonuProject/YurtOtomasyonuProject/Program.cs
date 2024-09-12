using System;
using YurtOtomasyonuProject;

namespace YurtOtomasyonuProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database("localhost", "yurtotomasyonu_8", "postgres", "123456");

            OdaManager odaManager = new OdaManager(db);
            OgrenciManager ogrenciManager = new OgrenciManager(db);
            MemurManager memurManager = new MemurManager(db); // MemurManager örneği oluşturuldu
            GuvenlikManager guvenlikManager = new GuvenlikManager(db);
            OdemeManager odemeManager = new OdemeManager(db);
            MobilyaManager mobilyaManager = new MobilyaManager(db); // MobilyaManager örneği oluşturuldu

            while (true)
            {
                Console.WriteLine("=== Yurt Otomasyon Sistemine Hoşgeldiniz ===");
                Console.WriteLine("1. Oda Ekle");
                Console.WriteLine("2. Oda Listele");
                Console.WriteLine("3. Oda Sil");
                Console.WriteLine("4. Öğrenci Ekle");
                Console.WriteLine("5. Öğrenci Listele");
                Console.WriteLine("6. Öğrenci Sil");
                Console.WriteLine("7. Memur Ekle");
                Console.WriteLine("8. Memur Listele");
                Console.WriteLine("9. Memur Sil");
                Console.WriteLine("10. Güvenlik Ekle");
                Console.WriteLine("11. Güvenlik Listele");
                Console.WriteLine("12. Güvenlik Sil");
                Console.WriteLine("13. Ödeme Ekle");
                Console.WriteLine("14. Ödeme Listele");
                Console.WriteLine("15. Ödeme Sil");
                Console.WriteLine("16. Mobilya Ekle");
                Console.WriteLine("17. Mobilya Listele");
                Console.WriteLine("18. Mobilya Sil");
                Console.WriteLine("0. Çıkış");
                Console.Write("Seçiminiz: ");
                var secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        // Oda ekleme işlemleri
                        Oda yeniOda = new Oda();

                        Console.Write("Yatak Sayısı: ");
                        yeniOda.YatakSayisi = int.Parse(Console.ReadLine());

                        Console.Write("Oda Tipi: ");
                        yeniOda.OdaTipi = Console.ReadLine() ?? string.Empty;

                        Console.Write("Kat No: ");
                        yeniOda.KatNo = int.Parse(Console.ReadLine());

                        odaManager.OdaEkle(yeniOda);
                        Console.WriteLine("Oda başarıyla eklendi.");
                        break;

                    case "2":
                        // Oda listeleme işlemleri
                        var odalar = odaManager.OdaListele();
                        Console.WriteLine("=== Odalar Listesi ===");
                        foreach (var oda in odalar)
                        {
                            Console.WriteLine($"Oda No: {oda.OdaNo}, Yatak Sayısı: {oda.YatakSayisi}, Oda Tipi: {oda.OdaTipi}, Kat No: {oda.KatNo}");
                        }
                        break;

                    case "3":
                        // Oda silme işlemleri
                        Console.Write("Silinecek Oda Numarasını Girin: ");
                        if (int.TryParse(Console.ReadLine(), out int odaNo))
                        {
                            odaManager.OdaSil(odaNo);
                            Console.WriteLine("Oda başarıyla silindi.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz oda numarası.");
                        }
                        break;

                    case "4":
                        // Öğrenci ekleme işlemleri
                        Ogrenci yeniOgrenci = new Ogrenci();

                        Console.Write("T.C. Kimlik No: ");
                        yeniOgrenci.TcKimlikNo = Console.ReadLine() ?? string.Empty;

                        Console.Write("Ad Soyad: ");
                        yeniOgrenci.AdSoyad = Console.ReadLine() ?? string.Empty;

                        Console.Write("Doğum Tarihi (yyyy-AA-gg): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime dogumTarihi))
                        {
                            yeniOgrenci.DogumTarihi = dogumTarihi;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz tarih formatı.");
                            break;
                        }

                        Console.Write("Cinsiyet: ");
                        yeniOgrenci.Cinsiyet = Console.ReadLine() ?? string.Empty;

                        Console.Write("Telefon No: ");
                        yeniOgrenci.TelefonNo = Console.ReadLine() ?? string.Empty;

                        Console.Write("Parmak İzi: ");
                        yeniOgrenci.Parmakizi = Console.ReadLine() ?? string.Empty;

                        Console.Write("Adres: ");
                        yeniOgrenci.Adres = Console.ReadLine() ?? string.Empty;

                        Console.Write("Öğrenim Durumu: ");
                        yeniOgrenci.OgrenimDurumu = Console.ReadLine() ?? string.Empty;

                        Console.Write("Oda No: ");
                        if (int.TryParse(Console.ReadLine(), out int ogrOdaNo))
                        {
                            yeniOgrenci.OdaNo = ogrOdaNo;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz oda numarası.");
                            break;
                        }

                        ogrenciManager.OgrenciEkle(yeniOgrenci);
                        Console.WriteLine("Öğrenci başarıyla eklendi.");
                        break;

                    case "5":
                        // Öğrenci listeleme işlemleri
                        var ogrenciler = ogrenciManager.OgrenciListele();
                        Console.WriteLine("=== Öğrenciler Listesi ===");
                        foreach (var ogrenci in ogrenciler)
                        {
                            Console.WriteLine($"Ad Soyad: {ogrenci.AdSoyad}, T.C. No: {ogrenci.TcKimlikNo}, Oda No: {ogrenci.OdaNo}");
                        }
                        break;

                    case "6":
                        // Öğrenci silme işlemleri
                        Console.Write("Silinecek Öğrencinin T.C. Kimlik Numarasını Girin: ");
                        string? tcKimlikNo = Console.ReadLine();
                        if (!string.IsNullOrEmpty(tcKimlikNo))
                        {
                            ogrenciManager.OgrenciSil(tcKimlikNo);
                            Console.WriteLine("Öğrenci başarıyla silindi.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz T.C. Kimlik No.");
                        }
                        break;

                    case "7":
                        // Memur ekleme işlemleri
                        Memur yeniMemur = new Memur();

                        Console.Write("T.C. Kimlik No: ");
                        yeniMemur.TcKimlikNo = Console.ReadLine() ?? string.Empty;

                        Console.Write("Ad Soyad: ");
                        yeniMemur.AdSoyad = Console.ReadLine() ?? string.Empty;

                        Console.Write("Pozisyon: ");
                        yeniMemur.Pozisyon = Console.ReadLine() ?? string.Empty;

                        Console.Write("Maaş: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal maas))
                        {
                            yeniMemur.Maas = maas;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz maaş formatı.");
                            break;
                        }

                        Console.Write("Telefon No: ");
                        yeniMemur.TelefonNo = Console.ReadLine() ?? string.Empty;

                        Console.Write("Adres: ");
                        yeniMemur.Adres = Console.ReadLine() ?? string.Empty;

                        memurManager.MemurEkle(yeniMemur);
                        Console.WriteLine("Memur başarıyla eklendi.");
                        break;

                    case "8":
                        // Memur listeleme işlemleri
                        var memurlar = memurManager.MemurListele();
                        Console.WriteLine("=== Memurlar Listesi ===");
                        foreach (var memur in memurlar)
                        {
                            Console.WriteLine($"T.C. Kimlik No: {memur.TcKimlikNo}, Ad Soyad: {memur.AdSoyad}, Pozisyon: {memur.Pozisyon}, Maaş: {memur.Maas}, Telefon No: {memur.TelefonNo}, Adres: {memur.Adres}");
                        }
                        break;

                    case "9":
                        // Memur silme işlemleri
                        Console.Write("Silinecek Memurun T.C. Kimlik Numarasını Girin: ");
                        string? memurTcKimlikNo = Console.ReadLine();
                        if (!string.IsNullOrEmpty(memurTcKimlikNo))
                        {
                            memurManager.MemurSil(memurTcKimlikNo);
                            Console.WriteLine("Memur başarıyla silindi.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz T.C. Kimlik No.");
                        }
                        break;
                    case "10":
                        // Güvenlik ekleme işlemleri
                        Guvenlik yeniGuvenlik = new Guvenlik();

                        Console.Write("T.C. Kimlik No: ");
                        yeniGuvenlik.TcKimlikNo = Console.ReadLine() ?? string.Empty;

                        Console.Write("Ad Soyad: ");
                        yeniGuvenlik.AdSoyad = Console.ReadLine() ?? string.Empty;

                        Console.Write("Pozisyon: ");
                        yeniGuvenlik.Pozisyon = Console.ReadLine() ?? string.Empty;

                        Console.Write("Maaş: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal guvMaas))
                        {
                            yeniGuvenlik.Maas = guvMaas;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz maaş formatı.");
                            break;
                        }

                        Console.Write("Telefon No: ");
                        yeniGuvenlik.TelefonNo = Console.ReadLine() ?? string.Empty;

                        Console.Write("Adres: ");
                        yeniGuvenlik.Adres = Console.ReadLine() ?? string.Empty;

                        guvenlikManager.GuvenlikEkle(yeniGuvenlik);
                        Console.WriteLine("Güvenlik personeli başarıyla eklendi.");
                        break;

                    case "11":
                        // Güvenlik listeleme işlemleri
                        var guvenlikler = guvenlikManager.GuvenlikListele();
                        Console.WriteLine("=== Güvenlik Personelleri Listesi ===");
                        foreach (var guvenlik in guvenlikler)
                        {
                            Console.WriteLine($"T.C. Kimlik No: {guvenlik.TcKimlikNo}, Ad Soyad: {guvenlik.AdSoyad}, Pozisyon: {guvenlik.Pozisyon}, Maaş: {guvenlik.Maas}, Telefon No: {guvenlik.TelefonNo}, Adres: {guvenlik.Adres}");
                        }
                        break;

                    case "12":
                        // Güvenlik silme işlemleri
                        Console.Write("Silinecek Güvenlik Personelinin T.C. Kimlik Numarasını Girin: ");
                        string? guvenlikTcKimlikNo = Console.ReadLine();
                        if (!string.IsNullOrEmpty(guvenlikTcKimlikNo))
                        {
                            guvenlikManager.GuvenlikSil(guvenlikTcKimlikNo);
                            Console.WriteLine("Güvenlik personeli başarıyla silindi.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz T.C. Kimlik No.");
                        }
                        break;
                    case "13":
                        // Ödeme ekleme işlemleri
                        Odeme yeniOdeme = new Odeme();

                        Console.Write("Ödeme Tarihi (yyyy-AA-gg SS:dd:ss): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime odemeTarihi))
                        {
                            yeniOdeme.OdemeTarihi = odemeTarihi;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz tarih formatı.");
                            break;
                        }

                        Console.Write("T.C. Kimlik No: ");
                        yeniOdeme.TcKimlikNo = Console.ReadLine() ?? string.Empty;

                        Console.Write("Fatura Tutarı: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal faturaTutar))
                        {
                            yeniOdeme.FaturaTutar = faturaTutar;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz tutar.");
                            break;
                        }

                        odemeManager.OdemeEkle(yeniOdeme);
                        Console.WriteLine("Ödeme başarıyla eklendi.");
                        break;

                    case "14":
                        // Ödeme listeleme işlemleri
                        var odemeler = odemeManager.OdemeListele();
                        Console.WriteLine("=== Ödemeler Listesi ===");
                        foreach (var odeme in odemeler)
                        {
                            Console.WriteLine($"Fatura No: {odeme.FaturaNo}, Tarih: {odeme.OdemeTarihi:yyyy-MM-dd HH:mm:ss}, T.C. No: {odeme.TcKimlikNo}, Tutar: {odeme.FaturaTutar} TL");
                        }
                        break;

                    case "15":
                        // Ödeme silme işlemleri
                        Console.Write("Silinecek Fatura Numarasını Girin: ");
                        if (int.TryParse(Console.ReadLine(), out int faturaNo))
                        {
                            odemeManager.OdemeSil(faturaNo);
                            Console.WriteLine("Ödeme başarıyla silindi.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz fatura numarası.");
                        }
                        break;
                    case "16":
                        // Mobilya ekleme işlemleri
                        Mobilya yeniMobilya = new Mobilya();

                        Console.Write("Mobilya Kodu: ");
                        if (int.TryParse(Console.ReadLine(), out int mobilyaKodu))
                        {
                            yeniMobilya.MobilyaKodu = mobilyaKodu;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz mobilya kodu.");
                            break;
                        }

                        Console.Write("Oda No: ");
                        if (int.TryParse(Console.ReadLine(), out int mobOdaNo))
                        {
                            yeniMobilya.OdaNo = mobOdaNo;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz oda numarası.");
                            break;
                        }

                        Console.Write("T.C. Kimlik No: ");
                        yeniMobilya.TcKimlikNo = Console.ReadLine() ?? string.Empty;

                        mobilyaManager.MobilyaEkle(yeniMobilya);
                        Console.WriteLine("Mobilya başarıyla eklendi.");
                        break;

                    case "17":
                        // Mobilya listeleme işlemleri
                        var mobilyalar = mobilyaManager.MobilyaListele();
                        Console.WriteLine("=== Mobilyalar Listesi ===");
                        foreach (var mobilya in mobilyalar)
                        {
                            Console.WriteLine($"Mobilya Kodu: {mobilya.MobilyaKodu}, Oda No: {mobilya.OdaNo}, T.C. No: {mobilya.TcKimlikNo}");
                        }
                        break;

                    case "18":
                        // Mobilya silme işlemleri
                        Console.Write("Silinecek Mobilya Kodunu Girin: ");
                        if (int.TryParse(Console.ReadLine(), out int silMobilyaKodu))
                        {
                            mobilyaManager.MobilyaSil(silMobilyaKodu);
                            Console.WriteLine("Mobilya başarıyla silindi.");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz mobilya kodu.");
                        }
                        break;

                    case "0":
                        // Programdan çıkış
                        Console.WriteLine("Programdan çıkılıyor...");
                        return;

                    default:
                        Console.WriteLine("Geçersiz seçenek.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}

