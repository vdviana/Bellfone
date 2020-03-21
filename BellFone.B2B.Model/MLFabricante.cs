using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade Fabricante 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class MLFabricante
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de FAB_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de FAB_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Descricao { get; set; }

        /// <summary> 
        /// Recebe o valor de FAB_B_ATIVO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public bool? IsAtivo { get; set; }

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
            if (pobjIDataReader["FAB_C_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = pobjIDataReader["FAB_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["FAB_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.Descricao = pobjIDataReader["FAB_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["FAB_B_ATIVO"] != System.DBNull.Value)
            {
                this.IsAtivo = Convert.ToBoolean(pobjIDataReader["FAB_B_ATIVO"]);
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados do Fabricante

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLFabricante> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            try
            {
                List<MLFabricante> lstRetorno = new List<MLFabricante>();
                MLFabricante objMLFabricante;

                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (String strLinha in strLinhas)
                {
                    try
                    {
                        objMLFabricante = new MLFabricante();

                        if (!string.IsNullOrEmpty(strLinha))
                        {

                            objMLFabricante.Codigo = strLinha.Substring(0, 5).Trim();
                            objMLFabricante.Descricao = strLinha.Substring(7, 50).Trim();
                            if (strLinha.Substring(57, 1) == "1")
                            {
                                objMLFabricante.IsAtivo = true;
                            }
                            else if (strLinha.Substring(57, 1) == "0")
                            {
                                objMLFabricante.IsAtivo = false;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 4).Trim() + "(Erro ao ler campo Ativo)");
                            }
                            objMLFabricante.Operacao = strLinha.Substring(58, 1).Trim();

                            lstRetorno.Add(objMLFabricante);

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


