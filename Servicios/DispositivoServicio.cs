using IRMS.Model;
using IRMS.Repositorios;

namespace IRMS.Servicios
{
    public interface IDispositivoServicio
    {
        Task<List<Dispositivo>> GetAll();
        Task<Dispositivo> GetDispositivo(int DispositivoId);
        Task<Dispositivo> CreateDispositivo(string NombreDispositivo, string Descripcion, int TipoDispositivoId);
        Task<Dispositivo> UpdateDispositivo(int DispositivoId, string? NombreDispositivo = null, string? Descripcion = null, int? TipoDispositivoId = null);
        Task<Dispositivo> DeleteDispositivo(int DispositivoId);
    }
    public class DispositivoServicio : IDispositivoServicio
    {
        private readonly IDispositivoRepositorio _dispositivoRepositorio;

        public DispositivoServicio(IDispositivoRepositorio dispositivoRepositorio)
        {
            _dispositivoRepositorio = dispositivoRepositorio;
        }
        public async Task<Dispositivo> CreateDispositivo(string NombreDispositivo, string Descripcion, int TipoDispositivoId)
        {
            return await _dispositivoRepositorio.CreateDispositivo(NombreDispositivo, Descripcion, TipoDispositivoId);
        }

        public async Task<Dispositivo> DeleteDispositivo(int DispositivoId)
        {
            return await _dispositivoRepositorio.DeleteDispositivo(DispositivoId);
        }

        public async Task<List<Dispositivo>> GetAll()
        {
            return await _dispositivoRepositorio.GetAll();
        }

        public async Task<Dispositivo> GetDispositivo(int DispositivoId)
        {
            return await _dispositivoRepositorio.GetDispositivo(DispositivoId);
        }

        public async Task<Dispositivo> UpdateDispositivo(int DispositivoId, string? NombreDispositivo = null, string? Descripcion = null, int? TipoDispositivoId = null)
        {
            Dispositivo updateDispositivo = await _dispositivoRepositorio.GetDispositivo(DispositivoId);
            if (updateDispositivo != null) 
            {
                if (NombreDispositivo != null) { updateDispositivo.NombreDispositivo =  NombreDispositivo; }
                if (Descripcion != null) { updateDispositivo.Descripcion = Descripcion; }
                if (TipoDispositivoId != null) { updateDispositivo.TipoDispositivoId = (int) TipoDispositivoId; }
            }
            else { return null; }

            return await _dispositivoRepositorio.UpdateDispositivo(updateDispositivo);
        }
    }
}
