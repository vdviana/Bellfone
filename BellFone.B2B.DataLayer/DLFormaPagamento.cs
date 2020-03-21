using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para FormaPagamento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class DLFormaPagamento : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.1]</user> 
        public DLFormaPagamento()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLFormaPagamento">Parametros para filtro</param>
        /// <returns>Lista de FormaPagamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLFormaPagamento> Listar(MLFormaPagamento pobjMLFormaPagamento)
        {

            List<MLFormaPagamento> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_FORMA_PAGAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLFormaPagamento.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FOP_C_CODIGO", FWDbType.Varchar, 2));
                cmdCommand.Parameters["@FOP_C_CODIGO"].Value = pobjMLFormaPagamento.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLFormaPagamento.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FOP_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@FOP_C_DESCRICAO"].Value = pobjMLFormaPagamento.Descricao;
            }
            if (pobjMLFormaPagamento.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FOP_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@FOP_B_ATIVO"].Value = pobjMLFormaPagamento.IsAtivo.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLFormaPagamento objRetorno = null;
                lstRetorno = new List<MLFormaPagamento>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLFormaPagamento();
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
        /// <returns>FormaPagamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLFormaPagamento Obter(string pstrCodigo)
        {

            MLFormaPagamento objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_FORMA_PAGAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@FOP_C_CODIGO", FWDbType.Varchar, 2));
            cmdCommand.Parameters["@FOP_C_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FOP_C_CODIGO", FWDbType.Varchar, 2));
            cmdCommand.Parameters["@OUT_FOP_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FOP_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_FOP_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FOP_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_FOP_B_ATIVO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_FOP_C_CODIGO") && cmdCommand.Parameters["@OUT_FOP_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLFormaPagamento();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_FOP_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_FOP_C_DESCRICAO") && cmdCommand.Parameters["@OUT_FOP_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_FOP_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_FOP_B_ATIVO") && cmdCommand.Parameters["@OUT_FOP_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_FOP_B_ATIVO"].Value);
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

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_FORMA_PAGAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@FOP_C_CODIGO", FWDbType.Varchar, 2));
            cmdCommand.Parameters["@FOP_C_CODIGO"].Value = pstrCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLFormaPagamento">FormaPagamento para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLFormaPagamento pobjMLFormaPagamento)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_FORMA_PAGAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLFormaPagamento.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FOP_C_CODIGO", FWDbType.Varchar, 2));
                cmdCommand.Parameters["@FOP_C_CODIGO"].Value = pobjMLFormaPagamento.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLFormaPagamento.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FOP_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@FOP_C_DESCRICAO"].Value = pobjMLFormaPagamento.Descricao;
            }
            if (pobjMLFormaPagamento.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FOP_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@FOP_B_ATIVO"].Value = pobjMLFormaPagamento.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLFormaPagamento">FormaPagamento para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Inserir(MLFormaPagamento pobjMLFormaPagamento)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_FORMA_PAGAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLFormaPagamento.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FOP_C_CODIGO", FWDbType.Varchar, 2));
                cmdCommand.Parameters["@FOP_C_CODIGO"].Value = pobjMLFormaPagamento.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLFormaPagamento.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FOP_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@FOP_C_DESCRICAO"].Value = pobjMLFormaPagamento.Descricao;
            }
            if (pobjMLFormaPagamento.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FOP_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@FOP_B_ATIVO"].Value = pobjMLFormaPagamento.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion
    }
}



