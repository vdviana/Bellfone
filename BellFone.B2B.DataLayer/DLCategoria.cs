using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;
using BellFone.B2B.BusinessLayer.Configuration;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para Categoria 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class DLCategoria : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.0]</user> 
        public DLCategoria()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLCategoria">Parametros para filtro</param>
        /// <returns>Lista de Categoria</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLCategoria> Listar(MLCategoria pobjMLCategoria, string strTreinamento, bool bProdutoAtivo, bool? bProdutoVisivel)
        {           

            List<MLCategoria> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLCategoria.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CAT_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@CAT_C_CODIGO"].Value = pobjMLCategoria.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLCategoria.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CAT_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@CAT_C_DESCRICAO"].Value = pobjMLCategoria.Descricao;
            }
            if (pobjMLCategoria.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CAT_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@CAT_B_ATIVO"].Value = pobjMLCategoria.IsAtivo.Value;
            }

            if (!string.IsNullOrEmpty(strTreinamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CMF_C_TREINAMENTO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@CMF_C_TREINAMENTO"].Value = strTreinamento;
            }

            if (bProdutoVisivel != null)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_VISIVEL", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_VISIVEL"].Value = bProdutoVisivel;
            }

            cmdCommand.Parameters.Add(new FWParameter("@PRD_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@PRD_B_STATUS"].Value = bProdutoAtivo;

            IDataReader idrRetorno = null;
            try
            {
                MLCategoria objRetorno = null;
                lstRetorno = new List<MLCategoria>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLCategoria();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (idrRetorno != null && !idrRetorno.IsClosed)
                {
                    idrRetorno.Close();
                }
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Executa a stored procedure para retornar um registro específico
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Categoria</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLCategoria Obter(string pstrCodigo)
        {

            MLCategoria objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@CAT_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@CAT_C_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_CAT_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_CAT_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_CAT_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_CAT_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_CAT_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_CAT_B_ATIVO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_CAT_C_CODIGO") && cmdCommand.Parameters["@OUT_CAT_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLCategoria();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_CAT_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_CAT_C_DESCRICAO") && cmdCommand.Parameters["@OUT_CAT_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_CAT_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_CAT_B_ATIVO") && cmdCommand.Parameters["@OUT_CAT_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_CAT_B_ATIVO"].Value);
                    }

                }
            }
            catch
            {
                throw;
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Executa a Stored Procedure de Exclusão
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registro Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Excluir(string pstrCodigo)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@CAT_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@CAT_C_CODIGO"].Value = pstrCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLCategoria">Categoria para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLCategoria pobjMLCategoria)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLCategoria.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CAT_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@CAT_C_CODIGO"].Value = pobjMLCategoria.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLCategoria.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CAT_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@CAT_C_DESCRICAO"].Value = pobjMLCategoria.Descricao;
            }
            if (pobjMLCategoria.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CAT_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@CAT_B_ATIVO"].Value = pobjMLCategoria.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLCategoria">Categoria para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Inserir(MLCategoria pobjMLCategoria)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLCategoria.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CAT_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@CAT_C_CODIGO"].Value = pobjMLCategoria.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLCategoria.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CAT_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@CAT_C_DESCRICAO"].Value = pobjMLCategoria.Descricao;
            }
            if (pobjMLCategoria.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CAT_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@CAT_B_ATIVO"].Value = pobjMLCategoria.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion
    }
}


