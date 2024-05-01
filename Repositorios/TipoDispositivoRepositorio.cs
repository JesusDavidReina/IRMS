using IRMS.Context;
using IRMS.Model;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repositorios
{
    public interface ITipoDispositivoRepositorio
    {
        Task<List<TipoDispositivo>> GetAll();
        Task<TipoDispositivo> GetTipoDispositivo(int TipoDispositoId);
        Task<TipoDispositivo> CreateTipoDispositivo(string NombreDispositivo);
        Task<TipoDispositivo> UpdateTipoDispositivo(TipoDispositivo tipoDispositivo);
        Task<TipoDispositivo> DeleteTipoDispositivo(int TipoDispositivoId);

    }
    public class TipoDispositivoRepositorio : ITipoDispositivoRepositorio
    {
        private readonly AppDbContextIRMS _db;
        public TipoDispositivoRepositorio(AppDbContextIRMS db)
        {
            _db = db;
        }
        public async Task<TipoDispositivo> CreateTipoDispositivo(string NombreDispositivo)
        {
            TipoDispositivo newTipoDispositivo = new TipoDispositivo
            {
                NombreTipoDispositivo = NombreDispositivo
            };

            await _db.AddAsync(newTipoDispositivo);
            await _db.SaveChangesAsync();

            return newTipoDispositivo;
        }

        public async Task<TipoDispositivo> DeleteTipoDispositivo(int TipoDispositivoId)
        {
            TipoDispositivo deleteTipoDsipositivo = await _db.TipoDispositivo.FirstOrDefaultAsync(U =>U.TipoDispositivoId == TipoDispositivoId);
            if (deleteTipoDsipositivo != null) { _db.TipoDispositivo.Remove(deleteTipoDsipositivo);}

            await _db.SaveChangesAsync();
            return deleteTipoDsipositivo;
        }

        public async Task<List<TipoDispositivo>> GetAll()
        {
            return await _db.TipoDispositivo.ToListAsync();
        }

        public async Task<TipoDispositivo> GetTipoDispositivo(int TipoDispositoId)
        {
            return await _db.TipoDispositivo.Where(U => U.TipoDispositivoId == TipoDispositoId).FirstOrDefaultAsync();
        }

        public async Task<TipoDispositivo> UpdateTipoDispositivo(TipoDispositivo tipoDispositivo)
        {
            _db.TipoDispositivo.Update(tipoDispositivo);
            await _db.SaveChangesAsync();
            return tipoDispositivo;
        }
    }
}
