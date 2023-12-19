namespace Hastane_Randevu.Models
{
    
    public class CalismaTakvimi
    {
        public int CalismaTakvimiID { get; set; }
        public int DoktorID { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }
        // Navigation property
        public Doktor Doktor { get; set; }
    }
}
