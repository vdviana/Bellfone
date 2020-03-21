using System;
using System.Collections.Generic;
using Framework.AtendimentoOnline.Model;
using Framework.AtendimentoOnline.DataLayer;

namespace Framework.AtendimentoOnline.BusinessLayer
{
    /// <summary>
    /// Classe para manipulação do assunto
    /// </summary>
    /// <author>vnarcizo</author>
    /// <createdDate>27/02/2009</createdDate>
    public class BLAtendimento
    {

        #region Inserir
        /// <summary>
        /// Insere um novo Atendimento
        /// </summary>
        /// <param name="GUID"></param>
        /// <param name="caminhoArquivo"></param>
        /// <returns>Status da Inserção</returns>
        /// <user>vnarcizo</user>
        public bool Inserir(string GUID, string caminhoArquivo)
        {
            var objDALAtendimento = new DALAtendimento();

            return objDALAtendimento.Inserir(GUID, caminhoArquivo);
        }

        #endregion

        #region Alterar
        /// <summary>
        /// Altera um registro
        /// </summary>
        /// <param name="GUID">Guid do registro</param>
        /// <param name="caminhoArquivo">Caminho do Arquivo</param>
        /// <returns>Status da Alteração</returns>
        /// <user>vnarcizo</user>
        public bool Alterar(string GUID, string caminhoArquivo)
        {
            var objDALAtendimento = new DALAtendimento();

            return objDALAtendimento.Alterar(GUID, caminhoArquivo);
        }

        #endregion

        #region Remover
        /// <summary>
        /// Remove um atendimento
        /// </summary>
        /// <param name="GUID">Guid do atendimento</param>
        /// <param name="caminhoArquivo">Caminho do Arquivo</param>
        /// <returns>Status da Remoção</returns>
        /// <user>vnarcizo</user>
        public bool Remover(string GUID, string caminhoArquivo)
        {
            var objDALAtendimento = new DALAtendimento();

            return objDALAtendimento.Remover(GUID, caminhoArquivo);
        }

        #endregion

        #region Listar
        /// <summary>
        ///  Listar os atendimentos
        /// </summary>
        /// <param name="CaminhoArquivo">Caminho do arquivo</param>
        /// <returns>Lista de atendimentos</returns>
        /// <user>vnarcizo</user>
        public List<ModelAtendimento> Listar(string CaminhoArquivo)
        {
            var objDALAtendimento = new DALAtendimento();

            return objDALAtendimento.Listar(CaminhoArquivo);
        }

        #endregion

        #region Historico de atendimentos
        /// <summary>
        /// Historico de atendimentos
        /// </summary>
        /// <param name="pobjModelAtendimentoHistorico">Filtro para o atendimento</param>
        /// <returns>Lista de atendimentos</returns>
        /// <user>vnarcizo</user>
        public List<ModelAtendimentoHistorico> Historico(ModelAtendimentoHistorico pobjModelAtendimentoHistorico)
        {
            var objDALAtendimento = new DALAtendimento();

            return objDALAtendimento.Historico(pobjModelAtendimentoHistorico);
        }
        #endregion
    }
}
