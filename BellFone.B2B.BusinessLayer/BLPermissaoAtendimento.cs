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
    /// Classe de Business Layer para PermissaoAtendimento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class BLPermissaoAtendimento
    {

        #region Listar

        /// <summary> 
        /// Listar PermissaoAtendimento
        /// </summary> 
        /// <param name="pobjMLPermissaoAtendimento">Parametros para filtro</param>
        /// <returns>Lista de PermissaoAtendimento</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLPermissaoAtendimento> Listar(MLPermissaoAtendimento pobjMLPermissaoAtendimento)
        {

            DLPermissaoAtendimento objDLPermissaoAtendimento = new DLPermissaoAtendimento();
            List<MLPermissaoAtendimento> lstRetorno = null;

            try
            {
                lstRetorno = objDLPermissaoAtendimento.Listar(pobjMLPermissaoAtendimento);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLPermissaoAtendimento.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um PermissaoAtendimento
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>PermissaoAtendimento</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLPermissaoAtendimento Obter(decimal pdecCodigo)
        {

            DLPermissaoAtendimento objDLPermissaoAtendimento = new DLPermissaoAtendimento();
            MLPermissaoAtendimento objRetorno = null;

            try
            {
                objRetorno = objDLPermissaoAtendimento.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLPermissaoAtendimento.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um PermissaoAtendimento
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Excluir(decimal pdecCodigo)
        {

            DLPermissaoAtendimento objDLPermissaoAtendimento = new DLPermissaoAtendimento();

            try
            {
                return objDLPermissaoAtendimento.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLPermissaoAtendimento.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um PermissaoAtendimento
        /// </summary> 
        /// <param name="pobjMLPermissaoAtendimento">PermissaoAtendimento com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLPermissaoAtendimento pobjMLPermissaoAtendimento)
        {

            DLPermissaoAtendimento objDLPermissaoAtendimento = new DLPermissaoAtendimento();

            try
            {
                return objDLPermissaoAtendimento.Alterar(pobjMLPermissaoAtendimento);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLPermissaoAtendimento.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um PermissaoAtendimento
        /// </summary> 
        /// <param name="pobjMLPermissaoAtendimento">PermissaoAtendimento a ser inserido</param>
        /// <returns>Código PermissaoAtendimento</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public decimal Inserir(MLPermissaoAtendimento pobjMLPermissaoAtendimento)
        {

            DLPermissaoAtendimento objDLPermissaoAtendimento = new DLPermissaoAtendimento();

            try
            {
                return objDLPermissaoAtendimento.Inserir(pobjMLPermissaoAtendimento);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLPermissaoAtendimento.Finalizar();
            }
        }

        #endregion

        #region Importação de Permissão de Atendimento

        /// <summary> 
        /// Insere Permissões de Atendimento
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Permissões de Atendimento a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLPermissaoAtendimento> plstMLPermissaoAtendimento, out List<string> objRetorno)
        {
            DLPermissaoAtendimento objDLPermissaoAtendimento = new DLPermissaoAtendimento();
            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                objDLPermissaoAtendimento.BeginTransaction();

                foreach (MLPermissaoAtendimento objMLPermissaoAtendimento in plstMLPermissaoAtendimento)
                {
                    try
                    {
                        if (objMLPermissaoAtendimento.Operacao == "I")
                        {
                            objDLPermissaoAtendimento.Inserir(objMLPermissaoAtendimento);
                        }
                        else if (objMLPermissaoAtendimento.Operacao == "A")
                        {
                            var intCodigo = objDLPermissaoAtendimento.Alterar(objMLPermissaoAtendimento);

                            if (intCodigo == 0)
                            {
                                objDLPermissaoAtendimento.Inserir(objMLPermissaoAtendimento);
                            }
                        }
                        else if (objMLPermissaoAtendimento.Operacao == "E")
                        {
                            objDLPermissaoAtendimento.Excluir(Convert.ToDecimal(objMLPermissaoAtendimento.Codigo));
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLPermissaoAtendimento.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLPermissaoAtendimento.Codigo + " - Linha com erro(s). " + ex.Message);
                        bolErro = true;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLPermissaoAtendimento.RollBackTransaction();
                }
                else
                {
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                    objDLPermissaoAtendimento.CommitTransaction();
                }

            }
            catch (Exception ex)
            {
                objRetorno.Add("Importação não realizada!!");
                objDLPermissaoAtendimento.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLPermissaoAtendimento.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion
    }
}


