using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.Model.Enquete;

namespace VM2.Framework.DataLayer.Enquete.Sql
{
    /// <summary> 
    /// Classe de conexão de dados para Enquete 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLEnquete : DLFWBase, VM2.Framework.DataLayer.Enquete.Sql.IDLEnquete 
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2</user> 
        public DLEnquete()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLEnquete">Parametros para filtro</param>
        /// <returns>Lista de Enquete</returns> 
        /// <user>GeradorVm2</user>
        public List<MLEnquete> Listar(MLEnquete pobjMLEnquete)
        {

            List<MLEnquete> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWC_L_ENQUETE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLEnquete.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@ENQ_N_CODIGO"].Value = pobjMLEnquete.Codigo.Value;
            }
            if (pobjMLEnquete.CodigoIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@ENQ_IDI_N_CODIGO"].Value = pobjMLEnquete.CodigoIdioma.Value;
            }
            if (pobjMLEnquete.Inicio.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_D_INICIO", FWDbType.DateTime));
                cmdCommand.Parameters["@ENQ_D_INICIO"].Value = pobjMLEnquete.Inicio.Value;
            }
            if (pobjMLEnquete.Termino.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_D_TERMINO", FWDbType.DateTime));
                cmdCommand.Parameters["@ENQ_D_TERMINO"].Value = pobjMLEnquete.Termino.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLEnquete.Titulo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_C_TITULO", FWDbType.Varchar, 300));
                cmdCommand.Parameters["@ENQ_C_TITULO"].Value = pobjMLEnquete.Titulo;
            }
            if (pobjMLEnquete.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@ENQ_B_STATUS"].Value = pobjMLEnquete.IsStatus.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLEnquete objRetorno = null;
                lstRetorno = new List<MLEnquete>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLEnquete();
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
        /// <returns>Enquete</returns> 
        /// <user>GeradorVm2</user>
        public MLEnquete Obter(decimal pdecCodigo)
        {

            MLEnquete objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWC_S_ENQUETE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@ENQ_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@ENQ_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ENQ_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_ENQ_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ENQ_IDI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_ENQ_IDI_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ENQ_D_INICIO", FWDbType.DateTime));
            cmdCommand.Parameters["@OUT_ENQ_D_INICIO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ENQ_D_TERMINO", FWDbType.DateTime));
            cmdCommand.Parameters["@OUT_ENQ_D_TERMINO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ENQ_C_TITULO", FWDbType.Varchar, 300));
            cmdCommand.Parameters["@OUT_ENQ_C_TITULO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ENQ_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_ENQ_B_STATUS"].Direction = ParameterDirection.Output;

            try
            {
                objRetorno = new MLEnquete();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["@OUT_ENQ_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_ENQ_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_ENQ_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_ENQ_N_CODIGO"].Value);
                    if ((cmdCommand.Parameters["@OUT_ENQ_IDI_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_ENQ_IDI_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_ENQ_IDI_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoIdioma = Convert.ToDecimal(cmdCommand.Parameters["@OUT_ENQ_IDI_N_CODIGO"].Value);
                    }

                    if ((cmdCommand.Parameters["@OUT_ENQ_D_INICIO"] != null) && cmdCommand.Parameters["@OUT_ENQ_D_INICIO"].Value != null && cmdCommand.Parameters["@OUT_ENQ_D_INICIO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Inicio = Convert.ToDateTime(cmdCommand.Parameters["@OUT_ENQ_D_INICIO"].Value);
                    }

                    if ((cmdCommand.Parameters["@OUT_ENQ_D_TERMINO"] != null) && cmdCommand.Parameters["@OUT_ENQ_D_TERMINO"].Value != null && cmdCommand.Parameters["@OUT_ENQ_D_TERMINO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Termino = Convert.ToDateTime(cmdCommand.Parameters["@OUT_ENQ_D_TERMINO"].Value);
                    }

                    if ((cmdCommand.Parameters["@OUT_ENQ_C_TITULO"] != null) && cmdCommand.Parameters["@OUT_ENQ_C_TITULO"].Value != null && cmdCommand.Parameters["@OUT_ENQ_C_TITULO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Titulo = cmdCommand.Parameters["@OUT_ENQ_C_TITULO"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_ENQ_B_STATUS"] != null) && cmdCommand.Parameters["@OUT_ENQ_B_STATUS"].Value != null && cmdCommand.Parameters["@OUT_ENQ_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatus = Convert.ToBoolean(cmdCommand.Parameters["@OUT_ENQ_B_STATUS"].Value);
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
            FWCommand cmdCommand = new FWCommand("USP_FWC_D_ENQUETE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@ENQ_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@ENQ_N_CODIGO"].Value = pdecCodigo;

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
        /// <param name="pobjMLEnquete">Enquete para alterar</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLEnquete pobjMLEnquete)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_U_ENQUETE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLEnquete.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@ENQ_N_CODIGO"].Value = pobjMLEnquete.Codigo.Value;
            }
            if (pobjMLEnquete.CodigoIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@ENQ_IDI_N_CODIGO"].Value = pobjMLEnquete.CodigoIdioma.Value;
            }
            if (pobjMLEnquete.Inicio.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_D_INICIO", FWDbType.DateTime));
                cmdCommand.Parameters["@ENQ_D_INICIO"].Value = pobjMLEnquete.Inicio.Value;
            }
            if (pobjMLEnquete.Termino.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_D_TERMINO", FWDbType.DateTime));
                cmdCommand.Parameters["@ENQ_D_TERMINO"].Value = pobjMLEnquete.Termino.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLEnquete.Titulo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_C_TITULO", FWDbType.Varchar, 300));
                cmdCommand.Parameters["@ENQ_C_TITULO"].Value = pobjMLEnquete.Titulo;
            }
            if (pobjMLEnquete.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@ENQ_B_STATUS"].Value = pobjMLEnquete.IsStatus.Value;
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
        /// <param name="pobjMLEnquete">Enquete para inserir</param>
        /// <returns>Código Enquete</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLEnquete pobjMLEnquete)
        {

            int intRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_I_ENQUETE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLEnquete.CodigoIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@ENQ_IDI_N_CODIGO"].Value = pobjMLEnquete.CodigoIdioma.Value;
            }
            if (pobjMLEnquete.Inicio.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_D_INICIO", FWDbType.DateTime));
                cmdCommand.Parameters["@ENQ_D_INICIO"].Value = pobjMLEnquete.Inicio.Value;
            }
            if (pobjMLEnquete.Termino.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_D_TERMINO", FWDbType.DateTime));
                cmdCommand.Parameters["@ENQ_D_TERMINO"].Value = pobjMLEnquete.Termino.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLEnquete.Titulo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_C_TITULO", FWDbType.Varchar, 300));
                cmdCommand.Parameters["@ENQ_C_TITULO"].Value = pobjMLEnquete.Titulo;
            }
            if (pobjMLEnquete.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ENQ_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@ENQ_B_STATUS"].Value = pobjMLEnquete.IsStatus.Value;
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


