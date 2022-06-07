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
    public class RotaRepository : IRotaRepository
    {
           
           LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idRota, Rota RotaU)
        {
         
            Rota rotaBuscada = BuscarPorID(idRota);

            if (RotaU.IdSituacao != null) { rotaBuscada.IdSituacao = RotaU.IdSituacao; }
            if (RotaU.IdMotorista != null) { rotaBuscada.IdMotorista = RotaU.IdMotorista; }
            if (RotaU.IdVeiculo != null) { rotaBuscada.IdVeiculo = RotaU.IdVeiculo; }
            if (RotaU.Origem != null) { rotaBuscada.Origem = RotaU.Origem; }
            if (RotaU.Destino != null) { rotaBuscada.Destino = RotaU.Destino; }
            if (RotaU.DataPartida != null) { rotaBuscada.DataPartida = RotaU.DataPartida; }
            if (RotaU.DataChegada != null) { rotaBuscada.DataChegada = RotaU.DataChegada; }
            if (RotaU.Carga != null) { rotaBuscada.Carga = RotaU.Carga; }
            if (RotaU.Descricao != null) { rotaBuscada.Descricao = RotaU.Descricao; }
            if (RotaU.PesoBrutoCarga != null) { rotaBuscada.PesoBrutoCarga = RotaU.PesoBrutoCarga; }
            if (RotaU.VolumeCarga != null) { rotaBuscada.VolumeCarga = RotaU.VolumeCarga; }

            ctx.Rotas.Update(rotaBuscada);

            ctx.SaveChanges();
        }
        

        public Rota BuscarPorID(int idRota)
        {
            return ctx.Rotas.Include(x => x.IdSituacaoNavigation).Include(y => y.IdVeiculoNavigation).ThenInclude(z => z.Pecas).ThenInclude(w => w.IdTipoPecaNavigation).FirstOrDefault(c => c.IdRota == idRota);
        }

        public void Cadastrar(Rota NovaRota)
        {

            ctx.Rotas.Add(NovaRota);
            ctx.SaveChanges();
        }

        public void Deletar(int idRota)
        {
            Rota rotaBuscada = BuscarPorID(idRota);
            ctx.Rotas.Remove(rotaBuscada);
            ctx.SaveChanges();
        }

        public List<Rota> Listar()
        {
            return ctx.Rotas.Include(x => x.IdSituacaoNavigation).Include(y => y.IdVeiculoNavigation).ThenInclude(z => z.Pecas).ThenInclude(w => w.IdTipoPecaNavigation).ToList();
        }
    }
}
