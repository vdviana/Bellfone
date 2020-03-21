using System;
using System.Text;
using System.Collections.Generic;
using VM2.Framework.Model.Menu;
using VM2.Framework.DataLayer.Menu;
using VM2.Framework.BusinessLayer.Utilitarios;

namespace VM2.Framework.BusinessLayer.Menu
{
    /// <summary> 
    /// Classe de Business Layer para MenuItem 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class BLMenuItem
    {
        #region Listar

        /// <summary> 
        /// Listar MenuItem
        /// </summary> 
        /// <param name="pobjMLMenuItem">Parametros para filtro</param>
        /// <returns>Lista de MenuItem</returns> 
        /// <user>GeradorVm2</user>
        public List<MLMenuItem> Listar(MLMenuItem pobjMLMenuItem)
        {

            Connector conMenuItem = new Connector();

            IDLMenuItem objDLMenuItem = conMenuItem.ObterDLMenuItem();
            List<MLMenuItem> lstRetorno = null;

            try
            {
                lstRetorno = objDLMenuItem.Listar(pobjMLMenuItem);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conMenuItem.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um MenuItem
        /// </summary> 
        /// <param name="pdecCodigo">Código do Item do Menu</param>
        /// <returns>MenuItem</returns> 
        /// <user>GeradorVm2</user>
        public MLMenuItem Obter(decimal pdecCodigo)
        {

            Connector conMenuItem = new Connector();

            IDLMenuItem objDLMenuItem = conMenuItem.ObterDLMenuItem();
            MLMenuItem objRetorno = null;

            try
            {
                objRetorno = objDLMenuItem.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conMenuItem.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um MenuItem
        /// </summary> 
        /// <param name="pdecCodigo">Código do Item do Menu</param>
        /// <returns>Retorna da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Excluir(String pstrCodigoItens)
        {

            Connector conMenuItem = new Connector();
            IDLMenuItem objDLMenuItem = conMenuItem.ObterDLMenuItem();
            bool objRetorno = false;

            try
            {
                objRetorno = objDLMenuItem.Excluir(pstrCodigoItens);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conMenuItem.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um MenuItem
        /// </summary> 
        /// <param name="pobjMLMenuItem">MenuItem com as alterações</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLMenuItem pobjMLMenuItem)
        {
            Connector conMenuItem = new Connector();
            IDLMenuItem objDLMenuItem = conMenuItem.ObterDLMenuItem();
            bool objRetorno = false;

            try
            {
                objRetorno = objDLMenuItem.Alterar(pobjMLMenuItem);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conMenuItem.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um MenuItem
        /// </summary> 
        /// <param name="pobjMLMenuItem">MenuItem a ser inserido</param>
        /// <returns>Código MenuItem</returns> 
        /// <user>GeradorVm2</user>
        public decimal Inserir(MLMenuItem pobjMLMenuItem)
        {
            Connector conMenuItem = new Connector();
            IDLMenuItem objDLMenuItem = conMenuItem.ObterDLMenuItem();
            decimal objRetorno = 0;

            try
            {
                objRetorno = objDLMenuItem.Inserir(pobjMLMenuItem);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conMenuItem.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar Ordem
        /// <summary>
        /// Alterar a ordem de exibição do item do menu
        /// </summary>
        /// <param name="pdecCodigoOrigem"></param>
        /// <param name="pdecCodigoDestino"></param>
        /// <user>tprohaska</user>
        public void AlterarOrdem(decimal pdecCodigoOrigem, decimal? pdecCodigoDestino, decimal pdecCodigoPaiDestino)
        {
            Connector conMenuItem = new Connector();
            IDLMenuItem objDLMenuItem = conMenuItem.ObterDLMenuItem();

            try
            {
                objDLMenuItem.AlterarOrdem(pdecCodigoOrigem, pdecCodigoDestino, pdecCodigoPaiDestino);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conMenuItem.Finalizar();
            }
        }
        #endregion

        #region Listar Pais

        /// <summary>
        ///     Execura a procedure de listagem de pais de itens
        /// </summary>
        /// <user>mazevedo</user>
        public List<MLMenuItem> ListarPais(decimal pdecCodigo)
        {
            List<MLMenuItem> lstRetorno = new List<MLMenuItem>();
            Connector conMenuItem = new Connector();
            IDLMenuItem objDLMenuItem = null;

            try
            {
                objDLMenuItem = conMenuItem.ObterDLMenuItem();
                lstRetorno = objDLMenuItem.ListarPais(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conMenuItem.Finalizar();
            }
            return lstRetorno;

        }

        #endregion

        #region Lista Filhos

        /// <summary>
        ///     Execura a procedure de listagem de filhos de itens
        /// </summary>
        /// <user>mazevedo</user>
        public List<MLMenuItem> ListarFilhos(decimal pdecCodigo)
        {
            List<MLMenuItem> lstRetorno = new List<MLMenuItem>();
            Connector conMenuItem = new Connector();
            IDLMenuItem objDLMenuItem = null;

            try
            {
                objDLMenuItem = conMenuItem.ObterDLMenuItem();
                lstRetorno = objDLMenuItem.ListarFilhos(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conMenuItem.Finalizar();
            }

            return lstRetorno;
        }

        #endregion
    }
}


