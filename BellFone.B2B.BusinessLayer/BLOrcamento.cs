using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using BellFone.B2B.Model;
using BellFone.B2B.DataLayer;
using VM2.Framework.BusinessLayer.Utilitarios;
using System.Collections.ObjectModel;
using BellFone.B2B.BusinessLayer.Configuration;

namespace BellFone.B2B.BusinessLayer
{
    /// <summary> 
    /// Classe de Business Layer para Orcamento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class BLOrcamento
    {

        #region Listar

        /// <summary> 
        /// Listar Orcamento
        /// </summary> 
        /// <param name="pobjMLOrcamento">Parametros para filtro</param>
        /// <returns>Lista de Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLOrcamento> Listar(MLOrcamento pobjMLOrcamento)
        {

            DLOrcamento objDLOrcamento = new DLOrcamento();
            List<MLOrcamento> lstRetorno = null;

            try
            {
                lstRetorno = objDLOrcamento.Listar(pobjMLOrcamento);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamento.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Orcamento
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLOrcamento Obter(decimal pdecCodigo)
        {

            DLOrcamento objDLOrcamento = new DLOrcamento();
            MLOrcamento objRetorno = null;

            try
            {
                objRetorno = objDLOrcamento.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamento.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Orcamento
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Excluir(decimal pdecCodigo)
        {

            DLOrcamento objDLOrcamento = new DLOrcamento();
            int intCodigo = 0;

            try
            {
                intCodigo = objDLOrcamento.Excluir(pdecCodigo);

                return intCodigo;
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamento.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Orcamento
        /// </summary> 
        /// <param name="pobjMLOrcamento">Orcamento com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLOrcamento pobjMLOrcamento)
        {

            DLOrcamento objDLOrcamento = new DLOrcamento();

            try
            {                
                pobjMLOrcamento.IsAlterado = true;
                return objDLOrcamento.Alterar(pobjMLOrcamento);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamento.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Orcamento
        /// </summary> 
        /// <param name="pobjMLOrcamento">Orcamento a ser inserido</param>
        /// <returns>Código Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public decimal Inserir(MLOrcamento pobjMLOrcamento)
        {

            DLOrcamento objDLOrcamento = new DLOrcamento();

            try
            {
                return objDLOrcamento.Inserir(pobjMLOrcamento);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamento.Finalizar();
            }
        }

        #endregion



        #region Integração

        #region Importação de Orçamentos

        /// <summary> 
        /// Insere Orçamentos
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Orçamentos a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLOrcamento> plstMLOrcamento, out List<string> objRetorno)
        {
            DLOrcamento objDLOrcamento = new DLOrcamento();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                objDLOrcamento.BeginTransaction();

                foreach (MLOrcamento objMLOrcamento in plstMLOrcamento)
                {
                    try
                    {
                        if (objMLOrcamento.Operacao == "I")
                        {
                            objDLOrcamento.Inserir(objMLOrcamento);
                        }
                        else if (objMLOrcamento.Operacao == "A")
                        {
                            var intCodigo = objDLOrcamento.Alterar(objMLOrcamento);

                            if (intCodigo == 0)
                            {
                                objDLOrcamento.Inserir(objMLOrcamento);
                            }
                        }
                        else if (objMLOrcamento.Operacao == "E")
                        {
                            objDLOrcamento.Excluir(Convert.ToDecimal(objMLOrcamento.Codigo));
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLOrcamento.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLOrcamento.Codigo + " - Linha com erro(s). " + ex.Message);
                        bolErro = true;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLOrcamento.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLOrcamento.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                objRetorno.Add("Importação não realizada!!");
                objDLOrcamento.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLOrcamento.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion

        #region Exportar de Orçamentos

        /// <summary> 
        /// Exporta Orçamentos
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Orçamentos a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public void Exportacao(Collection<MLOrcamento> pcolMLOrcamento)
        {


            try
            {
                foreach (MLOrcamento objMLOrcamento in pcolMLOrcamento)
                {
                    this.Inserir(objMLOrcamento);
                }
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
        }

        #endregion

        #endregion

        #region Listar por Usuario de Revendedor

        /// <summary> 
        /// Executa a Stored Procedure de Listagem para o Filtro
        /// </summary> 
        /// <param name="pstrRevendedor"></param>
        /// <param name="pstrVendedor"></param>
        /// <param name="pstrTituloOrcamento"></param>
        /// <param name="pdteOrcamentoDe"></param>
        /// <param name="pdteOrcamentoAte"></param>
        /// <param name="pdecOrcamentoCodigoDe"></param>
        /// <param name="pdecOrcamentoCodigoAte"></param>
        /// <param name="pstrBellfoneCodigo"></param>
        /// <param name="pbolIsTemporario"></param>
        /// <param name="pintDiasLimite"></param>
        /// <returns>Lista de Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLOrcamentoCompleto> Listar(String pstrRevendedor,
                                        String pstrVendedor,
                                        String pstrTituloOrcamento,
                                        DateTime? pdteOrcamentoDe,
                                        DateTime? pdteOrcamentoAte,
                                        Decimal? pdecOrcamentoCodigoDe,
                                        Decimal? pdecOrcamentoCodigoAte,
                                        String pstrBellfoneCodigo,
                                        Boolean pbolIsTemporario,
                                        int? pintDiasLimite)
        {

            DLOrcamento objDLOrcamento = new DLOrcamento();
            List<MLOrcamentoCompleto> lstRetorno = null;

            try
            { 
                lstRetorno = objDLOrcamento.Listar(pstrRevendedor, pstrVendedor, pstrTituloOrcamento, pdteOrcamentoDe, pdteOrcamentoAte, pdecOrcamentoCodigoDe, pdecOrcamentoCodigoAte, pstrBellfoneCodigo, pbolIsTemporario, pintDiasLimite);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamento.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Listar por Usuario de Revendedor

        /// <summary> 
        /// Executa a Stored Procedure de Listagem para o Filtro
        /// </summary> 
        /// <param name="pobjMLOrcamento"></param>
        /// <param name="pdecUsuario"></param>
        /// <returns>Lista de Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLOrcamento> ListarPorUsuarioRevendedor(String pstrRevendedor, bool pbolTemporario)
        {

            DLOrcamento objDLOrcamento = new DLOrcamento();
            List<MLOrcamento> lstRetorno = null;

            try
            {
                lstRetorno = objDLOrcamento.ListarPorUsuarioRevendedor(pstrRevendedor, pbolTemporario);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamento.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Listar por Usuario de Vendedor

        /// <summary> 
        /// Executa a Stored Procedure de Listagem para o Filtro
        /// </summary> 
        /// <param name="pobjMLOrcamento"></param>
        /// <param name="pdecUsuario"></param>
        /// <returns>Lista de Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLOrcamento> ListarPorUsuarioVendedor(String pstrVendedor, bool pbolTemporario)
        {

            DLOrcamento objDLOrcamento = new DLOrcamento();
            List<MLOrcamento> lstRetorno = null;

            try
            {
                lstRetorno = objDLOrcamento.ListarPorUsuarioVendedor(pstrVendedor, pbolTemporario);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamento.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Completo

        #region Listar

        /// <summary> 
        /// Retorna a lista de orcamentos completo somente não vencidos
        /// </summary> 
        /// <param name="pobjMLOrcamento">Parametros para filtro</param>
        /// <returns>Lista de Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLOrcamentoCompleto> ListarCompleto(MLOrcamento pobjMLOrcamento, int? pintDiasLimite)
        {

            DLOrcamento objDLOrcamento = new DLOrcamento();
            List<MLOrcamentoCompleto> lstRetorno = null;

            try
            {
                lstRetorno = objDLOrcamento.ListarCompleto(pobjMLOrcamento, pintDiasLimite);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamento.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter Completo

        /// <summary> 
        /// Obtem um Orcamento
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLOrcamentoCompleto ObterCompleto(decimal pdecCodigo)
        {

            DLOrcamento objDLOrcamento = new DLOrcamento();
            MLOrcamentoCompleto objRetorno = null;

            try
            {
                objRetorno = objDLOrcamento.ObterCompleto(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamento.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #endregion

        #region Obter

        /// <summary> 
        /// Cancela um Orcamento
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public void Cancelar(List<MLOrcamentoItemCompleto> ListMLOrcamentoItemCompleto)
        {

            var objDLOrcamentoItem = new DLOrcamentoItem();

            try
            {
                //objDLOrcamentoItem.BeginTransaction();

                string strStatusCancelado = UTConfiguracao.ObterIdConfiguracaoSituacaoCancelado();
                string strStatusOrcado = UTConfiguracao.ObterIdConfiguracaoSituacaoOrcado();

                var strStatusItemOrcamentoCancelado = new BLConfiguracao().Obter(strStatusCancelado).Valor;
                var strStatusItemOrcamentoOrcado = new BLConfiguracao().Obter(strStatusOrcado).Valor;

                foreach (var objMLOrcamentoItem in ListMLOrcamentoItemCompleto)
                {
                    if (objMLOrcamentoItem.CodigoStatusItemOrcamento == strStatusItemOrcamentoOrcado)
                    {
                        objMLOrcamentoItem.CodigoStatusItemOrcamento = strStatusItemOrcamentoCancelado;
                        objDLOrcamentoItem.Alterar(objMLOrcamentoItem);
                        
                    }                                     
                }

                //objDLOrcamentoItem.CommitTransaction();
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamentoItem.Finalizar();
            }
        }

        #endregion
    }
}


