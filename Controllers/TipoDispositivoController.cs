using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IRMS.Repositorios;
using IRMS.Servicios;
using IRMS.Model;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDispositivoController : ControllerBase
    {
        private readonly ITipoDispositivoServicio _tipoDispositivoServicio;
        public TipoDispositivoController(ITipoDispositivoServicio tipoDispositivoServicio)
        {
            _tipoDispositivoServicio = tipoDispositivoServicio;
        }
        [HttpGet]
        public async Task<ActionResult<List<TipoDispositivo>>> GetAllTipoDispos()
        {
            return Ok(await _tipoDispositivoServicio.GetAll());
        }

        [HttpGet("{TipoDispositivoId}")]
        public async Task<ActionResult<TipoDispositivo>> GetTipoDispositivo(int TipoDispositivoId)
        {
            var tipodispositivo = _tipoDispositivoServicio.GetTipoDispositivo(TipoDispositivoId);
            if (tipodispositivo == null) { return BadRequest("Dispositivo no encontrado"); }

            return Ok(await tipodispositivo);
        }
        [HttpPost]
        public async Task<ActionResult<TipoDispositivo>> CreateTipoDispositivo(string NombreTipoDispositivo)
        {
            return Ok(await _tipoDispositivoServicio.CreateTipoDispositivo(NombreTipoDispositivo));
        }
        [HttpPut("{TipoDispositivoId}")]
        public async Task<ActionResult<TipoDispositivo>> UpdateTipoDispositivo(int TipoDispositivoId, [FromBody] TipoDispositivo tipoDispositivo)
        {
            return Ok(await _tipoDispositivoServicio.UpdateTipoDispositivo(TipoDispositivoId, tipoDispositivo.NombreTipoDispositivo));
        }
        [HttpDelete("{TipoDispositivoId}")]
        public async Task<ActionResult<TipoDispositivo>> DeleteTipoDispositivo(int TipoDispositivoId)
        {
            return Ok(await _tipoDispositivoServicio.DeleteTipoDispositivo(TipoDispositivoId));
        }
    }
}
