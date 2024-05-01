using IRMS.Context;
using IRMS.Model;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repositorios
{
    public interface IPartidaRepositorio
    {
        Task<List<Partida>> GetAll();
        Task<Partida> GetPartida(int id);
        Task<Partida> CreatePartida(int NivelId, string Puntuacion, DateTime FechaGuardado, DateTime FechaCreacion, string PartidaEstado, int JugadorId);
        Task<Partida> UpdatePartida(Partida partida);
        Task<Partida> DeletePartida(int partidaid);

    }
    public class PartidaRepositorio : IPartidaRepositorio
    {
        private readonly AppDbContextIRMS _db;

        public PartidaRepositorio(AppDbContextIRMS db)
        {
            _db = db;
        }
        public async Task<Partida> CreatePartida(int GranjaId, string Puntuacion, DateTime FechaGuardado, DateTime FechaCreacion, string PartidaEstado, int JugadorId)
        {
            Partida newPartida = new Partida
            {
                GranjaId = GranjaId,
                Puntuacion = Puntuacion,
                FechaGuardado = FechaGuardado,
                FechaCreacion = FechaCreacion,
                PartidaEstado = PartidaEstado,
                JugadorId = JugadorId
            };

            await _db.AddAsync(newPartida);
            await _db.SaveChangesAsync();
            return newPartida;
        }

        public async Task<Partida> DeletePartida(int partidaid)
        {
            Partida deletePartida = await _db.Partida.FirstOrDefaultAsync(U => U.PartidaId == partidaid);
            if (deletePartida != null) { _db.Partida.Remove(deletePartida); }

            await _db.SaveChangesAsync();
            return deletePartida;
        }

        public async Task<List<Partida>> GetAll()
        {
            return  await _db.Partida.ToListAsync();
        }

        public async Task<Partida> GetPartida(int id)
        {
            return await _db.Partida.Where(U => U.PartidaId == id).FirstAsync();
        }

        public async Task<Partida> UpdatePartida(Partida partida)
        {
            _db.Partida.Update(partida);
            await _db.SaveChangesAsync();
            return partida;
        }
    }
}
