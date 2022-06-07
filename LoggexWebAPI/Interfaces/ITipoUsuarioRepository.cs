using LoggexWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de "Tipos de usuários"
    /// </summary>
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Tipos de usuários
        /// </summary>
        /// <returns>Uma lista de Tipos de usuários</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Busca um tipo de usuário a partir de um ID
        /// </summary>
        /// <param name="idTiposUsuario">ID do tipo de usuário a ser buscado</param>
        /// <returns>Um TiposUsuario encontrado</returns>
        TiposUsuario BuscarPorID(int idTiposUsuario);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="NovoTiposUsuario">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(TiposUsuario NovoTiposUsuario);

        /// <summary>
        /// Atualiza os dados de um tipo de usuário
        /// </summary>
        /// <param name="idTiposUsuario">ID do tipo de usuário a ser atualizado</param>
        /// <param name="TiposUsuarioU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idTiposUsuario, TiposUsuario TiposUsuarioU);

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="idTiposUsuario">ID do tipo de usuário a ser deletado</param>
        void Deletar(int idTiposUsuario);
    }
}
