using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para StatusItemOrcamento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.1.1]</user> 
    public class DLStatusItemOrcamento : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.1.1]</user> 
        public DLStatusItemOrcamento()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLStatusItemOrcamento">Parametros para filtro</param>
        /// <returns>Lista de StatusItemOrcamento</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public List<MLStatusItemOrcamento> Listar(MLStatusItemOrcamento pobjMLStatusItemOrcamento)
        {

            List<MLStatusItemOrcamento> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_STATUS_ITEM_ORCAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLStatusItemOrcamento.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@STI_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@STI_C_CODIGO"].Value = pobjMLStatusItemOrcamento.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLStatusItemOrcamento.Descicao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@STI_C_DESCICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@STI_C_DESCICAO"].Value = pobjMLStatusItemOrcamento.Descicao;
            }
            if (pobjMLStatusItemOrcamento.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@STI_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@STI_B_ATIVO"].Value = pobjMLStatusItemOrcamento.IsAtivo.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLStatusItemOrcamento objRetorno = null;
                lstRetorno = new List<MLStatusItemOrcamento>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLStatusItemOrcamento();
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
        /// <returns>StatusItemOrcamento</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public MLStatusItemOrcamento Obter(string pstrCodigo)
        {

            MLStatusItemOrcamento objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_STATUS_ITEM_ORCAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@STI_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@STI_C_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_STI_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_STI_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_STI_C_DESCICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_STI_C_DESCICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_STI_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_STI_B_ATIVO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_STI_C_CODIGO") && cmdCommand.Parameters["@OUT_STI_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLStatusItemOrcamento();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_STI_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_STI_C_DESCICAO") && cmdCommand.Parameters["@OUT_STI_C_DESCICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descicao = cmdCommand.Parameters["@OUT_STI_C_DESCICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_STI_B_ATIVO") && cmdCommand.Parameters["@OUT_STI_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_STI_B_ATIVO"].Value);
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
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public int Excluir(string pstrCodigo)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_STATUS_ITEM_ORCAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@STI_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@STI_C_CODIGO"].Value = pstrCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLStatusItemOrcamento">StatusItemOrcamento para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public int Alterar(MLStatusItemOrcamento pobjMLStatusItemOrcamento)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_STATUS_ITEM_ORCAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLStatusItemOrcamento.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@STI_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@STI_C_CODIGO"].Value = pobjMLStatusItemOrcamento.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLStatusItemOrcamento.Descicao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@STI_C_DESCICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@STI_C_DESCICAO"].Value = pobjMLStatusItemOrcamento.Descicao;
            }
            if (pobjMLStatusItemOrcamento.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@STI_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@STI_B_ATIVO"].Value = pobjMLStatusItemOrcamento.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLStatusItemOrcamento">StatusItemOrcamento para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public int Inserir(MLStatusItemOrcamento pobjMLStatusItemOrcamento)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_STATUS_ITEM_ORCAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLStatusItemOrcamento.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@STI_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@STI_C_CODIGO"].Value = pobjMLStatusItemOrcamento.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLStatusItemOrcamento.Descicao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@STI_C_DESCICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@STI_C_DESCICAO"].Value = pobjMLStatusItemOrcamento.Descicao;
            }
            if (pobjMLStatusItemOrcamento.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@STI_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@STI_B_ATIVO"].Value = pobjMLStatusItemOrcamento.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion
    }
}


