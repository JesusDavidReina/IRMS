using IRMS.Context;
using IRMS.Model;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repositorios
{
    public interface IJugadorRepositorio
    {
        Task<List<Jugador>> GetJugadorList();
        Task<Jugador> GetJugador(int JugadorId);
        Task<Jugador> CreateJugador(string Nombres, string Apellidos, string NombreUsuario, string password, string photo , string Email);
        Task<Jugador> DeleteJugador(int JugadorId);
        Task<Jugador> UpdateJugador(Jugador jugador);
    }
    public class JugadorRepositorio : IJugadorRepositorio
    {
        private readonly AppDbContextIRMS _db;
        public JugadorRepositorio(AppDbContextIRMS db)
        {
            _db = db;
        }
        public async Task<Jugador> CreateJugador(string Nombres, string Apellidos, string NombreUsuario, string password, string photo, string Email)
        {
            Jugador newJugador = new Jugador
            {
                Nombres = Nombres,
                Apellidos = Apellidos,
                NombreUsuario = NombreUsuario,
                password = password,
                photo = photo,
                Email = Email
            };

            await _db.Jugador.AddAsync(newJugador);
            await _db.SaveChangesAsync();
            return newJugador;
        }

        public async Task<Jugador> DeleteJugador(int JugadorId)
        {
            Jugador deleteJugador = await _db.Jugador.FirstOrDefaultAsync(U => U.JugadorId == JugadorId);
            if (deleteJugador != null) { _db.Jugador.Remove(deleteJugador); }

            
            await _db.SaveChangesAsync();
            return deleteJugador;
        }

        public async Task<Jugador> GetJugador(int JugadorId)
        {
            return await _db.Jugador.Where(U => U.JugadorId == JugadorId).FirstAsync();

        }

        public async Task<List<Jugador>> GetJugadorList()
        {
            return await _db.Jugador.ToListAsync();
        }

        public async Task<Jugador> UpdateJugador(Jugador jugador)
        {
            _db.Jugador.Update(jugador);
            await _db.SaveChangesAsync();
            return jugador;
        }
    }
}
