using System;
using System.Text;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.DataLayer;
using VM2.Framework.BusinessLayer.Utilitarios;
using VM2.Framework.Model.Enquete ;
using VM2.Framework.DataLayer.Enquete ;
using VM2.Framework.DataLayer.Enquete.Sql;

namespace VM2.Framework.BusinessLayer.EnqueteOpcao
{
    /// <summary> 
    /// Classe de Business Layer para EnqueteOpcao 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class BLEnqueteOpcao
    {

        #region Listar

        /// <summary> 
        /// Listar EnqueteOpcao
        /// </summary> 
        /// <param name="pobjMLEnqueteOpcao">Parametros para filtro</param>
        /// <returns>Lista de EnqueteOpcao</returns> 
        /// <user>GeradorVm2</user>
        public List<MLEnqueteOpcao> Listar(MLEnqueteOpcao pobjMLEnqueteOpcao, decimal regAtual)
        {

            Connector conEnqueteOpcao = new Connector();
            IDLEnqueteOpcao objDLEnqueteOpcao = conEnqueteOpcao.ObterDLEnqueteOpcao();

            List<MLEnqueteOpcao> lstRetorno = null;
            try
            {
                lstRetorno = objDLEnqueteOpcao.Listar(pobjMLEnqueteOpcao, regAtual);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conEnqueteOpcao.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um EnqueteOpcao
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>EnqueteOpcao</returns> 
        /// <user>GeradorVm2</user>
        public MLEnqueteOpcao Obter(decimal pdecCodigo)
        {

            Connector conEnqueteOpcao = new Connector();
            IDLEnqueteOpcao objDLEnqueteOpcao = conEnqueteOpcao.ObterDLEnqueteOpcao();
            MLEnqueteOpcao objRetorno = null;

            try
            {
                objRetorno = objDLEnqueteOpcao.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conEnqueteOpcao.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um EnqueteOpcao
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Retorna da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Excluir(decimal pdecCodigo)
        {

            Connector conEnqueteOpcao = new Connector();
            IDLEnqueteOpcao objDLEnqueteOpcao = conEnqueteOpcao.ObterDLEnqueteOpcao();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLEnqueteOpcao.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conEnqueteOpcao.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um EnqueteOpcao
        /// </summary> 
        /// <param name="pobjMLEnqueteOpcao">EnqueteOpcao com as alterações</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLEnqueteOpcao pobjMLEnqueteOpcao)
        {

            Connector conEnqueteOpcao = new Connector();
            IDLEnqueteOpcao objDLEnqueteOpcao = conEnqueteOpcao.ObterDLEnqueteOpcao();

            bool objRetorno = false;

            try
            {
                objRetorno = objDLEnqueteOpcao.Alterar(pobjMLEnqueteOpcao);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conEnqueteOpcao.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um EnqueteOpcao
        /// </summary> 
        /// <param name="pobjMLEnqueteOpcao">EnqueteOpcao a ser inserido</param>
        /// <returns>Código EnqueteOpcao</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLEnqueteOpcao pobjMLEnqueteOpcao)
        {

            Connector conEnqueteOpcao = new Connector();
            IDLEnqueteOpcao objDLEnqueteOpcao = conEnqueteOpcao.ObterDLEnqueteOpcao();

            int objRetorno = 0;

            try
            {
                objRetorno = objDLEnqueteOpcao.Inserir(pobjMLEnqueteOpcao);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conEnqueteOpcao.Finalizar();
            }
            return objRetorno;
        }

        #endregion
    }
}


