using System;
using System.Text;
using System.Collections.Generic;
using VM2.Framework.Model.Usuario;
using VM2.Framework.DataLayer.Usuario;
using VM2.Framework.BusinessLayer.Utilitarios;

namespace VM2.Framework.BusinessLayer.Usuario
{
    /// <summary> 
    /// Classe de Business Layer para Funcionalidade 
    /// </summary> 
    /// <user>mazevedo</user> 
    public class BLFuncionalidade
    {
        #region Listar

        /// <summary> 
        /// Listar Funcionalidade
        /// </summary> 
        /// <param name="pobjMLFuncionalidade">Parametros para filtro</param>
        /// <returns>Lista de Funcionalidade</returns> 
        /// <user>GeradorVm2</user>
        public List<MLFuncionalidade> Listar(MLFuncionalidade pobjMLFuncionalidade)
        {

            Connector conFuncionalidade = new Connector();

            IDLFuncionalidade objDLFuncionalidade = conFuncionalidade.ObterDLFuncionalidade();
            List<MLFuncionalidade> lstRetorno = null;

            try
            {
                lstRetorno = objDLFuncionalidade.Listar(pobjMLFuncionalidade);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conFuncionalidade.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Funcionalidade
        /// </summary> 
        /// <param name="pdecCodigo">Código da Funcionalidade</param>
        /// <returns>Funcionalidade</returns> 
        /// <user>GeradorVm2</user>
        public MLFuncionalidade Obter(decimal pdecCodigo)
        {

            Connector conFuncionalidade = new Connector();

            IDLFuncionalidade objDLFuncionalidade = conFuncionalidade.ObterDLFuncionalidade();
            MLFuncionalidade objRetorno = null;

            try
            {
                objRetorno = objDLFuncionalidade.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conFuncionalidade.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Funcionalidade
        /// </summary> 
        /// <param name="pdecCodigo">Código da Funcionalidade</param>
        /// <returns>Retorna da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Excluir(decimal pdecCodigo)
        {

            Connector conFuncionalidade = new Connector();

            IDLFuncionalidade objDLFuncionalidade = conFuncionalidade.ObterDLFuncionalidade();
            bool objRetorno = false;

            try
            {
                objRetorno = objDLFuncionalidade.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conFuncionalidade.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Funcionalidade
        /// </summary> 
        /// <param name="pobjMLFuncionalidade">Funcionalidade com as alterações</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLFuncionalidade pobjMLFuncionalidade)
        {

            Connector conFuncionalidade = new Connector();

            IDLFuncionalidade objDLFuncionalidade = conFuncionalidade.ObterDLFuncionalidade();
            bool objRetorno = false;

            try
            {
                objRetorno = objDLFuncionalidade.Alterar(pobjMLFuncionalidade);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conFuncionalidade.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Funcionalidade
        /// </summary> 
        /// <param name="pobjMLFuncionalidade">Funcionalidade a ser inserido</param>
        /// <returns>Código Funcionalidade</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLFuncionalidade pobjMLFuncionalidade)
        {

            Connector conFuncionalidade = new Connector();

            IDLFuncionalidade objDLFuncionalidade = conFuncionalidade.ObterDLFuncionalidade();
            int objRetorno = 0;

            try
            {
                objRetorno = objDLFuncionalidade.Inserir(pobjMLFuncionalidade);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conFuncionalidade.Finalizar();
            }
            return objRetorno;
        }

        #endregion
    }
}


