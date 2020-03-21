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
    /// Classe de Business Layer para OrcamentoItem 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class BLOrcamentoItem
    {
        #region Listar

        /// <summary> 
        /// Listar OrcamentoItem
        /// </summary> 
        /// <param name="pobjMLOrcamentoItem">Parametros para filtro</param>
        /// <returns>Lista de OrcamentoItem</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLOrcamentoItem> Listar(MLOrcamentoItem pobjMLOrcamentoItem)
        {

            DLOrcamentoItem objDLOrcamentoItem = new DLOrcamentoItem();
            List<MLOrcamentoItem> lstRetorno = null;

            try
            {
                lstRetorno = objDLOrcamentoItem.Listar(pobjMLOrcamentoItem);
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
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um OrcamentoItem
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>OrcamentoItem</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLOrcamentoItem Obter(decimal pdecCodigo)
        {

            DLOrcamentoItem objDLOrcamentoItem = new DLOrcamentoItem();
            MLOrcamentoItem objRetorno = null;

            try
            {
                objRetorno = objDLOrcamentoItem.Obter(pdecCodigo);
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
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um OrcamentoItem
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Excluir(decimal pdecCodigo)
        {

            DLOrcamentoItem objDLOrcamentoItem = new DLOrcamentoItem();

            try
            {
                return objDLOrcamentoItem.Excluir(pdecCodigo);
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

        #region Alterar

        /// <summary> 
        /// Alterar um OrcamentoItem
        /// </summary> 
        /// <param name="pobjMLOrcamentoItem">OrcamentoItem com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLOrcamentoItem pobjMLOrcamentoItem)
        {

            DLOrcamentoItem objDLOrcamentoItem = new DLOrcamentoItem();

            try
            {                
                pobjMLOrcamentoItem.IsAlterado = true;
                return objDLOrcamentoItem.Alterar(pobjMLOrcamentoItem);
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

        #region Inserir

        /// <summary> 
        /// Insere um OrcamentoItem
        /// </summary> 
        /// <param name="pobjMLOrcamentoItem">OrcamentoItem a ser inserido</param>
        /// <returns>Código OrcamentoItem</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public decimal Inserir(MLOrcamentoItem pobjMLOrcamentoItem)
        {

            DLOrcamentoItem objDLOrcamentoItem = new DLOrcamentoItem();

            try
            {
                return objDLOrcamentoItem.Inserir(pobjMLOrcamentoItem);
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


        #region Importação de Orçamentos Itens

        /// <summary> 
        /// Insere Orçamentos Itens
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Orçamentos Itens a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLOrcamentoItem> plstMLOrcamentoItem, out List<string> objRetorno)
        {
            DLOrcamentoItem objDLOrcamentoItem = new DLOrcamentoItem();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                objDLOrcamentoItem.BeginTransaction();

                foreach (MLOrcamentoItem objMLOrcamentoItem in plstMLOrcamentoItem)
                {
                    try
                    {
                        if (objMLOrcamentoItem.Operacao == "I")
                        {
                            objDLOrcamentoItem.Inserir(objMLOrcamentoItem);
                        }
                        else if (objMLOrcamentoItem.Operacao == "A")
                        {
                            var intCodigo = objDLOrcamentoItem.Alterar(objMLOrcamentoItem);

                            if (intCodigo == 0)
                            {
                                objDLOrcamentoItem.Inserir(objMLOrcamentoItem);
                            }
                        }
                        else if (objMLOrcamentoItem.Operacao == "E")
                        {
                            objDLOrcamentoItem.Excluir(Convert.ToDecimal(objMLOrcamentoItem.Codigo));
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLOrcamentoItem.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLOrcamentoItem.Codigo + " - Linha com erro(s). " + ex.Message);
                        bolErro = true;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLOrcamentoItem.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLOrcamentoItem.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                objRetorno.Add("Importação não realizada!!");
                objDLOrcamentoItem.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLOrcamentoItem.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion

        #region ListarOrcamentoItemsTemporarios

        /// <summary> 
        /// Listar OrcamentoItem
        /// </summary> 
        /// <param name="pdecUsuario"></param>
        /// <returns>Lista de OrcamentoItem</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLOrcamentoItemCompleto> ListarOrcamentoItemsTemporarios(Decimal pdecUsuario)
        {

            DLOrcamentoItem objDLOrcamentoItem = new DLOrcamentoItem();
            List<MLOrcamentoItemCompleto> lstRetorno = null;

            try
            {
                lstRetorno = objDLOrcamentoItem.ListarOrcamentoItemsTemporarios(pdecUsuario);
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
            return lstRetorno;
        }

        #endregion

        #region ListarOrcamentoItemsTemporarios

        /// <summary> 
        /// Listar ListarOrcamentoItemsPorRevendedor
        /// </summary> 
        /// <param name="pdecUsuario"></param>
        /// <returns>Lista de OrcamentoItem</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLOrcamentoItemCompleto> ListarOrcamentoItemsPorRevendedor(String pstrRevendedor)
        {

            DLOrcamentoItem objDLOrcamentoItem = new DLOrcamentoItem();
            List<MLOrcamentoItemCompleto> lstRetorno = null;

            try
            {
                lstRetorno = objDLOrcamentoItem.ListarOrcamentoItemsPorRevendedor(pstrRevendedor);
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
            return lstRetorno;
        }

        #endregion

        #region Listar

        /// <summary> 
        /// Listar OrcamentoItem
        /// </summary> 
        /// <param name="pobjMLOrcamentoItem">Parametros para filtro</param>
        /// <returns>Lista de OrcamentoItem</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLOrcamentoItemCompleto> ListarCompleto(MLOrcamentoItem pobjMLOrcamentoItem)
        {

            DLOrcamentoItem objDLOrcamentoItem = new DLOrcamentoItem();
            List<MLOrcamentoItemCompleto> lstRetorno = null;

            try
            {
                lstRetorno = objDLOrcamentoItem.ListarCompleto(pobjMLOrcamentoItem);
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
            return lstRetorno;
        }

        #endregion

    }

    /// <summary> 
    /// Classe de Business Layer para OrcamentoItemHistorico 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class BLOrcamentoItemHistorico
    {

        #region Listar

        /// <summary> 
        /// Listar OrcamentoItemHistorico
        /// </summary> 
        /// <param name="pobjMLOrcamentoItemHistorico">Parametros para filtro</param>
        /// <returns>Lista de OrcamentoItemHistorico</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLOrcamentoItemHistorico> Listar(MLOrcamentoItemHistorico pobjMLOrcamentoItemHistorico)
        {

            DLOrcamentoItemHistorico objDLOrcamentoItemHistorico = new DLOrcamentoItemHistorico();
            List<MLOrcamentoItemHistorico> lstRetorno = null;

            try
            {
                lstRetorno = objDLOrcamentoItemHistorico.Listar(pobjMLOrcamentoItemHistorico);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamentoItemHistorico.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um OrcamentoItemHistorico
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>OrcamentoItemHistorico</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLOrcamentoItemHistorico Obter(decimal pdecCodigo)
        {

            DLOrcamentoItemHistorico objDLOrcamentoItemHistorico = new DLOrcamentoItemHistorico();
            MLOrcamentoItemHistorico objRetorno = null;

            try
            {
                objRetorno = objDLOrcamentoItemHistorico.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamentoItemHistorico.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um OrcamentoItemHistorico
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Excluir(decimal pdecCodigo)
        {

            DLOrcamentoItemHistorico objDLOrcamentoItemHistorico = new DLOrcamentoItemHistorico();

            try
            {
                return objDLOrcamentoItemHistorico.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamentoItemHistorico.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um OrcamentoItemHistorico
        /// </summary> 
        /// <param name="pobjMLOrcamentoItemHistorico">OrcamentoItemHistorico com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLOrcamentoItemHistorico pobjMLOrcamentoItemHistorico)
        {

            DLOrcamentoItemHistorico objDLOrcamentoItemHistorico = new DLOrcamentoItemHistorico();

            try
            {
                return objDLOrcamentoItemHistorico.Alterar(pobjMLOrcamentoItemHistorico);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamentoItemHistorico.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um OrcamentoItemHistorico
        /// </summary> 
        /// <param name="pobjMLOrcamentoItemHistorico">OrcamentoItemHistorico a ser inserido</param>
        /// <returns>Código OrcamentoItemHistorico</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public decimal Inserir(MLOrcamentoItemHistorico pobjMLOrcamentoItemHistorico)
        {

            DLOrcamentoItemHistorico objDLOrcamentoItemHistorico = new DLOrcamentoItemHistorico();

            try
            {
                return objDLOrcamentoItemHistorico.Inserir(pobjMLOrcamentoItemHistorico);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLOrcamentoItemHistorico.Finalizar();
            }
        }

        #endregion
    }
}


