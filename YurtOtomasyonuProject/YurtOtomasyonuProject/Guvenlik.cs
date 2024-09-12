namespace YurtOtomasyonuProject
{
    public class Guvenlik
    {
        public string TcKimlikNo { get; set; } = string.Empty;
        public string AdSoyad { get; set; } = string.Empty;
        public string Pozisyon { get; set; } = string.Empty;
        public decimal Maas { get; set; }
        public string TelefonNo { get; set; } = string.Empty;
        public string Adres { get; set; } = string.Empty;

        public Guvenlik()
        {
            // Varsayılan yapıcı metot
        }
    }
}

