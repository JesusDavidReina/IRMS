using IRMS.Model;
using IRMS.Repositorios;

namespace IRMS.Servicios
{
    public interface IPartidaServicio
    {
        Task<List<Partida>> GetAll();
        Task<Partida> GetPartida(int id);
        Task<Partida> CreatePartida(int NivelId, string Puntuacion, DateTime FechaGuardado, DateTime FechaCreacion, string PartidaEstado, int JugadorId);
        Task<Partida> UpdatePartida(int PartdidaId, int? NivelId = null, string? Puntuacion = null, DateTime? FechaGuardado = null, DateTime? FechaCreacion = null, string? PartidaEstado = null, int? JugadorId = null);
        Task<Partida> DeletePartida(int partidaid);
    }
    public class PartidaServicio : IPartidaServicio
    {
        private readonly IPartidaRepositorio _partidaRepositorio;
        public PartidaServicio(IPartidaRepositorio partidaRepositorio)
        {
            _partidaRepositorio = partidaRepositorio;
        }
        public async Task<Partida> CreatePartida(int NivelId, string Puntuacion, DateTime FechaGuardado, DateTime FechaCreacion, string PartidaEstado, int JugadorId)
        {
            return await _partidaRepositorio.CreatePartida(NivelId, Puntuacion, FechaGuardado, FechaCreacion, PartidaEstado, JugadorId);
        }

        public async Task<Partida> DeletePartida(int partidaid)
        {
            return await _partidaRepositorio.DeletePartida(partidaid);
        }

        public async Task<List<Partida>> GetAll()
        {
            return await _partidaRepositorio.GetAll();
        }

        public async Task<Partida> GetPartida(int id)
        {
            return await _partidaRepositorio.GetPartida(id);
        }

        public async Task<Partida> UpdatePartida(int PartdidaId, int? GranjaId = null, string? Puntuacion = null, DateTime? FechaGuardado = null, DateTime? FechaCreacion = null, string? PartidaEstado = null, int? JugadorId = null)
        {
            Partida newPartida = await _partidaRepositorio.GetPartida(PartdidaId);

            if (newPartida != null) 
            {
                if (GranjaId != null) { newPartida.GranjaId = (int) GranjaId; }
                if (Puntuacion != null) { newPartida.Puntuacion = Puntuacion; }
                if (FechaGuardado != null) { newPartida.FechaGuardado = (DateTime)FechaGuardado; }
                if (FechaCreacion != null) { newPartida.FechaCreacion =  (DateTime)FechaCreacion; }
                if (PartidaEstado != null) { newPartida.PartidaEstado = PartidaEstado; }
                if (JugadorId != null) { newPartida.JugadorId =  (int) JugadorId; }
            }
            else { return null; }

            return await _partidaRepositorio.UpdatePartida(newPartida);
        }
    }
}
