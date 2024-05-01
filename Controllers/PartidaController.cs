using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IRMS.Repositorios;
using IRMS.Servicios;
using IRMS.Model;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidaController : ControllerBase
    {
        private readonly IPartidaServicio _partidaServicio;
        public PartidaController(IPartidaServicio partidaServicio)
        {
            _partidaServicio = partidaServicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Partida>>> GetAllPartida()
        {
            return Ok(await _partidaServicio.GetAll());
        }

        [HttpGet("{PartidaId}")]
        public  async Task<ActionResult<Partida>> GetPartida(int PartidaId)
        {
            var partida = _partidaServicio.GetPartida(PartidaId);
            if (partida == null) { return BadRequest("Partida no encontrada"); }

            return Ok(await partida);
        }
        [HttpPost]
        public async Task<ActionResult<Partida>> CreatePartida(int GranjaId, string Puntuacion, DateTime FechaGuardado, DateTime FechaCreacion, string PartidaEstado, int JugadorId)
        {
            return Ok(await _partidaServicio.CreatePartida(GranjaId,  Puntuacion,  FechaGuardado,  FechaCreacion,  PartidaEstado,  JugadorId));
        }
        [HttpPut("{PartidaId}")]
        public async Task<ActionResult<Cultivo>> UpdateCultivo(int PartidaId, [FromBody] Partida partida)
        {
            return Ok(await _partidaServicio.UpdatePartida(PartidaId,partida.GranjaId, partida.Puntuacion, partida.FechaGuardado,partida.FechaCreacion, partida.PartidaEstado, partida.JugadorId));
        }
        [HttpDelete("{PartidaId}")]
        public async Task<ActionResult<Partida>> DeletePartida(int PartidaId)
        {
            return Ok(await _partidaServicio.DeletePartida(PartidaId));
        }
    }
}
