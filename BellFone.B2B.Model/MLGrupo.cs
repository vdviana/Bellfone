using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade Grupo 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class MLGrupo
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de GRU_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de GRU_CAT_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string CodigoCategoria { get; set; }

        /// <summary> 
        /// Recebe o valor de GRU_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Descricao { get; set; }

        /// <summary> 
        /// Recebe o valor de GRU_B_ATIVO 
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
            if (pobjIDataReader["GRU_C_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = pobjIDataReader["GRU_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["GRU_CAT_C_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoCategoria = pobjIDataReader["GRU_CAT_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["GRU_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.Descricao = pobjIDataReader["GRU_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["GRU_B_ATIVO"] != System.DBNull.Value)
            {
                this.IsAtivo = Convert.ToBoolean(pobjIDataReader["GRU_B_ATIVO"]);
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados da categoria

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLGrupo> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            try
            {
                List<MLGrupo> lstRetorno = new List<MLGrupo>();
                MLGrupo objMLGrupo;

                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (String strLinha in strLinhas)
                {
                    try
                    {
                        objMLGrupo = new MLGrupo();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            objMLGrupo.CodigoCategoria = strLinha.Substring(0, 3).Trim();
                            objMLGrupo.Codigo = strLinha.Substring(3, 3).Trim();
                            objMLGrupo.Descricao = strLinha.Substring(6, 50).Trim();
                            if (strLinha.Substring(56, 1) == "1")
                            {
                                objMLGrupo.IsAtivo = true;
                            }
                            else if (strLinha.Substring(56, 1) == "0")
                            {
                                objMLGrupo.IsAtivo = false;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 3).Trim() + "(Erro ao ler campo Ativo)");
                            }

                            objMLGrupo.Operacao = strLinha.Substring(57, 1).Trim();

                            lstRetorno.Add(objMLGrupo);
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


