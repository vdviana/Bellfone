using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para UnidadeMedida 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class DLUnidadeMedida : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.1]</user> 
        public DLUnidadeMedida()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLUnidadeMedida">Parametros para filtro</param>
        /// <returns>Lista de UnidadeMedida</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLUnidadeMedida> Listar(MLUnidadeMedida pobjMLUnidadeMedida)
        {

            List<MLUnidadeMedida> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_UNIDADE_MEDIDA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLUnidadeMedida.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@UNM_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@UNM_C_CODIGO"].Value = pobjMLUnidadeMedida.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLUnidadeMedida.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@UNM_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@UNM_C_DESCRICAO"].Value = pobjMLUnidadeMedida.Descricao;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLUnidadeMedida objRetorno = null;
                lstRetorno = new List<MLUnidadeMedida>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLUnidadeMedida();
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
        /// <returns>UnidadeMedida</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLUnidadeMedida Obter(string pstrCodigo)
        {

            MLUnidadeMedida objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_UNIDADE_MEDIDA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@UNM_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@UNM_C_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_UNM_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_UNM_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_UNM_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_UNM_C_DESCRICAO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_UNM_C_CODIGO") && cmdCommand.Parameters["@OUT_UNM_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLUnidadeMedida();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_UNM_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_UNM_C_DESCRICAO") && cmdCommand.Parameters["@OUT_UNM_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_UNM_C_DESCRICAO"].Value.ToString();
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

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_UNIDADE_MEDIDA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@UNM_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@UNM_C_CODIGO"].Value = pstrCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLUnidadeMedida">UnidadeMedida para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLUnidadeMedida pobjMLUnidadeMedida)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_UNIDADE_MEDIDA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLUnidadeMedida.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@UNM_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@UNM_C_CODIGO"].Value = pobjMLUnidadeMedida.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLUnidadeMedida.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@UNM_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@UNM_C_DESCRICAO"].Value = pobjMLUnidadeMedida.Descricao;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLUnidadeMedida">UnidadeMedida para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Inserir(MLUnidadeMedida pobjMLUnidadeMedida)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_UNIDADE_MEDIDA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLUnidadeMedida.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@UNM_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@UNM_C_CODIGO"].Value = pobjMLUnidadeMedida.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLUnidadeMedida.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@UNM_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@UNM_C_DESCRICAO"].Value = pobjMLUnidadeMedida.Descricao;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion
    }
}


