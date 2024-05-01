using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IRMS.Repositorios;
using IRMS.Servicios;
using IRMS.Model;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccionController : ControllerBase
    {
        private readonly IAccionServicio _accionServicio;
        public AccionController(IAccionServicio accionServicio)
        {
            _accionServicio = accionServicio;
        }
        [HttpGet]
        public async Task<ActionResult<List<Accion>>> GetAllAcciones()
        {
            return Ok(await _accionServicio.GetAll());
        }

        [HttpGet("{AccionId}")]
        public async Task<ActionResult<Accion>> GetAccion(int AccionId)
        {
            var accion = _accionServicio.GetAccion(AccionId);
            if (accion == null) { return BadRequest("Accion no encontrada"); }

            return Ok(await accion);
        }
        [HttpPost]
        public async Task<ActionResult<Accion>> CreateAccion(string NombreAccion, string Descripcion, int DispositivoId)
        {
            return Ok(await _accionServicio.CreateAccion(NombreAccion, Descripcion, DispositivoId));
        }
        [HttpPut("{AccionId}")]
        public async Task<ActionResult<Accion>> UpdateAccion(int AccionId, [FromBody] Accion accion)
        {
            return Ok(await _accionServicio.UpdateAccion(AccionId, accion.NombreAccion, accion.Descripcion, accion.DispositivoId));
        }
        [HttpDelete("{AccionId}")]
        public async Task<ActionResult<Clima>> DeleteAccion(int AccionId)
        {
            return Ok(await _accionServicio.DeleteAccion(AccionId));
        }
    }
}
