using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para Subgrupo 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class DLSubgrupo : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.0]</user> 
        public DLSubgrupo()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLSubgrupo">Parametros para filtro</param>
        /// <returns>Lista de Subgrupo</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLSubgrupo> Listar(MLSubgrupo pobjMLSubgrupo, bool bProdutoAtivo, bool? bProdutoVisivel)
        {

            List<MLSubgrupo> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_SUBGRUPO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLSubgrupo.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@SUB_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@SUB_C_CODIGO"].Value = pobjMLSubgrupo.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLSubgrupo.CodigoGrupo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@SUB_GRU_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@SUB_GRU_C_CODIGO"].Value = pobjMLSubgrupo.CodigoGrupo;
            }
            if (!string.IsNullOrEmpty(pobjMLSubgrupo.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@SUB_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@SUB_C_DESCRICAO"].Value = pobjMLSubgrupo.Descricao;
            }
            if (pobjMLSubgrupo.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@SUB_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@SUB_B_ATIVO"].Value = pobjMLSubgrupo.IsAtivo.Value;
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
                MLSubgrupo objRetorno = null;
                lstRetorno = new List<MLSubgrupo>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLSubgrupo();
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
        /// <returns>Subgrupo</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLSubgrupo Obter(string pstrCodigo)
        {

            MLSubgrupo objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_SUBGRUPO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@SUB_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@SUB_C_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_SUB_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_SUB_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_SUB_GRU_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_SUB_GRU_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_SUB_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_SUB_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_SUB_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_SUB_B_ATIVO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_SUB_C_CODIGO") && cmdCommand.Parameters["@OUT_SUB_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLSubgrupo();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_SUB_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_SUB_GRU_C_CODIGO") && cmdCommand.Parameters["@OUT_SUB_GRU_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoGrupo = cmdCommand.Parameters["@OUT_SUB_GRU_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_SUB_C_DESCRICAO") && cmdCommand.Parameters["@OUT_SUB_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_SUB_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_SUB_B_ATIVO") && cmdCommand.Parameters["@OUT_SUB_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_SUB_B_ATIVO"].Value);
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

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_SUBGRUPO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@SUB_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@SUB_C_CODIGO"].Value = pstrCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLSubgrupo">Subgrupo para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLSubgrupo pobjMLSubgrupo)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_SUBGRUPO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLSubgrupo.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@SUB_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@SUB_C_CODIGO"].Value = pobjMLSubgrupo.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLSubgrupo.CodigoGrupo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@SUB_GRU_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@SUB_GRU_C_CODIGO"].Value = pobjMLSubgrupo.CodigoGrupo;
            }
            if (!string.IsNullOrEmpty(pobjMLSubgrupo.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@SUB_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@SUB_C_DESCRICAO"].Value = pobjMLSubgrupo.Descricao;
            }
            if (pobjMLSubgrupo.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@SUB_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@SUB_B_ATIVO"].Value = pobjMLSubgrupo.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLSubgrupo">Subgrupo para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Inserir(MLSubgrupo pobjMLSubgrupo)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_SUBGRUPO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLSubgrupo.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@SUB_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@SUB_C_CODIGO"].Value = pobjMLSubgrupo.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLSubgrupo.CodigoGrupo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@SUB_GRU_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@SUB_GRU_C_CODIGO"].Value = pobjMLSubgrupo.CodigoGrupo;
            }
            if (!string.IsNullOrEmpty(pobjMLSubgrupo.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@SUB_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@SUB_C_DESCRICAO"].Value = pobjMLSubgrupo.Descricao;
            }
            if (pobjMLSubgrupo.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@SUB_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@SUB_B_ATIVO"].Value = pobjMLSubgrupo.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion
    }
}


