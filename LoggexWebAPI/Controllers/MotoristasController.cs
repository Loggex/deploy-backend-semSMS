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
    public class MotoristasController : ControllerBase
    {
        private readonly LoggexContext _context;
        private IMotoristaRepository _motoRepository { get; set; }

        public MotoristasController(LoggexContext context)
        {
            _context = context;
            _motoRepository = new MotoristaRepository();

        }

        // GET: api/Motoristas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motorista>>> GetMotoristas()
        {
            return _motoRepository.Listar();
        }

        // GET: api/Motoristas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Motorista>> GetMotorista(int id)
        {
            var motorista = await _context.Motoristas.FindAsync(id);

            if (motorista == null)
            {
                return NotFound();
            }

            return _motoRepository.BuscarPorID(id);
        }

        // PUT: api/Motoristas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Motorista logUPDT)
        {
            try
            {
                Motorista teste = _motoRepository.BuscarPorID(id);
                if (teste != null)
                {
                    _motoRepository.Atualizar(id, logUPDT);

                    return StatusCode(204);
                }

                return NotFound("O motorista não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        // POST: api/Motoristas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostMotorista(Motorista motorista)
        {

            //_context.Motoristas.Add(motorista);
            //_context.Usuarios.Add(usuario);
            //motorista.IdUsuario = usuario.IdUsuario;
            _motoRepository.Cadastrar(motorista);
            _context.SaveChanges();

            return CreatedAtAction("GetMotorista", new { id = motorista.IdMotorista }, motorista);
        }

        // DELETE: api/Motoristas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotorista(int id)
        {
            var motorista = await _context.Motoristas.FindAsync(id);
            if (motorista == null)
            {
                return NotFound();
            }

            _context.Motoristas.Remove(motorista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotoristaExists(int id)
        {
            return _context.Motoristas.Any(e => e.IdMotorista == id);
        }
    }
}
