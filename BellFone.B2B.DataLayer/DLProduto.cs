using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.BusinessLayer.Configuration;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para Produto 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class DLProduto : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.1]</user> 
        public DLProduto()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }

        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLProduto">Parametros para filtro</param>
        /// <param name="pstrRevendedorClassificacao">Classificação do Revendedor para buscar os preços</param>
        /// <returns>Lista de Produto</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public List<MLProduto> Listar(MLProduto pobjMLProduto, string pstrRevendedorClassificacao)
        {

            List<MLProduto> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_PRODUTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLProduto.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CODIGO", FWDbType.Varchar, 13));
                cmdCommand.Parameters["@PRD_C_CODIGO"].Value = pobjMLProduto.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.CodigoUnidadeMedida))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_UNM_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@PRD_UNM_C_CODIGO"].Value = pobjMLProduto.CodigoUnidadeMedida;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.CodigoSubgrupo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_SUB_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@PRD_SUB_C_CODIGO"].Value = pobjMLProduto.CodigoSubgrupo;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.CodigoFabricante))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_FAB_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@PRD_FAB_C_CODIGO"].Value = pobjMLProduto.CodigoFabricante;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@PRD_C_NOME"].Value = pobjMLProduto.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.Link))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_LINK", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@PRD_C_LINK"].Value = pobjMLProduto.Link;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.CaminhoImagem))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CAMINHO_IMAGEM", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@PRD_C_CAMINHO_IMAGEM"].Value = pobjMLProduto.CaminhoImagem;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_DESCRICAO", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@PRD_C_DESCRICAO"].Value = pobjMLProduto.Descricao;
            }
            if (pobjMLProduto.ValorOriginal.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_N_VALOR_ORIGINAL", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Precision = 11;
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Scale = 3;
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Value = pobjMLProduto.ValorOriginal.Value;
            }
            if (pobjMLProduto.ValorPromocional.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_N_VALOR_PROMOCIONAL", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Precision = 11;
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Scale = 3;
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Value = pobjMLProduto.ValorPromocional.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.Classificacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CLASSIFICACAO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@PRD_C_CLASSIFICACAO"].Value = pobjMLProduto.Classificacao;
            }
            if (pobjMLProduto.IsVisivel.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_VISIVEL", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_VISIVEL"].Value = pobjMLProduto.IsVisivel.Value;
            }
            if (pobjMLProduto.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_STATUS"].Value = pobjMLProduto.IsStatus.Value;
            }
            if (!string.IsNullOrEmpty(pstrRevendedorClassificacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_CLASSIFICACAO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@REV_C_CLASSIFICACAO"].Value = pstrRevendedorClassificacao;
            }
            if (pobjMLProduto.TemImagem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_EXISTE_IMAGEM", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_EXISTE_IMAGEM"].Value = pobjMLProduto.TemImagem.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLProduto objRetorno = null;
                lstRetorno = new List<MLProduto>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLProduto();
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
        /// <param name="pstrCodigo">Codigo</param>
        /// <param name="pstrRevendedorClassificacao">Classificação do Revendedor para buscar os preços</param>
        /// <returns>Produto</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public MLProduto Obter(string pstrCodigo, string pstrRevendedorClassificacao)
        {

            MLProduto objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_PRODUTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CODIGO", FWDbType.Varchar, 13));
            cmdCommand.Parameters["@PRD_C_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_C_CODIGO", FWDbType.Varchar, 13));
            cmdCommand.Parameters["@OUT_PRD_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_UNM_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_PRD_UNM_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_SUB_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_PRD_SUB_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_FAB_C_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_PRD_FAB_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_C_NOME", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_PRD_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_C_LINK", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_PRD_C_LINK"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_C_CAMINHO_IMAGEM", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_PRD_C_CAMINHO_IMAGEM"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_C_DESCRICAO", FWDbType.Varchar, -1));
            cmdCommand.Parameters["@OUT_PRD_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_N_VALOR_ORIGINAL", FWDbType.Decimal, 11));
            cmdCommand.Parameters["@OUT_PRD_N_VALOR_ORIGINAL"].Precision = 11;
            cmdCommand.Parameters["@OUT_PRD_N_VALOR_ORIGINAL"].Scale = 3;
            cmdCommand.Parameters["@OUT_PRD_N_VALOR_ORIGINAL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_N_VALOR_PROMOCIONAL", FWDbType.Decimal, 11));
            cmdCommand.Parameters["@OUT_PRD_N_VALOR_PROMOCIONAL"].Precision = 11;
            cmdCommand.Parameters["@OUT_PRD_N_VALOR_PROMOCIONAL"].Scale = 3;
            cmdCommand.Parameters["@OUT_PRD_N_VALOR_PROMOCIONAL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_C_CLASSIFICACAO", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@OUT_PRD_C_CLASSIFICACAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_B_VISIVEL", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_PRD_B_VISIVEL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_PRD_B_STATUS"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@REV_C_CLASSIFICACAO", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@REV_C_CLASSIFICACAO"].Value = pstrRevendedorClassificacao;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MN_VALOR_DE", FWDbType.Decimal, 11));
            cmdCommand.Parameters["@OUT_MN_VALOR_DE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MN_VALOR_POR", FWDbType.Decimal, 11));
            cmdCommand.Parameters["@OUT_MN_VALOR_POR"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_B_DESTAQUE", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_PRD_B_DESTAQUE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_B_EXISTE_IMAGEM", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_PRD_B_EXISTE_IMAGEM"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_PRD_C_CODIGO") && cmdCommand.Parameters["@OUT_PRD_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLProduto();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_PRD_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_PRD_UNM_C_CODIGO") && cmdCommand.Parameters["@OUT_PRD_UNM_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoUnidadeMedida = cmdCommand.Parameters["@OUT_PRD_UNM_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_SUB_C_CODIGO") && cmdCommand.Parameters["@OUT_PRD_SUB_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoSubgrupo = cmdCommand.Parameters["@OUT_PRD_SUB_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_FAB_C_CODIGO") && cmdCommand.Parameters["@OUT_PRD_FAB_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoFabricante = cmdCommand.Parameters["@OUT_PRD_FAB_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_C_NOME") && cmdCommand.Parameters["@OUT_PRD_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.Nome = cmdCommand.Parameters["@OUT_PRD_C_NOME"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_C_LINK") && cmdCommand.Parameters["@OUT_PRD_C_LINK"].Value != System.DBNull.Value)
                    {
                        objRetorno.Link = cmdCommand.Parameters["@OUT_PRD_C_LINK"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_C_CAMINHO_IMAGEM") && cmdCommand.Parameters["@OUT_PRD_C_CAMINHO_IMAGEM"].Value != System.DBNull.Value)
                    {
                        objRetorno.CaminhoImagem = cmdCommand.Parameters["@OUT_PRD_C_CAMINHO_IMAGEM"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_C_DESCRICAO") && cmdCommand.Parameters["@OUT_PRD_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_PRD_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_N_VALOR_ORIGINAL") && cmdCommand.Parameters["@OUT_PRD_N_VALOR_ORIGINAL"].Value != System.DBNull.Value)
                    {
                        objRetorno.ValorOriginal = Convert.ToDecimal(cmdCommand.Parameters["@OUT_PRD_N_VALOR_ORIGINAL"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_N_VALOR_PROMOCIONAL") && cmdCommand.Parameters["@OUT_PRD_N_VALOR_PROMOCIONAL"].Value != System.DBNull.Value)
                    {
                        objRetorno.ValorPromocional = Convert.ToDecimal(cmdCommand.Parameters["@OUT_PRD_N_VALOR_PROMOCIONAL"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_C_CLASSIFICACAO") && cmdCommand.Parameters["@OUT_PRD_C_CLASSIFICACAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Classificacao = cmdCommand.Parameters["@OUT_PRD_C_CLASSIFICACAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_B_VISIVEL") && cmdCommand.Parameters["@OUT_PRD_B_VISIVEL"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsVisivel = Convert.ToBoolean(cmdCommand.Parameters["@OUT_PRD_B_VISIVEL"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_B_STATUS") && cmdCommand.Parameters["@OUT_PRD_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatus = Convert.ToBoolean(cmdCommand.Parameters["@OUT_PRD_B_STATUS"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_MN_VALOR_DE") && cmdCommand.Parameters["@OUT_MN_VALOR_DE"].Value != System.DBNull.Value)
                    {
                        objRetorno.ValorDe = Convert.ToDecimal(cmdCommand.Parameters["@OUT_MN_VALOR_DE"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_MN_VALOR_POR") && cmdCommand.Parameters["@OUT_MN_VALOR_POR"].Value != System.DBNull.Value)
                    {
                        objRetorno.ValorPor = Convert.ToDecimal(cmdCommand.Parameters["@OUT_MN_VALOR_POR"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_B_DESTAQUE") && cmdCommand.Parameters["@OUT_PRD_B_DESTAQUE"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsDestaque = Convert.ToBoolean(cmdCommand.Parameters["@OUT_PRD_B_DESTAQUE"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_B_EXISTE_IMAGEM") && cmdCommand.Parameters["@OUT_PRD_B_EXISTE_IMAGEM"].Value != System.DBNull.Value)
                    {
                        objRetorno.TemImagem = Convert.ToBoolean(cmdCommand.Parameters["@OUT_PRD_B_EXISTE_IMAGEM"].Value);
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
        /// <param name="pstrCodigo">Codigo</param>
        /// <returns>Quantidade de Registro Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public int Excluir(string pstrCodigo)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_PRODUTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CODIGO", FWDbType.Varchar, 13));
            cmdCommand.Parameters["@PRD_C_CODIGO"].Value = pstrCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLProduto">Produto para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public int Alterar(MLProduto pobjMLProduto)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_PRODUTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLProduto.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CODIGO", FWDbType.Varchar, 13));
                cmdCommand.Parameters["@PRD_C_CODIGO"].Value = pobjMLProduto.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.CodigoUnidadeMedida))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_UNM_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@PRD_UNM_C_CODIGO"].Value = pobjMLProduto.CodigoUnidadeMedida;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.CodigoSubgrupo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_SUB_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@PRD_SUB_C_CODIGO"].Value = pobjMLProduto.CodigoSubgrupo;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.CodigoFabricante))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_FAB_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@PRD_FAB_C_CODIGO"].Value = pobjMLProduto.CodigoFabricante;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@PRD_C_NOME"].Value = pobjMLProduto.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.Link))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_LINK", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@PRD_C_LINK"].Value = pobjMLProduto.Link;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.CaminhoImagem))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CAMINHO_IMAGEM", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@PRD_C_CAMINHO_IMAGEM"].Value = pobjMLProduto.CaminhoImagem;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_DESCRICAO", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@PRD_C_DESCRICAO"].Value = pobjMLProduto.Descricao;
            }
            if (pobjMLProduto.ValorOriginal.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_N_VALOR_ORIGINAL", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Precision = 11;
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Scale = 3;
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Value = pobjMLProduto.ValorOriginal.Value;
            }
            if (pobjMLProduto.ValorPromocional.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_N_VALOR_PROMOCIONAL", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Precision = 11;
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Scale = 3;
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Value = pobjMLProduto.ValorPromocional.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.Classificacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CLASSIFICACAO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@PRD_C_CLASSIFICACAO"].Value = pobjMLProduto.Classificacao;
            }
            if (pobjMLProduto.IsVisivel.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_VISIVEL", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_VISIVEL"].Value = pobjMLProduto.IsVisivel.Value;
            }
            if (pobjMLProduto.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_STATUS"].Value = pobjMLProduto.IsStatus.Value;
            }
            if (pobjMLProduto.IsDestaque.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_DESTAQUE", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_DESTAQUE"].Value = pobjMLProduto.IsDestaque.Value;
            }
            if (pobjMLProduto.TemImagem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_EXISTE_IMAGEM", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_EXISTE_IMAGEM"].Value = pobjMLProduto.TemImagem.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLProduto">Produto para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public int Inserir(MLProduto pobjMLProduto)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_PRODUTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLProduto.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CODIGO", FWDbType.Varchar, 13));
                cmdCommand.Parameters["@PRD_C_CODIGO"].Value = pobjMLProduto.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.CodigoUnidadeMedida))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_UNM_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@PRD_UNM_C_CODIGO"].Value = pobjMLProduto.CodigoUnidadeMedida;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.CodigoSubgrupo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_SUB_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@PRD_SUB_C_CODIGO"].Value = pobjMLProduto.CodigoSubgrupo;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.CodigoFabricante))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_FAB_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@PRD_FAB_C_CODIGO"].Value = pobjMLProduto.CodigoFabricante;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@PRD_C_NOME"].Value = pobjMLProduto.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.Link))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_LINK", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@PRD_C_LINK"].Value = pobjMLProduto.Link;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.CaminhoImagem))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CAMINHO_IMAGEM", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@PRD_C_CAMINHO_IMAGEM"].Value = pobjMLProduto.CaminhoImagem;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_DESCRICAO", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@PRD_C_DESCRICAO"].Value = pobjMLProduto.Descricao;
            }
            if (pobjMLProduto.ValorOriginal.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_N_VALOR_ORIGINAL", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Precision = 11;
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Scale = 3;
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Value = pobjMLProduto.ValorOriginal.Value;
            }
            if (pobjMLProduto.ValorPromocional.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_N_VALOR_PROMOCIONAL", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Precision = 11;
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Scale = 3;
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Value = pobjMLProduto.ValorPromocional.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLProduto.Classificacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CLASSIFICACAO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@PRD_C_CLASSIFICACAO"].Value = pobjMLProduto.Classificacao;
            }
            if (pobjMLProduto.IsVisivel.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_VISIVEL", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_VISIVEL"].Value = pobjMLProduto.IsVisivel.Value;
            }
            if (pobjMLProduto.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_STATUS"].Value = pobjMLProduto.IsStatus.Value;
            }
            if (pobjMLProduto.IsDestaque.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_DESTAQUE", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_DESTAQUE"].Value = pobjMLProduto.IsDestaque.Value;
            }
            
            cmdCommand.Parameters.Add(new FWParameter("@PRD_B_EXISTE_IMAGEM", FWDbType.Boolean));
            cmdCommand.Parameters["@PRD_B_EXISTE_IMAGEM"].Value = false;
  
            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion
        
        #region Listar Produto Completo
        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLProdutoCompleto">Parametros para filtro</param>
        /// <param name="pstrRevendedorClassificacao">Classificação do Revendedor para buscar os preços</param>
        /// <returns>Lista de Produto</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLProdutoCompleto> ListarCompleto(MLProdutoCompleto pobjMLProdutoCompleto, String pstrRevendedorClassificacao)
        {

            List<MLProdutoCompleto> lstRetorno = null;

            var cmdCommand = new FWCommand("USP_BLF_L_PRODUTO_COMPLETO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CODIGO", FWDbType.Varchar, 13));
                cmdCommand.Parameters["@PRD_C_CODIGO"].Value = pobjMLProdutoCompleto.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.CodigoUnidadeMedida))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_UNM_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@PRD_UNM_C_CODIGO"].Value = pobjMLProdutoCompleto.CodigoUnidadeMedida;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.CodigoSubgrupo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_SUB_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@PRD_SUB_C_CODIGO"].Value = pobjMLProdutoCompleto.CodigoSubgrupo;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.CodigoFabricante))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_FAB_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@PRD_FAB_C_CODIGO"].Value = pobjMLProdutoCompleto.CodigoFabricante;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@PRD_C_NOME"].Value = pobjMLProdutoCompleto.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.Link))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_LINK", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@PRD_C_LINK"].Value = pobjMLProdutoCompleto.Link;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.CaminhoImagem))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CAMINHO_IMAGEM", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@PRD_C_CAMINHO_IMAGEM"].Value = pobjMLProdutoCompleto.CaminhoImagem;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_DESCRICAO", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@PRD_C_DESCRICAO"].Value = pobjMLProdutoCompleto.Descricao;
            }
            if (pobjMLProdutoCompleto.ValorOriginal.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_N_VALOR_ORIGINAL", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Precision = 11;
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Scale = 3;
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Value = pobjMLProdutoCompleto.ValorOriginal.Value;
            }
            if (pobjMLProdutoCompleto.ValorPromocional.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_N_VALOR_PROMOCIONAL", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Precision = 11;
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Scale = 3;
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Value = pobjMLProdutoCompleto.ValorPromocional;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.Classificacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CLASSIFICACAO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@PRD_C_CLASSIFICACAO"].Value = pobjMLProdutoCompleto.Classificacao;
            }
            if (pobjMLProdutoCompleto.IsVisivel.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_VISIVEL", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_VISIVEL"].Value = pobjMLProdutoCompleto.IsVisivel.Value;
            }
            if (pobjMLProdutoCompleto.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_STATUS"].Value = pobjMLProdutoCompleto.IsStatus.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.GrupoCodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@GRU_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@GRU_C_CODIGO"].Value = pobjMLProdutoCompleto.GrupoCodigo;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.CategoriaCodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CAT_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@CAT_C_CODIGO"].Value = pobjMLProdutoCompleto.CategoriaCodigo;
            }
            if (!string.IsNullOrEmpty(pstrRevendedorClassificacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_CLASSIFICACAO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@REV_C_CLASSIFICACAO"].Value = pstrRevendedorClassificacao;
            }
            if (pobjMLProdutoCompleto.TemImagem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_EXISTE_IMAGEM", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_EXISTE_IMAGEM"].Value = pobjMLProdutoCompleto.TemImagem.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLProdutoCompleto objRetorno = null;
                lstRetorno = new List<MLProdutoCompleto>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLProdutoCompleto();
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

        #region Listar Produto Completo Aleatorio
        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLProdutoCompleto">Parametros para filtro</param>
        /// <param name="pstrRevendedorClassificacao">Classificação do Revendedor para buscar os preços</param>
        /// <returns>Lista de Produto</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLProdutoCompleto> ListarCompletoAleatorio(MLProdutoCompleto pobjMLProdutoCompleto, String pstrRevendedorClassificacao, bool boolIsVitrine)
        {

            List<MLProdutoCompleto> lstRetorno = null;

            var cmdCommand = new FWCommand("USP_BLF_L_PRODUTO_COMPLETO_ALEATORIO");

            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (boolIsVitrine)
            {
                cmdCommand.Parameters.Add(new FWParameter("@TOP", FWDbType.Int32));
                cmdCommand.Parameters["@TOP"].Value = Convert.ToInt32(UTVitrine.ObterQuantidadeProdutosVitrine());
            }
            else
            {
                cmdCommand.Parameters.Add(new FWParameter("@TOP", FWDbType.Int32));
                cmdCommand.Parameters["@TOP"].Value = 200;
            }

            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CODIGO", FWDbType.Varchar, 13));
                cmdCommand.Parameters["@PRD_C_CODIGO"].Value = pobjMLProdutoCompleto.Codigo;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.CodigoUnidadeMedida))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_UNM_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@PRD_UNM_C_CODIGO"].Value = pobjMLProdutoCompleto.CodigoUnidadeMedida;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.CodigoSubgrupo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_SUB_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@PRD_SUB_C_CODIGO"].Value = pobjMLProdutoCompleto.CodigoSubgrupo;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.CodigoFabricante))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_FAB_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@PRD_FAB_C_CODIGO"].Value = pobjMLProdutoCompleto.CodigoFabricante;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@PRD_C_NOME"].Value = pobjMLProdutoCompleto.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.Link))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_LINK", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@PRD_C_LINK"].Value = pobjMLProdutoCompleto.Link;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.CaminhoImagem))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CAMINHO_IMAGEM", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@PRD_C_CAMINHO_IMAGEM"].Value = pobjMLProdutoCompleto.CaminhoImagem;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_DESCRICAO", FWDbType.Varchar, -1));
                cmdCommand.Parameters["@PRD_C_DESCRICAO"].Value = pobjMLProdutoCompleto.Descricao;
            }
            if (pobjMLProdutoCompleto.ValorOriginal.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_N_VALOR_ORIGINAL", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Precision = 11;
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Scale = 3;
                cmdCommand.Parameters["@PRD_N_VALOR_ORIGINAL"].Value = pobjMLProdutoCompleto.ValorOriginal.Value;
            }
            if (pobjMLProdutoCompleto.ValorPromocional.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_N_VALOR_PROMOCIONAL", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Precision = 11;
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Scale = 3;
                cmdCommand.Parameters["@PRD_N_VALOR_PROMOCIONAL"].Value = pobjMLProdutoCompleto.ValorPromocional;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.Classificacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CLASSIFICACAO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@PRD_C_CLASSIFICACAO"].Value = pobjMLProdutoCompleto.Classificacao;
            }
            if (pobjMLProdutoCompleto.IsVisivel.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_VISIVEL", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_VISIVEL"].Value = pobjMLProdutoCompleto.IsVisivel.Value;
            }
            if (pobjMLProdutoCompleto.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_STATUS"].Value = pobjMLProdutoCompleto.IsStatus.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.GrupoCodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@GRU_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@GRU_C_CODIGO"].Value = pobjMLProdutoCompleto.GrupoCodigo;
            }
            if (!string.IsNullOrEmpty(pobjMLProdutoCompleto.CategoriaCodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CAT_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@CAT_C_CODIGO"].Value = pobjMLProdutoCompleto.CategoriaCodigo;
            }
            if (!string.IsNullOrEmpty(pstrRevendedorClassificacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_CLASSIFICACAO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@REV_C_CLASSIFICACAO"].Value = pstrRevendedorClassificacao;
            }
            if (pobjMLProdutoCompleto.IsDestaque.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_DESTAQUE", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_DESTAQUE"].Value = pobjMLProdutoCompleto.IsDestaque.Value;
            }
            if (pobjMLProdutoCompleto.IsSuperOferta.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_SUPER", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_SUPER"].Value = pobjMLProdutoCompleto.IsSuperOferta.Value;
            }
            if (pobjMLProdutoCompleto.TemImagem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_B_EXISTE_IMAGEM", FWDbType.Boolean));
                cmdCommand.Parameters["@PRD_B_EXISTE_IMAGEM"].Value = pobjMLProdutoCompleto.TemImagem.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLProdutoCompleto objRetorno = null;
                lstRetorno = new List<MLProdutoCompleto>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLProdutoCompleto();
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

        #region Obter Completo
        /// <summary> 
        /// Executa a stored procedure para retornar um registro específico
        /// </summary> 
        /// <param name="pstrCodigo">Codigo</param>
        /// <param name="pstrRevendedorClassificacao">Classificação do Revendedor para buscar os preços</param>
        /// <returns>Produto</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLProdutoCompleto ObterCompleto(string pstrCodigo, string pstrRevendedorClassificacao)
        {

            MLProdutoCompleto objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_PRODUTO_COMPLETO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@PRD_C_CODIGO", FWDbType.Varchar, 13));
            cmdCommand.Parameters["@PRD_C_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@REV_C_CLASSIFICACAO", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@REV_C_CLASSIFICACAO"].Value = pstrRevendedorClassificacao;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_C_CODIGO", FWDbType.Varchar, 13));
            cmdCommand.Parameters["@OUT_PRD_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_UNM_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_PRD_UNM_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_SUB_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_PRD_SUB_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_FAB_C_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_PRD_FAB_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_C_NOME", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_PRD_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_C_LINK", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_PRD_C_LINK"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_C_CAMINHO_IMAGEM", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_PRD_C_CAMINHO_IMAGEM"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_C_DESCRICAO", FWDbType.Varchar, -1));
            cmdCommand.Parameters["@OUT_PRD_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_N_VALOR_ORIGINAL", FWDbType.Decimal, 11));
            cmdCommand.Parameters["@OUT_PRD_N_VALOR_ORIGINAL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_N_VALOR_PROMOCIONAL", FWDbType.Decimal, 11));
            cmdCommand.Parameters["@OUT_PRD_N_VALOR_PROMOCIONAL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_C_CLASSIFICACAO", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@OUT_PRD_C_CLASSIFICACAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_B_VISIVEL", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_PRD_B_VISIVEL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_PRD_B_STATUS"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_GRU_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_GRU_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_SUB_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_SUB_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FAB_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_FAB_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_CAT_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_CAT_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_UNM_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_UNM_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_GRU_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_GRU_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_CAT_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_CAT_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MN_VALOR_DE", FWDbType.Decimal, 11));
            cmdCommand.Parameters["@OUT_MN_VALOR_DE"].Precision = 11;
            cmdCommand.Parameters["@OUT_MN_VALOR_DE"].Scale = 3;
            cmdCommand.Parameters["@OUT_MN_VALOR_DE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MN_VALOR_POR", FWDbType.Decimal, 11));
            cmdCommand.Parameters["@OUT_MN_VALOR_POR"].Precision = 11;
            cmdCommand.Parameters["@OUT_MN_VALOR_POR"].Scale = 3;
            cmdCommand.Parameters["@OUT_MN_VALOR_POR"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_B_DESTAQUE", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_PRD_B_DESTAQUE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_PRD_B_EXISTE_IMAGEM", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_PRD_B_EXISTE_IMAGEM"].Direction = ParameterDirection.Output;            

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_PRD_C_CODIGO") && cmdCommand.Parameters["@OUT_PRD_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLProdutoCompleto();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_PRD_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_PRD_UNM_C_CODIGO") && cmdCommand.Parameters["@OUT_PRD_UNM_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoUnidadeMedida = cmdCommand.Parameters["@OUT_PRD_UNM_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_SUB_C_CODIGO") && cmdCommand.Parameters["@OUT_PRD_SUB_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoSubgrupo = cmdCommand.Parameters["@OUT_PRD_SUB_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_FAB_C_CODIGO") && cmdCommand.Parameters["@OUT_PRD_FAB_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoFabricante = cmdCommand.Parameters["@OUT_PRD_FAB_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_C_NOME") && cmdCommand.Parameters["@OUT_PRD_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.Nome = cmdCommand.Parameters["@OUT_PRD_C_NOME"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_C_LINK") && cmdCommand.Parameters["@OUT_PRD_C_LINK"].Value != System.DBNull.Value)
                    {
                        objRetorno.Link = cmdCommand.Parameters["@OUT_PRD_C_LINK"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_C_CAMINHO_IMAGEM") && cmdCommand.Parameters["@OUT_PRD_C_CAMINHO_IMAGEM"].Value != System.DBNull.Value)
                    {
                        objRetorno.CaminhoImagem = cmdCommand.Parameters["@OUT_PRD_C_CAMINHO_IMAGEM"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_C_DESCRICAO") && cmdCommand.Parameters["@OUT_PRD_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Descricao = cmdCommand.Parameters["@OUT_PRD_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_N_VALOR_ORIGINAL") && cmdCommand.Parameters["@OUT_PRD_N_VALOR_ORIGINAL"].Value != System.DBNull.Value)
                    {
                        objRetorno.ValorOriginal = Convert.ToDecimal(cmdCommand.Parameters["@OUT_PRD_N_VALOR_ORIGINAL"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_N_VALOR_PROMOCIONAL") && cmdCommand.Parameters["@OUT_PRD_N_VALOR_PROMOCIONAL"].Value != System.DBNull.Value)
                    {
                        objRetorno.ValorPromocional = Convert.ToDecimal(cmdCommand.Parameters["@OUT_PRD_N_VALOR_PROMOCIONAL"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_C_CLASSIFICACAO") && cmdCommand.Parameters["@OUT_PRD_C_CLASSIFICACAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Classificacao = cmdCommand.Parameters["@OUT_PRD_C_CLASSIFICACAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_B_VISIVEL") && cmdCommand.Parameters["@OUT_PRD_B_VISIVEL"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsVisivel = Convert.ToBoolean(cmdCommand.Parameters["@OUT_PRD_B_VISIVEL"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_B_STATUS") && cmdCommand.Parameters["@OUT_PRD_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatus = Convert.ToBoolean(cmdCommand.Parameters["@OUT_PRD_B_STATUS"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_GRU_C_DESCRICAO") && cmdCommand.Parameters["@OUT_GRU_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.GrupoDescricao = Convert.ToString(cmdCommand.Parameters["@OUT_GRU_C_DESCRICAO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_SUB_C_DESCRICAO") && cmdCommand.Parameters["@OUT_SUB_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.SubGrupoDescricao = Convert.ToString(cmdCommand.Parameters["@OUT_SUB_C_DESCRICAO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_FAB_C_DESCRICAO") && cmdCommand.Parameters["@OUT_FAB_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.FabricanteDescricao = Convert.ToString(cmdCommand.Parameters["@OUT_FAB_C_DESCRICAO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_CAT_C_DESCRICAO") && cmdCommand.Parameters["@OUT_CAT_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CategoriaDescricao = Convert.ToString(cmdCommand.Parameters["@OUT_CAT_C_DESCRICAO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_UNM_C_DESCRICAO") && cmdCommand.Parameters["@OUT_UNM_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.UnidadeMedidaDescricao = Convert.ToString(cmdCommand.Parameters["@OUT_UNM_C_DESCRICAO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_GRU_C_CODIGO") && cmdCommand.Parameters["@OUT_GRU_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.GrupoCodigo = Convert.ToString(cmdCommand.Parameters["@OUT_GRU_C_CODIGO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_CAT_C_CODIGO") && cmdCommand.Parameters["@OUT_CAT_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CategoriaCodigo = Convert.ToString(cmdCommand.Parameters["@OUT_CAT_C_CODIGO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_MN_VALOR_DE") && cmdCommand.Parameters["@OUT_MN_VALOR_DE"].Value != System.DBNull.Value)
                    {
                        objRetorno.ValorDe = Convert.ToDecimal(cmdCommand.Parameters["@OUT_MN_VALOR_DE"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_MN_VALOR_POR") && cmdCommand.Parameters["@OUT_MN_VALOR_POR"].Value != System.DBNull.Value)
                    {
                        objRetorno.ValorPor = Convert.ToDecimal(cmdCommand.Parameters["@OUT_MN_VALOR_POR"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_B_DESTAQUE") && cmdCommand.Parameters["@OUT_PRD_B_DESTAQUE"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsDestaque = Convert.ToBoolean(cmdCommand.Parameters["@OUT_PRD_B_DESTAQUE"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_PRD_B_EXISTE_IMAGEM") && cmdCommand.Parameters["@OUT_PRD_B_EXISTE_IMAGEM"].Value != System.DBNull.Value)
                    {
                        objRetorno.TemImagem = Convert.ToBoolean(cmdCommand.Parameters["@OUT_PRD_B_EXISTE_IMAGEM"].Value);
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

        #region ListarBusca

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLProduto">Parametros para filtro</param>
        /// <param name="pstrRevendedorClassificacao">Classificação do Revendedor para buscar os preços</param>
        /// <returns>Lista de Produto</returns> 
        /// <user>GeradorVm2 [2.3.1.1]</user>
        public List<MLProdutoBusca> ListarBusca(string strFabricanteCod, string strCategoriaCod, string strNomeProduto, bool bVisivel)
        {

            List<MLProdutoBusca> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_PRODUTO_BUSCA");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(strFabricanteCod))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_FAB_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@PRD_FAB_C_CODIGO"].Value = strFabricanteCod;
            }
            if (!string.IsNullOrEmpty(strCategoriaCod))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CAT_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@CAT_C_CODIGO"].Value = strCategoriaCod;
            }
            if (!string.IsNullOrEmpty(strNomeProduto))
            {
                cmdCommand.Parameters.Add(new FWParameter("@PRD_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@PRD_C_NOME"].Value = strNomeProduto;
            }           
            
            cmdCommand.Parameters.Add(new FWParameter("@PRD_B_VISIVEL", FWDbType.Boolean));
            cmdCommand.Parameters["@PRD_B_VISIVEL"].Value = bVisivel;
             

            IDataReader idrRetorno = null;
            try
            {
                MLProdutoBusca objRetorno = null;
                lstRetorno = new List<MLProdutoBusca>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLProdutoBusca();
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

    }
}


