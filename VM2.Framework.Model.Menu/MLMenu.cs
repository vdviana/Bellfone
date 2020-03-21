using System;
using System.Data;

namespace VM2.Framework.Model.Menu
{
    /// <summary> 
    /// Model da Entidade Menu 
    /// </summary> 
    /// <user>mazevedo</user> 
    public class MLMenu
    {
        #region Propriedades

        /// <summary> 
        /// Código do Menu
        /// </summary> 
        /// <user>mazevedo</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Código do Idioma
        /// </summary> 
        /// <user>mazevedo</user>
        public decimal? CodigoIdioma { get; set; }

        /// <summary> 
        /// Nome do Menu
        /// </summary> 
        /// <user>mazevedo</user>
        public string Nome { get; set; }

        /// <summary> 
        /// Indicador de Status do Menu
        /// </summary> 
        /// <user>mazevedo</user>
        public bool? IsAtivo { get; set; }

        /// <summary> 
        /// Nome do Skin
        /// </summary> 
        /// <user>mazevedo</user>
        public string Skin { get; set; }

        #endregion

        #region Conversor DataReader

        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["MEN_N_CODIGO"] != DBNull.Value)
                Codigo = Convert.ToDecimal(pobjIDataReader["MEN_N_CODIGO"]);

            if (pobjIDataReader["MEN_C_NOME"] != DBNull.Value)
                Nome = Convert.ToString(pobjIDataReader["MEN_C_NOME"]);

            if (pobjIDataReader["MEN_B_STATUS"] != DBNull.Value)
                IsAtivo = Convert.ToBoolean(pobjIDataReader["MEN_B_STATUS"]);

            if (pobjIDataReader["MEN_C_SKIN"] != DBNull.Value)
                Skin = Convert.ToString(pobjIDataReader["MEN_C_SKIN"]);

            if (pobjIDataReader["MEN_IDI_N_CODIGO"] != DBNull.Value)
                CodigoIdioma = Convert.ToDecimal(pobjIDataReader["MEN_IDI_N_CODIGO"]);
        }

        #endregion
    }
}


