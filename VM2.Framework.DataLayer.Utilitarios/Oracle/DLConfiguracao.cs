using System;
using System.Collections.Generic;
using System.Text;
using VM2.Framework.DataLayer.Utilitarios;
using System.Configuration;
using VM2.Framework.Model.Utilitarios;
using System.Data;

namespace VM2.Framework.DataLayer.Utilitarios.Oracle
{
    public class DLConfiguracao : DLFWBase, IDLConfiguracao
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>mazevedo</user> 
        public DLConfiguracao()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }

        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLConfiguracao">Parametros para filtro</param>
        /// <returns>Lista de Configuracao</returns> 
        /// <user>mazevedo</user>
        public List<MLConfiguracao> Listar(MLConfiguracao pobjMLConfiguracao)
        {

            List<MLConfiguracao> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWK_L_CONFIGURACAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLConfiguracao.Chave))
            {
                cmdCommand.Parameters.Add(new FWParameter("CFG_C_CHAVE", FWDbType.Varchar, 50));
                cmdCommand.Parameters["CFG_C_CHAVE"].Value = pobjMLConfiguracao.Chave;
            }
            if (!string.IsNullOrEmpty(pobjMLConfiguracao.Valor))
            {
                cmdCommand.Parameters.Add(new FWParameter("CFG_C_VALOR", FWDbType.Varchar, 100));
                cmdCommand.Parameters["CFG_C_VALOR"].Value = pobjMLConfiguracao.Valor;
            }

            // Retorno do Curso
            cmdCommand.Parameters.Add(new FWParameter("RCT1", FWDbType.Cursor));
            cmdCommand.Parameters["RCT1"].Direction = ParameterDirection.Output;

            IDataReader idrRetorno = null;
            try
            {
                MLConfiguracao objRetorno = null;
                lstRetorno = new List<MLConfiguracao>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLConfiguracao();
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
        /// <param name="pstrChave">Chave</param>
        /// <returns>Configuracao</returns> 
        /// <user>mazevedo</user>
        public MLConfiguracao Obter(string pstrChave)
        {

            MLConfiguracao objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWK_S_CONFIGURACAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("CFG_C_CHAVE", FWDbType.Varchar, 50));
            cmdCommand.Parameters["CFG_C_CHAVE"].Value = pstrChave;
            cmdCommand.Parameters.Add(new FWParameter("OUT_CFG_C_CHAVE", FWDbType.Varchar, 50));
            cmdCommand.Parameters["OUT_CFG_C_CHAVE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_CFG_C_VALOR", FWDbType.Varchar, 100));
            cmdCommand.Parameters["OUT_CFG_C_VALOR"].Direction = ParameterDirection.Output;

            try
            {
                objRetorno = new MLConfiguracao();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["OUT_CFG_C_CHAVE"] != null) && cmdCommand.Parameters["OUT_CFG_C_CHAVE"].Value != null && cmdCommand.Parameters["OUT_CFG_C_CHAVE"].Value != System.DBNull.Value)
                {
                    objRetorno.Chave = cmdCommand.Parameters["OUT_CFG_C_CHAVE"].Value.ToString();
                    if ((cmdCommand.Parameters["OUT_CFG_C_VALOR"] != null) && cmdCommand.Parameters["OUT_CFG_C_VALOR"].Value != null && cmdCommand.Parameters["OUT_CFG_C_VALOR"].Value != System.DBNull.Value)
                    {
                        objRetorno.Valor = cmdCommand.Parameters["OUT_CFG_C_VALOR"].Value.ToString();
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

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLConfiguracao">Configuracao para alterar</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>mazevedo</user>
        public bool Alterar(MLConfiguracao pobjMLConfiguracao)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWK_U_CONFIGURACAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLConfiguracao.Chave))
            {
                cmdCommand.Parameters.Add(new FWParameter("CFG_C_CHAVE", FWDbType.Varchar, 50));
                cmdCommand.Parameters["CFG_C_CHAVE"].Value = pobjMLConfiguracao.Chave;
            }
            if (!string.IsNullOrEmpty(pobjMLConfiguracao.Valor))
            {
                cmdCommand.Parameters.Add(new FWParameter("CFG_C_VALOR", FWDbType.Varchar, 100));
                cmdCommand.Parameters["CFG_C_VALOR"].Value = pobjMLConfiguracao.Valor;
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

    }
}
