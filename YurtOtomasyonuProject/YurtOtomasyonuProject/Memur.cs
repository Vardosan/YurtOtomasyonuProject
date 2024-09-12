namespace YurtOtomasyonuProject
{
    public class Memur
    {
        public string TcKimlikNo { get; set; } = string.Empty; // T.C. Kimlik No, birincil anahtar
        public string AdSoyad { get; set; } = string.Empty; // Memurun adı ve soyadı
        public string Pozisyon { get; set; } = string.Empty; // Memurun pozisyonu
        public decimal Maas { get; set; } // Memurun maaşı
        public string TelefonNo { get; set; } = string.Empty; // Memurun telefon numarası
        public string Adres { get; set; } = string.Empty; // Memurun adresi

        public Memur()
        {
            // Varsayılan yapıcı metot
        }
    }
}

