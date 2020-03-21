using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.UI.WebControls;
using VM2.Framework.Model.Utilitarios;
using System.Web.UI;

namespace VM2.Framework.BusinessLayer.Utilitarios
{

    /// <summary>
    ///     Classe com funções básicas para reaproveitamento
    /// </summary>
    /// <user>mazevedo</user>
    public class BLFuncoes
    {

        public static string StringISNullCache(object pobj)
        {
            try
            {
                if (pobj == null)
                {
                    return "_null";
                }
                return "_" + pobj.ToString();
            }
            catch
            {
                return "_null";
            }

        }

        #region Log

        /// <summary>
        ///     Grava o log de erros na base
        /// </summary>
        /// <param name="pstrAcao">Acao que estava sendo executada</param>
        /// <param name="pobjErro">Erro capturado</param>
        /// <user>mazevedo</user>
        public static void GravaLog(string pstrAcao, Exception pobjErro)
        {
            MLLog objLog = null;
            BLLog objBLLog = new BLLog();

            try
            {

                if (BLConfiguracao.IsGravarLog)
                {
                    objLog = new MLLog();
                    objLog.Data = DateTime.Now;
                    objLog.Metodo = pstrAcao;
                    objLog.StackTrace = pobjErro.Message + pobjErro.StackTrace;
                    objBLLog.Inserir(objLog);
                }

            }
            catch
            {
            }
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Grava Log de Exception 
        /// </summary> 
        /// <param name="pstrAcao">Nome da Classe/Metodo/Ação</param> 
        /// <param name="pobjErro">Exception</param> 
        /// <history> 
        /// [mazevedo] 15/07/2008 Created 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public static void GravaLog(string pstrAcao)
        {

            BLLog objBLLog = new BLLog();

            try
            {
                if (BLConfiguracao.IsGravarLog)
                {
                    MLLog objMLLog = new MLLog();
                    objMLLog.Data = DateTime.Now;
                    objMLLog.Metodo = "Importação";
                    objMLLog.StackTrace = pstrAcao;

                    objBLLog.Inserir(objMLLog);
                }

            }
            catch (Exception)
            {
                //não faz nada 
            }
        }

        #endregion

        #region Pagina

        /// <summary>
        ///     Acerta a url obtida através do método 
        /// </summary>
        /// <param name="pstrPagina"></param>
        /// <returns></returns>
        /// <user>mazevedo</user>
        public static string AcertarUrl(string pstrPagina)
        {
            string strRetorno = pstrPagina.Substring(4);

            strRetorno = strRetorno.Substring(0, strRetorno.LastIndexOf("_")) + "." + strRetorno.Substring(strRetorno.LastIndexOf("_") + 1);
            strRetorno = strRetorno.Replace("_", "/");

            return strRetorno;
        }

        #endregion

        #region Encontrar Controle Página
        /// <summary>
        ///     Procura um controle através do seu ClientId
        /// </summary>
        /// <param name="ppagPagina">Pagina na qual devemos procurar o controle</param>
        /// <param name="pstrClientId">Client Id do controle</param>
        /// <returns>Controle</returns>
        /// <user>mazevedo</user>
        public static Control EncontrarControle(Page ppagPagina, string pstrClientId, Type ptypTipoObjeto)
        {

            Control ctlRetorno = null;

            foreach (Control ctlControle in ppagPagina.Controls)
            {
                if (ctlControle != null)
                {
                    ctlRetorno = EncontrarControleRecursivo(ctlControle, pstrClientId, ptypTipoObjeto);
                }
            }

            return ctlRetorno;

        }

        /// <summary>
        ///     Utiliza recursividade para encontrar um controle
        /// </summary>
        /// <param name="pctlControle">Controle atual</param>
        /// <param name="pstrClientId">Client ID desejado</param>
        /// <returns>Controle</returns>
        /// <user>mazevedo</user>
        private static Control EncontrarControleRecursivo(Control pctlControle, string pstrClientId, Type ptypTipoObjeto)
        {
            if (pstrClientId.Contains(pctlControle.ClientID) && (pctlControle.GetType().Equals(ptypTipoObjeto) || pctlControle.GetType().IsSubclassOf(ptypTipoObjeto)))
            {
                return pctlControle;
            }
            else
            {
                foreach (Control ctlControle in pctlControle.Controls)
                {
                    Control ctlRetorno = EncontrarControleRecursivo(ctlControle, pstrClientId, ptypTipoObjeto);
                    if (ctlRetorno != null)
                    {
                        return ctlRetorno;
                    }
                }
                return null;
            }
        }

        #endregion

        #region Encontrar Controle User Control

        /// <summary>
        ///     Encontra todos os objetos de um determinado tipo em um User Control
        /// </summary>
        /// <param name="puscControle">User Control alvo</param>
        /// <param name="ptypTipoObjeto">Tipo do objeto a ser encontrado</param>
        /// <returns>Lista de objetos encontrados</returns>
        /// <user>mazevedo</user>
        public static List<object> EncontrarControle(UserControl puscControle, Type ptypTipoObjeto)
        {
            List<object> lstRetorno = new List<object>();
            foreach (Control ctlControle in puscControle.Controls)
            {
                if (ctlControle != null)
                {
                    EncontrarControleRecursivo(ctlControle, ptypTipoObjeto, lstRetorno);
                }
            }

            return lstRetorno;

        }


        /// <summary>
        ///     Utiliza recursividade para encontrar um controle
        /// </summary>
        /// <param name="pctlControle">Controle atual</param>
        /// <param name="pstrClientId">Client ID desejado</param>
        /// <user>mazevedo</user>
        private static void EncontrarControleRecursivo(Control pctlControle, Type ptypTipoObjeto, List<object> plstLista)
        {
            if (pctlControle.GetType().Equals(ptypTipoObjeto) || pctlControle.GetType().IsSubclassOf(ptypTipoObjeto))
            {
                plstLista.Add(pctlControle);
            }

            foreach (Control ctlControle in pctlControle.Controls)
            {
                EncontrarControleRecursivo(ctlControle, ptypTipoObjeto, plstLista);
            }
        }
        #endregion

        #region Encontrar Controle Página
        /// <summary>
        ///     Procura um controle através do seu ClientId
        /// </summary>
        /// <param name="ppagPagina">Pagina na qual devemos procurar o controle</param>
        /// <param name="pstrClientId">Client Id do controle</param>
        /// <returns>Controle</returns>
        /// <user>mazevedo</user>
        public static Control EncontrarControle(Page ppagPagina, Type ptypTipoObjeto)
        {

            Control ctlRetorno = null;
            List<object> lstRetorno = new List<object>();

            foreach (Control ctlControle in ppagPagina.Controls)
            {
                if (ctlControle != null)
                {
                    EncontrarControleRecursivo(ctlControle, ptypTipoObjeto, lstRetorno);
                }
            }

            if (lstRetorno.Count > 0)
            {
                ctlRetorno = (Control)lstRetorno[0];
            }

            return ctlRetorno;

        }

        #endregion

        #region Encontrar Lista de Controle Página
        /// <summary>
        ///     Procura um controle através do seu tipo
        /// </summary>
        /// <param name="ppagPagina">Pagina na qual devemos procurar o controle</param>
        /// <param name="ptypTipoObjeto">Tipo do controle</param>
        /// <returns>List<object></returns>
        /// <user>tprohaska</user>
        public static List<object> EncontrarListaControle(Page ppagPagina, Type ptypTipoObjeto)
        {
            List<object> lstRetorno = new List<object>();

            EncontrarControleRecursivo(ppagPagina, ptypTipoObjeto, lstRetorno);

            return lstRetorno;
        }

        #endregion

        #region Abrir Popup

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Adiciona atributo para abir popup
        /// </summary> 
        ///<param name="pintHeight">Altura</param>
        /// <param name="pintWidth">Largura</param>
        /// <param name="pstrIdPop">Codigo Popup</param>
        /// <param name="pstrPath">Caminho</param>
        /// <param name="pwctControl">WebControl</param>
        /// <history> 
        /// [mmoreno] 22/07/2008 Created 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public static void AbrirPopUp(Page pobjPage, string pstrPath, string pstrIdPop, int pintWidth, int pintHeight)
        {
            pobjPage.ClientScript.RegisterStartupScript(typeof(string), "abrirRel", String.Format("abrirPopUp('{0}', '{1}', {2}, {3});", pstrPath, pstrIdPop, pintWidth, pintHeight), true);

        }

        #endregion

        #region Abrir Popup


        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Adicionar Atributte para formatar data
        /// </summary> 
        /// <param name="ptxtBox">TextBox a se adicionar atributo para mascara de data</param> 
        /// <history> 
        /// [mmoreno] 15/07/2008 Created 
        /// </history> 
        /// ----------------------------------------------------------------------------- 
        public static void FormatarData(TextBox ptxtBox)
        {
            ptxtBox.Attributes.Add("OnKeyPress", "return desabilitaCtrlKeyCombinacao(event);");
            ptxtBox.Attributes.Add("OnKeyDown", "return desabilitaCtrlKeyCombinacao(event);");
            ptxtBox.Attributes.Add("OnKeyPress", "return FormataData(event,this);");
        }

        #endregion


    }
}
