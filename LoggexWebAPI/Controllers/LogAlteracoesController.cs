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
    public class LogAlteracoesController : ControllerBase
    {
        private readonly LoggexContext _context;
        private ILogAlteracaoRepository _logRepository { get; set; }


        public LogAlteracoesController(LoggexContext context)
        {
            _context = context;
            _logRepository = new LogAlteracaoRepository();
        }


        // GET: api/LogAlteracoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogAlteracao>>> GetLogAlteracaos()
        {
            return await _context.LogAlteracaos.ToListAsync();
        }

        // GET: api/LogAlteracoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogAlteracao>> GetLogAlteracao(int id)
        {
            var logAlteracao = await _context.LogAlteracaos.FindAsync(id);

            if (logAlteracao == null)
            {
                return NotFound();
            }

            return logAlteracao;
        }

        // PUT: api/LogAlteracoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, LogAlteracao logUPDT)
        {
            try
            {
                LogAlteracao teste = _logRepository.BuscarPorID(id);
                if (teste != null)
                {
                    _logRepository.Atualizar(id, logUPDT);

                    return StatusCode(204);
                }

                return NotFound("O log não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        // POST: api/LogAlteracoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogAlteracao>> PostLogAlteracao(LogAlteracao logAlteracao)
        {
            _context.LogAlteracaos.Add(logAlteracao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogAlteracao", new { id = logAlteracao.IdLog }, logAlteracao);
        }

        // DELETE: api/LogAlteracoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogAlteracao(int id)
        {
            var logAlteracao = await _context.LogAlteracaos.FindAsync(id);
            if (logAlteracao == null)
            {
                return NotFound();
            }

            _context.LogAlteracaos.Remove(logAlteracao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogAlteracaoExists(int id)
        {
            return _context.LogAlteracaos.Any(e => e.IdLog == id);
        }
    }
}
