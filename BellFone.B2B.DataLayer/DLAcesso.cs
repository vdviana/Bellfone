using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para Acesso 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class DLAcesso : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.1]</user> 
        public DLAcesso()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }
        
        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLAcesso">Parametros para filtro</param>
        /// <returns>Lista de Acesso</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLAcesso> Listar(MLAcesso pobjMLAcesso)
        {

            List<MLAcesso> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ACESSO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLAcesso.CodigoUsuario.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ACC_USU_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ACC_USU_N_CODIGO"].Value = pobjMLAcesso.CodigoUsuario.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLAcesso.CodigoProduto))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ACC_PRD_N_CODIGO", FWDbType.Varchar, 13));
                cmdCommand.Parameters["@ACC_PRD_N_CODIGO"].Value = pobjMLAcesso.CodigoProduto;
            }
            if (pobjMLAcesso.Data.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ACC_D_DATA", FWDbType.DateTime));
                cmdCommand.Parameters["@ACC_D_DATA"].Value = pobjMLAcesso.Data.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLAcesso objRetorno = null;
                lstRetorno = new List<MLAcesso>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLAcesso();
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

        public List<MLAcesso> ListarRelatorio(MLAcesso pobjMLAcesso)
        {

            List<MLAcesso> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ACESSOS");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            IDataReader idrRetorno = null;
            try
            {
                MLAcesso objRetorno = null;
                lstRetorno = new List<MLAcesso>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLAcesso();
                    objRetorno.FromIDataReaderRel(idrRetorno);
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

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLAcesso">Acesso para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Inserir(MLAcesso pobjMLAcesso)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_ACESSO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLAcesso.CodigoUsuario.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ACC_USU_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ACC_USU_N_CODIGO"].Value = pobjMLAcesso.CodigoUsuario.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLAcesso.CodigoProduto))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ACC_PRD_N_CODIGO", FWDbType.Varchar, 13));
                cmdCommand.Parameters["@ACC_PRD_N_CODIGO"].Value = pobjMLAcesso.CodigoProduto;
            }
            if (pobjMLAcesso.Data.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ACC_D_DATA", FWDbType.DateTime));
                cmdCommand.Parameters["@ACC_D_DATA"].Value = pobjMLAcesso.Data.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion
    }
}


