using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.Model.FAQ;
using VM2.Framework.DataLayer.FAQ;

namespace VM2.Framework.DataLayer.FAQ.Sql
{
    /// <summary> 
    /// Classe de conexão de dados para PerguntaFrequenteCategoria 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLPerguntaFrequenteCategoria : DLFWBase, IDLPerguntaFrequenteCategoria
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2</user> 
        public DLPerguntaFrequenteCategoria()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLPerguntaFrequenteCategoria">Parametros para filtro</param>
        /// <returns>Lista de PerguntaFrequenteCategoria</returns> 
        /// <user>GeradorVm2</user>
        public List<MLPerguntaFrequenteCategoria> Listar(MLPerguntaFrequenteCategoria pobjMLPerguntaFrequenteCategoria)
        {

            List<MLPerguntaFrequenteCategoria> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWC_L_PERGUNTA_FREQUENTE_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLPerguntaFrequenteCategoria.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FQC_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@FQC_N_CODIGO"].Value = pobjMLPerguntaFrequenteCategoria.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLPerguntaFrequenteCategoria.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FQC_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@FQC_C_DESCRICAO"].Value = pobjMLPerguntaFrequenteCategoria.Descricao;
            }
            if (pobjMLPerguntaFrequenteCategoria.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FQC_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@FQC_B_STATUS"].Value = pobjMLPerguntaFrequenteCategoria.IsStatus;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLPerguntaFrequenteCategoria objRetorno = null;
                lstRetorno = new List<MLPerguntaFrequenteCategoria>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLPerguntaFrequenteCategoria();
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
        /// <returns>PerguntaFrequenteCategoria</returns> 
        /// <user>GeradorVm2</user>
        public MLPerguntaFrequenteCategoria Obter(decimal pdecCodigo)
        {

            MLPerguntaFrequenteCategoria objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWC_S_PERGUNTA_FREQUENTE_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@FQC_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@FQC_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FQC_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_FQC_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FQC_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_FQC_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FQC_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_FQC_B_STATUS"].Direction = ParameterDirection.Output;

            try
            {
                objRetorno = new MLPerguntaFrequenteCategoria();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["@OUT_FQC_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_FQC_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_FQC_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_FQC_N_CODIGO"].Value);
                    if ((cmdCommand.Parameters["@OUT_FQC_C_DESCRICAO"] != null) && cmdCommand.Parameters["@OUT_FQC_C_DESCRICAO"].Value != null && cmdCommand.Parameters["@OUT_FQC_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_FQC_C_DESCRICAO"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_FQC_B_STATUS"] != null) && cmdCommand.Parameters["@OUT_FQC_B_STATUS"].Value != null && cmdCommand.Parameters["@OUT_FQC_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatus = Convert.ToBoolean(cmdCommand.Parameters["@OUT_FQC_B_STATUS"].Value);
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
            FWCommand cmdCommand = new FWCommand("USP_FWC_D_PERGUNTA_FREQUENTE_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@FQC_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@FQC_N_CODIGO"].Value = pdecCodigo;

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
        /// <param name="pobjMLPerguntaFrequenteCategoria">PerguntaFrequenteCategoria para alterar</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLPerguntaFrequenteCategoria pobjMLPerguntaFrequenteCategoria)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_U_PERGUNTA_FREQUENTE_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLPerguntaFrequenteCategoria.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FQC_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@FQC_N_CODIGO"].Value = pobjMLPerguntaFrequenteCategoria.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLPerguntaFrequenteCategoria.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FQC_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@FQC_C_DESCRICAO"].Value = pobjMLPerguntaFrequenteCategoria.Descricao;
            }
            if (pobjMLPerguntaFrequenteCategoria.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FQC_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@FQC_B_STATUS"].Value = pobjMLPerguntaFrequenteCategoria.IsStatus.Value;
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
        /// <param name="pobjMLPerguntaFrequenteCategoria">PerguntaFrequenteCategoria para inserir</param>
        /// <returns>Código PerguntaFrequenteCategoria</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLPerguntaFrequenteCategoria pobjMLPerguntaFrequenteCategoria)
        {

            int intRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_I_PERGUNTA_FREQUENTE_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLPerguntaFrequenteCategoria.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FQC_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@FQC_C_DESCRICAO"].Value = pobjMLPerguntaFrequenteCategoria.Descricao;
            }
            if (pobjMLPerguntaFrequenteCategoria.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FQC_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@FQC_B_STATUS"].Value = pobjMLPerguntaFrequenteCategoria.IsStatus.Value;
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


