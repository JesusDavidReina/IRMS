using IRMS.Model;
using IRMS.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace IRMS.Servicios
{
    public interface ITipoDispositivoServicio
    {
        Task<List<TipoDispositivo>> GetAll();
        Task<TipoDispositivo> GetTipoDispositivo(int TipoDispositoId);
        Task<TipoDispositivo> CreateTipoDispositivo(string NombreDispositivo);
        Task<TipoDispositivo> UpdateTipoDispositivo(int TipoDispositivoId, string? NombreDispositivo = null);
        Task<TipoDispositivo> DeleteTipoDispositivo(int TipoDispositivoId);
    }
    public class TipoDispositivoServicio : ITipoDispositivoServicio
    {
        private readonly ITipoDispositivoRepositorio _tipoDispositivoRepositorio;
        public TipoDispositivoServicio(ITipoDispositivoRepositorio tipoDispositivoRepositorio)
        {
            _tipoDispositivoRepositorio = tipoDispositivoRepositorio;
        }
        public async Task<TipoDispositivo> CreateTipoDispositivo(string NombreDispositivo)
        {
            return await _tipoDispositivoRepositorio.CreateTipoDispositivo(NombreDispositivo);
        }

        public async Task<TipoDispositivo> DeleteTipoDispositivo(int TipoDispositivoId)
        {
            return await _tipoDispositivoRepositorio.DeleteTipoDispositivo(TipoDispositivoId);
        }

        public async Task<List<TipoDispositivo>> GetAll()
        {
            return await _tipoDispositivoRepositorio.GetAll();
        }

        public async Task<TipoDispositivo> GetTipoDispositivo(int TipoDispositoId)
        {
            return await _tipoDispositivoRepositorio.GetTipoDispositivo(TipoDispositoId);
        }

        public async Task<TipoDispositivo> UpdateTipoDispositivo(int TipoDispositivoId, string? NombreDispositivo = null)
        {
            TipoDispositivo updateTipo = await _tipoDispositivoRepositorio.GetTipoDispositivo(TipoDispositivoId);
            if (updateTipo != null) 
            {
                if (NombreDispositivo != null) { updateTipo.NombreTipoDispositivo =  NombreDispositivo; }
            }
            else { return null; }

            return await _tipoDispositivoRepositorio.UpdateTipoDispositivo(updateTipo);
        }
    }
}
