using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idTiposUsuario, TiposUsuario TiposUsuarioU)
        {
            TiposUsuario tipoPecaBuscada = ctx.TiposUsuarios.Find(idTiposUsuario);

            if (TiposUsuarioU.NomeTipoUsuario != null) { tipoPecaBuscada.NomeTipoUsuario = TiposUsuarioU.NomeTipoUsuario; }

            ctx.TiposUsuarios.Update(tipoPecaBuscada);

            ctx.SaveChanges();
        }

        public TiposUsuario BuscarPorID(int idTiposUsuario)
        {
            return ctx.TiposUsuarios.FirstOrDefault(c => c.IdTipoUsuario == idTiposUsuario);
        }

        public void Cadastrar(TiposUsuario NovoTiposUsuario)
        {
            ctx.TiposUsuarios.Add(NovoTiposUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idTiposUsuario)
        {
            TiposUsuario tipoPecaBuscada = BuscarPorID(idTiposUsuario);


            ctx.TiposUsuarios.Remove(tipoPecaBuscada);

            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}
