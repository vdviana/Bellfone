using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.Model.Noticia;

namespace VM2.Framework.DataLayer.Noticia.Sql
{
    /// <summary> 
    /// Classe de conexão de dados para Noticia 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLNoticia : DLFWBase, IDLNoticia
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2</user> 
        public DLNoticia()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLNoticia">Parametros para filtro</param>
        /// <returns>Lista de Noticia</returns> 
        /// <user>GeradorVm2</user>
        public List<MLNoticia> Listar(MLNoticia pobjMLNoticia)
        {

            List<MLNoticia> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWC_L_NOTICIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLNoticia.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@NOT_N_CODIGO"].Value = pobjMLNoticia.Codigo.Value;
            }
            if (pobjMLNoticia.CodgioNoticiaCategoria.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_NTC_N_CODGIO", FWDbType.Decimal));
                cmdCommand.Parameters["@NOT_NTC_N_CODGIO"].Value = pobjMLNoticia.CodgioNoticiaCategoria.Value;
            }
            if (pobjMLNoticia.CodigoIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@NOT_IDI_N_CODIGO"].Value = pobjMLNoticia.CodigoIdioma.Value;
            }
            if (pobjMLNoticia.Data.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_D_DATA", FWDbType.DateTime));
                cmdCommand.Parameters["@NOT_D_DATA"].Value = pobjMLNoticia.Data.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Titulo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_TITULO", FWDbType.Varchar, 200));
                cmdCommand.Parameters["@NOT_C_TITULO"].Value = pobjMLNoticia.Titulo;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Sintese))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_SINTESE", FWDbType.Varchar, 500));
                cmdCommand.Parameters["@NOT_C_SINTESE"].Value = pobjMLNoticia.Sintese;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Conteudo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_CONTEUDO", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@NOT_C_CONTEUDO"].Value = pobjMLNoticia.Conteudo;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Fonte))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_FONTE", FWDbType.Varchar, 200));
                cmdCommand.Parameters["@NOT_C_FONTE"].Value = pobjMLNoticia.Fonte;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Autor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_AUTOR", FWDbType.Varchar, 200));
                cmdCommand.Parameters["@NOT_C_AUTOR"].Value = pobjMLNoticia.Autor;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.ImagemExtensao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_IMAGEM_EXTENSAO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@NOT_C_IMAGEM_EXTENSAO"].Value = pobjMLNoticia.ImagemExtensao;
            }
            if (pobjMLNoticia.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@NOT_B_ATIVO"].Value = pobjMLNoticia.IsAtivo.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLNoticia objRetorno = null;
                lstRetorno = new List<MLNoticia>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLNoticia();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (idrRetorno != null && !idrRetorno.IsClosed)
                {
                    idrRetorno.Close();
                }
            }
            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary> 
        /// Executa a stored procedure para retornar um registro específico
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Noticia</returns> 
        /// <user>GeradorVm2</user>
        public MLNoticia Obter(decimal pdecCodigo)
        {

            MLNoticia objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWC_S_NOTICIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@NOT_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@NOT_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_NOT_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_NOT_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_NOT_NTC_N_CODGIO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_NOT_NTC_N_CODGIO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_NOT_IDI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_NOT_IDI_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_NOT_D_DATA", FWDbType.DateTime));
            cmdCommand.Parameters["@OUT_NOT_D_DATA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_NOT_C_TITULO", FWDbType.Varchar, 200));
            cmdCommand.Parameters["@OUT_NOT_C_TITULO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_NOT_C_SINTESE", FWDbType.Varchar, 500));
            cmdCommand.Parameters["@OUT_NOT_C_SINTESE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_NOT_C_CONTEUDO", FWDbType.Varchar, -1));
            cmdCommand.Parameters["@OUT_NOT_C_CONTEUDO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_NOT_C_FONTE", FWDbType.Varchar, 200));
            cmdCommand.Parameters["@OUT_NOT_C_FONTE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_NOT_C_AUTOR", FWDbType.Varchar, 200));
            cmdCommand.Parameters["@OUT_NOT_C_AUTOR"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_NOT_C_IMAGEM_EXTENSAO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_NOT_C_IMAGEM_EXTENSAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_NOT_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_NOT_B_ATIVO"].Direction = ParameterDirection.Output;

            try
            {
                objRetorno = new MLNoticia();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["@OUT_NOT_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_NOT_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_NOT_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_NOT_N_CODIGO"].Value);
                    if ((cmdCommand.Parameters["@OUT_NOT_NTC_N_CODGIO"] != null) && cmdCommand.Parameters["@OUT_NOT_NTC_N_CODGIO"].Value != null && cmdCommand.Parameters["@OUT_NOT_NTC_N_CODGIO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodgioNoticiaCategoria = Convert.ToDecimal(cmdCommand.Parameters["@OUT_NOT_NTC_N_CODGIO"].Value);
                    }

                    if ((cmdCommand.Parameters["@OUT_NOT_IDI_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_NOT_IDI_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_NOT_IDI_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoIdioma = Convert.ToDecimal(cmdCommand.Parameters["@OUT_NOT_IDI_N_CODIGO"].Value);
                    }

                    if ((cmdCommand.Parameters["@OUT_NOT_D_DATA"] != null) && cmdCommand.Parameters["@OUT_NOT_D_DATA"].Value != null && cmdCommand.Parameters["@OUT_NOT_D_DATA"].Value != System.DBNull.Value)
                    {
                        objRetorno.Data = Convert.ToDateTime(cmdCommand.Parameters["@OUT_NOT_D_DATA"].Value);
                    }

                    if ((cmdCommand.Parameters["@OUT_NOT_C_TITULO"] != null) && cmdCommand.Parameters["@OUT_NOT_C_TITULO"].Value != null && cmdCommand.Parameters["@OUT_NOT_C_TITULO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Titulo = cmdCommand.Parameters["@OUT_NOT_C_TITULO"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_NOT_C_SINTESE"] != null) && cmdCommand.Parameters["@OUT_NOT_C_SINTESE"].Value != null && cmdCommand.Parameters["@OUT_NOT_C_SINTESE"].Value != System.DBNull.Value)
                    {
                        objRetorno.Sintese = cmdCommand.Parameters["@OUT_NOT_C_SINTESE"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_NOT_C_CONTEUDO"] != null) && cmdCommand.Parameters["@OUT_NOT_C_CONTEUDO"].Value != null && cmdCommand.Parameters["@OUT_NOT_C_CONTEUDO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Conteudo = cmdCommand.Parameters["@OUT_NOT_C_CONTEUDO"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_NOT_C_FONTE"] != null) && cmdCommand.Parameters["@OUT_NOT_C_FONTE"].Value != null && cmdCommand.Parameters["@OUT_NOT_C_FONTE"].Value != System.DBNull.Value)
                    {
                        objRetorno.Fonte = cmdCommand.Parameters["@OUT_NOT_C_FONTE"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_NOT_C_AUTOR"] != null) && cmdCommand.Parameters["@OUT_NOT_C_AUTOR"].Value != null && cmdCommand.Parameters["@OUT_NOT_C_AUTOR"].Value != System.DBNull.Value)
                    {
                        objRetorno.Autor = cmdCommand.Parameters["@OUT_NOT_C_AUTOR"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_NOT_C_IMAGEM_EXTENSAO"] != null) && cmdCommand.Parameters["@OUT_NOT_C_IMAGEM_EXTENSAO"].Value != null && cmdCommand.Parameters["@OUT_NOT_C_IMAGEM_EXTENSAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.ImagemExtensao = cmdCommand.Parameters["@OUT_NOT_C_IMAGEM_EXTENSAO"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["@OUT_NOT_B_ATIVO"] != null) && cmdCommand.Parameters["@OUT_NOT_B_ATIVO"].Value != null && cmdCommand.Parameters["@OUT_NOT_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_NOT_B_ATIVO"].Value);
                    }

                }
            }
            catch
            {
                throw;
            }
            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Executa a Stored Procedure de Exclusão
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Excluir(decimal pdecCodigo)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_D_NOTICIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@NOT_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@NOT_N_CODIGO"].Value = pdecCodigo;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                blnRetorno = true;

            }
            catch
            {
                throw;
            }
            return blnRetorno;
        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLNoticia">Noticia para alterar</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>GeradorVm2</user>
        public bool Alterar(MLNoticia pobjMLNoticia)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_U_NOTICIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLNoticia.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@NOT_N_CODIGO"].Value = pobjMLNoticia.Codigo.Value;
            }
            if (pobjMLNoticia.CodgioNoticiaCategoria.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_NTC_N_CODGIO", FWDbType.Decimal));
                cmdCommand.Parameters["@NOT_NTC_N_CODGIO"].Value = pobjMLNoticia.CodgioNoticiaCategoria.Value;
            }
            if (pobjMLNoticia.CodigoIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@NOT_IDI_N_CODIGO"].Value = pobjMLNoticia.CodigoIdioma.Value;
            }
            if (pobjMLNoticia.Data.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_D_DATA", FWDbType.DateTime));
                cmdCommand.Parameters["@NOT_D_DATA"].Value = pobjMLNoticia.Data.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Titulo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_TITULO", FWDbType.Varchar, 200));
                cmdCommand.Parameters["@NOT_C_TITULO"].Value = pobjMLNoticia.Titulo;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Sintese))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_SINTESE", FWDbType.Varchar, 500));
                cmdCommand.Parameters["@NOT_C_SINTESE"].Value = pobjMLNoticia.Sintese;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Conteudo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_CONTEUDO", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@NOT_C_CONTEUDO"].Value = pobjMLNoticia.Conteudo;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Fonte))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_FONTE", FWDbType.Varchar, 200));
                cmdCommand.Parameters["@NOT_C_FONTE"].Value = pobjMLNoticia.Fonte;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Autor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_AUTOR", FWDbType.Varchar, 200));
                cmdCommand.Parameters["@NOT_C_AUTOR"].Value = pobjMLNoticia.Autor;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.ImagemExtensao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_IMAGEM_EXTENSAO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@NOT_C_IMAGEM_EXTENSAO"].Value = pobjMLNoticia.ImagemExtensao;
            }
            if (pobjMLNoticia.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@NOT_B_ATIVO"].Value = pobjMLNoticia.IsAtivo.Value;
            }

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                blnRetorno = true;

            }
            catch
            {
                throw;
            }
            return blnRetorno;
        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLNoticia">Noticia para inserir</param>
        /// <returns>Código Noticia</returns> 
        /// <user>GeradorVm2</user>
        public int Inserir(MLNoticia pobjMLNoticia)
        {

            int intRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWC_I_NOTICIA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLNoticia.CodgioNoticiaCategoria.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_NTC_N_CODGIO", FWDbType.Decimal));
                cmdCommand.Parameters["@NOT_NTC_N_CODGIO"].Value = pobjMLNoticia.CodgioNoticiaCategoria.Value;
            }
            if (pobjMLNoticia.CodigoIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@NOT_IDI_N_CODIGO"].Value = pobjMLNoticia.CodigoIdioma.Value;
            }
            if (pobjMLNoticia.Data.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_D_DATA", FWDbType.DateTime));
                cmdCommand.Parameters["@NOT_D_DATA"].Value = pobjMLNoticia.Data.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Titulo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_TITULO", FWDbType.Varchar, 200));
                cmdCommand.Parameters["@NOT_C_TITULO"].Value = pobjMLNoticia.Titulo;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Sintese))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_SINTESE", FWDbType.Varchar, 500));
                cmdCommand.Parameters["@NOT_C_SINTESE"].Value = pobjMLNoticia.Sintese;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Conteudo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_CONTEUDO", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@NOT_C_CONTEUDO"].Value = pobjMLNoticia.Conteudo;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Fonte))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_FONTE", FWDbType.Varchar, 200));
                cmdCommand.Parameters["@NOT_C_FONTE"].Value = pobjMLNoticia.Fonte;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.Autor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_AUTOR", FWDbType.Varchar, 200));
                cmdCommand.Parameters["@NOT_C_AUTOR"].Value = pobjMLNoticia.Autor;
            }
            if (!string.IsNullOrEmpty(pobjMLNoticia.ImagemExtensao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_C_IMAGEM_EXTENSAO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@NOT_C_IMAGEM_EXTENSAO"].Value = pobjMLNoticia.ImagemExtensao;
            }
            if (pobjMLNoticia.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@NOT_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@NOT_B_ATIVO"].Value = pobjMLNoticia.IsAtivo.Value;
            }

            try
            {
                intRetorno = Convert.ToInt32(conProvider.ExecuteScalar(cmdCommand));

            }
            catch
            {
                throw;
            }
            return intRetorno;
        }

        #endregion

        
    }
}


