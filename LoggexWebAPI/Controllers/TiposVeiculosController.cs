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
using LoggexWebAPI.ViewModels;

namespace LoggexWebAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposVeiculosController : ControllerBase
    {
        private readonly LoggexContext _context;
        private ITipoVeiculoRepository _tpvcRepository { get; set; }

        public TiposVeiculosController(LoggexContext context)
        {
            _context = context;
            _tpvcRepository = new TipoVeiculoRepository();

        }

        // GET: api/TiposVeiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposVeiculo>>> GetTiposVeiculos()
        {
            return await _context.TiposVeiculos.ToListAsync();
        }

        // GET: api/TiposVeiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposVeiculo>> GetTiposVeiculo(int id)
        {
            var tiposVeiculo = await _context.TiposVeiculos.FindAsync(id);

            if (tiposVeiculo == null)
            {
                return NotFound();
            }

            return tiposVeiculo;
        }

        // PUT: api/TiposVeiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TiposVeiculo logUPDT)
        {
            try
            {
                TiposVeiculo teste = _tpvcRepository.BuscarPorID(id);
                if (teste != null)
                {
                    _tpvcRepository.Atualizar(id, logUPDT);

                    return StatusCode(204);
                }

                return NotFound("O log não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        // POST: api/TiposVeiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiposVeiculo>> PostTiposVeiculo(TipoVeiculoViewModel tiposVeiculo)
        {
            TiposVeiculo novoTipoVeiculo = new()
            {
                ModeloVeiculo = tiposVeiculo.ModeloVeiculo,
                TipoCarreta = tiposVeiculo.TipoCarreta,
                TipoCarroceria = tiposVeiculo.TipoCarroceria,
                TipoVeiculo = tiposVeiculo.TipoVeiculo,
            };

            _context.TiposVeiculos.Add(novoTipoVeiculo);
            await _context.SaveChangesAsync();

            foreach (var item in tiposVeiculo.Pecas)
            {
                TiposPeca novoTipoPeca = new TiposPeca()
                {
                    NomePeça = item,
                    IdTipoVeiculo = novoTipoVeiculo.IdTipoVeiculo
                };

                _context.TiposPecas.Add(novoTipoPeca);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetTiposVeiculo", new { id = tiposVeiculo.IdTipoVeiculo }, tiposVeiculo);
        }

        // DELETE: api/TiposVeiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposVeiculo(int id)
        {
            var tiposVeiculo = await _context.TiposVeiculos.FindAsync(id);
            if (tiposVeiculo == null)
            {
                return NotFound();
            }

            _context.TiposVeiculos.Remove(tiposVeiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposVeiculoExists(int id)
        {
            return _context.TiposVeiculos.Any(e => e.IdTipoVeiculo == id);
        }
    }
}
