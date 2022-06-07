using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class PecaRepository: IPecaRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idPeca, Peca PecaU)
        {
            Peca pecaBuscada = BuscarPorID(idPeca);

            if(PecaU.IdTipoPeca != null) { pecaBuscada.IdTipoPeca = PecaU.IdTipoPeca; }
            //if(PecaU.IdTipoPecaNavigation != null) { pecaBuscada.IdTipoPecaNavigation = PecaU.IdTipoPecaNavigation; }
            if(PecaU.IdVeiculo != null) { pecaBuscada.IdVeiculo = PecaU.IdVeiculo; }
            //if(PecaU.IdVeiculoNavigation != null) { pecaBuscada.IdVeiculoNavigation = PecaU.IdVeiculoNavigation; }
            if(PecaU.ImgPeca != null) { pecaBuscada.ImgPeca = PecaU.ImgPeca; }
            //if(PecaU.LogAlteracaos != null) { pecaBuscada.LogAlteracaos = PecaU.LogAlteracaos; }
            if(PecaU.Semelhanca != null) { pecaBuscada.Semelhanca = PecaU.Semelhanca; }
            pecaBuscada.EstadoPeca = PecaU.EstadoPeca; 

            ctx.Pecas.Update(pecaBuscada);

            ctx.SaveChanges();
        }

        public Peca BuscarPorID(int idPeca)
        {
            return ctx.Pecas.Include(x => x.IdTipoPecaNavigation).FirstOrDefault(c => c.IdPeca == idPeca);
        }

        public void Cadastrar(Peca NovaPeca)
        {
            ctx.Pecas.Add(NovaPeca);
            ctx.SaveChanges();
        }

        public List<Peca> Checklist(string placa)
        {
            return ctx.Pecas.Include(x => x.IdTipoPecaNavigation).Where(c => c.IdVeiculoNavigation.Placa == placa).ToList();

        }

        public void Deletar(int idPeca)
        {
            Peca pecaBuscada = BuscarPorID(idPeca);

            ctx.Pecas.Remove(pecaBuscada);
            ctx.SaveChanges();
        }

        public List<Peca> Listar()
        {
            return ctx.Pecas.Include(x => x.IdTipoPecaNavigation).ToList();
        }
    }
}
