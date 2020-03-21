using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade StatusItemOrcamento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.1.1]</user> 
    public class MLStatusItemOrcamento
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de STI_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de STI_C_DESCICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string Descicao { get; set; }

        /// <summary> 
        /// Recebe o valor de STI_B_ATIVO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public bool? IsAtivo { get; set; }

        /// <summary> 
        /// Recebe o valor Operação para a Integração
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
            if (pobjIDataReader["STI_C_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = pobjIDataReader["STI_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["STI_C_DESCICAO"] != System.DBNull.Value)
            {
                this.Descicao = pobjIDataReader["STI_C_DESCICAO"].ToString();
            }
            if (pobjIDataReader["STI_B_ATIVO"] != System.DBNull.Value)
            {
                this.IsAtivo = Convert.ToBoolean(pobjIDataReader["STI_B_ATIVO"]);
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados da categoria

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLStatusItemOrcamento> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            List<MLStatusItemOrcamento> lstRetorno = new List<MLStatusItemOrcamento>();
            MLStatusItemOrcamento objMLStatusItemOrcamento;

            try
            {
                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (String strLinha in strLinhas)
                {
                    try
                    {
                        objMLStatusItemOrcamento = new MLStatusItemOrcamento();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            objMLStatusItemOrcamento.Codigo = strLinha.Substring(0, 3).Trim();
                            objMLStatusItemOrcamento.Descicao = strLinha.Substring(3, 50).Trim();
                            if (strLinha.Substring(53, 1) == "1")
                            {
                                objMLStatusItemOrcamento.IsAtivo = true;
                            }
                            else if (strLinha.Substring(53, 1) == "0")
                            {
                                objMLStatusItemOrcamento.IsAtivo = false;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 3).Trim() + "(Erro ao ler campo Ativo)");
                            }
                            objMLStatusItemOrcamento.Operacao = strLinha.Substring(54, 1).Trim();

                            lstRetorno.Add(objMLStatusItemOrcamento);
                        }
                    }
                    catch (Exception ex)
                    {
                        plstErros.Add("Erro ao ler registro: " + ex.Message);
                    }
                }
            }
            catch
            {
                throw;
            }
            return lstRetorno;
        }

        #endregion
    }
}



