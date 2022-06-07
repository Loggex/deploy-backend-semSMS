using LoggexWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de peças
    /// </summary>
    interface IPecaRepository
    {
        /// <summary>
        /// Lista todas as Peça
        /// </summary>
        /// <returns>Uma lista de Peça</returns>
        List<Peca> Listar();

        /// <summary>
        /// Busca uma Peça a partir de um ID
        /// </summary>
        /// <param name="idPeca">ID da Peça a ser buscada</param>
        /// <returns>Uma Peca encontrada</returns>
        Peca BuscarPorID(int idPeca);

        /// <summary>
        /// Cadastra uma nova Peça
        /// </summary>
        /// <param name="NovaPeca">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Peca NovaPeca);

        /// <summary>
        /// Atualiza os dados de uma Peça
        /// </summary>
        /// <param name="idPeca">ID da Peças a ser atualizada</param>
        /// <param name="PecaU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idPeca, Peca PecaU);

        /// <summary>
        /// Deleta uma Peça
        /// </summary>
        /// <param name="idPeca">ID da Peças a ser deletada</param>
        void Deletar(int idPeca);
        /// <summary>
        /// Lista as peças de um determinado veículo
        /// </summary>
        /// <returns></returns>
        List<Peca> Checklist(string placa);

    }
}
