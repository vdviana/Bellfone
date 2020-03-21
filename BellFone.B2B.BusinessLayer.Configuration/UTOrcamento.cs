using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BellFone.B2B.BusinessLayer.Configuration
{
    public class UTOrcamento
    {
        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Quantidade de Produtos à serem visualizados na Vitrine
        /// </summary>
        /// <returns>Quantidade de Produtos à serem visualizados na Vitrine</returns>
        /// <history>
        /// [efranca] 28/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterQuantidadeOrcamento()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.Orcamento.QuantidadeOrcamento"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.Orcamento.QuantidadeOrcamento"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Quantidade de "Abas" à serem visualizados na paginação da Vitrine
        /// </summary>
        /// <returns>Quantidade de Produtos à serem visualizados na Vitrine</returns>
        /// <history>
        /// [efranca] 28/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterQuantidadeAbasPaginacao()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.Orcamento.QuantidadeAbasPaginacao"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.Orcamento.QuantidadeAbasPaginacao"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Quantidade de "Abas" à serem visualizados na paginação da Vitrine
        /// </summary>
        /// <returns>Quantidade de Produtos à serem visualizados na Vitrine</returns>
        /// <history>
        /// [efranca] 28/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterSituacaOrcado()
        {
            if (ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoOrcado"] != null)
            {
                return ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoOrcado"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Quantidade de "Abas" à serem visualizados na paginação da Vitrine
        /// </summary>
        /// <returns>Quantidade de Produtos à serem visualizados na Vitrine</returns>
        /// <history>
        /// [efranca] 28/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterSituacaPedido()
        {
            if (ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoPedido"] != null)
            {
                return ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoPedido"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Quantidade de "Abas" à serem visualizados na paginação da Vitrine
        /// </summary>
        /// <returns>Quantidade de Produtos à serem visualizados na Vitrine</returns>
        /// <history>
        /// [efranca] 28/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterSituacaFaturado()
        {
            if (ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoFaturado"] != null)
            {
                return ConfigurationManager.AppSettings["Ecom1.Configuration.IdConfiguracaoSituacaoFaturado"];
            }

            return String.Empty;
        }
    }
}
