using IRMS.Context;
using IRMS.Model;
using Microsoft.EntityFrameworkCore;
namespace IRMS.Repositorios
{
    public interface IClimaRepositorio
    {
        Task<List<Clima>> GetALL();
        Task<Clima> GetClima(int ClimaId);
        Task<Clima> CreateClima(string NombreClima, string EfectoClima);
        Task<Clima> DeleteClima(int ClimaId);
        Task<Clima> UpdateClima(Clima Clima);
    }
    public class ClimaRepositorio : IClimaRepositorio
    {
        private readonly AppDbContextIRMS _db;
        public ClimaRepositorio(AppDbContextIRMS db)
        {
            _db = db;
        }
        public async Task<Clima> CreateClima(string NombreClima, string EfectoClima)
        {
            Clima newClima = new Clima
            {
                NombreClima = NombreClima,
                EfectoClima = EfectoClima
            };

            await _db.Clima.AddAsync(newClima);
            await _db.SaveChangesAsync();
            return newClima;
        }

        public async Task<Clima> DeleteClima(int ClimaId)
        {
            Clima deleteClima = await _db.Clima.FirstOrDefaultAsync(U => U.ClimaId == ClimaId);
            if (deleteClima != null) { _db.Clima.Remove(deleteClima); }

            await _db.SaveChangesAsync();
            return deleteClima;
        }

        public async Task<List<Clima>> GetALL()
        {
            return await _db.Clima.ToListAsync();
        }

        public async Task<Clima> GetClima(int ClimaId)
        {
            return await _db.Clima.Where(U => U.ClimaId == ClimaId).FirstAsync();
        }

        public async Task<Clima> UpdateClima(Clima Clima)
        {
            _db.Clima.Update(Clima);
            await _db.SaveChangesAsync();
            return Clima;
        }
    }
}
