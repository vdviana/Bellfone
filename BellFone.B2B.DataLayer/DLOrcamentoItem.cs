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
    /// Classe de conexão de dados para OrcamentoItem 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class DLOrcamentoItem : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.0]</user> 
        public DLOrcamentoItem()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }

        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLOrcamentoItem">Parametros para filtro</param>
        /// <returns>Lista de OrcamentoItem</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLOrcamentoItem> Listar(MLOrcamentoItem pobjMLOrcamentoItem)
        {

            List<MLOrcamentoItem> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ORCAMENTO_ITEM");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLOrcamentoItem.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORI_N_CODIGO"].Value = pobjMLOrcamentoItem.Codigo.Value;
            }
            if (pobjMLOrcamentoItem.CodigoOrcamento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_ORC_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORI_ORC_N_CODIGO"].Value = pobjMLOrcamentoItem.CodigoOrcamento.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.Origem))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_C_ORIGEM", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORI_C_ORIGEM"].Value = pobjMLOrcamentoItem.Origem;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.ItemOrcamentoLegado))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_C_ITEM_ORCAMENTO_LEGADO", FWDbType.Varchar, 6));
                cmdCommand.Parameters["@ORI_C_ITEM_ORCAMENTO_LEGADO"].Value = pobjMLOrcamentoItem.ItemOrcamentoLegado;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.Procodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_PRO_N_CODIGO", FWDbType.Varchar, 13));
                cmdCommand.Parameters["@ORI_PRO_N_CODIGO"].Value = pobjMLOrcamentoItem.Procodigo;
            }
            if (pobjMLOrcamentoItem.DataCriacao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_D_CRIACAO", FWDbType.DateTime));
                cmdCommand.Parameters["@ORI_D_CRIACAO"].Value = pobjMLOrcamentoItem.DataCriacao.Value;
            }
            if (pobjMLOrcamentoItem.Quantidade.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_QUANTIDADE", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORI_N_QUANTIDADE"].Value = pobjMLOrcamentoItem.Quantidade.Value;
            }
            if (pobjMLOrcamentoItem.PrecoSugerido.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_PRECO_SUGERIDO", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@ORI_N_PRECO_SUGERIDO"].Precision = 11;
                cmdCommand.Parameters["@ORI_N_PRECO_SUGERIDO"].Scale = 3;
                cmdCommand.Parameters["@ORI_N_PRECO_SUGERIDO"].Value = pobjMLOrcamentoItem.PrecoSugerido.Value;
            }
            if (pobjMLOrcamentoItem.PrecoAplicado.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_PRECO_APLICADO", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@ORI_N_PRECO_APLICADO"].Precision = 11;
                cmdCommand.Parameters["@ORI_N_PRECO_APLICADO"].Scale = 3;
                cmdCommand.Parameters["@ORI_N_PRECO_APLICADO"].Value = pobjMLOrcamentoItem.PrecoAplicado.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.CodigoStatusItemOrcamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_STI_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORI_STI_C_CODIGO"].Value = pobjMLOrcamentoItem.CodigoStatusItemOrcamento;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.Situacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_C_SITUACAO", FWDbType.Varchar, 200));
                cmdCommand.Parameters["@ORI_C_SITUACAO"].Value = pobjMLOrcamentoItem.Situacao;
            }
            if (pobjMLOrcamentoItem.IsStatusMigracao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_B_STATUS_MIGRACAO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORI_B_STATUS_MIGRACAO"].Value = pobjMLOrcamentoItem.IsStatusMigracao.Value;
            }
            if (pobjMLOrcamentoItem.IsAlterado.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_B_ALTERADO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORI_B_ALTERADO"].Value = pobjMLOrcamentoItem.IsAlterado;
            } 

            IDataReader idrRetorno = null;
            try
            {
                MLOrcamentoItem objRetorno = null;
                lstRetorno = new List<MLOrcamentoItem>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLOrcamentoItem();
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
        /// <returns>OrcamentoItem</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLOrcamentoItem Obter(decimal pdecCodigo)
        {

            MLOrcamentoItem objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_ORCAMENTO_ITEM");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@ORI_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@ORI_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORI_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_ORI_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORI_ORC_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_ORI_ORC_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORI_C_ORIGEM", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_ORI_C_ORIGEM"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORI_C_ITEM_ORCAMENTO_LEGADO", FWDbType.Varchar, 6));
            cmdCommand.Parameters["@OUT_ORI_C_ITEM_ORCAMENTO_LEGADO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORI_PRO_N_CODIGO", FWDbType.Varchar, 13));
            cmdCommand.Parameters["@OUT_ORI_PRO_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORI_D_CRIACAO", FWDbType.DateTime));
            cmdCommand.Parameters["@OUT_ORI_D_CRIACAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORI_N_QUANTIDADE", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_ORI_N_QUANTIDADE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORI_N_PRECO_SUGERIDO", FWDbType.Decimal, 11));
            cmdCommand.Parameters["@OUT_ORI_N_PRECO_SUGERIDO"].Precision = 11;
            cmdCommand.Parameters["@OUT_ORI_N_PRECO_SUGERIDO"].Scale = 3;
            cmdCommand.Parameters["@OUT_ORI_N_PRECO_SUGERIDO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORI_N_PRECO_APLICADO", FWDbType.Decimal, 11));
            cmdCommand.Parameters["@OUT_ORI_N_PRECO_APLICADO"].Precision = 11;
            cmdCommand.Parameters["@OUT_ORI_N_PRECO_APLICADO"].Scale = 3;
            cmdCommand.Parameters["@OUT_ORI_N_PRECO_APLICADO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORI_STI_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_ORI_STI_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORI_C_SITUACAO", FWDbType.Varchar, 200));
            cmdCommand.Parameters["@OUT_ORI_C_SITUACAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORI_B_STATUS_MIGRACAO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_ORI_B_STATUS_MIGRACAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_ORI_B_ALTERADO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_ORI_B_ALTERADO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_ORI_N_CODIGO") && cmdCommand.Parameters["@OUT_ORI_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLOrcamentoItem();

                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_ORI_N_CODIGO"].Value);
                    if (cmdCommand.Parameters.Contains("@OUT_ORI_ORC_N_CODIGO") && cmdCommand.Parameters["@OUT_ORI_ORC_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoOrcamento = Convert.ToDecimal(cmdCommand.Parameters["@OUT_ORI_ORC_N_CODIGO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORI_C_ORIGEM") && cmdCommand.Parameters["@OUT_ORI_C_ORIGEM"].Value != System.DBNull.Value)
                    {
                        objRetorno.Origem = cmdCommand.Parameters["@OUT_ORI_C_ORIGEM"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORI_C_ITEM_ORCAMENTO_LEGADO") && cmdCommand.Parameters["@OUT_ORI_C_ITEM_ORCAMENTO_LEGADO"].Value != System.DBNull.Value)
                    {
                        objRetorno.ItemOrcamentoLegado = cmdCommand.Parameters["@OUT_ORI_C_ITEM_ORCAMENTO_LEGADO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORI_PRO_N_CODIGO") && cmdCommand.Parameters["@OUT_ORI_PRO_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Procodigo = cmdCommand.Parameters["@OUT_ORI_PRO_N_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORI_D_CRIACAO") && cmdCommand.Parameters["@OUT_ORI_D_CRIACAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.DataCriacao = Convert.ToDateTime(cmdCommand.Parameters["@OUT_ORI_D_CRIACAO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORI_N_QUANTIDADE") && cmdCommand.Parameters["@OUT_ORI_N_QUANTIDADE"].Value != System.DBNull.Value)
                    {
                        objRetorno.Quantidade = Convert.ToDecimal(cmdCommand.Parameters["@OUT_ORI_N_QUANTIDADE"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORI_N_PRECO_SUGERIDO") && cmdCommand.Parameters["@OUT_ORI_N_PRECO_SUGERIDO"].Value != System.DBNull.Value)
                    {
                        objRetorno.PrecoSugerido = Convert.ToDecimal(cmdCommand.Parameters["@OUT_ORI_N_PRECO_SUGERIDO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORI_N_PRECO_APLICADO") && cmdCommand.Parameters["@OUT_ORI_N_PRECO_APLICADO"].Value != System.DBNull.Value)
                    {
                        objRetorno.PrecoAplicado = Convert.ToDecimal(cmdCommand.Parameters["@OUT_ORI_N_PRECO_APLICADO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORI_STI_C_CODIGO") && cmdCommand.Parameters["@OUT_ORI_STI_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoStatusItemOrcamento = cmdCommand.Parameters["@OUT_ORI_STI_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORI_C_SITUACAO") && cmdCommand.Parameters["@OUT_ORI_C_SITUACAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Situacao = cmdCommand.Parameters["@OUT_ORI_C_SITUACAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORI_B_STATUS_MIGRACAO") && cmdCommand.Parameters["@OUT_ORI_B_STATUS_MIGRACAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatusMigracao = Convert.ToBoolean(cmdCommand.Parameters["@OUT_ORI_B_STATUS_MIGRACAO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_ORI_B_ALTERADO") && cmdCommand.Parameters["@OUT_ORI_B_ALTERADO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAlterado = Convert.ToBoolean(cmdCommand.Parameters["@OUT_ORI_B_ALTERADO"].Value);
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

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_ORCAMENTO_ITEM");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@ORI_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@ORI_N_CODIGO"].Value = pdecCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLOrcamentoItem">OrcamentoItem para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLOrcamentoItem pobjMLOrcamentoItem)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_ORCAMENTO_ITEM");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLOrcamentoItem.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORI_N_CODIGO"].Value = pobjMLOrcamentoItem.Codigo.Value;
            }
            if (pobjMLOrcamentoItem.CodigoOrcamento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_ORC_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORI_ORC_N_CODIGO"].Value = pobjMLOrcamentoItem.CodigoOrcamento.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.Origem))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_C_ORIGEM", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORI_C_ORIGEM"].Value = pobjMLOrcamentoItem.Origem;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.ItemOrcamentoLegado))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_C_ITEM_ORCAMENTO_LEGADO", FWDbType.Varchar, 6));
                cmdCommand.Parameters["@ORI_C_ITEM_ORCAMENTO_LEGADO"].Value = pobjMLOrcamentoItem.ItemOrcamentoLegado;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.Procodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_PRO_N_CODIGO", FWDbType.Varchar, 13));
                cmdCommand.Parameters["@ORI_PRO_N_CODIGO"].Value = pobjMLOrcamentoItem.Procodigo;
            }
            if (pobjMLOrcamentoItem.DataCriacao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_D_CRIACAO", FWDbType.DateTime));
                cmdCommand.Parameters["@ORI_D_CRIACAO"].Value = pobjMLOrcamentoItem.DataCriacao.Value;
            }
            if (pobjMLOrcamentoItem.Quantidade.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_QUANTIDADE", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORI_N_QUANTIDADE"].Value = pobjMLOrcamentoItem.Quantidade.Value;
            }
            if (pobjMLOrcamentoItem.PrecoSugerido.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_PRECO_SUGERIDO", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@ORI_N_PRECO_SUGERIDO"].Precision = 11;
                cmdCommand.Parameters["@ORI_N_PRECO_SUGERIDO"].Scale = 3;
                cmdCommand.Parameters["@ORI_N_PRECO_SUGERIDO"].Value = pobjMLOrcamentoItem.PrecoSugerido.Value;
            }
            if (pobjMLOrcamentoItem.PrecoAplicado.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_PRECO_APLICADO", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@ORI_N_PRECO_APLICADO"].Precision = 11;
                cmdCommand.Parameters["@ORI_N_PRECO_APLICADO"].Scale = 3;
                cmdCommand.Parameters["@ORI_N_PRECO_APLICADO"].Value = pobjMLOrcamentoItem.PrecoAplicado.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.CodigoStatusItemOrcamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_STI_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORI_STI_C_CODIGO"].Value = pobjMLOrcamentoItem.CodigoStatusItemOrcamento;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.Situacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_C_SITUACAO", FWDbType.Varchar, 200));
                cmdCommand.Parameters["@ORI_C_SITUACAO"].Value = pobjMLOrcamentoItem.Situacao;
            }
            if (pobjMLOrcamentoItem.IsStatusMigracao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_B_STATUS_MIGRACAO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORI_B_STATUS_MIGRACAO"].Value = pobjMLOrcamentoItem.IsStatusMigracao.Value;
            }

            if (pobjMLOrcamentoItem.IsAlterado.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_B_ALTERADO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORI_B_ALTERADO"].Value = pobjMLOrcamentoItem.IsAlterado;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLOrcamentoItem">OrcamentoItem para inserir</param>
        /// <returns>Código OrcamentoItem</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public decimal Inserir(MLOrcamentoItem pobjMLOrcamentoItem)
        {
            FWCommand cmdCommand = new FWCommand("USP_BLF_I_ORCAMENTO_ITEM");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            
            if (pobjMLOrcamentoItem.CodigoOrcamento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_ORC_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORI_ORC_N_CODIGO"].Value = pobjMLOrcamentoItem.CodigoOrcamento.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.Origem))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_C_ORIGEM", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORI_C_ORIGEM"].Value = pobjMLOrcamentoItem.Origem;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.ItemOrcamentoLegado))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_C_ITEM_ORCAMENTO_LEGADO", FWDbType.Varchar, 6));
                cmdCommand.Parameters["@ORI_C_ITEM_ORCAMENTO_LEGADO"].Value = pobjMLOrcamentoItem.ItemOrcamentoLegado;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.Procodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_PRO_N_CODIGO", FWDbType.Varchar, 13));
                cmdCommand.Parameters["@ORI_PRO_N_CODIGO"].Value = pobjMLOrcamentoItem.Procodigo;
            }
            if (pobjMLOrcamentoItem.DataCriacao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_D_CRIACAO", FWDbType.DateTime));
                cmdCommand.Parameters["@ORI_D_CRIACAO"].Value = pobjMLOrcamentoItem.DataCriacao.Value;
            }
            if (pobjMLOrcamentoItem.Quantidade.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_QUANTIDADE", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORI_N_QUANTIDADE"].Value = pobjMLOrcamentoItem.Quantidade.Value;
            }
            if (pobjMLOrcamentoItem.PrecoSugerido.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_PRECO_SUGERIDO", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@ORI_N_PRECO_SUGERIDO"].Precision = 11;
                cmdCommand.Parameters["@ORI_N_PRECO_SUGERIDO"].Scale = 3;
                cmdCommand.Parameters["@ORI_N_PRECO_SUGERIDO"].Value = pobjMLOrcamentoItem.PrecoSugerido.Value;
            }
            if (pobjMLOrcamentoItem.PrecoAplicado.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_PRECO_APLICADO", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@ORI_N_PRECO_APLICADO"].Precision = 11;
                cmdCommand.Parameters["@ORI_N_PRECO_APLICADO"].Scale = 3;
                cmdCommand.Parameters["@ORI_N_PRECO_APLICADO"].Value = pobjMLOrcamentoItem.PrecoAplicado.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.CodigoStatusItemOrcamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_STI_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORI_STI_C_CODIGO"].Value = pobjMLOrcamentoItem.CodigoStatusItemOrcamento;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.Situacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_C_SITUACAO", FWDbType.Varchar, 200));
                cmdCommand.Parameters["@ORI_C_SITUACAO"].Value = pobjMLOrcamentoItem.Situacao;
            }
            if (pobjMLOrcamentoItem.IsStatusMigracao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_B_STATUS_MIGRACAO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORI_B_STATUS_MIGRACAO"].Value = pobjMLOrcamentoItem.IsStatusMigracao.Value;
            }
            if (pobjMLOrcamentoItem.IsAlterado.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_B_ALTERADO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORI_B_ALTERADO"].Value = pobjMLOrcamentoItem.IsAlterado;
            }

            return Convert.ToDecimal(conProvider.ExecuteScalar(cmdCommand));

        }

        #endregion


        #region ListarOrcamentoItemsTemporarios

        /// <summary> 
        /// Executa a Stored Procedure de Listagem por Usuario e Orcamento Temporario
        /// </summary> 
        /// <param name="pdecUsuario"></param>
        /// <returns>Lista de OrcamentoItem</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLOrcamentoItemCompleto> ListarOrcamentoItemsTemporarios(Decimal pdecUsuario)
        {
            List<MLOrcamentoItemCompleto> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ORCAMENTO_ITEM_USUARIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pdecUsuario != 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_USU_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@REV_USU_N_CODIGO"].Value = pdecUsuario;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLOrcamentoItemCompleto objRetorno = null;
                lstRetorno = new List<MLOrcamentoItemCompleto>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLOrcamentoItemCompleto();
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

        #region ListarOrcamentoItemsTemporarios

        /// <summary> 
        /// Executa a Stored Procedure de Listagem por Usuario e Orcamento Temporario
        /// </summary> 
        /// <param name="pdecUsuario"></param>
        /// <returns>Lista de OrcamentoItem</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLOrcamentoItemCompleto> ListarOrcamentoItemsPorRevendedor(String pstrRevendedor)
        {
            List<MLOrcamentoItemCompleto> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ORCAMENTO_ITEM_REVENDEDOR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pstrRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_CODIGO", FWDbType.NVarchar, 5));
                cmdCommand.Parameters["@REV_C_CODIGO"].Value = pstrRevendedor;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLOrcamentoItemCompleto objRetorno = null;
                lstRetorno = new List<MLOrcamentoItemCompleto>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLOrcamentoItemCompleto();
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

        #region Listar Completo

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLOrcamentoItem">Parametros para filtro</param>
        /// <returns>Lista de OrcamentoItem</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLOrcamentoItemCompleto> ListarCompleto(MLOrcamentoItem pobjMLOrcamentoItem)
        {

            List<MLOrcamentoItemCompleto> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ORCAMENTO_ITEM_COMPLETO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLOrcamentoItem.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORI_N_CODIGO"].Value = pobjMLOrcamentoItem.Codigo.Value;
            }
            if (pobjMLOrcamentoItem.CodigoOrcamento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_ORC_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORI_ORC_N_CODIGO"].Value = pobjMLOrcamentoItem.CodigoOrcamento.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.Origem))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_C_ORIGEM", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORI_C_ORIGEM"].Value = pobjMLOrcamentoItem.Origem;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.ItemOrcamentoLegado))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_C_ITEM_ORCAMENTO_LEGADO", FWDbType.Varchar, 6));
                cmdCommand.Parameters["@ORI_C_ITEM_ORCAMENTO_LEGADO"].Value = pobjMLOrcamentoItem.ItemOrcamentoLegado;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.Procodigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_PRO_N_CODIGO", FWDbType.Varchar, 13));
                cmdCommand.Parameters["@ORI_PRO_N_CODIGO"].Value = pobjMLOrcamentoItem.Procodigo;
            }
            if (pobjMLOrcamentoItem.DataCriacao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_D_CRIACAO", FWDbType.DateTime));
                cmdCommand.Parameters["@ORI_D_CRIACAO"].Value = pobjMLOrcamentoItem.DataCriacao.Value;
            }
            if (pobjMLOrcamentoItem.Quantidade.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_QUANTIDADE", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@ORI_N_QUANTIDADE"].Value = pobjMLOrcamentoItem.Quantidade.Value;
            }
            if (pobjMLOrcamentoItem.PrecoSugerido.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_PRECO_SUGERIDO", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@ORI_N_PRECO_SUGERIDO"].Precision = 11;
                cmdCommand.Parameters["@ORI_N_PRECO_SUGERIDO"].Scale = 3;
                cmdCommand.Parameters["@ORI_N_PRECO_SUGERIDO"].Value = pobjMLOrcamentoItem.PrecoSugerido.Value;
            }
            if (pobjMLOrcamentoItem.PrecoAplicado.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_N_PRECO_APLICADO", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@ORI_N_PRECO_APLICADO"].Precision = 11;
                cmdCommand.Parameters["@ORI_N_PRECO_APLICADO"].Scale = 3;
                cmdCommand.Parameters["@ORI_N_PRECO_APLICADO"].Value = pobjMLOrcamentoItem.PrecoAplicado.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.CodigoStatusItemOrcamento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_STI_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@ORI_STI_C_CODIGO"].Value = pobjMLOrcamentoItem.CodigoStatusItemOrcamento;
            }
            if (!string.IsNullOrEmpty(pobjMLOrcamentoItem.Situacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_C_SITUACAO", FWDbType.Varchar, 200));
                cmdCommand.Parameters["@ORI_C_SITUACAO"].Value = pobjMLOrcamentoItem.Situacao;
            }
            if (pobjMLOrcamentoItem.IsStatusMigracao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_B_STATUS_MIGRACAO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORI_B_STATUS_MIGRACAO"].Value = pobjMLOrcamentoItem.IsStatusMigracao.Value;
            }
            if (pobjMLOrcamentoItem.IsAlterado.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@ORI_B_ALTERADO", FWDbType.Boolean));
                cmdCommand.Parameters["@ORI_B_ALTERADO"].Value = pobjMLOrcamentoItem.IsAlterado.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLOrcamentoItemCompleto objRetorno = null;
                lstRetorno = new List<MLOrcamentoItemCompleto>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLOrcamentoItemCompleto();
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

    /// <summary> 
    /// Classe de conexão de dados para OrcamentoItemHistorico 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.1]</user> 
    public class DLOrcamentoItemHistorico : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.1]</user> 
        public DLOrcamentoItemHistorico()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLOrcamentoItemHistorico">Parametros para filtro</param>
        /// <returns>Lista de OrcamentoItemHistorico</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLOrcamentoItemHistorico> Listar(MLOrcamentoItemHistorico pobjMLOrcamentoItemHistorico)
        {

            List<MLOrcamentoItemHistorico> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_ORCAMENTO_ITEM_HISTORICO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLOrcamentoItemHistorico.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@OIH_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@OIH_N_CODIGO"].Value = pobjMLOrcamentoItemHistorico.Codigo.Value;
            }
            if (pobjMLOrcamentoItemHistorico.CodigoOrcamentoItem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@OIH_ORI_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@OIH_ORI_N_CODIGO"].Value = pobjMLOrcamentoItemHistorico.CodigoOrcamentoItem.Value;
            }
            if (pobjMLOrcamentoItemHistorico.PrecoSugeridoOrcamentoItem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@OIH_ORI_N_PRECO_SUGERIDO", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@OIH_ORI_N_PRECO_SUGERIDO"].Precision = 11;
                cmdCommand.Parameters["@OIH_ORI_N_PRECO_SUGERIDO"].Scale = 3;
                cmdCommand.Parameters["@OIH_ORI_N_PRECO_SUGERIDO"].Value = pobjMLOrcamentoItemHistorico.PrecoSugeridoOrcamentoItem.Value;
            }
            if (pobjMLOrcamentoItemHistorico.DataAlteracao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@OIH_D_DATA_ALTERACAO", FWDbType.DateTime));
                cmdCommand.Parameters["@OIH_D_DATA_ALTERACAO"].Value = pobjMLOrcamentoItemHistorico.DataAlteracao.Value;
            }
            if (pobjMLOrcamentoItemHistorico.CodigoUsuario.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@OIH_USU_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@OIH_USU_N_CODIGO"].Value = pobjMLOrcamentoItemHistorico.CodigoUsuario.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLOrcamentoItemHistorico objRetorno = null;
                lstRetorno = new List<MLOrcamentoItemHistorico>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLOrcamentoItemHistorico();
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
        /// <returns>OrcamentoItemHistorico</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLOrcamentoItemHistorico Obter(decimal pdecCodigo)
        {

            MLOrcamentoItemHistorico objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_ORCAMENTO_ITEM_HISTORICO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@OIH_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OIH_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_OIH_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_OIH_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_OIH_ORI_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_OIH_ORI_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_OIH_ORI_N_PRECO_SUGERIDO", FWDbType.Decimal, 11));
            cmdCommand.Parameters["@OUT_OIH_ORI_N_PRECO_SUGERIDO"].Precision = 11;
            cmdCommand.Parameters["@OUT_OIH_ORI_N_PRECO_SUGERIDO"].Scale = 3;
            cmdCommand.Parameters["@OUT_OIH_ORI_N_PRECO_SUGERIDO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_OIH_D_DATA_ALTERACAO", FWDbType.DateTime));
            cmdCommand.Parameters["@OUT_OIH_D_DATA_ALTERACAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_OIH_USU_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_OIH_USU_N_CODIGO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_OIH_N_CODIGO") && cmdCommand.Parameters["@OUT_OIH_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLOrcamentoItemHistorico();

                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_OIH_N_CODIGO"].Value);
                    if (cmdCommand.Parameters.Contains("@OUT_OIH_ORI_N_CODIGO") && cmdCommand.Parameters["@OUT_OIH_ORI_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoOrcamentoItem = Convert.ToDecimal(cmdCommand.Parameters["@OUT_OIH_ORI_N_CODIGO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_OIH_ORI_N_PRECO_SUGERIDO") && cmdCommand.Parameters["@OUT_OIH_ORI_N_PRECO_SUGERIDO"].Value != System.DBNull.Value)
                    {
                        objRetorno.PrecoSugeridoOrcamentoItem = Convert.ToDecimal(cmdCommand.Parameters["@OUT_OIH_ORI_N_PRECO_SUGERIDO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_OIH_D_DATA_ALTERACAO") && cmdCommand.Parameters["@OUT_OIH_D_DATA_ALTERACAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.DataAlteracao = Convert.ToDateTime(cmdCommand.Parameters["@OUT_OIH_D_DATA_ALTERACAO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_OIH_USU_N_CODIGO") && cmdCommand.Parameters["@OUT_OIH_USU_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoUsuario = Convert.ToDecimal(cmdCommand.Parameters["@OUT_OIH_USU_N_CODIGO"].Value);
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

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_ORCAMENTO_ITEM_HISTORICO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@OIH_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OIH_N_CODIGO"].Value = pdecCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLOrcamentoItemHistorico">OrcamentoItemHistorico para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLOrcamentoItemHistorico pobjMLOrcamentoItemHistorico)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_ORCAMENTO_ITEM_HISTORICO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLOrcamentoItemHistorico.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@OIH_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@OIH_N_CODIGO"].Value = pobjMLOrcamentoItemHistorico.Codigo.Value;
            }
            if (pobjMLOrcamentoItemHistorico.CodigoOrcamentoItem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@OIH_ORI_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@OIH_ORI_N_CODIGO"].Value = pobjMLOrcamentoItemHistorico.CodigoOrcamentoItem.Value;
            }
            if (pobjMLOrcamentoItemHistorico.PrecoSugeridoOrcamentoItem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@OIH_ORI_N_PRECO_SUGERIDO", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@OIH_ORI_N_PRECO_SUGERIDO"].Precision = 11;
                cmdCommand.Parameters["@OIH_ORI_N_PRECO_SUGERIDO"].Scale = 3;
                cmdCommand.Parameters["@OIH_ORI_N_PRECO_SUGERIDO"].Value = pobjMLOrcamentoItemHistorico.PrecoSugeridoOrcamentoItem.Value;
            }
            if (pobjMLOrcamentoItemHistorico.DataAlteracao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@OIH_D_DATA_ALTERACAO", FWDbType.DateTime));
                cmdCommand.Parameters["@OIH_D_DATA_ALTERACAO"].Value = pobjMLOrcamentoItemHistorico.DataAlteracao.Value;
            }
            if (pobjMLOrcamentoItemHistorico.CodigoUsuario.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@OIH_USU_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@OIH_USU_N_CODIGO"].Value = pobjMLOrcamentoItemHistorico.CodigoUsuario.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLOrcamentoItemHistorico">OrcamentoItemHistorico para inserir</param>
        /// <returns>Código OrcamentoItemHistorico</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public decimal Inserir(MLOrcamentoItemHistorico pobjMLOrcamentoItemHistorico)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_ORCAMENTO_ITEM_HISTORICO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLOrcamentoItemHistorico.CodigoOrcamentoItem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@OIH_ORI_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@OIH_ORI_N_CODIGO"].Value = pobjMLOrcamentoItemHistorico.CodigoOrcamentoItem.Value;
            }
            if (pobjMLOrcamentoItemHistorico.PrecoSugeridoOrcamentoItem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@OIH_ORI_N_PRECO_SUGERIDO", FWDbType.Decimal, 11));
                cmdCommand.Parameters["@OIH_ORI_N_PRECO_SUGERIDO"].Precision = 11;
                cmdCommand.Parameters["@OIH_ORI_N_PRECO_SUGERIDO"].Scale = 3;
                cmdCommand.Parameters["@OIH_ORI_N_PRECO_SUGERIDO"].Value = pobjMLOrcamentoItemHistorico.PrecoSugeridoOrcamentoItem.Value;
            }
            if (pobjMLOrcamentoItemHistorico.DataAlteracao.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@OIH_D_DATA_ALTERACAO", FWDbType.DateTime));
                cmdCommand.Parameters["@OIH_D_DATA_ALTERACAO"].Value = pobjMLOrcamentoItemHistorico.DataAlteracao.Value;
            }
            if (pobjMLOrcamentoItemHistorico.CodigoUsuario.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@OIH_USU_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@OIH_USU_N_CODIGO"].Value = pobjMLOrcamentoItemHistorico.CodigoUsuario.Value;
            }

            return Convert.ToDecimal(conProvider.ExecuteScalar(cmdCommand));

        }

        #endregion
    }
}


