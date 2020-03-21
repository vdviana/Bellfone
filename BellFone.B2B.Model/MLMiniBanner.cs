using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade MiniBanner 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class MLMiniBanner
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de MBN_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de MBN_C_TITULO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Titulo { get; set; }

        /// <summary> 
        /// Recebe o valor de MBN_C_LINK 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Link { get; set; }

        /// <summary> 
        /// Recebe o valor de MBN_N_LARGURA 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? Largura { get; set; }

        /// <summary> 
        /// Recebe o valor de MBN_N_ALTURA 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public decimal? Altura { get; set; }

        /// <summary> 
        /// Recebe o valor de MBN_C_EXTENSAO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public string Extensao { get; set; }

        /// <summary> 
        /// Recebe o valor de MBN_N_ORDEM 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public int? Ordem { get; set; }

        /// <summary> 
        /// Recebe o valor de MBN_B_FIXO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.0]]</user>
        public bool? IsFixo { get; set; }

        /// <summary> 
        /// Recebe o valor de MBN_B_STATUS 
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
            if (pobjIDataReader["MBN_N_CODIGO"] != System.DBNull.Value)
            {
                this.Codigo = Convert.ToDecimal(pobjIDataReader["MBN_N_CODIGO"]);
            }
            if (pobjIDataReader["MBN_C_TITULO"] != System.DBNull.Value)
            {
                this.Titulo = pobjIDataReader["MBN_C_TITULO"].ToString();
            }
            if (pobjIDataReader["MBN_C_LINK"] != System.DBNull.Value)
            {
                this.Link = pobjIDataReader["MBN_C_LINK"].ToString();
            }
            if (pobjIDataReader["MBN_N_LARGURA"] != System.DBNull.Value)
            {
                this.Largura = Convert.ToDecimal(pobjIDataReader["MBN_N_LARGURA"]);
            }
            if (pobjIDataReader["MBN_N_ALTURA"] != System.DBNull.Value)
            {
                this.Altura = Convert.ToDecimal(pobjIDataReader["MBN_N_ALTURA"]);
            }
            if (pobjIDataReader["MBN_C_EXTENSAO"] != System.DBNull.Value)
            {
                this.Extensao = pobjIDataReader["MBN_C_EXTENSAO"].ToString();
            }
            if (pobjIDataReader["MBN_N_ORDEM"] != System.DBNull.Value)
            {
                this.Ordem = Convert.ToInt32(pobjIDataReader["MBN_N_ORDEM"]);
            }
            if (pobjIDataReader["MBN_B_FIXO"] != System.DBNull.Value)
            {
                this.IsFixo = Convert.ToBoolean(pobjIDataReader["MBN_B_FIXO"]);
            }
            if (pobjIDataReader["MBN_B_STATUS"] != System.DBNull.Value)
            {
                this.IsStatus = Convert.ToBoolean(pobjIDataReader["MBN_B_STATUS"]);
            }
        }

        #endregion
    }
}


