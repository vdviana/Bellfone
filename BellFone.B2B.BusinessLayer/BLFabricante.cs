using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using BellFone.B2B.Model;
using BellFone.B2B.DataLayer;
using VM2.Framework.BusinessLayer.Utilitarios;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.Caching;

namespace BellFone.B2B.BusinessLayer
{
    /// <summary> 
    /// Classe de Business Layer para Fabricante 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class BLFabricante
    {

        #region Listar

        /// <summary> 
        /// Listar Fabricante
        /// </summary> 
        /// <param name="pobjMLFabricante">Parametros para filtro</param>
        /// <returns>Lista de Fabricante</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLFabricante> Listar(MLFabricante pobjMLFabricante)
        {

            string strChaveCache = string.Empty;
            strChaveCache = "cchFabricanteListar"
                + BLFuncoes.StringISNullCache(pobjMLFabricante.Codigo)
                + BLFuncoes.StringISNullCache(pobjMLFabricante.Descricao)
                + BLFuncoes.StringISNullCache(pobjMLFabricante.IsAtivo)
                + BLFuncoes.StringISNullCache(pobjMLFabricante.Operacao);

            if (HttpContext.Current.Cache[strChaveCache] != null)
                return (List<MLFabricante>)System.Web.HttpContext.Current.Cache[strChaveCache];

            DLFabricante objDLFabricante = new DLFabricante();
            List<MLFabricante> lstRetorno = null;
        
            try
            {
                lstRetorno = objDLFabricante.Listar(pobjMLFabricante);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFabricante.Finalizar();
            }

            HttpContext.Current.Cache.Insert(strChaveCache, lstRetorno, null, DateTime.Now.AddMinutes(BLConfiguracao.TempoExpiracaoCacheListar("cchFabricanteListar")), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Fabricante
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Fabricante</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLFabricante Obter(string pstrCodigo)
        {

            DLFabricante objDLFabricante = new DLFabricante();
            MLFabricante objRetorno = null;
        
            try
            {
                objRetorno = objDLFabricante.Obter(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFabricante.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Fabricante
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Excluir(string pstrCodigo)
        {

            DLFabricante objDLFabricante = new DLFabricante();
        
            try
            {
                return objDLFabricante.Excluir(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFabricante.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Fabricante
        /// </summary> 
        /// <param name="pobjMLFabricante">Fabricante com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLFabricante pobjMLFabricante)
        {

            DLFabricante objDLFabricante = new DLFabricante();
        
            try
            {
                return objDLFabricante.Alterar(pobjMLFabricante);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFabricante.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Fabricante
        /// </summary> 
        /// <param name="pobjMLFabricante">Fabricante a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public  int Inserir(MLFabricante pobjMLFabricante)
        {

            DLFabricante objDLFabricante = new DLFabricante();
        
            try
            {
                return objDLFabricante.Inserir(pobjMLFabricante);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFabricante.Finalizar();
            }
        }

        #endregion

        #region Importação de Fabricante

        /// <summary> 
        /// Insere um Fabricante
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Fabricantes a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLFabricante> plstMLFabricante, out List<string> objRetorno)
        {
            DLFabricante objDLFabricante = new DLFabricante();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                objDLFabricante.BeginTransaction();

                foreach (MLFabricante objMLFabricante in plstMLFabricante)
                {
                    try
                    {
                        if (objMLFabricante.Operacao == "I")
                        {
                            objDLFabricante.Inserir(objMLFabricante);
                        }
                        else if (objMLFabricante.Operacao == "A")
                        {
                            var intCodigo = objDLFabricante.Alterar(objMLFabricante);

                            if (intCodigo == 0)
                            {
                                objDLFabricante.Inserir(objMLFabricante);
                            }
                        }
                        else if (objMLFabricante.Operacao == "E")
                        {
                            objDLFabricante.Excluir(objMLFabricante.Codigo);
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLFabricante.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLFabricante.Codigo + " - Linha com erro(s). " + ex.Message);
                        bolErro = true;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLFabricante.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLFabricante.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                objRetorno.Add("Importação não realizada!!");
                objDLFabricante.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLFabricante.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion
    }
}


