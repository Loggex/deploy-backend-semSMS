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
using LoggexWebAPI.Utils;

namespace LoggexWebAPI.Controllers
{
 //   [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly LoggexContext _context;
        private UsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController(LoggexContext context)
        {
            _context = context;
            _UsuarioRepository = new UsuarioRepository();

        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string cpf)
        {
            //var usuario = await _context.Usuarios.FindAsync(cpf);

            var usuario = _UsuarioRepository.BuscarPorCPF(cpf);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("id/{id}")]
        public IActionResult Atualizar(int id, Usuario logUPDT)
        {
            try
            {
                Usuario teste = _UsuarioRepository.BuscarPorID(id);
                if (teste != null)
                {
                    _UsuarioRepository.Atualizar(id, logUPDT);

                    return StatusCode(204);
                }

                return NotFound("O log não foi encontrado :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            //string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
            //string uploadResultado = uploadImg.UploadFile(arquivo, extensoesPermitidas);

            //if (uploadResultado == "")
            //{
            //    return BadRequest("Arquivo não encontrado");
            //}

            //if (uploadResultado == "Extensão não permitida")
            //{
            //    return BadRequest("Extensão de arquivo não permitida");
            //}

            //usuario.ImgPerfil = uploadResultado;

            _UsuarioRepository.Cadastrar(usuario);

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
