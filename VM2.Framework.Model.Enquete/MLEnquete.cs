using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace VM2.Framework.Model.Enquete
{
    /// <summary> 
    /// Model da Entidade Enquete 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class MLEnquete
    {

        #region Variáveis Privadas

        ///<summary>ENQ_N_CODIGO</summary>
        decimal? gdecCodigo;

        ///<summary>ENQ_IDI_N_CODIGO</summary>
        decimal? gdecCodigoIdioma;

        ///<summary>ENQ_D_INICIO</summary>
        DateTime? gdatInicio;

        ///<summary>ENQ_D_TERMINO</summary>
        DateTime? gdatTermino;

        ///<summary>ENQ_C_TITULO</summary>
        string gstrTitulo;

        string gstrIdioma;
        ///<summary>ENQ_B_STATUS</summary>
        bool? gblnStatus;

        #endregion

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de ENQ_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? Codigo
        {
            get { return gdecCodigo; }
            set { gdecCodigo = value; }
        }

        /// <summary> 
        /// Recebe o valor de ENQ_IDI_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? CodigoIdioma
        {
            get { return gdecCodigoIdioma; }
            set { gdecCodigoIdioma = value; }
        }

        /// <summary> 
        /// Recebe o valor de ENQ_D_INICIO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public DateTime? Inicio
        {
            get { return gdatInicio; }
            set { gdatInicio = value; }
        }

        /// <summary> 
        /// Recebe o valor de ENQ_D_TERMINO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public DateTime? Termino
        {
            get { return gdatTermino; }
            set { gdatTermino = value; }
        }

        /// <summary> 
        /// Recebe o valor de ENQ_C_TITULO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Titulo
        {
            get { return gstrTitulo; }
            set { gstrTitulo = value; }
        }


        public string Idioma
        {
            get { return gstrIdioma; }
            set { gstrIdioma = value; }
        }

        /// <summary> 
        /// Recebe o valor de ENQ_B_STATUS 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public bool? IsStatus
        {
            get { return gblnStatus; }
            set { gblnStatus = value; }
        }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            try
            {
                if (pobjIDataReader["ENQ_N_CODIGO"] != System.DBNull.Value)
                {
                    this.Codigo = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("ENQ_N_CODIGO")));
                }
                if (pobjIDataReader["ENQ_IDI_N_CODIGO"] != System.DBNull.Value)
                {
                    this.CodigoIdioma = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("ENQ_IDI_N_CODIGO")));
                }
                if (pobjIDataReader["ENQ_D_INICIO"] != System.DBNull.Value)
                {
                    this.Inicio = Convert.ToDateTime(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("ENQ_D_INICIO")));
                }
                if (pobjIDataReader["ENQ_D_TERMINO"] != System.DBNull.Value)
                {
                    this.Termino = Convert.ToDateTime(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("ENQ_D_TERMINO")));
                }
                if (pobjIDataReader["ENQ_C_TITULO"] != System.DBNull.Value)
                {
                    this.Titulo = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("ENQ_C_TITULO")).ToString();
                }
                if (pobjIDataReader["ENQ_B_STATUS"] != System.DBNull.Value)
                {
                    this.IsStatus = Convert.ToBoolean(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("ENQ_B_STATUS")));
                }

                if (pobjIDataReader["IDI_C_NOME"] != System.DBNull.Value)
                {
                    this.Idioma = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("IDI_C_NOME")).ToString();
                }

            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}


