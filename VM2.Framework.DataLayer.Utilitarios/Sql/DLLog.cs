using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using VM2.Framework.Model.Utilitarios;


namespace VM2.Framework.DataLayer.Utilitarios.Sql
{

    /// <summary>
    ///     Classe de acesso a dados para Log de Erro
    /// </summary>
    /// <user>mazevedo</user>
    public class DLLog : DLFWBase, IDLLog
    {

        /// <summary>
        ///     Contrutor da classe inicializa as conexões
        /// </summary>
        /// <user>mazevedo</user>
        public DLLog()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }

        #region Listar

        /// <summary>
        ///     Executa a stored procedure de listagem
        /// </summary>
        /// <param name="pobjParametro">Parametros de Filtro</param>
        /// <returns>Lista de logs</returns>
        /// <user>mazevedo</user>
        public List<MLLog> Listar(MLLog pobjParametro)
        {

            List<MLLog> colRetorno = null;

            // Cria os objetos de conexão ao banco de dados
            FWCommand cmdCommand = new FWCommand("USP_FWK_L_LOG_ERRO");
            // Monta cmdCommand como Stored Procedure
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            //Parâmetros de entrada

            if (pobjParametro.Codigo > 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("@LOG_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@LOG_N_CODIGO"].Value = pobjParametro.Codigo;
            }

            if (!string.IsNullOrEmpty(pobjParametro.Metodo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@LOG_C_ERRO", FWDbType.Varchar, 255));
                cmdCommand.Parameters["@LOG_C_ERRO"].Value = pobjParametro.Metodo;
            }

            if (pobjParametro.Data != null && pobjParametro.Data > DateTime.MinValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@LOG_D_DATA", FWDbType.DateTime));
                cmdCommand.Parameters["@LOG_D_DATA"].Value = pobjParametro.Data;
            }

            if (!string.IsNullOrEmpty(pobjParametro.StackTrace))
            {
                cmdCommand.Parameters.Add(new FWParameter("@LOG_C_STACK", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@LOG_C_STACK"].Value = pobjParametro.StackTrace;
            }

            try
            {
                IDataReader idrRetorno;
                MLLog objRetorno = null;
                colRetorno = new List<MLLog>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLLog();
                    objRetorno.FromIDataReader(idrRetorno);
                    colRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }
            return colRetorno;
        }

        #endregion

        #region Inserir

        /// <summary>
        ///     Executa a stored procedure para inserir
        /// </summary>
        /// <param name="pobjLog">Log para inserir</param>
        /// <returns>Codigo do log</returns>
        /// <user>mazevedo</user>
        public int Inserir(MLLog pobjLog)
        {

            int intRetorno;
            // Cria os objetos de conexão ao banco de dados
            FWCommand cmdCommand = new FWCommand("USP_FWK_I_LOG_ERRO");
            // Monta cmdCommand como Stored Procedure
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            //Parâmetros de entrada
            cmdCommand.Parameters.Add(new FWParameter("@LOG_C_ERRO", FWDbType.Varchar, 255));
            cmdCommand.Parameters["@LOG_C_ERRO"].Value = pobjLog.Metodo;
            cmdCommand.Parameters.Add(new FWParameter("@LOG_D_DATA", FWDbType.DateTime));
            cmdCommand.Parameters["@LOG_D_DATA"].Value = pobjLog.Data;
            cmdCommand.Parameters.Add(new FWParameter("@LOG_C_STACK", FWDbType.Varchar, -1));
            cmdCommand.Parameters["@LOG_C_STACK"].Value = pobjLog.StackTrace;

            // Executa o comando da stored procedure
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


