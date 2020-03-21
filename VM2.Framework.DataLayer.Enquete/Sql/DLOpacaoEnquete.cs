using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.Model.Enquete;

namespace VM2.Framework.DataLayer.Enquete.Sql
{
    /// <summary> 
    /// Classe de conexão de dados para EnqueteOpcao 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLEnqueteOpcao : DLFWBase, IDLEnqueteOpcao
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2</user> 
        public DLEnqueteOpcao()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLEnqueteOpcao">Parametros para filtro</param>
        /// <returns>Lista de EnqueteOpcao</returns> 
        /// <user>GeradorVm2</user>
        public List<MLEnqueteOpcao> Listar(MLEnqueteOpcao pobjMLEnqueteOpcao, decimal regAtual)
        {

            List<MLEnqueteOpcao> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWC_L_ENQUETE_OPCAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLEnqueteOpcao.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EQP_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@EQP_N_CODIGO"].Value = pobjMLEnqueteOpcao.Codigo.Value;
            }
           
                cmdCommand.Parameters.Add(new FWParameter("@EQP_ENQ_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@EQP_ENQ_N_CODIGO"].Value = regAtual;
            
            if (!string.IsNullOrEmpty(pobjMLEnqueteOpcao.Opcao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EQP_C_OPCAO", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@EQP_C_OPCAO"].Value = pobjMLEnqueteOpcao.Opcao;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLEnqueteOpcao objRetorno = null;
                lstRetorno = new List<MLEnqueteOpcao>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLEnqueteOpcao();
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
        /// <returns>EnqueteOpcao</returns> 
        /// <user>GeradorVm2</user>
        public MLEnqueteOpcao Obter(decimal pdecCodigo)
        {

            MLEnqueteOpcao objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWC_S_ENQUETE_OPCAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@EQP_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@EQP_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_EQP_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_EQP_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_EQP_ENQ_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_EQP_ENQ_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_EQP_C_OPCAO", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_EQP_C_OPCAO"].Direction = ParameterDirection.Output;

            try
            {
                objRetorno = new MLEnqueteOpcao();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["@OUT_EQP_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_EQP_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_EQP_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_EQP_N_CODIGO"].Value);
                    if ((cmdCommand.Parameters["@OUT_EQP_ENQ_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_EQP_ENQ_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_EQP_ENQ_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoEnquete = Convert.ToDecimal(cmdCommand.Parameters["@OUT_EQP_ENQ_N_CODIGO"].Value);
                    }

                    if ((cmdCommand.Parameters["@OUT_EQP_C_OPCAO"] != null) && cmdCommand.Parameters["@OUT_EQP_C_OPCAO"].Value != null && cmdCommand.Parameters["@OUT_EQP_C_OPCAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Opcao = cmdCommand.Parameters["@OUT_EQP_C_OPCAO"].Value.ToString();
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
            FWCommand cmdCommand = new FWCommand("USP_FWC_D_ENQUETE_OPCAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@EQP_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@EQP_N_CODIGO"].Value = pdecCodigo;

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
        /// <param name="pobjMLEnqueteOpcao">EnqueteOpcao para alterar</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLEnqueteOpcao pobjMLEnqueteOpcao)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_U_ENQUETE_OPCAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLEnqueteOpcao.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EQP_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@EQP_N_CODIGO"].Value = pobjMLEnqueteOpcao.Codigo.Value;
            }
            if (pobjMLEnqueteOpcao.CodigoEnquete.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EQP_ENQ_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@EQP_ENQ_N_CODIGO"].Value = pobjMLEnqueteOpcao.CodigoEnquete.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLEnqueteOpcao.Opcao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EQP_C_OPCAO", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@EQP_C_OPCAO"].Value = pobjMLEnqueteOpcao.Opcao;
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
        /// <param name="pobjMLEnqueteOpcao">EnqueteOpcao para inserir</param>
        /// <returns>Código EnqueteOpcao</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLEnqueteOpcao pobjMLEnqueteOpcao)
        {

            int intRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_I_ENQUETE_OPCAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLEnqueteOpcao.CodigoEnquete.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EQP_ENQ_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@EQP_ENQ_N_CODIGO"].Value = pobjMLEnqueteOpcao.CodigoEnquete.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLEnqueteOpcao.Opcao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EQP_C_OPCAO", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@EQP_C_OPCAO"].Value = pobjMLEnqueteOpcao.Opcao;
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


