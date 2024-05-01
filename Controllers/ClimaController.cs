using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IRMS.Repositorios;
using IRMS.Servicios;
using IRMS.Model;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimaController : ControllerBase
    {
        private readonly IClimaServicio _climaservicio;
        public ClimaController(IClimaServicio climaServicio)
        {
            _climaservicio = climaServicio;
        }
        [HttpGet]
        public async Task<ActionResult<List<Clima>>> GetAllClimas()
        {
            return Ok(await _climaservicio.GetALL());
        }

        [HttpGet("{ClimaId}")]
        public async Task<ActionResult<Clima>> GetClima(int ClimaId)
        {
            var clima = _climaservicio.GetClima(ClimaId);
            if (clima == null) { return BadRequest("Clima no encontrado"); }

            return Ok(await clima);
        }
        [HttpPost]
        public async Task<ActionResult<Clima>> CreateClima(string NombreClima, string EfectoClima)
        {
            return Ok(await _climaservicio.CreateClima(NombreClima, EfectoClima));
        }
        [HttpPut("{ClimaId}")]
        public async Task<ActionResult<Clima>> UpdateClima(int ClimaId, [FromBody] Clima clima)
        {
            return Ok(await _climaservicio.UpdateClima(ClimaId, clima.NombreClima, clima.EfectoClima));
        }
        [HttpDelete("{ClimaId}")]
        public async Task<ActionResult<Clima>> DeleteClima(int ClimaId)
        {
            return Ok(await _climaservicio.DeleteClima(ClimaId));
        }
    }
}
