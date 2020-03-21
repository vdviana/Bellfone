using BellFone.B2B.BusinessLayer;
using BellFone.B2B.BusinessLayer.Configuration;
using BellFone.B2B.UI.Utils;
using System;
using System.IO;

namespace BellFone.B2B.UI
{
    public partial class Produto : System.Web.UI.Page
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

                SessionToView();

                ObterProduto();
            }
        }

        #region --- Eventos ---

        #endregion --- Eventos ---

        #region --- Privados ---

        private void ObterProduto()
        {
            var strClassificacao = string.Empty;

            var objMLProdutoCompleto = objBLProduto.ObterCompleto(v_PersistenciaTO.idProduto, strClassificacao);

            ltlNome.Text = objMLProdutoCompleto.Nome;

            lblPreco.Text = string.Format("Por: R$ {0}", objMLProdutoCompleto.ValorDe);
            lblPreco.Text = lblPreco.Text.Substring(0, lblPreco.Text.Length - 1);

            string codigo = int.Parse(objMLProdutoCompleto.Codigo).ToString();
            ltlCodigo.Text = codigo;

            ltlFabricante.Text = objMLProdutoCompleto.FabricanteDescricao;
            ltlUnidadeMedida.Text = objMLProdutoCompleto.UnidadeMedidaDescricao;
            ltlDescricao.Text = objMLProdutoCompleto.Descricao;

            if (string.IsNullOrWhiteSpace(ltlDescricao.Text))
                pnlDescricao.Visible = false;

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

        #endregion --- Privados ---
    }
}