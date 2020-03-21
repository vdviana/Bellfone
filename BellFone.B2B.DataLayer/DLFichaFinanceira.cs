using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para FichaFinanceira 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class DLFichaFinanceira : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.0]</user> 
        public DLFichaFinanceira()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLFichaFinanceira">Parametros para filtro</param>
        /// <returns>Lista de FichaFinanceira</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLFichaFinanceira> Listar(MLFichaFinanceira pobjMLFichaFinanceira)
        {

            List<MLFichaFinanceira> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_FICHA_FINANCEIRA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_N_CODIGO", FWDbType.Varchar, 18));
                cmdCommand.Parameters["@FIF_N_CODIGO"].Value = pobjMLFichaFinanceira.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.Parcela))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_C_PARCELA", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@FIF_C_PARCELA"].Value = pobjMLFichaFinanceira.Parcela;
            }
            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@FIF_REV_C_CODIGO"].Value = pobjMLFichaFinanceira.CodigoRevendedor;
            }
            if (pobjMLFichaFinanceira.DataLancamento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_D_LANCAMENTO", FWDbType.DateTime));
                cmdCommand.Parameters["@FIF_D_LANCAMENTO"].Value = pobjMLFichaFinanceira.DataLancamento.Value;
            }
            if (pobjMLFichaFinanceira.DataVencimento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_D_VENCIMENTO", FWDbType.DateTime));
                cmdCommand.Parameters["@FIF_D_VENCIMENTO"].Value = pobjMLFichaFinanceira.DataVencimento.Value;
            }
            if (pobjMLFichaFinanceira.ValorParcela.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_N_VALOR_PARCELA", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@FIF_N_VALOR_PARCELA"].Value = pobjMLFichaFinanceira.ValorParcela.Value;
            }
            if (pobjMLFichaFinanceira.ValorPagamento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_N_VALOR_PAGAMENTO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@FIF_N_VALOR_PAGAMENTO"].Value = pobjMLFichaFinanceira.ValorPagamento.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.FormaPagamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_C_FORMA_PAGAMENTO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@FIF_C_FORMA_PAGAMENTO"].Value = pobjMLFichaFinanceira.FormaPagamento;
            }
            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.CodigoClienteRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_REV_C_CODIGO_CLIENTE", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@FIF_REV_C_CODIGO_CLIENTE"].Value = pobjMLFichaFinanceira.CodigoClienteRevendedor;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLFichaFinanceira objRetorno = null;
                lstRetorno = new List<MLFichaFinanceira>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLFichaFinanceira();
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
        /// <param name="pstrParcela">Parcela</param>
        /// <returns>FichaFinanceira</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLFichaFinanceira Obter(string pdecCodigo,
                                               string pstrParcela)
        {

            MLFichaFinanceira objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_FICHA_FINANCEIRA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@FIF_N_CODIGO", FWDbType.Varchar, 18));
            cmdCommand.Parameters["@FIF_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@FIF_C_PARCELA", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@FIF_C_PARCELA"].Value = pstrParcela;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FIF_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_FIF_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FIF_C_PARCELA", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@OUT_FIF_C_PARCELA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FIF_REV_C_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_FIF_REV_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FIF_D_LANCAMENTO", FWDbType.DateTime));
            cmdCommand.Parameters["@OUT_FIF_D_LANCAMENTO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FIF_D_VENCIMENTO", FWDbType.DateTime));
            cmdCommand.Parameters["@OUT_FIF_D_VENCIMENTO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FIF_N_VALOR_PARCELA", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_FIF_N_VALOR_PARCELA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FIF_N_VALOR_PAGAMENTO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_FIF_N_VALOR_PAGAMENTO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FIF_C_FORMA_PAGAMENTO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_FIF_C_FORMA_PAGAMENTO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FIF_REV_C_CODIGO_CLIENTE", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_FIF_REV_C_CODIGO_CLIENTE"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_FIF_N_CODIGO") && cmdCommand.Parameters["@OUT_FIF_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLFichaFinanceira();

                    objRetorno.Codigo = Convert.ToString(cmdCommand.Parameters["@OUT_FIF_N_CODIGO"].Value);
                    if (cmdCommand.Parameters.Contains("@OUT_FIF_C_PARCELA") && cmdCommand.Parameters["@OUT_FIF_C_PARCELA"].Value != System.DBNull.Value)
                    {
                        objRetorno.Parcela = cmdCommand.Parameters["@OUT_FIF_C_PARCELA"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_FIF_REV_C_CODIGO") && cmdCommand.Parameters["@OUT_FIF_REV_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoRevendedor = cmdCommand.Parameters["@OUT_FIF_REV_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_FIF_D_LANCAMENTO") && cmdCommand.Parameters["@OUT_FIF_D_LANCAMENTO"].Value != System.DBNull.Value)
                    {
                        objRetorno.DataLancamento = Convert.ToDateTime(cmdCommand.Parameters["@OUT_FIF_D_LANCAMENTO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_FIF_D_VENCIMENTO") && cmdCommand.Parameters["@OUT_FIF_D_VENCIMENTO"].Value != System.DBNull.Value)
                    {
                        objRetorno.DataVencimento = Convert.ToDateTime(cmdCommand.Parameters["@OUT_FIF_D_VENCIMENTO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_FIF_N_VALOR_PARCELA") && cmdCommand.Parameters["@OUT_FIF_N_VALOR_PARCELA"].Value != System.DBNull.Value)
                    {
                        objRetorno.ValorParcela = Convert.ToDecimal(cmdCommand.Parameters["@OUT_FIF_N_VALOR_PARCELA"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_FIF_N_VALOR_PAGAMENTO") && cmdCommand.Parameters["@OUT_FIF_N_VALOR_PAGAMENTO"].Value != System.DBNull.Value)
                    {
                        objRetorno.ValorPagamento = Convert.ToDecimal(cmdCommand.Parameters["@OUT_FIF_N_VALOR_PAGAMENTO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_FIF_C_FORMA_PAGAMENTO") && cmdCommand.Parameters["@OUT_FIF_C_FORMA_PAGAMENTO"].Value != System.DBNull.Value)
                    {
                        objRetorno.FormaPagamento = cmdCommand.Parameters["@OUT_FIF_C_FORMA_PAGAMENTO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_FIF_REV_C_CODIGO_CLIENTE") && cmdCommand.Parameters["@OUT_FIF_REV_C_CODIGO_CLIENTE"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoClienteRevendedor = cmdCommand.Parameters["@OUT_FIF_REV_C_CODIGO_CLIENTE"].Value.ToString();
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
        /// <param name="pstrParcela">Parcela</param>
        /// <returns>Quantidade de Registro Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Excluir(string pstrCodigo,
                                               string pstrParcela)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_FICHA_FINANCEIRA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@FIF_N_CODIGO", FWDbType.Varchar, 18));
            cmdCommand.Parameters["@FIF_N_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@FIF_C_PARCELA", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@FIF_C_PARCELA"].Value = pstrParcela;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLFichaFinanceira">FichaFinanceira para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLFichaFinanceira pobjMLFichaFinanceira)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_FICHA_FINANCEIRA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_N_CODIGO", FWDbType.Varchar, 18));
                cmdCommand.Parameters["@FIF_N_CODIGO"].Value = pobjMLFichaFinanceira.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.Parcela))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_C_PARCELA", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@FIF_C_PARCELA"].Value = pobjMLFichaFinanceira.Parcela;
            }
            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@FIF_REV_C_CODIGO"].Value = pobjMLFichaFinanceira.CodigoRevendedor;
            }
            if (pobjMLFichaFinanceira.DataLancamento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_D_LANCAMENTO", FWDbType.DateTime));
                cmdCommand.Parameters["@FIF_D_LANCAMENTO"].Value = pobjMLFichaFinanceira.DataLancamento.Value;
            }
            if (pobjMLFichaFinanceira.DataVencimento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_D_VENCIMENTO", FWDbType.DateTime));
                cmdCommand.Parameters["@FIF_D_VENCIMENTO"].Value = pobjMLFichaFinanceira.DataVencimento.Value;
            }
            if (pobjMLFichaFinanceira.ValorParcela.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_N_VALOR_PARCELA", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@FIF_N_VALOR_PARCELA"].Value = pobjMLFichaFinanceira.ValorParcela.Value;
            }
            if (pobjMLFichaFinanceira.ValorPagamento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_N_VALOR_PAGAMENTO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@FIF_N_VALOR_PAGAMENTO"].Value = pobjMLFichaFinanceira.ValorPagamento.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.FormaPagamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_C_FORMA_PAGAMENTO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@FIF_C_FORMA_PAGAMENTO"].Value = pobjMLFichaFinanceira.FormaPagamento;
            }
            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.CodigoClienteRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_REV_C_CODIGO_CLIENTE", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@FIF_REV_C_CODIGO_CLIENTE"].Value = pobjMLFichaFinanceira.CodigoClienteRevendedor;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLFichaFinanceira">FichaFinanceira para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Inserir(MLFichaFinanceira pobjMLFichaFinanceira)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_FICHA_FINANCEIRA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_N_CODIGO", FWDbType.Varchar, 18));
                cmdCommand.Parameters["@FIF_N_CODIGO"].Value = pobjMLFichaFinanceira.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.Parcela))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_C_PARCELA", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@FIF_C_PARCELA"].Value = pobjMLFichaFinanceira.Parcela;
            }
            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@FIF_REV_C_CODIGO"].Value = pobjMLFichaFinanceira.CodigoRevendedor;
            }
            if (pobjMLFichaFinanceira.DataLancamento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_D_LANCAMENTO", FWDbType.DateTime));
                cmdCommand.Parameters["@FIF_D_LANCAMENTO"].Value = pobjMLFichaFinanceira.DataLancamento.Value;
            }
            if (pobjMLFichaFinanceira.DataVencimento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_D_VENCIMENTO", FWDbType.DateTime));
                cmdCommand.Parameters["@FIF_D_VENCIMENTO"].Value = pobjMLFichaFinanceira.DataVencimento.Value;
            }
            if (pobjMLFichaFinanceira.ValorParcela.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_N_VALOR_PARCELA", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@FIF_N_VALOR_PARCELA"].Value = pobjMLFichaFinanceira.ValorParcela.Value;
            }
            if (pobjMLFichaFinanceira.ValorPagamento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_N_VALOR_PAGAMENTO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@FIF_N_VALOR_PAGAMENTO"].Value = pobjMLFichaFinanceira.ValorPagamento.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.FormaPagamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_C_FORMA_PAGAMENTO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@FIF_C_FORMA_PAGAMENTO"].Value = pobjMLFichaFinanceira.FormaPagamento;
            }
            if (!string.IsNullOrEmpty(pobjMLFichaFinanceira.CodigoClienteRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_REV_C_CODIGO_CLIENTE", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@FIF_REV_C_CODIGO_CLIENTE"].Value = pobjMLFichaFinanceira.CodigoClienteRevendedor;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion
    }
}


