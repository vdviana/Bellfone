using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BellFone.B2B.BusinessLayer.Configuration
{
    public class UTIntegracao
    {
        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Quantidade de Threads que vão ser executadas
        /// </summary>
        /// <returns>Quantidade de Threads que vão ser executadas</returns>
        /// <history>
        /// [efranca] 28/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static int ObterQuantidadeThreadsExecutadas()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.Vitrine.QuantidadeThreadsExecutadas"] != null)
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Bellfone.Vitrine.QuantidadeThreadsExecutadas"]);
            }

            return 1;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Quantidade de Intervalo Processamento Envio
        /// </summary>
        /// <returns>Quantidade de Threads que vão ser executadas</returns>
        /// <history>
        /// [efranca] 28/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static int ObterIntervaloProcessamentoEnvio()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.Integracao.IdIntervaloEnvio"] != null)
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Bellfone.Integracao.IdIntervaloEnvio"]);
            }

            return 1;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Quantidade de Intervalo Processamento Recebimento
        /// </summary>
        /// <returns>Quantidade de Threads que vão ser executadas</returns>
        /// <history>
        /// [efranca] 28/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static int ObterIntervaloProcessamentoRecebimento()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.Integracao.IdIntervaloRecebimento"] != null)
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Bellfone.Integracao.IdIntervaloRecebimento"]);
            }

            return 1;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Quantidade de Threads que vão ser executadas
        /// </summary>
        /// <returns>Quantidade de Threads que vão ser executadas</returns>
        /// <history>
        /// [efranca] 28/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterCaminhoRecebimento()
        {
            if (ConfigurationManager.AppSettings["VM2.Integracao.CaminhoRecebimento"] != null)
            {
                return Convert.ToString(ConfigurationManager.AppSettings["VM2.Integracao.CaminhoRecebimento"]);
            }

            return "";
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Quantidade de Threads que vão ser executadas
        /// </summary>
        /// <returns>Quantidade de Threads que vão ser executadas</returns>
        /// <history>
        /// [efranca] 28/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterCaminhoEnvio()
        {
            if (ConfigurationManager.AppSettings["VM2.Integracao.CaminhoEnvio"] != null)
            {
                return Convert.ToString(ConfigurationManager.AppSettings["VM2.Integracao.CaminhoEnvio"]);
            }

            return "";
        }
    }
}
