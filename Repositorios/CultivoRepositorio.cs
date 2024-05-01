using IRMS.Context;
using IRMS.Model;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repositorios
{
    public interface ICultivoRepositorio
    {
        Task<List<Cultivo>> GetAll();
        Task<Cultivo> GetCultivo(int CultivoId);
        Task<Cultivo> CreateCultivo(string CultivoNombre, int NivelAgua, string Estado, int DispositivoId);
        Task<Cultivo> DeleteCultivo(int CultivoId);
        Task<Cultivo> UpdateCultivo(Cultivo cultivo);
    }
    public class CultivoRepositorio : ICultivoRepositorio
    {
        private readonly AppDbContextIRMS _db;
        public CultivoRepositorio(AppDbContextIRMS db)
        {
            _db = db;
        }
        public async Task<Cultivo> CreateCultivo(string CultivoNombre, int NivelAgua, string Estado, int DispositivoId)
        {
            Cultivo newCultivo = new Cultivo
            {
                CultivoNombre = CultivoNombre,
                NivelAgua = NivelAgua,
                Estado = Estado,
                DispositivoId = DispositivoId,
            };

            await _db.Cultivo.AddAsync(newCultivo);
            await _db.SaveChangesAsync();

            return newCultivo;
        }

        public async Task<Cultivo> DeleteCultivo(int CultivoId)
        {
            Cultivo deleteCultivo = await _db.Cultivo.FirstOrDefaultAsync(U => U.CultivoId == CultivoId);
            if(deleteCultivo != null) { _db.Cultivo.Remove(deleteCultivo); }

            await _db.SaveChangesAsync();
            return deleteCultivo;
        }

        public async Task<List<Cultivo>> GetAll()
        {
            return await _db.Cultivo.ToListAsync();
        }

        public async Task<Cultivo> GetCultivo(int CultivoId)
        {
            return await _db.Cultivo.Where(U => U.CultivoId == CultivoId).FirstAsync();
        }

        public async Task<Cultivo> UpdateCultivo(Cultivo cultivo)
        {
            _db.Cultivo.Update(cultivo);
            await _db.SaveChangesAsync();
            return cultivo;
        }
    }
}
