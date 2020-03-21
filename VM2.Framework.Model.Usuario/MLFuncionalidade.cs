using System;
using System.Data;

namespace VM2.Framework.Model.Usuario
{
    /// <summary> 
    /// Model da Entidade Funcionalidade 
    /// </summary> 
    /// <user>mazevedo</user> 
    public class MLFuncionalidade
    {
        #region Propriedades

        /// <summary> 
        /// Código da Funcionalidade
        /// </summary> 
        /// <user>mazevedo</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Nome da Funcionalidade
        /// </summary> 
        /// <user>mazevedo</user>
        public string Nome { get; set; }

        /// <summary> 
        /// Endereço Web da Funcionalidade
        /// </summary> 
        /// <user>mazevedo</user>
        public string CaminhoPagina { get; set; }

        /// <summary> 
        /// Recebe o valor de FUN_B_STATUS 
        /// </summary> 
        /// <user>mazevedo</user>
        public bool? IsAtivo { get; set; }

        /// <summary> 
        /// Recebe o valor de FUN_B_FRAMEWORK
        /// Define se é uma funcionalidade do Framework ou não
        /// </summary> 
        /// <user>tprohaska</user>
        public bool? IsFramework { get; set; }

        #endregion

        #region Conversor DataReader

        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["FUN_N_CODIGO"] != DBNull.Value)
                Codigo = Convert.ToDecimal(pobjIDataReader["FUN_N_CODIGO"]);

            if (pobjIDataReader["FUN_C_NOME"] != DBNull.Value)
                Nome = Convert.ToString(pobjIDataReader["FUN_C_NOME"]);

            if (pobjIDataReader["FUN_C_CAMINHO_PAGINA"] != DBNull.Value)
                CaminhoPagina = Convert.ToString(pobjIDataReader["FUN_C_CAMINHO_PAGINA"]);

            if (pobjIDataReader["FUN_B_STATUS"] != DBNull.Value)
                IsAtivo = Convert.ToBoolean(pobjIDataReader["FUN_B_STATUS"]);

            if (pobjIDataReader["FUN_B_FRAMEWORK"] != DBNull.Value)
                IsFramework = Convert.ToBoolean(pobjIDataReader["FUN_B_FRAMEWORK"]);
        }

        #endregion
    }
}


