using BellFone.B2B.BusinessLayer;
using BellFone.B2B.Model;
using System;
using System.Web;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BellFone.B2B.BusinessLayer.Configuration;
using System.IO;
using BellFone.B2B.UI.Utils;

namespace BellFone.B2B.UI.Componentes
{
    public partial class Ofertas : System.Web.UI.UserControl
    {
        #region --- Propriedades ---

        private PersistenciaTO v_PersistenciaTO
        {
            get
            {
                if (ViewState["v_PersistenciaTO"] != null)
                    return (PersistenciaTO)ViewState["v_PersistenciaTO"];

                return null;
            }
            set
            {
                ViewState["v_PersistenciaTO"] = value;
            }
        }

        private PersistenciaTO s_PersistenciaTO
        {
            get
            {
                if (Session["s_PersistenciaTO"] != null)
                    return (PersistenciaTO)Session["s_PersistenciaTO"];

                return null;
            }
            set
            {
                Session["s_PersistenciaTO"] = value;
            }
        }

        private int PaginaAtual
        {
            get
            {
                if (ViewState["v_PaginaAtual"] != null)
                    return (int)ViewState["v_PaginaAtual"];

                return 0;
            }
            set
            {
                ViewState["v_PaginaAtual"] = value;
            }
        }

        private int UltimaPagina
        {
            get
            {
                if (ViewState["v_UltimaPagina"] != null)
                    return (int)ViewState["v_UltimaPagina"];

                return 0;
            }
            set
            {
                ViewState["v_UltimaPagina"] = value;
            }
        }

        private int TotalRegistros
        {
            get
            {
                if (ViewState["v_TotalRegistros"] != null)
                    return (int)ViewState["v_TotalRegistros"];

                return 0;
            }
            set
            {
                ViewState["v_TotalRegistros"] = value;
            }
        }

        private int Contador
        {
            get
            {
                if (ViewState["v_Contador"] != null)
                    return (int)ViewState["v_Contador"];

                return 0;
            }
            set
            {
                ViewState["v_Contador"] = value;
            }
        }

        MLProdutoCompleto objMLProdutoCompleto = new MLProdutoCompleto();

        BLProduto objBLProduto = new BLProduto();

        #endregion --- Propriedades ---

        #region --- Gerenciamento de ViewState e Session ---

        private void ViewToSession()
        {
            Session["s_PersistenciaTO"] = ViewState["v_PersistenciaTO"];
        }

        private void SessionToView()
        {
            ViewState["v_PersistenciaTO"] = Session["s_PersistenciaTO"];
        }

        #endregion --- Gerenciamento de ViewState e Session ---

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                v_PersistenciaTO = new PersistenciaTO();
            }
        }

        #region --- Eventos ---

        protected void rptOfertas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var objMLProdutoCompleto = (MLProdutoCompleto)e.Item.DataItem;
            var rptOfertas = (sender as Repeater);
           
            if (e.Item.ItemType == ListItemType.Header)
            {                
                if (Page.ToString() == "ASP.categoria_aspx")
                {
                    if (TotalRegistros == 0)
                    {
                        var ltlMensagem = (Literal)e.Item.FindControl("ltlMensagem");
                        ltlMensagem.Text = "Nenhum produto encontrado.";

                        var pnlMensagem = (Panel)e.Item.FindControl("pnlMensagem");
                        pnlMensagem.Visible = true;

                        var pnlPaginacaoCabecalho = (Panel)e.Item.FindControl("pnlPaginacaoCabecalho");
                        pnlPaginacaoCabecalho.Visible = false;
                    }

                    Contador = (PaginaAtual == 0 ? 1 : Contador + 1);

                    int finalRegistro = (Contador * 12);
                    int inicioRegistro = (finalRegistro == 0 ? 1 : (finalRegistro - 12) + 1);

                    finalRegistro = (finalRegistro > TotalRegistros ? inicioRegistro : finalRegistro);

                    var ltlResultados = (Literal)e.Item.FindControl("ltlResultados");
                    ltlResultados.Text = string.Format("Mostrando {0}-{1} de {2} resultados.", inicioRegistro, finalRegistro, TotalRegistros);
                }
                else
                {
                    var pnlPaginacaoCabecalho = (Panel)e.Item.FindControl("pnlPaginacaoCabecalho");
                    pnlPaginacaoCabecalho.Visible = false;
                }
            }

            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var imgProduto = (Image)e.Item.FindControl("imgProduto");
                var lblProdutoValor = (Label)e.Item.FindControl("lblProdutoValor");

                lblProdutoValor.Text = string.Format("Por: R$ {0}", objMLProdutoCompleto.ValorDe);

                var intValor = 0;

                if (int.TryParse(objMLProdutoCompleto.Codigo, out intValor))
                {
                    var url = Server.MapPath(UTProduto.ObterCaminhoProdutoImagem() + Convert.ToInt32(objMLProdutoCompleto.Codigo).ToString() + ".jpg");

                    if (File.Exists(url))
                    {
                        imgProduto.ImageUrl = UTProduto.ObterCaminhoProdutoImagem() + Convert.ToInt32(objMLProdutoCompleto.Codigo).ToString() + ".jpg";
                    }
                    else
                    {
                        imgProduto.ImageUrl = UTProduto.ObterCaminhoProdutoImagemPadrao();
                    }
                }
                else
                {
                    imgProduto.ImageUrl = UTProduto.ObterCaminhoProdutoImagemPadrao();
                }
            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                if (Page.ToString() == "ASP.categoria_aspx")
                {
                    if (TotalRegistros == 0)
                    {
                        var pnlPaginacaoRodape = (Panel)e.Item.FindControl("pnlPaginacaoRodape");
                        pnlPaginacaoRodape.Visible = false;
                    }
                }
                else
                {
                    var pnlPaginacaoRodape = (Panel)e.Item.FindControl("pnlPaginacaoRodape");
                    pnlPaginacaoRodape.Visible = false;
                }
            }
        }

        protected void btnDetalhesProduto_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);

            v_PersistenciaTO.idProduto = button.CommandArgument;

            ViewToSession();

            Response.Redirect("Produto.aspx");
        }

        protected void btnAdicionarCarrinho_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);

            string commandArgument = button.CommandArgument;
        }

        protected void btnPrimeiro_Click(object sender, EventArgs e)
        {
            PaginaAtual = 0;

            ObterProdutosPorCategoria();
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            PaginaAtual--;

            ObterProdutosPorCategoria();
        }

        protected void btnProximo_Click(object sender, EventArgs e)
        {
            PaginaAtual++;

            ObterProdutosPorCategoria();
        }

        protected void btnUltimo_Click(object sender, EventArgs e)
        {
            PaginaAtual = UltimaPagina - 1;

            ObterProdutosPorCategoria();
        }

        #endregion --- Eventos ---

        #region --- Privados ---

        #endregion --- Privados ---

        #region --- Publicos ---

        public void ObterProdutos()
        {
            var strClassificacao = string.Empty;
            objMLProdutoCompleto.IsDestaque = true;

            var ListMLProdutoCompleto = objBLProduto.ListarCompletoAleatorios(objMLProdutoCompleto, strClassificacao, true);

            if (ListMLProdutoCompleto.Count != 0)
            {
                rptOfertas.DataSource = ListMLProdutoCompleto;
                rptOfertas.DataBind();
            }
        }

        public void ObterProdutosPorCategoria()
        {
            SessionToView();

            if (!string.IsNullOrEmpty(v_PersistenciaTO.idCategoria))
            {
                objMLProdutoCompleto.CategoriaCodigo = v_PersistenciaTO.idCategoria;
            }

            objMLProdutoCompleto.IsStatus = true;
            var strClassificacao = string.Empty;

            var ListMLProdutoCompleto = objBLProduto.ListarCompletoAleatorios(objMLProdutoCompleto, strClassificacao, false);

            PagedDataSource page = new PagedDataSource();
            page.AllowPaging = true; 
            page.DataSource = ListMLProdutoCompleto; 
            page.PageSize = 12; 

            if (PaginaAtual >= page.PageCount)
            {
                PaginaAtual--;
            }
            else if (PaginaAtual < 0)
            {
                PaginaAtual++;
            }
            else
            {
                page.CurrentPageIndex = PaginaAtual;
                UltimaPagina = page.PageCount;
                TotalRegistros = page.DataSourceCount;

                rptOfertas.DataSource = page;
                rptOfertas.DataBind();
            }
        }

        #endregion --- Publicos ---
    }
}