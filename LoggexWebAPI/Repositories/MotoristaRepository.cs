using LoggexWebAPI.Contexts;
using LoggexWebAPI.Controllers;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using LoggexWebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class MotoristaRepository : IMotoristaRepository
    {
        LoggexContext ctx = new LoggexContext();
        //UsuariosController _usuarioController = new UsuariosController();
        UsuarioRepository usuarioRepository = new UsuarioRepository();

        public void Atualizar(int idMotorista, Motorista motoristaU)
        {
            Motorista motoristaBuscado = BuscarPorID(idMotorista);
            if (motoristaU.Cnh != null) { motoristaBuscado.Cnh = motoristaU.Cnh; }
            if (motoristaU.IdMotorista != null) { motoristaBuscado.IdMotorista = motoristaU.IdMotorista; }
            if (motoristaU.IdUsuario != null) { motoristaBuscado.IdUsuario = motoristaU.IdUsuario; }
            if (motoristaU.NumCelular != null) { motoristaBuscado.NumCelular = motoristaU.NumCelular; }
            if (motoristaU.IdUsuarioNavigation != null) { motoristaBuscado.IdUsuarioNavigation = motoristaU.IdUsuarioNavigation; }
            if (motoristaU.Rota != null) { motoristaBuscado.Rota = motoristaU.Rota; }

            ctx.Motoristas.Update(motoristaBuscado);
            ctx.SaveChanges();
        }

        public Motorista BuscarPorID(int idMotorista)
        {
            return ctx.Motoristas.FirstOrDefault(c => c.IdMotorista == idMotorista);
        }

        public void Cadastrar(Motorista NovoMotorista)
        {
            NovoMotorista.IdUsuario = usuarioRepository.ultimoID;
            if (NovoMotorista != null)
            {
                ctx.Motoristas.Add(NovoMotorista);
            }
            ctx.SaveChanges();
        }

        public void Deletar(int idMotorista)
        {
            Motorista motoristaBuscado = BuscarPorID(idMotorista);

            ctx.Motoristas.Remove(motoristaBuscado);
            ctx.SaveChanges();
        }

        public List<Motorista> Listar()
        {
            return ctx.Motoristas
                 .Include(x => x.IdUsuarioNavigation).ToList();

        }

        public Motorista login(CredMotoristaViewModel cred)
        {
                return ctx.Motoristas.FirstOrDefault(u => u.NumCelular == cred.Telefone);
           
        }
    }
}
