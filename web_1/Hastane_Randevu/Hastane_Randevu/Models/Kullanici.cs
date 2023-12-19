namespace Hastane_Randevu.Models
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; } // Gerçek uygulamada şifreler hashlenmelidir
        public string Rol { get; set; }
        public string Eposta { get; set; }

        // İlişkilendirme: Bir kullanıcının birden fazla randevusu olabilir
        public ICollection<Randevu> Randevular { get; set; }
    }



}
