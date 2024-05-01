using IRMS.Context;
using IRMS.Model;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Repositorios
{
    public interface IGranjaRepositorio
    {
        Task<List<Granja>> GetAll();
        Task<Granja> GetGranja(int id);
        Task<Granja> CreateGranja(string NombreGranja, int CultivoId, int ClimaId, string SistemaRiego, string Dificultad);
        Task<Granja> UpdateGranja(Granja granja);
        Task<Granja> DeleteGranja(int granjaId);
    }
    public class GranjaRepositorio : IGranjaRepositorio
    {
        private readonly AppDbContextIRMS _db;
        public GranjaRepositorio(AppDbContextIRMS db)
        {
            _db = db;
        }
        public async Task<Granja> CreateGranja(string NombreGranja, int CultivoId, int ClimaId, string SistemaRiego, string Dificultad)
        {
            Granja newGranja = new Granja
            {
                NombreGranja = NombreGranja,
                CultivoId = CultivoId,
                ClimaId = ClimaId,
                SistemaRiego = SistemaRiego,
                Dificultad = Dificultad
            };

            await _db.Granja.AddAsync(newGranja);
            await _db.SaveChangesAsync();
            return newGranja;
        }

        public async Task<Granja> DeleteGranja(int granjaId)
        {
            Granja deleteGranja = await _db.Granja.FirstOrDefaultAsync(U => U.GranjaId == granjaId);
            if (deleteGranja != null) { _db.Granja.Remove(deleteGranja); }

            await _db.SaveChangesAsync();
            return deleteGranja;
        }

        public async Task<List<Granja>> GetAll()
        {
            return await _db.Granja.ToListAsync();
        }

        public async Task<Granja> GetGranja(int id)
        {
            return await _db.Granja.Where(U => U.GranjaId == id).FirstAsync();
        }

        public async Task<Granja> UpdateGranja(Granja granja)
        {
            _db.Granja.Update(granja);
            await _db.SaveChangesAsync();
            return granja;
        }
    }
}
