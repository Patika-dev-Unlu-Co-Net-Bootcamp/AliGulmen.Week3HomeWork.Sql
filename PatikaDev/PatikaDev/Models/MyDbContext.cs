using Microsoft.EntityFrameworkCore;

namespace PatikaDev.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Egitim> Egitimler { get; set; }
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Katilimci> Katilimcilar { get; set; }
        public DbSet<Asistan> Asistanlar { get; set; }
        public DbSet<Egitmen> Egitmenler{ get; set; }
        public DbSet<EgitimOgrencileri> EgitimOgrencileri { get; set; }
        public DbSet<EgitimTarihleri> EgitimTarihleri { get; set; }
        public DbSet<EgitimYoklamalari> EgitimYoklamalari { get; set; }
        public DbSet<NotTablosu> NotTablosu { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }

}
