using System;
using System.Collections.Generic;
using System.Reflection;
using BellFone.B2B.Model;
using BellFone.B2B.DataLayer;
using VM2.Framework.BusinessLayer.Usuario;
using VM2.Framework.BusinessLayer.Utilitarios;
using VM2.Framework.Model.Usuario;
using Framework.AtendimentoOnline.Model;
using Framework.AtendimentoOnline.DataLayer;
using VM2.Framework.DataLayer.Usuario.Sql;


namespace BellFone.B2B.BusinessLayer
{
    /// <summary> 
    /// Classe de Business Layer para Revendedor 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class BLRevendedor
    {
        #region Listar

        /// <summary> 
        /// Listar Revendedor
        /// </summary> 
        /// <param name="pobjMLRevendedor">Parametros para filtro</param>
        /// <returns>Lista de Revendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLRevendedor> Listar(MLRevendedor pobjMLRevendedor)
        {

            DLRevendedor objDLRevendedor = new DLRevendedor();
            List<MLRevendedor> lstRetorno = null;
        
            try
            {
                lstRetorno = objDLRevendedor.Listar(pobjMLRevendedor);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRevendedor.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Revendedor
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Revendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLRevendedor Obter(string pstrCodigo)
        {

            DLRevendedor objDLRevendedor = new DLRevendedor();
            MLRevendedor objRetorno = null;
        
            try
            {
                objRetorno = objDLRevendedor.Obter(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRevendedor.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Revendedor
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Excluir(string pstrCodigo)
        {

            var objDLRevendedor = new DLRevendedor();
            BLUsuario objBLUsuario = new BLUsuario();
        
            try
            {
                objBLUsuario.Excluir(Convert.ToDecimal(this.Obter(pstrCodigo).CodigoUsuario));

                return objDLRevendedor.Excluir(pstrCodigo);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRevendedor.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Revendedor
        /// </summary> 
        /// <param name="pobjMLRevendedor">Revendedor com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLRevendedor pobjMLRevendedor)
        {

            DLRevendedor objDLRevendedor = new DLRevendedor();
            BLUsuario objBLUsuario = new BLUsuario();
            MLUsuario objMLUsuario = new MLUsuario();
        
            try
            {
                //Altera o Usuario conforme alteração do Revendedor                
                objMLUsuario.Codigo = pobjMLRevendedor.CodigoUsuario;                            
                objMLUsuario.Nome = pobjMLRevendedor.RazaoSocial;
                objMLUsuario.Login = pobjMLRevendedor.Email;
                objMLUsuario.Senha = BLEncriptacao.EncriptarSenha((pobjMLRevendedor.Senha));
                objMLUsuario.IsAtivo = true;
                objMLUsuario.IsAlterarSenha = false;

                objBLUsuario.Alterar(objMLUsuario);

                return objDLRevendedor.Alterar(pobjMLRevendedor);
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRevendedor.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Revendedor
        /// </summary> 
        /// <param name="pobjMLRevendedor">Revendedor a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Inserir(MLRevendedor pobjMLRevendedor)
        {

            var objDLRevendedor = new DLRevendedor();
            var objDLUsuario = new DLUsuario();
            var objMLUsuario = new MLUsuario();
            var objDLGrupo = new VM2.Framework.DataLayer.Usuario.Sql.DLGrupo();
            var listMLGrupos = new List<VM2.Framework.Model.Usuario.MLGrupo>();
            var objMLGrupo = new VM2.Framework.Model.Usuario.MLGrupo();
            
           

            try
            {

                objDLRevendedor.BeginTransaction();
                objDLUsuario.TransacaoID = objDLRevendedor.TransacaoID;
                objDLGrupo.TransacaoID = objDLRevendedor.TransacaoID;

                var intRows = 0;
                               
                //cria o usuário do Revendedor e salva o código do usuário no revendedor
                objMLUsuario.Nome = pobjMLRevendedor.RazaoSocial;
                objMLUsuario.Login = pobjMLRevendedor.Email;
                objMLUsuario.Senha = BLEncriptacao.EncriptarSenha((pobjMLRevendedor.Senha));
                objMLUsuario.DataCadastro = DateTime.Today;
                objMLUsuario.IsAtivo = true;
                objMLUsuario.IsAlterarSenha = false;
                objMLUsuario.Email = pobjMLRevendedor.Email;

                pobjMLRevendedor.CodigoUsuario = objDLUsuario.Inserir(objMLUsuario);

                intRows = objDLRevendedor.Inserir(pobjMLRevendedor);

                objMLGrupo.Codigo = 8;

                listMLGrupos = objDLGrupo.Listar(objMLGrupo);

                var strCodigosGrupos = string.Empty;
                if (listMLGrupos.Count > 0)
                {
                    strCodigosGrupos = listMLGrupos[0].Codigo.ToString();

                    for (int i = 1; i < listMLGrupos.Count; i++)
                    {
                        strCodigosGrupos += "," + listMLGrupos[i].Codigo.ToString();
                    }
                }

                objDLUsuario.InserirGrupos(Convert.ToDecimal(pobjMLRevendedor.CodigoUsuario), strCodigosGrupos);

                objDLRevendedor.CommitTransaction();

                return intRows;
            }
            catch  (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRevendedor.Finalizar();
                objDLUsuario.Finalizar();
                objDLGrupo.Finalizar();
            }
        }

        #endregion

        #region Importação de Revendedores

        /// <summary> 
        /// Insere Revendedores
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Revendedores a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLRevendedor> plstMLRevendedor, out List<string> objRetorno)
        {
            DLRevendedor objDLRevendedor = new DLRevendedor();
            DLUsuario objDLUsuario = new DLUsuario();
            var objDLGrupo = new VM2.Framework.DataLayer.Usuario.Sql.DLGrupo();

            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                // Inserir Grupo do Usuário
                var listMLGrupos = new VM2.Framework.BusinessLayer.Usuario.BLGrupo().Listar(new VM2.Framework.Model.Usuario.MLGrupo() { Codigo = 8 });
                var strCodigosGrupos = string.Empty;
                if (listMLGrupos.Count > 0)
                {
                    strCodigosGrupos = listMLGrupos[0].Codigo.ToString();

                    for (int i = 1; i < listMLGrupos.Count; i++)
                    {
                        strCodigosGrupos += "," + listMLGrupos[i].Codigo.ToString();
                    }
                }

                objDLRevendedor.BeginTransaction();
                objDLUsuario.TransacaoID = objDLRevendedor.TransacaoID;
                objDLGrupo.TransacaoID = objDLRevendedor.TransacaoID;

                foreach (MLRevendedor objMLRevendedor in plstMLRevendedor)
                {
                    try
                    {
                        if (objMLRevendedor.Operacao == "I")
                        {
                            bool blnValidado = (objDLUsuario.Listar(new MLUsuario() { Login = objMLRevendedor.Email }).Count == 0);
                            if (!blnValidado)
                            {
                                objRetorno.Add("- Cód.: " + objMLRevendedor.Codigo + " - Email do revendedor já esta cadastrado em nosso sistema.");
                                bolErro = true;
                            }
                            else
                            {
                                var objMLUsuario = new MLUsuario();

                                //cria o usuário do Revendedor e salva o código do usuário no revendedor
                                objMLUsuario.Nome = objMLRevendedor.RazaoSocial;
                                objMLUsuario.Login = objMLRevendedor.Email;
                                objMLUsuario.Senha = BLEncriptacao.EncriptarSenha((objMLRevendedor.Senha));
                                objMLUsuario.DataCadastro = DateTime.Today;
                                objMLUsuario.IsAtivo = true;
                                objMLUsuario.IsAlterarSenha = false;
                                objMLUsuario.Email = objMLRevendedor.Email;
                                objMLRevendedor.CodigoUsuario = objDLUsuario.Inserir(objMLUsuario);

                                objDLUsuario.InserirGrupos(Convert.ToDecimal(objMLRevendedor.CodigoUsuario), strCodigosGrupos);

                                objDLRevendedor.Inserir(objMLRevendedor);
                            }                            
                        }
                        else if (objMLRevendedor.Operacao == "A")
                        {
                                var obj = objDLRevendedor.Obter(objMLRevendedor.Codigo);

                                if (obj != null)
                                {
                                    objMLRevendedor.CodigoUsuario = obj.CodigoUsuario;
                                    objDLRevendedor.Alterar(objMLRevendedor);
                                }
                                else
                                {
                                    var objMLUsuario = new MLUsuario();

                                    //cria o usuário do Revendedor e salva o código do usuário no revendedor
                                    objMLUsuario.Nome = objMLRevendedor.RazaoSocial;
                                    objMLUsuario.Login = objMLRevendedor.Email;
                                    objMLUsuario.Senha = BLEncriptacao.EncriptarSenha((objMLRevendedor.Senha));
                                    objMLUsuario.DataCadastro = DateTime.Today;
                                    objMLUsuario.IsAtivo = true;
                                    objMLUsuario.IsAlterarSenha = false;
                                    objMLUsuario.Email = objMLRevendedor.Email;
                                    objMLRevendedor.CodigoUsuario = objDLUsuario.Inserir(objMLUsuario);

                                    objDLUsuario.InserirGrupos(Convert.ToDecimal(objMLRevendedor.CodigoUsuario), strCodigosGrupos);

                                    objDLRevendedor.Inserir(objMLRevendedor);                                    
                                }                                 
                        }
                        else if (objMLRevendedor.Operacao == "E")
                        {
                            objDLRevendedor.Excluir(objMLRevendedor.Codigo);
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLRevendedor.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("- Cód.: " + objMLRevendedor.Codigo + " - Linha com erros. " + ex.Message);
                        bolErro = true;
                        break;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLRevendedor.RollBackTransaction();
                }
                else
                {
                    objDLRevendedor.CommitTransaction();
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                }
            }
            catch (Exception ex)
            {
                objDLRevendedor.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLRevendedor.Finalizar();
                objDLUsuario.Finalizar();
                objDLGrupo.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion

        #region Obter Por Usuário

        /// <summary> 
        /// Obtem um Revendedor
        /// </summary> 
        /// <param name="pdecUsuario">Codigo</param>
        /// <returns>Revendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLRevendedor ObterPorUsuario(Decimal pdecUsuario)
        {

            DLRevendedor objDLRevendedor = new DLRevendedor();
            MLRevendedor objRetorno = null;

            try
            {
                objRetorno = objDLRevendedor.ObterPorUsuario(pdecUsuario);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRevendedor.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Obter Por Email

        /// <summary> 
        /// Obtem um Revendedor
        /// </summary> 
        /// <param name="pstrEmail">Codigo</param>
        /// <returns>Revendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLRevendedorCompleto ObterPorEmail(string pstrEmail)
        {

            DLRevendedor objDLRevendedor = new DLRevendedor();
            MLRevendedorCompleto objRetorno = null;

            try
            {
                objRetorno = objDLRevendedor.ObterPorEmail(pstrEmail);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLRevendedor.Finalizar();
            }
            return objRetorno;
        }

        #endregion
    }
}


