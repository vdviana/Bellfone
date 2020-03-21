using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace VM2.Framework.Model.Enquete
{
    /// <summary> 
    /// Model da Entidade EnqueteOpcao 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class MLEnqueteOpcao
    {

        #region Variáveis Privadas

        ///<summary>EQP_N_CODIGO</summary>
        decimal? gdecCodigo;

        ///<summary>EQP_ENQ_N_CODIGO</summary>
        decimal? gdecCodigoEnquete;

        ///<summary>EQP_C_OPCAO</summary>
        string gstrOpcao;

        #endregion

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de EQP_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? Codigo
        {
            get { return gdecCodigo; }
            set { gdecCodigo = value; }
        }

        /// <summary> 
        /// Recebe o valor de EQP_ENQ_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? CodigoEnquete
        {
            get { return gdecCodigoEnquete; }
            set { gdecCodigoEnquete = value; }
        }

        /// <summary> 
        /// Recebe o valor de EQP_C_OPCAO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Opcao
        {
            get { return gstrOpcao; }
            set { gstrOpcao = value; }
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
                if (pobjIDataReader["EQP_N_CODIGO"] != System.DBNull.Value)
                {
                    this.Codigo = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("EQP_N_CODIGO")));
                }
                if (pobjIDataReader["EQP_ENQ_N_CODIGO"] != System.DBNull.Value)
                {
                    this.CodigoEnquete = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("EQP_ENQ_N_CODIGO")));
                }
                if (pobjIDataReader["EQP_C_OPCAO"] != System.DBNull.Value)
                {
                    this.Opcao = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("EQP_C_OPCAO")).ToString();
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


