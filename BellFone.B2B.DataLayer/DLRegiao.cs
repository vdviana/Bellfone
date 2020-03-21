using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para Regiao 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class DLRegiao : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.1]</user> 
        public DLRegiao()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLRegiao">Parametros para filtro</param>
        /// <returns>Lista de Regiao</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLRegiao> Listar(MLRegiao pobjMLRegiao)
        {

            List<MLRegiao> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_REGIAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLRegiao.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REG_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@REG_C_CODIGO"].Value = pobjMLRegiao.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLRegiao.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REG_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@REG_C_DESCRICAO"].Value = pobjMLRegiao.Descricao;
            }
            if (pobjMLRegiao.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@REG_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@REG_B_STATUS"].Value = pobjMLRegiao.IsStatus.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLRegiao objRetorno = null;
                lstRetorno = new List<MLRegiao>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLRegiao();
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
        /// <returns>Regiao</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLRegiao Obter(string pstrCodigo)
        {

            MLRegiao objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_REGIAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@REG_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@REG_C_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REG_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_REG_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REG_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_REG_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REG_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_REG_B_STATUS"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_REG_C_CODIGO") && cmdCommand.Parameters["@OUT_REG_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLRegiao();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_REG_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_REG_C_DESCRICAO") && cmdCommand.Parameters["@OUT_REG_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_REG_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REG_B_STATUS") && cmdCommand.Parameters["@OUT_REG_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatus = Convert.ToBoolean(cmdCommand.Parameters["@OUT_REG_B_STATUS"].Value);
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
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Excluir(string pstrCodigo)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_REGIAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@REG_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@REG_C_CODIGO"].Value = pstrCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLRegiao">Regiao para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLRegiao pobjMLRegiao)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_REGIAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLRegiao.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REG_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@REG_C_CODIGO"].Value = pobjMLRegiao.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLRegiao.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REG_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@REG_C_DESCRICAO"].Value = pobjMLRegiao.Descricao;
            }
            if (pobjMLRegiao.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@REG_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@REG_B_STATUS"].Value = pobjMLRegiao.IsStatus.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLRegiao">Regiao para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Inserir(MLRegiao pobjMLRegiao)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_REGIAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLRegiao.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REG_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@REG_C_CODIGO"].Value = pobjMLRegiao.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLRegiao.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REG_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@REG_C_DESCRICAO"].Value = pobjMLRegiao.Descricao;
            }
            if (pobjMLRegiao.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@REG_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@REG_B_STATUS"].Value = pobjMLRegiao.IsStatus.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion
    }
}


