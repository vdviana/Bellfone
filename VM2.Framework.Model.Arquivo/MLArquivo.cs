using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace VM2.Framework.Model.Arquivo
{
    /// <summary> 
    /// Model da Entidade Arquivo 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class MLArquivo
    {

        #region Variáveis Privadas

        ///<summary>ARQ_N_CODIGO</summary>
        decimal? gdecCodigo;

        ///<summary>ARQ_IDI_N_CODIGO</summary>
        decimal? gdecCodigoIdioma;

        ///<summary>ARQ_AQC_N_CODIGO</summary>
        decimal? gdecCodigoArquivoCategoria;

        ///<summary>ARQ_C_NOME</summary>
        string gstrNome;

        string gstrNomeCategoria;

        string gstrNomeIdioma;

        ///<summary>ARQ_C_DESCRICAO</summary>
        string gstrDescricao;

        ///<summary>ARQ_C_ARQUIVO</summary>
        string gstrArquivo;

        ///<summary>ARQ_B_STATUS</summary>
        bool? gblnStatus;

        #endregion

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de ARQ_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? Codigo
        {
            get { return gdecCodigo; }
            set { gdecCodigo = value; }
        }

        /// <summary> 
        /// Recebe o valor de ARQ_IDI_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? CodigoIdioma
        {
            get { return gdecCodigoIdioma; }
            set { gdecCodigoIdioma = value; }
        }

        /// <summary> 
        /// Recebe o valor de ARQ_AQC_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? CodigoArquivoCategoria
        {
            get { return gdecCodigoArquivoCategoria; }
            set { gdecCodigoArquivoCategoria = value; }
        }

        /// <summary> 
        /// Recebe o valor de ARQ_C_NOME 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Nome
        {
            get { return gstrNome; }
            set { gstrNome = value; }
        }


        public string NomeCategoria
        {
            get { return gstrNomeCategoria; }
            set { gstrNomeCategoria = value; }
        }

        public string NomeIdioma
        {
            get { return gstrNomeIdioma; }
            set { gstrNomeIdioma = value; }
        }

        /// <summary> 
        /// Recebe o valor de ARQ_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Descricao
        {
            get { return gstrDescricao; }
            set { gstrDescricao = value; }
        }

        /// <summary> 
        /// Recebe o valor de ARQ_C_ARQUIVO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Arquivo
        {
            get { return gstrArquivo; }
            set { gstrArquivo = value; }
        }

        /// <summary> 
        /// Recebe o valor de ARQ_B_STATUS 
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
                if (pobjIDataReader["ARQ_N_CODIGO"] != System.DBNull.Value)
                {
                    this.Codigo = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("ARQ_N_CODIGO")));
                }
                if (pobjIDataReader["ARQ_IDI_N_CODIGO"] != System.DBNull.Value)
                {
                    this.CodigoIdioma = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("ARQ_IDI_N_CODIGO")));
                }
                if (pobjIDataReader["ARQ_AQC_N_CODIGO"] != System.DBNull.Value)
                {
                    this.CodigoArquivoCategoria = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("ARQ_AQC_N_CODIGO")));
                }
                if (pobjIDataReader["ARQ_C_NOME"] != System.DBNull.Value)
                {
                    this.Nome = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("ARQ_C_NOME")).ToString();
                }
                if (pobjIDataReader["ARQ_C_DESCRICAO"] != System.DBNull.Value)
                {
                    this.Descricao = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("ARQ_C_DESCRICAO")).ToString();
                }
                if (pobjIDataReader["ARQ_C_ARQUIVO"] != System.DBNull.Value)
                {
                    this.Arquivo = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("ARQ_C_ARQUIVO")).ToString();
                }
                if (pobjIDataReader["ARQ_B_STATUS"] != System.DBNull.Value)
                {
                    this.IsStatus = Convert.ToBoolean(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("ARQ_B_STATUS")));
                }
                if (pobjIDataReader["AQC_C_DESCRICAO"] != System.DBNull.Value)
                {
                    this.NomeCategoria = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("AQC_C_DESCRICAO")).ToString();
                }
                if (pobjIDataReader["IDI_C_NOME"] != System.DBNull.Value)
                {
                    this.NomeIdioma = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("IDI_C_NOME")).ToString();
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


