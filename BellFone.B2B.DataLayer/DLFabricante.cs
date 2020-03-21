using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para Fabricante 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class DLFabricante : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.0]</user> 
        public DLFabricante()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLFabricante">Parametros para filtro</param>
        /// <returns>Lista de Fabricante</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLFabricante> Listar(MLFabricante pobjMLFabricante)
        {

            List<MLFabricante> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_FABRICANTE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLFabricante.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FAB_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@FAB_C_CODIGO"].Value = pobjMLFabricante.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLFabricante.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FAB_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@FAB_C_DESCRICAO"].Value = pobjMLFabricante.Descricao;
            }
            if (pobjMLFabricante.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FAB_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@FAB_B_ATIVO"].Value = pobjMLFabricante.IsAtivo.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLFabricante objRetorno = null;
                lstRetorno = new List<MLFabricante>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLFabricante();
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
        /// <returns>Fabricante</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLFabricante Obter(string pstrCodigo)
        {

            MLFabricante objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_FABRICANTE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@FAB_C_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@FAB_C_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FAB_C_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_FAB_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FAB_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_FAB_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FAB_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_FAB_B_ATIVO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_FAB_C_CODIGO") && cmdCommand.Parameters["@OUT_FAB_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLFabricante();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_FAB_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_FAB_C_DESCRICAO") && cmdCommand.Parameters["@OUT_FAB_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_FAB_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_FAB_B_ATIVO") && cmdCommand.Parameters["@OUT_FAB_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_FAB_B_ATIVO"].Value);
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
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Excluir(string pstrCodigo)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_FABRICANTE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@FAB_C_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@FAB_C_CODIGO"].Value = pstrCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLFabricante">Fabricante para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLFabricante pobjMLFabricante)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_FABRICANTE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLFabricante.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FAB_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@FAB_C_CODIGO"].Value = pobjMLFabricante.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLFabricante.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FAB_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@FAB_C_DESCRICAO"].Value = pobjMLFabricante.Descricao;
            }
            if (pobjMLFabricante.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FAB_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@FAB_B_ATIVO"].Value = pobjMLFabricante.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLFabricante">Fabricante para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Inserir(MLFabricante pobjMLFabricante)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_FABRICANTE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLFabricante.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FAB_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@FAB_C_CODIGO"].Value = pobjMLFabricante.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLFabricante.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FAB_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@FAB_C_DESCRICAO"].Value = pobjMLFabricante.Descricao;
            }
            if (pobjMLFabricante.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FAB_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@FAB_B_ATIVO"].Value = pobjMLFabricante.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion
    }
}


