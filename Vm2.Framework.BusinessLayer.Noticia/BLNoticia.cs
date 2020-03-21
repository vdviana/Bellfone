using System;
using System.Text;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.DataLayer;
using VM2.Framework.BusinessLayer.Utilitarios;
using VM2.Framework.Model.Noticia;
using VM2.Framework.DataLayer.Noticia;

namespace VM2.Framework.BusinessLayer.Noticia
{
    /// <summary> 
    /// Classe de Business Layer para Noticia 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class BLNoticia
    {

        #region Listar

        /// <summary> 
        /// Listar Noticia
        /// </summary> 
        /// <param name="pobjMLNoticia">Parametros para filtro</param>
        /// <returns>Lista de Noticia</returns> 
        /// <user>GeradorVm2</user>
        public List<MLNoticia> Listar(MLNoticia pobjMLNoticia)
        {

            Connector conNoticia = new Connector();
            IDLNoticia objDLNoticia = conNoticia.ObterDLNoticia();

            List<MLNoticia> lstRetorno = null;
            try
            {
                lstRetorno = objDLNoticia.Listar(pobjMLNoticia);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conNoticia.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Noticia
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Noticia</returns> 
        /// <user>GeradorVm2</user>
        public MLNoticia Obter(decimal pdecCodigo)
        {

            Connector conNoticia = new Connector();
            IDLNoticia objDLNoticia = conNoticia.ObterDLNoticia();
            MLNoticia objRetorno = null;

            try
            {
                objRetorno = objDLNoticia.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conNoticia.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Noticia
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Retorna da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Excluir(decimal pdecCodigo)
        {

            Connector conNoticia = new Connector();
            IDLNoticia objDLNoticia = conNoticia.ObterDLNoticia();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLNoticia.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conNoticia.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Noticia
        /// </summary> 
        /// <param name="pobjMLNoticia">Noticia com as alterações</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLNoticia pobjMLNoticia)
        {

            Connector conNoticia = new Connector();
            IDLNoticia objDLNoticia = conNoticia.ObterDLNoticia();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLNoticia.Alterar(pobjMLNoticia);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conNoticia.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Noticia
        /// </summary> 
        /// <param name="pobjMLNoticia">Noticia a ser inserido</param>
        /// <returns>Código Noticia</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLNoticia pobjMLNoticia)
        {

            Connector conNoticia = new Connector();
            IDLNoticia objDLNoticia = conNoticia.ObterDLNoticia();

            int objRetorno = 0;

            try
            {
                objRetorno = objDLNoticia.Inserir(pobjMLNoticia);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conNoticia.Finalizar();
            }
            return objRetorno;
        }

        #endregion
    }
}


