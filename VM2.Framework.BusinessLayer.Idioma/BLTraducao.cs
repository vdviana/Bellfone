using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.IO;
using VM2.Framework.BusinessLayer.Utilitarios;
using System.Web;
using System.Xml;
using System.Xml.XPath;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace VM2.Framework.BusinessLayer.Idiomas
{

    /// <summary>
    ///     Classe de negócio para tradução de conteudo
    /// </summary>
    /// <user>mazevedo</user>
    public class BLTraducao
    {

        #region TraduzirControle
        /// <summary>
        ///     Traduz um controle no idioma atual
        /// </summary>
        /// <user>mazevedo</user>
        [Obsolete("Desativado",false)]
        public static void TraduzirControle(Control pctlControle, string pstrPagina)
        {
            //TODO: Desativado
            return;

            string strConteudo = null;
            string strCultura = BLIdioma.IdiomaAtual.ToLower();
            string strDiretorio = HttpContext.Current.Server.MapPath(BLConfiguracao.DiretorioXMLIdioma);

            try
            {
                if (!string.IsNullOrEmpty(pctlControle.ID))
                {

                    if (Directory.Exists(strDiretorio) && File.Exists(strDiretorio + pstrPagina + ".xml") && pctlControle.ID != "0")
                    {
                        XPathDocument xpdIdioma = new XPathDocument(strDiretorio + pstrPagina + ".xml");
                        XPathNavigator xpnNavegador = xpdIdioma.CreateNavigator();
                        XPathNodeIterator xniBusca = xpnNavegador.Select("//" + strCultura.ToLower() + "//" + pctlControle.ID);
                        if (xniBusca.Count > 0)
                        {
                            xniBusca.MoveNext();
                            strConteudo = xniBusca.Current.Value;
                            if (typeof(ITextControl).IsAssignableFrom(pctlControle.GetType()) && !typeof(IRepeatInfoUser).IsAssignableFrom(pctlControle.GetType()))
                            {
                                if (((ITextControl)pctlControle).Text != "*")
                                {
                                    ((ITextControl)pctlControle).Text = strConteudo;
                                }
                            }
                            if (typeof(IRepeatInfoUser).IsAssignableFrom(pctlControle.GetType()))
                            {
                                if (pctlControle.GetType().ToString().IndexOf("CheckBoxList") > -1)
                                {
                                    int x = 1;
                                    foreach (ListItem lst in ((CheckBoxList)pctlControle).Items)
                                    {
                                        string strNomeColuna = null;
                                        XPathNodeIterator xniBuscaColuna = xpnNavegador.Select("//" + strCultura.ToLower() + "//" + pctlControle.ID + "//itens//item" + x.ToString());
                                        if (xniBuscaColuna.Count > 0)
                                        {
                                            xniBuscaColuna.MoveNext();
                                            strNomeColuna = xniBuscaColuna.Current.Value;
                                            lst.Text = strNomeColuna;
                                        }
                                        x += 1;
                                    }
                                }
                                else if (pctlControle.GetType().ToString().IndexOf("RadioButtonList") > -1)
                                {
                                    int x = 1;
                                    foreach (ListItem lst in ((RadioButtonList)pctlControle).Items)
                                    {
                                        string strNomeColuna = null;
                                        XPathNodeIterator xniBuscaColuna = xpnNavegador.Select("//" + strCultura.ToLower() + "//" + pctlControle.ID + "//itens//item" + x.ToString());
                                        if (xniBuscaColuna.Count > 0)
                                        {
                                            xniBuscaColuna.MoveNext();
                                            strNomeColuna = xniBuscaColuna.Current.Value;
                                            lst.Text = strNomeColuna;
                                        }
                                        x += 1;
                                    }
                                }

                            }
                            if (typeof(ICheckBoxControl).IsAssignableFrom(pctlControle.GetType()))
                            {
                                if (pctlControle.GetType().ToString().IndexOf("RadioButton") > -1)
                                    ((System.Web.UI.WebControls.RadioButton)((ICheckBoxControl)pctlControle)).Text = strConteudo;
                                else if (pctlControle.GetType().ToString().IndexOf("CheckBox") > -1)
                                    ((System.Web.UI.WebControls.CheckBox)((ICheckBoxControl)pctlControle)).Text = strConteudo;
                            }

                            if (typeof(IButtonControl).IsAssignableFrom(pctlControle.GetType()))
                            {
                                ((IButtonControl)pctlControle).Text = strConteudo;
                            }
                            if (typeof(IValidator).IsAssignableFrom(pctlControle.GetType()))
                            {
                                ((IValidator)pctlControle).ErrorMessage = strConteudo;
                            }
                            if (pctlControle.GetType().Equals(typeof(HyperLink)))
                            {
                                ((HyperLink)pctlControle).Text = strConteudo;
                            }
                            if (pctlControle.GetType().IsSubclassOf(typeof(RadGrid)))
                            {
                                RadGrid rdgGrid = (RadGrid)pctlControle;
                                foreach (GridColumn gcmColuna in rdgGrid.MasterTableView.Columns)
                                {
                                    string strNomeColuna = null;
                                    XPathNodeIterator xniBuscaColuna = xpnNavegador.Select("//" + strCultura.ToLower() + "//" + pctlControle.ID + "//colunas//" + gcmColuna.UniqueName);
                                    if (xniBuscaColuna.Count > 0)
                                    {
                                        xniBuscaColuna.MoveNext();
                                        strNomeColuna = xniBuscaColuna.Current.Value;
                                        gcmColuna.HeaderText = strNomeColuna;
                                    }
                                }
                                rdgGrid.Rebind();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }



        }
        #endregion

        #region Tradução Mensagem

        #region TraduzirMensagem
        /// <summary>
        ///     Traduz uma mensagem no idioma atual
        /// </summary>
        /// <param name="pintCodigoMensagem">Codigo da Mensagem a ser traduzida</param>
        /// <param name="pstrCaminhoXML">Caminho relativo do xml de imagens</param>
        /// <returns>Mensagem no idioma atual</returns>
        /// <user>mazevedo</user>
        public static string TraduzirMensagem(string pstrMensagem, string pstrCaminhoXML)
        {
            string strRetorno = string.Empty;
            string strDiretorio = HttpContext.Current.Server.MapPath(BLConfiguracao.DiretorioXMLIdioma);
            string strCultura = BLIdioma.IdiomaAtual.ToLower();

            try
            {
                XPathDocument xpdIdioma = new XPathDocument(strDiretorio + pstrCaminhoXML + ".xml");
                XPathNavigator xpnNavegador = xpdIdioma.CreateNavigator();
                XPathNodeIterator xniBusca = xpnNavegador.Select("//" + strCultura.ToLower() + "//" + pstrMensagem);

                if (xniBusca.Count > 0)
                {
                    xniBusca.MoveNext();
                    strRetorno = xniBusca.Current.Value;
                }

            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }



            return strRetorno;
        }
        #endregion

        #region TraduzirMensagem String
        /// <summary>
        ///     Traduz uma mensagem no idioma atual
        /// </summary>
        /// <param name="pintCodigoMensagem">Codigo da Mensagem a ser traduzida</param>
        /// <returns>Mensagem no idioma atual</returns>
        /// <user>mazevedo</user>
        public static string TraduzirMensagem(string pstrMensagem)
        {
            return TraduzirMensagem(pstrMensagem, "Mensagens");
        }
        #endregion

        #endregion

    }
}
