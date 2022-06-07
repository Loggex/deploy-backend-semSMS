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
    public class VeiculoRepository : IVeiculoRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idVeiculo, Veiculo VeiculoU)
        {
            Veiculo VeiculoBuscado = BuscarPorID(idVeiculo);

            //if (VeiculoU.IdTipoVeiculo != null) { VeiculoBuscado.IdTipoVeiculo = VeiculoU.IdTipoVeiculo; }
            if (VeiculoU.Placa != null) { VeiculoBuscado.Placa = VeiculoU.Placa; }
            if (VeiculoU.AnoFabricacao != null) { VeiculoBuscado.AnoFabricacao = VeiculoU.AnoFabricacao; }
            if (VeiculoU.Seguro != null) { VeiculoBuscado.Seguro = VeiculoU.Seguro; }
            if (VeiculoU.Cor != null) { VeiculoBuscado.Cor = VeiculoU.Cor; }
            if (VeiculoU.Descricao != null) { VeiculoBuscado.Descricao = VeiculoU.Descricao; }
            if (VeiculoU.Chassi != null) { VeiculoBuscado.Chassi = VeiculoU.Chassi; }
            if (VeiculoU.EstadoVeiculo != null) { VeiculoBuscado.EstadoVeiculo = VeiculoU.EstadoVeiculo; }
            if (VeiculoU.Quilometragem != null) { VeiculoBuscado.Quilometragem = VeiculoU.Quilometragem; }

            ctx.Veiculos.Update(VeiculoBuscado);

            ctx.SaveChanges();
        }

        public Veiculo BuscarPelaPlaca(string placa)
        {
            return ctx.Veiculos.Include(x => x.IdTipoVeiculoNavigation).FirstOrDefault(c => c.Placa == placa);
        }

        public Veiculo BuscarPorID(int idVeiculo)
        {
            return ctx.Veiculos.Include(x => x.Pecas).ThenInclude(y => y.IdTipoPecaNavigation).FirstOrDefault(c => c.IdVeiculo == idVeiculo);
        }

        public void Cadastrar(Veiculo NovoVeiculo)
        {
            ctx.Veiculos.Add(NovoVeiculo);
            ctx.SaveChanges();
        }

        public void Deletar(int idVeiculo)
        {
            Veiculo VeiculoBuscado = BuscarPorID(idVeiculo);
            ctx.Veiculos.Remove(VeiculoBuscado);
            ctx.SaveChanges();
        }

        public List<Veiculo> Listar()
        {   
            return ctx.Veiculos
                .Include(x => x.Pecas).ThenInclude(y => y.IdTipoPecaNavigation)
                .Include(x => x.Pecas).ThenInclude(y => y.LogAlteracaos).ToList();
        }
    }
}
