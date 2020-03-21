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
    /// Classe de Business Layer para Banner 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class BLBanner
    {

        #region Listar

        /// <summary> 
        /// Listar Banner
        /// </summary> 
        /// <param name="pobjMLBanner">Parametros para filtro</param>
        /// <returns>Lista de Banner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLBanner> Listar(MLBanner pobjMLBanner)
        {

            DLBanner objDLBanner = new DLBanner();
            List<MLBanner> lstRetorno = null;

            try
            {
                lstRetorno = objDLBanner.Listar(pobjMLBanner);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLBanner.Finalizar();
            }
            return lstRetorno;
        }

        /// <summary> 
        /// Listar Banner
        /// </summary> 
        /// <returns>Lista de Banner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLBanner> ListarAleatorio()
        {

            string strChaveCache = string.Empty;
            strChaveCache = "cchBannerListarAleatorio";

            if (HttpContext.Current.Cache[strChaveCache] != null)
                return (List<MLBanner>)System.Web.HttpContext.Current.Cache[strChaveCache];


            DLBanner objDLBanner = new DLBanner();
            List<MLBanner> lstRetorno = null;

            try
            {
                lstRetorno = objDLBanner.ListarAleatorio();
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLBanner.Finalizar();
            }

            HttpContext.Current.Cache.Insert(strChaveCache, lstRetorno, null, DateTime.Now.AddMinutes(BLConfiguracao.TempoExpiracaoCacheListar("cchBannerListarAleatorio")), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Banner
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Banner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLBanner Obter(decimal pdecCodigo)
        {

            DLBanner objDLBanner = new DLBanner();
            MLBanner objRetorno = null;

            try
            {
                objRetorno = objDLBanner.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLBanner.Finalizar();
            }
            return objRetorno;
        }

        /// <summary> 
        /// Obtem um Banner Aleatorio
        /// </summary>         
        /// <returns>Banner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLBanner ObterAleatorio()
        {

            DLBanner objDLBanner = new DLBanner();
            MLBanner objRetorno = null;

            try
            {
                objRetorno = objDLBanner.ObterAleatorio();
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLBanner.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Banner
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Excluir(decimal pdecCodigo)
        {

            DLBanner objDLBanner = new DLBanner();

            try
            {
                return objDLBanner.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLBanner.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Banner
        /// </summary> 
        /// <param name="pobjMLBanner">Banner com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLBanner pobjMLBanner)
        {

            DLBanner objDLBanner = new DLBanner();

            try
            {
                return objDLBanner.Alterar(pobjMLBanner);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLBanner.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Banner
        /// </summary> 
        /// <param name="pobjMLBanner">Banner a ser inserido</param>
        /// <returns>Código Banner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public decimal Inserir(MLBanner pobjMLBanner)
        {

            DLBanner objDLBanner = new DLBanner();

            try
            {
                return objDLBanner.Inserir(pobjMLBanner);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLBanner.Finalizar();
            }
        }

        #endregion
    }
}


