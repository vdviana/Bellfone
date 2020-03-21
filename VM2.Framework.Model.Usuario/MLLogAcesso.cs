using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace VM2.Framework.Model.Usuario
{
    /// <summary> 
    /// Model da Entidade LogAcesso 
    /// </summary> 
    /// <user>GeradorVm2 [2.2.0.0]</user> 
    public class MLLogAcesso
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de LAC_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.2.0.0]]</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de LAC_D_DATA 
        /// </summary> 
        /// <user>GeradorVm2 [[2.2.0.0]]</user>
        public DateTime? Data { get; set; }
        
        /// <summary> 
        /// Recebe o valor de LAC_USU_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.2.0.0]]</user>
        public decimal? CodigoUsuario { get; set; }

        /// <summary> 
        /// Recebe o valor de LAC_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.2.0.0]]</user>
        public string Descricao { get; set; }

        /// <summary> 
        /// Recebe o valor de USU_C_NOME
        /// </summary> 
        /// <user>GeradorVm2 [[2.2.0.0]]</user>
        public string LoginUsuario { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["LAC_N_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = Convert.ToDecimal(pobjIDataReader["LAC_N_CODIGO"]);
            }
            if (pobjIDataReader["LAC_D_DATA"] != System.DBNull.Value)
            {
                this.Data = Convert.ToDateTime(pobjIDataReader["LAC_D_DATA"]);
            }
            if (pobjIDataReader["LAC_USU_N_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoUsuario = Convert.ToDecimal(pobjIDataReader["LAC_USU_N_CODIGO"]);
            }
            if (pobjIDataReader["LAC_C_DESCRICAO"] != System.DBNull.Value)
            {
                this.Descricao = pobjIDataReader["LAC_C_DESCRICAO"].ToString();
            }
            if (pobjIDataReader["USU_C_LOGIN"] != System.DBNull.Value)
            {
                this.LoginUsuario = pobjIDataReader["USU_C_LOGIN"].ToString();
            }
            
        }

        #endregion
    }
}
