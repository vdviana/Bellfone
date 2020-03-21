using System;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BellFone.B2B.Model
{
    #region MLProduto
    /// <summary> 
    /// Model da Entidade Produto 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    [Serializable]
    public class MLProduto
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de PRD_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_UNM_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string CodigoUnidadeMedida { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_SUB_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string CodigoSubgrupo { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_FAB_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string CodigoFabricante { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_C_NOME 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string Nome { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_C_LINK 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string Link { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_C_CAMINHO_IMAGEM 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string CaminhoImagem { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string Descricao { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_N_VALOR_ORIGINAL 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public decimal? ValorOriginal { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_N_VALOR_PROMOCIONAL 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public decimal? ValorPromocional { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_C_CLASSIFICACAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string Classificacao { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_B_VISIVEL 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public bool? IsVisivel { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_B_STATUS 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public bool? IsStatus { get; set; }

        /// <summary> 
        /// Recebe o valor de Operação da Integração
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string Operacao { get; set; }

        /// <summary> 
        /// Recebe o valor de mn_valor_de
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public decimal? ValorDe { get; set; }

        /// <summary> 
        /// Recebe o valor de mn_valor_por 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public decimal? ValorPor { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_B_DESTAQUE 
        /// </summary> 
        /// <user>efranca</user>
        public bool? IsDestaque { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_B_SUPER 
        /// </summary> 
        /// <user>efranca</user>
        public bool? IsSuperOferta { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_B_EXISTE_IMAGEM
        /// </summary> 
        /// <user>efranca</user>
        public bool? TemImagem { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["PRD_C_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = pobjIDataReader["PRD_C_CODIGO"].ToString();
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
            if (pobjIDataReader["PRD_C_NOME"] != System.DBNull.Value)
            {
                this.Nome = pobjIDataReader["PRD_C_NOME"].ToString();
                Nome = Nome.Length > 30 ? Nome.Substring(0, 25)+"..." : Nome;
               
            }
            if (pobjIDataReader["PRD_C_LINK"] != System.DBNull.Value)
            {
                this.Link = pobjIDataReader["PRD_C_LINK"].ToString();
            }
            if (pobjIDataReader["PRD_C_CAMINHO_IMAGEM"] != System.DBNull.Value)
            {
                this.CaminhoImagem = pobjIDataReader["PRD_C_CAMINHO_IMAGEM"].ToString();
            }
            if (pobjIDataReader["PRD_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.Descricao = pobjIDataReader["PRD_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["PRD_N_VALOR_ORIGINAL"] != System.DBNull.Value)
            {
                this.ValorOriginal = Convert.ToDecimal(pobjIDataReader["PRD_N_VALOR_ORIGINAL"]);
            }
            if (pobjIDataReader["PRD_N_VALOR_PROMOCIONAL"] != System.DBNull.Value)
            {
                this.ValorPromocional = Convert.ToDecimal(pobjIDataReader["PRD_N_VALOR_PROMOCIONAL"]);
            }
            if (pobjIDataReader["PRD_C_CLASSIFICACAO"] != System.DBNull.Value)
            {
                this.Classificacao = pobjIDataReader["PRD_C_CLASSIFICACAO"].ToString();
                Classificacao = Classificacao.Length < 15 ? "12345678901234567890" : Classificacao.Substring(0, 15);
            }
            if (pobjIDataReader["PRD_B_VISIVEL"] != System.DBNull.Value)
            {
                this.IsVisivel = Convert.ToBoolean(pobjIDataReader["PRD_B_VISIVEL"]);
            }
            if (pobjIDataReader["PRD_B_STATUS"] != System.DBNull.Value)
            {
                this.IsStatus = Convert.ToBoolean(pobjIDataReader["PRD_B_STATUS"]);
            }
            if (pobjIDataReader["mn_valor_de"] != System.DBNull.Value)
            {
                this.ValorDe = Convert.ToDecimal(pobjIDataReader["mn_valor_de"]);
            }
            if (pobjIDataReader["mn_valor_por"] != System.DBNull.Value)
            {
                this.ValorPor = Convert.ToDecimal(pobjIDataReader["mn_valor_por"]);
            }
            if (pobjIDataReader["PRD_B_DESTAQUE"] != System.DBNull.Value)
            {
                this.IsDestaque = Convert.ToBoolean(pobjIDataReader["PRD_B_DESTAQUE"]);
            }
            if (pobjIDataReader["PRD_B_SUPER"] != System.DBNull.Value)
            {
                this.IsSuperOferta = Convert.ToBoolean(pobjIDataReader["PRD_B_SUPER"]);
            }

            if (pobjIDataReader["PRD_B_EXISTE_IMAGEM"] != System.DBNull.Value)
            {
                this.TemImagem = Convert.ToBoolean(pobjIDataReader["PRD_B_EXISTE_IMAGEM"]);
            }
        }

        #endregion

        #region Conversor Arquivo de Interação para dados da categoria

        /// <summary>
        /// Metodo que popula a Model com a String recebida para interação
        /// </summary>
        /// <param name=pstrArquivoInteracao>Arquivo de Interação</param>
        public List<MLProduto> FromArquivoIntegracao(String pstrArquivoIntegracao, ref List<string> plstErros)
        {
            try
            {
                List<MLProduto> lstRetorno = new List<MLProduto>();
                MLProduto objMLProduto;
                Decimal deValorDecimal;

                String[] strLinhas = pstrArquivoIntegracao.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                foreach (String strLinha in strLinhas)
                {
                    try
                    {
                        objMLProduto = new MLProduto();

                        if (!string.IsNullOrEmpty(strLinha))
                        {
                            objMLProduto.Codigo = strLinha.Substring(0, 13).Trim();
                            objMLProduto.Nome = strLinha.Substring(13, 50).Trim();
                            objMLProduto.Link = strLinha.Substring(63, 100).Trim();
                            objMLProduto.CaminhoImagem = strLinha.Substring(163, 100).Trim();
                            objMLProduto.CodigoUnidadeMedida = strLinha.Substring(263, 3).Trim();
                            objMLProduto.CodigoSubgrupo = strLinha.Substring(266, 3).Trim();
                            objMLProduto.CodigoFabricante = strLinha.Substring(269, 5).Trim();
                            if (strLinha.Substring(274, 1) == "1")
                            {
                                objMLProduto.IsVisivel = true;
                            }
                            else if (strLinha.Substring(274, 1) == "0")
                            {
                                objMLProduto.IsVisivel = false;
                            }
                            else
                            {
                                plstErros.Add("- Cód.: " + objMLProduto.Codigo + "(Erro ao ler campo Visivel)");
                            }
                            if (strLinha.Substring(275, 1) == "1")
                            {
                                objMLProduto.IsStatus = true;
                            }
                            else if (strLinha.Substring(275, 1) == "0")
                            {
                                objMLProduto.IsStatus = false;
                            }
                            else
                            {
                                plstErros.Add("Cód.: " + objMLProduto.Codigo + "(Erro ao ler campo Ativo)");
                            }
                            objMLProduto.Classificacao = strLinha.Substring(276, 1).Trim();
                            if (Decimal.TryParse(strLinha.Substring(277, 15).Trim(), out deValorDecimal))
                            {
                                objMLProduto.ValorOriginal = deValorDecimal / 100;
                            }
                            else
                            {
                                plstErros.Add("Cód.: " + objMLProduto.Codigo + "(Erro ao ler campo Valor Original)");
                            }
                            //campo não esta sendo mais usado.
                            objMLProduto.ValorPromocional = 0;
                            
                            objMLProduto.Descricao = strLinha.Substring(292, (strLinha.Length - 2)- 292).Trim();
                            if (strLinha.Substring(strLinha.Length - 2, 1) == "1")
                            {
                                objMLProduto.IsDestaque = true;
                            }
                            else if (strLinha.Substring(strLinha.Length - 2, 1) == "0")
                            {
                                objMLProduto.IsDestaque = false;
                            }
                            else
                            {
                                plstErros.Add("Cód.: " + objMLProduto.Codigo + "(Erro ao ler campo Destaque)");
                            }
                            objMLProduto.Operacao = strLinha.Substring(strLinha.Length - 1, 1).Trim();

                            lstRetorno.Add(objMLProduto);
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
    #endregion
    
    #region MLProdutoCompleto
    /// <summary> 
    /// Model da Entidade Produto 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    [Serializable]
    public class MLProdutoCompleto : MLProduto
    {
        #region Propriedades
        
        /// <summary> 
        /// Recebe o valor de FAB_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string FabricanteDescricao { get; set; }

        /// <summary> 
        /// Recebe o valor de CAT_C_CODIGO  
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CategoriaCodigo { get; set; }

        /// <summary> 
        /// Recebe o valor de CAT_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string CategoriaDescricao { get; set; }

        /// <summary> 
        /// Recebe o valor de GRU_C_CODIGO  
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string GrupoCodigo { get; set; }

        /// <summary> 
        /// Recebe o valor de GRU_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string GrupoDescricao { get; set; }

        /// <summary> 
        /// Recebe o valor de SUB_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string SubGrupoDescricao { get; set; }

        /// <summary> 
        /// Recebe o valor de UNM_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string UnidadeMedidaDescricao { get; set; }

        public decimal ValorPromocionalPorQuantidade { get; set; }

        public int QtdPromocional { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            base.FromIDataReader(pobjIDataReader);
            
            if (pobjIDataReader["FAB_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.FabricanteDescricao = pobjIDataReader["FAB_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["CAT_C_CODIGO"] != System.DBNull.Value)
            {
                this.CategoriaCodigo = pobjIDataReader["CAT_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["CAT_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.CategoriaDescricao = pobjIDataReader["CAT_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["GRU_C_CODIGO"] != System.DBNull.Value)
            {
                this.GrupoCodigo = pobjIDataReader["GRU_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["GRU_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.GrupoDescricao = pobjIDataReader["GRU_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["SUB_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.SubGrupoDescricao = pobjIDataReader["SUB_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["UNM_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.UnidadeMedidaDescricao = pobjIDataReader["UNM_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["PRD_N_VALOR_PROMOCIONAL"] != System.DBNull.Value)
            {
                this.ValorPromocional = Convert.ToDecimal(pobjIDataReader["PRD_N_VALOR_PROMOCIONAL"].ToString());
            }
            if (pobjIDataReader["PRD_N_QTD_PROMO"] != System.DBNull.Value)
            {
                this.QtdPromocional = Convert.ToInt32(pobjIDataReader["PRD_N_QTD_PROMO"].ToString());
            }
        }

        #endregion
    }
    #endregion

    #region MLProdutoBusca
    /// <summary> 
    /// Model da Entidade Produto 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    [Serializable]
    public class MLProdutoBusca
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de PRD_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_C_NOME 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string Nome { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["PRD_C_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = pobjIDataReader["PRD_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["PRD_C_NOME"] != System.DBNull.Value)
            {
                this.Nome = pobjIDataReader["PRD_C_NOME"].ToString();
            }           
        }

        #endregion

    }
    #endregion
}


