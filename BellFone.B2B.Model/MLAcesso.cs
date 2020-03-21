using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace BellFone.B2B.Model
{
    /// <summary> 
    /// Model da Entidade Acesso 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class MLAcesso
    {

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de ACC_USU_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public decimal? CodigoUsuario { get; set; }

        /// <summary> 
        /// Recebe o valor de ACC_PRD_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public string CodigoProduto { get; set; }

        /// <summary> 
        /// Recebe o valor de ACC_D_DATA 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public DateTime? Data { get; set; }

        /// <summary> 
        /// 
        /// </summary> 
        /// <user>GeradorVm2 [[2.3.0.1]]</user>
        public int? QuantidadeAcessos { get; set; }

        #endregion

        #region Conversor DataReader
        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["ACC_USU_N_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoUsuario = Convert.ToDecimal(pobjIDataReader["ACC_USU_N_CODIGO"]);
            }
            if (pobjIDataReader["ACC_PRD_N_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoProduto = pobjIDataReader["ACC_PRD_N_CODIGO"].ToString();
            }
            if (pobjIDataReader["ACC_D_DATA"] != System.DBNull.Value)
            {
                this.Data = Convert.ToDateTime(pobjIDataReader["ACC_D_DATA"]);
            }
            if (pobjIDataReader["QUANTIDADE"] != System.DBNull.Value)
            {
                this.QuantidadeAcessos = Convert.ToInt32(pobjIDataReader["QUANTIDADE"]);
            }

        }

        #endregion

        public void FromIDataReaderRel(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["ACC_USU_N_CODIGO"] != System.DBNull.Value)
            {
                this.CodigoUsuario = Convert.ToDecimal(pobjIDataReader["ACC_USU_N_CODIGO"]);
            }
            if (pobjIDataReader["ACC_D_DATA"] != System.DBNull.Value)
            {
                this.Data = Convert.ToDateTime(pobjIDataReader["ACC_D_DATA"]);
            }
            if (pobjIDataReader["QUANTIDADE"] != System.DBNull.Value)
            {
                this.QuantidadeAcessos = Convert.ToInt32(pobjIDataReader["QUANTIDADE"]);
            }

        }

        public String FromArquivoIntegracaoExportar(MLAcesso linhaAcesso)
        {
            String strArquivo = "";

            strArquivo += linhaAcesso.CodigoUsuario.ToString().PadRight(18);
            strArquivo += linhaAcesso.QuantidadeAcessos.ToString().PadRight(10);
            strArquivo += Convert.ToDateTime(linhaAcesso.Data.ToString().PadRight(10)).ToString("dd/MM/yyyy");
            
            strArquivo += "\r\n";

            return strArquivo;
        }
    }
}


