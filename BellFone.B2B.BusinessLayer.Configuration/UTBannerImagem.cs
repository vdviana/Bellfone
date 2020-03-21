using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BellFone.B2B.BusinessLayer.Configuration
{
    public class UTBannerImagem
    {
        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Caminho para imagem default
        /// </summary>
        /// <returns>Caminho da imagem default</returns>
        /// <history>
        /// [lmascarenhas] 29/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterCaminhoBannerImagem()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.Banner.CaminhoImagem"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.Banner.CaminhoImagem"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Caminho para o XML
        /// </summary>
        /// <returns>Caminho do XML</returns>
        /// <history>
        /// [lmascarenhas] 29/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterCaminhoBannerXml()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.Banner.CaminhoXML"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.Banner.CaminhoXML"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Caminho para Swf
        /// </summary>
        /// <returns>Caminho da wwf</returns>
        /// <history>
        /// [lmascarenhas] 29/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterCaminhoBannerSwf()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.Banner.CaminhoSWF"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.Banner.CaminhoSWF"];
            }

            return String.Empty;
        }
    }
}
