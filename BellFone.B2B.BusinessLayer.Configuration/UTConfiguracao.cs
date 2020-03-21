using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BellFone.B2B.BusinessLayer.Configuration
{
    public class UTConfiguracao
    {
        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter o Codigo do Serviço de Envio na Integração
        /// </summary>
        /// <returns>Codigo do Serviço de Envio na Integração</returns>
        /// <history>
        /// [efranca] 07/04/2010 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterIdConfiguracaoServicoEnvio()
        {
            if (ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoServicoEnvio"] != null)
            {
                return ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoServicoEnvio"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter o Codigo do Serviço de Recebimento na Integração
        /// </summary>
        /// <returns>Codigo do Serviço de Recebimento na Integração</returns>
        /// <history>
        /// [efranca] 07/04/2010 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterIdConfiguracaoServicoRecebimento()
        {
            if (ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoServicoRecebimento"] != null)
            {
                return ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoServicoRecebimento"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter o Codigo da Categoria dos Treinamentos
        /// </summary>
        /// <returns>Codigo da Categoria dos Treinamentos</returns>
        /// <history>
        /// [efranca] 07/04/2010 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterIdConfiguracaoTreinamento()
        {
            if (ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoTreinamento"] != null)
            {
                return ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoTreinamento"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter o Codigo da Situação de Orçamento
        /// </summary>
        /// <returns>Codigo da Situação de Orçamento</returns>
        /// <history>
        /// [efranca] 09/04/2010 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterIdConfiguracaoSituacaoOrcado()
        {
            if (ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoOrcado"] != null)
            {
                return ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoOrcado"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter o Codigo da Situação de Pedido
        /// </summary>
        /// <returns>Codigo da Situação de Pedido</returns>
        /// <history>
        /// [efranca] 09/04/2010 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterIdConfiguracaoSituacaoPedido()
        {
            if (ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoPedido"] != null)
            {
                return ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoPedido"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter o Codigo da Situação de Faturado
        /// </summary>
        /// <returns>Codigo da Situação de Faturado</returns>
        /// <history>
        /// [efranca] 09/04/2010 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterIdConfiguracaoSituacaoFaturado()
        {
            if (ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoFaturado"] != null)
            {
                return ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoFaturado"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter o Codigo da Situação de Cancelado
        /// </summary>
        /// <returns>Codigo da Situação de Cancelado</returns>
        /// <history>
        /// [efranca] 09/04/2010 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterIdConfiguracaoSituacaoCancelado()
        {
            if (ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoCancelado"] != null)
            {
                return ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoCancelado"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter o Codigo da Situação de Processado
        /// </summary>
        /// <returns>Codigo da Situação de Processado</returns>
        /// <history>
        /// [efranca] 09/04/2010 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterIdConfiguracaoSituacaoProcessado()
        {
            if (ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoProcessado"] != null)
            {
                return ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoProcessado"];
            }

            return String.Empty;
        }
    }
}
