using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace LoggexWebAPI.Repositories
{
    public class ImgVeiculoRepository : IImgVeiculoRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idImagem, ImgVeiculo ImagemU)
        {
            ImgVeiculo imagemBuscada = ctx.ImgVeiculos.Find(idImagem);

            if (ImagemU.IdVeiculo != null) { imagemBuscada.IdVeiculo = ImagemU.IdVeiculo; }
            if (ImagemU.EnderecoImagem != null) { imagemBuscada.EnderecoImagem = ImagemU.EnderecoImagem; }


            ctx.ImgVeiculos.Update(imagemBuscada);

            ctx.SaveChanges();
        }

        public ImgVeiculo BuscarPorID(int idImagem)
        {
            return ctx.ImgVeiculos.FirstOrDefault(c => c.IdImagem == idImagem);
        }

        public void Cadastrar(ImgVeiculo NovaImagem)
        {
            ctx.ImgVeiculos.Add(NovaImagem);

            ctx.SaveChanges();
        }

        public void Deletar(int idImagem)
        {
            ImgVeiculo imagemBuscada = BuscarPorID(idImagem);


            ctx.ImgVeiculos.Remove(imagemBuscada);

            ctx.SaveChanges();
        }

        public List<ImgVeiculo> Listar()
        {
            return ctx.ImgVeiculos.ToList();
        }
    }
}
