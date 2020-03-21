using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace VM2.Framework.Model.Noticia
{
    /// <summary> 
    /// Model da Entidade NoticiaCategoria 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class MLNoticiaCategoria
    {

        #region Variáveis Privadas

        ///<summary>NTC_N_CODIGO</summary>
        decimal? gdecCodigo;

        ///<summary>NTC_C_DESCRICAO</summary>
        string gstrDescricao;

        ///<summary>NTC_B_ATIVO</summary>
        bool? gblnAtivo;

        #endregion

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de NTC_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? Codigo
        {
            get { return gdecCodigo; }
            set { gdecCodigo = value; }
        }

        /// <summary> 
        /// Recebe o valor de NTC_C_DESCRICAO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Descricao
        {
            get { return gstrDescricao; }
            set { gstrDescricao = value; }
        }

        /// <summary> 
        /// Recebe o valor de NTC_B_ATIVO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public bool? IsAtivo
        {
            get { return gblnAtivo; }
            set { gblnAtivo = value; }
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
                if (pobjIDataReader["NTC_N_CODIGO"] != System.DBNull.Value)
                {
                    this.Codigo = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NTC_N_CODIGO")));
                }
                if (pobjIDataReader["NTC_C_DESCRICAO"] != System.DBNull.Value)
                {
                    this.Descricao = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NTC_C_DESCRICAO")).ToString();
                }
                if (pobjIDataReader["NTC_B_ATIVO"] != System.DBNull.Value)
                {
                    this.IsAtivo = Convert.ToBoolean(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NTC_B_ATIVO")));
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
