namespace Hastane_Randevu.Models
{
    public class Poliklinik
    {
        public int PoliklinikID { get; set; }
        public string PoliklinikAdi { get; set; }
        public string Konum { get; set; }

        // İlişkilendirme: Bir poliklinikte birden fazla randevu olabilir
        public ICollection<Randevu> Randevular { get; set; }
    }

}
