using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para Revendedor 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class DLRevendedor : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.0]</user> 
        public DLRevendedor()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }
        
        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLRevendedor">Parametros para filtro</param>
        /// <returns>Lista de Revendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLRevendedor> Listar(MLRevendedor pobjMLRevendedor)
        {

            List<MLRevendedor> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_REVENDEDOR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLRevendedor.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@REV_C_CODIGO"].Value = pobjMLRevendedor.Codigo;
            }
            if (pobjMLRevendedor.CodigoUsuario.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_USU_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@REV_USU_N_CODIGO"].Value = pobjMLRevendedor.CodigoUsuario.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.CodigoVendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_VEN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@REV_VEN_C_CODIGO"].Value = pobjMLRevendedor.CodigoVendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.RazaoSocial))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_RAZAO_SOCIAL", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@REV_C_RAZAO_SOCIAL"].Value = pobjMLRevendedor.RazaoSocial;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Doc))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_DOC", FWDbType.Varchar, 18));
                cmdCommand.Parameters["@REV_C_DOC"].Value = pobjMLRevendedor.Doc;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Ie))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_IE", FWDbType.Varchar, 20));
                cmdCommand.Parameters["@REV_C_IE"].Value = pobjMLRevendedor.Ie;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Email))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_EMAIL", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@REV_C_EMAIL"].Value = pobjMLRevendedor.Email;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Endereco))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_ENDERECO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@REV_C_ENDERECO"].Value = pobjMLRevendedor.Endereco;
            }
            if (pobjMLRevendedor.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@REV_B_ATIVO"].Value = pobjMLRevendedor.IsAtivo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Tipo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_TIPO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@REV_C_TIPO"].Value = pobjMLRevendedor.Tipo;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.TipoRevenda))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_TIPO_REVENDA", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@REV_C_TIPO_REVENDA"].Value = pobjMLRevendedor.TipoRevenda;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Classificacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_CLASSIFICACAO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@REV_C_CLASSIFICACAO"].Value = pobjMLRevendedor.Classificacao;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLRevendedor objRetorno = null;
                lstRetorno = new List<MLRevendedor>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLRevendedor();
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
        /// <returns>Revendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLRevendedor Obter(string pstrCodigo)
        {

            MLRevendedor objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_REVENDEDOR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@REV_C_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@REV_C_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_REV_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_USU_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_REV_USU_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_VEN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_REV_VEN_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_RAZAO_SOCIAL", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_REV_C_RAZAO_SOCIAL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_DOC", FWDbType.Varchar, 18));
            cmdCommand.Parameters["@OUT_REV_C_DOC"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_IE", FWDbType.Varchar, 20));
            cmdCommand.Parameters["@OUT_REV_C_IE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_EMAIL", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_REV_C_EMAIL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_ENDERECO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_REV_C_ENDERECO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_REV_B_ATIVO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_TIPO", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@OUT_REV_C_TIPO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_TIPO_REVENDA", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@OUT_REV_C_TIPO_REVENDA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_CLASSIFICACAO", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@OUT_REV_C_CLASSIFICACAO"].Direction = ParameterDirection.Output;

            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_TELEFONE", FWDbType.Varchar, 20));
            cmdCommand.Parameters["@OUT_REV_C_TELEFONE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_CONTATO", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_REV_C_CONTATO"].Direction = ParameterDirection.Output;


            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_REV_C_CODIGO") && cmdCommand.Parameters["@OUT_REV_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLRevendedor();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_REV_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_REV_USU_N_CODIGO") && cmdCommand.Parameters["@OUT_REV_USU_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoUsuario = Convert.ToDecimal(cmdCommand.Parameters["@OUT_REV_USU_N_CODIGO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_VEN_C_CODIGO") && cmdCommand.Parameters["@OUT_REV_VEN_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoVendedor = cmdCommand.Parameters["@OUT_REV_VEN_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_RAZAO_SOCIAL") && cmdCommand.Parameters["@OUT_REV_C_RAZAO_SOCIAL"].Value != System.DBNull.Value)
                    {
                        objRetorno.RazaoSocial = cmdCommand.Parameters["@OUT_REV_C_RAZAO_SOCIAL"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_DOC") && cmdCommand.Parameters["@OUT_REV_C_DOC"].Value != System.DBNull.Value)
                    {
                        objRetorno.Doc = cmdCommand.Parameters["@OUT_REV_C_DOC"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_IE") && cmdCommand.Parameters["@OUT_REV_C_IE"].Value != System.DBNull.Value)
                    {
                        objRetorno.Ie = cmdCommand.Parameters["@OUT_REV_C_IE"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_EMAIL") && cmdCommand.Parameters["@OUT_REV_C_EMAIL"].Value != System.DBNull.Value)
                    {
                        objRetorno.Email = cmdCommand.Parameters["@OUT_REV_C_EMAIL"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_ENDERECO") && cmdCommand.Parameters["@OUT_REV_C_ENDERECO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Endereco = cmdCommand.Parameters["@OUT_REV_C_ENDERECO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_B_ATIVO") && cmdCommand.Parameters["@OUT_REV_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_REV_B_ATIVO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_TIPO") && cmdCommand.Parameters["@OUT_REV_C_TIPO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Tipo = cmdCommand.Parameters["@OUT_REV_C_TIPO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_TIPO_REVENDA") && cmdCommand.Parameters["@OUT_REV_C_TIPO_REVENDA"].Value != System.DBNull.Value)
                    {
                        objRetorno.TipoRevenda = cmdCommand.Parameters["@OUT_REV_C_TIPO_REVENDA"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_CLASSIFICACAO") && cmdCommand.Parameters["@OUT_REV_C_CLASSIFICACAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Classificacao = cmdCommand.Parameters["@OUT_REV_C_CLASSIFICACAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_TELEFONE") && cmdCommand.Parameters["@OUT_REV_C_TELEFONE"].Value != System.DBNull.Value)
                    {
                        objRetorno.Telefone = cmdCommand.Parameters["@OUT_REV_C_TELEFONE"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_CONTATO") && cmdCommand.Parameters["@OUT_REV_C_CONTATO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Contato = cmdCommand.Parameters["@OUT_REV_C_CONTATO"].Value.ToString();
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
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Excluir(string pstrCodigo)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_REVENDEDOR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@REV_C_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@REV_C_CODIGO"].Value = pstrCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLRevendedor">Revendedor para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLRevendedor pobjMLRevendedor)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_REVENDEDOR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@REV_C_CODIGO"].Value = pobjMLRevendedor.Codigo;
            }
            if (pobjMLRevendedor.CodigoUsuario.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_USU_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@REV_USU_N_CODIGO"].Value = pobjMLRevendedor.CodigoUsuario.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.CodigoVendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_VEN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@REV_VEN_C_CODIGO"].Value = pobjMLRevendedor.CodigoVendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.RazaoSocial))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_RAZAO_SOCIAL", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@REV_C_RAZAO_SOCIAL"].Value = pobjMLRevendedor.RazaoSocial;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Doc))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_DOC", FWDbType.Varchar, 18));
                cmdCommand.Parameters["@REV_C_DOC"].Value = pobjMLRevendedor.Doc;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Ie))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_IE", FWDbType.Varchar, 20));
                cmdCommand.Parameters["@REV_C_IE"].Value = pobjMLRevendedor.Ie;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Email))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_EMAIL", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@REV_C_EMAIL"].Value = pobjMLRevendedor.Email;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Endereco))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_ENDERECO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@REV_C_ENDERECO"].Value = pobjMLRevendedor.Endereco;
            }
            if (pobjMLRevendedor.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@REV_B_ATIVO"].Value = pobjMLRevendedor.IsAtivo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Tipo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_TIPO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@REV_C_TIPO"].Value = pobjMLRevendedor.Tipo;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.TipoRevenda))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_TIPO_REVENDA", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@REV_C_TIPO_REVENDA"].Value = pobjMLRevendedor.TipoRevenda;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Classificacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_CLASSIFICACAO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@REV_C_CLASSIFICACAO"].Value = pobjMLRevendedor.Classificacao;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Telefone))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_TELEFONE", FWDbType.Varchar, 20));
                cmdCommand.Parameters["@REV_C_TELEFONE"].Value = pobjMLRevendedor.Telefone;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Contato))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_CONTATO", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@REV_C_CONTATO"].Value = pobjMLRevendedor.Contato;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLRevendedor">Revendedor para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Inserir(MLRevendedor pobjMLRevendedor)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_REVENDEDOR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_CODIGO", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@REV_C_CODIGO"].Value = pobjMLRevendedor.Codigo;
            }
            if (pobjMLRevendedor.CodigoUsuario.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_USU_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@REV_USU_N_CODIGO"].Value = pobjMLRevendedor.CodigoUsuario.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.CodigoVendedor))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_VEN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@REV_VEN_C_CODIGO"].Value = pobjMLRevendedor.CodigoVendedor;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.RazaoSocial))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_RAZAO_SOCIAL", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@REV_C_RAZAO_SOCIAL"].Value = pobjMLRevendedor.RazaoSocial;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Doc))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_DOC", FWDbType.Varchar, 18));
                cmdCommand.Parameters["@REV_C_DOC"].Value = pobjMLRevendedor.Doc;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Ie))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_IE", FWDbType.Varchar, 20));
                cmdCommand.Parameters["@REV_C_IE"].Value = pobjMLRevendedor.Ie;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Email))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_EMAIL", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@REV_C_EMAIL"].Value = pobjMLRevendedor.Email;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Endereco))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_ENDERECO", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@REV_C_ENDERECO"].Value = pobjMLRevendedor.Endereco;
            }
            if (pobjMLRevendedor.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@REV_B_ATIVO"].Value = pobjMLRevendedor.IsAtivo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Tipo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_TIPO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@REV_C_TIPO"].Value = pobjMLRevendedor.Tipo;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.TipoRevenda))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_TIPO_REVENDA", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@REV_C_TIPO_REVENDA"].Value = pobjMLRevendedor.TipoRevenda;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Classificacao))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_CLASSIFICACAO", FWDbType.Varchar, 1));
                cmdCommand.Parameters["@REV_C_CLASSIFICACAO"].Value = pobjMLRevendedor.Classificacao;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Telefone))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_TELEFONE", FWDbType.Varchar, 20));
                cmdCommand.Parameters["@REV_C_TELEFONE"].Value = pobjMLRevendedor.Telefone;
            }
            if (!string.IsNullOrEmpty(pobjMLRevendedor.Contato))
            {
                cmdCommand.Parameters.Add(new FWParameter("@REV_C_CONTATO", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@REV_C_CONTATO"].Value = pobjMLRevendedor.Contato;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);
            
        }

        #endregion

        #region Obter Por Usuário

        /// <summary> 
        /// Executa a stored procedure para retornar um registro específico
        /// </summary> 
        /// <param name="pdecUsuario">Codigo</param>
        /// <returns>Revendedor</returns> 
        /// <user>efranca</user>
        public MLRevendedor ObterPorUsuario(Decimal pdecUsuario)
        {

            MLRevendedor objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_REVENDEDOR_USUARIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@REV_USU_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@REV_USU_N_CODIGO"].Value = pdecUsuario;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_REV_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_USU_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_REV_USU_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_VEN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_REV_VEN_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_RAZAO_SOCIAL", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_REV_C_RAZAO_SOCIAL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_DOC", FWDbType.Varchar, 18));
            cmdCommand.Parameters["@OUT_REV_C_DOC"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_IE", FWDbType.Varchar, 20));
            cmdCommand.Parameters["@OUT_REV_C_IE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_EMAIL", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_REV_C_EMAIL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_ENDERECO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_REV_C_ENDERECO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_REV_B_ATIVO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_TIPO", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@OUT_REV_C_TIPO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_TIPO_REVENDA", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@OUT_REV_C_TIPO_REVENDA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_CLASSIFICACAO", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@OUT_REV_C_CLASSIFICACAO"].Direction = ParameterDirection.Output;

            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_TELEFONE", FWDbType.Varchar, 20));
            cmdCommand.Parameters["@OUT_REV_C_TELEFONE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_CONTATO", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_REV_C_CONTATO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_REV_C_CODIGO") && cmdCommand.Parameters["@OUT_REV_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLRevendedor();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_REV_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_REV_USU_N_CODIGO") && cmdCommand.Parameters["@OUT_REV_USU_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoUsuario = Convert.ToDecimal(cmdCommand.Parameters["@OUT_REV_USU_N_CODIGO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_VEN_C_CODIGO") && cmdCommand.Parameters["@OUT_REV_VEN_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoVendedor = cmdCommand.Parameters["@OUT_REV_VEN_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_RAZAO_SOCIAL") && cmdCommand.Parameters["@OUT_REV_C_RAZAO_SOCIAL"].Value != System.DBNull.Value)
                    {
                        objRetorno.RazaoSocial = cmdCommand.Parameters["@OUT_REV_C_RAZAO_SOCIAL"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_DOC") && cmdCommand.Parameters["@OUT_REV_C_DOC"].Value != System.DBNull.Value)
                    {
                        objRetorno.Doc = cmdCommand.Parameters["@OUT_REV_C_DOC"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_IE") && cmdCommand.Parameters["@OUT_REV_C_IE"].Value != System.DBNull.Value)
                    {
                        objRetorno.Ie = cmdCommand.Parameters["@OUT_REV_C_IE"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_EMAIL") && cmdCommand.Parameters["@OUT_REV_C_EMAIL"].Value != System.DBNull.Value)
                    {
                        objRetorno.Email = cmdCommand.Parameters["@OUT_REV_C_EMAIL"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_ENDERECO") && cmdCommand.Parameters["@OUT_REV_C_ENDERECO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Endereco = cmdCommand.Parameters["@OUT_REV_C_ENDERECO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_B_ATIVO") && cmdCommand.Parameters["@OUT_REV_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_REV_B_ATIVO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_TIPO") && cmdCommand.Parameters["@OUT_REV_C_TIPO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Tipo = cmdCommand.Parameters["@OUT_REV_C_TIPO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_TIPO_REVENDA") && cmdCommand.Parameters["@OUT_REV_C_TIPO_REVENDA"].Value != System.DBNull.Value)
                    {
                        objRetorno.TipoRevenda = cmdCommand.Parameters["@OUT_REV_C_TIPO_REVENDA"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_CLASSIFICACAO") && cmdCommand.Parameters["@OUT_REV_C_CLASSIFICACAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Classificacao = cmdCommand.Parameters["@OUT_REV_C_CLASSIFICACAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_TELEFONE") && cmdCommand.Parameters["@OUT_REV_C_TELEFONE"].Value != System.DBNull.Value)
                    {
                        objRetorno.Telefone = cmdCommand.Parameters["@OUT_REV_C_TELEFONE"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_CONTATO") && cmdCommand.Parameters["@OUT_REV_C_CONTATO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Contato = cmdCommand.Parameters["@OUT_REV_C_CONTATO"].Value.ToString();
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

        #region Obter Por Email

        /// <summary> 
        /// Executa a stored procedure para retornar um registro específico
        /// </summary> 
        /// <param name="pstrEmail">Codigo</param>
        /// <returns>Revendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLRevendedorCompleto ObterPorEmail(string pstrEmail)
        {

            MLRevendedorCompleto objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_REVENDEDOR_EMAIL");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@REV_C_EMAIL", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@REV_C_EMAIL"].Value = pstrEmail;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_CODIGO", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_REV_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_USU_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_REV_USU_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_VEN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_REV_VEN_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_RAZAO_SOCIAL", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_REV_C_RAZAO_SOCIAL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_DOC", FWDbType.Varchar, 18));
            cmdCommand.Parameters["@OUT_REV_C_DOC"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_IE", FWDbType.Varchar, 20));
            cmdCommand.Parameters["@OUT_REV_C_IE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_EMAIL", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_REV_C_EMAIL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_ENDERECO", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_REV_C_ENDERECO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_REV_B_ATIVO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_TIPO", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@OUT_REV_C_TIPO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_TIPO_REVENDA", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@OUT_REV_C_TIPO_REVENDA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_CLASSIFICACAO", FWDbType.Varchar, 1));
            cmdCommand.Parameters["@OUT_REV_C_CLASSIFICACAO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_USU_C_SENHA", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_USU_C_SENHA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_USU_C_LOGIN", FWDbType.Varchar, 200));
            cmdCommand.Parameters["@OUT_USU_C_LOGIN"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_USU_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_VEN_USU_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_NOME", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_VEN_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_TELEFONE", FWDbType.Varchar, 20));
            cmdCommand.Parameters["@OUT_REV_C_TELEFONE"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_REV_C_CONTATO", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_REV_C_CONTATO"].Direction = ParameterDirection.Output;
            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_REV_C_CODIGO") && cmdCommand.Parameters["@OUT_REV_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLRevendedorCompleto();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_REV_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_REV_USU_N_CODIGO") && cmdCommand.Parameters["@OUT_REV_USU_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoUsuario = Convert.ToDecimal(cmdCommand.Parameters["@OUT_REV_USU_N_CODIGO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_VEN_C_CODIGO") && cmdCommand.Parameters["@OUT_REV_VEN_C_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoVendedor = cmdCommand.Parameters["@OUT_REV_VEN_C_CODIGO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_RAZAO_SOCIAL") && cmdCommand.Parameters["@OUT_REV_C_RAZAO_SOCIAL"].Value != System.DBNull.Value)
                    {
                        objRetorno.RazaoSocial = cmdCommand.Parameters["@OUT_REV_C_RAZAO_SOCIAL"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_DOC") && cmdCommand.Parameters["@OUT_REV_C_DOC"].Value != System.DBNull.Value)
                    {
                        objRetorno.Doc = cmdCommand.Parameters["@OUT_REV_C_DOC"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_IE") && cmdCommand.Parameters["@OUT_REV_C_IE"].Value != System.DBNull.Value)
                    {
                        objRetorno.Ie = cmdCommand.Parameters["@OUT_REV_C_IE"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_EMAIL") && cmdCommand.Parameters["@OUT_REV_C_EMAIL"].Value != System.DBNull.Value)
                    {
                        objRetorno.Email = cmdCommand.Parameters["@OUT_REV_C_EMAIL"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_ENDERECO") && cmdCommand.Parameters["@OUT_REV_C_ENDERECO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Endereco = cmdCommand.Parameters["@OUT_REV_C_ENDERECO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_B_ATIVO") && cmdCommand.Parameters["@OUT_REV_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_REV_B_ATIVO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_TIPO") && cmdCommand.Parameters["@OUT_REV_C_TIPO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Tipo = cmdCommand.Parameters["@OUT_REV_C_TIPO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_TIPO_REVENDA") && cmdCommand.Parameters["@OUT_REV_C_TIPO_REVENDA"].Value != System.DBNull.Value)
                    {
                        objRetorno.TipoRevenda = cmdCommand.Parameters["@OUT_REV_C_TIPO_REVENDA"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_CLASSIFICACAO") && cmdCommand.Parameters["@OUT_REV_C_CLASSIFICACAO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Classificacao = cmdCommand.Parameters["@OUT_REV_C_CLASSIFICACAO"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_USU_C_LOGIN") && cmdCommand.Parameters["@OUT_USU_C_LOGIN"].Value != System.DBNull.Value)
                    {
                        objRetorno.Login = cmdCommand.Parameters["@OUT_USU_C_LOGIN"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_USU_C_SENHA") && cmdCommand.Parameters["@OUT_USU_C_SENHA"].Value != System.DBNull.Value)
                    {
                        objRetorno.Senha = cmdCommand.Parameters["@OUT_USU_C_SENHA"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_USU_N_CODIGO") && cmdCommand.Parameters["@OUT_VEN_USU_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.VendedorUsuario = Convert.ToDecimal(cmdCommand.Parameters["@OUT_VEN_USU_N_CODIGO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_C_NOME") && cmdCommand.Parameters["@OUT_VEN_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.VendedorNome = cmdCommand.Parameters["@OUT_VEN_C_NOME"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_TELEFONE") && cmdCommand.Parameters["@OUT_REV_C_TELEFONE"].Value != System.DBNull.Value)
                    {
                        objRetorno.Telefone = cmdCommand.Parameters["@OUT_REV_C_TELEFONE"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_REV_C_CONTATO") && cmdCommand.Parameters["@OUT_REV_C_CONTATO"].Value != System.DBNull.Value)
                    {
                        objRetorno.Contato = cmdCommand.Parameters["@OUT_REV_C_CONTATO"].Value.ToString();
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
    }
}


