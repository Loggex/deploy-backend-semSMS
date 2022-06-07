using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SituacaogexWebAPI.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idSituacao, Situaco SituacaoU)
        {
            Situaco SituacaoBuscada = ctx.Situacoes.Find(idSituacao);

            if (SituacaoU.TituloSituacao != null) { SituacaoBuscada.TituloSituacao = SituacaoU.TituloSituacao; }


            ctx.Situacoes.Update(SituacaoBuscada);

            ctx.SaveChanges();
        }

        public Situaco BuscarPorID(int idSituacao)
        {
            return ctx.Situacoes.FirstOrDefault(c => c.IdSituacao == idSituacao);
        }

        public void Cadastrar(Situaco Novasituacao)
        {
            ctx.Situacoes.Add(Novasituacao);

            ctx.SaveChanges();
        }

        public void Deletar(int idSituacao)
        {
            Situaco SituacaoBuscada = BuscarPorID(idSituacao);


            ctx.Situacoes.Remove(SituacaoBuscada);

            ctx.SaveChanges();
        }

        public List<Situaco> Listar()
        {
            return ctx.Situacoes.ToList();
        }
    }
}
