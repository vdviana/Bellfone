using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para MiniBanner 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class DLMiniBanner : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.0]</user> 
        public DLMiniBanner()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }
        
        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLMiniBanner">Parametros para filtro</param>
        /// <returns>Lista de MiniBanner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLMiniBanner> Listar(MLMiniBanner pobjMLMiniBanner)
        {

            List<MLMiniBanner> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_MINI_BANNER");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLMiniBanner.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@MBN_N_CODIGO"].Value = pobjMLMiniBanner.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMiniBanner.Titulo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_C_TITULO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@MBN_C_TITULO"].Value = pobjMLMiniBanner.Titulo;
            }
            if (!string.IsNullOrEmpty(pobjMLMiniBanner.Link))
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_C_LINK", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@MBN_C_LINK"].Value = pobjMLMiniBanner.Link;
            }
            if (pobjMLMiniBanner.Largura.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_N_LARGURA", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@MBN_N_LARGURA"].Value = pobjMLMiniBanner.Largura.Value;
            }
            if (pobjMLMiniBanner.Altura.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_N_ALTURA", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@MBN_N_ALTURA"].Value = pobjMLMiniBanner.Altura.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMiniBanner.Extensao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_C_EXTENSAO", FWDbType.Varchar, 4));
                cmdCommand.Parameters["@MBN_C_EXTENSAO"].Value = pobjMLMiniBanner.Extensao;
            }
            if (pobjMLMiniBanner.Ordem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_N_ORDEM", FWDbType.Int32));
                cmdCommand.Parameters["@MBN_N_ORDEM"].Value = pobjMLMiniBanner.Ordem.Value;
            }
            if (pobjMLMiniBanner.IsFixo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_B_FIXO", FWDbType.Boolean));
                cmdCommand.Parameters["@MBN_B_FIXO"].Value = pobjMLMiniBanner.IsFixo.Value;
            }
            if (pobjMLMiniBanner.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@MBN_B_STATUS"].Value = pobjMLMiniBanner.IsStatus.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLMiniBanner objRetorno = null;
                lstRetorno = new List<MLMiniBanner>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLMiniBanner();
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

        /// <summary> 
        /// Executa a Stored Procedure de Listagem de MiniBanner´s Fixos e completa com os outros
        /// </summary>         
        /// <returns>Lista de MiniBanner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public List<MLMiniBanner> ListarFixos()
        {

            List<MLMiniBanner> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_MINI_BANNER_FIXOS");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            IDataReader idrRetorno = null;
            try
            {
                MLMiniBanner objRetorno = null;
                lstRetorno = new List<MLMiniBanner>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLMiniBanner();
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
        /// <returns>MiniBanner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public MLMiniBanner Obter(decimal pdecCodigo)
        {

            MLMiniBanner objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_MINI_BANNER");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@MBN_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@MBN_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MBN_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_MBN_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MBN_C_TITULO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_MBN_C_TITULO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MBN_C_LINK", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_MBN_C_LINK"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MBN_N_LARGURA", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_MBN_N_LARGURA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MBN_N_ALTURA", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_MBN_N_ALTURA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MBN_C_EXTENSAO", FWDbType.Varchar, 4));
            cmdCommand.Parameters["@OUT_MBN_C_EXTENSAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MBN_N_ORDEM", FWDbType.Int32));
            cmdCommand.Parameters["@OUT_MBN_N_ORDEM"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MBN_B_FIXO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_MBN_B_FIXO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MBN_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_MBN_B_STATUS"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_MBN_N_CODIGO") && cmdCommand.Parameters["@OUT_MBN_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLMiniBanner();

                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_MBN_N_CODIGO"].Value);
                    if (cmdCommand.Parameters.Contains("@OUT_MBN_C_TITULO") && cmdCommand.Parameters["@OUT_MBN_C_TITULO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Titulo = cmdCommand.Parameters["@OUT_MBN_C_TITULO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_MBN_C_LINK") && cmdCommand.Parameters["@OUT_MBN_C_LINK"].Value != System.DBNull.Value)
                    {
                        objRetorno.Link = cmdCommand.Parameters["@OUT_MBN_C_LINK"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_MBN_N_LARGURA") && cmdCommand.Parameters["@OUT_MBN_N_LARGURA"].Value != System.DBNull.Value)
                    {
                        objRetorno.Largura = Convert.ToDecimal(cmdCommand.Parameters["@OUT_MBN_N_LARGURA"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_MBN_N_ALTURA") && cmdCommand.Parameters["@OUT_MBN_N_ALTURA"].Value != System.DBNull.Value)
                    {
                        objRetorno.Altura = Convert.ToDecimal(cmdCommand.Parameters["@OUT_MBN_N_ALTURA"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_MBN_C_EXTENSAO") && cmdCommand.Parameters["@OUT_MBN_C_EXTENSAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Extensao = cmdCommand.Parameters["@OUT_MBN_C_EXTENSAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_MBN_N_ORDEM") && cmdCommand.Parameters["@OUT_MBN_N_ORDEM"].Value != System.DBNull.Value)
                    {
                        objRetorno.Ordem = Convert.ToInt32(cmdCommand.Parameters["@OUT_MBN_N_ORDEM"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_MBN_B_FIXO") && cmdCommand.Parameters["@OUT_MBN_B_FIXO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsFixo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_MBN_B_FIXO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_MBN_B_STATUS") && cmdCommand.Parameters["@OUT_MBN_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsStatus = Convert.ToBoolean(cmdCommand.Parameters["@OUT_MBN_B_STATUS"].Value);
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

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_MINI_BANNER");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@MBN_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@MBN_N_CODIGO"].Value = pdecCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLMiniBanner">MiniBanner para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public int Alterar(MLMiniBanner pobjMLMiniBanner)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_MINI_BANNER");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLMiniBanner.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@MBN_N_CODIGO"].Value = pobjMLMiniBanner.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMiniBanner.Titulo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_C_TITULO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@MBN_C_TITULO"].Value = pobjMLMiniBanner.Titulo;
            }
            if (!string.IsNullOrEmpty(pobjMLMiniBanner.Link))
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_C_LINK", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@MBN_C_LINK"].Value = pobjMLMiniBanner.Link;
            }
            if (pobjMLMiniBanner.Largura.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_N_LARGURA", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@MBN_N_LARGURA"].Value = pobjMLMiniBanner.Largura.Value;
            }
            if (pobjMLMiniBanner.Altura.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_N_ALTURA", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@MBN_N_ALTURA"].Value = pobjMLMiniBanner.Altura.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMiniBanner.Extensao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_C_EXTENSAO", FWDbType.Varchar, 4));
                cmdCommand.Parameters["@MBN_C_EXTENSAO"].Value = pobjMLMiniBanner.Extensao;
            }
            if (pobjMLMiniBanner.Ordem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_N_ORDEM", FWDbType.Int32));
                cmdCommand.Parameters["@MBN_N_ORDEM"].Value = pobjMLMiniBanner.Ordem.Value;
            }
            if (pobjMLMiniBanner.IsFixo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_B_FIXO", FWDbType.Boolean));
                cmdCommand.Parameters["@MBN_B_FIXO"].Value = pobjMLMiniBanner.IsFixo.Value;
            }
            if (pobjMLMiniBanner.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@MBN_B_STATUS"].Value = pobjMLMiniBanner.IsStatus.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLMiniBanner">MiniBanner para inserir</param>
        /// <returns>Código MiniBanner</returns> 
        /// <user>GeradorVm2 [2.3.0.0]</user>
        public decimal Inserir(MLMiniBanner pobjMLMiniBanner)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_MINI_BANNER");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLMiniBanner.Titulo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_C_TITULO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@MBN_C_TITULO"].Value = pobjMLMiniBanner.Titulo;
            }
            if (!string.IsNullOrEmpty(pobjMLMiniBanner.Link))
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_C_LINK", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@MBN_C_LINK"].Value = pobjMLMiniBanner.Link;
            }
            if (pobjMLMiniBanner.Largura.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_N_LARGURA", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@MBN_N_LARGURA"].Value = pobjMLMiniBanner.Largura.Value;
            }
            if (pobjMLMiniBanner.Altura.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_N_ALTURA", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@MBN_N_ALTURA"].Value = pobjMLMiniBanner.Altura.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMiniBanner.Extensao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_C_EXTENSAO", FWDbType.Varchar, 4));
                cmdCommand.Parameters["@MBN_C_EXTENSAO"].Value = pobjMLMiniBanner.Extensao;
            }
            if (pobjMLMiniBanner.Ordem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_N_ORDEM", FWDbType.Int32));
                cmdCommand.Parameters["@MBN_N_ORDEM"].Value = pobjMLMiniBanner.Ordem.Value;
            }
            if (pobjMLMiniBanner.IsFixo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_B_FIXO", FWDbType.Boolean));
                cmdCommand.Parameters["@MBN_B_FIXO"].Value = pobjMLMiniBanner.IsFixo.Value;
            }
            if (pobjMLMiniBanner.IsStatus.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MBN_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@MBN_B_STATUS"].Value = pobjMLMiniBanner.IsStatus.Value;
            }

            return Convert.ToDecimal(conProvider.ExecuteScalar(cmdCommand));

        }

        #endregion
    }
}


