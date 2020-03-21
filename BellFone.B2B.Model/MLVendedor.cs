using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade Vendedor 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class MLVendedor
    {
        #region Propriedades

        /// <summary> 
        /// Recebe o valor de VEN_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de VEN_USU_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? CodigoUsuario { get; set; }

        /// <summary> 
        /// Recebe o valor de VEN_C_NOME 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Nome { get; set; }

        /// <summary> 
        /// Recebe o valor de VEN_C_RAMAL 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Ramal { get; set; }

        /// <summary> 
        /// Recebe o valor de VEN_C_EMAIL1 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Email1 { get; set; }

        /// <summary> 
        /// Recebe o valor de VEN_C_EMAIL2 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Email2 { get; set; }

        /// <summary> 
        /// Recebe o valor de VEN_B_ATIVO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public bool? IsAtivo { get; set; }

        /// <summary> 
        /// Recebe o valor da Operação na Integração 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Operacao { get; set; }

        /// <summary> 
        /// Recebe o da Senha na Integração para usar na criação do Usuario 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Senha { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["VEN_C_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = pobjIDataReader["VEN_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["VEN_USU_N_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoUsuario = Convert.ToDecimal(pobjIDataReader["VEN_USU_N_CODIGO"]);
            }
            if (pobjIDataReader["VEN_C_NOME"] != System.DBNull.Value)
            {
                this.Nome = pobjIDataReader["VEN_C_NOME"].ToString();
            }
            if (pobjIDataReader["VEN_C_RAMAL"] != System.DBNull.Value)
            {
                this.Ramal = pobjIDataReader["VEN_C_RAMAL"].ToString();
            }
            if (pobjIDataReader["VEN_C_EMAIL1"] != System.DBNull.Value)
            {
                this.Email1 = pobjIDataReader["VEN_C_EMAIL1"].ToString();
            }
            if (pobjIDataReader["VEN_C_EMAIL2"] != System.DBNull.Value)
            {
                this.Email2 = pobjIDataReader["VEN_C_EMAIL2"].ToString();
            }
            if (pobjIDataReader["VEN_B_ATIVO"] != System.DBNull.Value)
            {
                this.IsAtivo = Convert.ToBoolean(pobjIDataReader["VEN_B_ATIVO"]);
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados do vendedor

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLVendedor> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            try
            {                
                List<MLVendedor> lstRetorno = new List<MLVendedor>();
                MLVendedor objMLVendedor;

                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                
                foreach (String strLinha in strLinhas)
                {
                    try
                    {
                        objMLVendedor = new MLVendedor();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            objMLVendedor.Codigo = strLinha.Substring(0, 3).Trim();
                            objMLVendedor.Nome = strLinha.Substring(3, 50).Trim();
                            objMLVendedor.Ramal = strLinha.Substring(53, 5).Trim();
                            objMLVendedor.Email1 = strLinha.Substring(58, 100).Trim();
                            objMLVendedor.Email2 = strLinha.Substring(158, 100).Trim();
                            if (strLinha.Substring(258, 1) == "1")
                            {
                                objMLVendedor.IsAtivo = true;
                            }
                            else if (strLinha.Substring(258, 1) == "0")
                            {
                                objMLVendedor.IsAtivo = false;
                            }
                            else
                            {
                                plstErros.Add("-Cód.: " + objMLVendedor.Codigo + "(Erro ao ler campo Ativo)");
                            }
                            objMLVendedor.Operacao = strLinha.Substring(259, 1).Trim();
                            objMLVendedor.Senha = strLinha.Substring(260, 200).Trim();

                            lstRetorno.Add(objMLVendedor);
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

    /// <summary> 
    /// Model da Entidade Vendedor 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class MLVendedorCompleto : MLVendedor
    {
        #region Propriedades

        /// <summary> 
        /// Recebe o valor de [USU_C_LOGIN] 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Login { get; set; }

        /// <summary> 
        /// Recebe o valor de [USU_C_SENHA] 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Senha { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            base.FromIDataReader(pobjIDataReader);

            if (pobjIDataReader["USU_C_LOGIN"] != System.DBNull.Value)
            {
                this.Login = pobjIDataReader["USU_C_LOGIN"].ToString();
            }

            if (pobjIDataReader["USU_C_SENHA"] != System.DBNull.Value)
            {
                this.Senha = pobjIDataReader["USU_C_SENHA"].ToString();
            }
        }

        #endregion
    }      
}
 

