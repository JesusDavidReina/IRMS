using IRMS.Model;
using IRMS.Repositorios;

namespace IRMS.Servicios
{
    public interface IGranjaServicio
    {
        Task<List<Granja>> GetAll();
        Task<Granja> GetGranja(int id);
        Task<Granja> CreateGranja(string NombreGranja, int CultivoId, int ClimaId, string SistemaRiego, string Dificultad);
        Task<Granja> UpdateGranja(int GranjaId, string? NombreGranja = null, int? CultivoId = null, int? ClimaId = null, string? SistemaRiego = null, string? Dificultad = null);
        Task<Granja> DeleteGranja(int GranjaId);
    }
    public class GranjaServicio : IGranjaServicio
    {
        private readonly IGranjaRepositorio _granjaRepositorio;
        public GranjaServicio(IGranjaRepositorio granjaRepositorio)
        {
            _granjaRepositorio = granjaRepositorio;
        }
        public async Task<Granja> CreateGranja(string NombreGranja, int CultivoId, int ClimaId, string SistemaRiego, string Dificultad)
        {
            return await _granjaRepositorio.CreateGranja(NombreGranja, CultivoId, ClimaId, SistemaRiego, Dificultad);
        }

        public async Task<Granja> DeleteGranja(int GranjaId)
        {
            return await _granjaRepositorio.DeleteGranja(GranjaId);
        }

        public async Task<List<Granja>> GetAll()
        {
            return await _granjaRepositorio.GetAll();
        }

        public async Task<Granja> GetGranja(int id)
        {
            return await _granjaRepositorio.GetGranja(id);
        }

        public async Task<Granja> UpdateGranja(int GranjaId, string? NombreGranja = null, int? CultivoId = null, int? ClimaId = null, string? SistemaRiego = null, string? Dificultad = null)
        {
            Granja newGranja = await _granjaRepositorio.GetGranja(GranjaId);

            if (newGranja != null) 
            {
                if (NombreGranja != null) { newGranja.NombreGranja = NombreGranja; }
                if (CultivoId != null) { newGranja.CultivoId = (int) CultivoId; }
                if (ClimaId != null) { newGranja.ClimaId = (int) ClimaId; }
                if (SistemaRiego != null) { newGranja.SistemaRiego = SistemaRiego; }
                if (Dificultad != null) { newGranja.Dificultad = Dificultad; }
            }
            else { return null; }

            return await _granjaRepositorio.UpdateGranja(newGranja);
        }
    }
}
