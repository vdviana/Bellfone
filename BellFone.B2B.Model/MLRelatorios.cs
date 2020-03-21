using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BellFone.B2B.Model
{
    #region Orçamentos/Pedido/Faturado

    /// <summary> 
    /// Model da Entidade Orcamento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    [Serializable]
    public class MLOrcamentoRelatorio
    {
        #region Propriedades

        //Orçamento

        /// <summary> 
        /// Recebe o valor de ORC_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? OrcamentoCodigo { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_ORIGEM 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string OrcamentoOrigem { get; set; }

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
        /// Recebe o valor se Orçamento é Temporario 
        /// </summary> 
        /// <user>efranca</user>
        public bool IsTemporario { get; set; }

        /// <summary> 
        /// Recebe o valor ORC_B_GERADO_VENDEDOR 
        /// </summary> 
        /// <user>efranca</user>
        public bool GeradoVendedor { get; set; }


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

        //Orçamento Item

        /// <summary> 
        /// Recebe o valor de ORI_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? OrcamentoItemCodigo { get; set; }

        /// <summary> 
        /// Recebe o valor de ORI_C_ORIGEM 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string OrcamentoItemOrigem { get; set; }

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
        /// Recebe o valor de UNM_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string UnidadeMedidaDescricao { get; set; }

        /// <summary> 
        /// Recebe o valor de PRD_N_VALOR_ORIGINAL,  
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? ProdutoValorOriginal { get; set; }


        /// <summary> 
        /// Recebe o valor de PRD_N_VALOR_PROMOCIONAL 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? ProdutoValorPromocional { get; set; }

        /// <summary> 
        /// Recebe o valor da Validade
        /// </summary> 
        /// <user>efranca</user>
        public string Validade { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            //Orcamento
            if (pobjIDataReader["ORC_N_CODIGO"] != System.DBNull.Value)
            {
                this.OrcamentoCodigo = Convert.ToDecimal(pobjIDataReader["ORC_N_CODIGO"]);
            }
            if (pobjIDataReader["ORC_C_ORIGEM"] != System.DBNull.Value)
            {
                this.OrcamentoOrigem = pobjIDataReader["ORC_C_ORIGEM"].ToString();
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

            if (pobjIDataReader["ORC_N_MAO_OBRA"] != System.DBNull.Value)
            {
                this.MaoObra = Convert.ToDecimal(pobjIDataReader["ORC_N_MAO_OBRA"]);
            }

            //Orçamento Item

            if (pobjIDataReader["ORI_N_CODIGO"] != System.DBNull.Value)
            {
                this.OrcamentoItemCodigo = Convert.ToDecimal(pobjIDataReader["ORI_N_CODIGO"]);
            }
            if (pobjIDataReader["ORI_C_ORIGEM"] != System.DBNull.Value)
            {
                this.OrcamentoItemOrigem = pobjIDataReader["ORI_C_ORIGEM"].ToString();
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
            if (pobjIDataReader["PRD_C_NOME"] != System.DBNull.Value)
            {
                this.ProdutoNome = pobjIDataReader["PRD_C_NOME"].ToString();
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
            if (pobjIDataReader["PRD_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.ProdutoDescricao = pobjIDataReader["PRD_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["UNM_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.UnidadeMedidaDescricao = pobjIDataReader["UNM_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["PRD_N_VALOR_ORIGINAL"] != System.DBNull.Value)
            {
                this.ProdutoValorOriginal = Convert.ToDecimal(pobjIDataReader["PRD_N_VALOR_ORIGINAL"]);
            }
            if (pobjIDataReader["PRD_N_VALOR_PROMOCIONAL"] != System.DBNull.Value)
            {
                this.ProdutoValorPromocional = Convert.ToDecimal(pobjIDataReader["PRD_N_VALOR_PROMOCIONAL"]);
            }



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
        }

        #endregion
    }

    /// <summary> 
    /// Model da Entidade Orcamento e Pedido Por Dia
    /// </summary> 
    /// <user>etani</user> 
    [Serializable]
    public class MLPedidoOrcamentoRelatorioPorDia
    {
        #region Propriedades

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
        /// Recebe o valor de ORC_D_EMISSAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public DateTime? DataEmissao { get; set; }

        /// <summary> 
        /// Recebe o valor de STI_C_CODIGO
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string StatusOrcamento { get; set; }

        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public decimal? CodigoOrcamentoInicio { get; set; }
        public decimal? CodigoOrcamentoFim { get; set; }
        public decimal? ValorTotal { get; set; }

        public decimal? CodigoOrcamentoRel { get; set; }


        #endregion

        #region Conversor DataReader

        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["ORC_D_EMISSAO"] != System.DBNull.Value)
                this.DataEmissao = pobjIDataReader.GetDateTime(pobjIDataReader.GetOrdinal("ORC_D_EMISSAO"));
            if (pobjIDataReader["ORC_D_VALOR_TOTAL"] != System.DBNull.Value)
                this.ValorTotal = pobjIDataReader.GetDecimal(pobjIDataReader.GetOrdinal("ORC_D_VALOR_TOTAL"));
            if (pobjIDataReader["ORC_N_CODIGO"] != System.DBNull.Value)
                this.CodigoOrcamentoRel = pobjIDataReader.GetDecimal(pobjIDataReader.GetOrdinal("ORC_N_CODIGO"));
        }

        #endregion
    }

    /// <summary> 
    /// Model da Entidade Orcamento e Pedido
    /// </summary> 
    /// <user>etani</user> 
    [Serializable]
    public class MLPedidoOrcamentoRelatorio
    {
        #region Propriedades

        //Orçamento

        /// <summary> 
        /// Recebe o valor de ORC_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? CodigoOrcamento { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_ORCAMENTO_LEGADO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string OrcamentoLegado { get; set; }

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
        /// Recebe o valor de ORC_TPN_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoTipoNegocio { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_D_EMISSAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public DateTime? DataEmissao { get; set; }

        /// <summary> 
        /// Recebe o valor ORC_B_GERADO_VENDEDOR 
        /// </summary> 
        /// <user>efranca</user>
        public bool? GeradoVendedor { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_NOME_VENDEDOR
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string NomeVendedor { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_NOME_USUARIO
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string NomeUsuario { get; set; }

        /// <summary> 
        /// Recebe o valor de STI_C_CODIGO
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string StatusOrcamento { get; set; }
        public decimal? CodigoOrcamentoInicio { get; set; }
        public decimal? CodigoOrcamentoFim { get; set; }
        public decimal? ValorTotal { get; set; }

        #endregion

        #region Conversor DataReader

        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["ORC_N_CODIGO"] != System.DBNull.Value)
                this.CodigoOrcamento = pobjIDataReader.GetDecimal(pobjIDataReader.GetOrdinal("ORC_N_CODIGO"));
            if (pobjIDataReader["ORC_D_EMISSAO"] != System.DBNull.Value)
                this.DataEmissao = pobjIDataReader.GetDateTime(pobjIDataReader.GetOrdinal("ORC_D_EMISSAO"));
            if (pobjIDataReader["ORC_C_TITULO_ORCAMENTO"] != System.DBNull.Value)
                this.TituloOrcamento = pobjIDataReader.GetString(pobjIDataReader.GetOrdinal("ORC_C_TITULO_ORCAMENTO"));
            if (pobjIDataReader["VEN_C_NOME"] != System.DBNull.Value)
                this.NomeVendedor = pobjIDataReader.GetString(pobjIDataReader.GetOrdinal("VEN_C_NOME"));
            if (pobjIDataReader["BLF_USU_C_NOME"] != System.DBNull.Value)
                this.NomeUsuario = pobjIDataReader.GetString(pobjIDataReader.GetOrdinal("BLF_USU_C_NOME"));
            if (pobjIDataReader["ORC_D_VALOR_TOTAL"] != System.DBNull.Value)
                this.ValorTotal = pobjIDataReader.GetDecimal(pobjIDataReader.GetOrdinal("ORC_D_VALOR_TOTAL"));
        }

        #endregion
    }

    /// <summary> 
    /// Model da Entidade Itens Orcamento e Pedido
    /// </summary> 
    /// <user>etani</user> 
    [Serializable]
    public class MLPedidoOrcamentoItensRelatorio
    {
        #region Propriedades

        /// <summary>
        /// Valor do Campo ORI_N_CODIGO
        /// </summary>
        public decimal? CodigoOrcamentoItem { get; set; }

        /// <summary>
        /// Valor do Campo ORI_ORC_N_CODIGO
        /// </summary>
        public decimal? CodigoOrcamento { get; set; }

        /// <summary>
        /// Valor do Campo ORI_PRO_N_CODIGO
        /// </summary>
        public string CodigoProduto { get; set; }

        /// <summary>
        /// Valor do Campo ORI_N_QUANTIDADE
        /// </summary>
        public decimal? Quantidade { get; set; }

        /// <summary>
        /// Valor do Campo ORI_N_PRECO_APLICADO
        /// </summary>
        public decimal? ValorAplicado { get; set; }

        /// <summary>
        /// Valor do Campo PRD_C_NOME
        /// </summary>
        public string NomeProduto { get; set; }

        /// <summary>
        /// Valor do Campo ORC_D_EMISSAO
        /// </summary>
        public DateTime? DataEmissao { get; set; }

        /// <summary>
        /// Valor do Campo ORI_B_TEM_HISTORICO
        /// </summary>
        public int? PossuiHistorico { get; set; }

        #endregion

        #region Conversor DataReader

        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["ORI_N_CODIGO"] != System.DBNull.Value)
                this.CodigoOrcamentoItem = pobjIDataReader.GetDecimal(pobjIDataReader.GetOrdinal("ORI_N_CODIGO"));
            if (pobjIDataReader["ORI_ORC_N_CODIGO"] != System.DBNull.Value)
                this.CodigoOrcamento = pobjIDataReader.GetDecimal(pobjIDataReader.GetOrdinal("ORI_ORC_N_CODIGO"));
            if (pobjIDataReader["ORI_PRO_N_CODIGO"] != System.DBNull.Value)
                this.CodigoProduto = pobjIDataReader.GetString(pobjIDataReader.GetOrdinal("ORI_PRO_N_CODIGO"));
            if (pobjIDataReader["ORI_N_QUANTIDADE"] != System.DBNull.Value)
                this.Quantidade = pobjIDataReader.GetDecimal(pobjIDataReader.GetOrdinal("ORI_N_QUANTIDADE"));
            if (pobjIDataReader["ORI_N_PRECO_SUGERIDO"] != System.DBNull.Value)
                this.ValorAplicado = pobjIDataReader.GetDecimal(pobjIDataReader.GetOrdinal("ORI_N_PRECO_SUGERIDO"));
            if (pobjIDataReader["PRD_C_NOME"] != System.DBNull.Value)
                this.NomeProduto = pobjIDataReader.GetString(pobjIDataReader.GetOrdinal("PRD_C_NOME"));
            if (pobjIDataReader["ORC_D_EMISSAO"] != System.DBNull.Value)
                this.DataEmissao = pobjIDataReader.GetDateTime(pobjIDataReader.GetOrdinal("ORC_D_EMISSAO"));
            if (pobjIDataReader["ORI_B_TEM_HISTORICO"] != System.DBNull.Value)
                this.PossuiHistorico = pobjIDataReader.GetInt32(pobjIDataReader.GetOrdinal("ORI_B_TEM_HISTORICO"));
        }

        #endregion
    }

    #endregion
    
    #region Acessos ao Site

    /// <summary> 
    /// Model da Entidade do Relatorio do Orçamento 
    /// </summary> 
    /// <user>efranca</user> 
    [Serializable]
    public class MLAcessosRelatorio
    {
        #region Propriedades

        //Orçamento

        /// <summary> 
        /// Recebe o valor de ORC_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? UsuarioCodigo { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_ORIGEM 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string ProdutoCodigo { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_ORIGEM 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? ProdutoCod { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_ORCAMENTO_LEGADO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public DateTime DataAcesso { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_FOP_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string UsuarioNome { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_CON_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string ProdutoNome { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_REV_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public Boolean Orcado { get; set; }

        /// <summary> 
        /// Recebe o valor do Codigo para exibição na Grid
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string UsuarioCodigoGrid { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["ACC_USU_N_CODIGO"] != System.DBNull.Value)
            {
                this.UsuarioCodigo = Convert.ToDecimal(pobjIDataReader["ACC_USU_N_CODIGO"]);
            }
            if (pobjIDataReader["ACC_PRD_N_CODIGO"] != System.DBNull.Value)
            {
                this.ProdutoCodigo = pobjIDataReader["ACC_PRD_N_CODIGO"].ToString();
            }
            if (pobjIDataReader["REV_C_RAZAO_SOCIAL"] != System.DBNull.Value)
            {
                this.UsuarioNome = pobjIDataReader["REV_C_RAZAO_SOCIAL"].ToString();
            }
            if (pobjIDataReader["PRD_C_NOME"] != System.DBNull.Value)
            {
                this.ProdutoNome = Convert.ToDecimal(pobjIDataReader["PRD_C_CODIGO"]) + " - " + pobjIDataReader["PRD_C_NOME"].ToString();
            }
            if (pobjIDataReader["ORCADO"] != System.DBNull.Value)
            {
                this.Orcado = Convert.ToBoolean(pobjIDataReader["ORCADO"]);
            }
            if (pobjIDataReader["ACC_D_DATA"] != System.DBNull.Value)
            {
                this.DataAcesso = Convert.ToDateTime(pobjIDataReader["ACC_D_DATA"]);
            }

            this.UsuarioCodigoGrid = this.UsuarioCodigo + this.DataAcesso.ToString();
        }

        #endregion
    }

    /// <summary> 
    /// Model da Entidade do Relatorio do Orçamento 
    /// </summary> 
    /// <user>efranca</user> 
    [Serializable]
    public class MLAcessosCabecalhoRelatorio
    {
        #region Propriedades

        //Orçamento

        /// <summary> 
        /// Recebe o valor de ORC_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? UsuarioCodigo { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_C_ORCAMENTO_LEGADO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public DateTime DataAcesso { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_FOP_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string UsuarioNome { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_FOP_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string ProdutoNome { get; set; }

        /// <summary> 
        /// Recebe o valor de ORC_FOP_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? ProdutoCodigo { get; set; }

        /// <summary> 
        /// Recebe o valor do Codigo para exibição na Grid
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string UsuarioCodigoGrid { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["ACC_USU_N_CODIGO"] != System.DBNull.Value)
            {
                this.UsuarioCodigo = Convert.ToDecimal(pobjIDataReader["ACC_USU_N_CODIGO"]);
            }
            if (pobjIDataReader["USU_C_NOME"] != System.DBNull.Value)
            {
                this.UsuarioNome = pobjIDataReader["USU_C_NOME"].ToString();
            }
            if (pobjIDataReader["ACC_D_DATA"] != System.DBNull.Value)
            {
                this.DataAcesso = Convert.ToDateTime(pobjIDataReader["ACC_D_DATA"]);
            }
            //if (pobjIDataReader["ACC_PRD_N_CODIGO"] != System.DBNull.Value)
            //{
              //  this.ProdutoCodigo = Convert.ToDecimal(pobjIDataReader["ACC_PRD_N_CODIGO"]);
            //}
            /*if (pobjIDataReader["PRD_C_NOME"] != System.DBNull.Value)
            {
                this.ProdutoNome = pobjIDataReader["PRD_C_NOME"].ToString();
            }*/
            this.UsuarioCodigoGrid = this.UsuarioCodigo + this.DataAcesso.ToString();
        }

        #endregion
    }

    #endregion

    #region Ficha Financeira

    public class MLFichaFinanceiraDetalheRelatorio
    {
        #region Propriedades

        /// <summary> 
        /// Recebe o valor de FIF_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_C_PARCELA 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string Parcela { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_REV_C_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoRevendedor { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_D_LANCAMENTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public DateTime? DataLancamento { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_D_VENCIMENTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public DateTime? DataVencimento { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_N_VALOR_PARCELA 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? ValorParcela { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_N_VALOR_PAGAMENTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? ValorPagamento { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_C_FORMA_PAGAMENTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string FormaPagamento { get; set; }

        /// <summary> 
        /// Recebe o valor de FIF_REV_C_CODIGO_CLIENTE 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoClienteRevendedor { get; set; }

        /// <summary>
        /// Recebe a Situação de FIF_C_SITUACAO
        /// </summary>
        /// <user>etani</user>
        public string Situacao { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["FIF_N_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = Convert.ToString(pobjIDataReader["FIF_N_CODIGO"]);
            }
            if (pobjIDataReader["FIF_C_PARCELA"] != System.DBNull.Value)
            {
                this.Parcela = pobjIDataReader["FIF_C_PARCELA"].ToString();
            }
            if (pobjIDataReader["FIF_REV_C_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoRevendedor = pobjIDataReader["FIF_REV_C_CODIGO"].ToString();
            }
            if (pobjIDataReader["FIF_D_LANCAMENTO"] != System.DBNull.Value)
            {
                this.DataLancamento = Convert.ToDateTime(pobjIDataReader["FIF_D_LANCAMENTO"]);
            }
            if (pobjIDataReader["FIF_D_VENCIMENTO"] != System.DBNull.Value)
            {
                this.DataVencimento = Convert.ToDateTime(pobjIDataReader["FIF_D_VENCIMENTO"]);
            }
            if (pobjIDataReader["FIF_N_VALOR_PARCELA"] != System.DBNull.Value)
            {
                this.ValorParcela = Convert.ToDecimal(pobjIDataReader["FIF_N_VALOR_PARCELA"]);
            }
            if (pobjIDataReader["FIF_N_VALOR_PAGAMENTO"] != System.DBNull.Value)
            {
                this.ValorPagamento = Convert.ToDecimal(pobjIDataReader["FIF_N_VALOR_PAGAMENTO"]);
            }
            if (pobjIDataReader["FIF_C_FORMA_PAGAMENTO"] != System.DBNull.Value)
            {
                this.FormaPagamento = pobjIDataReader["FIF_C_FORMA_PAGAMENTO"].ToString();
            }
            if (pobjIDataReader["FIF_REV_C_CODIGO_CLIENTE"] != System.DBNull.Value)
            {
                this.CodigoClienteRevendedor = pobjIDataReader["FIF_REV_C_CODIGO_CLIENTE"].ToString();
            }
            if (pobjIDataReader["FIF_C_SITUACAO"] != System.DBNull.Value)
            {
                this.Situacao = pobjIDataReader["FIF_C_SITUACAO"].ToString();
            }
        }

        #endregion
    }

    public class MLFichaFinanceiraCabecalhoRelatorio
    {
        public DateTime DataLancamento { get; set; }

        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["FIF_D_LANCAMENTO"] != System.DBNull.Value)
            {
                this.DataLancamento = Convert.ToDateTime(pobjIDataReader["FIF_D_LANCAMENTO"]);
            }
        }
    }

    #endregion

    #region Extrato Financeiro

    /// <summary> 
    /// Model da Entidade do Relatorio do Orçamento 
    /// </summary> 
    /// <user>efranca</user> 
    [Serializable]
    public class MLExtratoFinanceiroCabecalhoRelatorio
    {
        #region Propriedades
        
        /// <summary> 
        /// Recebe o valor de EXF_D_LANCAMENTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public DateTime DataLancamento { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_N_SALDO_ANTERIOR 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? SaldoAnterior { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_N_SALDO_ATUAL 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? SaldoAtual { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["EXF_D_LANCAMENTO"] != System.DBNull.Value)
            {
                this.DataLancamento = Convert.ToDateTime(pobjIDataReader["EXF_D_LANCAMENTO"]);
            }
            if (pobjIDataReader["EXF_N_SALDO_ANTERIOR"] != System.DBNull.Value)
            {
                this.SaldoAnterior = Convert.ToDecimal(pobjIDataReader["EXF_N_SALDO_ANTERIOR"]);
            }
            if (pobjIDataReader["EXF_N_SALDO_ATUAL"] != System.DBNull.Value)
            {
                this.SaldoAtual = Convert.ToDecimal(pobjIDataReader["EXF_N_SALDO_ATUAL"]);
            }
        }

        #endregion
    }

    /// <summary> 
    /// Model da Entidade do Relatorio do Orçamento 
    /// </summary> 
    /// <user>efranca</user> 
    [Serializable]
    public class MLExtratoFinanceiroDetalheRelatorio
    {
        #region Propriedades

        /// <summary> 
        /// Recebe o valor de EXF_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_REV_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string CodigoRevendedor { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_D_LANCAMENTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public DateTime? DataLancamento { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_C_HISTORICO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Historico { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_N_SALDO_ANTERIOR 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? SaldoAnterior { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_N_CREDITO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? Credito { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_N_DEBITO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? Debito { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_N_SALDO_ATUAL 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? SaldoAtual { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_C_STATUS 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Status { get; set; }

        /// <summary> 
        /// Recebe o valor de EXF_C_DOCUMENTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Documento { get; set; }

        /// <summary> 
        /// Recebe a inicial da operação na Integração
        /// </summary> 
        /// <user>efranca</user>
        public string Operacao { get; set; }

        /// <summary> 
        /// Recebe o valor de REV_C_RAZAO_SOCIAL 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string RevendedorRazaoSocial { get; set; }

        /// <summary> 
        /// Recebe o valor de TIPO_OPERACAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string TipoOperacao { get; set; }

        /// <summary> 
        /// Recebe o valor de VALOR 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? Valor { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["EXF_N_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = Convert.ToDecimal(pobjIDataReader["EXF_N_CODIGO"]);
            }
            if (pobjIDataReader["EXF_REV_N_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoRevendedor = pobjIDataReader["EXF_REV_N_CODIGO"].ToString();
            }
            if (pobjIDataReader["EXF_D_LANCAMENTO"] != System.DBNull.Value)
            {
                this.DataLancamento = Convert.ToDateTime(pobjIDataReader["EXF_D_LANCAMENTO"]);
            }
            if (pobjIDataReader["EXF_C_HISTORICO"] != System.DBNull.Value)
            {
                this.Historico = pobjIDataReader["EXF_C_HISTORICO"].ToString();
            }
            if (pobjIDataReader["EXF_N_SALDO_ANTERIOR"] != System.DBNull.Value)
            {
                this.SaldoAnterior = Convert.ToDecimal(pobjIDataReader["EXF_N_SALDO_ANTERIOR"]);
            }
            if (pobjIDataReader["EXF_N_CREDITO"] != System.DBNull.Value)
            {
                this.Credito = Convert.ToDecimal(pobjIDataReader["EXF_N_CREDITO"]);
            }
            if (pobjIDataReader["EXF_N_DEBITO"] != System.DBNull.Value)
            {
                this.Debito = Convert.ToDecimal(pobjIDataReader["EXF_N_DEBITO"]);
            }
            if (pobjIDataReader["EXF_N_SALDO_ATUAL"] != System.DBNull.Value)
            {
                this.SaldoAtual = Convert.ToDecimal(pobjIDataReader["EXF_N_SALDO_ATUAL"]);
            }
            if (pobjIDataReader["EXF_C_STATUS"] != System.DBNull.Value)
            {
                this.Status = pobjIDataReader["EXF_C_STATUS"].ToString();
            }
            if (pobjIDataReader["EXF_C_DOCUMENTO"] != System.DBNull.Value)
            {
                this.Documento = pobjIDataReader["EXF_C_DOCUMENTO"].ToString();
            }
            if (pobjIDataReader["REV_C_RAZAO_SOCIAL"] != System.DBNull.Value)
            {
                this.RevendedorRazaoSocial = pobjIDataReader["REV_C_RAZAO_SOCIAL"].ToString();
            }
            if (pobjIDataReader["TIPO_OPERACAO"] != System.DBNull.Value)
            {
                this.TipoOperacao = pobjIDataReader["TIPO_OPERACAO"].ToString();
            }
            if (pobjIDataReader["VALOR"] != System.DBNull.Value)
            {
                this.Valor = Convert.ToDecimal(pobjIDataReader["VALOR"]);
            }
        }

        #endregion
    }

    #endregion
}
