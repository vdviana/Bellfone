using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BellFone.B2B.BusinessLayer.Configuration
{
    /// -----------------------------------------------------------------------------
    /// Project : BellFone.B2B.BusinessLayer.Configuration
    /// Class : UTProdutoImagem
    /// ----------------------------------------------------------------------------- 
    /// <summary> 
    /// Classe com settings do Produto Imagem
    /// </summary> 
    /// <history> 
    /// [lmascarenhas] 26/10/2009 Created 
    /// </history> 
    /// ----------------------------------------------------------------------------- 
    public class UTProdutoImagem
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
        public static string ObterCaminhoImagemDefault()
        {
            if (ConfigurationManager.AppSettings["VM2.Bellfone.Produto.ImagemPadrao"] != null)
            {
                return ConfigurationManager.AppSettings["VM2.Bellfone.Produto.ImagemPadrao"];
            }

            return String.Empty;
        }
    }
}
