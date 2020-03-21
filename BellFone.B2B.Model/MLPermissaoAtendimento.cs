using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade PermissaoAtendimento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class MLPermissaoAtendimento
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de PAT_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de PAT_REV_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string CodigoRevendedor { get; set; }

        /// <summary> 
        /// Recebe o valor de PAT_ATD_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public int? Atdcodigo { get; set; }

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
            if (pobjIDataReader["PAT_N_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = Convert.ToDecimal(pobjIDataReader["PAT_N_CODIGO"]);
            }
            if (pobjIDataReader["PAT_REV_C_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoRevendedor = pobjIDataReader["PAT_REV_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["PAT_ATD_N_CODIGO"] != System.DBNull.Value)
            {
                this.Atdcodigo = Convert.ToInt32(pobjIDataReader["PAT_ATD_N_CODIGO"]);
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados da Tipo de Negocio

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLPermissaoAtendimento> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            try
            {
                List<MLPermissaoAtendimento> lstRetorno = new List<MLPermissaoAtendimento>();

                MLPermissaoAtendimento objMLPermissaoAtendimento;
                Decimal deValorDecimal;
                int intValorInteger;

                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);


                foreach (String strLinha in strLinhas)
                {
                    try
                    {
                        objMLPermissaoAtendimento = new MLPermissaoAtendimento();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            if (Decimal.TryParse(strLinha.Substring(0, 18).Trim(), out deValorDecimal))
                            {
                                objMLPermissaoAtendimento.Codigo = deValorDecimal;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Código)");
                            }
                            objMLPermissaoAtendimento.CodigoRevendedor = strLinha.Substring(18, 5).Trim();
                            if (Int32.TryParse(strLinha.Substring(23, 1).Trim(), out intValorInteger))
                            {
                                objMLPermissaoAtendimento.Atdcodigo = intValorInteger;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Código de Atendimento)");
                            }
                            objMLPermissaoAtendimento.Operacao = strLinha.Substring(24, 1).Trim();

                            lstRetorno.Add(objMLPermissaoAtendimento);
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


