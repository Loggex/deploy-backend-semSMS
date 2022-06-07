using LoggexWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de rotas
    /// </summary>
    interface IRotaRepository
    {
        /// <summary>
        /// Lista todas as Rotas
        /// </summary>
        /// <returns>Uma lista de Rotas</returns>
        List<Rota> Listar();

        /// <summary>
        /// Busca uma Rota a partir de um ID
        /// </summary>
        /// <param name="idRota">ID da Rota a ser buscada</param>
        /// <returns>Uma Rota encontrada</returns>
        Rota BuscarPorID(int idRota);

        /// <summary>
        /// Cadastra uma nova Rota
        /// </summary>
        /// <param name="NovaRota">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Rota NovaRota);

        /// <summary>
        /// Atualiza os dados de uma Rota
        /// </summary>
        /// <param name="idRota">ID da Rota a ser atualizada</param>
        /// <param name="RotaU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idRota, Rota RotaU);

        /// <summary>
        /// Deleta uma Rota
        /// </summary>
        /// <param name="idRota">ID da Rota a ser deletada</param>
        void Deletar(int idRota);
    }
}
