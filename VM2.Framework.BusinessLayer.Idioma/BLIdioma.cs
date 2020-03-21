using System;
using System.Text;
using System.Collections.Generic;
using VM2.Framework.Model.Idioma;
using VM2.Framework.DataLayer.Idioma;
using VM2.Framework.BusinessLayer.Utilitarios;
using System.Web;
using System.Threading;
using System.Globalization;

namespace VM2.Framework.BusinessLayer.Idiomas
{
    /// <summary> 
    /// Classe de Business Layer para Idioma 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class BLIdioma
    {

        #region Listar

        /// <summary> 
        /// Listar Idioma
        /// </summary> 
        /// <param name="pobjMLIdioma">Parametros para filtro</param>
        /// <returns>Lista de Idioma</returns> 
        /// <user>GeradorVm2</user>
        public List<MLIdioma> Listar(MLIdioma pobjMLIdioma)
        {

            Connector conIdiona = new Connector();
            IDLIdioma objDLIdioma = null;
            List<MLIdioma> lstRetorno = null;

            try
            {
                objDLIdioma = conIdiona.ObterDLIdioma();
                lstRetorno = objDLIdioma.Listar(pobjMLIdioma);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conIdiona.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Idioma
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Idioma</returns> 
        /// <user>GeradorVm2</user>
        public MLIdioma Obter(decimal pdecCodigo)
        {

            Connector conIdioma = new Connector();
            IDLIdioma objDLIdioma = null;
            MLIdioma objRetorno = null;

            try
            {
                objDLIdioma = conIdioma.ObterDLIdioma();
                objRetorno = objDLIdioma.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conIdioma.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Idioma
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Retorna da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Excluir(decimal pdecCodigo)
        {

            Connector conIdiona = new Connector();
            IDLIdioma objDLIdioma = null;
            bool objRetorno = false;

            try
            {
                objDLIdioma = conIdiona.ObterDLIdioma();
                objRetorno = objDLIdioma.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conIdiona.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Idioma
        /// </summary> 
        /// <param name="pobjMLIdioma">Idioma com as alterações</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLIdioma pobjMLIdioma)
        {

            Connector conIdiona = new Connector();
            IDLIdioma objDLIdioma = null;
            bool objRetorno = false;

            try
            {
                objDLIdioma = conIdiona.ObterDLIdioma();
                objRetorno = objDLIdioma.Alterar(pobjMLIdioma);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conIdiona.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Idioma
        /// </summary> 
        /// <param name="pobjMLIdioma">Idioma a ser inserido</param>
        /// <returns>Código Idioma</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLIdioma pobjMLIdioma)
        {

            Connector conIdiona = new Connector();
            IDLIdioma objDLIdioma = null;
            int objRetorno = 0;

            try
            {
                objDLIdioma = conIdiona.ObterDLIdioma();
                objRetorno = objDLIdioma.Inserir(pobjMLIdioma);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conIdiona.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region IdiomaAtual

        /// <summary>
        ///     Obtem o idioma atual do sistema
        /// </summary>
        /// <user>mazevedo</user>
        public static string IdiomaAtual
        {
            get
            {
                if (HttpContext.Current.Session["ssFWIdioma"] != null)
                    return HttpContext.Current.Session["ssFWIdioma"].ToString();
                else
                    return BLConfiguracao.IdiomaPadrao;
            }
            set
            {
                HttpContext.Current.Session["ssFWIdioma"] = value;
            }
        }

        #endregion

        #region CodigoIdiomaAtual

        /// <summary>
        ///     Retorna o Código do Idioma Atual
        /// </summary>
        /// <user>mazevedo</user>
        public static decimal CodigoIdiomaAtual
        {
            get
            {
                decimal decRetorno = BLConfiguracao.CodigoIdiomaPadrao;
                BLIdioma objBLIdioma = new BLIdioma();
                MLIdioma objMLIdiomaFiltro = new MLIdioma();
                objMLIdiomaFiltro.Sigla = BLIdioma.IdiomaAtual;
                List<MLIdioma> lstIdioma = new List<MLIdioma>();
                lstIdioma = objBLIdioma.Listar(objMLIdiomaFiltro);
                if (lstIdioma.Count > 0 && lstIdioma[0].Codigo.HasValue)
                {
                    decRetorno = lstIdioma[0].Codigo.Value;
                }
                return decRetorno;
            }
        }

        #endregion

    }
}


