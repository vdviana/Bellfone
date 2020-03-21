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
    /// Classe de Business Layer para UnidadeMedida 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class BLUnidadeMedida
    {

        #region Listar

        /// <summary> 
        /// Listar UnidadeMedida
        /// </summary> 
        /// <param name="pobjMLUnidadeMedida">Parametros para filtro</param>
        /// <returns>Lista de UnidadeMedida</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLUnidadeMedida> Listar(MLUnidadeMedida pobjMLUnidadeMedida)
        {

            DLUnidadeMedida objDLUnidadeMedida = new DLUnidadeMedida();
            List<MLUnidadeMedida> lstRetorno = null;
        
            try
            {
                lstRetorno = objDLUnidadeMedida.Listar(pobjMLUnidadeMedida);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLUnidadeMedida.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um UnidadeMedida
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>UnidadeMedida</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLUnidadeMedida Obter(string pstrCodigo)
        {

            DLUnidadeMedida objDLUnidadeMedida = new DLUnidadeMedida();
            MLUnidadeMedida objRetorno = null;
        
            try
            {
                objRetorno = objDLUnidadeMedida.Obter(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLUnidadeMedida.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um UnidadeMedida
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Excluir(string pstrCodigo)
        {

            DLUnidadeMedida objDLUnidadeMedida = new DLUnidadeMedida();
        
            try
            {
                return objDLUnidadeMedida.Excluir(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLUnidadeMedida.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um UnidadeMedida
        /// </summary> 
        /// <param name="pobjMLUnidadeMedida">UnidadeMedida com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLUnidadeMedida pobjMLUnidadeMedida)
        {

            DLUnidadeMedida objDLUnidadeMedida = new DLUnidadeMedida();
        
            try
            {
                return objDLUnidadeMedida.Alterar(pobjMLUnidadeMedida);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLUnidadeMedida.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um UnidadeMedida
        /// </summary> 
        /// <param name="pobjMLUnidadeMedida">UnidadeMedida a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public  int Inserir(MLUnidadeMedida pobjMLUnidadeMedida)
        {

            DLUnidadeMedida objDLUnidadeMedida = new DLUnidadeMedida();
        
            try
            {
                return objDLUnidadeMedida.Inserir(pobjMLUnidadeMedida);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLUnidadeMedida.Finalizar();
            }
        }

        #endregion

        #region Importação de Unidade de Medida

        /// <summary> 
        /// Importação de Unidade de Medida
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Categorias a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLUnidadeMedida> plstMLUnidadeMedida, out List<string> objRetorno)
        {
            DLUnidadeMedida objDLUnidadeMedida = new DLUnidadeMedida();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                objDLUnidadeMedida.BeginTransaction();

                foreach (MLUnidadeMedida objMLUnidadeMedida in plstMLUnidadeMedida)
                {
                    try
                    {
                        if (objMLUnidadeMedida.Operacao == "I")
                        {
                            objDLUnidadeMedida.Inserir(objMLUnidadeMedida);
                            
                        }
                        else if (objMLUnidadeMedida.Operacao == "A")
                        {
                            var intCodigo = objDLUnidadeMedida.Alterar(objMLUnidadeMedida);

                            if (intCodigo == 0)
                            {
                                objDLUnidadeMedida.Inserir(objMLUnidadeMedida);
                            }
                        }
                        else if (objMLUnidadeMedida.Operacao == "E")
                        {
                            objDLUnidadeMedida.Excluir(objMLUnidadeMedida.Codigo);
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLUnidadeMedida.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLUnidadeMedida.Codigo + " - Linha com erro(s). " + ex.Message);
                        bolErro = true;
                        throw;
                    }
                }
                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLUnidadeMedida.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLUnidadeMedida.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                objRetorno.Add("Importação não realizada!!");
                objDLUnidadeMedida.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLUnidadeMedida.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion

    }
}



