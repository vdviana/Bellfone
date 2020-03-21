using System;
using System.Data;

namespace VM2.Framework.Model.Idioma
{
    /// <summary> 
    /// Model da Entidade Idioma 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class MLIdioma
    {
        #region Propriedades

        /// <summary> 
        /// Recebe o valor de IDI_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de IDI_C_NOME 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Nome { get; set; }

        /// <summary> 
        /// Recebe o valor de IDI_C_SIGLA 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Sigla { get; set; }

        /// <summary> 
        /// Recebe o valor de IDI_B_ATIVO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public bool? IsAtivo { get; set; }

        #endregion

        #region Conversor DataReader

        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["IDI_N_CODIGO"] != DBNull.Value)
                Codigo = Convert.ToDecimal(pobjIDataReader["IDI_N_CODIGO"]);

            if (pobjIDataReader["IDI_C_NOME"] != DBNull.Value)
                Nome = Convert.ToString(pobjIDataReader["IDI_C_NOME"]);

            if (pobjIDataReader["IDI_C_SIGLA"] != DBNull.Value)
                Sigla = Convert.ToString(pobjIDataReader["IDI_C_SIGLA"]);

            if (pobjIDataReader["IDI_B_ATIVO"] != DBNull.Value)
                IsAtivo = Convert.ToBoolean(pobjIDataReader["IDI_B_ATIVO"]);
        }

        #endregion
    }
}


