using System;
using System.Data;

namespace VM2.Framework.Model.Utilitarios
{
    /// <summary> 
    /// Model da Entidade Configuracao 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class MLConfiguracao
    {
        #region Propriedades

        /// <summary> 
        /// Recebe o valor de CFG_C_CHAVE 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Chave { get; set; }

        /// <summary> 
        /// Recebe o valor de CFG_C_VALOR 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Valor { get; set; }

        #endregion

        #region Conversor DataReader

        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["CFG_C_CHAVE"] != DBNull.Value)
                Chave = Convert.ToString(pobjIDataReader["CFG_C_CHAVE"]);

            if (pobjIDataReader["CFG_C_VALOR"] != DBNull.Value)
                Valor = Convert.ToString(pobjIDataReader["CFG_C_VALOR"]);
        }

        #endregion
    }
}
