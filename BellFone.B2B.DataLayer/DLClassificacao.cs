using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para Classificacao 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.1.1]</user> 
    public class DLClassificacao : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.1.1]</user> 
        public DLClassificacao()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLClassificacao">Parametros para filtro</param>
        /// <returns>Lista de Classificacao</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public List<MLClassificacao> Listar(MLClassificacao pobjMLClassificacao)
        {

            List<MLClassificacao> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_CLASSIFICACAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLClassificacao.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CLC_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@CLC_N_CODIGO"].Value = pobjMLClassificacao.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLClassificacao.Classificacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CLC_C_CLASSIFICACAO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@CLC_C_CLASSIFICACAO"].Value = pobjMLClassificacao.Classificacao;
            }
            if (pobjMLClassificacao.IsProduto.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CLC_B_PRODUTO", FWDbType.Boolean));
                cmdCommand.Parameters["@CLC_B_PRODUTO"].Value = pobjMLClassificacao.IsProduto.Value;
            }
            if (pobjMLClassificacao.IsRevendedor.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CLC_B_REVENDEDOR", FWDbType.Boolean));
                cmdCommand.Parameters["@CLC_B_REVENDEDOR"].Value = pobjMLClassificacao.IsRevendedor.Value;
            }
            if (pobjMLClassificacao.Desconto.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CLC_N_DESCONTO", FWDbType.Decimal, 5));
                cmdCommand.Parameters["@CLC_N_DESCONTO"].Scale = 2;
                cmdCommand.Parameters["@CLC_N_DESCONTO"].Value = pobjMLClassificacao.Desconto.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLClassificacao objRetorno = null;
                lstRetorno = new List<MLClassificacao>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLClassificacao();
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
        /// <returns>Classificacao</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public MLClassificacao Obter(decimal pdecCodigo)
        {

            MLClassificacao objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_CLASSIFICACAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@CLC_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@CLC_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_CLC_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_CLC_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_CLC_C_CLASSIFICACAO", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@OUT_CLC_C_CLASSIFICACAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_CLC_B_PRODUTO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_CLC_B_PRODUTO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_CLC_B_REVENDEDOR", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_CLC_B_REVENDEDOR"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_CLC_N_DESCONTO", FWDbType.Decimal, 5));
            cmdCommand.Parameters["@OUT_CLC_N_DESCONTO"].Scale = 2;
            cmdCommand.Parameters["@OUT_CLC_N_DESCONTO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_CLC_N_CODIGO") && cmdCommand.Parameters["@OUT_CLC_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLClassificacao();

                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_CLC_N_CODIGO"].Value);
                    if (cmdCommand.Parameters.Contains("@OUT_CLC_C_CLASSIFICACAO") && cmdCommand.Parameters["@OUT_CLC_C_CLASSIFICACAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Classificacao = cmdCommand.Parameters["@OUT_CLC_C_CLASSIFICACAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_CLC_B_PRODUTO") && cmdCommand.Parameters["@OUT_CLC_B_PRODUTO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsProduto = Convert.ToBoolean(cmdCommand.Parameters["@OUT_CLC_B_PRODUTO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_CLC_B_REVENDEDOR") && cmdCommand.Parameters["@OUT_CLC_B_REVENDEDOR"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsRevendedor = Convert.ToBoolean(cmdCommand.Parameters["@OUT_CLC_B_REVENDEDOR"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_CLC_N_DESCONTO") && cmdCommand.Parameters["@OUT_CLC_N_DESCONTO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Desconto = Convert.ToDecimal(cmdCommand.Parameters["@OUT_CLC_N_DESCONTO"].Value);
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
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public int Excluir(decimal pdecCodigo)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_CLASSIFICACAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@CLC_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@CLC_N_CODIGO"].Value = pdecCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLClassificacao">Classificacao para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public int Alterar(MLClassificacao pobjMLClassificacao)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_CLASSIFICACAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLClassificacao.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CLC_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@CLC_N_CODIGO"].Value = pobjMLClassificacao.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLClassificacao.Classificacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CLC_C_CLASSIFICACAO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@CLC_C_CLASSIFICACAO"].Value = pobjMLClassificacao.Classificacao;
            }
            if (pobjMLClassificacao.IsProduto.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CLC_B_PRODUTO", FWDbType.Boolean));
                cmdCommand.Parameters["@CLC_B_PRODUTO"].Value = pobjMLClassificacao.IsProduto.Value;
            }
            if (pobjMLClassificacao.IsRevendedor.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CLC_B_REVENDEDOR", FWDbType.Boolean));
                cmdCommand.Parameters["@CLC_B_REVENDEDOR"].Value = pobjMLClassificacao.IsRevendedor.Value;
            }
            if (pobjMLClassificacao.Desconto.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CLC_N_DESCONTO", FWDbType.Decimal, 5));
                //cmdCommand.Parameters["@CLC_N_DESCONTO"].Scale = 2;
                cmdCommand.Parameters["@CLC_N_DESCONTO"].Value = pobjMLClassificacao.Desconto.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLClassificacao">Classificacao para inserir</param>
        /// <returns>Código Classificacao</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public decimal Inserir(MLClassificacao pobjMLClassificacao)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_CLASSIFICACAO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLClassificacao.Classificacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CLC_C_CLASSIFICACAO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@CLC_C_CLASSIFICACAO"].Value = pobjMLClassificacao.Classificacao;
            }
            if (pobjMLClassificacao.IsProduto.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CLC_B_PRODUTO", FWDbType.Boolean));
                cmdCommand.Parameters["@CLC_B_PRODUTO"].Value = pobjMLClassificacao.IsProduto.Value;
            }
            if (pobjMLClassificacao.IsRevendedor.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CLC_B_REVENDEDOR", FWDbType.Boolean));
                cmdCommand.Parameters["@CLC_B_REVENDEDOR"].Value = pobjMLClassificacao.IsRevendedor.Value;
            }
            if (pobjMLClassificacao.Desconto.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CLC_N_DESCONTO", FWDbType.Decimal, 5));
                //cmdCommand.Parameters["@CLC_N_DESCONTO"].Scale = 2;
                cmdCommand.Parameters["@CLC_N_DESCONTO"].Value = pobjMLClassificacao.Desconto.Value;
            }

            return Convert.ToDecimal(conProvider.ExecuteScalar(cmdCommand));

        }

        #endregion
    }
}


