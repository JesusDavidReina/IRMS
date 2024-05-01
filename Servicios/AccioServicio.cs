using IRMS.Model;
using IRMS.Repositorios;

namespace IRMS.Servicios
{
    public interface IAccionServicio
    {
        Task<List<Accion>> GetAll();
        Task<Accion> GetAccion(int AccionId);
        Task<Accion> CreateAccion(string NombreAccion, string Descipcion, int DispositivoId);
        Task<Accion> UpdateAccion(int AccionId, string? NombreAccion = null, string? Descipcion = null, int? DispositivoId = null);
        Task<Accion> DeleteAccion(int AccionId);

    }
    public class AccioServicio : IAccionServicio
    {
        private readonly IAccionRepositorio _accionRepositorio;
        public AccioServicio(IAccionRepositorio accionRepositorio)
        {
            _accionRepositorio = accionRepositorio;
        }
        public async Task<Accion> CreateAccion(string NombreAccion, string Descipcion, int DispositivoId)
        {
            return await _accionRepositorio.CreateAccion(NombreAccion, Descipcion, DispositivoId);
        }

        public async Task<Accion> DeleteAccion(int AccionId)
        {
            return await _accionRepositorio.DeleteAccion(AccionId);
        }

        public async Task<Accion> GetAccion(int AccionId)
        {
            return await _accionRepositorio.GetAccion(AccionId);
        }

        public async Task<List<Accion>> GetAll()
        {
            return await _accionRepositorio.GetAll();
        }

        public async Task<Accion> UpdateAccion(int AccionId, string? NombreAccion = null, string? Descipcion = null, int? DispositivoId = null)
        {
            Accion updateAccion = await _accionRepositorio.GetAccion(AccionId);
            if (updateAccion != null)
            {
                if (NombreAccion != null) { updateAccion.NombreAccion = NombreAccion; }
                if (Descipcion != null) { updateAccion.Descripcion = Descipcion; }
                if (DispositivoId != null) { updateAccion.DispositivoId = (int)DispositivoId; }
            }
            else { return null; }

            return await _accionRepositorio.UpdateAccion(updateAccion);
        }
    }
}
