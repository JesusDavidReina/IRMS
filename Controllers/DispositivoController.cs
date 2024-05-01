using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IRMS.Repositorios;
using IRMS.Servicios;
using IRMS.Model;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivoController : ControllerBase
    {
        private readonly IDispositivoServicio _dispositivoServicio;
        public DispositivoController(IDispositivoServicio dispositivoServicio)
        {
            _dispositivoServicio = dispositivoServicio;
        }
        [HttpGet]
        public async Task<ActionResult<List<Dispositivo>>> GetAllDispositivos()
        {
            return Ok(await _dispositivoServicio.GetAll());
        }

        [HttpGet("{DispositivoId}")]
        public async Task<ActionResult<Dispositivo>> GetDispositivo(int DispositivoId)
        {
            var dispositivo = _dispositivoServicio.GetDispositivo(DispositivoId);
            if (dispositivo == null) { return BadRequest("Dispositivo no encontrado"); }

            return Ok(await dispositivo);
        }
        [HttpPost]
        public async Task<ActionResult<Dispositivo>> CreateDispositivo(string NombreDispositivo, string Descripcion, int TipoDispositivoId)
        {
            return Ok(await _dispositivoServicio.CreateDispositivo(NombreDispositivo,Descripcion,TipoDispositivoId));
        }
        [HttpPut("{DispositivoId}")]
        public async Task<ActionResult<Dispositivo>> UpdateDispositivo(int DispositivoId, [FromBody] Dispositivo dispositivo)
        {
            return Ok(await _dispositivoServicio.UpdateDispositivo(DispositivoId, dispositivo.NombreDispositivo, dispositivo.Descripcion, dispositivo.TipoDispositivoId));
        }
        [HttpDelete("{DispositivoId}")]
        public async Task<ActionResult<Dispositivo>> DeleteDispositivo(int DispositivoId)
        {
            return Ok(await _dispositivoServicio.DeleteDispositivo(DispositivoId));
        }
    }
}
