using System;
using System.Text;
using System.Collections.Generic;
using VM2.Framework.Model.Menu;
using VM2.Framework.DataLayer.Menu;
using VM2.Framework.BusinessLayer.Utilitarios;
using System.Web;

namespace VM2.Framework.BusinessLayer.Menu
{
    /// <summary> 
    /// Classe de Business Layer para Menu 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class BLMenu
    {

        #region Listar

        /// <summary> 
        /// Listar Menu
        /// </summary> 
        /// <param name="pobjMLMenu">Parametros para filtro</param>
        /// <returns>Lista de Menu</returns> 
        /// <user>GeradorVm2</user>
        public List<MLMenu> Listar(MLMenu pobjMLMenu)
        {

            Connector conMenu = new Connector();

            IDLMenu objDLMenu = conMenu.ObterDLMenu();
            List<MLMenu> lstRetorno = null;

            try
            {
                lstRetorno = objDLMenu.Listar(pobjMLMenu);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conMenu.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Menu
        /// </summary> 
        /// <param name="pdecCodigo">Código do Menu</param>
        /// <returns>Menu</returns> 
        /// <user>GeradorVm2</user>
        public MLMenu Obter(decimal pdecCodigo)
        {
            Connector conMenu = new Connector();

            IDLMenu objDLMenu = conMenu.ObterDLMenu();
            MLMenu objRetorno = null;

            try
            {
                objRetorno = objDLMenu.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conMenu.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Obter Completo

        /// <summary>
        ///     Obtém um menu com seus itens de menu
        /// </summary>
        /// <param name="pdecCodigoMenu">Código do Menu</param>
        /// <returns>Menu Completo</returns>
        /// <user>mazevedo</user>
        public MLMenuCompleto ObterCompleto(decimal pdecCodigoMenu, decimal pdecCodigoIdioma)
        {
            Connector conMenu = new Connector();
            IDLMenu objDLMenu = conMenu.ObterDLMenu();
            MLMenuCompleto objRetorno = null;
            MLMenuItem objItem = new MLMenuItem(); ;
            int intContador = 0;

            try
            {
                if (BLConfiguracao.IsMenuCache)
                {
                    objRetorno = (MLMenuCompleto)HttpRuntime.Cache.Get("cacFWMenu" + pdecCodigoMenu.ToString());
                    if (objRetorno != null)
                    {
                        objRetorno.ItensMenu.Clear();
                        while (objItem != null)
                        {
                            objItem = (MLMenuItem)HttpRuntime.Cache.Get("cacFWMenu" + pdecCodigoMenu.ToString() + "Item" + intContador);
                            if (objItem != null)
                            {
                                objRetorno.ItensMenu.Add(objItem);
                            }
                            intContador++;
                        }
                    }
                }

                if (objRetorno == null)
                {
                    objRetorno = objDLMenu.ObterCompleto(pdecCodigoMenu, pdecCodigoIdioma, true);
                    if (BLConfiguracao.IsMenuCache)
                    {
                        HttpRuntime.Cache.Remove("cacFWMenu" + pdecCodigoMenu.ToString());
                        HttpRuntime.Cache.Insert("cacFWMenu" + pdecCodigoMenu.ToString(), objRetorno, null, DateTime.Now.AddMinutes(BLConfiguracao.TempoExpiracaoCache), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
                        for (int intContadorItens = 0; intContadorItens < objRetorno.ItensMenu.Count; intContadorItens++)
                        {
                            HttpRuntime.Cache.Remove("cacFWMenu" + pdecCodigoMenu.ToString() + "Item" + intContadorItens);
                            HttpRuntime.Cache.Insert("cacFWMenu" + pdecCodigoMenu.ToString() + "Item" + intContadorItens, objRetorno.ItensMenu[intContadorItens], null, DateTime.Now.AddMinutes(BLConfiguracao.TempoExpiracaoCache), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conMenu.Finalizar();
            }

            return objRetorno;

        }

        #endregion

        #region Obter Completo

        /// <summary>
        ///     Obtém um menu com seus itens de menu sempre indo na base
        /// </summary>
        /// <param name="pdecCodigoMenu">Código do Menu</param>
        /// <returns>Menu Completo</returns>
        /// <user>tprohaska</user>
        public MLMenuCompleto ObterCompletoBase(decimal pdecCodigoMenu, decimal pdecCodigoIdioma)
        {
            Connector conMenu = new Connector();
            IDLMenu objDLMenu = conMenu.ObterDLMenu();
            MLMenuCompleto objRetorno = null;
            MLMenuItem objItem = new MLMenuItem();

            try
            {
                objRetorno = objDLMenu.ObterCompleto(pdecCodigoMenu, pdecCodigoIdioma, null);
                if (BLConfiguracao.IsMenuCache)
                {
                    HttpRuntime.Cache.Remove("cacFWMenu" + pdecCodigoMenu.ToString());
                    HttpRuntime.Cache.Insert("cacFWMenu" + pdecCodigoMenu.ToString(), objRetorno, null, DateTime.Now.AddMinutes(BLConfiguracao.TempoExpiracaoCache), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
                    for (int intContadorItens = 0; intContadorItens < objRetorno.ItensMenu.Count; intContadorItens++)
                    {
                        HttpRuntime.Cache.Remove("cacFWMenu" + pdecCodigoMenu.ToString() + "Item" + intContadorItens);
                        HttpRuntime.Cache.Insert("cacFWMenu" + pdecCodigoMenu.ToString() + "Item" + intContadorItens, objRetorno.ItensMenu[intContadorItens], null, DateTime.Now.AddMinutes(BLConfiguracao.TempoExpiracaoCache), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
                    }
                }
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conMenu.Finalizar();
            }
            return objRetorno;

        }

        #endregion

    }
}