using System;
using System.Data;

namespace VM2.Framework.Model.Utilitarios
{
    /// <summary>
    ///     Classe de tranporte para log
    /// </summary>
    /// <user>mazevedo</user>
    public class MLLog
    {
        #region Propriedades

        /// <summary>
        ///     Codigo
        /// </summary>
        public decimal Codigo { get; set; }

        /// <summary>
        ///     Metodo
        /// </summary>
        /// <user>mazevedo</user>
        public string Metodo { get; set; }

        /// <summary>
        ///     Data
        /// </summary>
        /// <user>mazevedo</user>
        public DateTime Data { get; set; }

        /// <summary>
        ///     Stack Trace
        /// </summary>
        /// <user>mazevedo</user>
        public string StackTrace { get; set; }

        #endregion

        #region Collections DataReader

        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["LOG_N_CODIGO"] != DBNull.Value)
                Codigo = Convert.ToDecimal(pobjIDataReader["LOG_N_CODIGO"]);

            if (pobjIDataReader["LOG_C_ERRO"] != DBNull.Value)
                Metodo = Convert.ToString(pobjIDataReader["LOG_C_ERRO"]);

            if (pobjIDataReader["LOG_D_DATA"] != DBNull.Value)
                Data = Convert.ToDateTime(pobjIDataReader["LOG_D_DATA"]);

            if (pobjIDataReader["LOG_C_STACK"] != DBNull.Value)
                StackTrace = Convert.ToString(pobjIDataReader["LOG_C_STACK"]);
        }

        #endregion
    }
}


