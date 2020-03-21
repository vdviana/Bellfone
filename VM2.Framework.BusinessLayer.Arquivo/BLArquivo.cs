using System;
using System.Text;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.DataLayer;
using VM2.Framework.BusinessLayer.Utilitarios;
using VM2.Framework.Model.Arquivo;
using VM2.Framework.DataLayer.Arquivo;
using VM2.Framework.DataLayer.Arquivo.Sql;

namespace VM2.Framework.BusinessLayer.Arquivo
{
    /// <summary> 
    /// Classe de Business Layer para Arquivo 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class BLArquivo
    {

        #region Listar

        /// <summary> 
        /// Listar Arquivo
        /// </summary> 
        /// <param name="pobjMLArquivo">Parametros para filtro</param>
        /// <returns>Lista de Arquivo</returns> 
        /// <user>GeradorVm2</user>
        public List<MLArquivo> Listar(MLArquivo pobjMLArquivo, bool status)
        {

            Connector conArquivo = new Connector();
            IDLArquivo objDLArquivo = conArquivo.ObterDLArquivo();

            List<MLArquivo> lstRetorno = null;
            try
            {
                lstRetorno = objDLArquivo.Listar(pobjMLArquivo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conArquivo.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Arquivo
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Arquivo</returns> 
        /// <user>GeradorVm2</user>
        public MLArquivo Obter(decimal pdecCodigo)
        {

            Connector conArquivo = new Connector();
            IDLArquivo objDLArquivo = conArquivo.ObterDLArquivo();
            MLArquivo objRetorno = null;

            try
            {
                objRetorno = objDLArquivo.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conArquivo.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Arquivo
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Retorna da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Excluir(decimal pdecCodigo)
        {

            Connector conArquivo = new Connector();
            IDLArquivo objDLArquivo = conArquivo.ObterDLArquivo();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLArquivo.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conArquivo.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Arquivo
        /// </summary> 
        /// <param name="pobjMLArquivo">Arquivo com as alterações</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLArquivo pobjMLArquivo)
        {

            Connector conArquivo = new Connector();
            IDLArquivo objDLArquivo = conArquivo.ObterDLArquivo();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLArquivo.Alterar(pobjMLArquivo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conArquivo.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Arquivo
        /// </summary> 
        /// <param name="pobjMLArquivo">Arquivo a ser inserido</param>
        /// <returns>Código Arquivo</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLArquivo pobjMLArquivo)
        {

            Connector conArquivo = new Connector();
            IDLArquivo objDLArquivo = conArquivo.ObterDLArquivo();

            int objRetorno = 0;

            try
            {
                objRetorno = objDLArquivo.Inserir(pobjMLArquivo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conArquivo.Finalizar();
            }
            return objRetorno;
        }

        #endregion
    }
}


