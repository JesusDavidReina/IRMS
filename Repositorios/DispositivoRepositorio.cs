using IRMS.Context;
using IRMS.Model;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repositorios
{
    public interface IDispositivoRepositorio
    {
        Task<List<Dispositivo>> GetAll();
        Task<Dispositivo> GetDispositivo(int DispositivoId);
        Task<Dispositivo> CreateDispositivo(string NombreDispositivo, string Descripcion, int TipoDispositivoId);
        Task<Dispositivo> UpdateDispositivo(Dispositivo dispositivo);
        Task<Dispositivo> DeleteDispositivo(int DispositivoId);
    }
    public class DispositivoRepositorio : IDispositivoRepositorio
    {
        private readonly AppDbContextIRMS _db;
        public DispositivoRepositorio(AppDbContextIRMS db)
        {
            _db = db;
        }
        public async Task<Dispositivo> CreateDispositivo(string NombreDispositivo, string Descripcion, int TipoDispositivoId)
        {
            Dispositivo newDispositivo = new Dispositivo
            {
                NombreDispositivo = NombreDispositivo,
                Descripcion = Descripcion,
                TipoDispositivoId = TipoDispositivoId
            };

            await _db.AddAsync(newDispositivo);
            await _db.SaveChangesAsync();
            return newDispositivo;
        }

        public async Task<Dispositivo> DeleteDispositivo(int DispositivoId)
        {
            Dispositivo deleteDispositivo = await _db.Dispositivo.FirstOrDefaultAsync(U => U.DispositivoId == DispositivoId);
            if (deleteDispositivo != null) { _db.Dispositivo.Remove(deleteDispositivo); }

            await _db.SaveChangesAsync();
            return deleteDispositivo;

        }

        public async Task<List<Dispositivo>> GetAll()
        {
            return await _db.Dispositivo.ToListAsync();
        }

        public async Task<Dispositivo> GetDispositivo(int DispositivoId)
        {
            return await _db.Dispositivo.Where(U => U.DispositivoId == DispositivoId).FirstOrDefaultAsync();
        }

        public async Task<Dispositivo> UpdateDispositivo(Dispositivo dispositivo)
        {
            _db.Dispositivo.Update(dispositivo);
            await _db.SaveChangesAsync();
            return dispositivo;
        }
    }
}
