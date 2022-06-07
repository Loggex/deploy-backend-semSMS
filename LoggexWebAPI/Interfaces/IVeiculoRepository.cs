using LoggexWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de veículos
    /// </summary>
    interface IVeiculoRepository
    {
        /// <summary>
        /// Lista todos os veículos
        /// </summary>
        /// <returns>Uma lista de Tipos de veículos</returns>
        List<Veiculo> Listar();

        /// <summary>
        /// Busca um  veículo a partir de um ID
        /// </summary>
        /// <param name="idVeiculo">ID do veículo a ser buscado</param>
        /// <returns>Um Veiculo encontrado</returns>
        Veiculo BuscarPorID(int idVeiculo);

        /// <summary>
        /// Busca um veículo através da placa
        /// </summary>
        /// <param name="placa">Placa do veículo a ser buscado</param>
        /// <returns>Um veículo encontrado</returns>
        Veiculo BuscarPelaPlaca(string placa);

        /// <summary>
        /// Cadastra um novo veículo
        /// </summary>
        /// <param name="NovoVeiculo">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Veiculo NovoVeiculo);

        /// <summary>
        /// Atualiza os dados de um veículo
        /// </summary>
        /// <param name="idVeiculo">ID do veículo a ser atualizado</param>
        /// <param name="VeiculoU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idVeiculo, Veiculo VeiculoU);

        /// <summary>
        /// Deleta um  veículo
        /// </summary>
        /// <param name="idVeiculo">ID do veículo a ser deletado</param>
        void Deletar(int idVeiculo);
    }
}
