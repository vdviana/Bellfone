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
    /// Classe de Business Layer para Subgrupo 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class BLSubgrupo
    {

        #region Listar

        /// <summary> 
        /// Listar Subgrupo
        /// </summary> 
        /// <param name="pobjMLSubgrupo">Parametros para filtro</param>
        /// <returns>Lista de Subgrupo</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLSubgrupo> Listar(MLSubgrupo pobjMLSubgrupo, bool bProdutoAtivo, bool? bProdutoVisivel)
        {

            string strChaveCache = string.Empty;
            strChaveCache = "cchSubgrupoListar"
                + BLFuncoes.StringISNullCache(pobjMLSubgrupo.Codigo)
                + BLFuncoes.StringISNullCache(pobjMLSubgrupo.CodigoGrupo)
                + BLFuncoes.StringISNullCache(pobjMLSubgrupo.Descricao)
                + BLFuncoes.StringISNullCache(pobjMLSubgrupo.IsAtivo)
                + BLFuncoes.StringISNullCache(pobjMLSubgrupo.Operacao);

            if (HttpContext.Current.Cache[strChaveCache] != null)
                return (List<MLSubgrupo>)System.Web.HttpContext.Current.Cache[strChaveCache];

            DLSubgrupo objDLSubgrupo = new DLSubgrupo();
            List<MLSubgrupo> lstRetorno = null;
        
            try
            {
                lstRetorno = objDLSubgrupo.Listar(pobjMLSubgrupo, bProdutoAtivo, bProdutoVisivel);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLSubgrupo.Finalizar();
            }

            HttpContext.Current.Cache.Insert(strChaveCache, lstRetorno, null, DateTime.Now.AddMinutes(BLConfiguracao.TempoExpiracaoCacheListar("cchSubgrupoListar")), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Subgrupo
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Subgrupo</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLSubgrupo Obter(string pstrCodigo)
        {

            DLSubgrupo objDLSubgrupo = new DLSubgrupo();
            MLSubgrupo objRetorno = null;
        
            try
            {
                objRetorno = objDLSubgrupo.Obter(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLSubgrupo.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Subgrupo
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Excluir(string pstrCodigo)
        {

            DLSubgrupo objDLSubgrupo = new DLSubgrupo();
        
            try
            {
                return objDLSubgrupo.Excluir(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLSubgrupo.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Subgrupo
        /// </summary> 
        /// <param name="pobjMLSubgrupo">Subgrupo com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLSubgrupo pobjMLSubgrupo)
        {

            DLSubgrupo objDLSubgrupo = new DLSubgrupo();
        
            try
            {
                return objDLSubgrupo.Alterar(pobjMLSubgrupo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLSubgrupo.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Subgrupo
        /// </summary> 
        /// <param name="pobjMLSubgrupo">Subgrupo a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public  int Inserir(MLSubgrupo pobjMLSubgrupo)
        {

            DLSubgrupo objDLSubgrupo = new DLSubgrupo();
        
            try
            {
                return objDLSubgrupo.Inserir(pobjMLSubgrupo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLSubgrupo.Finalizar();
            }
        }

        #endregion

        #region Importação de Subgrupo

        /// <summary> 
        /// Insere Subgrupos
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Subgrupos a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLSubgrupo> plstMLSubgrupo, out List<string> objRetorno)
        {
            DLSubgrupo objDLSubgrupo = new DLSubgrupo();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                objDLSubgrupo.BeginTransaction();

                foreach (MLSubgrupo objMLSubgrupo in plstMLSubgrupo)
                {
                    try
                    {
                        if (objMLSubgrupo.Operacao == "I")
                        {
                            objDLSubgrupo.Inserir(objMLSubgrupo);
                        }
                        else if (objMLSubgrupo.Operacao == "A")
                        {
                            var intCodigo = objDLSubgrupo.Alterar(objMLSubgrupo);

                            if (intCodigo == 0)
                            {
                                objDLSubgrupo.Inserir(objMLSubgrupo);
                            }
                        }
                        else if (objMLSubgrupo.Operacao == "E")
                        {
                            objDLSubgrupo.Excluir(objMLSubgrupo.Codigo);
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLSubgrupo.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLSubgrupo.Codigo + " - Linha com erros. " + ex.Message);
                        bolErro = true;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLSubgrupo.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLSubgrupo.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                objRetorno.Add("Importação não realizada!!");
                objDLSubgrupo.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLSubgrupo.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion
    }
}


