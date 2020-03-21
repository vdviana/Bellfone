using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.Model.FAQ;

namespace VM2.Framework.DataLayer.FAQ.Sql
{
    /// <summary> 
    /// Classe de conexão de dados para PerguntaFrequente 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLPerguntaFrequente : DLFWBase, IDLPerguntaFrequente
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2</user> 
        public DLPerguntaFrequente()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLPerguntaFrequente">Parametros para filtro</param>
        /// <returns>Lista de PerguntaFrequente</returns> 
        /// <user>GeradorVm2</user>
        public List<MLPerguntaFrequente> Listar(MLPerguntaFrequente pobjMLPerguntaFrequente)
        {

            List<MLPerguntaFrequente> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWC_L_PERGUNTA_FREQUENTE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLPerguntaFrequente.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@PFQ_N_CODIGO"].Value = pobjMLPerguntaFrequente.Codigo.Value;
            }
            if (pobjMLPerguntaFrequente.CodigoIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@PFQ_IDI_N_CODIGO"].Value = pobjMLPerguntaFrequente.CodigoIdioma.Value;
            }
            if (pobjMLPerguntaFrequente.CodigoPerguntaFrequenteCategoria.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_PFC_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@PFQ_PFC_N_CODIGO"].Value = pobjMLPerguntaFrequente.CodigoPerguntaFrequenteCategoria.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLPerguntaFrequente.Pergunta))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_C_PERGUNTA", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@PFQ_C_PERGUNTA"].Value = pobjMLPerguntaFrequente.Pergunta;
            }
            if (!string.IsNullOrEmpty(pobjMLPerguntaFrequente.Resposta))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_C_RESPOSTA", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@PFQ_C_RESPOSTA"].Value = pobjMLPerguntaFrequente.Resposta;
            }
            if (pobjMLPerguntaFrequente.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@PFQ_B_STATUS"].Value = pobjMLPerguntaFrequente.IsStatus.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLPerguntaFrequente objRetorno = null;
                lstRetorno = new List<MLPerguntaFrequente>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLPerguntaFrequente();
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
        /// <returns>PerguntaFrequente</returns> 
        /// <user>GeradorVm2</user>
        public MLPerguntaFrequente Obter(decimal pdecCodigo)
        {

            MLPerguntaFrequente objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWC_S_PERGUNTA_FREQUENTE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@PFQ_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@PFQ_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PFQ_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_PFQ_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PFQ_IDI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_PFQ_IDI_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PFQ_PFC_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_PFQ_PFC_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PFQ_C_PERGUNTA", FWDbType.Varchar, -1));
            cmdCommand.Parameters["@OUT_PFQ_C_PERGUNTA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PFQ_C_RESPOSTA", FWDbType.Varchar, -1));
            cmdCommand.Parameters["@OUT_PFQ_C_RESPOSTA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PFQ_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_PFQ_B_STATUS"].Direction = ParameterDirection.Output;

            try
            {
                objRetorno = new MLPerguntaFrequente();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["@OUT_PFQ_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_PFQ_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_PFQ_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_PFQ_N_CODIGO"].Value);
                    if ((cmdCommand.Parameters["@OUT_PFQ_IDI_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_PFQ_IDI_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_PFQ_IDI_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoIdioma = Convert.ToDecimal(cmdCommand.Parameters["@OUT_PFQ_IDI_N_CODIGO"].Value);
                    }

                    if ((cmdCommand.Parameters["@OUT_PFQ_PFC_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_PFQ_PFC_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_PFQ_PFC_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoPerguntaFrequenteCategoria = Convert.ToDecimal(cmdCommand.Parameters["@OUT_PFQ_PFC_N_CODIGO"].Value);
                    }

                    if ((cmdCommand.Parameters["@OUT_PFQ_C_PERGUNTA"] != null) && cmdCommand.Parameters["@OUT_PFQ_C_PERGUNTA"].Value != null && cmdCommand.Parameters["@OUT_PFQ_C_PERGUNTA"].Value != System.DBNull.Value)
                    {
                        objRetorno.Pergunta = cmdCommand.Parameters["@OUT_PFQ_C_PERGUNTA"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_PFQ_C_RESPOSTA"] != null) && cmdCommand.Parameters["@OUT_PFQ_C_RESPOSTA"].Value != null && cmdCommand.Parameters["@OUT_PFQ_C_RESPOSTA"].Value != System.DBNull.Value)
                    {
                        objRetorno.Resposta = cmdCommand.Parameters["@OUT_PFQ_C_RESPOSTA"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_PFQ_B_STATUS"] != null) && cmdCommand.Parameters["@OUT_PFQ_B_STATUS"].Value != null && cmdCommand.Parameters["@OUT_PFQ_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatus = Convert.ToBoolean(cmdCommand.Parameters["@OUT_PFQ_B_STATUS"].Value);
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
            FWCommand cmdCommand = new FWCommand("USP_FWC_D_PERGUNTA_FREQUENTE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@PFQ_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@PFQ_N_CODIGO"].Value = pdecCodigo;

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
        /// <param name="pobjMLPerguntaFrequente">PerguntaFrequente para alterar</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLPerguntaFrequente pobjMLPerguntaFrequente)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_U_PERGUNTA_FREQUENTE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLPerguntaFrequente.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@PFQ_N_CODIGO"].Value = pobjMLPerguntaFrequente.Codigo.Value;
            }
            if (pobjMLPerguntaFrequente.CodigoIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@PFQ_IDI_N_CODIGO"].Value = pobjMLPerguntaFrequente.CodigoIdioma.Value;
            }
            if (pobjMLPerguntaFrequente.CodigoPerguntaFrequenteCategoria.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_PFC_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@PFQ_PFC_N_CODIGO"].Value = pobjMLPerguntaFrequente.CodigoPerguntaFrequenteCategoria.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLPerguntaFrequente.Pergunta))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_C_PERGUNTA", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@PFQ_C_PERGUNTA"].Value = pobjMLPerguntaFrequente.Pergunta;
            }
            if (!string.IsNullOrEmpty(pobjMLPerguntaFrequente.Resposta))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_C_RESPOSTA", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@PFQ_C_RESPOSTA"].Value = pobjMLPerguntaFrequente.Resposta;
            }
            if (pobjMLPerguntaFrequente.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@PFQ_B_STATUS"].Value = pobjMLPerguntaFrequente.IsStatus.Value;
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
        /// <param name="pobjMLPerguntaFrequente">PerguntaFrequente para inserir</param>
        /// <returns>Código PerguntaFrequente</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLPerguntaFrequente pobjMLPerguntaFrequente)
        {

            int intRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_I_PERGUNTA_FREQUENTE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLPerguntaFrequente.CodigoIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@PFQ_IDI_N_CODIGO"].Value = pobjMLPerguntaFrequente.CodigoIdioma.Value;
            }
            if (pobjMLPerguntaFrequente.CodigoPerguntaFrequenteCategoria.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_PFC_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@PFQ_PFC_N_CODIGO"].Value = pobjMLPerguntaFrequente.CodigoPerguntaFrequenteCategoria.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLPerguntaFrequente.Pergunta))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_C_PERGUNTA", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@PFQ_C_PERGUNTA"].Value = pobjMLPerguntaFrequente.Pergunta;
            }
            if (!string.IsNullOrEmpty(pobjMLPerguntaFrequente.Resposta))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_C_RESPOSTA", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@PFQ_C_RESPOSTA"].Value = pobjMLPerguntaFrequente.Resposta;
            }
            if (pobjMLPerguntaFrequente.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PFQ_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@PFQ_B_STATUS"].Value = pobjMLPerguntaFrequente.IsStatus.Value;
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


