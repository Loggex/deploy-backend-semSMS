using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class TipoVeiculoRepository : ITipoVeiculoRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idTiposVeiculo, TiposVeiculo TiposVeiculoU)
        {
            TiposVeiculo tipoVeiculoBuscada = ctx.TiposVeiculos.Find(idTiposVeiculo);

            if (TiposVeiculoU.TipoCarreta != null) { tipoVeiculoBuscada.TipoCarreta = TiposVeiculoU.TipoCarreta; }
            if (TiposVeiculoU.TipoVeiculo != null) { tipoVeiculoBuscada.TipoVeiculo = TiposVeiculoU.TipoVeiculo; }
            if (TiposVeiculoU.ModeloVeiculo != null) { tipoVeiculoBuscada.ModeloVeiculo = TiposVeiculoU.ModeloVeiculo; }
            if (TiposVeiculoU.TipoCarroceria != null) { tipoVeiculoBuscada.TipoCarroceria = TiposVeiculoU.TipoCarroceria; }

            ctx.TiposVeiculos.Update(tipoVeiculoBuscada);

            ctx.SaveChanges();
        }

        public TiposVeiculo BuscarPorID(int idTiposVeiculo)
        {
            return ctx.TiposVeiculos.FirstOrDefault(c => c.IdTipoVeiculo == idTiposVeiculo);
        }

        public void Cadastrar(TiposVeiculo NovoTiposVeiculo)
        {
            ctx.TiposVeiculos.Add(NovoTiposVeiculo);

            ctx.SaveChanges();
        }

        public void Deletar(int idTiposVeiculo)
        {
            TiposVeiculo tipoPecaBuscada = BuscarPorID(idTiposVeiculo);


            ctx.TiposVeiculos.Remove(tipoPecaBuscada);

            ctx.SaveChanges();
        }

        public List<TiposVeiculo> Listar()
        {
            return ctx.TiposVeiculos.ToList();
        }
    }
}
