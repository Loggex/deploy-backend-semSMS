using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class TipoPecaRepository : ITipoPecaRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idTiposPeca, TiposPeca TiposPecaU)
        {
            TiposPeca tipoPecaBuscada = ctx.TiposPecas.Find(idTiposPeca);

            if (TiposPecaU.IdTipoVeiculo != null) { tipoPecaBuscada.IdTipoVeiculo = TiposPecaU.IdTipoVeiculo; }
            if (TiposPecaU.NomePeça != null) { tipoPecaBuscada.NomePeça = TiposPecaU.NomePeça; }

            ctx.TiposPecas.Update(tipoPecaBuscada);

            ctx.SaveChanges();
        }

        public TiposPeca BuscarPorID(int idTiposPeca)
        {
            return ctx.TiposPecas.FirstOrDefault(c => c.IdTipoVeiculo == idTiposPeca);
        }

        public void Cadastrar(TiposPeca NovoTiposPeca)
        {
            ctx.TiposPecas.Add(NovoTiposPeca);

            ctx.SaveChanges();
        }

        public void Deletar(int idTiposPeca)
        {
            TiposPeca tipoPecaBuscada = BuscarPorID(idTiposPeca);


            ctx.TiposPecas.Remove(tipoPecaBuscada);

            ctx.SaveChanges();
        }

        public List<TiposPeca> Listar()
        {
            return ctx.TiposPecas.ToList();
        }
    }
}
