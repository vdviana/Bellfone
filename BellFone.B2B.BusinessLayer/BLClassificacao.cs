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
    /// Classe de Business Layer para Classificacao 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.1.1]</user> 
    public class BLClassificacao
    {

        #region Listar

        /// <summary> 
        /// Listar Classificacao
        /// </summary> 
        /// <param name="pobjMLClassificacao">Parametros para filtro</param>
        /// <returns>Lista de Classificacao</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public List<MLClassificacao> Listar(MLClassificacao pobjMLClassificacao)
        {

            DLClassificacao objDLClassificacao = new DLClassificacao();
            List<MLClassificacao> lstRetorno = null;

            try
            {
                lstRetorno = objDLClassificacao.Listar(pobjMLClassificacao);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLClassificacao.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Classificacao
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Classificacao</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public MLClassificacao Obter(decimal pdecCodigo)
        {

            DLClassificacao objDLClassificacao = new DLClassificacao();
            MLClassificacao objRetorno = null;

            try
            {
                objRetorno = objDLClassificacao.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLClassificacao.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Classificacao
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public int Excluir(decimal pdecCodigo)
        {

            DLClassificacao objDLClassificacao = new DLClassificacao();

            try
            {
                return objDLClassificacao.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLClassificacao.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Classificacao
        /// </summary> 
        /// <param name="pobjMLClassificacao">Classificacao com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public int Alterar(MLClassificacao pobjMLClassificacao)
        {

            DLClassificacao objDLClassificacao = new DLClassificacao();

            try
            {
                return objDLClassificacao.Alterar(pobjMLClassificacao);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLClassificacao.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Classificacao
        /// </summary> 
        /// <param name="pobjMLClassificacao">Classificacao a ser inserido</param>
        /// <returns>Código Classificacao</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public decimal Inserir(MLClassificacao pobjMLClassificacao)
        {

            DLClassificacao objDLClassificacao = new DLClassificacao();

            try
            {
                return objDLClassificacao.Inserir(pobjMLClassificacao);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLClassificacao.Finalizar();
            }
        }

        #endregion
    }
}


