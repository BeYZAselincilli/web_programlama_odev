namespace Hastane_Randevu.Models
{
    public class UzmanlikAlani
    {
        public int UzmanlikAlaniID { get; set; }
        public string UzmanlikAlaniAdi { get; set; }

        // İlişkilendirme: Bir uzmanlık alanında birden fazla doktor olabilir
        public ICollection<Doktor> Doktorlar { get; set; }
    }

}
