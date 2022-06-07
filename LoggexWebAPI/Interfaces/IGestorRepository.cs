using LoggexWebAPI.Domains;
using LoggexWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Interfaces
{
    interface IGestorRepository
    {
        /// <summary>
        /// Lista todos os Gestores
        /// </summary>
        /// <returns>Uma lista de Tipos de usuários</returns>
        List<Gestor> Listar();

        /// <summary>
        /// Busca um  Gestor a partir de um ID
        /// </summary>
        /// <param name="idUsuario">ID do gestor a ser buscado</param>
        /// <returns>Um Usuario encontrado</returns>
        Gestor BuscarPorID(int idUsuario);

        /// <summary>
        /// Cadastra um novo gestor
        /// </summary>
        /// <param name="NovoUsuario">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Gestor NovoUsuario);

        /// <summary>
        /// Atualiza os dados de um gestor
        /// </summary>
        /// <param name="idUsuario">ID do gestor a ser atualizado</param>
        /// <param name="UsuarioU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idUsuario, Gestor UsuarioU);

        /// <summary>
        /// Deleta um  gestor
        /// </summary>
        /// <param name="idUsuario">ID do gestor a ser deletado</param>
        void Deletar(int idUsuario);

        /// <summary>
        /// Loga o gestor
        /// </summary>
        /// <param name="cred">Credenciais de login</param>
        Gestor login(CredGerenteViewModel cred);
    }
}
