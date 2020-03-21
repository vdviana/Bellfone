using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using BellFone.B2B.Model;

namespace BellFone.B2B.DataLayer
{
    /// <summary> 
    /// Classe de conexão de dados para Vendedor 
    /// </summary> 
    /// <user>GeradorVm2 [2.3.0.0]</user> 
    public class DLVendedor : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2 [2.3.0.0]</user> 
        public DLVendedor()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLVendedor">Parametros para filtro</param>
        /// <returns>Lista de Vendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public List<MLVendedor> Listar(MLVendedor pobjMLVendedor)
        {

            List<MLVendedor> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_BLF_L_VENDEDOR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (!string.IsNullOrEmpty(pobjMLVendedor.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@VEN_C_CODIGO"].Value = pobjMLVendedor.Codigo;
            }
            if (pobjMLVendedor.CodigoUsuario.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_USU_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@VEN_USU_N_CODIGO"].Value = pobjMLVendedor.CodigoUsuario.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLVendedor.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@VEN_C_NOME"].Value = pobjMLVendedor.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLVendedor.Ramal))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_RAMAL", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@VEN_C_RAMAL"].Value = pobjMLVendedor.Ramal;
            }
            if (!string.IsNullOrEmpty(pobjMLVendedor.Email1))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_EMAIL1", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@VEN_C_EMAIL1"].Value = pobjMLVendedor.Email1;
            }
            if (!string.IsNullOrEmpty(pobjMLVendedor.Email2))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_EMAIL2", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@VEN_C_EMAIL2"].Value = pobjMLVendedor.Email2;
            }
            if (pobjMLVendedor.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@VEN_B_ATIVO"].Value = pobjMLVendedor.IsAtivo.Value;
            }

            IDataReader idrRetorno = null;
            try
            {
                MLVendedor objRetorno = null;
                lstRetorno = new List<MLVendedor>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLVendedor();
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
        /// <returns>Vendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLVendedor Obter(string pstrCodigo)
        {

            MLVendedor objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_VENDEDOR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@VEN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@VEN_C_CODIGO"].Value = pstrCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_VEN_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_USU_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_VEN_USU_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_NOME", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_VEN_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_RAMAL", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_VEN_C_RAMAL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_EMAIL1", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_VEN_C_EMAIL1"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_EMAIL2", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_VEN_C_EMAIL2"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_VEN_B_ATIVO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_VEN_C_CODIGO") && cmdCommand.Parameters["@OUT_VEN_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLVendedor();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_VEN_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_VEN_USU_N_CODIGO") && cmdCommand.Parameters["@OUT_VEN_USU_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoUsuario = Convert.ToDecimal(cmdCommand.Parameters["@OUT_VEN_USU_N_CODIGO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_C_NOME") && cmdCommand.Parameters["@OUT_VEN_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.Nome = cmdCommand.Parameters["@OUT_VEN_C_NOME"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_C_RAMAL") && cmdCommand.Parameters["@OUT_VEN_C_RAMAL"].Value != System.DBNull.Value)
                    {
                        objRetorno.Ramal = cmdCommand.Parameters["@OUT_VEN_C_RAMAL"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_C_EMAIL1") && cmdCommand.Parameters["@OUT_VEN_C_EMAIL1"].Value != System.DBNull.Value)
                    {
                        objRetorno.Email1 = cmdCommand.Parameters["@OUT_VEN_C_EMAIL1"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_C_EMAIL2") && cmdCommand.Parameters["@OUT_VEN_C_EMAIL2"].Value != System.DBNull.Value)
                    {
                        objRetorno.Email2 = cmdCommand.Parameters["@OUT_VEN_C_EMAIL2"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_B_ATIVO") && cmdCommand.Parameters["@OUT_VEN_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_VEN_B_ATIVO"].Value);
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

            FWCommand cmdCommand = new FWCommand("USP_BLF_D_VENDEDOR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@VEN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@VEN_C_CODIGO"].Value = pstrCodigo;

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Alterar

        /// <summary> 
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLVendedor">Vendedor para alterar</param>
        /// <returns>Quantidade de Registro Atualizados</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Alterar(MLVendedor pobjMLVendedor)
        {

            FWCommand cmdCommand = new FWCommand("USP_BLF_U_VENDEDOR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLVendedor.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@VEN_C_CODIGO"].Value = pobjMLVendedor.Codigo;
            }
            if (pobjMLVendedor.CodigoUsuario.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_USU_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@VEN_USU_N_CODIGO"].Value = pobjMLVendedor.CodigoUsuario.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLVendedor.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@VEN_C_NOME"].Value = pobjMLVendedor.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLVendedor.Ramal))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_RAMAL", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@VEN_C_RAMAL"].Value = pobjMLVendedor.Ramal;
            }
            if (!string.IsNullOrEmpty(pobjMLVendedor.Email1))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_EMAIL1", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@VEN_C_EMAIL1"].Value = pobjMLVendedor.Email1;
            }
            if (!string.IsNullOrEmpty(pobjMLVendedor.Email2))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_EMAIL2", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@VEN_C_EMAIL2"].Value = pobjMLVendedor.Email2;
            }
            if (pobjMLVendedor.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@VEN_B_ATIVO"].Value = pobjMLVendedor.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion

        #region Inserir

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLVendedor">Vendedor para inserir</param>
        /// <returns>Quantidade de Registro Inseridos</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public int Inserir(MLVendedor pobjMLVendedor)
        {           

            FWCommand cmdCommand = new FWCommand("USP_BLF_I_VENDEDOR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLVendedor.Codigo))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_CODIGO", FWDbType.Varchar, 3));
                cmdCommand.Parameters["@VEN_C_CODIGO"].Value = pobjMLVendedor.Codigo;
            }
            if (pobjMLVendedor.CodigoUsuario.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_USU_N_CODIGO", FWDbType.Decimal, 18));
                cmdCommand.Parameters["@VEN_USU_N_CODIGO"].Value = pobjMLVendedor.CodigoUsuario.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLVendedor.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@VEN_C_NOME"].Value = pobjMLVendedor.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLVendedor.Ramal))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_RAMAL", FWDbType.Varchar, 5));
                cmdCommand.Parameters["@VEN_C_RAMAL"].Value = pobjMLVendedor.Ramal;
            }
            if (!string.IsNullOrEmpty(pobjMLVendedor.Email1))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_EMAIL1", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@VEN_C_EMAIL1"].Value = pobjMLVendedor.Email1;
            }
            if (!string.IsNullOrEmpty(pobjMLVendedor.Email2))
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_C_EMAIL2", FWDbType.Varchar, 100));
                cmdCommand.Parameters["@VEN_C_EMAIL2"].Value = pobjMLVendedor.Email2;
            }
            if (pobjMLVendedor.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@VEN_B_ATIVO", FWDbType.Boolean));
                cmdCommand.Parameters["@VEN_B_ATIVO"].Value = pobjMLVendedor.IsAtivo.Value;
            }

            return conProvider.ExecuteNonQuery(cmdCommand);

        }

        #endregion


        #region ObterPorEmail

        /// <summary> 
        /// Executa a stored procedure para retornar um registro específico
        /// </summary> 
        /// <param name="pstrEmail">Codigo</param>
        /// <returns>Vendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLVendedorCompleto ObterPorEmail(string pstrEmail)
        {

            MLVendedorCompleto objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_VENDEDOR_EMAIL");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@VEN_C_EMAIL", FWDbType.Varchar));
            cmdCommand.Parameters["@VEN_C_EMAIL"].Value = pstrEmail;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_VEN_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_USU_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_VEN_USU_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_NOME", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_VEN_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_RAMAL", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_VEN_C_RAMAL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_EMAIL1", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_VEN_C_EMAIL1"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_EMAIL2", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_VEN_C_EMAIL2"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_VEN_B_ATIVO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_USU_C_SENHA", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_USU_C_SENHA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_USU_C_LOGIN", FWDbType.Varchar, 200));
            cmdCommand.Parameters["@OUT_USU_C_LOGIN"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_VEN_C_CODIGO") && cmdCommand.Parameters["@OUT_VEN_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLVendedorCompleto();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_VEN_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_VEN_USU_N_CODIGO") && cmdCommand.Parameters["@OUT_VEN_USU_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoUsuario = Convert.ToDecimal(cmdCommand.Parameters["@OUT_VEN_USU_N_CODIGO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_C_NOME") && cmdCommand.Parameters["@OUT_VEN_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.Nome = cmdCommand.Parameters["@OUT_VEN_C_NOME"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_C_RAMAL") && cmdCommand.Parameters["@OUT_VEN_C_RAMAL"].Value != System.DBNull.Value)
                    {
                        objRetorno.Ramal = cmdCommand.Parameters["@OUT_VEN_C_RAMAL"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_C_EMAIL1") && cmdCommand.Parameters["@OUT_VEN_C_EMAIL1"].Value != System.DBNull.Value)
                    {
                        objRetorno.Email1 = cmdCommand.Parameters["@OUT_VEN_C_EMAIL1"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_C_EMAIL2") && cmdCommand.Parameters["@OUT_VEN_C_EMAIL2"].Value != System.DBNull.Value)
                    {
                        objRetorno.Email2 = cmdCommand.Parameters["@OUT_VEN_C_EMAIL2"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_B_ATIVO") && cmdCommand.Parameters["@OUT_VEN_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_VEN_B_ATIVO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_USU_C_LOGIN") && cmdCommand.Parameters["@OUT_USU_C_LOGIN"].Value != System.DBNull.Value)
                    {
                        objRetorno.Login = cmdCommand.Parameters["@OUT_USU_C_LOGIN"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_USU_C_SENHA") && cmdCommand.Parameters["@OUT_USU_C_SENHA"].Value != System.DBNull.Value)
                    {
                        objRetorno.Senha = cmdCommand.Parameters["@OUT_USU_C_SENHA"].Value.ToString();
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

        #region ObterPorUsuario

        /// <summary> 
        /// Executa a stored procedure para retornar um registro específico
        /// </summary> 
        /// <param name="pdecUsuario">Usuario</param>
        /// <returns>Vendedor</returns> 
        /// <user>GeradorVm2 [2.3.0.1]</user>
        public MLVendedor ObterPorUsuario(Decimal pdecUsuario)
        {

            MLVendedor objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_BLF_S_VENDEDOR_USUARIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@VEN_USU_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@VEN_USU_N_CODIGO"].Value = pdecUsuario;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_CODIGO", FWDbType.Varchar, 3));
            cmdCommand.Parameters["@OUT_VEN_C_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_USU_N_CODIGO", FWDbType.Decimal, 18));
            cmdCommand.Parameters["@OUT_VEN_USU_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_NOME", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_VEN_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_RAMAL", FWDbType.Varchar, 5));
            cmdCommand.Parameters["@OUT_VEN_C_RAMAL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_EMAIL1", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_VEN_C_EMAIL1"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_C_EMAIL2", FWDbType.Varchar, 100));
            cmdCommand.Parameters["@OUT_VEN_C_EMAIL2"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_VEN_B_ATIVO", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_VEN_B_ATIVO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters.Contains("@OUT_VEN_C_CODIGO") && cmdCommand.Parameters["@OUT_VEN_C_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno = new MLVendedor();

                    objRetorno.Codigo = cmdCommand.Parameters["@OUT_VEN_C_CODIGO"].Value.ToString();
                    if (cmdCommand.Parameters.Contains("@OUT_VEN_USU_N_CODIGO") && cmdCommand.Parameters["@OUT_VEN_USU_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoUsuario = Convert.ToDecimal(cmdCommand.Parameters["@OUT_VEN_USU_N_CODIGO"].Value);
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_C_NOME") && cmdCommand.Parameters["@OUT_VEN_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.Nome = cmdCommand.Parameters["@OUT_VEN_C_NOME"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_C_RAMAL") && cmdCommand.Parameters["@OUT_VEN_C_RAMAL"].Value != System.DBNull.Value)
                    {
                        objRetorno.Ramal = cmdCommand.Parameters["@OUT_VEN_C_RAMAL"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_C_EMAIL1") && cmdCommand.Parameters["@OUT_VEN_C_EMAIL1"].Value != System.DBNull.Value)
                    {
                        objRetorno.Email1 = cmdCommand.Parameters["@OUT_VEN_C_EMAIL1"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_C_EMAIL2") && cmdCommand.Parameters["@OUT_VEN_C_EMAIL2"].Value != System.DBNull.Value)
                    {
                        objRetorno.Email2 = cmdCommand.Parameters["@OUT_VEN_C_EMAIL2"].Value.ToString();
                    }

                    if (cmdCommand.Parameters.Contains("@OUT_VEN_B_ATIVO") && cmdCommand.Parameters["@OUT_VEN_B_ATIVO"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_VEN_B_ATIVO"].Value);
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


