namespace YurtOtomasyonuProject
{
    public class Odeme
    {
        public int FaturaNo { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public string TcKimlikNo { get; set; } = string.Empty;
        public decimal FaturaTutar { get; set; }

        public Odeme()
        {
            // Varsayılan yapıcı metot
        }
    }
}
