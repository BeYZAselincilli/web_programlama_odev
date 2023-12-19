namespace Hastane_Randevu.Models
{
    public class Randevu
    {
        public int RandevuID { get; set; }
        public int KullaniciID { get; set; }
        public int DoktorID { get; set; }
        public int PoliklinikID { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public TimeSpan RandevuSaati { get; set; }

        // Navigation properties
        public Kullanici Kullanici { get; set; }
        public Doktor Doktor { get; set; }
        public Poliklinik Poliklinik { get; set; }
    }

}
