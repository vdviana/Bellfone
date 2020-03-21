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
    /// Classe de Business Layer para NoticiaCategoria 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class BLNoticiaCategoria
    {

        #region Listar

        /// <summary> 
        /// Listar NoticiaCategoria
        /// </summary> 
        /// <param name="pobjMLNoticiaCategoria">Parametros para filtro</param>
        /// <returns>Lista de NoticiaCategoria</returns> 
        /// <user>GeradorVm2</user>
        public List<MLNoticiaCategoria> Listar(MLNoticiaCategoria pobjMLNoticiaCategoria)
        {

            Connector conNoticiaCategoria = new Connector();
            IDLNoticiaCategoria objDLNoticiaCategoria = conNoticiaCategoria.ObterDLNoticiaCategoria();

            List<MLNoticiaCategoria> lstRetorno = null;
            try
            {
                lstRetorno = objDLNoticiaCategoria.Listar(pobjMLNoticiaCategoria);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conNoticiaCategoria.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um NoticiaCategoria
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>NoticiaCategoria</returns> 
        /// <user>GeradorVm2</user>
        public MLNoticiaCategoria Obter(decimal pdecCodigo)
        {

            Connector conNoticiaCategoria = new Connector();
            IDLNoticiaCategoria objDLNoticiaCategoria = conNoticiaCategoria.ObterDLNoticiaCategoria(); 
            MLNoticiaCategoria objRetorno = null;

            try
            {
                objRetorno = objDLNoticiaCategoria.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conNoticiaCategoria.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um NoticiaCategoria
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Retorna da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Excluir(decimal pdecCodigo)
        {

            Connector conNoticiaCategoria = new Connector();
            IDLNoticiaCategoria objDLNoticiaCategoria = conNoticiaCategoria.ObterDLNoticiaCategoria();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLNoticiaCategoria.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conNoticiaCategoria.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um NoticiaCategoria
        /// </summary> 
        /// <param name="pobjMLNoticiaCategoria">NoticiaCategoria com as alterações</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLNoticiaCategoria pobjMLNoticiaCategoria)
        {

            Connector conNoticiaCategoria = new Connector();
            IDLNoticiaCategoria objDLNoticiaCategoria = conNoticiaCategoria.ObterDLNoticiaCategoria();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLNoticiaCategoria.Alterar(pobjMLNoticiaCategoria);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conNoticiaCategoria.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um NoticiaCategoria
        /// </summary> 
        /// <param name="pobjMLNoticiaCategoria">NoticiaCategoria a ser inserido</param>
        /// <returns>Código NoticiaCategoria</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLNoticiaCategoria pobjMLNoticiaCategoria)
        {

            Connector conNoticiaCategoria = new Connector();
            IDLNoticiaCategoria objDLNoticiaCategoria = conNoticiaCategoria.ObterDLNoticiaCategoria();

            int objRetorno = 0;

            try
            {
                objRetorno = objDLNoticiaCategoria.Inserir(pobjMLNoticiaCategoria);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conNoticiaCategoria.Finalizar();
            }
            return objRetorno;
        }

        #endregion
    }
}


