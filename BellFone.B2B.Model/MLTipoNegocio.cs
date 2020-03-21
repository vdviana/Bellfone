using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade TipoNegocio 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class MLTipoNegocio
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de TPN_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de TPN_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Descricao { get; set; }

        /// <summary> 
        /// Recebe o valor de TPN_B_STATUS 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public bool? IsStatus { get; set; }

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
            if (pobjIDataReader["TPN_C_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = pobjIDataReader["TPN_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["TPN_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.Descricao = pobjIDataReader["TPN_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["TPN_B_STATUS"] != System.DBNull.Value)
            {
                this.IsStatus = Convert.ToBoolean(pobjIDataReader["TPN_B_STATUS"]);
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados da Tipo de Negocio

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLTipoNegocio> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            try
            {
                List<MLTipoNegocio> lstRetorno = new List<MLTipoNegocio>();
                MLTipoNegocio objMLTipoNegocio;

                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                
                foreach (String strLinha in strLinhas)
                {
                    try
                    {
                        objMLTipoNegocio = new MLTipoNegocio();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            objMLTipoNegocio.Codigo = strLinha.Substring(0, 3).Trim();
                            objMLTipoNegocio.Descricao = strLinha.Substring(3, 50).Trim();
                            if (strLinha.Substring(53, 1) == "1")
                            {
                                objMLTipoNegocio.IsStatus = true;
                            }
                            else if (strLinha.Substring(53, 1) == "0")
                            {
                                objMLTipoNegocio.IsStatus = false;
                            }
                            else
                            {
                                plstErros.Add("-Cód.: " + objMLTipoNegocio.Codigo + "(Erro ao ler campo Ativo)");
                            }
                            objMLTipoNegocio.Operacao = strLinha.Substring(54, 1).Trim();

                            lstRetorno.Add(objMLTipoNegocio);
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


