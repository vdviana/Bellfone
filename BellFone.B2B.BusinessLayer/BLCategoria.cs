using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using BellFone.B2B.Model;
using BellFone.B2B.DataLayer;
using VM2.Framework.BusinessLayer.Utilitarios;
using System.Collections.ObjectModel;
using VM2.Framework.Model.Utilitarios;
using BellFone.B2B.BusinessLayer.Configuration;
using System.Web.Caching;
using System.Web;

namespace BellFone.B2B.BusinessLayer
{
    /// <summary> 
    /// Classe de Business Layer para Categoria 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class BLCategoria
    {

        #region Listar

        /// <summary> 
        /// Listar Categoria
        /// </summary> 
        /// <param name="pobjMLCategoria">Parametros para filtro</param>
        /// <returns>Lista de Categoria</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLCategoria> Listar(MLCategoria pobjMLCategoria, bool bProdutoAtivo, bool? bProdutoVisivel)
        {

            string strChaveCache = string.Empty;
            strChaveCache = "cchCategoriaListar"
                + BLFuncoes.StringISNullCache(pobjMLCategoria.Codigo)
                + BLFuncoes.StringISNullCache(pobjMLCategoria.Descricao)
                + BLFuncoes.StringISNullCache(pobjMLCategoria.IsAtivo)
                + BLFuncoes.StringISNullCache(pobjMLCategoria.Operacao)
                + BLFuncoes.StringISNullCache(bProdutoAtivo)
                + BLFuncoes.StringISNullCache(bProdutoVisivel);

            if (HttpContext.Current.Cache[strChaveCache] != null)
                return (List<MLCategoria>)System.Web.HttpContext.Current.Cache[strChaveCache];

            DLCategoria objDLCategoria = new DLCategoria();
            List<MLCategoria> lstRetorno = null;
        
            try
            {
                var strConfiguracao = UTConfiguracao.ObterIdConfiguracaoTreinamento();

                BLConfiguracao objBLConfiguracao = new BLConfiguracao();
                MLConfiguracao objConfiguracao = objBLConfiguracao.Obter(strConfiguracao);

                lstRetorno = objDLCategoria.Listar(pobjMLCategoria, objConfiguracao.Valor, bProdutoAtivo, bProdutoVisivel);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLCategoria.Finalizar();
            }

            HttpContext.Current.Cache.Insert(strChaveCache, lstRetorno, null, DateTime.Now.AddMinutes(BLConfiguracao.TempoExpiracaoCacheListar("cchCategoriaListar")), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Categoria
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Categoria</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLCategoria Obter(string pstrCodigo)
        {

            DLCategoria objDLCategoria = new DLCategoria();
            MLCategoria objRetorno = null;
        
            try
            {
                objRetorno = objDLCategoria.Obter(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLCategoria.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Categoria
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Excluir(string pstrCodigo)
        {

            DLCategoria objDLCategoria = new DLCategoria();
        
            try
            {
                return objDLCategoria.Excluir(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLCategoria.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Categoria
        /// </summary> 
        /// <param name="pobjMLCategoria">Categoria com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLCategoria pobjMLCategoria)
        {

            DLCategoria objDLCategoria = new DLCategoria();
        
            try
            {
                return objDLCategoria.Alterar(pobjMLCategoria);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLCategoria.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Categoria
        /// </summary> 
        /// <param name="pobjMLCategoria">Categoria a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public  int Inserir(MLCategoria pobjMLCategoria)
        {

            DLCategoria objDLCategoria = new DLCategoria();
        
            try
            {
                return objDLCategoria.Inserir(pobjMLCategoria);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLCategoria.Finalizar();
            }
        }

        #endregion

        #region Importação de Categorias

        /// <summary> 
        /// Insere Categorias
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Categorias a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLCategoria> plstMLCategoria, out List<string> objRetorno)
        {
            DLCategoria objDLCategoria = new DLCategoria();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                objDLCategoria.BeginTransaction();

                foreach (MLCategoria objMLCategoria in plstMLCategoria)
                {
                    try
                    {
                        if (objMLCategoria.Operacao == "I")
                        {
                            objDLCategoria.Inserir(objMLCategoria);
                        }
                        else if (objMLCategoria.Operacao == "A")
                        {
                            var intCodigo = objDLCategoria.Alterar(objMLCategoria);

                            if (intCodigo == 0)
                            {
                                objDLCategoria.Inserir(objMLCategoria);
                            }
                        }
                        else if (objMLCategoria.Operacao == "E")
                        {
                            objDLCategoria.Excluir(objMLCategoria.Codigo);
                        }   
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLCategoria.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLCategoria.Codigo + " - Linha com erros. " + ex.Message);
                        bolErro = true;
                        break;
                    }                                  
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLCategoria.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLCategoria.CommitTransaction();
                }
                
            }
            catch (Exception ex)
            {
                objDLCategoria.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLCategoria.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion
    }
}


