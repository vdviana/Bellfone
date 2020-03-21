using System;
using System.Text;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.DataLayer;
using VM2.Framework.BusinessLayer.Utilitarios;
using VM2.Framework.Model.Arquivo;
using VM2.Framework.DataLayer.Arquivo;

namespace VM2.Framework.BusinessLayer.Arquivo
{
    /// <summary> 
    /// Classe de Business Layer para CategoriaArquivo 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class BLCategoriaArquivo
    {

        #region Listar

        /// <summary> 
        /// Listar CategoriaArquivo
        /// </summary> 
        /// <param name="pobjMLCategoriaArquivo">Parametros para filtro</param>
        /// <returns>Lista de CategoriaArquivo</returns> 
        /// <user>GeradorVm2</user>
        public List<MLCategoriaArquivo> Listar(MLCategoriaArquivo pobjMLCategoriaArquivo)
        {

            Connector conCategoriaArquivo = new Connector();
            IDLCategoriaArquivo objDLCategoriaArquivo = conCategoriaArquivo.ObterDLCategoriaArquivo();

            List<MLCategoriaArquivo> lstRetorno = null;
            try
            {
                
                lstRetorno = objDLCategoriaArquivo.Listar(pobjMLCategoriaArquivo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conCategoriaArquivo.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um CategoriaArquivo
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>CategoriaArquivo</returns> 
        /// <user>GeradorVm2</user>
        public MLCategoriaArquivo Obter(decimal pdecCodigo)
        {

            Connector conCategoriaArquivo = new Connector();
            IDLCategoriaArquivo objDLCategoriaArquivo = conCategoriaArquivo.ObterDLCategoriaArquivo();
            MLCategoriaArquivo objRetorno = null;

            try
            {
                objRetorno = objDLCategoriaArquivo.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conCategoriaArquivo.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um CategoriaArquivo
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Retorna da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Excluir(decimal pdecCodigo)
        {

            Connector conCategoriaArquivo = new Connector();
            IDLCategoriaArquivo objDLCategoriaArquivo = conCategoriaArquivo.ObterDLCategoriaArquivo();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLCategoriaArquivo.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conCategoriaArquivo.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um CategoriaArquivo
        /// </summary> 
        /// <param name="pobjMLCategoriaArquivo">CategoriaArquivo com as alterações</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLCategoriaArquivo pobjMLCategoriaArquivo)
        {

            Connector conCategoriaArquivo = new Connector();
            IDLCategoriaArquivo objDLCategoriaArquivo = conCategoriaArquivo.ObterDLCategoriaArquivo();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLCategoriaArquivo.Alterar(pobjMLCategoriaArquivo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conCategoriaArquivo.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um CategoriaArquivo
        /// </summary> 
        /// <param name="pobjMLCategoriaArquivo">CategoriaArquivo a ser inserido</param>
        /// <returns>Código CategoriaArquivo</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLCategoriaArquivo pobjMLCategoriaArquivo)
        {

            Connector conCategoriaArquivo = new Connector();
            IDLCategoriaArquivo objDLCategoriaArquivo = conCategoriaArquivo.ObterDLCategoriaArquivo();

            int objRetorno = 0;

            try
            {
                objRetorno = objDLCategoriaArquivo.Inserir(pobjMLCategoriaArquivo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conCategoriaArquivo.Finalizar();
            }
            return objRetorno;
        }

        #endregion
    }
}


