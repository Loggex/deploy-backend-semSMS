using LoggexWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de imagens dos veiculos
    /// </summary>
    interface IImgVeiculoRepository
    {
        /// <summary>
        /// Lista todas as Imagens
        /// </summary>
        /// <returns>Uma lista de Imagens</returns>
        List<ImgVeiculo> Listar();

        /// <summary>
        /// Busca uma Imagem a partir de um ID
        /// </summary>
        /// <param name="idImagem">ID da Imagem a ser buscada</param>
        /// <returns>Uma Imagem encontrada</returns>
        ImgVeiculo BuscarPorID(int idImagem);

        /// <summary>
        /// Cadastra uma nova Imagem
        /// </summary>
        /// <param name="NovaImagem">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(ImgVeiculo NovaImagem);

        /// <summary>
        /// Atualiza os dados de uma Imagem
        /// </summary>
        /// <param name="idImagem">ID da Imagem a ser atualizada</param>
        /// <param name="ImagemU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idImagem, ImgVeiculo ImagemU);

        /// <summary>
        /// Deleta uma Imagem
        /// </summary>
        /// <param name="idImagem">ID da Imagem a ser deletada</param>
        void Deletar(int idImagem);
    }
}
