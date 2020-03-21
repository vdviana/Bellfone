using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BellFone.B2B.BusinessLayer.Configuration
{
    public class UTVitrine
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
        public static string ObterQuantidadeProdutosVitrine()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.Vitrine.QuantidadeProdutos"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.Vitrine.QuantidadeProdutos"];
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
            if (ConfigurationManager.AppSettings["VM2.Bellfone.Vitrine.QuantidadeAbasPaginacao"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.Vitrine.QuantidadeAbasPaginacao"];
            }

            return String.Empty;
        }
  
    }
}
