using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model.Idioma;

namespace VM2.Framework.DataLayer.Idioma.Oracle
{
    /// <summary> 
    /// Classe de conexão de dados para Idioma 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLIdioma : DLFWBase, IDLIdioma
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>mazevedo</user> 
        public DLIdioma()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLIdioma">Parametros para filtro</param>
        /// <returns>Lista de Idioma</returns> 
        /// <user>mazevedo</user>
        public List<MLIdioma> Listar(MLIdioma pobjMLIdioma)
        {

            List<MLIdioma> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWK_L_IDIOMA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLIdioma.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["IDI_N_CODIGO"].Value = pobjMLIdioma.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLIdioma.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("IDI_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["IDI_C_NOME"].Value = pobjMLIdioma.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLIdioma.Sigla))
            {
                cmdCommand.Parameters.Add(new FWParameter("IDI_C_SIGLA", FWDbType.Varchar, 5));
                cmdCommand.Parameters["IDI_C_SIGLA"].Value = pobjMLIdioma.Sigla;
            }
            if (pobjMLIdioma.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@IDI_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@IDI_B_ATIVO"].Value = pobjMLIdioma.IsAtivo.Value;
            }

            // Retorno do Curso
            cmdCommand.Parameters.Add(new FWParameter("RCT1", FWDbType.Cursor));
            cmdCommand.Parameters["RCT1"].Direction = ParameterDirection.Output;

            IDataReader idrRetorno = null;
            try
            {
                MLIdioma objRetorno = null;
                lstRetorno = new List<MLIdioma>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLIdioma();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
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
        /// <returns>Idioma</returns> 
        /// <user>mazevedo</user>
        public MLIdioma Obter(decimal pdecCodigo)
        {
            MLIdioma objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWK_S_IDIOMA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("IDI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["IDI_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("OUT_IDI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["OUT_IDI_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_IDI_C_NOME", FWDbType.Varchar, 50));
            cmdCommand.Parameters["OUT_IDI_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_IDI_C_SIGLA", FWDbType.Varchar, 5));
            cmdCommand.Parameters["OUT_IDI_C_SIGLA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_IDI_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["OUT_IDI_B_ATIVO"].Direction = ParameterDirection.Output;

            objRetorno = new MLIdioma();

            conProvider.ExecuteNonQuery(cmdCommand);

            if ((cmdCommand.Parameters["OUT_IDI_N_CODIGO"] != null) && cmdCommand.Parameters["OUT_IDI_N_CODIGO"].Value != null && cmdCommand.Parameters["OUT_IDI_N_CODIGO"].Value != System.DBNull.Value)
            {
                objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["OUT_IDI_N_CODIGO"].Value);
                if ((cmdCommand.Parameters["OUT_IDI_C_NOME"] != null) && cmdCommand.Parameters["OUT_IDI_C_NOME"].Value != null && cmdCommand.Parameters["OUT_IDI_C_NOME"].Value != System.DBNull.Value)
                {
                    objRetorno.Nome = cmdCommand.Parameters["OUT_IDI_C_NOME"].Value.ToString();
                }

                if ((cmdCommand.Parameters["OUT_IDI_C_SIGLA"] != null) && cmdCommand.Parameters["OUT_IDI_C_SIGLA"].Value != null && cmdCommand.Parameters["OUT_IDI_C_SIGLA"].Value != System.DBNull.Value)
                {
                    objRetorno.Sigla = cmdCommand.Parameters["OUT_IDI_C_SIGLA"].Value.ToString();
                }

                if ((cmdCommand.Parameters["OUT_IDI_B_ATIVO"] != null) && cmdCommand.Parameters["OUT_IDI_B_ATIVO"].Value != null && cmdCommand.Parameters["OUT_IDI_B_ATIVO"].Value != System.DBNull.Value)
                {
                    objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["OUT_IDI_B_ATIVO"].Value);
                }

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
        /// <user>mazevedo</user>
        public bool Excluir(decimal pdecCodigo)
        {
            var cmdCommand = new FWCommand("USP_FWK_D_IDIOMA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("IDI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["IDI_N_CODIGO"].Value = pdecCodigo;

            return (conProvider.ExecuteNonQuery(cmdCommand)>0);
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLIdioma">Idioma para alterar</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>mazevedo</user>
        public bool Alterar(MLIdioma pobjMLIdioma)
        {
            var cmdCommand = new FWCommand("USP_FWK_U_IDIOMA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLIdioma.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["IDI_N_CODIGO"].Value = pobjMLIdioma.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLIdioma.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("IDI_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["IDI_C_NOME"].Value = pobjMLIdioma.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLIdioma.Sigla))
            {
                cmdCommand.Parameters.Add(new FWParameter("IDI_C_SIGLA", FWDbType.Varchar, 5));
                cmdCommand.Parameters["IDI_C_SIGLA"].Value = pobjMLIdioma.Sigla;
            }
            if (pobjMLIdioma.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("IDI_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["IDI_B_ATIVO"].Value = pobjMLIdioma.IsAtivo.Value;
            }

            return (conProvider.ExecuteNonQuery(cmdCommand)>0);
        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLIdioma">Idioma para inserir</param>
        /// <returns>Código Idioma</returns> 
        /// <user>mazevedo</user>
        public int Inserir(MLIdioma pobjMLIdioma)
        {

            var intRetorno = 0;
            var cmdCommand = new FWCommand("USP_FWK_I_IDIOMA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            
            if (!string.IsNullOrEmpty(pobjMLIdioma.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("IDI_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["IDI_C_NOME"].Value = pobjMLIdioma.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLIdioma.Sigla))
            {
                cmdCommand.Parameters.Add(new FWParameter("IDI_C_SIGLA", FWDbType.Varchar, 5));
                cmdCommand.Parameters["IDI_C_SIGLA"].Value = pobjMLIdioma.Sigla;
            }
            if (pobjMLIdioma.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("IDI_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["IDI_B_ATIVO"].Value = pobjMLIdioma.IsAtivo.Value;
            }

            cmdCommand.Parameters.Add(new FWParameter("IDI_N_CODIGO", FWDbType.Int32));
            cmdCommand.Parameters["IDI_N_CODIGO"].Direction = ParameterDirection.Output;

            conProvider.ExecuteNonQuery(cmdCommand);

            if (cmdCommand.Parameters["IDI_N_CODIGO"] != null)
                intRetorno = Convert.ToInt32(cmdCommand.Parameters["IDI_N_CODIGO"].Value);

            return intRetorno;
        }

        #endregion
    }
}


