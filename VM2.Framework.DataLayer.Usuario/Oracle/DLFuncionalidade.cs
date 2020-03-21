using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model.Usuario;

namespace VM2.Framework.DataLayer.Usuario.Oracle
{
    /// <summary> 
    /// Classe de conexão de dados para Funcionalidade 
    /// </summary> 
    /// <user>mazevedo</user> 
    public class DLFuncionalidade : DLFWBase, IDLFuncionalidade
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>mazevedo</user> 
        public DLFuncionalidade()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }

        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLFuncionalidade">Parametros para filtro</param>
        /// <returns>Lista de Funcionalidade</returns> 
        /// <user>mazevedo</user>
        public List<MLFuncionalidade> Listar(MLFuncionalidade pobjMLFuncionalidade)
        {

            List<MLFuncionalidade> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWK_L_FUNCIONALIDADE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLFuncionalidade.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("FUN_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["FUN_N_CODIGO"].Value = pobjMLFuncionalidade.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLFuncionalidade.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("FUN_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["FUN_C_NOME"].Value = pobjMLFuncionalidade.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLFuncionalidade.CaminhoPagina))
            {
                cmdCommand.Parameters.Add(new FWParameter("FUN_C_CAMINHO_PAGINA", FWDbType.Varchar, 300));
                cmdCommand.Parameters["FUN_C_CAMINHO_PAGINA"].Value = pobjMLFuncionalidade.CaminhoPagina;
            }
            if (pobjMLFuncionalidade.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("FUN_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["FUN_B_STATUS"].Value = pobjMLFuncionalidade.IsAtivo.Value;
            }
            if (pobjMLFuncionalidade.IsFramework.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("FUN_B_FRAMEWORK", FWDbType.Boolean));
                cmdCommand.Parameters["FUN_B_FRAMEWORK"].Value = pobjMLFuncionalidade.IsFramework.Value;
            }


            // Retorno do Curso
            cmdCommand.Parameters.Add(new FWParameter("RCT1", FWDbType.Cursor));
            cmdCommand.Parameters["RCT1"].Direction = ParameterDirection.Output;

            IDataReader idrRetorno = null;
            try
            {
                MLFuncionalidade objRetorno = null;
                lstRetorno = new List<MLFuncionalidade>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLFuncionalidade();
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
        /// <param name="pdecCodigo">Código da Funcionalidade</param>
        /// <returns>Funcionalidade</returns> 
        /// <user>mazevedo</user>
        public MLFuncionalidade Obter(decimal pdecCodigo)
        {

            MLFuncionalidade objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWK_S_FUNCIONALIDADE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("FUN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["FUN_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("OUT_FUN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["OUT_FUN_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_FUN_C_NOME", FWDbType.Varchar, 50));
            cmdCommand.Parameters["OUT_FUN_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_FUN_C_CAMINHO_PAGINA", FWDbType.Varchar, 300));
            cmdCommand.Parameters["OUT_FUN_C_CAMINHO_PAGINA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_FUN_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["OUT_FUN_B_STATUS"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_FUN_B_FRAMEWORK", FWDbType.Boolean));
            cmdCommand.Parameters["OUT_FUN_B_FRAMEWORK"].Direction = ParameterDirection.Output;

            try
            {
                objRetorno = new MLFuncionalidade();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["OUT_FUN_N_CODIGO"] != null) && cmdCommand.Parameters["OUT_FUN_N_CODIGO"].Value != null && cmdCommand.Parameters["OUT_FUN_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["OUT_FUN_N_CODIGO"].Value);
                    if ((cmdCommand.Parameters["OUT_FUN_C_NOME"] != null) && cmdCommand.Parameters["OUT_FUN_C_NOME"].Value != null && cmdCommand.Parameters["OUT_FUN_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.Nome = cmdCommand.Parameters["OUT_FUN_C_NOME"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["OUT_FUN_C_CAMINHO_PAGINA"] != null) && cmdCommand.Parameters["OUT_FUN_C_CAMINHO_PAGINA"].Value != null && cmdCommand.Parameters["OUT_FUN_C_CAMINHO_PAGINA"].Value != System.DBNull.Value)
                    {
                        objRetorno.CaminhoPagina = cmdCommand.Parameters["OUT_FUN_C_CAMINHO_PAGINA"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["OUT_FUN_B_STATUS"] != null) && cmdCommand.Parameters["OUT_FUN_B_STATUS"].Value != null && cmdCommand.Parameters["OUT_FUN_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["OUT_FUN_B_STATUS"].Value);
                    }

                    if ((cmdCommand.Parameters["OUT_FUN_B_FRAMEWORK"] != null) && cmdCommand.Parameters["OUT_FUN_B_FRAMEWORK"].Value != null && cmdCommand.Parameters["OUT_FUN_B_FRAMEWORK"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsFramework = Convert.ToBoolean(cmdCommand.Parameters["OUT_FUN_B_FRAMEWORK"].Value);
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
        /// <param name="pdecCodigo">Código da Funcionalidade</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>mazevedo</user>
        public bool Excluir(decimal pdecCodigo)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWK_D_FUNCIONALIDADE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("FUN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["FUN_N_CODIGO"].Value = pdecCodigo;

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
        /// <param name="pobjMLFuncionalidade">Funcionalidade para alterar</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>mazevedo</user>
        public bool Alterar(MLFuncionalidade pobjMLFuncionalidade)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWK_U_FUNCIONALIDADE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLFuncionalidade.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("FUN_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["FUN_N_CODIGO"].Value = pobjMLFuncionalidade.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLFuncionalidade.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("FUN_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["FUN_C_NOME"].Value = pobjMLFuncionalidade.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLFuncionalidade.CaminhoPagina))
            {
                cmdCommand.Parameters.Add(new FWParameter("FUN_C_CAMINHO_PAGINA", FWDbType.Varchar, 300));
                cmdCommand.Parameters["FUN_C_CAMINHO_PAGINA"].Value = pobjMLFuncionalidade.CaminhoPagina;
            }
            if (pobjMLFuncionalidade.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("FUN_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["FUN_B_STATUS"].Value = pobjMLFuncionalidade.IsAtivo.Value;
            }
            if (pobjMLFuncionalidade.IsFramework.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("FUN_B_FRAMEWORK", FWDbType.Boolean));
                cmdCommand.Parameters["FUN_B_FRAMEWORK"].Value = pobjMLFuncionalidade.IsFramework.Value;
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
        /// <param name="pobjMLFuncionalidade">Funcionalidade para inserir</param>
        /// <returns>Código Funcionalidade</returns> 
        /// <user>mazevedo</user>
        public int Inserir(MLFuncionalidade pobjMLFuncionalidade)
        {

            int intRetorno = 0;
            FWCommand cmdCommand = new FWCommand("USP_FWK_I_FUNCIONALIDADE");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLFuncionalidade.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("FUN_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["FUN_C_NOME"].Value = pobjMLFuncionalidade.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLFuncionalidade.CaminhoPagina))
            {
                cmdCommand.Parameters.Add(new FWParameter("FUN_C_CAMINHO_PAGINA", FWDbType.Varchar, 300));
                cmdCommand.Parameters["FUN_C_CAMINHO_PAGINA"].Value = pobjMLFuncionalidade.CaminhoPagina;
            }
            if (pobjMLFuncionalidade.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("FUN_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["FUN_B_STATUS"].Value = pobjMLFuncionalidade.IsAtivo.Value;
            }
            if (pobjMLFuncionalidade.IsFramework.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("FUN_B_FRAMEWORK", FWDbType.Boolean));
                cmdCommand.Parameters["FUN_B_FRAMEWORK"].Value = pobjMLFuncionalidade.IsFramework.Value;
            }

            cmdCommand.Parameters.Add(new FWParameter("FUN_N_CODIGO", FWDbType.Int32));
            cmdCommand.Parameters["FUN_N_CODIGO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters["FUN_N_CODIGO"] != null)
                    intRetorno = Convert.ToInt32(cmdCommand.Parameters["FUN_N_CODIGO"].Value);

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


