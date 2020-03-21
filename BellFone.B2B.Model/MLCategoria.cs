using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade Categoria 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class MLCategoria
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de CAT_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de CAT_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Descricao { get; set; }

        /// <summary> 
        /// Recebe o valor de CAT_B_ATIVO 
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
            if (pobjIDataReader["CAT_C_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = pobjIDataReader["CAT_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["CAT_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.Descricao = pobjIDataReader["CAT_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["CAT_B_ATIVO"] != System.DBNull.Value)
            {
                this.IsAtivo = Convert.ToBoolean(pobjIDataReader["CAT_B_ATIVO"]);
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados da categoria

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLCategoria> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            List<MLCategoria> lstRetorno = new List<MLCategoria>();
            MLCategoria objMLCategoria;

            try
            {                
                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (String strLinha in strLinhas)
                {
                    try
                    {
                        objMLCategoria = new MLCategoria();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            objMLCategoria.Codigo = strLinha.Substring(0, 3).Trim();
                            objMLCategoria.Descricao = strLinha.Substring(3, 50).Trim();
                            if (strLinha.Substring(53, 1) == "1")
                            {
                                objMLCategoria.IsAtivo = true;
                            }
                            else if (strLinha.Substring(53, 1) == "0")
                            {
                                objMLCategoria.IsAtivo = false;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 3).Trim() + "(Erro ao ler campo Ativo)");
                            }
                            objMLCategoria.Operacao = strLinha.Substring(54, 1).Trim();

                            lstRetorno.Add(objMLCategoria);
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


