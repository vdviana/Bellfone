using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using BellFone.B2B.Model;
using BellFone.B2B.DataLayer;
using VM2.Framework.BusinessLayer.Utilitarios;
using System.Web;
using System.Web.Caching;

namespace BellFone.B2B.BusinessLayer
{
    /// <summary> 
    /// Classe de Business Layer para MiniBanner 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class BLMiniBanner
    {

        #region Listar

        /// <summary> 
        /// Listar MiniBanner
        /// </summary> 
        /// <param name="pobjMLMiniBanner">Parametros para filtro</param>
        /// <returns>Lista de MiniBanner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLMiniBanner> Listar(MLMiniBanner pobjMLMiniBanner)
        {

            DLMiniBanner objDLMiniBanner = new DLMiniBanner();
            List<MLMiniBanner> lstRetorno = null;

            try
            {
                lstRetorno = objDLMiniBanner.Listar(pobjMLMiniBanner);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLMiniBanner.Finalizar();
            }
            return lstRetorno;
        }

        /// <summary> 
        /// MiniBanner´s Fixos
        /// </summary> 
        /// <returns>Lista de MiniBanner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLMiniBanner> ListarFixos()
        {

            string strChaveCache = string.Empty;
            strChaveCache = "cchMiniBannerListarFixos";

            if (HttpContext.Current.Cache[strChaveCache] != null)
                return (List<MLMiniBanner>)System.Web.HttpContext.Current.Cache[strChaveCache];

            DLMiniBanner objDLMiniBanner = new DLMiniBanner();
            List<MLMiniBanner> lstRetorno = null;

            try
            {
                lstRetorno = objDLMiniBanner.ListarFixos();
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLMiniBanner.Finalizar();
            }

            HttpContext.Current.Cache.Insert(strChaveCache, lstRetorno, null, DateTime.Now.AddMinutes(BLConfiguracao.TempoExpiracaoCacheListar("cchMiniBannerListarFixos")), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um MiniBanner
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>MiniBanner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLMiniBanner Obter(decimal pdecCodigo)
        {

            DLMiniBanner objDLMiniBanner = new DLMiniBanner();
            MLMiniBanner objRetorno = null;

            try
            {
                objRetorno = objDLMiniBanner.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLMiniBanner.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um MiniBanner
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Excluir(decimal pdecCodigo)
        {

            DLMiniBanner objDLMiniBanner = new DLMiniBanner();

            try
            {
                return objDLMiniBanner.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLMiniBanner.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um MiniBanner
        /// </summary> 
        /// <param name="pobjMLMiniBanner">MiniBanner com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLMiniBanner pobjMLMiniBanner)
        {

            DLMiniBanner objDLMiniBanner = new DLMiniBanner();

            try
            {
                return objDLMiniBanner.Alterar(pobjMLMiniBanner);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLMiniBanner.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um MiniBanner
        /// </summary> 
        /// <param name="pobjMLMiniBanner">MiniBanner a ser inserido</param>
        /// <returns>Código MiniBanner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public decimal Inserir(MLMiniBanner pobjMLMiniBanner)
        {

            DLMiniBanner objDLMiniBanner = new DLMiniBanner();

            try
            {
                return objDLMiniBanner.Inserir(pobjMLMiniBanner);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLMiniBanner.Finalizar();
            }
        }

        #endregion
    }
}


