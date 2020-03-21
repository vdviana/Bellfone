using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace VM2.Framework.Model.Noticia
{
    /// <summary> 
    /// Model da Entidade Noticia 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class MLNoticia
    {

        #region Variáveis Privadas

        ///<summary>NOT_N_CODIGO</summary>
        decimal? gdecCodigo;

        ///<summary>NOT_NTC_N_CODGIO</summary>
        decimal? gdecCodgioNoticiaCategoria;

        ///<summary>NOT_IDI_N_CODIGO</summary>
        decimal? gdecCodigoIdioma;

        ///<summary>NOT_D_DATA</summary>
        DateTime? gdatData;

        ///<summary>NOT_C_TITULO</summary>
        string gstrTitulo;

        string gstrIdioma;
        string gstrCategoria;
        ///<summary>NOT_C_SINTESE</summary>
        string gstrSintese;

        ///<summary>NOT_C_CONTEUDO</summary>
        string gstrConteudo;

        ///<summary>NOT_C_FONTE</summary>
        string gstrFonte;

        ///<summary>NOT_C_AUTOR</summary>
        string gstrAutor;

        ///<summary>NOT_C_IMAGEM_EXTENSAO</summary>
        string gstrImagemExtensao;

        ///<summary>NOT_B_ATIVO</summary>
        bool? gblnAtivo;

        #endregion

        #region Propriedades

        /// <summary> 
        /// Recebe o valor de NOT_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? Codigo
        {
            get { return gdecCodigo; }
            set { gdecCodigo = value; }
        }

        /// <summary> 
        /// Recebe o valor de NOT_NTC_N_CODGIO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? CodgioNoticiaCategoria
        {
            get { return gdecCodgioNoticiaCategoria; }
            set { gdecCodgioNoticiaCategoria = value; }
        }

        /// <summary> 
        /// Recebe o valor de NOT_IDI_N_CODIGO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public decimal? CodigoIdioma
        {
            get { return gdecCodigoIdioma; }
            set { gdecCodigoIdioma = value; }
        }

        /// <summary> 
        /// Recebe o valor de NOT_D_DATA 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public DateTime? Data
        {
            get { return gdatData; }
            set { gdatData = value; }
        }

        /// <summary> 
        /// Recebe o valor de NOT_C_TITULO 
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
            set { gstrIdioma  = value; }
        }


        public string Categoria
        {
            get { return gstrCategoria; }
            set { gstrCategoria = value; }
        }

        /// <summary> 
        /// Recebe o valor de NOT_C_SINTESE 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Sintese
        {
            get { return gstrSintese; }
            set { gstrSintese = value; }
        }

        /// <summary> 
        /// Recebe o valor de NOT_C_CONTEUDO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Conteudo
        {
            get { return gstrConteudo; }
            set { gstrConteudo = value; }
        }

        /// <summary> 
        /// Recebe o valor de NOT_C_FONTE 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Fonte
        {
            get { return gstrFonte; }
            set { gstrFonte = value; }
        }

        /// <summary> 
        /// Recebe o valor de NOT_C_AUTOR 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string Autor
        {
            get { return gstrAutor; }
            set { gstrAutor = value; }
        }

        /// <summary> 
        /// Recebe o valor de NOT_C_IMAGEM_EXTENSAO 
        /// </summary> 
        /// <user>GeradorVm2</user>
        public string ImagemExtensao
        {
            get { return gstrImagemExtensao; }
            set { gstrImagemExtensao = value; }
        }

        /// <summary> 
        /// Recebe o valor de NOT_B_ATIVO 
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
                if (pobjIDataReader["NOT_N_CODIGO"] != System.DBNull.Value)
                {
                    this.Codigo = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NOT_N_CODIGO")));
                }
                if (pobjIDataReader["NOT_NTC_N_CODGIO"] != System.DBNull.Value)
                {
                    this.CodgioNoticiaCategoria = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NOT_NTC_N_CODGIO")));
                }
                if (pobjIDataReader["NOT_IDI_N_CODIGO"] != System.DBNull.Value)
                {
                    this.CodigoIdioma = Convert.ToDecimal(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NOT_IDI_N_CODIGO")));
                }
                if (pobjIDataReader["NOT_D_DATA"] != System.DBNull.Value)
                {
                    this.Data = Convert.ToDateTime(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NOT_D_DATA")));
                }
                if (pobjIDataReader["NOT_C_TITULO"] != System.DBNull.Value)
                {
                    this.Titulo = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NOT_C_TITULO")).ToString();
                }
                if (pobjIDataReader["NOT_C_SINTESE"] != System.DBNull.Value)
                {
                    this.Sintese = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NOT_C_SINTESE")).ToString();
                }
                if (pobjIDataReader["NOT_C_CONTEUDO"] != System.DBNull.Value)
                {
                    this.Conteudo = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NOT_C_CONTEUDO")).ToString();
                }
                if (pobjIDataReader["NOT_C_FONTE"] != System.DBNull.Value)
                {
                    this.Fonte = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NOT_C_FONTE")).ToString();
                }
                if (pobjIDataReader["NOT_C_AUTOR"] != System.DBNull.Value)
                {
                    this.Autor = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NOT_C_AUTOR")).ToString();
                }
                if (pobjIDataReader["NOT_C_IMAGEM_EXTENSAO"] != System.DBNull.Value)
                {
                    this.ImagemExtensao = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NOT_C_IMAGEM_EXTENSAO")).ToString();
                }
                if (pobjIDataReader["NOT_B_ATIVO"] != System.DBNull.Value)
                {
                    this.IsAtivo = Convert.ToBoolean(pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NOT_B_ATIVO")));
                }

                if (pobjIDataReader["IDI_C_NOME"] != System.DBNull.Value)
                {
                    this.Idioma = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("IDI_C_NOME")).ToString();
                }

                if (pobjIDataReader["NTC_C_DESCRICAO"] != System.DBNull.Value)
                {
                    this.Categoria = pobjIDataReader.GetValue(pobjIDataReader.GetOrdinal("NTC_C_DESCRICAO")).ToString();
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


