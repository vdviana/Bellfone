using System;
using System.Text;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.DataLayer;
using VM2.Framework.BusinessLayer.Utilitarios;
using VM2.Framework.Model.Enquete;
using VM2.Framework.DataLayer.Enquete;
using VM2.Framework.DataLayer.Enquete.Sql;

namespace VM2.Framework.BusinessLayer.Enquete
{
    /// <summary> 
    /// Classe de Business Layer para Enquete 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class BLEnquete
    {

        #region Listar

        /// <summary> 
        /// Listar Enquete
        /// </summary> 
        /// <param name="pobjMLEnquete">Parametros para filtro</param>
        /// <returns>Lista de Enquete</returns> 
        /// <user>GeradorVm2</user>
        public List<MLEnquete> Listar(MLEnquete pobjMLEnquete)
        {

            Connector conEnquete = new Connector();
            IDLEnquete objDLEnquete = conEnquete.ObterDLEnquete();

            List<MLEnquete> lstRetorno = null;
            try
            {
                lstRetorno = objDLEnquete.Listar(pobjMLEnquete);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conEnquete.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Enquete
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Enquete</returns> 
        /// <user>GeradorVm2</user>
        public MLEnquete Obter(decimal pdecCodigo)
        {

            Connector conEnquete = new Connector();
            IDLEnquete objDLEnquete = conEnquete.ObterDLEnquete();
            MLEnquete objRetorno = null;

            try
            {
                objRetorno = objDLEnquete.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conEnquete.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Enquete
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Retorna da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Excluir(decimal pdecCodigo)
        {

            Connector conEnquete = new Connector();
            IDLEnquete objDLEnquete = conEnquete.ObterDLEnquete();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLEnquete.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conEnquete.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Enquete
        /// </summary> 
        /// <param name="pobjMLEnquete">Enquete com as alterações</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLEnquete pobjMLEnquete)
        {

            Connector conEnquete = new Connector();
            IDLEnquete objDLEnquete = conEnquete.ObterDLEnquete();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLEnquete.Alterar(pobjMLEnquete);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conEnquete.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Enquete
        /// </summary> 
        /// <param name="pobjMLEnquete">Enquete a ser inserido</param>
        /// <returns>Código Enquete</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLEnquete pobjMLEnquete)
        {

            Connector conEnquete = new Connector();
            IDLEnquete objDLEnquete = conEnquete.ObterDLEnquete();

            int objRetorno = 0;

            try
            {
                objRetorno = objDLEnquete.Inserir(pobjMLEnquete);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conEnquete.Finalizar();
            }
            return objRetorno;
        }

        #endregion
    }
}


