using LoggexWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de "Tipos de peças"
    /// </summary>
    interface ITipoPecaRepository
    {
        /// <summary>
        /// Lista todos os Tipos de peças
        /// </summary>
        /// <returns>Uma lista de Tipos de peças</returns>
        List<TiposPeca> Listar();

        /// <summary>
        /// Busca um tipo de peça a partir de um ID
        /// </summary>
        /// <param name="idTiposPeca">ID do tipo de peça a ser buscado</param>
        /// <returns>Um TiposPeca encontrado</returns>
        TiposPeca BuscarPorID(int idTiposPeca);

        /// <summary>
        /// Cadastra um novo tipo de peça
        /// </summary>
        /// <param name="NovoTiposPeca">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(TiposPeca NovoTiposPeca);

        /// <summary>
        /// Atualiza os dados de um tipo de peça
        /// </summary>
        /// <param name="idTiposPeca">ID do tipo de peça a ser atualizado</param>
        /// <param name="TiposPecaU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idTiposPeca, TiposPeca TiposPecaU);

        /// <summary>
        /// Deleta um tipo de peça
        /// </summary>
        /// <param name="idTiposPeca">ID do tipo de peça a ser deletado</param>
        void Deletar(int idTiposPeca);
    }
}
