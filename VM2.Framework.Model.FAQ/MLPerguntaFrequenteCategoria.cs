using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace VM2.Framework.Model.FAQ
{
    /// <summary> 
    /// Model da Entidade PerguntaFrequenteCategoria 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class MLPerguntaFrequenteCategoria
    {

        #region Variáveis Privadas

        ///<summary>FQC_N_CODIGO</summary>
        decimal? gdecCodigo;

        ///<summary>FQC_C_DESCRICAO</summary>
        string gstrDescricao;

        ///<summary>FQC_B_STATUS</summary>
        bool? gblnStatus;

        #endregion

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de FQC_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? Codigo
        {
            get { return gdecCodigo; }
            set { gdecCodigo = value; }
        }

        /// <summary> 
        /// Recebe o valor de FQC_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Descricao
        {
            get { return gstrDescricao; }
            set { gstrDescricao = value; }
        }

        /// <summary> 
        /// Recebe o valor de FQC_B_STATUS 
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
                if (pobjIDataReader["FQC_N_CODIGO"] != System.DBNull.Value)
                {
                    this.Codigo = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("FQC_N_CODIGO")));
                }
                if (pobjIDataReader["FQC_C_DESCRICAO"] != System.DBNull.Value)
                {
                    this.Descricao = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("FQC_C_DESCRICAO")).ToString();
                }
                if (pobjIDataReader["FQC_B_STATUS"] != System.DBNull.Value)
                {
                    this.IsStatus = Convert.ToBoolean(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("FQC_B_STATUS")));
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


