using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IRMS.Repositorios;
using IRMS.Servicios;
using IRMS.Model;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GranjaController : ControllerBase
    {
        private readonly IGranjaServicio _granjaServicio;
        public GranjaController(IGranjaServicio granjaServicio)
        {
            _granjaServicio = granjaServicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Granja>>> GetAllNivel()
        {
            return Ok(await _granjaServicio.GetAll());
        }

        [HttpGet("{GranjaId}")]
        public async Task<ActionResult<Granja>> GetNivel(int GranjaId)
        {
            var granja = _granjaServicio.GetGranja(GranjaId);
            if (granja == null) { return BadRequest("Granja no encontrado"); }

            return Ok(await granja);
        }
        [HttpPost]
        public async Task<ActionResult<Granja>> CreateGrnaja(string NombreGranja, int CultivoId, int ClimaId, string SistemaRiego, string Dificultad)
        {
            return Ok(await _granjaServicio.CreateGranja(NombreGranja, CultivoId, ClimaId, SistemaRiego, Dificultad));
        }
        [HttpPut("{GranjaId}")]
        public async Task<ActionResult<Granja>> UpdateGranja(int GranjaId, [FromBody] Granja granja)
        {
            return Ok(await _granjaServicio.UpdateGranja(GranjaId, granja.NombreGranja, granja.CultivoId, granja.ClimaId, granja.SistemaRiego, granja.Dificultad));
        }
        [HttpDelete("{GranjaId}")]
        public async Task<ActionResult<Granja>> DeleteGranja(int GranjaId)
        {
            return Ok(await _granjaServicio.DeleteGranja(GranjaId));
        }
    }
}
