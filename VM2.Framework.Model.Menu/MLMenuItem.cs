using System;
using System.Data;

namespace VM2.Framework.Model.Menu
{
    /// <summary> 
    /// Model da Entidade MenuItem 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    [Serializable]
    public class MLMenuItem
    {
        #region Propriedades

        /// <summary> 
        /// Código do Item do Menu
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Código do Menu
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? CodigoMenu { get; set; }

        /// <summary> 
        /// Nome do Item do Menu
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Nome { get; set; }

        /// <summary> 
        /// Recebe o valor de MNI_N_CODIGO_PAI 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? CodigoPai { get; set; }

        /// <summary> 
        /// Recebe o valor de MNI_FUN_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? CodigoFuncionalidade { get; set; }

        /// <summary> 
        /// Recebe o valor de MNI_B_STATUS 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public bool? IsAtivo { get; set; }

        /// <summary>
        /// Caminho da pagina da funcionalidade
        /// </summary>
        /// <user>mazevedo</user>
        public string CaminhoPagina { get; set; }

        /// <summary> 
        /// Recebe o valor de MNI_N_ORDEM 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public int? Ordem { get; set; }

        /// <summary> 
        /// Código do Idioma
        /// </summary> 
        /// <user>mazevedo</user>
        public decimal? CodigoMenuIdioma { get; set; }

        #endregion

        #region Conversor DataReader

        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["MNI_N_CODIGO"] != DBNull.Value)
                Codigo = Convert.ToDecimal(pobjIDataReader["MNI_N_CODIGO"]);

            if (pobjIDataReader["MNI_MEN_N_CODIGO"] != DBNull.Value)
                CodigoMenu = Convert.ToDecimal(pobjIDataReader["MNI_MEN_N_CODIGO"]);

            if (pobjIDataReader["MNI_MEN_IDI_N_CODIGO"] != DBNull.Value)
                CodigoMenuIdioma = Convert.ToDecimal(pobjIDataReader["MNI_MEN_IDI_N_CODIGO"]);

            if (pobjIDataReader["MNI_C_NOME"] != DBNull.Value)
                Nome = Convert.ToString(pobjIDataReader["MNI_C_NOME"]);

            if (pobjIDataReader["MNI_N_CODIGO_PAI"] != DBNull.Value)
                CodigoPai = Convert.ToDecimal(pobjIDataReader["MNI_N_CODIGO_PAI"]);

            if (pobjIDataReader["MNI_FUN_N_CODIGO"] != DBNull.Value)
                CodigoFuncionalidade = Convert.ToDecimal(pobjIDataReader["MNI_FUN_N_CODIGO"]);

            if (pobjIDataReader["MNI_B_STATUS"] != DBNull.Value)
                IsAtivo = Convert.ToBoolean(pobjIDataReader["MNI_B_STATUS"]);

            if (pobjIDataReader["MNI_N_ORDEM"] != DBNull.Value)
                Ordem = Convert.ToInt32(pobjIDataReader["MNI_N_ORDEM"]);

            if (pobjIDataReader["MNI_C_CAMINHO_PAGINA"] != DBNull.Value)
                CaminhoPagina = Convert.ToString(pobjIDataReader["MNI_C_CAMINHO_PAGINA"]);
        }

        #endregion
    }
}


