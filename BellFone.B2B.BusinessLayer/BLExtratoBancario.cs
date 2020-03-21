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
    /// Classe de Business Layer para ExtratoFinanceiro 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class BLExtratoFinanceiro
    {

        #region Listar

        /// <summary> 
        /// Listar ExtratoFinanceiro
        /// </summary> 
        /// <param name="pobjMLExtratoFinanceiro">Parametros para filtro</param>
        /// <returns>Lista de ExtratoFinanceiro</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLExtratoFinanceiro> Listar(MLExtratoFinanceiro pobjMLExtratoFinanceiro)
        {

            DLExtratoFinanceiro objDLExtratoFinanceiro = new DLExtratoFinanceiro();
            List<MLExtratoFinanceiro> lstRetorno = null;

            try
            {
                lstRetorno = objDLExtratoFinanceiro.Listar(pobjMLExtratoFinanceiro);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLExtratoFinanceiro.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um ExtratoFinanceiro
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>ExtratoFinanceiro</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLExtratoFinanceiro Obter(decimal pdecCodigo)
        {

            DLExtratoFinanceiro objDLExtratoFinanceiro = new DLExtratoFinanceiro();
            MLExtratoFinanceiro objRetorno = null;

            try
            {
                objRetorno = objDLExtratoFinanceiro.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLExtratoFinanceiro.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um ExtratoFinanceiro
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Excluir(decimal pdecCodigo)
        {

            DLExtratoFinanceiro objDLExtratoFinanceiro = new DLExtratoFinanceiro();

            try
            {
                return objDLExtratoFinanceiro.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLExtratoFinanceiro.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um ExtratoFinanceiro
        /// </summary> 
        /// <param name="pobjMLExtratoFinanceiro">ExtratoFinanceiro com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLExtratoFinanceiro pobjMLExtratoFinanceiro)
        {

            DLExtratoFinanceiro objDLExtratoFinanceiro = new DLExtratoFinanceiro();

            try
            {
                return objDLExtratoFinanceiro.Alterar(pobjMLExtratoFinanceiro);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLExtratoFinanceiro.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um ExtratoFinanceiro
        /// </summary> 
        /// <param name="pobjMLExtratoFinanceiro">ExtratoFinanceiro a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Inserir(MLExtratoFinanceiro pobjMLExtratoFinanceiro)
        {

            DLExtratoFinanceiro objDLExtratoFinanceiro = new DLExtratoFinanceiro();

            try
            {
                return objDLExtratoFinanceiro.Inserir(pobjMLExtratoFinanceiro);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLExtratoFinanceiro.Finalizar();
            }
        }

        #endregion

        #region Importação de Extrato Bancario

        /// <summary> 
        /// Insere um Extrato Bancario
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Extratos Bancarios a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLExtratoFinanceiro> plstMLExtratoFinanceiro, out List<string> objRetorno)
        {
            DLExtratoFinanceiro objDLExtratoFinanceiro = new DLExtratoFinanceiro();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                objDLExtratoFinanceiro.BeginTransaction();

                foreach (MLExtratoFinanceiro objMLExtratoFinanceiro in plstMLExtratoFinanceiro)
                {
                    try
                    {
                        if (objMLExtratoFinanceiro.Operacao == "I")
                        {
                            objDLExtratoFinanceiro.Inserir(objMLExtratoFinanceiro);
                        }
                        else if (objMLExtratoFinanceiro.Operacao == "A")
                        {
                            var intCodigo = objDLExtratoFinanceiro.Alterar(objMLExtratoFinanceiro);

                            if (intCodigo == 0)
                            {
                                objDLExtratoFinanceiro.Inserir(objMLExtratoFinanceiro);
                            }
                        }
                        else if (objMLExtratoFinanceiro.Operacao == "E")
                        {
                            objDLExtratoFinanceiro.Excluir(Convert.ToDecimal(objMLExtratoFinanceiro.Codigo));
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLExtratoFinanceiro.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch(Exception ex)
                    {
                        objRetorno.Add("- Cód.:" + objMLExtratoFinanceiro.Codigo + " - Linha com erro(s). " + ex.Message);
                        bolErro = true;
                        break;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLExtratoFinanceiro.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLExtratoFinanceiro.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                objRetorno.Add("Importação não realizada!!");
                objDLExtratoFinanceiro.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLExtratoFinanceiro.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion
    }
}


