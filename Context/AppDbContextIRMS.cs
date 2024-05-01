using IRMS.Model;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Context
{
    public class AppDbContextIRMS : DbContext
    {
        public AppDbContextIRMS(DbContextOptions<AppDbContextIRMS> options) : base(options)
        {

        }
        public DbSet<Jugador> Jugador { get; set; }
        public DbSet<Partida> Partida { get; set; }
        public DbSet<Clima> Clima { get; set; }
        public DbSet<Cultivo> Cultivo { get; set;}
        public DbSet<Granja> Granja { get; set; }
        public DbSet<Accion> Accion { get; set; }
        public DbSet<AccionXPartida> AccionXPartida { get;}
        public DbSet<Dispositivo> Dispositivo { get; set;}
        public DbSet<TipoDispositivo> TipoDispositivo { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccionXPartida>()
                .HasKey(U => new { U.AccionPartidaId, U.AccionId, U.PartidaId });
        }
    }
}
