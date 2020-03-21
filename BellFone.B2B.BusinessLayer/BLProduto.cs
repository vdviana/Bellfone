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
    /// Classe de Business Layer para Produto 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class BLProduto
    {

        #region Listar

        /// <summary> 
        /// Listar Produto
        /// </summary> 
        /// <param name="pobjMLProduto">Parametros para filtro</param>
        /// <param name="pstrRevendedorClassificacao">Classificação do Revendedor para buscar os preços</param>
        /// <returns>Lista de Produto</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public List<MLProduto> Listar(MLProduto pobjMLProduto, string pstrRevendedorClassificacao)
        {

            DLProduto objDLProduto = new DLProduto();
            List<MLProduto> lstRetorno = null;
        
            try
            {
                lstRetorno = objDLProduto.Listar(pobjMLProduto, pstrRevendedorClassificacao);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLProduto.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Produto
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <param name="pstrRevendedorClassificacao">Classificação do Revendedor para buscar os preços</param>
        /// <returns>Produto</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public MLProduto Obter(string pstrCodigo, string pstrRevendedorClassificacao)
        {

            DLProduto objDLProduto = new DLProduto();
            MLProduto objRetorno = null;
        
            try
            {
                objRetorno = objDLProduto.Obter(pstrCodigo, pstrRevendedorClassificacao);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLProduto.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Produto
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public int Excluir(string pstrCodigo)
        {

            DLProduto objDLProduto = new DLProduto();
        
            try
            {
                return objDLProduto.Excluir(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLProduto.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Produto
        /// </summary> 
        /// <param name="pobjMLProduto">Produto com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public int Alterar(MLProduto pobjMLProduto)
        {

            DLProduto objDLProduto = new DLProduto();
        
            try
            {
                return objDLProduto.Alterar(pobjMLProduto);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLProduto.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Produto
        /// </summary> 
        /// <param name="pobjMLProduto">Produto a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public  int Inserir(MLProduto pobjMLProduto)
        {

            DLProduto objDLProduto = new DLProduto();
        
            try
            {
                return objDLProduto.Inserir(pobjMLProduto);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLProduto.Finalizar();
            }
        }

        #endregion



        #region Listar Busca

        /// <summary> 
        /// Listar Produto Busca
        /// </summary> 
        /// <param name="pobjMLProduto">Parametros para filtro</param>
        /// <param name="pstrRevendedorClassificacao">Classificação do Revendedor para buscar os preços</param>
        /// <returns>Lista de Produto</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public List<MLProdutoBusca> ListarBusca(string strFabricanteCod, string strCategoriaCod, string strNomeProduto, bool bVisivel)
        {

            DLProduto objDLProduto = new DLProduto();
            List<MLProdutoBusca> lstRetorno = null;

            try
            {
                lstRetorno = objDLProduto.ListarBusca(strFabricanteCod, strCategoriaCod, strNomeProduto, bVisivel);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLProduto.Finalizar();
            }
            return lstRetorno;
        }

        #endregion
        
        #region Listar Produtos Completo
        /// <summary> 
        /// Listar Produto Completo
        /// </summary> 
        /// <param name="pobjMLProdutoCompleto">Parametros para filtro</param>
        /// <param name="pstrRevendedorClassificacao">Classificação do Revendedor para buscar os preços</param>
        /// <returns>Lista de Produto Completo</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLProdutoCompleto> ListarCompleto(MLProdutoCompleto pobjMLProdutoCompleto, String pstrRevendedorClassificacao)
        {

            string strChaveCache = string.Empty;
            strChaveCache = "cchProdutoListarCompleto"
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.CaminhoImagem)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.CategoriaCodigo)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.CategoriaDescricao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.Classificacao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.Codigo)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.CodigoFabricante)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.CodigoSubgrupo)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.CodigoUnidadeMedida)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.Descricao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.FabricanteDescricao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.GrupoCodigo)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.GrupoDescricao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.IsDestaque)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.IsStatus)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.IsVisivel)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.Link)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.Nome)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.Operacao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.SubGrupoDescricao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.TemImagem)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.UnidadeMedidaDescricao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.ValorDe)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.ValorOriginal)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.ValorPor)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.ValorPromocional)
                + BLFuncoes.StringISNullCache(pstrRevendedorClassificacao);

            if (HttpContext.Current.Cache[strChaveCache] != null)
                return (List<MLProdutoCompleto>)System.Web.HttpContext.Current.Cache[strChaveCache];

            var objDLProduto = new DLProduto();
            List<MLProdutoCompleto> lstRetorno = null;

            try
            {
                lstRetorno = objDLProduto.ListarCompleto(pobjMLProdutoCompleto, pstrRevendedorClassificacao);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLProduto.Finalizar();
            }

            HttpContext.Current.Cache.Insert(strChaveCache, lstRetorno, null, DateTime.Now.AddMinutes(BLConfiguracao.TempoExpiracaoCacheListar("cchProdutoListarCompleto")), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            return lstRetorno;
        }
        #endregion

        #region  Listar Produtos Completo Aleatório
        /// <summary> 
        /// Listar Produtos Aleatorios
        /// </summary> 
        /// <param name="pstrClassificacaoUsuario"></param>
        /// <returns>Lista de Produto</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLProdutoCompleto> ListarCompletoAleatorios(MLProdutoCompleto pobjMLProdutoCompleto, String pstrClassificacaoUsuario, bool boolIsVitrine)
        {

            string strChaveCache = string.Empty;
            strChaveCache = "cchProdutoListarCompletoAleatorios" 
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.CaminhoImagem)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.CategoriaCodigo)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.CategoriaDescricao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.Classificacao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.Codigo)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.CodigoFabricante)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.CodigoSubgrupo)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.CodigoUnidadeMedida)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.Descricao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.FabricanteDescricao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.GrupoCodigo)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.GrupoDescricao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.IsDestaque)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.IsStatus)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.IsVisivel)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.Link)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.Nome)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.Operacao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.SubGrupoDescricao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.TemImagem)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.UnidadeMedidaDescricao)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.ValorDe)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.ValorOriginal)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.ValorPor)
                + BLFuncoes.StringISNullCache(pobjMLProdutoCompleto.ValorPromocional)
                + BLFuncoes.StringISNullCache(pstrClassificacaoUsuario)
                + BLFuncoes.StringISNullCache(boolIsVitrine);

            if (HttpContext.Current.Cache[strChaveCache] != null)
                return (List<MLProdutoCompleto>)System.Web.HttpContext.Current.Cache[strChaveCache];


            DLProduto objDLProduto = new DLProduto();
            List<MLProdutoCompleto> lstRetorno = null;

            try
            {
                lstRetorno = objDLProduto.ListarCompletoAleatorio(pobjMLProdutoCompleto, pstrClassificacaoUsuario, boolIsVitrine);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLProduto.Finalizar();
            }

            HttpContext.Current.Cache.Insert(strChaveCache, lstRetorno, null, DateTime.Now.AddMinutes(BLConfiguracao.TempoExpiracaoCacheListar("cchProdutoListarCompletoAleatorios")), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            return lstRetorno;
        }
        #endregion

        #region Obter Produto Completo
        /// <summary> 
        /// Obtem um Produto
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Produto</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLProdutoCompleto ObterCompleto(string pstrCodigo, string pstrClassificacao)
        {

            string strChaveCache = string.Empty;
            strChaveCache = "cchProdutoObterCompleto"
                + BLFuncoes.StringISNullCache(pstrCodigo)
                + BLFuncoes.StringISNullCache(pstrClassificacao);

            if (HttpContext.Current.Cache[strChaveCache] != null)
                return (MLProdutoCompleto)System.Web.HttpContext.Current.Cache[strChaveCache];


            DLProduto objDLProduto = new DLProduto();
            MLProdutoCompleto objRetorno = null;

            try
            {
                objRetorno = objDLProduto.ObterCompleto(pstrCodigo, pstrClassificacao);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLProduto.Finalizar();
            }

            HttpContext.Current.Cache.Insert(strChaveCache, objRetorno, null, DateTime.Now.AddMinutes(BLConfiguracao.TempoExpiracaoCacheListar("cchProdutoObterCompleto")), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            return objRetorno;
        }
        #endregion

        #region Importação de Produtos

        /// <summary> 
        /// Importação de Produtos
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Categorias a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLProduto> plstMLProduto, out List<string> objRetorno)
        {
            DLProduto objDLProduto = new DLProduto();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                objDLProduto.BeginTransaction();

                foreach (MLProduto objMLProduto in plstMLProduto)
                {
                    try
                    {
                        if (objMLProduto.Operacao == "I")
                        {
                            objDLProduto.Inserir(objMLProduto);

                        }
                        else if (objMLProduto.Operacao == "A")
                        {
                            var intCodigo = objDLProduto.Alterar(objMLProduto);

                            if (intCodigo == 0)
                            {
                                objDLProduto.Inserir(objMLProduto);
                            }
                        }
                        else if (objMLProduto.Operacao == "E")
                        {
                            objDLProduto.Excluir(objMLProduto.Codigo);
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLProduto.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLProduto.Codigo + " - Linha com erro(s). " + ex.Message);
                        throw;
                    }
                }
                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLProduto.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLProduto.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                objRetorno.Add("Importação não realizada!!");
                objDLProduto.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLProduto.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion
        
    }
}


