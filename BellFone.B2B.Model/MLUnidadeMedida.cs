using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade UnidadeMedida 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class MLUnidadeMedida
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de UNM_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de UNM_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Descricao { get; set; }

        /// <summary> 
        /// Opreação feita na Integração
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
            if (pobjIDataReader["UNM_C_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = pobjIDataReader["UNM_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["UNM_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.Descricao = pobjIDataReader["UNM_C_DESCRICAO"].ToString();
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados da Unidade de Medida

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLUnidadeMedida> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            try
            {
                var lstRetorno = new List<MLUnidadeMedida>();
                MLUnidadeMedida objMLUnidadeMedida;

                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (String strLinha in strLinhas)
                {
                    try
                    {
                        objMLUnidadeMedida = new MLUnidadeMedida();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            objMLUnidadeMedida.Codigo = strLinha.Substring(0, 3).Trim();
                            objMLUnidadeMedida.Descricao = strLinha.Substring(3, 50).Trim();
                            objMLUnidadeMedida.Operacao = strLinha.Substring(53, 1).Trim();

                            lstRetorno.Add(objMLUnidadeMedida);
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


