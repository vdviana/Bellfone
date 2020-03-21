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
    /// Classe de Business Layer para CondicaoPagamento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class BLCondicaoPagamento
    {

        #region Listar

        /// <summary> 
        /// Listar CondicaoPagamento
        /// </summary> 
        /// <param name="pobjMLCondicaoPagamento">Parametros para filtro</param>
        /// <returns>Lista de CondicaoPagamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLCondicaoPagamento> Listar(MLCondicaoPagamento pobjMLCondicaoPagamento)
        {

            DLCondicaoPagamento objDLCondicaoPagamento = new DLCondicaoPagamento();
            List<MLCondicaoPagamento> lstRetorno = null;
        
            try
            {
                lstRetorno = objDLCondicaoPagamento.Listar(pobjMLCondicaoPagamento);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLCondicaoPagamento.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um CondicaoPagamento
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>CondicaoPagamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLCondicaoPagamento Obter(string pstrCodigo)
        {

            DLCondicaoPagamento objDLCondicaoPagamento = new DLCondicaoPagamento();
            MLCondicaoPagamento objRetorno = null;
        
            try
            {
                objRetorno = objDLCondicaoPagamento.Obter(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLCondicaoPagamento.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um CondicaoPagamento
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Excluir(string pstrCodigo)
        {

            DLCondicaoPagamento objDLCondicaoPagamento = new DLCondicaoPagamento();
        
            try
            {
                return objDLCondicaoPagamento.Excluir(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLCondicaoPagamento.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um CondicaoPagamento
        /// </summary> 
        /// <param name="pobjMLCondicaoPagamento">CondicaoPagamento com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLCondicaoPagamento pobjMLCondicaoPagamento)
        {

            DLCondicaoPagamento objDLCondicaoPagamento = new DLCondicaoPagamento();
        
            try
            {
                return objDLCondicaoPagamento.Alterar(pobjMLCondicaoPagamento);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLCondicaoPagamento.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um CondicaoPagamento
        /// </summary> 
        /// <param name="pobjMLCondicaoPagamento">CondicaoPagamento a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public  int Inserir(MLCondicaoPagamento pobjMLCondicaoPagamento)
        {

            DLCondicaoPagamento objDLCondicaoPagamento = new DLCondicaoPagamento();
        
            try
            {
                return objDLCondicaoPagamento.Inserir(pobjMLCondicaoPagamento);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLCondicaoPagamento.Finalizar();
            }
        }

        #endregion

        #region Importação de CondicaoPagamento

        /// <summary> 
        /// Insere um Fabricante
        /// </summary> 
        /// <param name="plstMLCondicaoPagamento"></param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLCondicaoPagamento> plstMLCondicaoPagamento, out List<string> objRetorno)
        {
            var objDLCondicaoPagamento = new DLCondicaoPagamento();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                objDLCondicaoPagamento.BeginTransaction();

                foreach (MLCondicaoPagamento objMLCondicaoPagamento in plstMLCondicaoPagamento)
                {
                    try
                    {
                        if (objMLCondicaoPagamento.Operacao == "I")
                        {
                            objDLCondicaoPagamento.Inserir(objMLCondicaoPagamento);
                        }
                        else if (objMLCondicaoPagamento.Operacao == "A")
                        {
                            var intCodigo = objDLCondicaoPagamento.Alterar(objMLCondicaoPagamento);

                            if (intCodigo == 0)
                            {
                                objDLCondicaoPagamento.Inserir(objMLCondicaoPagamento);
                                //objRetorno.Add("- Cód.: " + objMLCondicaoPagamento.Codigo + " -Código não encontrado.");
                            }
                        }
                        else if (objMLCondicaoPagamento.Operacao == "E")
                        {
                            objDLCondicaoPagamento.Excluir(objMLCondicaoPagamento.Codigo);
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLCondicaoPagamento.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLCondicaoPagamento.Codigo + " - Linha com erro(s). " + ex.Message);
                        bolErro = true;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLCondicaoPagamento.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLCondicaoPagamento.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                objRetorno.Add("Importação não realizada!!");
                objDLCondicaoPagamento.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLCondicaoPagamento.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion
    }
}



