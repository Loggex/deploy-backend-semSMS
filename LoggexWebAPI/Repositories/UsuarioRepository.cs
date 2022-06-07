using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using LoggexWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        LoggexContext ctx = new LoggexContext();
        public int? ultimoID { get; set; }


        public void Atualizar(int idUsuario, Usuario UsuarioU)
        {
            Usuario UsuarioBuscado = BuscarPorID(idUsuario);
            
            if (UsuarioU.IdTipoUsuario != null) { UsuarioBuscado.IdTipoUsuario = UsuarioU.IdTipoUsuario; }
            if (UsuarioU.Nome != null) { UsuarioBuscado.Nome = UsuarioU.Nome; }
            if (UsuarioU.Sexo != null) { UsuarioBuscado.Sexo = UsuarioU.Sexo; }
            if (UsuarioU.ImgPerfil != null) { UsuarioBuscado.ImgPerfil = UsuarioU.ImgPerfil; }
            if (UsuarioU.Cpf != null) { UsuarioBuscado.Cpf = UsuarioU.Cpf; }

            ctx.Usuarios.Update(UsuarioBuscado);
            
            ctx.SaveChanges();
        }

        public Usuario BuscarPorCPF(string cpfBuscado)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.Cpf == cpfBuscado);
        }

        public Usuario BuscarPorID(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == idUsuario);
        }
        public void Cadastrar(Usuario NovoUsuario)
        {
            ctx.Usuarios.Add(NovoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            Usuario UsuarioBuscado = BuscarPorID(idUsuario);
            ctx.Usuarios.Remove(UsuarioBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

    }
}
