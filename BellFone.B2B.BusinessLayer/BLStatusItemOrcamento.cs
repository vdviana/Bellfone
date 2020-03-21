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
    /// Classe de Business Layer para StatusItemOrcamento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.1.1]</user> 
    public class BLStatusItemOrcamento
    {

        #region Listar

        /// <summary> 
        /// Listar StatusItemOrcamento
        /// </summary> 
        /// <param name="pobjMLStatusItemOrcamento">Parametros para filtro</param>
        /// <returns>Lista de StatusItemOrcamento</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public List<MLStatusItemOrcamento> Listar(MLStatusItemOrcamento pobjMLStatusItemOrcamento)
        {

            DLStatusItemOrcamento objDLStatusItemOrcamento = new DLStatusItemOrcamento();
            List<MLStatusItemOrcamento> lstRetorno = null;
        
            try
            {
                lstRetorno = objDLStatusItemOrcamento.Listar(pobjMLStatusItemOrcamento);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLStatusItemOrcamento.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um StatusItemOrcamento
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>StatusItemOrcamento</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public MLStatusItemOrcamento Obter(string pstrCodigo)
        {

            DLStatusItemOrcamento objDLStatusItemOrcamento = new DLStatusItemOrcamento();
            MLStatusItemOrcamento objRetorno = null;
        
            try
            {
                objRetorno = objDLStatusItemOrcamento.Obter(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLStatusItemOrcamento.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um StatusItemOrcamento
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public int Excluir(string pstrCodigo)
        {

            DLStatusItemOrcamento objDLStatusItemOrcamento = new DLStatusItemOrcamento();
        
            try
            {
                return objDLStatusItemOrcamento.Excluir(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLStatusItemOrcamento.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um StatusItemOrcamento
        /// </summary> 
        /// <param name="pobjMLStatusItemOrcamento">StatusItemOrcamento com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public int Alterar(MLStatusItemOrcamento pobjMLStatusItemOrcamento)
        {

            DLStatusItemOrcamento objDLStatusItemOrcamento = new DLStatusItemOrcamento();
        
            try
            {
                return objDLStatusItemOrcamento.Alterar(pobjMLStatusItemOrcamento);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLStatusItemOrcamento.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um StatusItemOrcamento
        /// </summary> 
        /// <param name="pobjMLStatusItemOrcamento">StatusItemOrcamento a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public  int Inserir(MLStatusItemOrcamento pobjMLStatusItemOrcamento)
        {

            DLStatusItemOrcamento objDLStatusItemOrcamento = new DLStatusItemOrcamento();
        
            try
            {
                return objDLStatusItemOrcamento.Inserir(pobjMLStatusItemOrcamento);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLStatusItemOrcamento.Finalizar();
            }
        }

        #endregion

        #region Importação de Status Item Orcamento

        /// <summary> 
        /// Insere Categorias
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Categorias a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLStatusItemOrcamento> plstMLStatusItemOrcamento, out List<string> objRetorno)
        {
            DLStatusItemOrcamento objDLStatusItemOrcamento = new DLStatusItemOrcamento();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                objDLStatusItemOrcamento.BeginTransaction();

                foreach (MLStatusItemOrcamento objMLStatusItemOrcamento in plstMLStatusItemOrcamento)
                {
                    try
                    {
                        if (objMLStatusItemOrcamento.Operacao == "I")
                        {
                            objDLStatusItemOrcamento.Inserir(objMLStatusItemOrcamento);
                        }
                        else if (objMLStatusItemOrcamento.Operacao == "A")
                        {
                            var intCodigo = objDLStatusItemOrcamento.Alterar(objMLStatusItemOrcamento);

                            if (intCodigo == 0)
                            {
                                objDLStatusItemOrcamento.Inserir(objMLStatusItemOrcamento);
                            }
                        }
                        else if (objMLStatusItemOrcamento.Operacao == "E")
                        {
                            objDLStatusItemOrcamento.Excluir(objMLStatusItemOrcamento.Codigo);
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLStatusItemOrcamento.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLStatusItemOrcamento.Codigo + " - Linha com erros. " + ex.Message);
                        bolErro = true;
                        break;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLStatusItemOrcamento.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLStatusItemOrcamento.CommitTransaction();
                }

            }
            catch (Exception ex)
            {
                objDLStatusItemOrcamento.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLStatusItemOrcamento.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion
    }
}


