using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade Subgrupo 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class MLSubgrupo
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de SUB_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de SUB_GRU_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string CodigoGrupo { get; set; }

        /// <summary> 
        /// Recebe o valor de SUB_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Descricao { get; set; }

        /// <summary> 
        /// Recebe o valor de SUB_B_ATIVO 
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
            if (pobjIDataReader["SUB_C_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = pobjIDataReader["SUB_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["SUB_GRU_C_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoGrupo = pobjIDataReader["SUB_GRU_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["SUB_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.Descricao = pobjIDataReader["SUB_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["SUB_B_ATIVO"] != System.DBNull.Value)
            {
                this.IsAtivo = Convert.ToBoolean(pobjIDataReader["SUB_B_ATIVO"]);
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados do vendedor

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLSubgrupo> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            try
            {
                List<MLSubgrupo> lstRetorno = new List<MLSubgrupo>();
                MLSubgrupo objMLSubgrupo;

                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (String strLinha in strLinhas)
                {
                    try
                    {
                        objMLSubgrupo = new MLSubgrupo();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            objMLSubgrupo.CodigoGrupo = strLinha.Substring(0, 3).Trim();
                            objMLSubgrupo.Codigo = strLinha.Substring(3, 3).Trim();
                            objMLSubgrupo.Descricao = strLinha.Substring(6, 50).Trim();
                            if (strLinha.Substring(56, 1) == "1")
                            {
                                objMLSubgrupo.IsAtivo = true;
                            }
                            else if (strLinha.Substring(56, 1) == "0")
                            {
                                objMLSubgrupo.IsAtivo = false;
                            }
                            else
                            {
                                plstErros.Add("-Cód.: " + objMLSubgrupo.Codigo + "(Erro ao ler campo Ativo)");
                            }

                            objMLSubgrupo.Operacao = strLinha.Substring(57, 1).Trim();

                            lstRetorno.Add(objMLSubgrupo);
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


