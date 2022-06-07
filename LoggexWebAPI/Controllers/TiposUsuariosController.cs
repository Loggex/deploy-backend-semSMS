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
    public class TiposUsuariosController : ControllerBase
    {
        private readonly LoggexContext _context;
        private ITipoUsuarioRepository _tpusRepository { get; set; }


        public TiposUsuariosController(LoggexContext context)
        {
            _context = context;
            _tpusRepository = new TipoUsuarioRepository();

        }

        // GET: api/TiposUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposUsuario>>> GetTiposUsuarios()
        {
            return await _context.TiposUsuarios.ToListAsync();
        }

        // GET: api/TiposUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposUsuario>> GetTiposUsuario(int id)
        {
            var tiposUsuario = await _context.TiposUsuarios.FindAsync(id);

            if (tiposUsuario == null)
            {
                return NotFound();
            }

            return tiposUsuario;
        }

        // PUT: api/TiposUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TiposUsuario logUPDT)
        {
            try
            {
                TiposUsuario teste = _tpusRepository.BuscarPorID(id);
                if (teste != null)
                {
                    _tpusRepository.Atualizar(id, logUPDT);

                    return StatusCode(204);
                }

                return NotFound("O log não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        // POST: api/TiposUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiposUsuario>> PostTiposUsuario(TiposUsuario tiposUsuario)
        {
            _context.TiposUsuarios.Add(tiposUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposUsuario", new { id = tiposUsuario.IdTipoUsuario }, tiposUsuario);
        }

        // DELETE: api/TiposUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposUsuario(int id)
        {
            var tiposUsuario = await _context.TiposUsuarios.FindAsync(id);
            if (tiposUsuario == null)
            {
                return NotFound();
            }

            _context.TiposUsuarios.Remove(tiposUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposUsuarioExists(int id)
        {
            return _context.TiposUsuarios.Any(e => e.IdTipoUsuario == id);
        }
    }
}
