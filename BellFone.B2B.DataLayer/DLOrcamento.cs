using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para Orcamento 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class DLOrcamento : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.0]</user> 
        public DLOrcamento()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }

        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLOrcamento">Parametros para filtro</param>
        /// <returns>Lista de Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLOrcamento> Listar(MLOrcamento pobjMLOrcamento)
        {

            List<MLOrcamento> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ORCAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLOrcamento.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORC_N_CODIGO"].Value = pobjMLOrcamento.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Origem))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_ORIGEM", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_C_ORIGEM"].Value = pobjMLOrcamento.Origem;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.OrcamentoLegado))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_ORCAMENTO_LEGADO", FWDbType.Varchar, 6));
                cmdCommand.Parameters["@ORC_C_ORCAMENTO_LEGADO"].Value = pobjMLOrcamento.OrcamentoLegado;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Fopcodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_FOP_C_CODIGO", FWDbType.Varchar, 2));
                cmdCommand.Parameters["@ORC_FOP_C_CODIGO"].Value = pobjMLOrcamento.Fopcodigo;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Concodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_CON_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_CON_C_CODIGO"].Value = pobjMLOrcamento.Concodigo;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@ORC_REV_C_CODIGO"].Value = pobjMLOrcamento.CodigoRevendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoVendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_VEN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_VEN_C_CODIGO"].Value = pobjMLOrcamento.CodigoVendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.TituloOrcamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_TITULO_ORCAMENTO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@ORC_C_TITULO_ORCAMENTO"].Value = pobjMLOrcamento.TituloOrcamento;
            }
            if (pobjMLOrcamento.DataEmissao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_D_EMISSAO", FWDbType.DateTime));
                cmdCommand.Parameters["@ORC_D_EMISSAO"].Value = pobjMLOrcamento.DataEmissao.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.NomeConsumidor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_NOME_CONSUMIDOR", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@ORC_C_NOME_CONSUMIDOR"].Value = pobjMLOrcamento.NomeConsumidor;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Endereco))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_ENDERECO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@ORC_C_ENDERECO"].Value = pobjMLOrcamento.Endereco;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Contato))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_CONTATO", FWDbType.Varchar, 20));
                cmdCommand.Parameters["@ORC_C_CONTATO"].Value = pobjMLOrcamento.Contato;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Telefone))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_TELEFONE", FWDbType.Varchar, 20));
                cmdCommand.Parameters["@ORC_C_TELEFONE"].Value = pobjMLOrcamento.Telefone;
            }
            if (pobjMLOrcamento.IsStatusMigracao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_B_STATUS_MIGRACAO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORC_B_STATUS_MIGRACAO"].Value = pobjMLOrcamento.IsStatusMigracao.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoTipoNegocio))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_TPN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_TPN_C_CODIGO"].Value = pobjMLOrcamento.CodigoTipoNegocio;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoRegiao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_REG_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_REG_C_CODIGO"].Value = pobjMLOrcamento.CodigoRegiao;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoRegiao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_REG_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_REG_C_CODIGO"].Value = pobjMLOrcamento.CodigoRegiao;
            }

            cmdCommand.Parameters.Add(new FWParameter("@ORC_B_TEMPORARIO", FWDbType.Boolean));
            cmdCommand.Parameters["@ORC_B_TEMPORARIO"].Value = pobjMLOrcamento.IsTemporario;

            if (pobjMLOrcamento.GeradoVendedor.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_B_GERADO_VENDEDOR", FWDbType.Boolean));
                cmdCommand.Parameters["@ORC_B_GERADO_VENDEDOR"].Value = pobjMLOrcamento.GeradoVendedor;
            }

            if (pobjMLOrcamento.IsAlterado.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_B_ALTERADO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORC_B_ALTERADO"].Value = pobjMLOrcamento.IsAlterado;
            } 

            IDataReader idrRetorno = null;
            try
            {
                MLOrcamento objRetorno = null;
                lstRetorno = new List<MLOrcamento>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLOrcamento();
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
        /// <returns>Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLOrcamento Obter(decimal pdecCodigo)
        {

            MLOrcamento objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_ORCAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@ORC_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@ORC_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_ORC_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_C_ORIGEM", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_ORC_C_ORIGEM"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_C_ORCAMENTO_LEGADO", FWDbType.Varchar, 6));
            cmdCommand.Parameters["@OUT_ORC_C_ORCAMENTO_LEGADO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_FOP_C_CODIGO", FWDbType.Varchar, 2));
            cmdCommand.Parameters["@OUT_ORC_FOP_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_CON_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_ORC_CON_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_REV_C_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_ORC_REV_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_VEN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_ORC_VEN_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_C_TITULO_ORCAMENTO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_ORC_C_TITULO_ORCAMENTO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_D_EMISSAO", FWDbType.DateTime));
            cmdCommand.Parameters["@OUT_ORC_D_EMISSAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_C_NOME_CONSUMIDOR", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_ORC_C_NOME_CONSUMIDOR"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_C_ENDERECO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_ORC_C_ENDERECO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_C_CONTATO", FWDbType.Varchar, 20));
            cmdCommand.Parameters["@OUT_ORC_C_CONTATO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_C_TELEFONE", FWDbType.Varchar, 20));
            cmdCommand.Parameters["@OUT_ORC_C_TELEFONE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_B_STATUS_MIGRACAO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_ORC_B_STATUS_MIGRACAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_TPN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_ORC_TPN_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_REG_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_ORC_REG_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_B_TEMPORARIO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_ORC_B_TEMPORARIO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_B_GERADO_VENDEDOR", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_ORC_B_GERADO_VENDEDOR"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_B_ALTERADO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_ORC_B_ALTERADO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_ORC_N_CODIGO") && cmdCommand.Parameters["@OUT_ORC_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLOrcamento();

                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_ORC_N_CODIGO"].Value);
                    if (cmdCommand.Parameters.Contains("@OUT_ORC_C_ORIGEM") && cmdCommand.Parameters["@OUT_ORC_C_ORIGEM"].Value != System.DBNull.Value)
                    {
                        objRetorno.Origem = cmdCommand.Parameters["@OUT_ORC_C_ORIGEM"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_C_ORCAMENTO_LEGADO") && cmdCommand.Parameters["@OUT_ORC_C_ORCAMENTO_LEGADO"].Value != System.DBNull.Value)
                    {
                        objRetorno.OrcamentoLegado = cmdCommand.Parameters["@OUT_ORC_C_ORCAMENTO_LEGADO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_FOP_C_CODIGO") && cmdCommand.Parameters["@OUT_ORC_FOP_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Fopcodigo = cmdCommand.Parameters["@OUT_ORC_FOP_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_CON_C_CODIGO") && cmdCommand.Parameters["@OUT_ORC_CON_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Concodigo = cmdCommand.Parameters["@OUT_ORC_CON_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_REV_C_CODIGO") && cmdCommand.Parameters["@OUT_ORC_REV_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoRevendedor = cmdCommand.Parameters["@OUT_ORC_REV_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_VEN_C_CODIGO") && cmdCommand.Parameters["@OUT_ORC_VEN_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoVendedor = cmdCommand.Parameters["@OUT_ORC_VEN_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_C_TITULO_ORCAMENTO") && cmdCommand.Parameters["@OUT_ORC_C_TITULO_ORCAMENTO"].Value != System.DBNull.Value)
                    {
                        objRetorno.TituloOrcamento = cmdCommand.Parameters["@OUT_ORC_C_TITULO_ORCAMENTO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_D_EMISSAO") && cmdCommand.Parameters["@OUT_ORC_D_EMISSAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.DataEmissao = Convert.ToDateTime(cmdCommand.Parameters["@OUT_ORC_D_EMISSAO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_C_NOME_CONSUMIDOR") && cmdCommand.Parameters["@OUT_ORC_C_NOME_CONSUMIDOR"].Value != System.DBNull.Value)
                    {
                        objRetorno.NomeConsumidor = cmdCommand.Parameters["@OUT_ORC_C_NOME_CONSUMIDOR"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_C_ENDERECO") && cmdCommand.Parameters["@OUT_ORC_C_ENDERECO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Endereco = cmdCommand.Parameters["@OUT_ORC_C_ENDERECO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_C_CONTATO") && cmdCommand.Parameters["@OUT_ORC_C_CONTATO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Contato = cmdCommand.Parameters["@OUT_ORC_C_CONTATO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_C_TELEFONE") && cmdCommand.Parameters["@OUT_ORC_C_TELEFONE"].Value != System.DBNull.Value)
                    {
                        objRetorno.Telefone = cmdCommand.Parameters["@OUT_ORC_C_TELEFONE"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_B_STATUS_MIGRACAO") && cmdCommand.Parameters["@OUT_ORC_B_STATUS_MIGRACAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatusMigracao = Convert.ToBoolean(cmdCommand.Parameters["@OUT_ORC_B_STATUS_MIGRACAO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_TPN_C_CODIGO") && cmdCommand.Parameters["@OUT_ORC_TPN_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoTipoNegocio = cmdCommand.Parameters["@OUT_ORC_TPN_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_REG_C_CODIGO") && cmdCommand.Parameters["@OUT_ORC_REG_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoRegiao = cmdCommand.Parameters["@OUT_ORC_REG_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_B_TEMPORARIO") && cmdCommand.Parameters["@OUT_ORC_B_TEMPORARIO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsTemporario = Convert.ToBoolean(cmdCommand.Parameters["@OUT_ORC_B_TEMPORARIO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_B_GERADO_VENDEDOR") && cmdCommand.Parameters["@OUT_ORC_B_GERADO_VENDEDOR"].Value != System.DBNull.Value)
                    {
                        objRetorno.GeradoVendedor = Convert.ToBoolean(cmdCommand.Parameters["@OUT_ORC_B_GERADO_VENDEDOR"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_B_ALTERADO") && cmdCommand.Parameters["@OUT_ORC_B_ALTERADO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAlterado = Convert.ToBoolean(cmdCommand.Parameters["@OUT_ORC_B_ALTERADO"].Value);
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
        /// <returns>Quantidade de Registro Excluídos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Excluir(decimal pdecCodigo)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_ORCAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@ORC_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@ORC_N_CODIGO"].Value = pdecCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLOrcamento">Orcamento para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLOrcamento pobjMLOrcamento)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_ORCAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLOrcamento.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORC_N_CODIGO"].Value = pobjMLOrcamento.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Origem))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_ORIGEM", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_C_ORIGEM"].Value = pobjMLOrcamento.Origem;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.OrcamentoLegado))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_ORCAMENTO_LEGADO", FWDbType.Varchar, 6));
                cmdCommand.Parameters["@ORC_C_ORCAMENTO_LEGADO"].Value = pobjMLOrcamento.OrcamentoLegado;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Fopcodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_FOP_C_CODIGO", FWDbType.Varchar, 2));
                cmdCommand.Parameters["@ORC_FOP_C_CODIGO"].Value = pobjMLOrcamento.Fopcodigo;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Concodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_CON_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_CON_C_CODIGO"].Value = pobjMLOrcamento.Concodigo;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@ORC_REV_C_CODIGO"].Value = pobjMLOrcamento.CodigoRevendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoVendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_VEN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_VEN_C_CODIGO"].Value = pobjMLOrcamento.CodigoVendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.TituloOrcamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_TITULO_ORCAMENTO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@ORC_C_TITULO_ORCAMENTO"].Value = pobjMLOrcamento.TituloOrcamento;
            }
            if (pobjMLOrcamento.DataEmissao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_D_EMISSAO", FWDbType.DateTime));
                cmdCommand.Parameters["@ORC_D_EMISSAO"].Value = pobjMLOrcamento.DataEmissao.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.NomeConsumidor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_NOME_CONSUMIDOR", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@ORC_C_NOME_CONSUMIDOR"].Value = pobjMLOrcamento.NomeConsumidor;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Endereco))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_ENDERECO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@ORC_C_ENDERECO"].Value = pobjMLOrcamento.Endereco;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Contato))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_CONTATO", FWDbType.Varchar, 20));
                cmdCommand.Parameters["@ORC_C_CONTATO"].Value = pobjMLOrcamento.Contato;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Telefone))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_TELEFONE", FWDbType.Varchar, 20));
                cmdCommand.Parameters["@ORC_C_TELEFONE"].Value = pobjMLOrcamento.Telefone;
            }
            if (pobjMLOrcamento.IsStatusMigracao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_B_STATUS_MIGRACAO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORC_B_STATUS_MIGRACAO"].Value = pobjMLOrcamento.IsStatusMigracao.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoTipoNegocio))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_TPN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_TPN_C_CODIGO"].Value = pobjMLOrcamento.CodigoTipoNegocio;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoRegiao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_REG_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_REG_C_CODIGO"].Value = pobjMLOrcamento.CodigoRegiao;
            }
            cmdCommand.Parameters.Add(new FWParameter("@ORC_B_TEMPORARIO", FWDbType.Boolean));
            cmdCommand.Parameters["@ORC_B_TEMPORARIO"].Value = pobjMLOrcamento.IsTemporario;

            if (pobjMLOrcamento.GeradoVendedor.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_B_GERADO_VENDEDOR", FWDbType.Boolean));
                cmdCommand.Parameters["@ORC_B_GERADO_VENDEDOR"].Value = pobjMLOrcamento.GeradoVendedor;
            }

            if (pobjMLOrcamento.IsAlterado.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_B_ALTERADO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORC_B_ALTERADO"].Value = pobjMLOrcamento.IsAlterado;
            }
            if (pobjMLOrcamento.MaoObra.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_N_MAO_OBRA", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@ORC_N_MAO_OBRA"].Precision = 11;
                cmdCommand.Parameters["@ORC_N_MAO_OBRA"].Scale = 3;
                cmdCommand.Parameters["@ORC_N_MAO_OBRA"].Value = pobjMLOrcamento.MaoObra.Value;
            }
            

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLOrcamento">Orcamento para inserir</param>
        /// <returns>Código Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public decimal Inserir(MLOrcamento pobjMLOrcamento)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_ORCAMENTO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Origem))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_ORIGEM", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_C_ORIGEM"].Value = pobjMLOrcamento.Origem;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.OrcamentoLegado))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_ORCAMENTO_LEGADO", FWDbType.Varchar, 6));
                cmdCommand.Parameters["@ORC_C_ORCAMENTO_LEGADO"].Value = pobjMLOrcamento.OrcamentoLegado;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Fopcodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_FOP_C_CODIGO", FWDbType.Varchar, 2));
                cmdCommand.Parameters["@ORC_FOP_C_CODIGO"].Value = pobjMLOrcamento.Fopcodigo;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Concodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_CON_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_CON_C_CODIGO"].Value = pobjMLOrcamento.Concodigo;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@ORC_REV_C_CODIGO"].Value = pobjMLOrcamento.CodigoRevendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoVendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_VEN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_VEN_C_CODIGO"].Value = pobjMLOrcamento.CodigoVendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.TituloOrcamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_TITULO_ORCAMENTO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@ORC_C_TITULO_ORCAMENTO"].Value = pobjMLOrcamento.TituloOrcamento;
            }
            if (pobjMLOrcamento.DataEmissao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_D_EMISSAO", FWDbType.DateTime));
                cmdCommand.Parameters["@ORC_D_EMISSAO"].Value = pobjMLOrcamento.DataEmissao.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.NomeConsumidor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_NOME_CONSUMIDOR", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@ORC_C_NOME_CONSUMIDOR"].Value = pobjMLOrcamento.NomeConsumidor;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Endereco))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_ENDERECO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@ORC_C_ENDERECO"].Value = pobjMLOrcamento.Endereco;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Contato))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_CONTATO", FWDbType.Varchar, 20));
                cmdCommand.Parameters["@ORC_C_CONTATO"].Value = pobjMLOrcamento.Contato;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Telefone))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_TELEFONE", FWDbType.Varchar, 20));
                cmdCommand.Parameters["@ORC_C_TELEFONE"].Value = pobjMLOrcamento.Telefone;
            }
            if (pobjMLOrcamento.IsStatusMigracao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_B_STATUS_MIGRACAO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORC_B_STATUS_MIGRACAO"].Value = pobjMLOrcamento.IsStatusMigracao.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoTipoNegocio))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_TPN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_TPN_C_CODIGO"].Value = pobjMLOrcamento.CodigoTipoNegocio;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoRegiao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_REG_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_REG_C_CODIGO"].Value = pobjMLOrcamento.CodigoRegiao;
            }
            cmdCommand.Parameters.Add(new FWParameter("@ORC_B_TEMPORARIO", FWDbType.Boolean));
            cmdCommand.Parameters["@ORC_B_TEMPORARIO"].Value = pobjMLOrcamento.IsTemporario;

            if (pobjMLOrcamento.GeradoVendedor.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_B_GERADO_VENDEDOR", FWDbType.Boolean));
                cmdCommand.Parameters["@ORC_B_GERADO_VENDEDOR"].Value = pobjMLOrcamento.GeradoVendedor;
            }

            if (pobjMLOrcamento.IsAlterado.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_B_ALTERADO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORC_B_ALTERADO"].Value = pobjMLOrcamento.IsAlterado;
            }
            

            return Convert.ToDecimal(conProvider.ExecuteScalar(cmdCommand));

        }

        #endregion



        #region Listar Filtro

        /// <summary> 
        /// Executa a Stored Procedure de Listagem para o Filtro
        /// </summary> 
        /// <param name="pstrRevendedor"></param>
        /// <param name="pstrVendedor"></param>
        /// <param name="pstrTituloOrcamento"></param>
        /// <param name="pdteOrcamentoDe"></param>
        /// <param name="pdteOrcamentoAte"></param>
        /// <param name="pdecOrcamentoCodigoDe"></param>
        /// <param name="pdecOrcamentoCodigoAte"></param>
        /// <param name="pstrBellfoneCodigo"></param>
        /// <param name="pbolIsTemporario"></param>
        /// <param name="pintDiasLimite"></param>
        /// <returns>Lista de Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLOrcamentoCompleto> Listar(String pstrRevendedor,
                                        String pstrVendedor,
                                        String pstrTituloOrcamento,
                                        DateTime? pdteOrcamentoDe,
                                        DateTime? pdteOrcamentoAte,
                                        Decimal? pdecOrcamentoCodigoDe,
                                        Decimal? pdecOrcamentoCodigoAte,
                                        String pstrBellfoneCodigo,
                                       Boolean pbolIsTemporario,
                                        int? pintDiasLimite)
        {

            List<MLOrcamentoCompleto> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ORCAMENTO_FILTRAR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pdecOrcamentoCodigoDe != null && pdecOrcamentoCodigoDe > 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CODIGO_DE", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@CODIGO_DE"].Value = pdecOrcamentoCodigoDe;
            }
            if (pdecOrcamentoCodigoAte != null && pdecOrcamentoCodigoAte > 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("@CODIGO_ATE", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@CODIGO_ATE"].Value = pdecOrcamentoCodigoAte;
            }
            if (!String.IsNullOrEmpty(pstrBellfoneCodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@CODIGO_LEGADO", FWDbType.Varchar, 6));
                cmdCommand.Parameters["@CODIGO_LEGADO"].Value = pstrBellfoneCodigo;
            }
            if (!String.IsNullOrEmpty(pstrRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_REV_C_CODIGO", FWDbType.Varchar));
                cmdCommand.Parameters["@ORC_REV_C_CODIGO"].Value = pstrRevendedor;
            }
            if (!String.IsNullOrEmpty(pstrVendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_VEN_C_CODIGO", FWDbType.Varchar));
                cmdCommand.Parameters["@ORC_VEN_C_CODIGO"].Value = pstrVendedor;
            }
            if (!String.IsNullOrEmpty(pstrTituloOrcamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_TITULO_ORCAMENTO", FWDbType.Varchar));
                cmdCommand.Parameters["@ORC_C_TITULO_ORCAMENTO"].Value = pstrTituloOrcamento;
            }
            if (pdteOrcamentoDe != null && pdteOrcamentoDe > DateTime.MinValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@DATA_DE", FWDbType.DateTime));
                cmdCommand.Parameters["@DATA_DE"].Value = pdteOrcamentoDe;
            }
            if (pdteOrcamentoAte != null && pdteOrcamentoAte > DateTime.MinValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@DATA_ATE", FWDbType.DateTime));
                cmdCommand.Parameters["@DATA_ATE"].Value = pdteOrcamentoAte;
            }
            cmdCommand.Parameters.Add(new FWParameter("@ORC_B_TEMPORARIO", FWDbType.Boolean));
            cmdCommand.Parameters["@ORC_B_TEMPORARIO"].Value = pbolIsTemporario;

            if (pintDiasLimite.HasValue && pintDiasLimite > 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("@DIAS_LIMITE", FWDbType.Int32));
                cmdCommand.Parameters["@DIAS_LIMITE"].Value = pintDiasLimite;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLOrcamentoCompleto objRetorno = null;
                lstRetorno = new List<MLOrcamentoCompleto>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLOrcamentoCompleto();
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

        #region Listar por Usuario de Revendedor

        /// <summary> 
        /// Executa a Stored Procedure de Listagem para o Filtro
        /// </summary> 
        /// <param name="pobjMLOrcamento"></param>
        /// <param name="pdecUsuario"></param>
        /// <returns>Lista de Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLOrcamento> ListarPorUsuarioRevendedor(String pstrRevendedor, bool pbolTemporario)
        {

            List<MLOrcamento> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ORCAMENTO_REVENDEDOR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;


            if (!string.IsNullOrEmpty(pstrRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@ORC_REV_C_CODIGO"].Value = pstrRevendedor;
            }

            cmdCommand.Parameters.Add(new FWParameter("@ORC_B_TEMPORARIO", FWDbType.Boolean));
            cmdCommand.Parameters["@ORC_B_TEMPORARIO"].Value = pbolTemporario;

            IDataReader idrRetorno = null;
            try
            {
                MLOrcamento objRetorno = null;
                lstRetorno = new List<MLOrcamento>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLOrcamento();
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

        #region Listar por Usuario de Vendedor

        /// <summary> 
        /// Executa a Stored Procedure de Listagem para o Filtro
        /// </summary> 
        /// <param name="pobjMLOrcamento"></param>
        /// <param name="pdecUsuario"></param>
        /// <returns>Lista de Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLOrcamento> ListarPorUsuarioVendedor(String pstrVendedor, bool pbolTemporario)
        {

            List<MLOrcamento> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ORCAMENTO_VENDEDOR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;


            if (!string.IsNullOrEmpty(pstrVendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_VEN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_VEN_C_CODIGO"].Value = pstrVendedor;
            }
            cmdCommand.Parameters.Add(new FWParameter("@ORC_B_TEMPORARIO", FWDbType.Boolean));
            cmdCommand.Parameters["@ORC_B_TEMPORARIO"].Value = pbolTemporario;

            IDataReader idrRetorno = null;
            try
            {
                MLOrcamento objRetorno = null;
                lstRetorno = new List<MLOrcamento>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLOrcamento();
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

        #region Completo

        #region Listar Completo

        /// <summary> 
        /// Retorna a lista de orcamentos completo somente não vencidos
        /// </summary> 
        /// <param name="pobjMLOrcamento">Parametros para filtro</param>
        /// <returns>Lista de Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLOrcamentoCompleto> ListarCompleto(MLOrcamento pobjMLOrcamento, int? pintDiasLimite)
        {

            List<MLOrcamentoCompleto> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ORCAMENTO_COMPLETO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLOrcamento.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORC_N_CODIGO"].Value = pobjMLOrcamento.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Origem))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_ORIGEM", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_C_ORIGEM"].Value = pobjMLOrcamento.Origem;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.OrcamentoLegado))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_ORCAMENTO_LEGADO", FWDbType.Varchar, 6));
                cmdCommand.Parameters["@ORC_C_ORCAMENTO_LEGADO"].Value = pobjMLOrcamento.OrcamentoLegado;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Fopcodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_FOP_C_CODIGO", FWDbType.Varchar, 2));
                cmdCommand.Parameters["@ORC_FOP_C_CODIGO"].Value = pobjMLOrcamento.Fopcodigo;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Concodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_CON_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_CON_C_CODIGO"].Value = pobjMLOrcamento.Concodigo;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@ORC_REV_C_CODIGO"].Value = pobjMLOrcamento.CodigoRevendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoVendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_VEN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_VEN_C_CODIGO"].Value = pobjMLOrcamento.CodigoVendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.TituloOrcamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_TITULO_ORCAMENTO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@ORC_C_TITULO_ORCAMENTO"].Value = pobjMLOrcamento.TituloOrcamento;
            }
            if (pobjMLOrcamento.DataEmissao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_D_EMISSAO", FWDbType.DateTime));
                cmdCommand.Parameters["@ORC_D_EMISSAO"].Value = pobjMLOrcamento.DataEmissao.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.NomeConsumidor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_NOME_CONSUMIDOR", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@ORC_C_NOME_CONSUMIDOR"].Value = pobjMLOrcamento.NomeConsumidor;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Endereco))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_ENDERECO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@ORC_C_ENDERECO"].Value = pobjMLOrcamento.Endereco;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Contato))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_CONTATO", FWDbType.Varchar, 20));
                cmdCommand.Parameters["@ORC_C_CONTATO"].Value = pobjMLOrcamento.Contato;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.Telefone))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_C_TELEFONE", FWDbType.Varchar, 20));
                cmdCommand.Parameters["@ORC_C_TELEFONE"].Value = pobjMLOrcamento.Telefone;
            }
            if (pobjMLOrcamento.IsStatusMigracao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_B_STATUS_MIGRACAO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORC_B_STATUS_MIGRACAO"].Value = pobjMLOrcamento.IsStatusMigracao.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoTipoNegocio))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_TPN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_TPN_C_CODIGO"].Value = pobjMLOrcamento.CodigoTipoNegocio;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoRegiao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_REG_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_REG_C_CODIGO"].Value = pobjMLOrcamento.CodigoRegiao;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamento.CodigoRegiao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_REG_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORC_REG_C_CODIGO"].Value = pobjMLOrcamento.CodigoRegiao;
            }

            cmdCommand.Parameters.Add(new FWParameter("@ORC_B_TEMPORARIO", FWDbType.Boolean));
            cmdCommand.Parameters["@ORC_B_TEMPORARIO"].Value = pobjMLOrcamento.IsTemporario;

            if (pintDiasLimite.HasValue && pintDiasLimite > 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("@DIAS_LIMITE", FWDbType.Int32));
                cmdCommand.Parameters["@DIAS_LIMITE"].Value = pintDiasLimite;
            }
            if (pobjMLOrcamento.IsAlterado.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORC_B_ALTERADO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORC_B_ALTERADO"].Value = pobjMLOrcamento.IsAlterado.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLOrcamentoCompleto objRetorno = null;
                lstRetorno = new List<MLOrcamentoCompleto>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLOrcamentoCompleto();
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

        #region ObterCompleto

        /// <summary> 
        /// Executa a stored procedure para retornar um registro específico
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Orcamento</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLOrcamentoCompleto ObterCompleto(decimal pdecCodigo)
        {
            MLOrcamentoCompleto objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_ORCAMENTO_COMPLETO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@ORC_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@ORC_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_ORC_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_C_ORIGEM", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_ORC_C_ORIGEM"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_C_ORCAMENTO_LEGADO", FWDbType.Varchar, 6));
            cmdCommand.Parameters["@OUT_ORC_C_ORCAMENTO_LEGADO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_FOP_C_CODIGO", FWDbType.Varchar, 2));
            cmdCommand.Parameters["@OUT_ORC_FOP_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_CON_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_ORC_CON_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_REV_C_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_ORC_REV_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_VEN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_ORC_VEN_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_C_TITULO_ORCAMENTO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_ORC_C_TITULO_ORCAMENTO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_D_EMISSAO", FWDbType.DateTime));
            cmdCommand.Parameters["@OUT_ORC_D_EMISSAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_C_NOME_CONSUMIDOR", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_ORC_C_NOME_CONSUMIDOR"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_C_ENDERECO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_ORC_C_ENDERECO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_C_CONTATO", FWDbType.Varchar, 20));
            cmdCommand.Parameters["@OUT_ORC_C_CONTATO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_C_TELEFONE", FWDbType.Varchar, 20));
            cmdCommand.Parameters["@OUT_ORC_C_TELEFONE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_B_STATUS_MIGRACAO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_ORC_B_STATUS_MIGRACAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_TPN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_ORC_TPN_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_REG_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_ORC_REG_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_B_TEMPORARIO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_ORC_B_TEMPORARIO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_B_GERADO_VENDEDOR", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_ORC_B_GERADO_VENDEDOR"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_B_ALTERADO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_ORC_B_ALTERADO"].Direction = ParameterDirection.Output;

            cmdCommand.Parameters.Add(new FWParameter("@OUT_TPN_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_TPN_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REG_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_REG_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_RAZAO_SOCIAL", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_REV_C_RAZAO_SOCIAL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_CON_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_CON_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_FOP_C_DESCRICAO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_FOP_C_DESCRICAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_NOME", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_VEN_C_NOME"].Direction = ParameterDirection.Output;

            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORC_N_MAO_OBRA", FWDbType.Decimal, 11));
            cmdCommand.Parameters["@OUT_ORC_N_MAO_OBRA"].Precision = 11;
            cmdCommand.Parameters["@OUT_ORC_N_MAO_OBRA"].Scale = 3;
            cmdCommand.Parameters["@OUT_ORC_N_MAO_OBRA"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_ORC_N_CODIGO") && cmdCommand.Parameters["@OUT_ORC_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLOrcamentoCompleto();

                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_ORC_N_CODIGO"].Value);
                    if (cmdCommand.Parameters.Contains("@OUT_ORC_C_ORIGEM") && cmdCommand.Parameters["@OUT_ORC_C_ORIGEM"].Value != System.DBNull.Value)
                    {
                        objRetorno.Origem = cmdCommand.Parameters["@OUT_ORC_C_ORIGEM"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_C_ORCAMENTO_LEGADO") && cmdCommand.Parameters["@OUT_ORC_C_ORCAMENTO_LEGADO"].Value != System.DBNull.Value)
                    {
                        objRetorno.OrcamentoLegado = cmdCommand.Parameters["@OUT_ORC_C_ORCAMENTO_LEGADO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_FOP_C_CODIGO") && cmdCommand.Parameters["@OUT_ORC_FOP_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Fopcodigo = cmdCommand.Parameters["@OUT_ORC_FOP_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_CON_C_CODIGO") && cmdCommand.Parameters["@OUT_ORC_CON_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Concodigo = cmdCommand.Parameters["@OUT_ORC_CON_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_REV_C_CODIGO") && cmdCommand.Parameters["@OUT_ORC_REV_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoRevendedor = cmdCommand.Parameters["@OUT_ORC_REV_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_VEN_C_CODIGO") && cmdCommand.Parameters["@OUT_ORC_VEN_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoVendedor = cmdCommand.Parameters["@OUT_ORC_VEN_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_C_TITULO_ORCAMENTO") && cmdCommand.Parameters["@OUT_ORC_C_TITULO_ORCAMENTO"].Value != System.DBNull.Value)
                    {
                        objRetorno.TituloOrcamento = cmdCommand.Parameters["@OUT_ORC_C_TITULO_ORCAMENTO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_D_EMISSAO") && cmdCommand.Parameters["@OUT_ORC_D_EMISSAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.DataEmissao = Convert.ToDateTime(cmdCommand.Parameters["@OUT_ORC_D_EMISSAO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_C_NOME_CONSUMIDOR") && cmdCommand.Parameters["@OUT_ORC_C_NOME_CONSUMIDOR"].Value != System.DBNull.Value)
                    {
                        objRetorno.NomeConsumidor = cmdCommand.Parameters["@OUT_ORC_C_NOME_CONSUMIDOR"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_C_ENDERECO") && cmdCommand.Parameters["@OUT_ORC_C_ENDERECO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Endereco = cmdCommand.Parameters["@OUT_ORC_C_ENDERECO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_C_CONTATO") && cmdCommand.Parameters["@OUT_ORC_C_CONTATO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Contato = cmdCommand.Parameters["@OUT_ORC_C_CONTATO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_C_TELEFONE") && cmdCommand.Parameters["@OUT_ORC_C_TELEFONE"].Value != System.DBNull.Value)
                    {
                        objRetorno.Telefone = cmdCommand.Parameters["@OUT_ORC_C_TELEFONE"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_B_STATUS_MIGRACAO") && cmdCommand.Parameters["@OUT_ORC_B_STATUS_MIGRACAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatusMigracao = Convert.ToBoolean(cmdCommand.Parameters["@OUT_ORC_B_STATUS_MIGRACAO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_TPN_C_CODIGO") && cmdCommand.Parameters["@OUT_ORC_TPN_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoTipoNegocio = cmdCommand.Parameters["@OUT_ORC_TPN_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_REG_C_CODIGO") && cmdCommand.Parameters["@OUT_ORC_REG_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoRegiao = cmdCommand.Parameters["@OUT_ORC_REG_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_B_TEMPORARIO") && cmdCommand.Parameters["@OUT_ORC_B_TEMPORARIO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsTemporario = Convert.ToBoolean(cmdCommand.Parameters["@OUT_ORC_B_TEMPORARIO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORC_B_ALTERADO") && cmdCommand.Parameters["@OUT_ORC_B_ALTERADO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAlterado = Convert.ToBoolean(cmdCommand.Parameters["@OUT_ORC_B_ALTERADO"].Value);
                    }



                    if (cmdCommand.Parameters.Contains("@OUT_TPN_C_DESCRICAO") && cmdCommand.Parameters["@OUT_TPN_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.TipoNegocio = cmdCommand.Parameters["@OUT_TPN_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REG_C_DESCRICAO") && cmdCommand.Parameters["@OUT_REG_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Região = cmdCommand.Parameters["@OUT_REG_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_RAZAO_SOCIAL") && cmdCommand.Parameters["@OUT_REV_C_RAZAO_SOCIAL"].Value != System.DBNull.Value)
                    {
                        objRetorno.NomeRevendedor = cmdCommand.Parameters["@OUT_REV_C_RAZAO_SOCIAL"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_CON_C_DESCRICAO") && cmdCommand.Parameters["@OUT_CON_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CondicaoPagamento = cmdCommand.Parameters["@OUT_CON_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_FOP_C_DESCRICAO") && cmdCommand.Parameters["@OUT_FOP_C_DESCRICAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.FormaPagamento = cmdCommand.Parameters["@OUT_FOP_C_DESCRICAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_C_NOME") && cmdCommand.Parameters["@OUT_VEN_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.NomeVendedor = cmdCommand.Parameters["@OUT_VEN_C_NOME"].Value.ToString();
                    }


                    if (cmdCommand.Parameters.Contains("@OUT_ORC_N_MAO_OBRA") && cmdCommand.Parameters["@OUT_ORC_N_MAO_OBRA"].Value != System.DBNull.Value)
                    {
                        objRetorno.MaoObra = Convert.ToDecimal(cmdCommand.Parameters["@OUT_ORC_N_MAO_OBRA"].Value);
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

        #endregion

    }
}


