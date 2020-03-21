using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade FormaPagamento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class MLFormaPagamento
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de FOP_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de FOP_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Descricao { get; set; }

        /// <summary> 
        /// Recebe o valor de FOP_B_ATIVO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public bool? IsAtivo { get; set; }

        /// <summary> 
        /// Recebe o valor de Operação da Integração
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
            if (pobjIDataReader["FOP_C_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = pobjIDataReader["FOP_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["FOP_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.Descricao = pobjIDataReader["FOP_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["FOP_B_ATIVO"] != System.DBNull.Value)
            {
                this.IsAtivo = Convert.ToBoolean(pobjIDataReader["FOP_B_ATIVO"]);
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados da Condição de Pagamento

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLFormaPagamento> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            try
            {
                var lstRetorno = new List<MLFormaPagamento>();
                MLFormaPagamento objMLFormaPagamento;

                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (String strLinha in strLinhas)
                {
                    try
                    {
                        objMLFormaPagamento = new MLFormaPagamento();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            objMLFormaPagamento.Codigo = strLinha.Substring(0, 2).Trim();
                            objMLFormaPagamento.Descricao = strLinha.Substring(2, 50).Trim();
                            if (strLinha.Substring(52, 1) == "1")
                            {
                                objMLFormaPagamento.IsAtivo = true;
                            }
                            else if (strLinha.Substring(52, 1) == "0")
                            {
                                objMLFormaPagamento.IsAtivo = false;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Ativo)");
                            }
                            objMLFormaPagamento.Operacao = strLinha.Substring(53, 1).Trim();

                            lstRetorno.Add(objMLFormaPagamento);
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


