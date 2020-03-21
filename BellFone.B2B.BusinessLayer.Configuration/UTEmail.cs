using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BellFone.B2B.BusinessLayer.Configuration
{
    /// -----------------------------------------------------------------------------
    /// Project : BellFone.B2B.BusinessLayer.Configuration
    /// Class : UTEmail
    /// ----------------------------------------------------------------------------- 
    /// <summary> 
    /// Classe com settings do Email
    /// </summary> 
    /// <history> 
    /// [efranca] 27/10/2009 Created 
    /// </history> 
    /// -----------------------------------------------------------------------------
    public class UTEmail
    {
        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Email do Usuario default
        /// </summary>
        /// <returns>Email do Usuario default</returns>
        /// <history>
        /// [efranca] 27/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterEmailAdmin()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.EmailAdministradores"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.EmailAdministradores"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Modelo de email do Fale Conosco default
        /// </summary>
        /// <returns>Modelo de email do Fale Conosco default</returns>
        /// <history>
        /// [efranca] 27/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterModeloFaleConosco()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.EmailModeloFaleConosco"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.EmailModeloFaleConosco"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Modelo de email do Cadastro
        /// </summary>
        /// <returns>Modelo de email do Cadastro</returns>
        /// <history>
        /// [efranca] 27/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterModeloCadastro()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.EmailModeloCadastro"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.EmailModeloCadastro"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Modelo de email do Novo Orçamento
        /// </summary>
        /// <returns>Modelo de email do Cadastro</returns>
        /// <history>
        /// [efranca] 27/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterModeloNovoOrcamento()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.EmailModeloNovoOrcamento"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.EmailModeloNovoOrcamento"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Modelo de email do Esqueci minha Senha
        /// </summary>
        /// <returns>Modelo de email do Esqueci minha Senha</returns>
        /// <history>
        /// [efranca] 27/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterModeloEsqueciSenha()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.EmailModeloEsqueciSenha"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.EmailModeloEsqueciSenha"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Modelo de email do Cadastro
        /// </summary>
        /// <returns>Modelo de email do Cadastro</returns>
        /// <history>
        /// [efranca] 27/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterModeloEmailCliente()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.EmailModeloEmailCliente"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.EmailModeloEmailCliente"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Titulo do email do Cadastro para o Clinte
        /// </summary>
        /// <returns>Modelo de email do Cadastro</returns>
        /// <history>
        /// [efranca] 27/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterTituloCadastroCliente()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.EmailTituloCadastroClinte"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.EmailTituloCadastroClinte"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Titulo do email do Cadastro para o Clinte
        /// </summary>
        /// <returns>Modelo de email do Cadastro</returns>
        /// <history>
        /// [efranca] 27/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterMensagemCadastroCliente()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.EmailMensagemCadastroCliente"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.EmailMensagemCadastroCliente"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Titulo do email do Cadastro para o Clinte
        /// </summary>
        /// <returns>Modelo de email do Cadastro</returns>
        /// <history>
        /// [efranca] 27/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterTituloTreinamentoCliente()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.EmailTituloTreinamentoClinte"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.EmailTituloTreinamentoClinte"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Titulo do email do Cadastro para o Clinte
        /// </summary>
        /// <returns>Modelo de email do Cadastro</returns>
        /// <history>
        /// [efranca] 27/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterMensagemTreinamentoCliente()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.EmailMensagemTreinamentoCliente"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.EmailMensagemTreinamentoCliente"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Titulo do email do Cadastro para o Clinte
        /// </summary>
        /// <returns>Modelo de email do Cadastro</returns>
        /// <history>
        /// [efranca] 27/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterTituloFaleConoscoCliente()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.EmailTituloFaleConoscoClinte"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.EmailTituloFaleConoscoClinte"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Titulo do email do Cadastro para o Clinte
        /// </summary>
        /// <returns>Modelo de email do Cadastro</returns>
        /// <history>
        /// [efranca] 27/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterMensagemFaleConoscoCliente()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.EmailMensagemFaleConoscoCliente"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.EmailMensagemFaleConoscoCliente"];
            }

            return String.Empty;
        }
    }
}
