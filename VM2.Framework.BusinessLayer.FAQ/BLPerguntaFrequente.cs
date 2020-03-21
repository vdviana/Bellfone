using System;
using System.Text;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.DataLayer;
using VM2.Framework.BusinessLayer.Utilitarios;
using VM2.Framework.Model.FAQ;
using VM2.Framework.DataLayer.FAQ;
using VM2.Framework.DataLayer.FAQ.Sql;

namespace VM2.Framework.BusinessLayer.FAQ
{
    /// <summary> 
    /// Classe de Business Layer para PerguntaFrequente 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class BLPerguntaFrequente 
    {

        #region Listar

        /// <summary> 
        /// Listar PerguntaFrequente
        /// </summary> 
        /// <param name="pobjMLPerguntaFrequente">Parametros para filtro</param>
        /// <returns>Lista de PerguntaFrequente</returns> 
        /// <user>GeradorVm2</user>
        public List<MLPerguntaFrequente> Listar(MLPerguntaFrequente pobjMLPerguntaFrequente)
        {

            Connector conPerguntaFrequente = new Connector();
            IDLPerguntaFrequente objDLPerguntaFrequente = conPerguntaFrequente.ObterDLPerguntaFrequente();

            List<MLPerguntaFrequente> lstRetorno = null;
            try
            {
                lstRetorno = objDLPerguntaFrequente.Listar(pobjMLPerguntaFrequente);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conPerguntaFrequente.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um PerguntaFrequente
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>PerguntaFrequente</returns> 
        /// <user>GeradorVm2</user>
        public MLPerguntaFrequente Obter(decimal pdecCodigo)
        {

            Connector conPerguntaFrequente = new Connector();
            IDLPerguntaFrequente objDLPerguntaFrequente = conPerguntaFrequente.ObterDLPerguntaFrequente();
            MLPerguntaFrequente objRetorno = null;

            try
            {
                objRetorno = objDLPerguntaFrequente.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conPerguntaFrequente.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um PerguntaFrequente
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Retorna da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Excluir(decimal pdecCodigo)
        {

            Connector conPerguntaFrequente = new Connector();
            IDLPerguntaFrequente objDLPerguntaFrequente = conPerguntaFrequente.ObterDLPerguntaFrequente();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLPerguntaFrequente.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conPerguntaFrequente.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um PerguntaFrequente
        /// </summary> 
        /// <param name="pobjMLPerguntaFrequente">PerguntaFrequente com as alterações</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLPerguntaFrequente pobjMLPerguntaFrequente)
        {

            Connector conPerguntaFrequente = new Connector();
            IDLPerguntaFrequente objDLPerguntaFrequente = conPerguntaFrequente.ObterDLPerguntaFrequente();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLPerguntaFrequente.Alterar(pobjMLPerguntaFrequente);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conPerguntaFrequente.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um PerguntaFrequente
        /// </summary> 
        /// <param name="pobjMLPerguntaFrequente">PerguntaFrequente a ser inserido</param>
        /// <returns>Código PerguntaFrequente</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLPerguntaFrequente pobjMLPerguntaFrequente)
        {

            Connector conPerguntaFrequente = new Connector();
            IDLPerguntaFrequente objDLPerguntaFrequente = conPerguntaFrequente.ObterDLPerguntaFrequente();

            int objRetorno = 0;

            try
            {
                objRetorno = objDLPerguntaFrequente.Inserir(pobjMLPerguntaFrequente);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conPerguntaFrequente.Finalizar();
            }
            return objRetorno;
        }

        #endregion
    }
}


