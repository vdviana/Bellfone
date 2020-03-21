using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade Revendedor 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class MLRevendedor
    {
        #region Propriedades

        /// <summary> 
        /// Recebe o valor de REV_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de REV_USU_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? CodigoUsuario { get; set; }

        /// <summary> 
        /// Recebe o valor de REV_VEN_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoVendedor { get; set; }

        /// <summary> 
        /// Recebe o valor de REV_C_RAZAO_SOCIAL 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string RazaoSocial { get; set; }

        /// <summary> 
        /// Recebe o valor de REV_C_DOC 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Doc { get; set; }

        /// <summary> 
        /// Recebe o valor de REV_C_IE 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Ie { get; set; }

        /// <summary> 
        /// Recebe o valor de REV_C_EMAIL 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Email { get; set; }

        /// <summary> 
        /// Recebe o valor de REV_C_ENDERECO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Endereco { get; set; }

        /// <summary> 
        /// Recebe o valor de REV_B_ATIVO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public bool? IsAtivo { get; set; }

        /// <summary> 
        /// Recebe o valor de REV_C_TIPO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Tipo { get; set; }

        /// <summary> 
        /// Recebe o valor de REV_C_TIPO_REVENDA 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string TipoRevenda { get; set; }

        /// <summary> 
        /// Recebe o valor de REV_C_CLASSIFICACAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Classificacao { get; set; }

        /// <summary> 
        /// Recebe o valor de REV_C_CLASSIFICACAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Operacao { get; set; }

        /// <summary> 
        /// Recebe o da Senha na Integração para usar na criação do Usuario 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Senha { get; set; }

        /// <summary> 
        /// Recebe o Telefone do Revendedor 
        /// </summary> 
        /// <user>efranca</user>
        public string Telefone { get; set; }

        /// <summary> 
        /// Recebe o Contato do Revendedor 
        /// </summary> 
        /// <user>efranca</user>
        public string Contato { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["REV_C_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = pobjIDataReader["REV_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["REV_USU_N_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoUsuario = Convert.ToDecimal(pobjIDataReader["REV_USU_N_CODIGO"]);
            }
            if (pobjIDataReader["REV_VEN_C_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoVendedor = pobjIDataReader["REV_VEN_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["REV_C_RAZAO_SOCIAL"] != System.DBNull.Value)
            {
                this.RazaoSocial = pobjIDataReader["REV_C_RAZAO_SOCIAL"].ToString();
            }
            if (pobjIDataReader["REV_C_DOC"] != System.DBNull.Value)
            {
                this.Doc = pobjIDataReader["REV_C_DOC"].ToString();
            }
            if (pobjIDataReader["REV_C_IE"] != System.DBNull.Value)
            {
                this.Ie = pobjIDataReader["REV_C_IE"].ToString();
            }
            if (pobjIDataReader["REV_C_EMAIL"] != System.DBNull.Value)
            {
                this.Email = pobjIDataReader["REV_C_EMAIL"].ToString();
            }
            if (pobjIDataReader["REV_C_ENDERECO"] != System.DBNull.Value)
            {
                this.Endereco = pobjIDataReader["REV_C_ENDERECO"].ToString();
            }
            if (pobjIDataReader["REV_B_ATIVO"] != System.DBNull.Value)
            {
                this.IsAtivo = Convert.ToBoolean(pobjIDataReader["REV_B_ATIVO"]);
            }
            if (pobjIDataReader["REV_C_TIPO"] != System.DBNull.Value)
            {
                this.Tipo = pobjIDataReader["REV_C_TIPO"].ToString();
            }
            if (pobjIDataReader["REV_C_TIPO_REVENDA"] != System.DBNull.Value)
            {
                this.TipoRevenda = pobjIDataReader["REV_C_TIPO_REVENDA"].ToString();
            }
            if (pobjIDataReader["REV_C_CLASSIFICACAO"] != System.DBNull.Value)
            {
                this.Classificacao = pobjIDataReader["REV_C_CLASSIFICACAO"].ToString();
            }
            if (pobjIDataReader["REV_C_TELEFONE"] != System.DBNull.Value)
            {
                this.Telefone = pobjIDataReader["REV_C_TELEFONE"].ToString();
            }
            if (pobjIDataReader["REV_C_CONTATO"] != System.DBNull.Value)
            {
                this.Contato = pobjIDataReader["REV_C_CONTATO"].ToString();
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados do revendedor

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLRevendedor> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            List<MLRevendedor> lstRetorno = new List<MLRevendedor>();
            MLRevendedor objMLRevendedor;

            String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            
            foreach (String strLinha in strLinhas)
            {
                try
                {
                    objMLRevendedor = new MLRevendedor();

                    if (!string.IsNullOrEmpty(strLinha))
                    {
                        objMLRevendedor.Codigo = strLinha.Substring(0, 5).Trim();
                        objMLRevendedor.CodigoVendedor = strLinha.Substring(5, 3).Trim();
                        objMLRevendedor.RazaoSocial = strLinha.Substring(8, 50).Trim();
                        objMLRevendedor.Doc = strLinha.Substring(58, 18).Trim();
                        objMLRevendedor.Ie = strLinha.Substring(76, 20).Trim();
                        objMLRevendedor.Email = strLinha.Substring(96, 100).Trim();
                        objMLRevendedor.Endereco = strLinha.Substring(196, 50).Trim();
                        objMLRevendedor.Senha = strLinha.Substring(246, 200).Trim();
                        if (strLinha.Substring(446, 1) == "1")
                        {
                            objMLRevendedor.IsAtivo = true;
                        }
                        else if (strLinha.Substring(446, 1) == "0")
                        {
                            objMLRevendedor.IsAtivo = false;
                        }
                        else
                        {
                            plstErros.Add("-Cód.: " + objMLRevendedor.Codigo + "(Erro ao ler campo Ativo)");
                        }
                        objMLRevendedor.Tipo = strLinha.Substring(447, 1).Trim();
                        objMLRevendedor.TipoRevenda = strLinha.Substring(448, 1).Trim();
                        objMLRevendedor.Classificacao = strLinha.Substring(449, 1).Trim();

                        if (strLinha.Length == 451)
                        {
                            objMLRevendedor.Operacao = strLinha.Substring(450, 1).Trim();
                        }
                        else if (strLinha.Length == 571)
                        {
                            objMLRevendedor.Telefone = strLinha.Substring(450, 20).Trim();
                            objMLRevendedor.Contato = strLinha.Substring(470, 100).Trim();
                            objMLRevendedor.Operacao = strLinha.Substring(570, 1).Trim();
                        }                                              

                        lstRetorno.Add(objMLRevendedor);
                    }
                }
                catch (Exception ex)
                {
                    plstErros.Add("Erro ao ler registro: " + ex.Message);
                }

            }

            return lstRetorno;
        }
                
        #endregion
    }

    /// <summary> 
    /// Model da Entidade Revendedor 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class MLRevendedorCompleto : MLRevendedor
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

        /// <summary> 
        /// Recebe o valor de VEN_USU_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? VendedorUsuario { get; set; }

        /// <summary> 
        /// Recebe o valor de [VEN_C_NOME] 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string VendedorNome { get; set; }

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

            if (pobjIDataReader["VEN_USU_N_CODIGO"] != System.DBNull.Value)
            {
                this.VendedorUsuario = Convert.ToDecimal(pobjIDataReader["VEN_USU_N_CODIGO"]);
            }

            if (pobjIDataReader["VEN_C_NOME"] != System.DBNull.Value)
            {
                this.VendedorNome = pobjIDataReader["VEN_C_NOME"].ToString();
            }
        }

        #endregion
    }
}


