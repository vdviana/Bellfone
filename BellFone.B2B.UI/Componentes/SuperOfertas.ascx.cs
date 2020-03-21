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
    public partial class SuperOfertas : System.Web.UI.UserControl
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

                ObterProdutos();
            }
        }

        #region --- Eventos ---

        protected void rptSuperOfertas_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            var objMLProdutoCompleto = (MLProdutoCompleto)e.Item.DataItem;

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

        private void ObterProdutos()
        {
            var objMLProdutoCompleto = new MLProdutoCompleto();

            var strClassificacao = string.Empty;

            objMLProdutoCompleto.IsSuperOferta = true;
            var ListMLProdutoCompleto = objBLProduto.ListarCompletoAleatorios(objMLProdutoCompleto, strClassificacao, true);

            if (ListMLProdutoCompleto.Count != 0)
            {
                if (ListMLProdutoCompleto.Count > 4)
                    rptSuperOfertas.DataSource = ListMLProdutoCompleto.GetRange(0, 4);
                else
                    rptSuperOfertas.DataSource = ListMLProdutoCompleto;

                rptSuperOfertas.DataBind();
            }
        }

        #endregion --- Privados ---
    }
}