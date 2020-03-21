using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para PermissaoAtendimento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class DLPermissaoAtendimento : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.0]</user> 
        public DLPermissaoAtendimento()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLPermissaoAtendimento">Parametros para filtro</param>
        /// <returns>Lista de PermissaoAtendimento</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLPermissaoAtendimento> Listar(MLPermissaoAtendimento pobjMLPermissaoAtendimento)
        {

            List<MLPermissaoAtendimento> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_PERMISSAO_ATENDIMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLPermissaoAtendimento.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PAT_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@PAT_N_CODIGO"].Value = pobjMLPermissaoAtendimento.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLPermissaoAtendimento.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PAT_REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@PAT_REV_C_CODIGO"].Value = pobjMLPermissaoAtendimento.CodigoRevendedor;
            }
            if (pobjMLPermissaoAtendimento.Atdcodigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PAT_ATD_N_CODIGO", FWDbType.Int32));
                cmdCommand.Parameters["@PAT_ATD_N_CODIGO"].Value = pobjMLPermissaoAtendimento.Atdcodigo.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLPermissaoAtendimento objRetorno = null;
                lstRetorno = new List<MLPermissaoAtendimento>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLPermissaoAtendimento();
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
        /// <returns>PermissaoAtendimento</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLPermissaoAtendimento Obter(decimal pdecCodigo)
        {

            MLPermissaoAtendimento objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_PERMISSAO_ATENDIMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@PAT_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@PAT_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PAT_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_PAT_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PAT_REV_C_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_PAT_REV_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PAT_ATD_N_CODIGO", FWDbType.Int32));
            cmdCommand.Parameters["@OUT_PAT_ATD_N_CODIGO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_PAT_N_CODIGO") && cmdCommand.Parameters["@OUT_PAT_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLPermissaoAtendimento();

                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_PAT_N_CODIGO"].Value);
                    if (cmdCommand.Parameters.Contains("@OUT_PAT_REV_C_CODIGO") && cmdCommand.Parameters["@OUT_PAT_REV_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoRevendedor = cmdCommand.Parameters["@OUT_PAT_REV_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PAT_ATD_N_CODIGO") && cmdCommand.Parameters["@OUT_PAT_ATD_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Atdcodigo = Convert.ToInt32(cmdCommand.Parameters["@OUT_PAT_ATD_N_CODIGO"].Value);
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

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_PERMISSAO_ATENDIMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@PAT_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@PAT_N_CODIGO"].Value = pdecCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLPermissaoAtendimento">PermissaoAtendimento para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLPermissaoAtendimento pobjMLPermissaoAtendimento)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_PERMISSAO_ATENDIMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLPermissaoAtendimento.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PAT_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@PAT_N_CODIGO"].Value = pobjMLPermissaoAtendimento.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLPermissaoAtendimento.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PAT_REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@PAT_REV_C_CODIGO"].Value = pobjMLPermissaoAtendimento.CodigoRevendedor;
            }
            if (pobjMLPermissaoAtendimento.Atdcodigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PAT_ATD_N_CODIGO", FWDbType.Int32));
                cmdCommand.Parameters["@PAT_ATD_N_CODIGO"].Value = pobjMLPermissaoAtendimento.Atdcodigo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLPermissaoAtendimento">PermissaoAtendimento para inserir</param>
        /// <returns>Código PermissaoAtendimento</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public decimal Inserir(MLPermissaoAtendimento pobjMLPermissaoAtendimento)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_PERMISSAO_ATENDIMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLPermissaoAtendimento.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PAT_REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@PAT_REV_C_CODIGO"].Value = pobjMLPermissaoAtendimento.CodigoRevendedor;
            }
            if (pobjMLPermissaoAtendimento.Atdcodigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PAT_ATD_N_CODIGO", FWDbType.Int32));
                cmdCommand.Parameters["@PAT_ATD_N_CODIGO"].Value = pobjMLPermissaoAtendimento.Atdcodigo.Value;
            }

            return Convert.ToDecimal(conProvider.ExecuteScalar(cmdCommand));

        }

        #endregion
    }
}


