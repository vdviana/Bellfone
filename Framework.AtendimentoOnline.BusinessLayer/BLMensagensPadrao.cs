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
    public class BLMensagensPadrao
    {
        #region Inserir
        /// <summary>
        /// Insere novo assunto
        /// </summary>
        /// <param name="objModelMensagensPadrao">Model Mensagem Padrao</param>
        /// <returns>Status da inserção</returns>
        /// <user>vnarcizo</user>
        public bool Inserir(ModelMensagensPadrao objModelMensagensPadrao)
        {
            var objDALMensagens = new DALMensagensPadrao();

            return objDALMensagens.Inserir(objModelMensagensPadrao);
        }

        #endregion

        #region Listar
        /// <summary>
        /// Lista das Mensagens Padrões
        /// </summary>
        /// <param name="blnAtivo">Filtrar por status ou não</param>
        /// <returns>Lista Mensagens Padrões</returns>
        /// <user>vnarcizo</user>
        public List<ModelMensagensPadrao> Listar(bool? blnAtivo)
        {
            var objDALMensagens = new DALMensagensPadrao();

            return objDALMensagens.Listar(blnAtivo);
        }

        #endregion

        #region Obter
        /// <summary>
        ///  Obter Mensagem Padrão a Partir de um codigo
        /// </summary>
        /// <param name="CodigoRegistro">Codigo da Mensagem Padrão</param>
        /// <returns>Mensagem Padrão</returns>
        /// <user>vnarcizo</user>
        public ModelMensagensPadrao Obter(decimal? CodigoRegistro)
        {
            var objDALMensagens = new DALMensagensPadrao();

            return objDALMensagens.Obter(CodigoRegistro);
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Altera uma mensagem padrão
        /// </summary>
        /// <param name="objModelMensagensPadrao">Model Mensagem Padrao</param>
        /// <returns>Status da Alteração</returns>
        /// <user>vnarcizo</user>
        public bool Alterar(ModelMensagensPadrao objModelMensagensPadrao)
        {
            var objDALMensagens = new DALMensagensPadrao();

            return objDALMensagens.Alterar(objModelMensagensPadrao); ;
        }
        #endregion
    }
}
