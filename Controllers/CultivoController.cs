using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IRMS.Repositorios;
using IRMS.Servicios;
using IRMS.Model;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CultivoController : ControllerBase
    {
        private readonly ICultivoServicio _cultivoservicio;
        public CultivoController(ICultivoServicio cultivoServicio)
        {
            _cultivoservicio = cultivoServicio;
        }
        [HttpGet]
        public async Task<ActionResult<List<Cultivo>>> GetAllClimas()
        {
            return Ok(await _cultivoservicio.GetAll());
        }

        [HttpGet("{CultivoId}")]
        public async Task<ActionResult<Cultivo>> GetCulivo(int CultivoId)
        {
            var cultivo = _cultivoservicio.GetCultivo(CultivoId);
            if (cultivo == null) { return BadRequest("Cultivo no encontrado");  }

            return Ok(await cultivo);
        }
        [HttpPost]
        public async Task<ActionResult<Cultivo>> CreateCultivo(string CultivoNombre, string Estado, int NivelAgua, int DispositivoId)
        {
            return Ok(await _cultivoservicio.CreateCultivo(CultivoNombre, Estado, NivelAgua, DispositivoId));
        }
        [HttpPut("{CultivoId}")]
        public async Task<ActionResult<Cultivo>> UpdateCultivo(int CultivoId, [FromBody] Cultivo cultivo)
        {
            return Ok(await _cultivoservicio.UpdateCultivo(CultivoId, cultivo.CultivoNombre, cultivo.Estado, cultivo.NivelAgua, cultivo.DispositivoId));
        }
        [HttpDelete("{CultivoId}")]
        public async Task<ActionResult<Cultivo>> DeleteCultivo(int CultivoId)
        {
            return Ok(await _cultivoservicio.DeleteCultivo(CultivoId));
        }
    }
}
