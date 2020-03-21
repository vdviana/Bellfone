using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BellFone.B2B.BusinessLayer.Configuration
{
    public class UTMiniBannerImagem
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
        public static string ObterCaminhoMiniBannerImagem()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.MiniBanner.CaminhoImagem"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.MiniBanner.CaminhoImagem"];
            }

            return String.Empty;
        }
    }
}
