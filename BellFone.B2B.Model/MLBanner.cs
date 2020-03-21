using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade Banner 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class MLBanner
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de BAN_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de BAN_C_TITULO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Titulo { get; set; }

        /// <summary> 
        /// Recebe o valor de BAN_C_EXT 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Ext { get; set; }

        /// <summary> 
        /// Recebe o valor de BAN_C_LINK 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Link { get; set; }

        /// <summary> 
        /// Recebe o valor de BAN_B_STATUS 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public bool? IsStatus { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["BAN_N_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = Convert.ToDecimal(pobjIDataReader["BAN_N_CODIGO"]);
            }
            if (pobjIDataReader["BAN_C_TITULO"] != System.DBNull.Value)
            {
                this.Titulo = pobjIDataReader["BAN_C_TITULO"].ToString();
            }
            if (pobjIDataReader["BAN_C_EXT"] != System.DBNull.Value)
            {
                this.Ext = pobjIDataReader["BAN_C_EXT"].ToString();
            }
            if (pobjIDataReader["BAN_C_LINK"] != System.DBNull.Value)
            {
                this.Link = pobjIDataReader["BAN_C_LINK"].ToString();
            }
            if (pobjIDataReader["BAN_B_STATUS"] != System.DBNull.Value)
            {
                this.IsStatus = Convert.ToBoolean(pobjIDataReader["BAN_B_STATUS"]);
            }
        }

        #endregion
    }
}


