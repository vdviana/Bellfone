using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade OrcamentoItem 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user>
    [Serializable] 
    public class MLOrcamentoItem
    {
        #region Propriedades

        /// <summary> 
        /// Recebe o valor de ORI_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de ORI_ORC_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? CodigoOrcamento { get; set; }

        /// <summary> 
        /// Recebe o valor de ORI_C_ORIGEM 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Origem { get; set; }

        /// <summary> 
        /// Recebe o valor de ORI_C_ITEM_ORCAMENTO_LEGADO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string ItemOrcamentoLegado { get; set; }

        /// <summary> 
        /// Recebe o valor de ORI_PRO_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Procodigo { get; set; }

        /// <summary> 
        /// Recebe o valor de ORI_D_CRIACAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public DateTime? DataCriacao { get; set; }

        /// <summary> 
        /// Recebe o valor de ORI_N_QUANTIDADE 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? Quantidade { get; set; }

        /// <summary> 
        /// Recebe o valor de ORI_N_PRECO_SUGERIDO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? PrecoSugerido { get; set; }

        /// <summary> 
        /// Recebe o valor de ORI_N_PRECO_APLICADO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? PrecoAplicado { get; set; }

        /// <summary> 
        /// Recebe o valor de ORI_STI_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoStatusItemOrcamento { get; set; }

        /// <summary> 
        /// Recebe o valor de ORI_C_SITUACAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Situacao { get; set; }

        /// <summary> 
        /// Recebe o valor de ORI_B_STATUS_MIGRACAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public bool? IsStatusMigracao { get; set; }

        /// <summary> 
        /// Recebe o valor de ORI_C_SITUACAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Operacao { get; set; }

        /// <summary> 
        /// Recebe o valor do Valor informado pelo Revendedor 
        /// </summary> 
        /// <user>efranca</user>
        public decimal? PrecoRevendedor { get; set; }

        /// <summary> 
        /// Recebe o valor ORI_B_ALTERADO 
        /// </summary> 
        /// <user>efranca</user>
        public bool? IsAlterado { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["ORI_N_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = Convert.ToDecimal(pobjIDataReader["ORI_N_CODIGO"]);
            }
            if (pobjIDataReader["ORI_ORC_N_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoOrcamento = Convert.ToDecimal(pobjIDataReader["ORI_ORC_N_CODIGO"]);
            }
            if (pobjIDataReader["ORI_C_ORIGEM"] != System.DBNull.Value)
            {
                this.Origem = pobjIDataReader["ORI_C_ORIGEM"].ToString();
            }
            if (pobjIDataReader["ORI_C_ITEM_ORCAMENTO_LEGADO"] != System.DBNull.Value)
            {
                this.ItemOrcamentoLegado = pobjIDataReader["ORI_C_ITEM_ORCAMENTO_LEGADO"].ToString();
            }
            if (pobjIDataReader["ORI_PRO_N_CODIGO"] != System.DBNull.Value)
            {
                this.Procodigo = pobjIDataReader["ORI_PRO_N_CODIGO"].ToString();
            }
            if (pobjIDataReader["ORI_D_CRIACAO"] != System.DBNull.Value)
            {
                this.DataCriacao = Convert.ToDateTime(pobjIDataReader["ORI_D_CRIACAO"]);
            }
            if (pobjIDataReader["ORI_N_QUANTIDADE"] != System.DBNull.Value)
            {
                this.Quantidade = Convert.ToDecimal(pobjIDataReader["ORI_N_QUANTIDADE"]);
            }
            if (pobjIDataReader["ORI_N_PRECO_SUGERIDO"] != System.DBNull.Value)
            {
                this.PrecoSugerido = Convert.ToDecimal(pobjIDataReader["ORI_N_PRECO_SUGERIDO"]);
            }
            if (pobjIDataReader["ORI_N_PRECO_APLICADO"] != System.DBNull.Value)
            {
                this.PrecoAplicado = Convert.ToDecimal(pobjIDataReader["ORI_N_PRECO_APLICADO"]);
            }
            if (pobjIDataReader["ORI_STI_C_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoStatusItemOrcamento = pobjIDataReader["ORI_STI_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["ORI_C_SITUACAO"] != System.DBNull.Value)
            {
                this.Situacao = pobjIDataReader["ORI_C_SITUACAO"].ToString();
            }
            if (pobjIDataReader["ORI_B_STATUS_MIGRACAO"] != System.DBNull.Value)
            {
                this.IsStatusMigracao = Convert.ToBoolean(pobjIDataReader["ORI_B_STATUS_MIGRACAO"]);
            }
            if (pobjIDataReader["ORI_B_ALTERADO"] != System.DBNull.Value)
            {
                this.IsAlterado = Convert.ToBoolean(pobjIDataReader["ORI_B_ALTERADO"]);
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados do Orcamento Item

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLOrcamentoItem> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            try
            {
                List<MLOrcamentoItem> lstRetorno = new List<MLOrcamentoItem>();
                MLOrcamentoItem objMLOrcamentoItem;
                Decimal deValorDecimal;
                DateTime dtValorDateTime;

                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (String strLinha in strLinhas)
                {
                    try
                    {
                        objMLOrcamentoItem = new MLOrcamentoItem();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            if (Decimal.TryParse(strLinha.Substring(0, 18).Trim(), out deValorDecimal))
                            {
                                objMLOrcamentoItem.Codigo = deValorDecimal;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Código)");
                            }
                            if (Decimal.TryParse(strLinha.Substring(18, 18).Trim(), out deValorDecimal))
                            {
                                objMLOrcamentoItem.CodigoOrcamento = deValorDecimal;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Código do Orçamento)");
                            }
                            objMLOrcamentoItem.Origem = strLinha.Substring(36, 3).Trim();
                            objMLOrcamentoItem.ItemOrcamentoLegado = strLinha.Substring(39, 6).Trim();
                            objMLOrcamentoItem.Procodigo = strLinha.Substring(45, 13).Trim();
                            if (DateTime.TryParse(strLinha.Substring(58, 10), out dtValorDateTime))
                            {
                                objMLOrcamentoItem.DataCriacao = dtValorDateTime;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Data de Criação)");
                            }
                            if (Decimal.TryParse(strLinha.Substring(68, 18).Trim(), out deValorDecimal))
                            {
                                objMLOrcamentoItem.Quantidade = deValorDecimal;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Quantidade)");
                            }
                            //campo não esta sendo mais usado.
                            objMLOrcamentoItem.PrecoSugerido = 0;
                            
                            if (Decimal.TryParse(strLinha.Substring(100, 14).Trim(), out deValorDecimal))
                            {
                                objMLOrcamentoItem.PrecoAplicado = deValorDecimal / 100;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Preço Aplicado)");
                            }
                            objMLOrcamentoItem.CodigoStatusItemOrcamento = strLinha.Substring(114, 3).Trim();
                            objMLOrcamentoItem.Situacao = strLinha.Substring(117, 200).Trim();
                            if (strLinha.Substring(317, 1) == "1")
                            {
                                objMLOrcamentoItem.IsStatusMigracao = true;
                            }
                            else if (strLinha.Substring(317, 1) == "0")
                            {
                                objMLOrcamentoItem.IsStatusMigracao = false;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + strLinha.Substring(0, 18).Trim() + "(Erro ao ler campo Status da Migração)");    
                            }
                            objMLOrcamentoItem.Operacao = strLinha.Substring(318, 1).Trim();

                            lstRetorno.Add(objMLOrcamentoItem);
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
        public String FromArquivoIntegracaoExportar(List<MLOrcamentoItem> plistMLOrcamentoItem)
        {
            String strArquivo = "";
            const string strBranco = "";

            foreach (MLOrcamentoItem obj in plistMLOrcamentoItem)
            {
                //strArquivo += obj.Codigo.ToString().PadRight(18);
                strArquivo += obj.CodigoOrcamento.ToString().PadRight(18);
                //strArquivo += obj.Origem.ToString().PadRight(3);
                /*if (!String.IsNullOrEmpty(obj.ItemOrcamentoLegado))
                {
                    strArquivo += obj.ItemOrcamentoLegado.ToString().PadRight(6);
                }
                else
                {
                    strArquivo += strBranco.PadRight(6);
                }*/
                strArquivo += obj.Procodigo.ToString().PadRight(13);
                //strArquivo += Convert.ToDateTime(obj.DataCriacao.ToString().PadRight(10)).ToString("dd/MM/yyyy");
                strArquivo += obj.Quantidade.ToString().PadRight(18);
                strArquivo += Convert.ToDecimal(obj.PrecoSugerido.ToString()).ToString("N2").PadRight(14);
                strArquivo += Convert.ToDecimal(obj.PrecoAplicado.ToString()).ToString("N2").PadRight(14);
                //strArquivo += obj.CodigoStatusItemOrcamento.ToString().PadRight(3);
                //strArquivo += obj.Situacao.ToString().PadRight(200);
                /*if (Convert.ToBoolean(obj.IsStatusMigracao))
                {
                    strArquivo += "1";
                }
                else
                {
                    strArquivo += "0";
                }*/
                /*
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
                }  */                                 
                                
                strArquivo += "\r\n";
            }

            return strArquivo;
        }

        #endregion
    }

    /// <summary> 
    /// Model da Entidade OrcamentoItem 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user>
    [Serializable]
    public class MLOrcamentoItemCompleto : MLOrcamentoItem
    {
        #region Propriedades

        /// <summary> 
        /// Recebe o valor de PRD_C_NOME 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string ProdutoNome { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_C_LINK 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string ProdutoLink { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_C_CAMINHO_IMAGEM 
        /// </summary> 
        /// <user>efranca</user>
        public string ProdutoCaminhoImagem { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_UNM_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoUnidadeMedida { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_SUB_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoSubgrupo { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_FAB_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoFabricante { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_B_VISIVEL 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public bool? ProdutoIsVisivel { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_B_STATUS 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public bool? ProdutoIsStatus { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string ProdutoDescricao { get; set; }

        /// <summary> 
        /// Recebe o valor de STI_C_DESCICAO 
        /// </summary> 
        /// <user>efranca 09/04/2010</user>
        public string StatusItemOrcamentoDescricao { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            base.FromIDataReader(pobjIDataReader);
            
            if (pobjIDataReader["PRD_C_NOME"] != System.DBNull.Value)
            {
                this.ProdutoNome = pobjIDataReader["PRD_C_NOME"].ToString();
            }
            if (pobjIDataReader["PRD_C_LINK"] != System.DBNull.Value)
            {
                this.ProdutoLink = pobjIDataReader["PRD_C_LINK"].ToString();
            }
            if (pobjIDataReader["PRD_C_CAMINHO_IMAGEM"] != System.DBNull.Value)
            {
                this.ProdutoCaminhoImagem = pobjIDataReader["PRD_C_CAMINHO_IMAGEM"].ToString();
            }
            if (pobjIDataReader["PRD_UNM_C_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoUnidadeMedida = pobjIDataReader["PRD_UNM_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["PRD_SUB_C_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoSubgrupo = pobjIDataReader["PRD_SUB_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["PRD_FAB_C_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoFabricante = pobjIDataReader["PRD_FAB_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["PRD_B_VISIVEL"] != System.DBNull.Value)
            {
                this.ProdutoIsVisivel = Convert.ToBoolean(pobjIDataReader["PRD_B_VISIVEL"]);
            }
            if (pobjIDataReader["PRD_B_STATUS"] != System.DBNull.Value)
            {
                this.ProdutoIsStatus = Convert.ToBoolean(pobjIDataReader["PRD_B_STATUS"]);
            }
            if (pobjIDataReader["PRD_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.ProdutoDescricao = pobjIDataReader["PRD_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["STI_C_DESCICAO"] != System.DBNull.Value)
            {
                this.StatusItemOrcamentoDescricao = pobjIDataReader["STI_C_DESCICAO"].ToString();
            }
        }

        #endregion
        
    }

    /// <summary> 
    /// Model da Entidade OrcamentoItemHistorico 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class MLOrcamentoItemHistorico
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de OIH_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de OIH_ORI_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? CodigoOrcamentoItem { get; set; }

        /// <summary> 
        /// Recebe o valor de OIH_ORI_N_PRECO_SUGERIDO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? PrecoSugeridoOrcamentoItem { get; set; }

        /// <summary> 
        /// Recebe o valor de OIH_D_DATA_ALTERACAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public DateTime? DataAlteracao { get; set; }

        /// <summary> 
        /// Recebe o valor de OIH_USU_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? CodigoUsuario { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["OIH_N_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = Convert.ToDecimal(pobjIDataReader["OIH_N_CODIGO"]);
            }
            if (pobjIDataReader["OIH_ORI_N_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoOrcamentoItem = Convert.ToDecimal(pobjIDataReader["OIH_ORI_N_CODIGO"]);
            }
            if (pobjIDataReader["OIH_ORI_N_PRECO_SUGERIDO"] != System.DBNull.Value)
            {
                this.PrecoSugeridoOrcamentoItem = Convert.ToDecimal(pobjIDataReader["OIH_ORI_N_PRECO_SUGERIDO"]);
            }
            if (pobjIDataReader["OIH_D_DATA_ALTERACAO"] != System.DBNull.Value)
            {
                this.DataAlteracao = Convert.ToDateTime(pobjIDataReader["OIH_D_DATA_ALTERACAO"]);
            }
            if (pobjIDataReader["OIH_USU_N_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoUsuario = Convert.ToDecimal(pobjIDataReader["OIH_USU_N_CODIGO"]);
            }
        }

        #endregion
    }
}


