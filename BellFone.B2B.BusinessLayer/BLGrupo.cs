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
    /// Classe de Business Layer para Grupo 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class BLGrupo
    {

        #region Listar

        /// <summary> 
        /// Listar Grupo
        /// </summary> 
        /// <param name="pobjMLGrupo">Parametros para filtro</param>
        /// <returns>Lista de Grupo</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLGrupo> Listar(MLGrupo pobjMLGrupo, bool bProdutoAtivo, bool? bProdutoVisivel)
        {

            string strChaveCache = string.Empty;
            strChaveCache = "cchGrupoListar"
                + BLFuncoes.StringISNullCache(pobjMLGrupo.Codigo)
                + BLFuncoes.StringISNullCache(pobjMLGrupo.CodigoCategoria)
                + BLFuncoes.StringISNullCache(pobjMLGrupo.Descricao)
                + BLFuncoes.StringISNullCache(pobjMLGrupo.IsAtivo)
                + BLFuncoes.StringISNullCache(pobjMLGrupo.Operacao);

            if (HttpContext.Current.Cache[strChaveCache] != null)
                return (List<MLGrupo>)System.Web.HttpContext.Current.Cache[strChaveCache];

            DLGrupo objDLGrupo = new DLGrupo();
            List<MLGrupo> lstRetorno = null;
        
            try
            {
                lstRetorno = objDLGrupo.Listar(pobjMLGrupo, bProdutoAtivo, bProdutoVisivel);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLGrupo.Finalizar();
            }

            HttpContext.Current.Cache.Insert(strChaveCache, lstRetorno, null, DateTime.Now.AddMinutes(BLConfiguracao.TempoExpiracaoCacheListar("cchGrupoListar")), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Grupo
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Grupo</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLGrupo Obter(string pstrCodigo)
        {

            DLGrupo objDLGrupo = new DLGrupo();
            MLGrupo objRetorno = null;
        
            try
            {
                objRetorno = objDLGrupo.Obter(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLGrupo.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Grupo
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Excluir(string pstrCodigo)
        {

            DLGrupo objDLGrupo = new DLGrupo();
        
            try
            {
                return objDLGrupo.Excluir(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLGrupo.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Grupo
        /// </summary> 
        /// <param name="pobjMLGrupo">Grupo com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLGrupo pobjMLGrupo)
        {

            DLGrupo objDLGrupo = new DLGrupo();
        
            try
            {
                return objDLGrupo.Alterar(pobjMLGrupo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLGrupo.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Grupo
        /// </summary> 
        /// <param name="pobjMLGrupo">Grupo a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public  int Inserir(MLGrupo pobjMLGrupo)
        {

            DLGrupo objDLGrupo = new DLGrupo();
        
            try
            {
                return objDLGrupo.Inserir(pobjMLGrupo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLGrupo.Finalizar();
            }
        }

        #endregion

        #region Importação de Grupo

        /// <summary> 
        /// Insere Grupos
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Grupos a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLGrupo> plstMLGrupo, out List<string> objRetorno)
        {
            var objDLGrupo = new BellFone.B2B.DataLayer.DLGrupo();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                objDLGrupo.BeginTransaction();

                foreach (MLGrupo objMLGrupo in plstMLGrupo)
                {
                    try
                    {
                        if (objMLGrupo.Operacao == "I")
                        {
                            objDLGrupo.Inserir(objMLGrupo);
                        }
                        else if (objMLGrupo.Operacao == "A")
                        {
                            var intCodigo = objDLGrupo.Alterar(objMLGrupo);

                            if (intCodigo == 0)
                            {
                                objDLGrupo.Inserir(objMLGrupo);
                            }
                        }
                        else if (objMLGrupo.Operacao == "E")
                        {
                            objDLGrupo.Excluir(objMLGrupo.Codigo);
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLGrupo.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLGrupo.Codigo + " - Linha com erros. " + ex.Message);
                        bolErro = true;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLGrupo.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLGrupo.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                objRetorno.Add("Importação não realizada!!");
                objDLGrupo.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLGrupo.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion
    }
}



