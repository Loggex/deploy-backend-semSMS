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
using LoggexWebAPI.Repositories;
using LoggexWebAPI.Interfaces;
using LoggexWebAPI.Utils;

namespace LoggexWebAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImgVeiculosController : ControllerBase
    {
        private readonly LoggexContext _context;
        private IImgVeiculoRepository _imgRepository { get; set; }

        public ImgVeiculosController(LoggexContext context)
        {
            _context = context;
            _imgRepository = new ImgVeiculoRepository();


        }

        // GET: api/ImgVeiculos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImgVeiculo>>> GetImgVeiculos()
        {
            return await _context.ImgVeiculos.ToListAsync();
        }

        // GET: api/ImgVeiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImgVeiculo>> GetImgVeiculo(int id)
        {
            var imgVeiculo = await _context.ImgVeiculos.FindAsync(id);

            if (imgVeiculo == null)
            {
                return NotFound();
            }

            return imgVeiculo;
        }

        // PUT: api/ImgVeiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, ImgVeiculo ImgUPDT)
        {
            try
            {
                ImgVeiculo teste = _imgRepository.BuscarPorID(id);
                if (teste != null)
                {
                    _imgRepository.Atualizar(id, ImgUPDT);

                    return StatusCode(204);
                }

                return NotFound("A imagem não foi encontrada :P");
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        // POST: api/ImgVeiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImgVeiculo>> PostImgVeiculo([FromForm] ImgVeiculo imgVeiculo, IFormFile arquivo)
        {
            string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
            string uploadResultado = uploadImg.UploadFile(arquivo, extensoesPermitidas);

            if (uploadResultado == "")
            {
                return BadRequest("Arquivo não encontrado");
            }

            if (uploadResultado == "Extensão não permitida")
            {
                return BadRequest("Extensão de arquivo não permitida");
            }

            imgVeiculo.EnderecoImagem = uploadResultado;

            _context.ImgVeiculos.Add(imgVeiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImgVeiculo", new { id = imgVeiculo.IdImagem }, imgVeiculo);
        }

        // DELETE: api/ImgVeiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImgVeiculo(int id)
        {
            var imgVeiculo = await _context.ImgVeiculos.FindAsync(id);
            if (imgVeiculo == null)
            {
                return NotFound();
            }

            _context.ImgVeiculos.Remove(imgVeiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImgVeiculoExists(int id)
        {
            return _context.ImgVeiculos.Any(e => e.IdImagem == id);
        }
    }
}
