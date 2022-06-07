using LoggexWebAPI.Domains;
using LoggexWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de motoristas
    /// </summary>
    interface IMotoristaRepository
    {
        /// <summary>
        /// Lista todos os Motoristas
        /// </summary>
        /// <returns>Uma lista de Motoristas</returns>
        List<Motorista> Listar();

        /// <summary>
        /// Busca um Motorista a partir de um ID
        /// </summary>
        /// <param name="idMotorista">ID do Motorista a ser buscado</param>
        /// <returns>Um Motorista encontrado</returns>
        Motorista BuscarPorID(int idMotorista);


        /// <summary>
        /// Cadastra um novo Motorista
        /// </summary>
        /// <param name="NovoMotorista">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Motorista NovoMotorista);

        /// <summary>
        /// Atualiza os dados de um Motorista
        /// </summary>
        /// <param name="idMotorista">ID do Motorista a ser atualizado</param>
        /// <param name="MotoristaU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idMotorista, Motorista MotoristaU);

        /// <summary>
        /// Deleta um Motorista
        /// </summary>
        /// <param name="idMotorista">ID da Motorista a ser deletado</param>
        void Deletar(int idMotorista);

        /// <summary>
        /// Loga o motorista
        /// </summary>
        /// <param name="cred">Credenciais de login</param>
        Motorista login(CredMotoristaViewModel cred);
    }
}
