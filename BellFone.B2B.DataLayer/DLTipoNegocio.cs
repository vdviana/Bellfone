using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para TipoNegocio 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class DLTipoNegocio : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.1]</user> 
        public DLTipoNegocio()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLTipoNegocio">Parametros para filtro</param>
        /// <returns>Lista de TipoNegocio</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLTipoNegocio> Listar(MLTipoNegocio pobjMLTipoNegocio)
        {

            List<MLTipoNegocio> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_TIPO_NEGOCIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLTipoNegocio.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@TPN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@TPN_C_CODIGO"].Value = pobjMLTipoNegocio.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLTipoNegocio.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@TPN_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@TPN_C_DESCRICAO"].Value = pobjMLTipoNegocio.Descricao;
            }
            if (pobjMLTipoNegocio.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@TPN_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@TPN_B_STATUS"].Value = pobjMLTipoNegocio.IsStatus.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLTipoNegocio objRetorno = null;
                lstRetorno = new List<MLTipoNegocio>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLTipoNegocio();
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
        /// <returns>TipoNegocio</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLTipoNegocio Obter(string pstrCodigo)
        {

            MLTipoNegocio objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_TIPO_NEGOCIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@TPN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@TPN_C_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_TPN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_TPN_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_TPN_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_TPN_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_TPN_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_TPN_B_STATUS"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_TPN_C_CODIGO") && cmdCommand.Parameters["@OUT_TPN_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLTipoNegocio();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_TPN_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_TPN_C_DESCRICAO") && cmdCommand.Parameters["@OUT_TPN_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_TPN_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_TPN_B_STATUS") && cmdCommand.Parameters["@OUT_TPN_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatus = Convert.ToBoolean(cmdCommand.Parameters["@OUT_TPN_B_STATUS"].Value);
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

        #region ObterUltimo

        /// <summary> 
        /// Executa a stored procedure para retornar um registro específico
        /// </summary> 
        /// <param name="descricao">Codigo</param>
        /// <returns>TipoNegocio</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLTipoNegocio ObterUltimo(string descricao)
        {

            MLTipoNegocio objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_TIPO_NEGOCIO_ULTIMO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@TPN_C_DESC", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@TPN_C_DESC"].Value = descricao;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_TPN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_TPN_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_TPN_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_TPN_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_TPN_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_TPN_B_STATUS"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_TPN_C_CODIGO") && cmdCommand.Parameters["@OUT_TPN_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLTipoNegocio();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_TPN_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_TPN_C_DESCRICAO") && cmdCommand.Parameters["@OUT_TPN_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_TPN_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_TPN_B_STATUS") && cmdCommand.Parameters["@OUT_TPN_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatus = Convert.ToBoolean(cmdCommand.Parameters["@OUT_TPN_B_STATUS"].Value);
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

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_TIPO_NEGOCIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@TPN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@TPN_C_CODIGO"].Value = pstrCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLTipoNegocio">TipoNegocio para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLTipoNegocio pobjMLTipoNegocio)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_TIPO_NEGOCIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLTipoNegocio.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@TPN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@TPN_C_CODIGO"].Value = pobjMLTipoNegocio.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLTipoNegocio.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@TPN_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@TPN_C_DESCRICAO"].Value = pobjMLTipoNegocio.Descricao;
            }
            if (pobjMLTipoNegocio.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@TPN_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@TPN_B_STATUS"].Value = pobjMLTipoNegocio.IsStatus.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLTipoNegocio">TipoNegocio para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Inserir(MLTipoNegocio pobjMLTipoNegocio)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_TIPO_NEGOCIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLTipoNegocio.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@TPN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@TPN_C_CODIGO"].Value = pobjMLTipoNegocio.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLTipoNegocio.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@TPN_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@TPN_C_DESCRICAO"].Value = pobjMLTipoNegocio.Descricao;
            }
            if (pobjMLTipoNegocio.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@TPN_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@TPN_B_STATUS"].Value = pobjMLTipoNegocio.IsStatus.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion
    }
}


