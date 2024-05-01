using IRMS.Context;
using IRMS.Model;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repositorios
{
    public interface IAccionRepositorio
    {
        Task<List<Accion>> GetAll();
        Task<Accion> GetAccion(int AccionId);
        Task<Accion> CreateAccion(string NombreAccion, string Descipcion, int DispositivoId);
        Task<Accion> UpdateAccion(Accion accion);
        Task<Accion> DeleteAccion(int AccionId);

    }
    public class AccionRepositorio : IAccionRepositorio
    {
        private readonly AppDbContextIRMS _db;
        public AccionRepositorio(AppDbContextIRMS db)
        {
            _db = db;
        }
        public async Task<Accion> CreateAccion(string NombreAccion, string Descipcion, int DispositivoId)
        {
            Accion newAccion = new Accion
            {
                NombreAccion = NombreAccion,
                Descripcion = Descipcion,
                DispositivoId = DispositivoId
            };

            await _db.AddAsync(newAccion);
            await _db.SaveChangesAsync();
            return newAccion;
        }

        public async Task<Accion> DeleteAccion(int AccionId)
        {
            Accion deleteAccion = await _db.Accion.FirstOrDefaultAsync(U => U.AccionId == AccionId);
            if (deleteAccion != null) { _db.Accion.Remove(deleteAccion); }

            await _db.SaveChangesAsync();
            return deleteAccion;
        }

        public async Task<Accion> GetAccion(int AccionId)
        {
            return await _db.Accion.Where(U => U.AccionId == AccionId).FirstOrDefaultAsync();
        }

        public async Task<List<Accion>> GetAll()
        {
            return await _db.Accion.ToListAsync();
        }

        public async Task<Accion> UpdateAccion(Accion accion)
        {
            _db.Accion.Update(accion);
            await _db.SaveChangesAsync();
            return accion;
        }
    }
}
