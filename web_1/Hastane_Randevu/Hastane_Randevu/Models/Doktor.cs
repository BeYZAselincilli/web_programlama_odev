namespace Hastane_Randevu.Models
{
    public class Doktor
    {
        public int DoktorID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int UzmanlikAlaniID { get; set; }

        // Navigation property
        public UzmanlikAlani UzmanlikAlani { get; set; }
        public ICollection<Randevu> Randevular { get; set; }
        public ICollection<CalismaTakvimi> CalismaTakvimi { get; set; }
    }

}
