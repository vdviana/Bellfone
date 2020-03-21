using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para Banner 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class DLBanner : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.0]</user> 
        public DLBanner()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLBanner">Parametros para filtro</param>
        /// <returns>Lista de Banner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLBanner> Listar(MLBanner pobjMLBanner)
        {

            List<MLBanner> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_BANNER");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLBanner.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@BAN_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@BAN_N_CODIGO"].Value = pobjMLBanner.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLBanner.Titulo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@BAN_C_TITULO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@BAN_C_TITULO"].Value = pobjMLBanner.Titulo;
            }
            if (!string.IsNullOrEmpty(pobjMLBanner.Ext))
            {
                cmdCommand.Parameters.Add(new FWParameter("@BAN_C_EXT", FWDbType.Varchar, 4));
                cmdCommand.Parameters["@BAN_C_EXT"].Value = pobjMLBanner.Ext;
            }
            if (!string.IsNullOrEmpty(pobjMLBanner.Link))
            {
                cmdCommand.Parameters.Add(new FWParameter("@BAN_C_LINK", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@BAN_C_LINK"].Value = pobjMLBanner.Link;
            }
            if (pobjMLBanner.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@BAN_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@BAN_B_STATUS"].Value = pobjMLBanner.IsStatus.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLBanner objRetorno = null;
                lstRetorno = new List<MLBanner>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLBanner();
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

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLBanner">Parametros para filtro</param>
        /// <returns>Lista de Banner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLBanner> ListarAleatorio()
        {

            List<MLBanner> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_BANNER_ALEATORIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            
            IDataReader idrRetorno = null;
            try
            {
                MLBanner objRetorno = null;
                lstRetorno = new List<MLBanner>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLBanner();
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
        /// <returns>Banner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLBanner Obter(decimal pdecCodigo)
        {

            MLBanner objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_BANNER");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@BAN_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@BAN_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_BAN_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_BAN_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_BAN_C_TITULO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_BAN_C_TITULO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_BAN_C_EXT", FWDbType.Varchar, 4));
            cmdCommand.Parameters["@OUT_BAN_C_EXT"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_BAN_C_LINK", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_BAN_C_LINK"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_BAN_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_BAN_B_STATUS"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_BAN_N_CODIGO") && cmdCommand.Parameters["@OUT_BAN_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLBanner();

                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_BAN_N_CODIGO"].Value);
                    if (cmdCommand.Parameters.Contains("@OUT_BAN_C_TITULO") && cmdCommand.Parameters["@OUT_BAN_C_TITULO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Titulo = cmdCommand.Parameters["@OUT_BAN_C_TITULO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_BAN_C_EXT") && cmdCommand.Parameters["@OUT_BAN_C_EXT"].Value != System.DBNull.Value)
                    {
                        objRetorno.Ext = cmdCommand.Parameters["@OUT_BAN_C_EXT"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_BAN_C_LINK") && cmdCommand.Parameters["@OUT_BAN_C_LINK"].Value != System.DBNull.Value)
                    {
                        objRetorno.Link = cmdCommand.Parameters["@OUT_BAN_C_LINK"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_BAN_B_STATUS") && cmdCommand.Parameters["@OUT_BAN_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatus = Convert.ToBoolean(cmdCommand.Parameters["@OUT_BAN_B_STATUS"].Value);
                    }

                }
            }
            catch
            {
                throw;
            }
            return objRetorno;
        }

        /// <summary> 
        /// Executa a stored procedure para retornar um registro aleatorio
        /// </summary>         
        /// <returns>Banner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLBanner ObterAleatorio()
        {

            MLBanner objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_BANNER_ALEATORIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;            
            cmdCommand.Parameters.Add(new FWParameter("@OUT_BAN_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_BAN_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_BAN_C_TITULO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_BAN_C_TITULO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_BAN_C_EXT", FWDbType.Varchar, 4));
            cmdCommand.Parameters["@OUT_BAN_C_EXT"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_BAN_C_LINK", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_BAN_C_LINK"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_BAN_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_BAN_B_STATUS"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_BAN_N_CODIGO") && cmdCommand.Parameters["@OUT_BAN_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLBanner();

                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_BAN_N_CODIGO"].Value);
                    if (cmdCommand.Parameters.Contains("@OUT_BAN_C_TITULO") && cmdCommand.Parameters["@OUT_BAN_C_TITULO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Titulo = cmdCommand.Parameters["@OUT_BAN_C_TITULO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_BAN_C_EXT") && cmdCommand.Parameters["@OUT_BAN_C_EXT"].Value != System.DBNull.Value)
                    {
                        objRetorno.Ext = cmdCommand.Parameters["@OUT_BAN_C_EXT"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_BAN_C_LINK") && cmdCommand.Parameters["@OUT_BAN_C_LINK"].Value != System.DBNull.Value)
                    {
                        objRetorno.Link = cmdCommand.Parameters["@OUT_BAN_C_LINK"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_BAN_B_STATUS") && cmdCommand.Parameters["@OUT_BAN_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatus = Convert.ToBoolean(cmdCommand.Parameters["@OUT_BAN_B_STATUS"].Value);
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
        /// <returns>Quantidade de Registro Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Excluir(decimal pdecCodigo)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_BANNER");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@BAN_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@BAN_N_CODIGO"].Value = pdecCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLBanner">Banner para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLBanner pobjMLBanner)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_BANNER");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLBanner.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@BAN_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@BAN_N_CODIGO"].Value = pobjMLBanner.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLBanner.Titulo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@BAN_C_TITULO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@BAN_C_TITULO"].Value = pobjMLBanner.Titulo;
            }
            if (!string.IsNullOrEmpty(pobjMLBanner.Ext))
            {
                cmdCommand.Parameters.Add(new FWParameter("@BAN_C_EXT", FWDbType.Varchar, 4));
                cmdCommand.Parameters["@BAN_C_EXT"].Value = pobjMLBanner.Ext;
            }
            if (!string.IsNullOrEmpty(pobjMLBanner.Link))
            {
                cmdCommand.Parameters.Add(new FWParameter("@BAN_C_LINK", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@BAN_C_LINK"].Value = pobjMLBanner.Link;
            }
            if (pobjMLBanner.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@BAN_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@BAN_B_STATUS"].Value = pobjMLBanner.IsStatus.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLBanner">Banner para inserir</param>
        /// <returns>Código Banner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public decimal Inserir(MLBanner pobjMLBanner)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_BANNER");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLBanner.Titulo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@BAN_C_TITULO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@BAN_C_TITULO"].Value = pobjMLBanner.Titulo;
            }
            if (!string.IsNullOrEmpty(pobjMLBanner.Ext))
            {
                cmdCommand.Parameters.Add(new FWParameter("@BAN_C_EXT", FWDbType.Varchar, 4));
                cmdCommand.Parameters["@BAN_C_EXT"].Value = pobjMLBanner.Ext;
            }
            if (!string.IsNullOrEmpty(pobjMLBanner.Link))
            {
                cmdCommand.Parameters.Add(new FWParameter("@BAN_C_LINK", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@BAN_C_LINK"].Value = pobjMLBanner.Link;
            }
            if (pobjMLBanner.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@BAN_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@BAN_B_STATUS"].Value = pobjMLBanner.IsStatus.Value;
            }

            return Convert.ToDecimal(conProvider.ExecuteScalar(cmdCommand));

        }

        #endregion
    }
}


