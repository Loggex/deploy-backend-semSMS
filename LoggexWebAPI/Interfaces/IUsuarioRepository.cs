using LoggexWebAPI.Domains;
using LoggexWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de usuários
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de Tipos de usuários</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um  usuário a partir de um ID
        /// </summary>
        /// <param name="idUsuario">ID do usuário a ser buscado</param>
        /// <returns>Um Usuario encontrado</returns>
        Usuario BuscarPorID(int idUsuario);
        /// <summary>
        /// Busca um usuário a partir do CPF
        /// </summary>
        /// <param name="cpfBuscado"></param>
        /// <returns>O usuário encontrado</returns>
        Usuario BuscarPorCPF(string cpfBuscado);

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="NovoUsuario">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Usuario NovoUsuario);

        /// <summary>
        /// Atualiza os dados de um usuário
        /// </summary>
        /// <param name="idUsuario">ID do usuário a ser atualizado</param>
        /// <param name="UsuarioU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idUsuario, Usuario UsuarioU);

        /// <summary>
        /// Deleta um  usuário
        /// </summary>
        /// <param name="idUsuario">ID do usuário a ser deletado</param>
        void Deletar(int idUsuario);

    }
}
