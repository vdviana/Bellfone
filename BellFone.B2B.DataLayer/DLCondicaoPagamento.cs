using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para CondicaoPagamento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class DLCondicaoPagamento : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.1]</user> 
        public DLCondicaoPagamento()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLCondicaoPagamento">Parametros para filtro</param>
        /// <returns>Lista de CondicaoPagamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLCondicaoPagamento> Listar(MLCondicaoPagamento pobjMLCondicaoPagamento)
        {

            List<MLCondicaoPagamento> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_CONDICAO_PAGAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLCondicaoPagamento.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CON_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@CON_C_CODIGO"].Value = pobjMLCondicaoPagamento.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLCondicaoPagamento.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CON_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@CON_C_DESCRICAO"].Value = pobjMLCondicaoPagamento.Descricao;
            }
            if (pobjMLCondicaoPagamento.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CON_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@CON_B_ATIVO"].Value = pobjMLCondicaoPagamento.IsAtivo.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLCondicaoPagamento objRetorno = null;
                lstRetorno = new List<MLCondicaoPagamento>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLCondicaoPagamento();
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
        /// <returns>CondicaoPagamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLCondicaoPagamento Obter(string pstrCodigo)
        {

            MLCondicaoPagamento objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_CONDICAO_PAGAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@CON_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@CON_C_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_CON_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_CON_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_CON_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_CON_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_CON_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_CON_B_ATIVO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_CON_C_CODIGO") && cmdCommand.Parameters["@OUT_CON_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLCondicaoPagamento();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_CON_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_CON_C_DESCRICAO") && cmdCommand.Parameters["@OUT_CON_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_CON_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_CON_B_ATIVO") && cmdCommand.Parameters["@OUT_CON_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_CON_B_ATIVO"].Value);
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

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_CONDICAO_PAGAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@CON_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@CON_C_CODIGO"].Value = pstrCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLCondicaoPagamento">CondicaoPagamento para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLCondicaoPagamento pobjMLCondicaoPagamento)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_CONDICAO_PAGAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLCondicaoPagamento.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CON_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@CON_C_CODIGO"].Value = pobjMLCondicaoPagamento.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLCondicaoPagamento.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CON_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@CON_C_DESCRICAO"].Value = pobjMLCondicaoPagamento.Descricao;
            }
            if (pobjMLCondicaoPagamento.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CON_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@CON_B_ATIVO"].Value = pobjMLCondicaoPagamento.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLCondicaoPagamento">CondicaoPagamento para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Inserir(MLCondicaoPagamento pobjMLCondicaoPagamento)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_CONDICAO_PAGAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLCondicaoPagamento.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CON_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@CON_C_CODIGO"].Value = pobjMLCondicaoPagamento.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLCondicaoPagamento.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CON_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@CON_C_DESCRICAO"].Value = pobjMLCondicaoPagamento.Descricao;
            }
            if (pobjMLCondicaoPagamento.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CON_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@CON_B_ATIVO"].Value = pobjMLCondicaoPagamento.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion
    }
}



