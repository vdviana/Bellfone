using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using BellFone.B2B.Model;
using BellFone.B2B.DataLayer;
using Framework.AtendimentoOnline.Model;
using Framework.AtendimentoOnline.DataLayer;
using VM2.Framework.BusinessLayer.Usuario;
using VM2.Framework.BusinessLayer.Utilitarios;
using System.Collections.ObjectModel;
using VM2.Framework.Model.Usuario;
using VM2.Framework.DataLayer.Usuario.Sql;

namespace BellFone.B2B.BusinessLayer
{
    /// <summary> 
    /// Classe de Business Layer para Vendedor 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class BLVendedor
    {

        #region Listar

        /// <summary> 
        /// Listar Vendedor
        /// </summary> 
        /// <param name="pobjMLVendedor">Parametros para filtro</param>
        /// <returns>Lista de Vendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLVendedor> Listar(MLVendedor pobjMLVendedor)
        {

            DLVendedor objDLVendedor = new DLVendedor();
            List<MLVendedor> lstRetorno = null;

            try
            {
                lstRetorno = objDLVendedor.Listar(pobjMLVendedor);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLVendedor.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Vendedor
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Vendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLVendedor Obter(string pstrCodigo)
        {

            DLVendedor objDLVendedor = new DLVendedor();
            MLVendedor objRetorno = null;

            try
            {
                objRetorno = objDLVendedor.Obter(pstrCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLVendedor.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Vendedor
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registros Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Excluir(string pstrCodigo)
        {

            DLVendedor objDLVendedor = new DLVendedor();
            BLUsuario objBLUsuario = new BLUsuario();

            try
            {
                objBLUsuario.Excluir(Convert.ToDecimal(this.Obter(pstrCodigo).CodigoUsuario));

                return objDLVendedor.Excluir(pstrCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLVendedor.Finalizar();
            }
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Vendedor
        /// </summary> 
        /// <param name="pobjMLVendedor">Vendedor com as alterações</param>
        /// <returns>Quantidade de Registros Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLVendedor pobjMLVendedor)
        {

            DLVendedor objDLVendedor = new DLVendedor();
            BLUsuario objBLUsuario = new BLUsuario();
            MLUsuario objMLUsuario = new MLUsuario();

            try
            {
                //Altera o Usuario conforme alteração do Revendedor
                objMLUsuario.Codigo = pobjMLVendedor.CodigoUsuario;
                objMLUsuario.Nome = pobjMLVendedor.Nome;
                objMLUsuario.Login = pobjMLVendedor.Email1;
                objMLUsuario.Senha = BLEncriptacao.EncriptarSenha((pobjMLVendedor.Senha));
                objMLUsuario.IsAtivo = true;
                objMLUsuario.IsAlterarSenha = false;

                objBLUsuario.Alterar(objMLUsuario);

                return objDLVendedor.Alterar(pobjMLVendedor);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLVendedor.Finalizar();
            }
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Vendedor
        /// </summary> 
        /// <param name="pobjMLVendedor">Vendedor a ser inserido</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Inserir(MLVendedor pobjMLVendedor)
        {

            DLVendedor objDLVendedor = new DLVendedor();
            BLUsuario objBLUsuario = new BLUsuario();
            MLUsuario objMLUsuario = new MLUsuario();
            var objBLGrupo = new VM2.Framework.BusinessLayer.Usuario.BLGrupo();
            var listMLGrupos = new List<VM2.Framework.Model.Usuario.MLGrupo>();
            var objMLGrupo = new VM2.Framework.Model.Usuario.MLGrupo();

            try
            {
                objDLVendedor.BeginTransaction();                 

                var intRows = 0;                               

                //cria o usuário do Revendedor e salva o código do usuário no revendedor
                objMLUsuario.Nome = pobjMLVendedor.Nome;
                objMLUsuario.Login = pobjMLVendedor.Email1;
                objMLUsuario.Senha = BLEncriptacao.EncriptarSenha((pobjMLVendedor.Senha));
                objMLUsuario.DataCadastro = DateTime.Today;
                objMLUsuario.IsAtivo = true;
                objMLUsuario.IsAlterarSenha = false;
                objMLUsuario.Email = pobjMLVendedor.Email1;

                pobjMLVendedor.CodigoUsuario = objBLUsuario.Inserir(objMLUsuario);

                try
                {
                    intRows = objDLVendedor.Inserir(pobjMLVendedor);
                }
                catch
                {
                    objBLUsuario.Excluir(Convert.ToDecimal(pobjMLVendedor.CodigoUsuario));
                    throw;
                }

                objMLGrupo.Codigo = 9;

                listMLGrupos = objBLGrupo.Listar(objMLGrupo);

                objBLUsuario.InserirGrupos(Convert.ToDecimal(pobjMLVendedor.CodigoUsuario), listMLGrupos);
        
                //cria atendente para o Chat Online
                var objMLAtendente = new ModelAtendente();
                objMLAtendente.CodVendedor = pobjMLVendedor.CodigoUsuario.ToString();
                objMLAtendente.Id = Convert.ToInt32(pobjMLVendedor.CodigoUsuario);
                objMLAtendente.Login = pobjMLVendedor.Email1;
                objMLAtendente.Nome = pobjMLVendedor.Nome;
                objMLAtendente.Senha = BLEncriptacao.EncriptarSenha(pobjMLVendedor.Senha);

                bool teste = new DALAtendente().Inserir(objMLAtendente);
                objDLVendedor.CommitTransaction();
                
                return intRows;
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLVendedor.Finalizar();
            }
        }

        #endregion

        #region Importação de Vendedor

        /// <summary> 
        /// Insere um Vendedor
        /// </summary> 
        /// <param name="pcolMLVendedor">collection com Vendedores a serem inseridos</param>         
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public bool Importacao(List<MLVendedor> lstMLVendedor, out List<string> objRetorno)
        {            
            DLVendedor objDLVendedor = new DLVendedor();
            DLUsuario objDLUsuario = new DLUsuario();
            var objDLGrupo = new VM2.Framework.DataLayer.Usuario.Sql.DLGrupo();

            var bolErro = false;
            bool boolIntegrou = false;
            objRetorno = new List<string>();

            try
            {
                // Inserir Grupo do Usuário
                var listMLGrupos = objDLGrupo.Listar(new VM2.Framework.Model.Usuario.MLGrupo() { Codigo = 9 });
                var strCodigosGrupos = string.Empty;
                if (listMLGrupos.Count > 0)
                {
                    strCodigosGrupos = listMLGrupos[0].Codigo.ToString();

                    for (int i = 1; i < listMLGrupos.Count; i++)
                    {
                        strCodigosGrupos += "," + listMLGrupos[i].Codigo.ToString();
                    }
                }

                objDLVendedor.BeginTransaction();
                objDLUsuario.TransacaoID = objDLVendedor.TransacaoID;
                objDLGrupo.TransacaoID = objDLVendedor.TransacaoID;

                foreach (MLVendedor objMLVendedor in lstMLVendedor)
                {
                    try
                    {
                        if (objMLVendedor.Operacao == "I")
                        {
                            bool blnValidado = (objDLUsuario.Listar(new MLUsuario() { Login = objMLVendedor.Email1 }).Count == 0);
                            if (!blnValidado)
                            {
                                objRetorno.Add("- Cód.: " + objMLVendedor.Codigo + " - Email do vendedor já esta cadastrado em nosso sistema.");
                                bolErro = true;
                            }
                            else 
                            {
                                var objMLUsuario = new MLUsuario();

                                //cria o usuário do Revendedor e salva o código do usuário no revendedor
                                objMLUsuario.Nome = objMLVendedor.Nome;
                                objMLUsuario.Login = objMLVendedor.Email1;
                                objMLUsuario.Senha = BLEncriptacao.EncriptarSenha((objMLVendedor.Senha));
                                objMLUsuario.DataCadastro = DateTime.Today;
                                objMLUsuario.IsAtivo = true;
                                objMLUsuario.IsAlterarSenha = false;
                                objMLUsuario.Email = objMLVendedor.Email1;
                                objMLVendedor.CodigoUsuario = objDLUsuario.Inserir(objMLUsuario);
                                                                
                                objDLUsuario.InserirGrupos(Convert.ToDecimal(objMLVendedor.CodigoUsuario), strCodigosGrupos);

                                //cria atendente para o Chat Online
                                var objMLAtendente = new ModelAtendente();
                                objMLAtendente.CodVendedor = objMLVendedor.CodigoUsuario.ToString();
                                objMLAtendente.Id = Convert.ToInt32(objMLVendedor.CodigoUsuario);
                                objMLAtendente.Login = objMLVendedor.Email1;
                                objMLAtendente.Nome = objMLVendedor.Nome;
                                objMLAtendente.Senha = BLEncriptacao.EncriptarSenha(objMLVendedor.Senha);

                                bool teste = new DALAtendente().Inserir(objMLAtendente);

                                objDLVendedor.Inserir(objMLVendedor);
                            }
                        }
                        else if (objMLVendedor.Operacao == "A")
                        {
                            var obj = objDLVendedor.Obter(objMLVendedor.Codigo);

                            if (obj != null)
                            {
                                objMLVendedor.CodigoUsuario = obj.CodigoUsuario;
                                objDLVendedor.Alterar(objMLVendedor);

                                //cria atendente para o Chat Online
                                var objMLAtendente = new ModelAtendente();
                                objMLAtendente.CodVendedor = objMLVendedor.CodigoUsuario.ToString();
                                objMLAtendente.Id = Convert.ToInt32(objMLVendedor.CodigoUsuario);
                                objMLAtendente.Login = objMLVendedor.Email1;
                                objMLAtendente.Nome = objMLVendedor.Nome;
                                objMLAtendente.Senha = BLEncriptacao.EncriptarSenha(objMLVendedor.Senha);

                                bool teste = new DALAtendente().Alterar(objMLAtendente);
                            }
                            else
                            {
                                var objMLUsuario = new MLUsuario();

                                //cria o usuário do Revendedor e salva o código do usuário no revendedor
                                objMLUsuario.Nome = objMLVendedor.Nome;
                                objMLUsuario.Login = objMLVendedor.Email1;
                                objMLUsuario.Senha = BLEncriptacao.EncriptarSenha((objMLVendedor.Senha));
                                objMLUsuario.DataCadastro = DateTime.Today;
                                objMLUsuario.IsAtivo = true;
                                objMLUsuario.IsAlterarSenha = false;
                                objMLUsuario.Email = objMLVendedor.Email1;
                                objMLVendedor.CodigoUsuario = objDLUsuario.Inserir(objMLUsuario);
                                                                
                                objDLUsuario.InserirGrupos(Convert.ToDecimal(objMLVendedor.CodigoUsuario), strCodigosGrupos);

                                //cria atendente para o Chat Online
                                var objMLAtendente = new ModelAtendente();
                                objMLAtendente.CodVendedor = objMLVendedor.CodigoUsuario.ToString();
                                objMLAtendente.Id = Convert.ToInt32(objMLVendedor.CodigoUsuario);
                                objMLAtendente.Login = objMLVendedor.Email1;
                                objMLAtendente.Nome = objMLVendedor.Nome;
                                objMLAtendente.Senha = BLEncriptacao.EncriptarSenha(objMLVendedor.Senha);

                                bool teste = new DALAtendente().Inserir(objMLAtendente);

                                objDLVendedor.Inserir(objMLVendedor);
                            }    
                        }
                        else if (objMLVendedor.Operacao == "E")
                        {                            
                            objDLVendedor.Excluir(objMLVendedor.Codigo);
                        }
                        else
                        {
                            objRetorno.Add("- Cód.: " + objMLVendedor.Codigo + " - Erro no código de Operação.");
                            bolErro = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        objRetorno.Add("Cód.: " + objMLVendedor.Codigo + " - Não Importado. " + ex.Message);
                        bolErro = true;
                        break;
                    }
                }

                if (bolErro)
                {
                    objRetorno.Add("Importação não realizada!!");
                    boolIntegrou = false;
                    objDLVendedor.RollBackTransaction();
                }
                else
                {
                    objDLVendedor.CommitTransaction();
                    objRetorno.Add("Importação realizada com sucesso!!");
                    boolIntegrou = true;
                }

            }
            catch (Exception ex)
            {
                objDLVendedor.RollBackTransaction();
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + ex.TargetSite.GetMethodBody().ToString(), ex);
            }
            finally
            {
                objDLVendedor.Finalizar();
                objDLUsuario.Finalizar();
                objDLGrupo.Finalizar();
            }
            return boolIntegrou;
        }

        #endregion


        #region ObterPorEmail

        /// <summary> 
        /// Obtem um Vendedor
        /// </summary> 
        /// <param name="pstrEmail">Codigo</param>
        /// <returns>Vendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLVendedor ObterPorEmail(string pstrEmail)
        {

            DLVendedor objDLVendedor = new DLVendedor();
            MLVendedor objRetorno = null;

            try
            {
                objRetorno = objDLVendedor.ObterPorEmail(pstrEmail);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLVendedor.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region ObterPorUsuario

        /// <summary> 
        /// Obtem por usuario
        /// </summary> 
        /// <param name="pdecUsuario">Usuario</param>
        /// <returns>Vendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLVendedor ObterPorUsuario(Decimal pdecUsuario)
        {

            DLVendedor objDLVendedor = new DLVendedor();
            MLVendedor objRetorno = null;

            try
            {
                objRetorno = objDLVendedor.ObterPorUsuario(pdecUsuario);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                objDLVendedor.Finalizar();
            }
            return objRetorno;
        }

        #endregion
    }
}


