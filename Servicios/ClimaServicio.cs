using IRMS.Model;
using IRMS.Repositorios;

namespace IRMS.Servicios
{
    public interface IClimaServicio
    {
        Task<List<Clima>> GetALL();
        Task<Clima> GetClima(int ClimaId);
        Task<Clima> CreateClima(string NombreClima, string EfectoClima);
        Task<Clima> DeleteClima(int ClimaId);
        Task<Clima> UpdateClima(int ClimaId, string? TipoClima = null, string? EfectoClima = null);

    }
    public class ClimaServicio : IClimaServicio
    {
        private readonly IClimaRepositorio _climaRepositorio;

        public ClimaServicio(IClimaRepositorio climaRepositorio)
        {
            _climaRepositorio = climaRepositorio;
        }
        public async Task<Clima> CreateClima(string TipoClima, string EfectoClima)
        {
            return await _climaRepositorio.CreateClima(TipoClima, EfectoClima);
        }

        public async Task<Clima> DeleteClima(int ClimaId)
        {
            return await _climaRepositorio.DeleteClima(ClimaId);
        }

        public async Task<List<Clima>> GetALL()
        {
            return await _climaRepositorio.GetALL();
        }

        public async Task<Clima> GetClima(int ClimaId)
        {
            return await _climaRepositorio.GetClima(ClimaId);
        }

        public async Task<Clima> UpdateClima(int ClimaId, string? NombreClima = null, string? EfectoClima = null)
        {
            Clima newClima = await _climaRepositorio.GetClima(ClimaId);

            if (newClima != null)
            {
                if (NombreClima != null) { newClima.NombreClima = NombreClima; }
                if (EfectoClima != null) { newClima.EfectoClima=EfectoClima; }
            }
            else { return null; }

            return await _climaRepositorio.UpdateClima(newClima);
        }
    }
}
