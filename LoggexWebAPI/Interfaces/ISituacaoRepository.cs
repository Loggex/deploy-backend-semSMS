using LoggexWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de situações
    /// </summary>
    interface ISituacaoRepository
    {
        /// <summary> 
        /// Lista todas as Situações
        /// </summary>
        /// <returns>Uma lista de Situações</returns>
        List<Situaco> Listar();

        /// <summary>
        /// Busca uma Situação a partir de um ID
        /// </summary>
        /// <param name="idSituacao">ID da Situação a ser buscada</param>
        /// <returns>Uma Situaco encontrada</returns>
        Situaco BuscarPorID(int idSituacao);

        /// <summary>
        /// Cadastra uma nova Situação
        /// </summary>
        /// <param name="Novasituacao">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Situaco Novasituacao);

        /// <summary>
        /// Atualiza os dados de uma Situação
        /// </summary>
        /// <param name="idSituacao">ID da Situação a ser atualizada</param>
        /// <param name="SituacoU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idSituacao, Situaco SituacoU);

        /// <summary>
        /// Deleta uma Situação
        /// </summary>
        /// <param name="idSituacao">ID da Situação a ser deletada</param>
        void Deletar(int idSituacao);
    }
}
