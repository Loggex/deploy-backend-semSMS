using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using Microsoft.AspNetCore.Authorization;
using LoggexWebAPI.Interfaces;
using LoggexWebAPI.Repositories;

namespace LoggexWebAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RotasController : ControllerBase
    {
        private readonly LoggexContext _context;
        private IRotaRepository _rotaRepository { get; set; }

        public RotasController(LoggexContext context)
        {
            _context = context;
            _rotaRepository = new RotaRepository();

        }

        // GET: api/Rotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rota>>> GetRotas()
        {
            return _rotaRepository.Listar();
        }

        // GET: api/Rotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rota>> GetRota(int id)
        {
            var rota = _rotaRepository.BuscarPorID(id);

            if (rota == null)
            {
                return NotFound();
            }

            return rota;
        }

        // PUT: api/Rotas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Rota logUPDT)
        {
            try
            {
                Rota teste = _rotaRepository.BuscarPorID(id);
                if (teste != null)
                {
                    _rotaRepository.Atualizar(id, logUPDT);

                    return StatusCode(204);
                }

                return NotFound("O log não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        // POST: api/Rotas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rota>> PostRota(Rota rota)
        {
            _context.Rotas.Add(rota);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRota", new { id = rota.IdRota }, rota);
        }

        // DELETE: api/Rotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRota(int id)
        {
            var rota = await _context.Rotas.FindAsync(id);
            if (rota == null)
            {
                return NotFound();
            }

            _context.Rotas.Remove(rota);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RotaExists(int id)
        {
            return _context.Rotas.Any(e => e.IdRota == id);
        }
    }
}
