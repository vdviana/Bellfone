using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Reflection;
using BellFone.B2B.Model;
using BellFone.B2B.DataLayer;
using Telerik.Web.UI;
using VM2.Framework.BusinessLayer.Utilitarios;
using System.Collections.ObjectModel;
namespace BellFone.B2B.BusinessLayer
{
    /// <summary> 
    /// Classe de Business Layer para Funções
    /// </summary> 
    public class BLFuncoesBellfone
    {
        #region SomenteNumero

        public static void SomenteNumero(TextBox ptxtBox)
        {
            ptxtBox.Attributes.Add("OnKeyPress", "return SomenteNumero(event);");
        }

        #endregion

        #region FormatarData

        public static void FormatarData(TextBox ptxtBox)
        {
            ptxtBox.Attributes.Add("OnKeyPress", "return FormataData(event,this);");
        }

        #endregion

        #region Tratar Erro

        /// <summary>
        /// Trata os erros gerados pela camada UI
        /// </summary>
        /// <param name="pexcExcecao"></param>
        /// <param name="pobjPagina"></param>
        /// <user>mazevedo</user>
        public static void TratarErro(Exception pexcExcecao, Page pobjPagina)
        {
            BLFuncoes.GravaLog("Classe: " + pexcExcecao.TargetSite.ReflectedType.Name + " Método: " + pexcExcecao.TargetSite.GetMethodBody(), pexcExcecao);

            var rwdErro = (RadWindow)EncontrarControle(pobjPagina, typeof(RadWindow));
            ConfigurarWindowErro(pexcExcecao, rwdErro);
        }

        #endregion
        
        #region Encontrar Controle Página

        /// <summary>
        /// Procura um controle através do seu ClientId
        /// </summary>
        /// <param name="ppagPagina">Pagina na qual devemos procurar o controle</param>
        /// <param name="ptypTipoObjeto"></param>
        /// <returns>Controle</returns>
        /// <user>mazevedo</user>
        public static Control EncontrarControle(Page ppagPagina, Type ptypTipoObjeto)
        {
            Control ctlRetorno = null;
            var lstRetorno = new List<object>();

            foreach (Control ctlControle in ppagPagina.Controls)
            {
                if (ctlControle != null)
                    EncontrarControleRecursivo(ctlControle, ptypTipoObjeto, lstRetorno);
            }

            if (lstRetorno.Count > 0)
                ctlRetorno = (Control)lstRetorno[0];

            return ctlRetorno;
        }

        #endregion

        #region Encontrar Controle Recursivo

        /// <summary>
        /// Utiliza recursividade para encontrar um controle
        /// </summary>
        /// <param name="pctlControle">Controle atual</param>
        /// <param name="ptypTipoObjeto"></param>
        /// <param name="plstLista"></param>
        /// <user>mazevedo</user>
        private static void EncontrarControleRecursivo(Control pctlControle, Type ptypTipoObjeto, List<object> plstLista)
        {
            if (pctlControle.GetType().Equals(ptypTipoObjeto) || pctlControle.GetType().IsSubclassOf(ptypTipoObjeto))
            {
                plstLista.Add(pctlControle);
            }
            else
            {
                foreach (Control ctlControle in pctlControle.Controls)
                    EncontrarControleRecursivo(ctlControle, ptypTipoObjeto, plstLista);

                return;
            }
        }

        #endregion

        #region Criar Window Erro

        /// <summary>
        /// Cria a window que sera exibida com o erro
        /// </summary>
        /// <param name="pexcExcecao">Excecao que aconteceu no usuário</param>
        /// <param name="rwdErro"></param>
        /// <returns></returns>
        /// <user></user>
        public static void ConfigurarWindowErro(Exception pexcExcecao, RadWindow rwdErro)
        {
            rwdErro.EnableViewState = false;
            rwdErro.ID = "wndCriacao";
            rwdErro.Width = Unit.Pixel(600);
            rwdErro.Height = Unit.Pixel(350);
            rwdErro.VisibleOnPageLoad = true;
            rwdErro.NavigateUrl = "~/Erro.aspx";
            rwdErro.DestroyOnClose = true;
            rwdErro.ReloadOnShow = true;
            rwdErro.Modal = true;
            rwdErro.InitialBehaviors = WindowBehaviors.Close;
        }

        #endregion

        public static string FormatarTelefone(string pstrTelefone)
        {
            if (pstrTelefone == string.Empty || pstrTelefone == null)
                return String.Empty;

            pstrTelefone = pstrTelefone.PadRight(14, ' ');

            pstrTelefone = pstrTelefone.Insert(6, "-");


            return "(" + pstrTelefone.Insert(2, ") ");
        }
        
    }
}
