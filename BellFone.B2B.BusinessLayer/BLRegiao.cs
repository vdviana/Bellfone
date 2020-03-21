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
    /// Classe de Business Layer para Regiao 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class BLRegiao
    {

        #region Listar

        /// <summary> 
        /// Listar Regiao
        /// </summary> 
        /// <param name="pobjMLRegiao">Parametros para filtro</param>
        /// <returns>Lista de Regiao</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLRegiao> Listar(MLRegiao pobjMLRegiao)
        {

            DLRegiao objDLRegiao = new DLRegiao();
            List<MLRegiao> lstRetorno = null;
        
            try
            {
                lstRetorno = objDLRegiao.Listar(pobjMLRegiao);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRegiao.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Regiao
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Regiao</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLRegiao Obter(string pstrCodigo)
        {

            DLRegiao objDLRegiao = new DLRegiao();
            MLRegiao objRetorno = null;
        
            try
            {
                objRetorno = objDLRegiao.Obter(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRegiao.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Regiao
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Excluir(string pstrCodigo)
        {

            DLRegiao objDLRegiao = new DLRegiao();
        
            try
            {
                return objDLRegiao.Excluir(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRegiao.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Regiao
        /// </summary> 
        /// <param name="pobjMLRegiao">Regiao com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLRegiao pobjMLRegiao)
        {

            DLRegiao objDLRegiao = new DLRegiao();
        
            try
            {
                return objDLRegiao.Alterar(pobjMLRegiao);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRegiao.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Regiao
        /// </summary> 
        /// <param name="pobjMLRegiao">Regiao a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public  int Inserir(MLRegiao pobjMLRegiao)
        {

            DLRegiao objDLRegiao = new DLRegiao();
        
            try
            {
                return objDLRegiao.Inserir(pobjMLRegiao);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRegiao.Finalizar();
            }
        }

        #endregion

        #region Importação de Tipo de Negocio

        /// <summary> 
        /// Insere Tipos de Negocios
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Tipos de Negocios a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLRegiao> plstMLRegiao, out List<string> objRetorno)
        {
            DLRegiao objDLRegiao = new DLRegiao();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                objDLRegiao.BeginTransaction();

                foreach (MLRegiao objMLRegiao in plstMLRegiao)
                {
                    try
                    {
                        if (objMLRegiao.Operacao == "I")
                        {
                            objDLRegiao.Inserir(objMLRegiao);
                        }
                        else if (objMLRegiao.Operacao == "A")
                        {
                            var intCodigo = objDLRegiao.Alterar(objMLRegiao);

                            if (intCodigo == 0)
                            {
                                objDLRegiao.Inserir(objMLRegiao);
                            }
                        }
                        else if (objMLRegiao.Operacao == "E")
                        {
                            objDLRegiao.Excluir(objMLRegiao.Codigo);
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLRegiao.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLRegiao.Codigo + " - Linha com erro(s). " + ex.Message);
                        bolErro = true;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLRegiao.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLRegiao.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                objRetorno.Add("Importação não realizada!!");
                objDLRegiao.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLRegiao.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion
    }
}


