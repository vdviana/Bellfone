using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using VM2.Framework.Model.Utilitarios;
using VM2.Framework.DataLayer.Utilitarios;

namespace VM2.Framework.BusinessLayer.Utilitarios
{
    /// <summary>
    ///     Classe de business layer para acesso a configuração
    /// </summary>
    /// <user>mazevedo</user>
    public class BLConfiguracao
    {

        #region GravarLog
        /// <summary>
        ///     Obter a configuração referente a log
        /// </summary>
        /// <user>mazevedo</user>
        public static bool IsGravarLog
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.GravaLog"] != null)
                {
                    return Convert.ToBoolean(ConfigurationManager.AppSettings["VM2.Framework.GravaLog"]);
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region TimeOutUsuario
        /// <summary>
        ///     Obter a configuração referente a log
        /// </summary>
        /// <user>mazevedo</user>
        public static int TimeOutUsuario
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.TimeOutUsuario"] != null)
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Framework.TimeOutUsuario"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion

        #region CodigoGrupoAdministrador
        /// <summary>
        ///     Obter a configuração referente a log
        /// </summary>
        /// <user>mazevedo</user>
        public static List<decimal> CodigoGrupoAdministrador
        {
            get
            {
                List<decimal> lstRetorno = null;
                if (ConfigurationManager.AppSettings["VM2.Framework.CodigoGrupoAdmin"] != null)
                {
                    lstRetorno = new List<decimal>();
                    string strListaGrupo;
                    string[] strArrayCodigo;
                    strListaGrupo = ConfigurationManager.AppSettings["VM2.Framework.CodigoGrupoAdmin"];
                    strArrayCodigo = strListaGrupo.Split(Convert.ToChar(";"));

                    for (int intContador = 0; intContador < strArrayCodigo.Length; intContador++)
                    {
                        lstRetorno.Add(Convert.ToDecimal(strArrayCodigo[intContador]));
                    }

                }

                return lstRetorno;

            }
        }
        #endregion

        #region RegistrosPagina

        /// <summary>
        ///     Numero de registros para paginação
        /// </summary>
        /// <user>mazevedo</user>
        public static int RegistroPagina
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.NumeroRegistrosPagina"] != null)
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Framework.NumeroRegistrosPagina"]);
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion

        #region PaginaAcessoNegado

        /// <summary>
        ///     Página para redirecionamento quando acesso é negado
        /// </summary>
        /// <user>mazevedo</user>
        public static string PaginaAcessoNegado
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.PaginaAcessoNegado"] != null)
                {
                    return ConfigurationManager.AppSettings["VM2.Framework.PaginaAcessoNegado"];
                }
                else
                {
                    return "";
                }
            }
        }

        #endregion

        #region PaginaEntradaUsuarioAutenticado

        /// <summary>
        ///     Página para redirecionamento quando o usuário é autenticado
        /// </summary>
        /// <user>mazevedo</user>
        public static string PaginaEntradaUsuarioAutenticado
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.PaginaEntradaUsuarioAutenticado"] != null)
                {
                    return ConfigurationManager.AppSettings["VM2.Framework.PaginaEntradaUsuarioAutenticado"];
                }
                else
                {
                    return "";
                }
            }
        }

        #endregion

        #region CodigoMenuAdmin
        /// <summary>
        ///     Obter a configuração referente a log
        /// </summary>
        /// <user>mazevedo</user>
        public static int CodigoMenuAdmin
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.CodigoMenuAdmin"] != null)
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Framework.CodigoMenuAdmin"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion

        #region CodigoMenuPublico
        /// <summary>
        ///     Obter a configuração referente a log
        /// </summary>
        /// <user>mazevedo</user>
        public static int CodigoMenuPublico
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.CodigoMenuPublico"] != null)
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Framework.CodigoMenuPublico"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion

        #region IsEmailLogin

        /// <summary>
        ///     Define se o cadastro de usuário
        ///     utiliza o email para login ou não
        /// </summary>
        /// <user>tprohaska</user>
        public static bool IsEmailLogin
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.UsarEmailComoLogin"] != null)
                {
                    return Convert.ToBoolean(Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Framework.UsarEmailComoLogin"]));
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region IsMenuCache

        /// <summary>
        ///     Define se o menu será guardado em cache
        /// </summary>
        /// <user>mazevedo</user>
        public static bool IsMenuCache
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.MenuUtilizaCache"] != null)
                {
                    return Convert.ToBoolean(Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Framework.MenuUtilizaCache"]));
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region TempoExpiracaoCache
        /// <summary>
        ///     Obter a configuração referente a log
        /// </summary>
        /// <user>mazevedo</user>
        public static int TempoExpiracaoCache
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.TempoExpiracaoCache"] != null)
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Framework.TempoExpiracaoCache"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion

        #region ExtensoesPermitidas
        /// <summary>
        /// Obter as extensoes permitidas para upload
        /// </summary>
        /// <user>larruda</user>
        public static string[] ExtensoesPermitidas
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.Arquivos.ExtensoesPermitidas"].ToString().Split(',') != null)
                {
                    return ConfigurationManager.AppSettings["VM2.Framework.Arquivos.ExtensoesPermitidas"].ToString().Split(',');
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region MultiIdioma
        /// <summary>
        ///     Obter a configuração referente a multidioma
        /// </summary>
        /// <user>mazevedo</user>
        public static bool IsMultiIdioma
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.MultiIdioma"] != null)
                {
                    return Convert.ToBoolean(ConfigurationManager.AppSettings["VM2.Framework.MultiIdioma"]);
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region CodigoIdiomaPadrao
        /// <summary>
        ///     Obter o codigo do idioma padrao
        /// </summary>
        /// <user>mazevedo</user>
        public static decimal CodigoIdiomaPadrao
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.CodigoIdiomaPadrao"] != null)
                {
                    return Convert.ToDecimal(ConfigurationManager.AppSettings["VM2.Framework.CodigoIdiomaPadrao"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        #endregion

        #region IdiomaPadrao
        /// <summary>
        ///     Obter o idioma padrao
        /// </summary>
        /// <user>mazevedo</user>
        public static string IdiomaPadrao
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.IdiomaPadrao"] != null)
                {
                    return ConfigurationManager.AppSettings["VM2.Framework.IdiomaPadrao"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        #endregion

        #region DiretorioXMLIdioma

        /// <summary>
        ///     Página para redirecionamento quando acesso é negado
        /// </summary>
        /// <user>mazevedo</user>
        public static string DiretorioXMLIdioma
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.DiretorioXMLIdioma"] != null)
                {
                    return ConfigurationManager.AppSettings["VM2.Framework.DiretorioXMLIdioma"];
                }
                else
                {
                    return "";
                }
            }
        }

        #endregion

        #region Email

        #region Usuário

        /// <summary>
        ///     Usuario para envio de Email
        /// </summary>
        /// <user>mazevedo</user>
        public static string UsuarioEmail
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.Email.Usuario"] != null)
                {
                    return ConfigurationManager.AppSettings["VM2.Framework.Email.Usuario"].ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region Senha

        /// <summary>
        ///     Senha para envio de Email
        /// </summary>
        /// <user>mazevedo</user>
        public static string SenhaEmail
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.Email.Senha"] != null)
                {
                    return ConfigurationManager.AppSettings["VM2.Framework.Email.Senha"].ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region Servidor

        /// <summary>
        ///     Servidor para envio de Email
        /// </summary>
        /// <user>mazevedo</user>
        public static string ServidorEmail
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.Email.Servidor"] != null)
                {
                    return ConfigurationManager.AppSettings["VM2.Framework.Email.Servidor"].ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region Porta

        /// <summary>
        ///     Porta para envio de Email
        /// </summary>
        /// <user>mazevedo</user>
        public static int PortaEmail
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.Email.Porta"] != null)
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Framework.Email.Porta"]);
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion

        #endregion

        #region VerificarBancoDados
        /// <summary>
        /// Obter a configuração referente a verificação de conectividade
        /// </summary>
        /// <user>mazevedo</user>
        public static bool IsVerificarBancoDados
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.VerificarBancoDados"] != null)
                {
                    return Convert.ToBoolean(ConfigurationManager.AppSettings["VM2.Framework.VerificarBancoDados"]);
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region Manutencao
        /// <summary>
        /// Obter a configuração referente sistema em manutenção
        /// </summary>
        /// <user>mazevedo</user>
        public static bool IsManutencao
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.EmManutencao"] != null)
                {
                    return Convert.ToBoolean(ConfigurationManager.AppSettings["VM2.Framework.EmManutencao"]);
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region Forcar Resolucao Estilo
        /// <summary>
        /// Obter o parametro para força resolução de estilo
        /// </summary>
        /// <user>mazevedo</user>
        public static bool IsForcarResolucaoEstilo
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.ForcarResolucaoEstilo"] != null)
                {
                    return Convert.ToBoolean(ConfigurationManager.AppSettings["VM2.Framework.ForcarResolucaoEstilo"]);
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region Listar

        /// <summary> 
        /// Listar Configuracao
        /// </summary> 
        /// <param name="pobjMLConfiguracao">Parametros para filtro</param>
        /// <returns>Lista de Configuracao</returns> 
        /// <user>GeradorVm2</user>
        public List<MLConfiguracao> Listar(MLConfiguracao pobjMLConfiguracao)
        {

            Connector conConfiguracao = new Connector();
            IDLConfiguracao objDLConfiguracao = null;
            List<MLConfiguracao> lstRetorno = null;

            try
            {
                objDLConfiguracao = conConfiguracao.ObterDLConfiguracao();
                lstRetorno = objDLConfiguracao.Listar(pobjMLConfiguracao);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conConfiguracao.Finalizar();
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Obtem um Configuracao
        /// </summary> 
        /// <param name="pstrChave">Chave</param>
        /// <returns>Configuracao</returns> 
        /// <user>GeradorVm2</user>
        public MLConfiguracao Obter(string pstrChave)
        {

            Connector conConfiguracao = new Connector();
            IDLConfiguracao objDLConfiguracao = null;
            MLConfiguracao objRetorno = null;

            try
            {
                objDLConfiguracao = conConfiguracao.ObterDLConfiguracao();
                objRetorno = objDLConfiguracao.Obter(pstrChave);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conConfiguracao.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Alterar um Configuracao
        /// </summary> 
        /// <param name="pobjMLConfiguracao">Configuracao com as alterações</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLConfiguracao pobjMLConfiguracao)
        {

            Connector conConfiguracao = new Connector();
            IDLConfiguracao objDLConfiguracao = null;
            bool objRetorno = false;

            try
            {
                objDLConfiguracao = conConfiguracao.ObterDLConfiguracao();
                objRetorno = objDLConfiguracao.Alterar(pobjMLConfiguracao);
            }
            catch (Exception ex)
            {
                BLFuncoes.GravaLog("Classe: " + ex.TargetSite.ReflectedType.Name.ToString() + " Método: " + System.Reflection.MethodInfo.GetCurrentMethod().Name.ToString(), ex);
                throw;
            }
            finally
            {
                conConfiguracao.Finalizar();
            }
            return objRetorno;
        }

        #endregion

        #region Popular Configuracoes
        /// <summary>
        /// Popula as configurações do sistema
        /// </summary>
        /// <user>tprohaska</user>
        public void PopularConfiguracoes()
        {
            Dictionary<string, string> dicConfiguracao = new Dictionary<string, string>();
            BLConfiguracao objBLConfiguracao = new BLConfiguracao();
            List<MLConfiguracao> lstConfiguracao = null;
            try
            {

                lstConfiguracao = objBLConfiguracao.Listar(new MLConfiguracao());

                foreach (MLConfiguracao item in lstConfiguracao)
                {
                    dicConfiguracao.Add(item.Chave, item.Valor);
                }

                HttpContext.Current.Application["ctxConfiguracao"] = dicConfiguracao;

            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Noticia

        #region Caminhi Imagens
        #region Porta

        /// <summary>
        ///     Porta para envio de Email
        /// </summary>
        /// <user>mazevedo</user>
        public static string CaminhoImagemNoticia
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.Noticia.CaminhoImagem"] != null)
                {
                    return ConfigurationManager.AppSettings["VM2.Framework.Noticia.CaminhoImagem"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public static string CaminhoArquivos
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.Arquivos.CaminhoArquivo"] != null)
                {
                    return ConfigurationManager.AppSettings["VM2.Framework.Arquivos.CaminhoArquivo"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }





        #endregion
        #endregion

        #endregion

        #region Autenticação Utilizando Session
        /// <summary>
        /// Verifica se usa Session (True) ou Forms (False) para autenticação do usuario
        /// </summary>
        /// <user>tprohaska</user>
        public static bool IsAutenticacaoUsandoSession
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.AutenticacaoEmSession"] != null)
                {
                    return Convert.ToBoolean(ConfigurationManager.AppSettings["VM2.Framework.AutenticacaoEmSession"]);
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region Log de Acesso
        /// <summary>
        /// Verifica se realiza ou não o log de acesso
        /// </summary>
        /// <user>tprohaska</user>
        public static bool IsLogarAcessosUsuario
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.LogAcesso"] != null)
                {
                    return Convert.ToBoolean(ConfigurationManager.AppSettings["VM2.Framework.LogAcesso"]);
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region IsCompressViewState

        /// <summary>
        ///     Define se o View State será comprimido
        /// </summary>
        /// <user>mazevedo</user>
        public static bool IsCompressViewState
        {
            get
            {
                if (ConfigurationManager.AppSettings["VM2.Framework.CompressViewState"] != null)
                {
                    return Convert.ToBoolean(ConfigurationManager.AppSettings["VM2.Framework.CompressViewState"]);
                }
                else
                {
                    return true;
                }
            }
        }

        #endregion

        #region TempoExpiracaoCacheListar
        /// <summary>
        /// Obtem o tempo de Expiração do Cache
        /// </summary>
        /// <returns> Minutos de Expiração do Cache</returns>
        /// <user>fzuconi</user>
        public static double TempoExpiracaoCacheListar(string strCache)
        {

            if (ConfigurationManager.AppSettings["VM2.Bellfone.MinutosExpiracao." + strCache] != null)
                return Convert.ToDouble(ConfigurationManager.AppSettings["VM2.Bellfone.MinutosExpiracao." + strCache]);

            return 10;

        }

        #endregion

    }
}
