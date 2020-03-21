using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para Grupo 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class DLGrupo : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.0]</user> 
        public DLGrupo()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLGrupo">Parametros para filtro</param>
        /// <returns>Lista de Grupo</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLGrupo> Listar(MLGrupo pobjMLGrupo, bool bProdutoAtivo, bool? bProdutoVisivel)
        {

            List<MLGrupo> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_GRUPO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLGrupo.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@GRU_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@GRU_C_CODIGO"].Value = pobjMLGrupo.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLGrupo.CodigoCategoria))
            {
                cmdCommand.Parameters.Add(new FWParameter("@GRU_CAT_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@GRU_CAT_C_CODIGO"].Value = pobjMLGrupo.CodigoCategoria;
            }
            if (!string.IsNullOrEmpty(pobjMLGrupo.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@GRU_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@GRU_C_DESCRICAO"].Value = pobjMLGrupo.Descricao;
            }
            if (pobjMLGrupo.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@GRU_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@GRU_B_ATIVO"].Value = pobjMLGrupo.IsAtivo.Value;
            }
            if (bProdutoVisivel != null)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_VISIVEL", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_VISIVEL"].Value = bProdutoVisivel;
            }

            cmdCommand.Parameters.Add(new FWParameter("@PRD_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@PRD_B_STATUS"].Value = bProdutoAtivo;

            IDataReader idrRetorno = null;
            try
            {
                MLGrupo objRetorno = null;
                lstRetorno = new List<MLGrupo>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLGrupo();
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
        /// <returns>Grupo</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLGrupo Obter(string pstrCodigo)
        {

            MLGrupo objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_GRUPO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@GRU_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@GRU_C_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_GRU_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_GRU_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_GRU_CAT_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_GRU_CAT_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_GRU_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_GRU_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_GRU_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_GRU_B_ATIVO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_GRU_C_CODIGO") && cmdCommand.Parameters["@OUT_GRU_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLGrupo();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_GRU_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_GRU_CAT_C_CODIGO") && cmdCommand.Parameters["@OUT_GRU_CAT_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoCategoria = cmdCommand.Parameters["@OUT_GRU_CAT_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_GRU_C_DESCRICAO") && cmdCommand.Parameters["@OUT_GRU_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_GRU_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_GRU_B_ATIVO") && cmdCommand.Parameters["@OUT_GRU_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_GRU_B_ATIVO"].Value);
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

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_GRUPO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@GRU_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@GRU_C_CODIGO"].Value = pstrCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLGrupo">Grupo para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLGrupo pobjMLGrupo)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_GRUPO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLGrupo.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@GRU_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@GRU_C_CODIGO"].Value = pobjMLGrupo.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLGrupo.CodigoCategoria))
            {
                cmdCommand.Parameters.Add(new FWParameter("@GRU_CAT_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@GRU_CAT_C_CODIGO"].Value = pobjMLGrupo.CodigoCategoria;
            }
            if (!string.IsNullOrEmpty(pobjMLGrupo.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@GRU_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@GRU_C_DESCRICAO"].Value = pobjMLGrupo.Descricao;
            }
            if (pobjMLGrupo.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@GRU_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@GRU_B_ATIVO"].Value = pobjMLGrupo.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLGrupo">Grupo para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Inserir(MLGrupo pobjMLGrupo)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_GRUPO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLGrupo.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@GRU_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@GRU_C_CODIGO"].Value = pobjMLGrupo.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLGrupo.CodigoCategoria))
            {
                cmdCommand.Parameters.Add(new FWParameter("@GRU_CAT_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@GRU_CAT_C_CODIGO"].Value = pobjMLGrupo.CodigoCategoria;
            }
            if (!string.IsNullOrEmpty(pobjMLGrupo.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@GRU_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@GRU_C_DESCRICAO"].Value = pobjMLGrupo.Descricao;
            }
            if (pobjMLGrupo.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@GRU_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@GRU_B_ATIVO"].Value = pobjMLGrupo.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion
    }
}



