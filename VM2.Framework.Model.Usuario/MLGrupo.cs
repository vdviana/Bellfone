using System;
using System.Data;

namespace VM2.Framework.Model.Usuario
{
    /// <summary>
    ///     Classe de transporte para Grupo
    /// </summary>
    /// <user>mazevedo</user>
    [Serializable]
    public class MLGrupo
    {

        #region Propriedades

        /// <summary>
        ///     Codigo
        /// </summary>
        /// <user>mazevedo</user>
        public decimal? Codigo { get; set; }

        /// <summary>
        ///     Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        ///     Status
        /// </summary>
        /// <user>mazevedo</user>
        public bool? IsAtivo { get; set; }

        #endregion

        #region Collections DataReader

        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["GRP_N_CODIGO"] != DBNull.Value)
                Codigo = Convert.ToDecimal(pobjIDataReader["GRP_N_CODIGO"]);

            if (pobjIDataReader["GRP_C_NOME"] != DBNull.Value)
                Nome = Convert.ToString(pobjIDataReader["GRP_C_NOME"]);
            
            if (pobjIDataReader["GRP_B_STATUS"] != DBNull.Value)
                IsAtivo = Convert.ToBoolean(pobjIDataReader["GRP_B_STATUS"]);
        }

        #endregion
    }
}


