using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using BellFone.B2B.Model;
using BellFone.B2B.DataLayer;
using VM2.Framework.BusinessLayer.Utilitarios;

namespace BellFone.B2B.BusinessLayer
{
    /// <summary> 
    /// Classe de Business Layer para FormaPagamento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class BLFormaPagamento
    {

        #region Listar

        /// <summary> 
        /// Listar FormaPagamento
        /// </summary> 
        /// <param name="pobjMLFormaPagamento">Parametros para filtro</param>
        /// <returns>Lista de FormaPagamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLFormaPagamento> Listar(MLFormaPagamento pobjMLFormaPagamento)
        {

            DLFormaPagamento objDLFormaPagamento = new DLFormaPagamento();
            List<MLFormaPagamento> lstRetorno = null;
        
            try
            {
                lstRetorno = objDLFormaPagamento.Listar(pobjMLFormaPagamento);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFormaPagamento.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um FormaPagamento
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>FormaPagamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLFormaPagamento Obter(string pstrCodigo)
        {

            DLFormaPagamento objDLFormaPagamento = new DLFormaPagamento();
            MLFormaPagamento objRetorno = null;
        
            try
            {
                objRetorno = objDLFormaPagamento.Obter(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFormaPagamento.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um FormaPagamento
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Excluir(string pstrCodigo)
        {

            DLFormaPagamento objDLFormaPagamento = new DLFormaPagamento();
        
            try
            {
                return objDLFormaPagamento.Excluir(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFormaPagamento.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um FormaPagamento
        /// </summary> 
        /// <param name="pobjMLFormaPagamento">FormaPagamento com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLFormaPagamento pobjMLFormaPagamento)
        {

            DLFormaPagamento objDLFormaPagamento = new DLFormaPagamento();
        
            try
            {
                return objDLFormaPagamento.Alterar(pobjMLFormaPagamento);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFormaPagamento.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um FormaPagamento
        /// </summary> 
        /// <param name="pobjMLFormaPagamento">FormaPagamento a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public  int Inserir(MLFormaPagamento pobjMLFormaPagamento)
        {

            DLFormaPagamento objDLFormaPagamento = new DLFormaPagamento();
        
            try
            {
                return objDLFormaPagamento.Inserir(pobjMLFormaPagamento);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLFormaPagamento.Finalizar();
            }
        }

        #endregion

        #region Importação de FormaPagamento

        /// <summary> 
        /// Insere uma Forma de Pagamento
        /// </summary> 
        /// <param name="plstMLCondicaoPagamento"></param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLFormaPagamento> plstMLFormaPagamento, out List<string> objRetorno)
        {
            var objDLFormaPagamento = new DLFormaPagamento();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();


            try
            {
                objDLFormaPagamento.BeginTransaction();

                foreach (MLFormaPagamento objMLFormaPagamento in plstMLFormaPagamento)
                {
                    try
                    {
                        if (objMLFormaPagamento.Operacao == "I")
                        {
                            objDLFormaPagamento.Inserir(objMLFormaPagamento);
                            
                        }
                        else if (objMLFormaPagamento.Operacao == "A")
                        {
                            var intCodigo = objDLFormaPagamento.Alterar(objMLFormaPagamento);

                            if (intCodigo == 0)
                            {
                                objDLFormaPagamento.Inserir(objMLFormaPagamento);
                            }
                        }
                        else if (objMLFormaPagamento.Operacao == "E")
                        {
                            objDLFormaPagamento.Excluir(objMLFormaPagamento.Codigo);
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLFormaPagamento.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLFormaPagamento.Codigo + " - Linha com erro(s). " + ex.Message);
                        bolErro = true;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLFormaPagamento.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLFormaPagamento.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                objRetorno.Add("Importação não realizada!!");
                objDLFormaPagamento.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLFormaPagamento.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion
    }
}


