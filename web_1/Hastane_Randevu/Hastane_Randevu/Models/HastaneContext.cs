using Microsoft.EntityFrameworkCore;

namespace Hastane_Randevu.Models
{
    public class HastaneContext : DbContext
    {
        public DbSet<UzmanlikAlani> UzmanlikAlanlari { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<CalismaTakvimi> CalismaTakvimi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-EADT7F0\SQLEXPRESS;Database=HastaneRandevu1;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doktor>()
                .HasOne<UzmanlikAlani>()
                .WithMany()
                .HasForeignKey(d => d.UzmanlikAlaniID);

            modelBuilder.Entity<Randevu>()
                .HasOne<Kullanici>()
                .WithMany()
                .HasForeignKey(r => r.KullaniciID);

            modelBuilder.Entity<Randevu>()
                .HasOne<Doktor>()
                .WithMany()
                .HasForeignKey(r => r.DoktorID);

            modelBuilder.Entity<Randevu>()
                .HasOne<Poliklinik>()
                .WithMany()
                .HasForeignKey(r => r.PoliklinikID);

            modelBuilder.Entity<CalismaTakvimi>()
                .HasOne<Doktor>()
                .WithMany()
                .HasForeignKey(ct => ct.DoktorID);
        }
    }

  
}
