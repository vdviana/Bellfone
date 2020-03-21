using BellFone.B2B.BusinessLayer;
using BellFone.B2B.Model;
using BellFone.B2B.UI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BellFone.B2B.UI.Componentes
{
    public partial class MenuPrincipal : System.Web.UI.UserControl
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

                ObterMenu();
            }
        }

        #region --- Eventos ---

        protected void rptMenuPrincipal_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var objMLCategoria = (MLCategoria)e.Item.DataItem;

            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var btnCategoria = (LinkButton)e.Item.FindControl("btnCategoria");

                btnCategoria.Text = objMLCategoria.Descricao;
            }
        }

        protected void btnCategoria_Click(object sender, EventArgs e)
        {
            LinkButton button = (sender as LinkButton);

            v_PersistenciaTO.idCategoria = button.CommandArgument;

            ViewToSession();

            Response.Redirect("Categoria.aspx");
        }

        #endregion --- Eventos ---

        #region --- Privados ---

        private void ObterMenu()
        {
            objMLCategoria.IsAtivo = true;
            bool? bProdutoVisivel = false;

            var listMLCategoria = objBLCategoria.Listar(objMLCategoria, true, bProdutoVisivel);

            rptMenuPrincipal.DataSource = listMLCategoria;
            rptMenuPrincipal.DataBind();
        }

        #endregion --- Privados ---
    }
}