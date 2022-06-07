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
    public class TiposPecasController : ControllerBase
    {
        private readonly LoggexContext _context;
        private ITipoPecaRepository _tppcRepository { get; set; }

        public TiposPecasController(LoggexContext context)
        {
            _context = context;
            _tppcRepository = new TipoPecaRepository();

        }

        // GET: api/TiposPecas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposPeca>>> GetTiposPecas()
        {
            return await _context.TiposPecas.ToListAsync();
        }

        // GET: api/TiposPecas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposPeca>> GetTiposPeca(int id)
        {
            var tiposPeca = await _context.TiposPecas.FindAsync(id);

            if (tiposPeca == null)
            {
                return NotFound();
            }

            return tiposPeca;
        }

        // PUT: api/TiposPecas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TiposPeca logUPDT)
        {
            try
            {
                TiposPeca teste = _tppcRepository.BuscarPorID(id);
                if (teste != null)
                {
                    _tppcRepository.Atualizar(id, logUPDT);

                    return StatusCode(204);
                }

                return NotFound("O log não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        // POST: api/TiposPecas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiposPeca>> PostTiposPeca(TiposPeca tiposPeca)
        {
            _context.TiposPecas.Add(tiposPeca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposPeca", new { id = tiposPeca.IdTipoPeca }, tiposPeca);
        }

        // DELETE: api/TiposPecas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposPeca(int id)
        {
            var tiposPeca = await _context.TiposPecas.FindAsync(id);
            if (tiposPeca == null)
            {
                return NotFound();
            }

            _context.TiposPecas.Remove(tiposPeca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposPecaExists(int id)
        {
            return _context.TiposPecas.Any(e => e.IdTipoPeca == id);
        }
    }
}
