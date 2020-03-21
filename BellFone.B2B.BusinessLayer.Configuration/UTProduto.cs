using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BellFone.B2B.BusinessLayer.Configuration
{
    public class UTProduto
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
        public static string ObterCaminhoProdutoImagemPadrao()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.Produto.ImagemPadrao"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.Produto.ImagemPadrao"];
            }

            return String.Empty;
        }

        /// ----------------------------------------------------------------------------- 
        /// <summary>
        /// Obter Caminho para imagem
        /// </summary>
        /// <returns>Caminho da imagem</returns>
        /// <history>
        /// [lmascarenhas] 29/10/2009 Created
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public static string ObterCaminhoProdutoImagem()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.Produto.Imagem"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.Produto.Imagem"];
            }

            return String.Empty;
        }
    }
}
