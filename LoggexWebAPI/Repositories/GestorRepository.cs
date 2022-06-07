using LoggexWebAPI.Contexts;
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
    public class GestorRepository : IGestorRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idGestor, Gestor gestorU)
        {
            Gestor gestorBuscado = BuscarPorID(idGestor);
            if (gestorU.IdUsuario != null) { gestorBuscado.IdUsuario = gestorU.IdUsuario; }
            if (gestorU.Email != null) { gestorBuscado.Email = gestorU.Email; }
            ctx.Gestors.Update(gestorBuscado);
            ctx.SaveChanges();
        }

        public Gestor BuscarPorID(int idGestor)
        {
            return ctx.Gestors.FirstOrDefault(c => c.IdGestor == idGestor);
        }

        public void Cadastrar(Gestor novoGestor)
        {
            if (novoGestor != null)
            {
                ctx.Gestors.Add(novoGestor);
            }
            ctx.SaveChanges();
        }

        public void Deletar(int idGestor)
        {
            Gestor gestorBuscado = BuscarPorID(idGestor);

            ctx.Gestors.Remove(gestorBuscado);
            ctx.SaveChanges();
        }

        public List<Gestor> Listar()
        {

            return ctx.Gestors
                 .Include(x => x.IdUsuarioNavigation).ToList();
        }

        public Gestor login(CredGerenteViewModel cred)
        {
            var gestor = ctx.Gestors.FirstOrDefault(u => u.Email == cred.Email);

            if (gestor != null)
            {
                if (gestor.Senha == cred.Senha)
                {
                    gestor.Senha = BCrypt.Net.BCrypt.HashPassword(cred.Senha);

                    ctx.Gestors.Update(gestor);
                    ctx.SaveChanges();

                    return gestor;
                }

                // Com o usuário encontrado, temos a hash da senha para poder comparar com a nova entrada pelo input de senha
                var comparado = BCrypt.Net.BCrypt.Verify(cred.Senha, gestor.Senha);
                if (comparado)
                {
                    return gestor;
                }
            }

            return null;
        }   

    }
}
