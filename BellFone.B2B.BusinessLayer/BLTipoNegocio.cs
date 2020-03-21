using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using BellFone.B2B.Model;
using BellFone.B2B.DataLayer;
using VM2.Framework.BusinessLayer.Utilitarios;
using System.Collections.ObjectModel;

namespace BellFone.B2B.BusinessLayer
{
    /// <summary> 
    /// Classe de Business Layer para TipoNegocio 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class BLTipoNegocio
    {

        #region Listar

        /// <summary> 
        /// Listar TipoNegocio
        /// </summary> 
        /// <param name="pobjMLTipoNegocio">Parametros para filtro</param>
        /// <returns>Lista de TipoNegocio</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLTipoNegocio> Listar(MLTipoNegocio pobjMLTipoNegocio)
        {

            DLTipoNegocio objDLTipoNegocio = new DLTipoNegocio();
            List<MLTipoNegocio> lstRetorno = null;
        
            try
            {
                lstRetorno = objDLTipoNegocio.Listar(pobjMLTipoNegocio);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLTipoNegocio.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um TipoNegocio
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>TipoNegocio</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLTipoNegocio Obter(string pstrCodigo)
        {

            DLTipoNegocio objDLTipoNegocio = new DLTipoNegocio();
            MLTipoNegocio objRetorno = null;
        
            try
            {
                objRetorno = objDLTipoNegocio.Obter(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLTipoNegocio.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region ObterUltimo

        /// <summary> 
        /// Obtem um TipoNegocio
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>TipoNegocio</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLTipoNegocio ObterUltimo(string pstrCodigo)
        {

            DLTipoNegocio objDLTipoNegocio = new DLTipoNegocio();
            MLTipoNegocio objRetorno = null;
            
            try
            {
                objRetorno = objDLTipoNegocio.ObterUltimo(pstrCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLTipoNegocio.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um TipoNegocio
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Excluir(string pstrCodigo)
        {

            DLTipoNegocio objDLTipoNegocio = new DLTipoNegocio();
        
            try
            {
                return objDLTipoNegocio.Excluir(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLTipoNegocio.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um TipoNegocio
        /// </summary> 
        /// <param name="pobjMLTipoNegocio">TipoNegocio com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLTipoNegocio pobjMLTipoNegocio)
        {

            DLTipoNegocio objDLTipoNegocio = new DLTipoNegocio();
        
            try
            {
                return objDLTipoNegocio.Alterar(pobjMLTipoNegocio);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLTipoNegocio.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um TipoNegocio
        /// </summary> 
        /// <param name="pobjMLTipoNegocio">TipoNegocio a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public  int Inserir(MLTipoNegocio pobjMLTipoNegocio)
        {

            DLTipoNegocio objDLTipoNegocio = new DLTipoNegocio();
        
            try
            {
                return objDLTipoNegocio.Inserir(pobjMLTipoNegocio);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLTipoNegocio.Finalizar();
            }
        }

        #endregion

        #region Importação de Tipo de Negocio

        /// <summary> 
        /// Insere Tipos de Negocios
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Tipos de Negocios a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLTipoNegocio> plstMLTipoNegocio, out List<string> objRetorno)
        {
            DLTipoNegocio objDLTipoNegocio = new DLTipoNegocio();
            bool boolIntegrou = false;
            var bolErro = false;
            objRetorno = new List<string>();

            try
            {
                objDLTipoNegocio.BeginTransaction();

                foreach (MLTipoNegocio objMLTipoNegocio in plstMLTipoNegocio)
                {
                    try
                    {
                        if (objMLTipoNegocio.Operacao == "I")
                        {
                            objDLTipoNegocio.Inserir(objMLTipoNegocio);
                        }
                        else if (objMLTipoNegocio.Operacao == "A")
                        {
                            var intCodigo = objDLTipoNegocio.Alterar(objMLTipoNegocio);

                            if (intCodigo == 0)
                            {
                                objDLTipoNegocio.Inserir(objMLTipoNegocio);
                            }
                        }
                        else if (objMLTipoNegocio.Operacao == "E")
                        {
                            objDLTipoNegocio.Excluir(objMLTipoNegocio.Codigo);
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLTipoNegocio.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLTipoNegocio.Codigo + " - Linha com erro(s). " + ex.Message);
                        bolErro = true;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLTipoNegocio.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLTipoNegocio.CommitTransaction();
                }

            }
            catch (Exception ex)
            {
                objRetorno.Add("Importação não realizada!!");
                objDLTipoNegocio.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLTipoNegocio.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion
    }
}


