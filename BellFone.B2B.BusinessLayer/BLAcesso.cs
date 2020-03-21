using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using BellFone.B2B.Model;
using BellFone.B2B.DataLayer;
using VM2.Framework.BusinessLayer.Utilitarios;

namespace BellFone.B2B.BusinessLayer
{
    /// <summary> 
    /// Classe de Business Layer para Acesso 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class BLAcesso
    {

        #region Listar

        /// <summary> 
        /// Listar Acesso
        /// </summary> 
        /// <param name="pobjMLAcesso">Parametros para filtro</param>
        /// <returns>Lista de Acesso</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLAcesso> Listar(MLAcesso pobjMLAcesso)
        {

            DLAcesso objDLAcesso = new DLAcesso();
            List<MLAcesso> lstRetorno = null;

            try
            {
                lstRetorno = objDLAcesso.Listar(pobjMLAcesso);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLAcesso.Finalizar();
            }
            return lstRetorno;
        }

        public List<MLAcesso> ListarRelatorio(MLAcesso pobjMLAcesso)
        {

            DLAcesso objDLAcesso = new DLAcesso();
            List<MLAcesso> lstRetorno = null;

            try
            {
                lstRetorno = objDLAcesso.ListarRelatorio(pobjMLAcesso);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLAcesso.Finalizar();
            }
            return lstRetorno;
        }

        

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Acesso
        /// </summary> 
        /// <param name="pobjMLAcesso">Acesso a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Inserir(MLAcesso pobjMLAcesso)
        {

            DLAcesso objDLAcesso = new DLAcesso();

            try
            {
                return objDLAcesso.Inserir(pobjMLAcesso);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLAcesso.Finalizar();
            }
        }

        #endregion
    }
}


