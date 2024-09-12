namespace YurtOtomasyonuProject
{
    public class Ogrenci
    {
        public string TcKimlikNo { get; set; } = string.Empty;
        public string AdSoyad { get; set; } = string.Empty;
        public DateTime DogumTarihi { get; set; }
        public string Cinsiyet { get; set; } = string.Empty;
        public string TelefonNo { get; set; } = string.Empty;
        public string Parmakizi { get; set; } = string.Empty;
        public string Adres { get; set; } = string.Empty;
        public string OgrenimDurumu { get; set; } = string.Empty;
        public int OdaNo { get; set; }

        
        public Ogrenci()
        {
            
        }
    }
}
