using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade Classificacao 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.1.1]</user> 
    public class MLClassificacao
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de CLC_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de CLC_C_CLASSIFICACAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public string Classificacao { get; set; }

        /// <summary> 
        /// Recebe o valor de CLC_B_PRODUTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public bool? IsProduto { get; set; }

        /// <summary> 
        /// Recebe o valor de CLC_B_REVENDEDOR 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public bool? IsRevendedor { get; set; }

        /// <summary> 
        /// Recebe o valor de CLC_N_DESCONTO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.1.1]]</user>
        public decimal? Desconto { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["CLC_N_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = Convert.ToDecimal(pobjIDataReader["CLC_N_CODIGO"]);
            }
            if (pobjIDataReader["CLC_C_CLASSIFICACAO"] != System.DBNull.Value)
            {
                this.Classificacao = pobjIDataReader["CLC_C_CLASSIFICACAO"].ToString();
            }
            if (pobjIDataReader["CLC_B_PRODUTO"] != System.DBNull.Value)
            {
                this.IsProduto = Convert.ToBoolean(pobjIDataReader["CLC_B_PRODUTO"]);
            }
            if (pobjIDataReader["CLC_B_REVENDEDOR"] != System.DBNull.Value)
            {
                this.IsRevendedor = Convert.ToBoolean(pobjIDataReader["CLC_B_REVENDEDOR"]);
            }
            if (pobjIDataReader["CLC_N_DESCONTO"] != System.DBNull.Value)
            {
                this.Desconto = Convert.ToDecimal(pobjIDataReader["CLC_N_DESCONTO"]);
            }
        }

        #endregion
    }
}


