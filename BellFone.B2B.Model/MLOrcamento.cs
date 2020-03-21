using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade Orcamento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    [Serializable]
    public class MLOrcamento
    { 
        #region Propriedades

        /// <summary> 
        /// Recebe o valor de ORC_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_ORIGEM 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Origem { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_ORCAMENTO_LEGADO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string OrcamentoLegado { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_FOP_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Fopcodigo { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_CON_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Concodigo { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_REV_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoRevendedor { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_VEN_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoVendedor { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_TITULO_ORCAMENTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string TituloOrcamento { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_D_EMISSAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public DateTime? DataEmissao { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_NOME_CONSUMIDOR 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string NomeConsumidor { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_ENDERECO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Endereco { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_CONTATO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Contato { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_TELEFONE 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Telefone { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_N_MAO_OBRA 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? MaoObra { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_B_STATUS_MIGRACAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public bool? IsStatusMigracao { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_TPN_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoTipoNegocio { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_REG_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoRegiao { get; set; }

        /// <summary> 
        /// Recebe o valor de Operação na Integração  
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Operacao { get; set; }

        /// <summary> 
        /// Recebe o valor ORC_B_TEMPORARIO 
        /// </summary> 
        /// <user>efranca</user>
        public bool IsTemporario { get; set; }

        /// <summary> 
        /// Recebe o valor ORC_B_GERADO_VENDEDOR 
        /// </summary> 
        /// <user>efranca</user>
        public bool? GeradoVendedor { get; set; }

        /// <summary> 
        /// Recebe o valor ORC_B_ALTERADO 
        /// </summary> 
        /// <user>efranca</user>
        public bool? IsAlterado { get; set; }

        public decimal ValorToral { get; set; }

        public decimal NumeroItens { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["ORC_N_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = Convert.ToDecimal(pobjIDataReader["ORC_N_CODIGO"]);
            }
            if (pobjIDataReader["ORC_C_ORIGEM"] != System.DBNull.Value)
            {
                this.Origem = pobjIDataReader["ORC_C_ORIGEM"].ToString();
            }
            if (pobjIDataReader["ORC_C_ORCAMENTO_LEGADO"] != System.DBNull.Value)
            {
                this.OrcamentoLegado = pobjIDataReader["ORC_C_ORCAMENTO_LEGADO"].ToString();
            }
            if (pobjIDataReader["ORC_FOP_C_CODIGO"] != System.DBNull.Value)
            {
                this.Fopcodigo = pobjIDataReader["ORC_FOP_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["ORC_CON_C_CODIGO"] != System.DBNull.Value)
            {
                this.Concodigo = pobjIDataReader["ORC_CON_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["ORC_REV_C_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoRevendedor = pobjIDataReader["ORC_REV_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["ORC_VEN_C_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoVendedor = pobjIDataReader["ORC_VEN_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["ORC_C_TITULO_ORCAMENTO"] != System.DBNull.Value)
            {
                this.TituloOrcamento = pobjIDataReader["ORC_C_TITULO_ORCAMENTO"].ToString();
            }
            if (pobjIDataReader["ORC_D_EMISSAO"] != System.DBNull.Value)
            {
                this.DataEmissao = Convert.ToDateTime(pobjIDataReader["ORC_D_EMISSAO"]);
            }
            if (pobjIDataReader["ORC_C_NOME_CONSUMIDOR"] != System.DBNull.Value)
            {
                this.NomeConsumidor = pobjIDataReader["ORC_C_NOME_CONSUMIDOR"].ToString();
            }
            if (pobjIDataReader["ORC_C_ENDERECO"] != System.DBNull.Value)
            {
                this.Endereco = pobjIDataReader["ORC_C_ENDERECO"].ToString();
            }
            if (pobjIDataReader["ORC_C_CONTATO"] != System.DBNull.Value)
            {
                this.Contato = pobjIDataReader["ORC_C_CONTATO"].ToString();
            }
            if (pobjIDataReader["ORC_C_TELEFONE"] != System.DBNull.Value)
            {
                this.Telefone = pobjIDataReader["ORC_C_TELEFONE"].ToString();
            }
            if (pobjIDataReader["ORC_B_STATUS_MIGRACAO"] != System.DBNull.Value)
            {
                this.IsStatusMigracao = Convert.ToBoolean(pobjIDataReader["ORC_B_STATUS_MIGRACAO"]);
            }
            if (pobjIDataReader["ORC_TPN_C_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoTipoNegocio = pobjIDataReader["ORC_TPN_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["ORC_REG_C_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoRegiao = pobjIDataReader["ORC_REG_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["ORC_B_TEMPORARIO"] != System.DBNull.Value)
            {
                this.IsTemporario = Convert.ToBoolean(pobjIDataReader["ORC_B_TEMPORARIO"]);
            }
            if (pobjIDataReader["ORC_B_GERADO_VENDEDOR"] != System.DBNull.Value)
            {
                this.GeradoVendedor = Convert.ToBoolean(pobjIDataReader["ORC_B_GERADO_VENDEDOR"]);
            }
            if (pobjIDataReader["ORC_B_ALTERADO"] != System.DBNull.Value)
            {
                this.IsAlterado = Convert.ToBoolean(pobjIDataReader["ORC_B_ALTERADO"]);
            }

            if (pobjIDataReader["ORC_N_MAO_OBRA"] != System.DBNull.Value)
            {
                this.MaoObra = Convert.ToDecimal(pobjIDataReader["ORC_N_MAO_OBRA"]);
            }
            
        }

        #endregion

        #region Conversor Arquivo de Interação para dados do Orcamento

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLOrcamento> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            try
            {
                List<MLOrcamento> lstRetorno = new List<MLOrcamento>();
                MLOrcamento objMLOrcamento;

                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (String strLinha in strLinhas)
                {
                    Decimal deValorDecimal;
                    DateTime dtValorDateTime;

                    try
                    {
                        objMLOrcamento = new MLOrcamento();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            if (Decimal.TryParse(strLinha.Substring(0, 18).Trim(), out deValorDecimal))
                            {
                                objMLOrcamento.Codigo = deValorDecimal;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Código)");
                            }
                            objMLOrcamento.Origem = strLinha.Substring(18, 3).Trim();
                            objMLOrcamento.OrcamentoLegado = strLinha.Substring(21, 6).Trim();
                            objMLOrcamento.Fopcodigo = strLinha.Substring(27, 2).Trim();
                            objMLOrcamento.Concodigo = strLinha.Substring(29, 3).Trim();
                            objMLOrcamento.CodigoRevendedor = strLinha.Substring(32, 5).Trim();
                            objMLOrcamento.CodigoVendedor = strLinha.Substring(37, 3).Trim();
                            objMLOrcamento.TituloOrcamento = strLinha.Substring(40, 50).Trim();
                            if (DateTime.TryParse(strLinha.Substring(90, 10), out dtValorDateTime))
                            {
                                objMLOrcamento.DataEmissao = dtValorDateTime;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Data de Emissão)");
                            }
                            objMLOrcamento.NomeConsumidor = strLinha.Substring(100, 50).Trim();
                            objMLOrcamento.Endereco = strLinha.Substring(150, 50).Trim();
                            objMLOrcamento.Contato = strLinha.Substring(200, 20).Trim();
                            objMLOrcamento.Telefone = strLinha.Substring(220, 20).Trim();
                            if (strLinha.Substring(240, 1) == "1")
                            {
                                objMLOrcamento.IsStatusMigracao = true;
                            }
                            else if (strLinha.Substring(240, 1) == "0")
                            {
                                objMLOrcamento.IsStatusMigracao = false;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Ativo)");
                            }
                            objMLOrcamento.CodigoTipoNegocio = strLinha.Substring(241, 3).Trim();
                            objMLOrcamento.CodigoRegiao = strLinha.Substring(244, 3).Trim();
                            objMLOrcamento.Operacao = strLinha.Substring(247, 1).Trim();

                            lstRetorno.Add(objMLOrcamento);
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

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public String FromArquivoIntegracaoExportar(List<MLOrcamento> plistMLOrcamento)
        {
            String strArquivo = "";
            String strBranco = "";

            if (plistMLOrcamento.Count == 0)
                return "";
            MLOrcamento obj = plistMLOrcamento[0];
            /*foreach (MLOrcamento obj in plistMLOrcamento)
            {*/
                strArquivo += obj.Codigo.ToString().PadLeft(5);
//                strArquivo += obj.Origem.ToString().PadLeft(3);
                /*if (!String.IsNullOrEmpty(obj.OrcamentoLegado))
                {
                    strArquivo += obj.OrcamentoLegado.ToString().PadRight(6);
                }
                else
                {
                    strArquivo += strBranco.PadRight(6);
                }*/
                strArquivo += obj.CodigoRevendedor.ToString().PadRight(5);
                if (!String.IsNullOrEmpty(obj.TituloOrcamento))
                {
                    strArquivo += obj.TituloOrcamento.ToString().PadRight(50);
                }
                else
                {
                    strArquivo += strBranco.PadRight(50);
                }
                strArquivo += Convert.ToDateTime(obj.DataEmissao.ToString().PadRight(10)).ToString("dd/MM/yyyy");

                strArquivo += obj.ValorToral.ToString().PadLeft(15);
                strArquivo += obj.NumeroItens.ToString().PadLeft(2);

                /*if (Convert.ToBoolean(obj.IsStatusMigracao))
                {
                    strArquivo += "1";
                }
                else
                {
                    strArquivo += "0";
                }*/
                /*if (!String.IsNullOrEmpty(obj.MaoObra.ToString()))
                {
                    strArquivo += obj.MaoObra.ToString().PadRight(14);
                }
                else
                {
                    strArquivo += strBranco.PadRight(50);
                }*/
                //fim
                /*if (!String.IsNullOrEmpty(obj.Fopcodigo))
                {
                    strArquivo += obj.Fopcodigo.ToString().PadRight(2);
                }
                else
                {
                    strArquivo += strBranco.PadRight(2);
                }
                if (!String.IsNullOrEmpty(obj.Concodigo))
                {
                    strArquivo += obj.Concodigo.ToString().PadRight(3);
                }
                else
                {
                    strArquivo += strBranco.PadRight(3);
                }
                
                strArquivo += obj.CodigoVendedor.ToString().PadRight(3);
                
                
                
                if (!String.IsNullOrEmpty(obj.NomeConsumidor))
                {
                    strArquivo += obj.NomeConsumidor.ToString().PadRight(50);
                }
                else
                {
                    strArquivo += strBranco.PadRight(50);
                }

                if (!String.IsNullOrEmpty(obj.Endereco))
                {
                    strArquivo += obj.Endereco.ToString().PadRight(50);
                }
                else
                {
                    strArquivo += strBranco.PadRight(50);
                }
                if (!String.IsNullOrEmpty(obj.Contato))
                {
                    strArquivo += obj.Contato.ToString().PadRight(20);
                }
                else
                {
                    strArquivo += strBranco.PadRight(20);
                }
                if (!String.IsNullOrEmpty(obj.Telefone))
                {
                    strArquivo += obj.Telefone.ToString().PadRight(20);
                }
                else
                {
                    strArquivo += strBranco.PadRight(20);
                }
                
                if (!String.IsNullOrEmpty(obj.CodigoTipoNegocio))
                {
                    strArquivo += obj.CodigoTipoNegocio.ToString().PadRight(3);
                }
                else
                {
                    strArquivo += strBranco.PadRight(3);
                }
                if (!String.IsNullOrEmpty(obj.CodigoRegiao))
                {
                    strArquivo += obj.CodigoRegiao.ToString().PadRight(3);
                }
                else
                {
                    strArquivo += strBranco.PadRight(3);
                }
                if (obj.IsAlterado.HasValue)
                {
                    if (obj.IsAlterado.Value)
                    {
                        strArquivo += "A";
                    }
                    else
                    {
                        strArquivo += "I";
                    } 
                }
                else
                {
                    strArquivo += "I";
                }*/ 
                strArquivo += "\r\n";
            //}    

            return strArquivo;
        }

        #endregion
    }

    /// <summary> 
    /// Model da Entidade Orcamento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    [Serializable]
    public class MLOrcamentoCompleto : MLOrcamento
    {
        #region Propriedades
        
        /// <summary> 
        /// Recebe o valor de Operação na Integração  
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Região { get; set; }

        /// <summary> 
        /// Recebe o valor de Operação na Integração  
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string TipoNegocio { get; set; }

        /// <summary> 
        /// Recebe o valor de Operação na Integração  
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string NomeRevendedor { get; set; }

        /// <summary> 
        /// Recebe o valor de Operação na Integração  
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string NomeVendedor { get; set; }

        /// <summary> 
        /// Recebe o valor de Operação na Integração  
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CondicaoPagamento { get; set; }

        /// <summary> 
        /// Recebe o valor de Operação na Integração  
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string FormaPagamento { get; set; }
        
    
        /// <summary> 
        /// Recebe o valor de ORC_N_TOTAL 
        /// </summary> 
        /// <user>efranca</user>
        public decimal? Total { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            base.FromIDataReader(pobjIDataReader);

            if (pobjIDataReader["TPN_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.TipoNegocio = pobjIDataReader["TPN_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["REG_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.Região = pobjIDataReader["REG_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["REV_C_RAZAO_SOCIAL"] != System.DBNull.Value)
            {
                this.NomeRevendedor = pobjIDataReader["REV_C_RAZAO_SOCIAL"].ToString();
            }
            if (pobjIDataReader["CON_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.CondicaoPagamento = pobjIDataReader["CON_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["FOP_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.FormaPagamento = pobjIDataReader["FOP_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["VEN_C_NOME"] != System.DBNull.Value)
            {
                this.NomeVendedor = pobjIDataReader["VEN_C_NOME"].ToString();
            }
            if (pobjIDataReader["ORC_N_TOTAL"] != System.DBNull.Value)
            {
                this.Total = Convert.ToDecimal(pobjIDataReader["ORC_N_TOTAL"]);
            }


        }

        #endregion
    }
}


