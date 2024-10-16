using Microsoft.EntityFrameworkCore;
using SolidarizeMVC.Models;

namespace SolidarizeMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CampanhaModel> Campanhas { get; set; }
        public DbSet<DoacaoModel> Doacoes { get; set; }
        public DbSet<DoadorModel> Doadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DoacaoModel>()
                .HasOne(d => d.Campanha)
                .WithMany(c => c.Doacoes)
                .HasForeignKey(d => d.CampanhaId);

            modelBuilder.Entity<DoacaoModel>()
                .HasOne(d => d.Doador)
                .WithMany(d => d.Doacoes)
                .HasForeignKey(d => d.DoadorId);
        }
    }
}
