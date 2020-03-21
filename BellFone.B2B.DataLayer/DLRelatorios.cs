using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para Relatorios 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class DLRelatorios : DLFWBase
    {
        /// <summary>
        /// Construtor, inicializa as variáveis de conexão
        /// </summary>
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public DLRelatorios()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }

        #region OrcamentoRelatorio

        #region OrcamentoRevendedorRelatorio

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLAcesso">Parametros para filtro</param>
        /// <returns>Lista de Acesso</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLOrcamentoRelatorio> OrcamentoRelatorio(decimal pdecOrcamentoDe)
        {

            List<MLOrcamentoRelatorio> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ORCAMENTO_RELATORIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;


            if (pdecOrcamentoDe != 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORC_N_CODIGO"].Value = pdecOrcamentoDe;
            }


            IDataReader idrRetorno = null;
            try
            {
                MLOrcamentoRelatorio objRetorno = null;
                lstRetorno = new List<MLOrcamentoRelatorio>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLOrcamentoRelatorio();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (idrRetorno != null && !idrRetorno.IsClosed)
                {
                    idrRetorno.Close();
                }
            }
            return lstRetorno;
        }

        #endregion

        #region Relatorio de Orcamento e Pedido Por Dia

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLPedidoOrcamentoRelatorio">Parametros para filtro</param>
        /// <returns></returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLPedidoOrcamentoRelatorioPorDia> RelatorioOrcamentoPedidoPorDia(MLPedidoOrcamentoRelatorioPorDia pobjMLPedidoOrcamentoRelatorioPorDia)
        {
            List<MLPedidoOrcamentoRelatorioPorDia> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ORCAMENTO_POR_DIA_RELATORIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLPedidoOrcamentoRelatorioPorDia.CodigoOrcamentoInicio.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_N_CODIGO_DE", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORC_N_CODIGO_DE"].Value = pobjMLPedidoOrcamentoRelatorioPorDia.CodigoOrcamentoInicio.Value;
            }
            if (pobjMLPedidoOrcamentoRelatorioPorDia.CodigoOrcamentoFim.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_N_CODIGO_ATE", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORC_N_CODIGO_ATE"].Value = pobjMLPedidoOrcamentoRelatorioPorDia.CodigoOrcamentoFim.Value;
            }
            if (pobjMLPedidoOrcamentoRelatorioPorDia.DataInicio.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@DATA_DE", FWDbType.DateTime));
                cmdCommand.Parameters["@DATA_DE"].Value = pobjMLPedidoOrcamentoRelatorioPorDia.DataInicio.Value;
            }
            if (pobjMLPedidoOrcamentoRelatorioPorDia.DataFim.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@DATA_ATE", FWDbType.DateTime));
                cmdCommand.Parameters["@DATA_ATE"].Value = pobjMLPedidoOrcamentoRelatorioPorDia.DataFim.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLPedidoOrcamentoRelatorioPorDia.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REVENDEDOR_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@REVENDEDOR_CODIGO"].Value = pobjMLPedidoOrcamentoRelatorioPorDia.CodigoRevendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLPedidoOrcamentoRelatorioPorDia.CodigoVendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VENDEDOR_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@VENDEDOR_CODIGO"].Value = pobjMLPedidoOrcamentoRelatorioPorDia.CodigoVendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLPedidoOrcamentoRelatorioPorDia.StatusOrcamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@STATUS_ORCAMENTO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@STATUS_ORCAMENTO"].Value = pobjMLPedidoOrcamentoRelatorioPorDia.StatusOrcamento;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLPedidoOrcamentoRelatorioPorDia objRetorno = null;
                lstRetorno = new List<MLPedidoOrcamentoRelatorioPorDia>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLPedidoOrcamentoRelatorioPorDia();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (idrRetorno != null && !idrRetorno.IsClosed)
                {
                    idrRetorno.Close();
                }
            }
            return lstRetorno;
        }

        #endregion

        #region Relatorio de Orcamento e Pedido

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLPedidoOrcamentoRelatorio">Parametros para filtro</param>
        /// <returns></returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLPedidoOrcamentoRelatorio> RelatorioOrcamentoPedido(MLPedidoOrcamentoRelatorioPorDia pobjMLPedidoOrcamentoRelatorioPorDia)
        {
            List<MLPedidoOrcamentoRelatorio> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ORCAMENTO_COMPLETO_RELATORIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLPedidoOrcamentoRelatorioPorDia.CodigoOrcamentoInicio.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_N_CODIGO_DE", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORC_N_CODIGO_DE"].Value = pobjMLPedidoOrcamentoRelatorioPorDia.CodigoOrcamentoInicio.Value;
            }
            if (pobjMLPedidoOrcamentoRelatorioPorDia.CodigoOrcamentoFim.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_N_CODIGO_ATE", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORC_N_CODIGO_ATE"].Value = pobjMLPedidoOrcamentoRelatorioPorDia.CodigoOrcamentoFim.Value;
            }
            if (pobjMLPedidoOrcamentoRelatorioPorDia.DataEmissao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@DATA", FWDbType.DateTime));
                cmdCommand.Parameters["@DATA"].Value = pobjMLPedidoOrcamentoRelatorioPorDia.DataEmissao.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLPedidoOrcamentoRelatorioPorDia.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REVENDEDOR_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@REVENDEDOR_CODIGO"].Value = pobjMLPedidoOrcamentoRelatorioPorDia.CodigoRevendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLPedidoOrcamentoRelatorioPorDia.CodigoVendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VENDEDOR_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@VENDEDOR_CODIGO"].Value = pobjMLPedidoOrcamentoRelatorioPorDia.CodigoVendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLPedidoOrcamentoRelatorioPorDia.StatusOrcamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@STATUS_ORCAMENTO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@STATUS_ORCAMENTO"].Value = pobjMLPedidoOrcamentoRelatorioPorDia.StatusOrcamento;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLPedidoOrcamentoRelatorio objRetorno = null;
                lstRetorno = new List<MLPedidoOrcamentoRelatorio>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLPedidoOrcamentoRelatorio();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (idrRetorno != null && !idrRetorno.IsClosed)
                {
                    idrRetorno.Close();
                }
            }
            return lstRetorno;
        }

        #endregion

        #region Relatorio de Itens de Orcamento e Pedido

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="MLPedidoOrcamentoItensRelatorio">Parametros para filtro</param>
        /// <returns></returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLPedidoOrcamentoItensRelatorio> RelatorioOrcamentoPedidoItens(MLPedidoOrcamentoRelatorio pobjMLPedidoOrcamentoRelatorio)
        {
            List<MLPedidoOrcamentoItensRelatorio> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ORCAMENTO_ITEM_COMPLETO_RELATORIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLPedidoOrcamentoRelatorio.CodigoOrcamento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@COD_ORCAMENTO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@COD_ORCAMENTO"].Value = pobjMLPedidoOrcamentoRelatorio.CodigoOrcamento.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLPedidoOrcamentoRelatorio.StatusOrcamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@STATUS_ORCAMENTO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@STATUS_ORCAMENTO"].Value = pobjMLPedidoOrcamentoRelatorio.StatusOrcamento;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLPedidoOrcamentoItensRelatorio objRetorno = null;
                lstRetorno = new List<MLPedidoOrcamentoItensRelatorio>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLPedidoOrcamentoItensRelatorio();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (idrRetorno != null && !idrRetorno.IsClosed)
                {
                    idrRetorno.Close();
                }
            }
            return lstRetorno;
        }

        #endregion

        #endregion

        #region AcessosRelatorio

        #region Cabeçalho Relatorio

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pdecUsuario">Código do Usuário</param>
        /// <param name="pdtDe">Data De</param>
        /// <param name="pdtAte">Data Ate</param>
        /// <returns>Lista de Acesso</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLAcessosCabecalhoRelatorio> AcessoCabecalhoRelatorio(decimal pdecUsuario, DateTime pdtDe, DateTime pdtAte)
        {

            List<MLAcessosCabecalhoRelatorio> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ACESSO_CABECALHO_RELATORIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pdecUsuario != 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ACC_USU_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ACC_USU_N_CODIGO"].Value = pdecUsuario;
            }
            if (pdtDe != DateTime.MinValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ACC_D_DATA_DE", FWDbType.DateTime));
                cmdCommand.Parameters["@ACC_D_DATA_DE"].Value = pdtDe;
            }
            if (pdtAte != DateTime.MinValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ACC_D_DATA_ATE", FWDbType.DateTime));
                cmdCommand.Parameters["@ACC_D_DATA_ATE"].Value = pdtAte;
            }


            IDataReader idrRetorno = null;
            try
            {
                MLAcessosCabecalhoRelatorio objRetorno = null;
                lstRetorno = new List<MLAcessosCabecalhoRelatorio>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLAcessosCabecalhoRelatorio();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (idrRetorno != null && !idrRetorno.IsClosed)
                {
                    idrRetorno.Close();
                }
            }
            return lstRetorno;
        }

        #endregion

        #region Detalhes Relatorio

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pdecUsuario">Código do Usuário</param>
        /// <param name="pdtDe">Data De</param>
        /// <param name="pdtAte">Data Ate</param>
        /// <returns>Lista de Acesso</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLAcessosRelatorio> AcessoDetalhesRelatorio(decimal pdecUsuario, DateTime pdtDe, DateTime pdtAte)
        {

            List<MLAcessosRelatorio> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ACESSO_RELATORIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pdecUsuario != 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ACC_USU_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ACC_USU_N_CODIGO"].Value = pdecUsuario;
            }
            if (pdtDe != DateTime.MinValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ACC_D_DATA_DE", FWDbType.DateTime));
                cmdCommand.Parameters["@ACC_D_DATA_DE"].Value = pdtDe;
            }
            if (pdtAte != DateTime.MinValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ACC_D_DATA_ATE", FWDbType.DateTime));
                cmdCommand.Parameters["@ACC_D_DATA_ATE"].Value = pdtAte;
            }


            IDataReader idrRetorno = null;
            try
            {
                MLAcessosRelatorio objRetorno = null;
                lstRetorno = new List<MLAcessosRelatorio>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLAcessosRelatorio();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (idrRetorno != null && !idrRetorno.IsClosed)
                {
                    idrRetorno.Close();
                }
            }
            return lstRetorno;
        }

        #endregion

        #endregion

        #region FichaFinanceiro

        #region Cabeçalho Relatorio

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pstrRevendedorCodigo">Código do Revendedor</param>
        /// <param name="pdtDe">Data De</param>
        /// <param name="pdtAte">Data Ate</param>
        /// <param name="pbooSituacao">A Situação da Ficha Financeira</param>
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLFichaFinanceiraCabecalhoRelatorio> FichaFinanceiraCabecalhoRelatorio(string pstrRevendedorCodigo, DateTime? pdtDe, DateTime? pdtAte, bool? pbooSituacao)
        {
            List<MLFichaFinanceiraCabecalhoRelatorio> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_FICHA_FINANCEIRA_CABECALHO_RELATORIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pstrRevendedorCodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@FIF_REV_C_CODIGO"].Value = pstrRevendedorCodigo;
            }

            if (pdtDe.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@DATA_DE", FWDbType.DateTime));
                cmdCommand.Parameters["@DATA_DE"].Value = pdtDe.Value;
            }
            if (pdtAte.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@DATA_ATE", FWDbType.DateTime));
                cmdCommand.Parameters["@DATA_ATE"].Value = pdtAte.Value;
            }

            if (pbooSituacao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@SITUACAO", FWDbType.Boolean));
                cmdCommand.Parameters["@SITUACAO"].Value = pbooSituacao.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLFichaFinanceiraCabecalhoRelatorio objRetorno = null;
                lstRetorno = new List<MLFichaFinanceiraCabecalhoRelatorio>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLFichaFinanceiraCabecalhoRelatorio();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (idrRetorno != null && !idrRetorno.IsClosed)
                {
                    idrRetorno.Close();
                }
            }
            return lstRetorno;
        }

        #endregion

        #region Detalhes Relatorio

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pdecUsuario">Código do Usuário</param>
        /// <param name="pdtDe">Data De</param>
        /// <param name="pdtAte">Data Ate</param>
        /// <param name="pbooSituacao">A Situação da Ficha Financeira</param>
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLFichaFinanceiraDetalheRelatorio> FichaFinanceiraDetalheRelatorio(DateTime pdtDe, bool? pbooSituacao, string pstrRevendedorCodigo)
        {
            List<MLFichaFinanceiraDetalheRelatorio> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_FICHA_FINANCEIRA_DETALHES_RELATORIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pdtDe != DateTime.MinValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@DATA", FWDbType.DateTime));
                cmdCommand.Parameters["@DATA"].Value = pdtDe;
            }

            if (!string.IsNullOrEmpty(pstrRevendedorCodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@FIF_REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@FIF_REV_C_CODIGO"].Value = pstrRevendedorCodigo;
            }

            if (pbooSituacao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@SITUACAO", FWDbType.Boolean));
                cmdCommand.Parameters["@SITUACAO"].Value = pbooSituacao.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLFichaFinanceiraDetalheRelatorio objRetorno = null;
                lstRetorno = new List<MLFichaFinanceiraDetalheRelatorio>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLFichaFinanceiraDetalheRelatorio();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (idrRetorno != null && !idrRetorno.IsClosed)
                {
                    idrRetorno.Close();
                }
            }
            return lstRetorno;
        }

        #endregion

        #endregion

        #region ExtratoFincanceiro

        #region Cabeçalho Relatorio

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pstrRevendedorCodigo">Código do Revendedor</param>
        /// <param name="pdtDe">Data De</param>
        /// <param name="pdtAte">Data Ate</param>
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLExtratoFinanceiroCabecalhoRelatorio> ExtratoFinanceiroCabecalhoRelatorio(string pstrRevendedorCodigo, DateTime? pdtDe, DateTime? pdtAte)
        {

            List<MLExtratoFinanceiroCabecalhoRelatorio> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_EXTRATO_FINANCEIRO_CABECALHO_RELATORIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pstrRevendedorCodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_REV_N_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@EXF_REV_N_CODIGO"].Value = pstrRevendedorCodigo;
            }

            if (pdtDe.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@DATA_DE", FWDbType.DateTime));
                cmdCommand.Parameters["@DATA_DE"].Value = pdtDe.Value;
            }
            if (pdtAte.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@DATA_ATE", FWDbType.DateTime));
                cmdCommand.Parameters["@DATA_ATE"].Value = pdtAte.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLExtratoFinanceiroCabecalhoRelatorio objRetorno = null;
                lstRetorno = new List<MLExtratoFinanceiroCabecalhoRelatorio>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLExtratoFinanceiroCabecalhoRelatorio();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (idrRetorno != null && !idrRetorno.IsClosed)
                {
                    idrRetorno.Close();
                }
            }
            return lstRetorno;
        }

        #endregion

        #region Detalhes Relatorio

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pdecUsuario">Código do Usuário</param>
        /// <param name="pdtDe">Data De</param>
        /// <param name="pdtAte">Data Ate</param>
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLExtratoFinanceiroDetalheRelatorio> ExtratoFinanceiroDetalheRelatorio(DateTime pdtDe)
        {

            List<MLExtratoFinanceiroDetalheRelatorio> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_EXTRATO_FINANCEIRO_DETALHES_RELATORIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pdtDe != DateTime.MinValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@DATA", FWDbType.DateTime));
                cmdCommand.Parameters["@DATA"].Value = pdtDe;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLExtratoFinanceiroDetalheRelatorio objRetorno = null;
                lstRetorno = new List<MLExtratoFinanceiroDetalheRelatorio>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLExtratoFinanceiroDetalheRelatorio();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (idrRetorno != null && !idrRetorno.IsClosed)
                {
                    idrRetorno.Close();
                }
            }
            return lstRetorno;
        }

        #endregion

        #endregion
    }
}