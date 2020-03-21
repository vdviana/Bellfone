using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace VM2.Framework.Model.FAQ
{
    /// <summary> 
    /// Model da Entidade PerguntaFrequente 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class MLPerguntaFrequente
    {

        #region Variáveis Privadas

        ///<summary>PFQ_N_CODIGO</summary>
        decimal? gdecCodigo;

        ///<summary>PFQ_IDI_N_CODIGO</summary>
        decimal? gdecCodigoIdioma;

        ///<summary>PFQ_PFC_N_CODIGO</summary>
        decimal? gdecCodigoPerguntaFrequenteCategoria;

        ///<summary>PFQ_C_PERGUNTA</summary>
        string gstrPergunta;

        string gstrCategoria;
        string gstrIdioma;
        
        ///<summary>PFQ_C_RESPOSTA</summary>
        string gstrResposta;

        ///<summary>PFQ_B_STATUS</summary>
        bool? gblnStatus;

        #endregion

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de PFQ_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? Codigo
        {
            get { return gdecCodigo; }
            set { gdecCodigo = value; }
        }

        /// <summary> 
        /// Recebe o valor de PFQ_IDI_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? CodigoIdioma
        {
            get { return gdecCodigoIdioma; }
            set { gdecCodigoIdioma = value; }
        }

        /// <summary> 
        /// Recebe o valor de PFQ_PFC_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? CodigoPerguntaFrequenteCategoria
        {
            get { return gdecCodigoPerguntaFrequenteCategoria; }
            set { gdecCodigoPerguntaFrequenteCategoria = value; }
        }

        /// <summary> 
        /// Recebe o valor de PFQ_C_PERGUNTA 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Pergunta
        {
            get { return gstrPergunta; }
            set { gstrPergunta = value; }
        }
        public string Idioma
        {
            get { return gstrIdioma; }
            set { gstrIdioma = value; }
        }
        public string Categoria
        {
            get { return gstrCategoria; }
            set { gstrCategoria = value; }
        }

        /// <summary> 
        /// Recebe o valor de PFQ_C_RESPOSTA 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Resposta
        {
            get { return gstrResposta; }
            set { gstrResposta = value; }
        }

        /// <summary> 
        /// Recebe o valor de PFQ_B_STATUS 
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
                if (pobjIDataReader["PFQ_N_CODIGO"] != System.DBNull.Value)
                {
                    this.Codigo = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("PFQ_N_CODIGO")));
                }
                if (pobjIDataReader["PFQ_IDI_N_CODIGO"] != System.DBNull.Value)
                {
                    this.CodigoIdioma = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("PFQ_IDI_N_CODIGO")));
                }
                if (pobjIDataReader["PFQ_PFC_N_CODIGO"] != System.DBNull.Value)
                {
                    this.CodigoPerguntaFrequenteCategoria = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("PFQ_PFC_N_CODIGO")));
                }
                if (pobjIDataReader["PFQ_C_PERGUNTA"] != System.DBNull.Value)
                {
                    this.Pergunta = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("PFQ_C_PERGUNTA")).ToString();
                }
                if (pobjIDataReader["PFQ_C_RESPOSTA"] != System.DBNull.Value)
                {
                    this.Resposta = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("PFQ_C_RESPOSTA")).ToString();
                }
                if (pobjIDataReader["PFQ_B_STATUS"] != System.DBNull.Value)
                {
                    this.IsStatus = Convert.ToBoolean(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("PFQ_B_STATUS")));
                }

                if (pobjIDataReader["IDI_C_NOME"] != System.DBNull.Value)
                {
                    this.Idioma = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("IDI_C_NOME")).ToString();
                }

                if (pobjIDataReader["FQC_C_DESCRICAO"] != System.DBNull.Value)
                {
                    this.Categoria = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("FQC_C_DESCRICAO")).ToString();
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


