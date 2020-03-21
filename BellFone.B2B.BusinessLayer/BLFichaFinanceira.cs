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
    /// Classe de Business Layer para FichaFinanceira 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class BLFichaFinanceira
    {

        #region Listar

        /// <summary> 
        /// Listar FichaFinanceira
        /// </summary> 
        /// <param name="pobjMLFichaFinanceira">Parametros para filtro</param>
        /// <returns>Lista de FichaFinanceira</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLFichaFinanceira> Listar(MLFichaFinanceira pobjMLFichaFinanceira)
        {

            DLFichaFinanceira objDLFichaFinanceira = new DLFichaFinanceira();
            List<MLFichaFinanceira> lstRetorno = null;
        
            try
            {
                lstRetorno = objDLFichaFinanceira.Listar(pobjMLFichaFinanceira);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFichaFinanceira.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um FichaFinanceira
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <param name="pstrParcela">Parcela</param>
        /// <returns>FichaFinanceira</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLFichaFinanceira Obter(string pstrCodigo,
                                               string pstrParcela)
        {

            DLFichaFinanceira objDLFichaFinanceira = new DLFichaFinanceira();
            MLFichaFinanceira objRetorno = null;
        
            try
            {
                objRetorno = objDLFichaFinanceira.Obter(pstrCodigo,pstrParcela);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFichaFinanceira.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um FichaFinanceira
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <param name="pstrParcela">Parcela</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Excluir(string pstrCodigo,
                                               string pstrParcela)
        {

            DLFichaFinanceira objDLFichaFinanceira = new DLFichaFinanceira();
        
            try
            {
                return objDLFichaFinanceira.Excluir(pstrCodigo,pstrParcela);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFichaFinanceira.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um FichaFinanceira
        /// </summary> 
        /// <param name="pobjMLFichaFinanceira">FichaFinanceira com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLFichaFinanceira pobjMLFichaFinanceira)
        {

            DLFichaFinanceira objDLFichaFinanceira = new DLFichaFinanceira();
        
            try
            {
                return objDLFichaFinanceira.Alterar(pobjMLFichaFinanceira);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFichaFinanceira.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um FichaFinanceira
        /// </summary> 
        /// <param name="pobjMLFichaFinanceira">FichaFinanceira a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public  int Inserir(MLFichaFinanceira pobjMLFichaFinanceira)
        {

            DLFichaFinanceira objDLFichaFinanceira = new DLFichaFinanceira();
        
            try
            {
                return objDLFichaFinanceira.Inserir(pobjMLFichaFinanceira);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFichaFinanceira.Finalizar();
            }
        }

        #endregion

        #region Importação de Ficha Financeira

        /// <summary> 
        /// Insere um Ficha Financeira
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Fichas Financeiras a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLFichaFinanceira> plstMLFichaFinanceira, out List<string> objRetorno)
        {
            DLFichaFinanceira objDLFichaFinanceira = new DLFichaFinanceira();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                objDLFichaFinanceira.BeginTransaction();

                foreach (MLFichaFinanceira objMLFichaFinanceira in plstMLFichaFinanceira)
                {
                    try
                    {
                        if (objMLFichaFinanceira.Operacao == "I")
                        {
                            objDLFichaFinanceira.Inserir(objMLFichaFinanceira);
                        }
                        else if (objMLFichaFinanceira.Operacao == "A")
                        {
                            var intCodigo = objDLFichaFinanceira.Alterar(objMLFichaFinanceira);

                            if (intCodigo == 0)
                            {
                                objDLFichaFinanceira.Inserir(objMLFichaFinanceira);
                            }
                        }
                        else if (objMLFichaFinanceira.Operacao == "E")
                        {
                            objDLFichaFinanceira.Excluir(objMLFichaFinanceira.Codigo, objMLFichaFinanceira.Parcela);
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLFichaFinanceira.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLFichaFinanceira.Codigo + " - Linha com erro(s). " + ex.Message);
                        bolErro = true;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLFichaFinanceira.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLFichaFinanceira.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                objRetorno.Add("Importação não realizada!!");
                objDLFichaFinanceira.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLFichaFinanceira.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion
    }
}


