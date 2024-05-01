using IRMS.Model;
using IRMS.Repositorios;

namespace IRMS.Servicios
{
    public interface ICultivoServicio
    {
        Task<List<Cultivo>> GetAll();
        Task<Cultivo> GetCultivo(int CultivoId);
        Task<Cultivo> CreateCultivo(string CultivoNombre, string Estado, int NivelAgua, int DispositivoId);
        Task<Cultivo> DeleteCultivo(int CultivoId);
        Task<Cultivo> UpdateCultivo(int CultivoId, string? CultivoNombre = null, string? Estado = null, int? NivelAgua = null, int? DispositivoId = null);
    }
    public class CultivoServicio : ICultivoServicio
    {
        private readonly ICultivoRepositorio _cultivoRepositorio;
        public CultivoServicio(ICultivoRepositorio cultivoRepositorio)
        {
            _cultivoRepositorio = cultivoRepositorio;
        }
        public async Task<Cultivo> CreateCultivo(string CultivoNombre, string Estado, int NivelAgua, int DispositivoId)
        {
            return await _cultivoRepositorio.CreateCultivo(CultivoNombre, NivelAgua, Estado, DispositivoId);
        }

        public async Task<Cultivo> DeleteCultivo(int CultivoId)
        {
            return await _cultivoRepositorio.DeleteCultivo(CultivoId);
        }

        public async Task<List<Cultivo>> GetAll()
        {
            return await _cultivoRepositorio.GetAll();
        }

        public async Task<Cultivo> GetCultivo(int CultivoId)
        {
            return await _cultivoRepositorio.GetCultivo(CultivoId);
        }

        public async Task<Cultivo> UpdateCultivo(int CultivoId, string? CultivoNombre = null, string? Estado = null, int? NivelAgua = null, int? DispositivoId = null)
        {
            Cultivo newCultivo = await _cultivoRepositorio.GetCultivo(CultivoId);

            if (newCultivo != null) 
            {
                if (CultivoNombre != null) { newCultivo.CultivoNombre = CultivoNombre; }
                if (DispositivoId != null) { newCultivo.DispositivoId = (int) DispositivoId; }
                if (NivelAgua != null) { newCultivo.NivelAgua = (int) NivelAgua; }
                if (Estado != null) { newCultivo.Estado = Estado; }
            }
            else { return null; }

            return await _cultivoRepositorio.UpdateCultivo(newCultivo);
        }
    }
}
