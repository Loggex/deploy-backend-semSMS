using LoggexWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de "Tipos de veículos"
    /// </summary>
    interface ITipoVeiculoRepository
    {
        /// <summary>
        /// Lista todos os Tipos de veículos
        /// </summary>
        /// <returns>Uma lista de Tipos de veículos</returns>
        List<TiposVeiculo> Listar();

        /// <summary>
        /// Busca um tipo de veículo a partir de um ID
        /// </summary>
        /// <param name="idTiposVeiculo">ID do tipo de veículo a ser buscado</param>
        /// <returns>Um TiposVeiculo encontrado</returns>
        TiposVeiculo BuscarPorID(int idTiposVeiculo);

        /// <summary>
        /// Cadastra um novo tipo de veículo
        /// </summary>
        /// <param name="NovoTiposVeiculo">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(TiposVeiculo NovoTiposVeiculo);

        /// <summary>
        /// Atualiza os dados de um tipo de veículo
        /// </summary>
        /// <param name="idTiposVeiculo">ID do tipo de veículo a ser atualizado</param>
        /// <param name="TiposVeiculoU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idTiposVeiculo, TiposVeiculo TiposVeiculoU);

        /// <summary>
        /// Deleta um tipo de veículo
        /// </summary>
        /// <param name="idTiposVeiculo">ID do tipo de veículo a ser deletado</param>
        void Deletar(int idTiposVeiculo);
    }
}
