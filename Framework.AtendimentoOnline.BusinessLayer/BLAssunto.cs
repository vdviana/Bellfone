using System.Collections.Generic;
using Framework.AtendimentoOnline.DataLayer;
using Framework.AtendimentoOnline.Model;

namespace Framework.AtendimentoOnline.BusinessLayer
{
    /// <summary>
    /// Classe para manipulação do assunto
    /// </summary>
    /// <author>vnarcizo</author>
    /// <createdDate>27/02/2009</createdDate>
    public class BLAssunto
    {
        #region Listar
        /// <summary>
        ///  Lista os assuntos cadastrados no xml
        /// </summary>
        /// <param name="blnAtivo">Status ou não do Assunto</param>
        /// <param name="blnVenda">Indicador de Assuntos restritos a vendas</param>
        /// <returns>lista de Assuntos</returns>
        /// <user>vnarcizo</user>
        public List<ModelAssunto> Listar(bool? blnAtivo, bool? blnVenda)
        {
            DALAssunto objDALAssunto = new DALAssunto();

            return objDALAssunto.Listar(blnAtivo, blnVenda);
        }

        #endregion

        #region Inserir
        /// <summary>
        /// Insere um novo assunto
        /// </summary>
        /// <param name="objMLAssunto">Model Assunto</param>
        /// <returns>Status da Inserção</returns>
        /// <user>vnarcizo</user>
        public bool Inserir(ModelAssunto objMLAssunto)
        {
            DALAssunto objDALAssunto = new DALAssunto();

            return objDALAssunto.Inserir(objMLAssunto);
        }

        #endregion

        #region Alterar
        /// <summary>
        /// Alterar um determinado assunto
        /// </summary>
        /// <param name="objModelAssunto">Model Assunto</param>
        /// <returns>Status da Alteração</returns>
        public bool Alterar(ModelAssunto objModelAssunto)
        {
            var objDALAssunto = new DALAssunto();

            return objDALAssunto.Alterar(objModelAssunto);
        }
        #endregion

        #region Obter
        /// <summary>
        /// Obter um determinado assunto
        /// </summary>
        /// <param name="CodigoRegistro">Codigo do registro</param>
        /// <returns>Model Assunto</returns>
        public ModelAssunto Obter(decimal? CodigoRegistro)
        {
            var objDALAssunto = new DALAssunto();

            return objDALAssunto.Obter(CodigoRegistro);
        }
        #endregion
    }
}
