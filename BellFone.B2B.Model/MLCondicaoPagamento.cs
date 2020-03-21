using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade CondicaoPagamento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class MLCondicaoPagamento
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de CON_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de CON_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Descricao { get; set; }

        /// <summary> 
        /// Recebe o valor de CON_B_ATIVO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public bool? IsAtivo { get; set; }

        /// <summary> 
        /// Recebe o valor de Operação na Integração 
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
            if (pobjIDataReader["CON_C_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = pobjIDataReader["CON_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["CON_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.Descricao = pobjIDataReader["CON_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["CON_B_ATIVO"] != System.DBNull.Value)
            {
                this.IsAtivo = Convert.ToBoolean(pobjIDataReader["CON_B_ATIVO"]);
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados da Condição de Pagamento

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLCondicaoPagamento> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            try
            {
                var lstRetorno = new List<MLCondicaoPagamento>();
                MLCondicaoPagamento objMLCondicaoPagamento;

                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (String strLinha in strLinhas)
                {
                    try
                    {
                        objMLCondicaoPagamento = new MLCondicaoPagamento();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            objMLCondicaoPagamento.Codigo = strLinha.Substring(0, 3).Trim();
                            objMLCondicaoPagamento.Descricao = strLinha.Substring(3, 50).Trim();
                            if (strLinha.Substring(53, 1) == "1")
                            {
                                objMLCondicaoPagamento.IsAtivo = true;
                            }
                            else if (strLinha.Substring(53, 1) == "0")
                            {
                                objMLCondicaoPagamento.IsAtivo = false;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 3).Trim() + "(Erro ao ler campo Ativo)");
                            }
                            objMLCondicaoPagamento.Operacao = strLinha.Substring(54, 1).Trim();

                            lstRetorno.Add(objMLCondicaoPagamento);
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
