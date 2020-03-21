using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.Model.Noticia;
using VM2.Framework.DataLayer.Noticia;

namespace VM2.Framework.DataLayer.Noticia.Sql
{
    /// <summary> 
    /// Classe de conexão de dados para NoticiaCategoria 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLNoticiaCategoria : DLFWBase, IDLNoticiaCategoria
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2</user> 
        public DLNoticiaCategoria()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLNoticiaCategoria">Parametros para filtro</param>
        /// <returns>Lista de NoticiaCategoria</returns> 
        /// <user>GeradorVm2</user>
        public List<MLNoticiaCategoria> Listar(MLNoticiaCategoria pobjMLNoticiaCategoria)
        {

            List<MLNoticiaCategoria> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWC_L_NOTICIA_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLNoticiaCategoria.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NTC_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@NTC_N_CODIGO"].Value = pobjMLNoticiaCategoria.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticiaCategoria.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NTC_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@NTC_C_DESCRICAO"].Value = pobjMLNoticiaCategoria.Descricao;
            }
            if (pobjMLNoticiaCategoria.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NTC_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@NTC_B_ATIVO"].Value = pobjMLNoticiaCategoria.IsAtivo;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLNoticiaCategoria objRetorno = null;
                lstRetorno = new List<MLNoticiaCategoria>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLNoticiaCategoria();
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
        /// <returns>NoticiaCategoria</returns> 
        /// <user>GeradorVm2</user>
        public MLNoticiaCategoria Obter(decimal pdecCodigo)
        {

            MLNoticiaCategoria objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWC_S_NOTICIA_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@NTC_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@NTC_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_NTC_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_NTC_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_NTC_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_NTC_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_NTC_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_NTC_B_ATIVO"].Direction = ParameterDirection.Output;

            try
            {
                objRetorno = new MLNoticiaCategoria();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["@OUT_NTC_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_NTC_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_NTC_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_NTC_N_CODIGO"].Value);
                    if ((cmdCommand.Parameters["@OUT_NTC_C_DESCRICAO"] != null) && cmdCommand.Parameters["@OUT_NTC_C_DESCRICAO"].Value != null && cmdCommand.Parameters["@OUT_NTC_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_NTC_C_DESCRICAO"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_NTC_B_ATIVO"] != null) && cmdCommand.Parameters["@OUT_NTC_B_ATIVO"].Value != null && cmdCommand.Parameters["@OUT_NTC_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_NTC_B_ATIVO"].Value);
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
            FWCommand cmdCommand = new FWCommand("USP_FWC_D_NOTICIA_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@NTC_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@NTC_N_CODIGO"].Value = pdecCodigo;

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
        /// <param name="pobjMLNoticiaCategoria">NoticiaCategoria para alterar</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLNoticiaCategoria pobjMLNoticiaCategoria)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_U_NOTICIA_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLNoticiaCategoria.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NTC_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@NTC_N_CODIGO"].Value = pobjMLNoticiaCategoria.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticiaCategoria.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NTC_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@NTC_C_DESCRICAO"].Value = pobjMLNoticiaCategoria.Descricao;
            }
            if (pobjMLNoticiaCategoria.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NTC_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@NTC_B_ATIVO"].Value = pobjMLNoticiaCategoria.IsAtivo.Value;
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
        /// <param name="pobjMLNoticiaCategoria">NoticiaCategoria para inserir</param>
        /// <returns>Código NoticiaCategoria</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLNoticiaCategoria pobjMLNoticiaCategoria)
        {

            int intRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_I_NOTICIA_CATEGORIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLNoticiaCategoria.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NTC_C_DESCRICAO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@NTC_C_DESCRICAO"].Value = pobjMLNoticiaCategoria.Descricao;
            }
            if (pobjMLNoticiaCategoria.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NTC_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@NTC_B_ATIVO"].Value = pobjMLNoticiaCategoria.IsAtivo.Value;
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


