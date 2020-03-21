using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade ExtratoFinanceiro 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class MLExtratoFinanceiro
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de EXF_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_REV_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string CodigoRevendedor { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_D_LANCAMENTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public DateTime? DataLancamento { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_C_HISTORICO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Historico { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_N_SALDO_ANTERIOR 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? SaldoAnterior { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_N_CREDITO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? Credito { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_N_DEBITO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? Debito { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_N_SALDO_ATUAL 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? SaldoAtual { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_C_STATUS 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Status { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_C_DOCUMENTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Documento { get; set; }

        /// <summary> 
        /// Recebe a inicial da operação na Integração
        /// </summary> 
        /// <user>efranca</user>
        public string Operacao { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["EXF_N_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = Convert.ToDecimal(pobjIDataReader["EXF_N_CODIGO"]);
            }
            if (pobjIDataReader["EXF_REV_N_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoRevendedor = pobjIDataReader["EXF_REV_N_CODIGO"].ToString();
            }
            if (pobjIDataReader["EXF_D_LANCAMENTO"] != System.DBNull.Value)
            {
                this.DataLancamento = Convert.ToDateTime(pobjIDataReader["EXF_D_LANCAMENTO"]);
            }
            if (pobjIDataReader["EXF_C_HISTORICO"] != System.DBNull.Value)
            {
                this.Historico = pobjIDataReader["EXF_C_HISTORICO"].ToString();
            }
            if (pobjIDataReader["EXF_N_SALDO_ANTERIOR"] != System.DBNull.Value)
            {
                this.SaldoAnterior = Convert.ToDecimal(pobjIDataReader["EXF_N_SALDO_ANTERIOR"]);
            }
            if (pobjIDataReader["EXF_N_CREDITO"] != System.DBNull.Value)
            {
                this.Credito = Convert.ToDecimal(pobjIDataReader["EXF_N_CREDITO"]);
            }
            if (pobjIDataReader["EXF_N_DEBITO"] != System.DBNull.Value)
            {
                this.Debito = Convert.ToDecimal(pobjIDataReader["EXF_N_DEBITO"]);
            }
            if (pobjIDataReader["EXF_N_SALDO_ATUAL"] != System.DBNull.Value)
            {
                this.SaldoAtual = Convert.ToDecimal(pobjIDataReader["EXF_N_SALDO_ATUAL"]);
            }
            if (pobjIDataReader["EXF_C_STATUS"] != System.DBNull.Value)
            {
                this.Status = pobjIDataReader["EXF_C_STATUS"].ToString();
            }
            if (pobjIDataReader["EXF_C_DOCUMENTO"] != System.DBNull.Value)
            {
                this.Documento = pobjIDataReader["EXF_C_DOCUMENTO"].ToString();
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados do Extrato Bancario

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLExtratoFinanceiro> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            try
            {
                List<MLExtratoFinanceiro> lstRetorno = new List<MLExtratoFinanceiro>();
                MLExtratoFinanceiro objMLExtratoFinanceiro;

                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (String strLinha in strLinhas)
                {
                    Decimal deValorDecimal;
                    DateTime dtValorDateTime;

                    try
                    {
                        objMLExtratoFinanceiro = new MLExtratoFinanceiro();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            //
                            if (Decimal.TryParse(strLinha.Substring(0, 18).Trim(), out deValorDecimal))
                            {
                                objMLExtratoFinanceiro.Codigo = deValorDecimal;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Código)");
                            }
                            //
                            objMLExtratoFinanceiro.CodigoRevendedor = strLinha.Substring(18, 5).Trim();
                            //
                            if (DateTime.TryParse(strLinha.Substring(23, 10).Trim(), out dtValorDateTime))
                            {
                                objMLExtratoFinanceiro.DataLancamento = dtValorDateTime;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Data de Lançamento)");
                            }
                            //
                            if (strLinha.Substring(33, 14).Trim().Contains("-"))
                            {
                                if (Decimal.TryParse(strLinha.Substring(33, 14).Trim().Replace('-', '0'), out deValorDecimal))
                                {
                                    objMLExtratoFinanceiro.SaldoAnterior = (deValorDecimal / 100) / -1;
                                }
                                else
                                {
                                    plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Saldo Anterior)");
                                }
                            }
                            else
                            {
                                if (Decimal.TryParse(strLinha.Substring(33, 14).Trim(), out deValorDecimal))
                                {
                                    objMLExtratoFinanceiro.SaldoAnterior = deValorDecimal / 100;
                                }
                                else
                                {
                                    plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Saldo Anterior)");
                                }
                            }
                            //
                            if (strLinha.Substring(47, 14).Trim().Contains("-"))
                            {
                                if (Decimal.TryParse(strLinha.Substring(47, 14).Trim().Replace('-', '0'), out deValorDecimal))
                                {
                                    objMLExtratoFinanceiro.Credito = (deValorDecimal / 100) / -1;
                                }
                                else
                                {
                                    plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Credito)");
                                }
                            }
                            else
                            {
                                if (Decimal.TryParse(strLinha.Substring(47, 14).Trim(), out deValorDecimal))
                                {
                                    objMLExtratoFinanceiro.Credito = deValorDecimal / 100;
                                }
                                else
                                {
                                    plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Credito)");
                                }
                            }
                            //
                            if (strLinha.Substring(61, 14).Trim().Contains("-"))
                            {
                                if (Decimal.TryParse(strLinha.Substring(61, 14).Trim().Replace('-', '0'), out deValorDecimal))
                                {
                                    objMLExtratoFinanceiro.Debito = (deValorDecimal / 100) / -1;
                                }
                                else
                                {
                                    plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Débito)");
                                }
                            }
                            else
                            {
                                if (Decimal.TryParse(strLinha.Substring(61, 14).Trim(), out deValorDecimal))
                                {
                                    objMLExtratoFinanceiro.Debito = deValorDecimal / 100;
                                }
                                else
                                {
                                    plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Débito)");
                                }
                            }
                            //
                            if (strLinha.Substring(75, 14).Trim().Contains("-"))
                            {
                                if (Decimal.TryParse(strLinha.Substring(75, 14).Trim().Replace('-', '0'), out deValorDecimal))
                                {
                                    objMLExtratoFinanceiro.SaldoAtual = (deValorDecimal / 100) / -1;
                                }
                                else
                                {
                                    plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Saldo Atual)");
                                }
                            }
                            else
                            {
                                if (Decimal.TryParse(strLinha.Substring(75, 14).Trim(), out deValorDecimal))
                                {
                                    objMLExtratoFinanceiro.SaldoAtual = deValorDecimal / 100;
                                }
                                else
                                {
                                    plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Saldo Atual)");
                                }
                            }
                            //
                            objMLExtratoFinanceiro.Status = strLinha.Substring(89, 1).Trim();
                            //
                            objMLExtratoFinanceiro.Documento = strLinha.Substring(90, 7).Trim();
                            //
                            objMLExtratoFinanceiro.Operacao = strLinha.Substring(97, 1).Trim();
                            //
                            objMLExtratoFinanceiro.Historico = strLinha.Substring(98);

                            lstRetorno.Add(objMLExtratoFinanceiro);
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


