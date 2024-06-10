using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Autenticacao> Autenticacoes { get; set; }
        public DbSet<Aplicativo> Aplicativos { get; set; }
        public DbSet<SistemaAlerta> SistemasAlerta { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<Historico> Historicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar a relação muitos-para-muitos entre Sensor e Historico
            modelBuilder.Entity<Sensor>()
                .HasMany(s => s.Historicos)
                .WithMany(h => h.Sensores)
                .UsingEntity<Dictionary<string, object>>(
                    "SensorHistorico",
                    j => j.HasOne<Historico>().WithMany().HasForeignKey("HistoricoId"),
                    j => j.HasOne<Sensor>().WithMany().HasForeignKey("SensorId"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
