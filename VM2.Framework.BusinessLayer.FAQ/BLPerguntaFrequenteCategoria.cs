using System;
using System.Text;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.DataLayer;
using VM2.Framework.BusinessLayer.Utilitarios;
using VM2.Framework.Model.FAQ;
using VM2.Framework.DataLayer.FAQ;

namespace VM2.Framework.BusinessLayer.FAQ
{
    /// <summary> 
    /// Classe de Business Layer para PerguntaFrequenteCategoria 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class BLPerguntaFrequenteCategoria
    {

        #region Listar

        /// <summary> 
        /// Listar PerguntaFrequenteCategoria
        /// </summary> 
        /// <param name="pobjMLPerguntaFrequenteCategoria">Parametros para filtro</param>
        /// <returns>Lista de PerguntaFrequenteCategoria</returns> 
        /// <user>GeradorVm2</user>
        public List<MLPerguntaFrequenteCategoria> Listar(MLPerguntaFrequenteCategoria pobjMLPerguntaFrequenteCategoria)
        {

            Connector conPerguntaFrequenteCategoria = new Connector();
            IDLPerguntaFrequenteCategoria objDLPerguntaFrequenteCategoria = conPerguntaFrequenteCategoria.ObterDLPerguntaFrequenteCategoria();

            List<MLPerguntaFrequenteCategoria> lstRetorno = null;
            try
            {
                lstRetorno = objDLPerguntaFrequenteCategoria.Listar(pobjMLPerguntaFrequenteCategoria);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conPerguntaFrequenteCategoria.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um PerguntaFrequenteCategoria
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>PerguntaFrequenteCategoria</returns> 
        /// <user>GeradorVm2</user>
        public MLPerguntaFrequenteCategoria Obter(decimal pdecCodigo)
        {

            Connector conPerguntaFrequenteCategoria = new Connector();
            IDLPerguntaFrequenteCategoria objDLPerguntaFrequenteCategoria = conPerguntaFrequenteCategoria.ObterDLPerguntaFrequenteCategoria();
            MLPerguntaFrequenteCategoria objRetorno = null;

            try
            {
                objRetorno = objDLPerguntaFrequenteCategoria.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conPerguntaFrequenteCategoria.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um PerguntaFrequenteCategoria
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Retorna da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Excluir(decimal pdecCodigo)
        {

            Connector conPerguntaFrequenteCategoria = new Connector();
            IDLPerguntaFrequenteCategoria objDLPerguntaFrequenteCategoria = conPerguntaFrequenteCategoria.ObterDLPerguntaFrequenteCategoria();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLPerguntaFrequenteCategoria.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conPerguntaFrequenteCategoria.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um PerguntaFrequenteCategoria
        /// </summary> 
        /// <param name="pobjMLPerguntaFrequenteCategoria">PerguntaFrequenteCategoria com as alterações</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLPerguntaFrequenteCategoria pobjMLPerguntaFrequenteCategoria)
        {

            Connector conPerguntaFrequenteCategoria = new Connector();
            IDLPerguntaFrequenteCategoria objDLPerguntaFrequenteCategoria = conPerguntaFrequenteCategoria.ObterDLPerguntaFrequenteCategoria();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLPerguntaFrequenteCategoria.Alterar(pobjMLPerguntaFrequenteCategoria);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conPerguntaFrequenteCategoria.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um PerguntaFrequenteCategoria
        /// </summary> 
        /// <param name="pobjMLPerguntaFrequenteCategoria">PerguntaFrequenteCategoria a ser inserido</param>
        /// <returns>Código PerguntaFrequenteCategoria</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLPerguntaFrequenteCategoria pobjMLPerguntaFrequenteCategoria)
        {

            Connector conPerguntaFrequenteCategoria = new Connector();
            IDLPerguntaFrequenteCategoria objDLPerguntaFrequenteCategoria = conPerguntaFrequenteCategoria.ObterDLPerguntaFrequenteCategoria();

            int objRetorno = 0;

            try
            {
                objRetorno = objDLPerguntaFrequenteCategoria.Inserir(pobjMLPerguntaFrequenteCategoria);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conPerguntaFrequenteCategoria.Finalizar();
            }
            return objRetorno;
        }

        #endregion
    }
}


