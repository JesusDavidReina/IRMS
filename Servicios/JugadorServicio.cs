using IRMS.Model;
using IRMS.Repositorios;

namespace IRMS.Servicios
{
    public interface IJugadorServicio
    {
        Task<List<Jugador>> GetJugadorList();
        Task<Jugador> GetJugador(int JugadorId);
        Task<Jugador> CreateJugador(string Nombres, string Apellidos, string NombreUsuario, string password, string photo, string Email);
        Task<Jugador> DeleteJugador(int JugadorId);
        Task<Jugador> UpdateJugador(int JugadorId , string? Nombres = null, string? Apellidos = null, string? NombreUsuario = null, string? password = null, string? photo = null, string? Email = null);
    }
    public class JugadorServicio : IJugadorServicio
    {
        private readonly IJugadorRepositorio _jugadorRepositorio;
        public JugadorServicio(IJugadorRepositorio jugadorRepositorio)
        {
            _jugadorRepositorio = jugadorRepositorio;
        }
        public async Task<Jugador> CreateJugador(string Nombres, string Apellidos, string NombreUsuario, string password, string photo, string Email)
        {
            return await _jugadorRepositorio.CreateJugador(Nombres, Apellidos, NombreUsuario, password, photo, Email);
        }

        public async Task<Jugador> DeleteJugador(int JugadorId)
        {
            return await _jugadorRepositorio.DeleteJugador(JugadorId);
        }

        public async Task<Jugador> GetJugador(int JugadorId)
        {
            return await _jugadorRepositorio.GetJugador(JugadorId);
        }

        public async Task<List<Jugador>> GetJugadorList()
        {
            return await _jugadorRepositorio.GetJugadorList();
        }

        public async Task<Jugador> UpdateJugador(int JugadorId, string? Nombres = null, string? Apellidos = null, string? NombreUsuario = null, string? password = null, string? photo = null, string? Email = null)
        {
            Jugador newJugador = await _jugadorRepositorio.GetJugador(JugadorId);

            if (newJugador != null) 
            {
                if (Nombres != null) { newJugador.Nombres = Nombres; }
                if (Apellidos != null) { newJugador.Apellidos = Apellidos; }
                if (NombreUsuario != null) { newJugador.NombreUsuario= NombreUsuario; }
                if (password != null) { newJugador.password = password; }
                if (photo != null) { newJugador.photo = photo; }
                if (Email != null) { newJugador.Email = Email; }
            }
            else { return null; }

            return await _jugadorRepositorio.UpdateJugador(newJugador);
        }
    }
}
