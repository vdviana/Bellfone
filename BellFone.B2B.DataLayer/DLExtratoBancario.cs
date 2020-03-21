using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para ExtratoFinanceiro 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class DLExtratoFinanceiro : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.0]</user> 
        public DLExtratoFinanceiro()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLExtratoFinanceiro">Parametros para filtro</param>
        /// <returns>Lista de ExtratoFinanceiro</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLExtratoFinanceiro> Listar(MLExtratoFinanceiro pobjMLExtratoFinanceiro)
        {

            List<MLExtratoFinanceiro> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_EXTRATO_FINANCEIRO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLExtratoFinanceiro.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@EXF_N_CODIGO"].Value = pobjMLExtratoFinanceiro.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLExtratoFinanceiro.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_REV_N_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@EXF_REV_N_CODIGO"].Value = pobjMLExtratoFinanceiro.CodigoRevendedor;
            }
            if (pobjMLExtratoFinanceiro.DataLancamento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_D_LANCAMENTO", FWDbType.DateTime));
                cmdCommand.Parameters["@EXF_D_LANCAMENTO"].Value = pobjMLExtratoFinanceiro.DataLancamento.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLExtratoFinanceiro.Historico))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_C_HISTORICO", FWDbType.Varchar, 255));
                cmdCommand.Parameters["@EXF_C_HISTORICO"].Value = pobjMLExtratoFinanceiro.Historico;
            }
            if (pobjMLExtratoFinanceiro.SaldoAnterior.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_SALDO_ANTERIOR", FWDbType.Decimal, 12));
                cmdCommand.Parameters["@EXF_N_SALDO_ANTERIOR"].Scale = 2;
                cmdCommand.Parameters["@EXF_N_SALDO_ANTERIOR"].Value = pobjMLExtratoFinanceiro.SaldoAnterior.Value;
            }
            if (pobjMLExtratoFinanceiro.Credito.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_CREDITO", FWDbType.Decimal, 12));
                cmdCommand.Parameters["@EXF_N_CREDITO"].Scale = 2;
                cmdCommand.Parameters["@EXF_N_CREDITO"].Value = pobjMLExtratoFinanceiro.Credito.Value;
            }
            if (pobjMLExtratoFinanceiro.Debito.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_DEBITO", FWDbType.Decimal, 12));
                cmdCommand.Parameters["@EXF_N_DEBITO"].Scale = 2;
                cmdCommand.Parameters["@EXF_N_DEBITO"].Value = pobjMLExtratoFinanceiro.Debito.Value;
            }
            if (pobjMLExtratoFinanceiro.SaldoAtual.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_SALDO_ATUAL", FWDbType.Decimal, 12));
                cmdCommand.Parameters["@EXF_N_SALDO_ATUAL"].Scale = 2;
                cmdCommand.Parameters["@EXF_N_SALDO_ATUAL"].Value = pobjMLExtratoFinanceiro.SaldoAtual.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLExtratoFinanceiro.Status))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_C_STATUS", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@EXF_C_STATUS"].Value = pobjMLExtratoFinanceiro.Status;
            }
            if (!string.IsNullOrEmpty(pobjMLExtratoFinanceiro.Documento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_C_DOCUMENTO", FWDbType.Varchar, 7));
                cmdCommand.Parameters["@EXF_C_DOCUMENTO"].Value = pobjMLExtratoFinanceiro.Documento;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLExtratoFinanceiro objRetorno = null;
                lstRetorno = new List<MLExtratoFinanceiro>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLExtratoFinanceiro();
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
        /// <returns>ExtratoFinanceiro</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLExtratoFinanceiro Obter(decimal pdecCodigo)
        {

            MLExtratoFinanceiro objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_EXTRATO_FINANCEIRO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@EXF_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@EXF_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_EXF_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_EXF_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_EXF_REV_N_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_EXF_REV_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_EXF_D_LANCAMENTO", FWDbType.DateTime));
            cmdCommand.Parameters["@OUT_EXF_D_LANCAMENTO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_EXF_C_HISTORICO", FWDbType.Varchar, 255));
            cmdCommand.Parameters["@OUT_EXF_C_HISTORICO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_EXF_N_SALDO_ANTERIOR", FWDbType.Decimal, 12));
            cmdCommand.Parameters["@OUT_EXF_N_SALDO_ANTERIOR"].Scale = 2;
            cmdCommand.Parameters["@OUT_EXF_N_SALDO_ANTERIOR"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_EXF_N_CREDITO", FWDbType.Decimal, 12));
            cmdCommand.Parameters["@OUT_EXF_N_CREDITO"].Scale = 2;
            cmdCommand.Parameters["@OUT_EXF_N_CREDITO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_EXF_N_DEBITO", FWDbType.Decimal, 12));
            cmdCommand.Parameters["@OUT_EXF_N_DEBITO"].Scale = 2;
            cmdCommand.Parameters["@OUT_EXF_N_DEBITO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_EXF_N_SALDO_ATUAL", FWDbType.Decimal, 12));
            cmdCommand.Parameters["@OUT_EXF_N_SALDO_ATUAL"].Scale = 2;
            cmdCommand.Parameters["@OUT_EXF_N_SALDO_ATUAL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_EXF_C_STATUS", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@OUT_EXF_C_STATUS"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_EXF_C_DOCUMENTO", FWDbType.Varchar, 7));
            cmdCommand.Parameters["@OUT_EXF_C_DOCUMENTO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_EXF_N_CODIGO") && cmdCommand.Parameters["@OUT_EXF_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLExtratoFinanceiro();

                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_EXF_N_CODIGO"].Value);
                    if (cmdCommand.Parameters.Contains("@OUT_EXF_REV_N_CODIGO") && cmdCommand.Parameters["@OUT_EXF_REV_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoRevendedor = cmdCommand.Parameters["@OUT_EXF_REV_N_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_EXF_D_LANCAMENTO") && cmdCommand.Parameters["@OUT_EXF_D_LANCAMENTO"].Value != System.DBNull.Value)
                    {
                        objRetorno.DataLancamento = Convert.ToDateTime(cmdCommand.Parameters["@OUT_EXF_D_LANCAMENTO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_EXF_C_HISTORICO") && cmdCommand.Parameters["@OUT_EXF_C_HISTORICO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Historico = cmdCommand.Parameters["@OUT_EXF_C_HISTORICO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_EXF_N_SALDO_ANTERIOR") && cmdCommand.Parameters["@OUT_EXF_N_SALDO_ANTERIOR"].Value != System.DBNull.Value)
                    {
                        objRetorno.SaldoAnterior = Convert.ToDecimal(cmdCommand.Parameters["@OUT_EXF_N_SALDO_ANTERIOR"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_EXF_N_CREDITO") && cmdCommand.Parameters["@OUT_EXF_N_CREDITO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Credito = Convert.ToDecimal(cmdCommand.Parameters["@OUT_EXF_N_CREDITO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_EXF_N_DEBITO") && cmdCommand.Parameters["@OUT_EXF_N_DEBITO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Debito = Convert.ToDecimal(cmdCommand.Parameters["@OUT_EXF_N_DEBITO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_EXF_N_SALDO_ATUAL") && cmdCommand.Parameters["@OUT_EXF_N_SALDO_ATUAL"].Value != System.DBNull.Value)
                    {
                        objRetorno.SaldoAtual = Convert.ToDecimal(cmdCommand.Parameters["@OUT_EXF_N_SALDO_ATUAL"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_EXF_C_STATUS") && cmdCommand.Parameters["@OUT_EXF_C_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.Status = cmdCommand.Parameters["@OUT_EXF_C_STATUS"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_EXF_C_DOCUMENTO") && cmdCommand.Parameters["@OUT_EXF_C_DOCUMENTO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Documento = cmdCommand.Parameters["@OUT_EXF_C_DOCUMENTO"].Value.ToString();
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
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Excluir(decimal pdecCodigo)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_EXTRATO_FINANCEIRO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@EXF_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@EXF_N_CODIGO"].Value = pdecCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLExtratoFinanceiro">ExtratoFinanceiro para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLExtratoFinanceiro pobjMLExtratoFinanceiro)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_EXTRATO_FINANCEIRO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLExtratoFinanceiro.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@EXF_N_CODIGO"].Value = pobjMLExtratoFinanceiro.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLExtratoFinanceiro.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_REV_N_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@EXF_REV_N_CODIGO"].Value = pobjMLExtratoFinanceiro.CodigoRevendedor;
            }
            if (pobjMLExtratoFinanceiro.DataLancamento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_D_LANCAMENTO", FWDbType.DateTime));
                cmdCommand.Parameters["@EXF_D_LANCAMENTO"].Value = pobjMLExtratoFinanceiro.DataLancamento.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLExtratoFinanceiro.Historico))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_C_HISTORICO", FWDbType.Varchar, 255));
                cmdCommand.Parameters["@EXF_C_HISTORICO"].Value = pobjMLExtratoFinanceiro.Historico;
            }
            if (pobjMLExtratoFinanceiro.SaldoAnterior.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_SALDO_ANTERIOR", FWDbType.Decimal, 12));
                cmdCommand.Parameters["@EXF_N_SALDO_ANTERIOR"].Scale = 2;
                cmdCommand.Parameters["@EXF_N_SALDO_ANTERIOR"].Precision = 12;
                cmdCommand.Parameters["@EXF_N_SALDO_ANTERIOR"].Value = pobjMLExtratoFinanceiro.SaldoAnterior.Value;
            }
            if (pobjMLExtratoFinanceiro.Credito.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_CREDITO", FWDbType.Decimal, 12));
                cmdCommand.Parameters["@EXF_N_CREDITO"].Scale = 2;
                cmdCommand.Parameters["@EXF_N_CREDITO"].Precision = 12;
                cmdCommand.Parameters["@EXF_N_CREDITO"].Value = pobjMLExtratoFinanceiro.Credito.Value;
            }
            if (pobjMLExtratoFinanceiro.Debito.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_DEBITO", FWDbType.Decimal, 12));
                cmdCommand.Parameters["@EXF_N_DEBITO"].Scale = 2;
                cmdCommand.Parameters["@EXF_N_DEBITO"].Precision = 12;
                cmdCommand.Parameters["@EXF_N_DEBITO"].Value = pobjMLExtratoFinanceiro.Debito.Value;
            }
            if (pobjMLExtratoFinanceiro.SaldoAtual.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_SALDO_ATUAL", FWDbType.Decimal, 12));
                cmdCommand.Parameters["@EXF_N_SALDO_ATUAL"].Scale = 2;
                cmdCommand.Parameters["@EXF_N_SALDO_ATUAL"].Precision = 12;
                cmdCommand.Parameters["@EXF_N_SALDO_ATUAL"].Value = pobjMLExtratoFinanceiro.SaldoAtual.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLExtratoFinanceiro.Status))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_C_STATUS", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@EXF_C_STATUS"].Value = pobjMLExtratoFinanceiro.Status;
            }
            if (!string.IsNullOrEmpty(pobjMLExtratoFinanceiro.Documento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_C_DOCUMENTO", FWDbType.Varchar, 7));
                cmdCommand.Parameters["@EXF_C_DOCUMENTO"].Value = pobjMLExtratoFinanceiro.Documento;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary>
        /// <param name="pobjMLExtratoFinanceiro">ExtratoFinanceiro para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Inserir(MLExtratoFinanceiro pobjMLExtratoFinanceiro)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_EXTRATO_FINANCEIRO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLExtratoFinanceiro.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@EXF_N_CODIGO"].Value = pobjMLExtratoFinanceiro.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLExtratoFinanceiro.CodigoRevendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_REV_N_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@EXF_REV_N_CODIGO"].Value = pobjMLExtratoFinanceiro.CodigoRevendedor;
            }
            if (pobjMLExtratoFinanceiro.DataLancamento.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_D_LANCAMENTO", FWDbType.DateTime));
                cmdCommand.Parameters["@EXF_D_LANCAMENTO"].Value = pobjMLExtratoFinanceiro.DataLancamento.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLExtratoFinanceiro.Historico))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_C_HISTORICO", FWDbType.Varchar, 255));
                cmdCommand.Parameters["@EXF_C_HISTORICO"].Value = pobjMLExtratoFinanceiro.Historico;
            }
            if (pobjMLExtratoFinanceiro.SaldoAnterior.HasValue && pobjMLExtratoFinanceiro.SaldoAnterior.Value != 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_SALDO_ANTERIOR", FWDbType.Decimal, 12));
                //cmdCommand.Parameters["@EXF_N_SALDO_ANTERIOR"].Scale = 2;
                cmdCommand.Parameters["@EXF_N_SALDO_ANTERIOR"].Value = pobjMLExtratoFinanceiro.SaldoAnterior.Value;
            }
            if (pobjMLExtratoFinanceiro.Credito.HasValue && pobjMLExtratoFinanceiro.Credito != 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_CREDITO", FWDbType.Decimal, 12));
                //cmdCommand.Parameters["@EXF_N_CREDITO"].Scale = 2;
                cmdCommand.Parameters["@EXF_N_CREDITO"].Value = pobjMLExtratoFinanceiro.Credito.Value;
            }
            if (pobjMLExtratoFinanceiro.Debito.HasValue && pobjMLExtratoFinanceiro.Debito != 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_DEBITO", FWDbType.Decimal, 12));
                //cmdCommand.Parameters["@EXF_N_DEBITO"].Scale = 2;
                cmdCommand.Parameters["@EXF_N_DEBITO"].Value = pobjMLExtratoFinanceiro.Debito.Value;
            }
            if (pobjMLExtratoFinanceiro.SaldoAtual.HasValue && pobjMLExtratoFinanceiro.SaldoAtual != 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_N_SALDO_ATUAL", FWDbType.Decimal, 12));
                //cmdCommand.Parameters["@EXF_N_SALDO_ATUAL"].Scale = 2;
                cmdCommand.Parameters["@EXF_N_SALDO_ATUAL"].Value = pobjMLExtratoFinanceiro.SaldoAtual.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLExtratoFinanceiro.Status))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_C_STATUS", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@EXF_C_STATUS"].Value = pobjMLExtratoFinanceiro.Status;
            }
            if (!string.IsNullOrEmpty(pobjMLExtratoFinanceiro.Documento))
            {
                cmdCommand.Parameters.Add(new FWParameter("@EXF_C_DOCUMENTO", FWDbType.Varchar, 7));
                cmdCommand.Parameters["@EXF_C_DOCUMENTO"].Value = pobjMLExtratoFinanceiro.Documento;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion
    }
}


