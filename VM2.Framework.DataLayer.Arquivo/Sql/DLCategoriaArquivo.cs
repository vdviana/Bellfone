using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.Model.Arquivo;

using VM2.Framework.DataLayer.Arquivo;

namespace VM2.Framework.DataLayer.Arquivo.Sql
{
    /// <summary> 
    /// Classe de conexão de dados para ArquivoCategoria 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLCategoriaArquivo: DLFWBase,IDLCategoriaArquivo 
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2</user> 
        public DLCategoriaArquivo()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLCategoriaArquivo">Parametros para filtro</param>
        /// <returns>Lista de CategoriaArquivo</returns> 
        /// <user>GeradorVm2</user>
        public List<MLCategoriaArquivo> Listar(MLCategoriaArquivo pobjMLCategoriaArquivo)
        {

            List<MLCategoriaArquivo> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWC_L_ARQUIVO_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLCategoriaArquivo.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@AQC_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@AQC_N_CODIGO"].Value = pobjMLCategoriaArquivo.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLCategoriaArquivo.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@AQC_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@AQC_C_DESCRICAO"].Value = pobjMLCategoriaArquivo.Descricao;
            }

            if (pobjMLCategoriaArquivo.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@AQC_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@AQC_B_STATUS"].Value = pobjMLCategoriaArquivo.IsStatus;
            }

                


            IDataReader idrRetorno = null;
            try
            {
                MLCategoriaArquivo objRetorno = null;
                lstRetorno = new List<MLCategoriaArquivo>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLCategoriaArquivo();
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
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>CategoriaArquivo</returns> 
        /// <user>GeradorVm2</user>
        public MLCategoriaArquivo Obter(decimal pdecCodigo)
        {

            MLCategoriaArquivo objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWC_S_ARQUIVO_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@AQC_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@AQC_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_AQC_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_AQC_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_AQC_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_AQC_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_AQC_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_AQC_B_STATUS"].Direction = ParameterDirection.Output;

            try
            {
                objRetorno = new MLCategoriaArquivo();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["@OUT_AQC_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_AQC_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_AQC_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_AQC_N_CODIGO"].Value);
                    if ((cmdCommand.Parameters["@OUT_AQC_C_DESCRICAO"] != null) && cmdCommand.Parameters["@OUT_AQC_C_DESCRICAO"].Value != null && cmdCommand.Parameters["@OUT_AQC_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_AQC_C_DESCRICAO"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_AQC_B_STATUS"] != null) && cmdCommand.Parameters["@OUT_AQC_B_STATUS"].Value != null && cmdCommand.Parameters["@OUT_AQC_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatus = Convert.ToBoolean(cmdCommand.Parameters["@OUT_AQC_B_STATUS"].Value);
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
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Excluir(decimal pdecCodigo)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_D_ARQUIVO_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@AQC_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@AQC_N_CODIGO"].Value = pdecCodigo;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                blnRetorno = true;

            }
            catch
            {
                throw;
            }
            return blnRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLCategoriaArquivo">CategoriaArquivo para alterar</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLCategoriaArquivo pobjMLCategoriaArquivo)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_U_ARQUIVO_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLCategoriaArquivo.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@AQC_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@AQC_N_CODIGO"].Value = pobjMLCategoriaArquivo.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLCategoriaArquivo.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@AQC_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@AQC_C_DESCRICAO"].Value = pobjMLCategoriaArquivo.Descricao;
            }
            if (pobjMLCategoriaArquivo.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@AQC_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@AQC_B_STATUS"].Value = pobjMLCategoriaArquivo.IsStatus.Value;
            }

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                blnRetorno = true;

            }
            catch
            {
                throw;
            }
            return blnRetorno;
        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLCategoriaArquivo">CategoriaArquivo para inserir</param>
        /// <returns>Código CategoriaArquivo</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLCategoriaArquivo pobjMLCategoriaArquivo)
        {

            int intRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_I_ARQUIVO_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLCategoriaArquivo.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@AQC_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@AQC_C_DESCRICAO"].Value = pobjMLCategoriaArquivo.Descricao;
            }
            if (pobjMLCategoriaArquivo.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@AQC_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@AQC_B_STATUS"].Value = pobjMLCategoriaArquivo.IsStatus.Value;
            }

            try
            {
                intRetorno = Convert.ToInt32(conProvider.ExecuteScalar(cmdCommand));

            }
            catch
            {
                throw;
            }
            return intRetorno;
        }

        #endregion
    }
}


