using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace VM2.Framework.Model.Arquivo
{
    /// <summary> 
    /// Model da Entidade ArquivoCategoria 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class MLCategoriaArquivo
    {

        #region Variáveis Privadas

        ///<summary>AQC_N_CODIGO</summary>
        decimal? gdecCodigo;

        ///<summary>AQC_C_DESCRICAO</summary>
        string gstrDescricao;

        ///<summary>AQC_B_STATUS</summary>
        bool? gblnStatus;

        #endregion

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de AQC_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? Codigo
        {
            get { return gdecCodigo; }
            set { gdecCodigo = value; }
        }

        /// <summary> 
        /// Recebe o valor de AQC_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Descricao
        {
            get { return gstrDescricao; }
            set { gstrDescricao = value; }
        }

        /// <summary> 
        /// Recebe o valor de AQC_B_STATUS 
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
                if (pobjIDataReader["AQC_N_CODIGO"] != System.DBNull.Value)
                {
                    this.Codigo = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("AQC_N_CODIGO")));
                }
                if (pobjIDataReader["AQC_C_DESCRICAO"] != System.DBNull.Value)
                {
                    this.Descricao = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("AQC_C_DESCRICAO")).ToString();
                }
                if (pobjIDataReader["AQC_B_STATUS"] != System.DBNull.Value)
                {
                    this.IsStatus = Convert.ToBoolean(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("AQC_B_STATUS")));
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


