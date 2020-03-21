using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BellFone.B2B.DataLayer;
using BellFone.B2B.Model;
using VM2.Framework.BusinessLayer.Utilitarios;

namespace BellFone.B2B.BusinessLayer
{
    public class BLRelatorios
    {
        #region OrcamentoRelatorio

        #region OrcamentoRevendedorRelatorio

        /// <summary> 
        /// Listar MiniBanner
        /// </summary> 
        /// <param name="pobjMLMiniBanner">Parametros para filtro</param>
        /// <returns>Lista de MiniBanner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLOrcamentoRelatorio> OrcamentoRelatorio(decimal pdecOrcamento)
        {

            var objDLRelatorios = new DLRelatorios();
            List<MLOrcamentoRelatorio> lstRetorno = null;

            try
            {
                lstRetorno = objDLRelatorios.OrcamentoRelatorio(pdecOrcamento);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRelatorios.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Relatorio de Itens de Orcamento e Pedido

        /// <summary> 
        /// Listar Orçamentos para uso em relatório
        /// </summary> 
        /// <returns>Lista de MLPedidoOrcamentoItensRelatorio</returns> 
        /// <user>etani</user>
        public List<MLPedidoOrcamentoItensRelatorio> RelatorioOrcamentoPedidoItens(MLPedidoOrcamentoRelatorio pobjMLPedidoOrcamentoRelatorio)
        {
            var objDLRelatorios = new DLRelatorios();
            List<MLPedidoOrcamentoItensRelatorio> lstRetorno = null;

            try
            {
                lstRetorno = objDLRelatorios.RelatorioOrcamentoPedidoItens(pobjMLPedidoOrcamentoRelatorio);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRelatorios.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Relatorio de Orcamento e Pedido Por Dia

        /// <summary> 
        /// Listar Orçamentos para uso em relatório
        /// </summary> 
        /// <returns>Lista de MLPedidoOrcamentoRelatorioPorDia</returns> 
        /// <user>etani</user>
        public List<MLPedidoOrcamentoRelatorioPorDia> RelatorioOrcamentoPedidoPorDia(MLPedidoOrcamentoRelatorioPorDia pobjMLPedidoOrcamentoRelatorioPorDia)
        {
            var objDLRelatorios = new DLRelatorios();
            List<MLPedidoOrcamentoRelatorioPorDia> lstRetorno = null;

            try
            {
                lstRetorno = objDLRelatorios.RelatorioOrcamentoPedidoPorDia(pobjMLPedidoOrcamentoRelatorioPorDia);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRelatorios.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Relatorio de Orcamento e Pedido

        /// <summary> 
        /// Listar Orçamentos para uso em relatório
        /// </summary> 
        /// <returns>Lista de MLPedidoOrcamentoRelatorio</returns> 
        /// <user>etani</user>
        public List<MLPedidoOrcamentoRelatorio> RelatorioOrcamentoPedido(MLPedidoOrcamentoRelatorioPorDia pobjMLPedidoOrcamentoRelatorioPorDia)
        {
            var objDLRelatorios = new DLRelatorios();
            List<MLPedidoOrcamentoRelatorio> lstRetorno = null;

            try
            {
                lstRetorno = objDLRelatorios.RelatorioOrcamentoPedido(pobjMLPedidoOrcamentoRelatorioPorDia);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRelatorios.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #endregion

        #region AcessoRelatorio

        #region Cabeçalho do Relatorio

        /// <summary> 
        /// Listar Acessos para o Relatório
        /// </summary> 
        /// <param name="pdecUsuario">Código do Usuário</param>
        /// <param name="pdtDe">Data De</param>
        /// <param name="pdtAte">Data Ate</param>
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLAcessosCabecalhoRelatorio> AcessoCabecalhoRelatorio(decimal pdecUsuario, DateTime pdtDe, DateTime pdtAte)
        {

            var objDLRelatorios = new DLRelatorios();
            List<MLAcessosCabecalhoRelatorio> lstRetorno = null;

            try
            {
                lstRetorno = objDLRelatorios.AcessoCabecalhoRelatorio(pdecUsuario, pdtDe, pdtAte);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRelatorios.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Detalhes Relatorio

        /// <summary> 
        /// Listar Acessos para o Relatório
        /// </summary> 
        /// <param name="pdecUsuario">Código do Usuário</param>
        /// <param name="pdtDe">Data De</param>
        /// <param name="pdtAte">Data Ate</param>
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLAcessosRelatorio> AcessoDetalhesRelatorio(decimal pdecUsuario, DateTime pdtDe, DateTime pdtAte)
        {

            var objDLRelatorios = new DLRelatorios();
            List<MLAcessosRelatorio> lstRetorno = null;

            try
            {
                lstRetorno = objDLRelatorios.AcessoDetalhesRelatorio(pdecUsuario, pdtDe, pdtAte);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRelatorios.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #endregion

        #region FichaFinanceiraRelatorio

        #region Cabeçalho do Relatorio

        /// <summary> 
        /// Listar Acessos para o Relatório
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLFichaFinanceiraCabecalhoRelatorio> FichaFinanceiraCabecalhoRelatorio(string pstrRevendedorCodigo, DateTime? pdtDe, DateTime? pdtAte, bool? pbooSituacao)
        {

            var objDLRelatorios = new DLRelatorios();
            List<MLFichaFinanceiraCabecalhoRelatorio> lstRetorno = null;

            try
            {
                lstRetorno = objDLRelatorios.FichaFinanceiraCabecalhoRelatorio(pstrRevendedorCodigo, pdtDe, pdtAte, pbooSituacao);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRelatorios.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Detalhes Relatorio

        /// <summary> 
        /// Listar Acessos para o Relatório
        /// </summary> 
        /// <param name="pdecUsuario">Código do Usuário</param>
        /// <param name="pdtDe">Data De</param>
        /// <param name="pdtAte">Data Ate</param>
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLFichaFinanceiraDetalheRelatorio> FichaFinanceiraDetalheRelatorio(string pstrRevendedorCodigo, DateTime pdtDe, bool? pbooSituacao)
        {

            var objDLRelatorios = new DLRelatorios();
            List<MLFichaFinanceiraDetalheRelatorio> lstRetorno = null;

            try
            {
                lstRetorno = objDLRelatorios.FichaFinanceiraDetalheRelatorio(pdtDe, pbooSituacao, pstrRevendedorCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRelatorios.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #endregion

        #region ExtratoFinanceiro

        #region Cabeçalho do Relatorio

        /// <summary> 
        /// Listar Acessos para o Relatório
        /// </summary> 
        /// <param name="pstrRevendedorCodigo">Código do Revendedor</param>
        /// <param name="pdtDe">Data De</param>
        /// <param name="pdtAte">Data Ate</param>
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLExtratoFinanceiroCabecalhoRelatorio> ExtratoFinanceiroCabecalhoRelatorio(string pstrRevendedorCodigo, DateTime? pdtDe, DateTime? pdtAte)
        {

            var objDLRelatorios = new DLRelatorios();
            List<MLExtratoFinanceiroCabecalhoRelatorio> lstRetorno = null;

            try
            {
                lstRetorno = objDLRelatorios.ExtratoFinanceiroCabecalhoRelatorio(pstrRevendedorCodigo, pdtDe, pdtAte);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRelatorios.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Detalhes Relatorio

        /// <summary> 
        /// Listar Acessos para o Relatório
        /// </summary> 
        /// <param name="pdecUsuario">Código do Usuário</param>
        /// <param name="pdtDe">Data De</param>
        /// <param name="pdtAte">Data Ate</param>
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLExtratoFinanceiroDetalheRelatorio> ExtratoFinanceiroDetalheRelatorio(DateTime pdtDe)
        {

            var objDLRelatorios = new DLRelatorios();
            List<MLExtratoFinanceiroDetalheRelatorio> lstRetorno = null;

            try
            {
                lstRetorno = objDLRelatorios.ExtratoFinanceiroDetalheRelatorio(pdtDe);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRelatorios.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #endregion
    }
}
