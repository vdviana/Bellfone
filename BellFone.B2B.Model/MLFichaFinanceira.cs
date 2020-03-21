using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade FichaFinanceira 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class MLFichaFinanceira
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de FIF_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_C_PARCELA 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Parcela { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_REV_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoRevendedor { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_D_LANCAMENTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public DateTime? DataLancamento { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_D_VENCIMENTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public DateTime? DataVencimento { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_N_VALOR_PARCELA 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? ValorParcela { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_N_VALOR_PAGAMENTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? ValorPagamento { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_C_FORMA_PAGAMENTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string FormaPagamento { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_REV_C_CODIGO_CLIENTE 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoClienteRevendedor { get; set; }

        /// <summary> 
        /// Recebe a Operação para a Integração
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Operacao { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["FIF_N_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = Convert.ToString(pobjIDataReader["FIF_N_CODIGO"]);
            }
            if (pobjIDataReader["FIF_C_PARCELA"] != System.DBNull.Value)
            {
                this.Parcela = pobjIDataReader["FIF_C_PARCELA"].ToString();
            }
            if (pobjIDataReader["FIF_REV_C_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoRevendedor = pobjIDataReader["FIF_REV_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["FIF_D_LANCAMENTO"] != System.DBNull.Value)
            {
                this.DataLancamento = Convert.ToDateTime(pobjIDataReader["FIF_D_LANCAMENTO"]);
            }
            if (pobjIDataReader["FIF_D_VENCIMENTO"] != System.DBNull.Value)
            {
                this.DataVencimento = Convert.ToDateTime(pobjIDataReader["FIF_D_VENCIMENTO"]);
            }
            if (pobjIDataReader["FIF_N_VALOR_PARCELA"] != System.DBNull.Value)
            {
                this.ValorParcela = Convert.ToDecimal(pobjIDataReader["FIF_N_VALOR_PARCELA"]);
            }
            if (pobjIDataReader["FIF_N_VALOR_PAGAMENTO"] != System.DBNull.Value)
            {
                this.ValorPagamento = Convert.ToDecimal(pobjIDataReader["FIF_N_VALOR_PAGAMENTO"]);
            }
            if (pobjIDataReader["FIF_C_FORMA_PAGAMENTO"] != System.DBNull.Value)
            {
                this.FormaPagamento = pobjIDataReader["FIF_C_FORMA_PAGAMENTO"].ToString();
            }
            if (pobjIDataReader["FIF_REV_C_CODIGO_CLIENTE"] != System.DBNull.Value)
            {
                this.CodigoClienteRevendedor = pobjIDataReader["FIF_REV_C_CODIGO_CLIENTE"].ToString();
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados da Ficha Financeira

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLFichaFinanceira> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            try
            {
                var lstRetorno = new List<MLFichaFinanceira>();
                MLFichaFinanceira objMLFichaFinanceira;
                Decimal deValorDecimal;
                DateTime dtValorDateTime;

                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (String strLinha in strLinhas)
                {   
                    try
                    {
                        objMLFichaFinanceira = new MLFichaFinanceira();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            if (!string.IsNullOrEmpty(strLinha.Substring(0, 18).Trim()))
                            {
                                objMLFichaFinanceira.Codigo = strLinha.Substring(0, 18).Trim();
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Código)");
                            }
                            objMLFichaFinanceira.CodigoRevendedor = strLinha.Substring(18, 5).Trim();
                            objMLFichaFinanceira.Parcela = strLinha.Substring(23, 1).Trim();
                            if (DateTime.TryParse(strLinha.Substring(24, 10), out dtValorDateTime))
                            {
                                objMLFichaFinanceira.DataLancamento = dtValorDateTime;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Data de Lançamento)");
                            }
                            if (DateTime.TryParse(strLinha.Substring(34, 10), out dtValorDateTime))
                            {
                                objMLFichaFinanceira.DataVencimento = dtValorDateTime;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Data de Vencimento)");
                            }
                            if (Decimal.TryParse(strLinha.Substring(44, 18).Trim(), out deValorDecimal))
                            {
                                objMLFichaFinanceira.ValorParcela = deValorDecimal / 100;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Valor da Parcela)");
                            }
                            if (Decimal.TryParse(strLinha.Substring(62, 18).Trim(), out deValorDecimal))
                            {
                                objMLFichaFinanceira.ValorPagamento = deValorDecimal / 100;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Valor da Pagamento)");
                            }
                            objMLFichaFinanceira.FormaPagamento = strLinha.Substring(80, 50).Trim();
                            objMLFichaFinanceira.CodigoClienteRevendedor = strLinha.Substring(130, 5).Trim();
                            objMLFichaFinanceira.Operacao = strLinha.Substring(135, 1).Trim();

                            if (String.IsNullOrEmpty(objMLFichaFinanceira.CodigoClienteRevendedor))
                            {
                                objMLFichaFinanceira.CodigoClienteRevendedor = objMLFichaFinanceira.CodigoRevendedor;
                            }

                            lstRetorno.Add(objMLFichaFinanceira);
                        }
                    }
                    catch (Exception ex)
                    {
                        plstErros.Add("Erro ao ler registro: " + ex.Message);
                    }
                }

                return lstRetorno;
            }
            catch
            {
                throw;
            }             
        }

        #endregion
    }
}


