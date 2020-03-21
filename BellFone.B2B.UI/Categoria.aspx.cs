using BellFone.B2B.BusinessLayer;
using BellFone.B2B.BusinessLayer.Configuration;
using BellFone.B2B.Model;
using BellFone.B2B.UI.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BellFone.B2B.UI
{
    public partial class Categoria : System.Web.UI.Page
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

        BLCategoria objBLCategoria = new BLCategoria();
        MLCategoria objMLCategoria = new MLCategoria();

        MLGrupo objMLGrupo = new MLGrupo();
        BLGrupo objBLGrupo = new BLGrupo();

        BLSubgrupo objBLSubgrupo = new BLSubgrupo();
        MLSubgrupo objMLSubgrupo = new MLSubgrupo();

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

                ObterCategoria();

                Ofertas.ObterProdutosPorCategoria();
            }
        }

        #region --- Eventos ---

        protected void rptGrupo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var objMLGrupo = (MLGrupo)e.Item.DataItem;

            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                objMLSubgrupo.CodigoGrupo = objMLGrupo.Codigo;
                objMLSubgrupo.IsAtivo = true;
                bool? bProdutoVisivel = null;

                var listMLSubgrupo = objBLSubgrupo.Listar(objMLSubgrupo, true, bProdutoVisivel);

                ((Repeater)e.Item.FindControl("rptSubGrupo")).DataSource = listMLSubgrupo;
                ((Repeater)e.Item.FindControl("rptSubGrupo")).DataBind();
            }
        }

        protected void rptProduto_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var objMLProdutoCompleto = (MLProdutoCompleto)e.Item.DataItem;

            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var imgProduto = (Image)e.Item.FindControl("imgProduto");
                var lblProdutoValor = (Label)e.Item.FindControl("lblProdutoValor");
                var ltlProdutoDescricao = (Literal)e.Item.FindControl("ltlProdutoDescricao");

                lblProdutoValor.Text = string.Format("Por: R$ {0}", objMLProdutoCompleto.ValorDe);
                ltlProdutoDescricao.Text = ltlProdutoDescricao.Text.Substring(0, ltlProdutoDescricao.Text.Length / 2);

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
        }

        protected void btnDetalhesProduto_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);

            v_PersistenciaTO.idProduto = button.CommandArgument;

            ViewToSession();

            Response.Redirect("Produto.aspx");
        }

        #endregion --- Eventos ---

        #region --- Privados ---

        private void ObterCategoria()
        {
            SessionToView();

            objMLCategoria = objBLCategoria.Obter(v_PersistenciaTO.idCategoria);

            ltlCategoria.Text = objMLCategoria.Descricao;

            objMLGrupo.CodigoCategoria = objMLCategoria.Codigo;
            objMLGrupo.IsAtivo = true;
            bool? bProdutoVisivel = null;

            var listMLGrupo = objBLGrupo.Listar(objMLGrupo, true, bProdutoVisivel);

            rptGrupo.DataSource = listMLGrupo;
            rptGrupo.DataBind();
        }

        #endregion --- Privados ---
    }
}