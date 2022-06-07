using LoggexWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de logs de alteração
    /// </summary>
    interface ILogAlteracaoRepository
    {
        /// <summary>
        /// Lista todos os Logs
        /// </summary>
        /// <returns>Uma lista de Logs</returns>
        List<LogAlteracao> Listar();

        /// <summary>
        /// Busca um Log a partir de um ID
        /// </summary>
        /// <param name="idLog">ID do Log a ser buscado</param>
        /// <returns>Um Log encontrado</returns>
        LogAlteracao BuscarPorID(int idLog);

        /// <summary>
        /// Cadastra um novo Log
        /// </summary>
        /// <param name="NovoLog">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(LogAlteracao NovoLog);

        /// <summary>
        /// Atualiza os dados de um Log
        /// </summary>
        /// <param name="idLog">ID do Log a ser atualizado</param>
        /// <param name="LogU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idLog, LogAlteracao LogU);

        /// <summary>
        /// Deleta um Log
        /// </summary>
        /// <param name="idLog">ID da Log a ser deletado</param>
        void Deletar(int idLog);
    }
}
