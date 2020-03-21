using System;
using System.Text;
using System.Collections.Generic;
using VM2.Framework.Model.Usuario;
using VM2.Framework.DataLayer.Usuario;
using VM2.Framework.BusinessLayer.Utilitarios;
using System.Web;
using System.Web.Security;

namespace VM2.Framework.BusinessLayer.Usuario
{
    /// <summary> 
    /// Classe de Business Layer para Usuario 
    /// </summary> 
    /// <user>mazevedo</user> 
    public class BLUsuario
    {

        #region Listar

        /// <summary> 
        /// Listar Usuario
        /// </summary> 
        /// <param name="pobjMLUsuario">Parametros para filtro</param>
        /// <returns>Lista de Usuario</returns> 
        /// <user>mazevedo</user>
        public List<MLUsuario> Listar(MLUsuario pobjMLUsuario)
        {

            Connector conUsuario = new Connector();

            IDLUsuario objDLUsuario = conUsuario.ObterDLUsuario();
            List<MLUsuario> lstRetorno = null;

            try
            {
                lstRetorno = objDLUsuario.Listar(pobjMLUsuario);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conUsuario.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Usuario
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Usuario</returns> 
        /// <user>mazevedo</user>
        public MLUsuario Obter(decimal pdecCodigo)
        {

            Connector conUsuario = new Connector();

            IDLUsuario objDLUsuario = conUsuario.ObterDLUsuario();
            MLUsuario objRetorno = null;

            try
            {
                objRetorno = objDLUsuario.Obter(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conUsuario.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Obter (2) Nome do Usuário

        /// <summary> 
        /// Obtem um Usuario
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Usuario</returns> 
        /// <user>mazevedo</user>
        public MLUsuario Obter(string pstrLogin)
        {
            Connector conUsuario = new Connector();

            IDLUsuario objDLUsuario = conUsuario.ObterDLUsuario();
            MLUsuario objRetorno = null;

            try
            {
                objRetorno = objDLUsuario.Obter(pstrLogin);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conUsuario.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Obter Completo

        /// <summary>
        ///     Obter o usuário com todas as suas informações
        /// </summary>
        /// <user>mazevedo</user>
        public MLUsuarioGrupo ObterCompleto(decimal pdecCodigo)
        {
            Connector conUsuario = new Connector();

            IDLUsuario objDLUsuario = null;
            MLUsuarioGrupo objRetorno = null;

            try
            {
                objDLUsuario = conUsuario.ObterDLUsuario();
                objRetorno = objDLUsuario.ObterCompleto(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conUsuario.Finalizar();
            }

            return objRetorno;

        }


        #endregion

        #region Excluir

        /// <summary> 
        /// Exclui um Usuario
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Retorna da Operação</returns> 
        /// <user>mazevedo</user>
        public bool Excluir(decimal pdecCodigo)
        {

            Connector conUsuario = new Connector();

            IDLUsuario objDLUsuario = conUsuario.ObterDLUsuario();
            bool objRetorno = false;

            try
            {
                objRetorno = objDLUsuario.Excluir(pdecCodigo);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conUsuario.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Usuario
        /// </summary> 
        /// <param name="pobjMLUsuario">Usuario com as alterações</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>mazevedo</user>
        public bool Alterar(MLUsuario pobjMLUsuario)
        {
            Connector conUsuario = new Connector();

            IDLUsuario objDLUsuario = conUsuario.ObterDLUsuario();
            bool objRetorno = false;

            try
            {
                objRetorno = objDLUsuario.Alterar(pobjMLUsuario);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conUsuario.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir

        /// <summary> 
        /// Insere um Usuario
        /// </summary> 
        /// <param name="pobjMLUsuario">Usuario a ser inserido</param>
        /// <returns>Código Usuario</returns> 
        /// <user>mazevedo</user>
        public int Inserir(MLUsuario pobjMLUsuario)
        {
            Connector conUsuario = new Connector();

            IDLUsuario objDLUsuario = conUsuario.ObterDLUsuario();
            int objRetorno = 0;

            try
            {
                objRetorno = objDLUsuario.Inserir(pobjMLUsuario);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conUsuario.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Inserir Grupos

        /// <summary> 
        /// Insere os grupos do usuario
        /// </summary> 
        /// <param name="pdecCodigoUsuario"></param>
        /// <param name="plstGrupos"></param>
        /// <user>tprohaska</user>
        public void InserirGrupos(decimal pdecCodigoUsuario, List<MLGrupo> plstGrupos)
        {
            Connector conUsuario = new Connector();

            IDLUsuario objDLUsuario = conUsuario.ObterDLUsuario();
            string strCodigosGrupos = string.Empty;
            try
            {
                if (plstGrupos.Count > 0)
                {
                    strCodigosGrupos = plstGrupos[0].Codigo.ToString();

                    for (int i = 1; i < plstGrupos.Count; i++)
                    {
                        strCodigosGrupos += "," + plstGrupos[i].Codigo.ToString();
                    }
                }

                objDLUsuario.InserirGrupos(pdecCodigoUsuario, strCodigosGrupos);

            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conUsuario.Finalizar();
            }
        }

        #endregion

        #region Inserir Auditoria Acesso
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pobjMLLogAcesso"></param>
        /// <returns></returns>
        public decimal InserirAuditoriaAcesso(MLLogAcesso pobjMLLogAcesso)
        {
            var conUsuario = new Connector();

            IDLUsuario objDLUsuario = conUsuario.ObterDLUsuario();
            decimal objRetorno = 0;

            try
            {
                objRetorno = objDLUsuario.InserirAuditoriaAcesso(pobjMLLogAcesso);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conUsuario.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Listar Auditoria Acesso
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pobjMLLogAcesso"></param>
        /// <returns></returns>
        public List<MLLogAcesso> ListarAuditoriaAcesso(Decimal pdecCodigoUsuario, DateTime? pdtDataInicio, DateTime? pdtDataFinal)
        {
            var conUsuario = new Connector();

            IDLUsuario objDLUsuario = conUsuario.ObterDLUsuario();
            List<MLLogAcesso> lstRetorno = new List<MLLogAcesso>();

            try
            {
                lstRetorno = objDLUsuario.ListarAuditoriaAcesso(pdecCodigoUsuario,  pdtDataInicio,  pdtDataFinal);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conUsuario.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Operacoes de Login

        #region Armazenar Logado

        /// <summary>
        ///     Armazena o usuário logado no contexto da aplicacao
        /// </summary>
        /// <user>mazevedo</user>
        public static void ArmazenarLogado()
        {
            Connector conUsuario = new Connector();
            int intCodigoUsuarioLogado;
            IDLUsuario objDLUsuario = null;
            MLUsuarioGrupo objUsuario = null;

            if (HttpContext.Current.Items["ctxUsuario"] == null && HttpContext.Current.Request.IsAuthenticated)
            {
                intCodigoUsuarioLogado = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                try
                {
                    objDLUsuario = conUsuario.ObterDLUsuario();
                    objUsuario = objDLUsuario.ObterCompleto(intCodigoUsuarioLogado);
                }
                catch (Exception ex)
                {
                    BLFuncoes.GravaLog(
                        "Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " +
                        System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                    throw;
                }
                finally
                {
                    conUsuario.Finalizar();
                }

            }

            if (objUsuario != null)
            {
                HttpContext.Current.Items["ctxUsuario"] = objUsuario;
            }

        }

        #endregion

        #region Armazenar Logado Session
        /// <summary>
        ///     Armazena o usuário logado no contexto da aplicacao
        /// </summary>
        /// <user>mazevedo</user>
        public static void ArmazenarLogadoSession()
        {
            Connector conUsuario = new Connector();
            int intCodigoUsuarioLogado;
            IDLUsuario objDLUsuario = null;
            MLUsuarioGrupo objUsuario = null;

            intCodigoUsuarioLogado = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

            try
            {
                objDLUsuario = conUsuario.ObterDLUsuario();
                objUsuario = objDLUsuario.ObterCompleto(intCodigoUsuarioLogado);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog(
                    "Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " +
                    System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conUsuario.Finalizar();
            }

            if (objUsuario != null)
            {
                HttpContext.Current.Session["ssUsuario"] = objUsuario;
            }

        }

        #endregion

        #region Obter Logado

        /// <summary>
        ///     Retorna o usuário logado atualmente no sistema
        /// </summary>
        /// <returns>Usuário Logado</returns>
        /// <user>mazevedo</user>
        public static MLUsuario ObterLogado()
        {
            if (BLConfiguracao.IsAutenticacaoUsandoSession)
            {
                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    if (HttpContext.Current.Session["ssUsuario"] == null)
                    {
                        ArmazenarLogadoSession();
                    }
                    
                    return (MLUsuario)HttpContext.Current.Session["ssUsuario"];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if (HttpContext.Current.Request.IsAuthenticated && HttpContext.Current.Items["ctxUsuario"] != null)
                {
                    return (MLUsuario)HttpContext.Current.Items["ctxUsuario"];
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region Autenticar Usuário

        /// <summary>
        ///     Autentica o Usuário
        /// </summary>
        /// <param name="pstrLogin">Login do Usuário</param>
        /// <param name="pstrSenha">Senha do Usuário</param>
        /// <returns>Resultado da operação</returns>
        /// <user>mazevedo</user>
        public static bool? AutenticarUsuario(string pstrLogin, string pstrSenha)
        {
            BLUsuario objBLUsuario = new BLUsuario();
            MLUsuario objMLUsuario = null;
            bool blnRetorno = false;

            try
            {
                objMLUsuario = objBLUsuario.Obter(pstrLogin);

                if (objMLUsuario.IsAtivo.Value && BLEncriptacao.EncriptarSenha(pstrSenha) == objMLUsuario.Senha)
                {
                    if (objMLUsuario.IsAlterarSenha.Value)
                        return null;

                    blnRetorno = true;
                    FormsAuthentication.SetAuthCookie(objMLUsuario.Codigo.ToString(), false);
                }
                else
                {
                    blnRetorno = false;
                }
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
            }

            return blnRetorno;
        }

        #endregion

        #region Alterar Senha

        /// <summary>
        ///     Alterar senha
        /// </summary>
        /// <param name="pstrLogin">Login</param>
        /// <param name="pstrNovaSenha">Nova senha</param>
        /// <returns>Resultado da Operação</returns>
        /// <user>mazevedo</user>
        public static bool AlterarSenha(string pstrLogin, string pstrNovaSenha, bool pblnIsAlterarSenhaProximoLogin)
        {
            BLUsuario objBLUsuario = new BLUsuario();
            MLUsuario objMLUsuario = null;
            bool blnRetorno = true;

            try
            {
                objMLUsuario = objBLUsuario.Obter(pstrLogin);
                objMLUsuario.Senha = BLEncriptacao.EncriptarSenha(pstrNovaSenha);
                objMLUsuario.IsAlterarSenha = pblnIsAlterarSenhaProximoLogin;
                blnRetorno = objBLUsuario.Alterar(objMLUsuario);
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                    FormsAuthentication.SetAuthCookie(objMLUsuario.Codigo.ToString(), false);


            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
            }

            return blnRetorno;
        }

        #endregion

        #region Encriptar Senha

        /// <summary>
        ///     Alterar senha
        /// </summary>
        /// <param name="pstrLogin">Login</param>
        /// <param name="pstrNovaSenha">Nova senha</param>
        /// <returns>Resultado da Operação</returns>
        /// <user>mazevedo</user>
        public string EncriptarSenha(string pstrNovaSenha)
        {
            return BLEncriptacao.EncriptarSenha(pstrNovaSenha);
        }

        #endregion

        #region Efetuar Logoff

        /// <summary>
        ///     Efetua o logoff do usuário
        /// </summary>
        /// <user>mazevedo</user>
        public static void EfetuarLogoff()
        {
            FormsAuthentication.SignOut();
        }

        #endregion

        #endregion

    }
}


