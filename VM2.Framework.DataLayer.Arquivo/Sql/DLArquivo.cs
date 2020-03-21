using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.Model.Arquivo;

namespace VM2.Framework.DataLayer.Arquivo.Sql
{
    /// <summary> 
    /// Classe de conexão de dados para Arquivo 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLArquivo : DLFWBase, IDLArquivo
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2</user> 
        public DLArquivo()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLArquivo">Parametros para filtro</param>
        /// <returns>Lista de Arquivo</returns> 
        /// <user>GeradorVm2</user>
        public List<MLArquivo> Listar(MLArquivo pobjMLArquivo)
        {

            List<MLArquivo> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWC_L_ARQUIVO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLArquivo.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@ARQ_N_CODIGO"].Value = pobjMLArquivo.Codigo.Value;
            }
            if (pobjMLArquivo.CodigoIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@ARQ_IDI_N_CODIGO"].Value = pobjMLArquivo.CodigoIdioma.Value;
            }
            if (pobjMLArquivo.CodigoArquivoCategoria.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_AQC_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@ARQ_AQC_N_CODIGO"].Value = pobjMLArquivo.CodigoArquivoCategoria.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLArquivo.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_C_NOME", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@ARQ_C_NOME"].Value = pobjMLArquivo.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLArquivo.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_C_DESCRICAO", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@ARQ_C_DESCRICAO"].Value = pobjMLArquivo.Descricao;
            }
            if (!string.IsNullOrEmpty(pobjMLArquivo.Arquivo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_C_ARQUIVO", FWDbType.Varchar, 300));
                cmdCommand.Parameters["@ARQ_C_ARQUIVO"].Value = pobjMLArquivo.Arquivo;
            }
            if (pobjMLArquivo.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@ARQ_B_STATUS"].Value = pobjMLArquivo.IsStatus.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLArquivo objRetorno = null;
                lstRetorno = new List<MLArquivo>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLArquivo();
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
        /// <returns>Arquivo</returns> 
        /// <user>GeradorVm2</user>
        public MLArquivo Obter(decimal pdecCodigo)
        {

            MLArquivo objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWC_S_ARQUIVO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@ARQ_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@ARQ_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ARQ_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_ARQ_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ARQ_IDI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_ARQ_IDI_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ARQ_AQC_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_ARQ_AQC_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ARQ_C_NOME", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_ARQ_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ARQ_C_DESCRICAO", FWDbType.Varchar, -1));
            cmdCommand.Parameters["@OUT_ARQ_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ARQ_C_ARQUIVO", FWDbType.Varchar, 300));
            cmdCommand.Parameters["@OUT_ARQ_C_ARQUIVO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ARQ_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_ARQ_B_STATUS"].Direction = ParameterDirection.Output;

            try
            {
                objRetorno = new MLArquivo();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["@OUT_ARQ_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_ARQ_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_ARQ_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_ARQ_N_CODIGO"].Value);
                    if ((cmdCommand.Parameters["@OUT_ARQ_IDI_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_ARQ_IDI_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_ARQ_IDI_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoIdioma = Convert.ToDecimal(cmdCommand.Parameters["@OUT_ARQ_IDI_N_CODIGO"].Value);
                    }

                    if ((cmdCommand.Parameters["@OUT_ARQ_AQC_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_ARQ_AQC_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_ARQ_AQC_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoArquivoCategoria = Convert.ToDecimal(cmdCommand.Parameters["@OUT_ARQ_AQC_N_CODIGO"].Value);
                    }

                    if ((cmdCommand.Parameters["@OUT_ARQ_C_NOME"] != null) && cmdCommand.Parameters["@OUT_ARQ_C_NOME"].Value != null && cmdCommand.Parameters["@OUT_ARQ_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.Nome = cmdCommand.Parameters["@OUT_ARQ_C_NOME"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_ARQ_C_DESCRICAO"] != null) && cmdCommand.Parameters["@OUT_ARQ_C_DESCRICAO"].Value != null && cmdCommand.Parameters["@OUT_ARQ_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_ARQ_C_DESCRICAO"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_ARQ_C_ARQUIVO"] != null) && cmdCommand.Parameters["@OUT_ARQ_C_ARQUIVO"].Value != null && cmdCommand.Parameters["@OUT_ARQ_C_ARQUIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Arquivo = cmdCommand.Parameters["@OUT_ARQ_C_ARQUIVO"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_ARQ_B_STATUS"] != null) && cmdCommand.Parameters["@OUT_ARQ_B_STATUS"].Value != null && cmdCommand.Parameters["@OUT_ARQ_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatus = Convert.ToBoolean(cmdCommand.Parameters["@OUT_ARQ_B_STATUS"].Value);
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
            FWCommand cmdCommand = new FWCommand("USP_FWC_D_ARQUIVO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@ARQ_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@ARQ_N_CODIGO"].Value = pdecCodigo;

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
        /// <param name="pobjMLArquivo">Arquivo para alterar</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLArquivo pobjMLArquivo)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_U_ARQUIVO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLArquivo.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@ARQ_N_CODIGO"].Value = pobjMLArquivo.Codigo.Value;
            }
            if (pobjMLArquivo.CodigoIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@ARQ_IDI_N_CODIGO"].Value = pobjMLArquivo.CodigoIdioma.Value;
            }
            if (pobjMLArquivo.CodigoArquivoCategoria.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_AQC_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@ARQ_AQC_N_CODIGO"].Value = pobjMLArquivo.CodigoArquivoCategoria.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLArquivo.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_C_NOME", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@ARQ_C_NOME"].Value = pobjMLArquivo.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLArquivo.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_C_DESCRICAO", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@ARQ_C_DESCRICAO"].Value = pobjMLArquivo.Descricao;
            }
            if (!string.IsNullOrEmpty(pobjMLArquivo.Arquivo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_C_ARQUIVO", FWDbType.Varchar, 300));
                cmdCommand.Parameters["@ARQ_C_ARQUIVO"].Value = pobjMLArquivo.Arquivo;
            }
            if (pobjMLArquivo.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@ARQ_B_STATUS"].Value = pobjMLArquivo.IsStatus.Value;
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
        /// <param name="pobjMLArquivo">Arquivo para inserir</param>
        /// <returns>Código Arquivo</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLArquivo pobjMLArquivo)
        {

            int intRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_I_ARQUIVO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            cmdCommand.Parameters.Add(new FWParameter("@ARQ_IDI_N_CODIGO", FWDbType.Decimal));

            if (pobjMLArquivo.CodigoIdioma.HasValue)
            {
                cmdCommand.Parameters["@ARQ_IDI_N_CODIGO"].Value = pobjMLArquivo.CodigoIdioma.Value;
            }
            else
            {
                cmdCommand.Parameters["@ARQ_IDI_N_CODIGO"].Value = DBNull.Value;
            }



            if (pobjMLArquivo.CodigoArquivoCategoria.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_AQC_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@ARQ_AQC_N_CODIGO"].Value = pobjMLArquivo.CodigoArquivoCategoria.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLArquivo.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_C_NOME", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@ARQ_C_NOME"].Value = pobjMLArquivo.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLArquivo.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_C_DESCRICAO", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@ARQ_C_DESCRICAO"].Value = pobjMLArquivo.Descricao;
            }
            if (!string.IsNullOrEmpty(pobjMLArquivo.Arquivo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_C_ARQUIVO", FWDbType.Varchar, 300));
                cmdCommand.Parameters["@ARQ_C_ARQUIVO"].Value = pobjMLArquivo.Arquivo;
            }
            if (pobjMLArquivo.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ARQ_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@ARQ_B_STATUS"].Value = pobjMLArquivo.IsStatus.Value;
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


