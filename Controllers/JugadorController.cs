﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IRMS.Repositorios;
using IRMS.Servicios;
using IRMS.Model;

namespace IRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {
        private readonly IJugadorServicio _jugadorServicio;
        public JugadorController(IJugadorServicio jugadorServicio)
        {
            _jugadorServicio = jugadorServicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Jugador>>> GetAllJugador()
        {
            return Ok(await _jugadorServicio.GetJugadorList());
        }

        [HttpGet("{NombreUsuario}/{password}")]
        public async Task<ActionResult<Jugador>> GetJugador(string NombreUsuario, string password)
        {
            var jugador = _jugadorServicio.GetJugador(NombreUsuario, password);
            if (jugador == null) { return BadRequest("Jugador no encontrado"); }

            return Ok(await jugador);
        }
        [HttpGet("{JugadorId}")]
        public async Task<ActionResult<Jugador>> GetJugadorById(int JugadorId)
        {
            var jugador = _jugadorServicio.GetJugadorById(JugadorId);
            if (jugador == null) { return BadRequest("Jugador no encontrado"); }

            return Ok(await jugador);
        }
        [HttpPost]
        public async Task<ActionResult<Jugador>> CreateJugado(string Nombres, string Apellidos, string NombreUsuario, string password, string photo, string Email)
        {
            return Ok(await _jugadorServicio.CreateJugador(Nombres, Apellidos, NombreUsuario, password, photo, Email));
        }
        [HttpPut("{jugardorID}")]
        public async Task<ActionResult<Jugador>> UpdateJugador(int jugardorID, [FromBody] Jugador jugador)
        {
            return Ok(await _jugadorServicio.UpdateJugador(jugardorID, jugador.Nombres, jugador.Apellidos, jugador.NombreUsuario, jugador.password, jugador.photo, jugador.Email));
        }
        [HttpDelete("{JugadorId}")]
        public async Task<ActionResult<Jugador>> DeleteJugador(int JugadorId)
        {
            return Ok(await _jugadorServicio.DeleteJugador(JugadorId));
        }
    }
}
