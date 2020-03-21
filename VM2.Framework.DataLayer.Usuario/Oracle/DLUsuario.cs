using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model.Usuario;

namespace VM2.Framework.DataLayer.Usuario.Oracle
{
    /// <summary> 
    /// Classe de conexão de dados para Usuario 
    /// </summary> 
    /// <user>mazevedo</user> 
    public class DLUsuario : DLFWBase, IDLUsuario
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>mazevedo</user> 
        public DLUsuario()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLUsuario">Parametros para filtro</param>
        /// <returns>Lista de Usuario</returns> 
        /// <user>mazevedo</user>
        public List<MLUsuario> Listar(MLUsuario pobjMLUsuario)
        {

            List<MLUsuario> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWK_L_USUARIO");

            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLUsuario.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["USU_N_CODIGO"].Value = pobjMLUsuario.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLUsuario.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_C_NOME", FWDbType.Varchar, 100));
                cmdCommand.Parameters["USU_C_NOME"].Value = pobjMLUsuario.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLUsuario.Login))
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_C_LOGIN", FWDbType.Varchar, 50));
                cmdCommand.Parameters["USU_C_LOGIN"].Value = pobjMLUsuario.Login;
            }
            if (!string.IsNullOrEmpty(pobjMLUsuario.Senha))
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_C_SENHA", FWDbType.Varchar, 50));
                cmdCommand.Parameters["USU_C_SENHA"].Value = pobjMLUsuario.Senha;
            }
            if (!string.IsNullOrEmpty(pobjMLUsuario.Email))
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_C_EMAIL", FWDbType.Varchar, 200));
                cmdCommand.Parameters["USU_C_EMAIL"].Value = pobjMLUsuario.Email;
            }
            if (pobjMLUsuario.DataCadastro.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_D_CADASTRO", FWDbType.DateTime));
                cmdCommand.Parameters["USU_D_CADASTRO"].Value = pobjMLUsuario.DataCadastro.Value;
            }
            if (pobjMLUsuario.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["USU_B_STATUS"].Value = pobjMLUsuario.IsAtivo.Value;
            }

            // Retorno do Curso
            cmdCommand.Parameters.Add(new FWParameter("RCT1", FWDbType.Cursor));
            cmdCommand.Parameters["RCT1"].Direction = ParameterDirection.Output;

            IDataReader idrRetorno = null;
            try
            {
                MLUsuario objRetorno = null;
                lstRetorno = new List<MLUsuario>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLUsuario();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
            }
            catch (Exception)
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
        /// <returns>Usuario</returns> 
        /// <user>mazevedo</user>
        public MLUsuario Obter(decimal pdecCodigo)
        {

            MLUsuario objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWK_S_USUARIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("USU_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["USU_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["OUT_USU_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_C_NOME", FWDbType.Varchar, 100));
            cmdCommand.Parameters["OUT_USU_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_C_LOGIN", FWDbType.Varchar, 200));
            cmdCommand.Parameters["OUT_USU_C_LOGIN"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_C_SENHA", FWDbType.Varchar, 50));
            cmdCommand.Parameters["OUT_USU_C_SENHA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_C_EMAIL", FWDbType.Varchar, 200));
            cmdCommand.Parameters["OUT_USU_C_EMAIL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_D_CADASTRO", FWDbType.DateTime));
            cmdCommand.Parameters["OUT_USU_D_CADASTRO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["OUT_USU_B_STATUS"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_B_ALTERARSENHA", FWDbType.Boolean));
            cmdCommand.Parameters["OUT_USU_B_ALTERARSENHA"].Direction = ParameterDirection.Output;

            try
            {
                objRetorno = new MLUsuario();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["OUT_USU_N_CODIGO"] != null) && cmdCommand.Parameters["OUT_USU_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["OUT_USU_N_CODIGO"].Value.ToString());
                    if ((cmdCommand.Parameters["OUT_USU_C_NOME"] != null) && cmdCommand.Parameters["OUT_USU_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.Nome = Convert.ToString(cmdCommand.Parameters["OUT_USU_C_NOME"].Value.ToString());
                    }

                    if ((cmdCommand.Parameters["OUT_USU_C_LOGIN"] != null) && cmdCommand.Parameters["OUT_USU_C_LOGIN"].Value != System.DBNull.Value)
                    {
                        objRetorno.Login = Convert.ToString(cmdCommand.Parameters["OUT_USU_C_LOGIN"].Value.ToString());
                    }

                    if ((cmdCommand.Parameters["OUT_USU_C_SENHA"] != null) && cmdCommand.Parameters["OUT_USU_C_SENHA"].Value != System.DBNull.Value)
                    {
                        objRetorno.Senha = Convert.ToString(cmdCommand.Parameters["OUT_USU_C_SENHA"].Value.ToString());
                    }

                    if ((cmdCommand.Parameters["OUT_USU_C_EMAIL"] != null) && cmdCommand.Parameters["OUT_USU_C_EMAIL"].Value != System.DBNull.Value)
                    {
                        objRetorno.Email = Convert.ToString(cmdCommand.Parameters["OUT_USU_C_EMAIL"].Value.ToString());
                    }

                    if ((cmdCommand.Parameters["OUT_USU_D_CADASTRO"] != null) && cmdCommand.Parameters["OUT_USU_D_CADASTRO"].Value != System.DBNull.Value)
                    {
                        objRetorno.DataCadastro = Convert.ToDateTime(cmdCommand.Parameters["OUT_USU_D_CADASTRO"].Value);
                    }

                    if ((cmdCommand.Parameters["OUT_USU_B_STATUS"] != null) && cmdCommand.Parameters["OUT_USU_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["OUT_USU_B_STATUS"].Value);
                    }
                    if ((cmdCommand.Parameters["OUT_USU_B_ALTERARSENHA"] != null) && cmdCommand.Parameters["OUT_USU_B_ALTERARSENHA"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAlterarSenha = Convert.ToBoolean(cmdCommand.Parameters["OUT_USU_B_ALTERARSENHA"].Value);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return objRetorno;
        }

        #endregion

        #region Obter (2) Login

        /// <summary> 
        /// Executa a stored procedure para retornar um registro específico
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Usuario</returns> 
        /// <user>mazevedo</user>
        public MLUsuario Obter(string pstrLogin)
        {

            MLUsuario objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWK_S_USUARIO_LOGIN");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("USU_C_LOGIN", FWDbType.Varchar, 200));
            cmdCommand.Parameters["USU_C_LOGIN"].Value = pstrLogin;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["OUT_USU_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_C_NOME", FWDbType.Varchar, 100));
            cmdCommand.Parameters["OUT_USU_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_C_LOGIN", FWDbType.Varchar, 200));
            cmdCommand.Parameters["OUT_USU_C_LOGIN"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_C_SENHA", FWDbType.Varchar, 50));
            cmdCommand.Parameters["OUT_USU_C_SENHA"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_C_EMAIL", FWDbType.Varchar, 200));
            cmdCommand.Parameters["OUT_USU_C_EMAIL"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_D_CADASTRO", FWDbType.DateTime));
            cmdCommand.Parameters["OUT_USU_D_CADASTRO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["OUT_USU_B_STATUS"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_USU_B_ALTERARSENHA", FWDbType.Boolean));
            cmdCommand.Parameters["OUT_USU_B_ALTERARSENHA"].Direction = ParameterDirection.Output;


            try
            {
                objRetorno = new MLUsuario();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["OUT_USU_N_CODIGO"] != null) && cmdCommand.Parameters["OUT_USU_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["OUT_USU_N_CODIGO"].Value.ToString());
                    if ((cmdCommand.Parameters["OUT_USU_C_NOME"] != null) && cmdCommand.Parameters["OUT_USU_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.Nome = Convert.ToString(cmdCommand.Parameters["OUT_USU_C_NOME"].Value.ToString());
                    }

                    if ((cmdCommand.Parameters["OUT_USU_C_LOGIN"] != null) && cmdCommand.Parameters["OUT_USU_C_LOGIN"].Value != System.DBNull.Value)
                    {
                        objRetorno.Login = Convert.ToString(cmdCommand.Parameters["OUT_USU_C_LOGIN"].Value.ToString());
                    }

                    if ((cmdCommand.Parameters["OUT_USU_C_SENHA"] != null) && cmdCommand.Parameters["OUT_USU_C_SENHA"].Value != System.DBNull.Value)
                    {
                        objRetorno.Senha = Convert.ToString(cmdCommand.Parameters["OUT_USU_C_SENHA"].Value.ToString());
                    }

                    if ((cmdCommand.Parameters["OUT_USU_C_EMAIL"] != null) && cmdCommand.Parameters["OUT_USU_C_EMAIL"].Value != System.DBNull.Value)
                    {
                        objRetorno.Email = Convert.ToString(cmdCommand.Parameters["OUT_USU_C_EMAIL"].Value.ToString());
                    }

                    if ((cmdCommand.Parameters["OUT_USU_D_CADASTRO"] != null) && cmdCommand.Parameters["OUT_USU_D_CADASTRO"].Value != System.DBNull.Value)
                    {
                        objRetorno.DataCadastro = Convert.ToDateTime(cmdCommand.Parameters["OUT_USU_D_CADASTRO"].Value);
                    }

                    if ((cmdCommand.Parameters["OUT_USU_B_STATUS"] != null) && cmdCommand.Parameters["OUT_USU_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["OUT_USU_B_STATUS"].Value);
                    }

                    if ((cmdCommand.Parameters["OUT_USU_B_ALTERARSENHA"] != null) && cmdCommand.Parameters["OUT_USU_B_ALTERARSENHA"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAlterarSenha = Convert.ToBoolean(cmdCommand.Parameters["OUT_USU_B_ALTERARSENHA"].Value);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return objRetorno;
        }

        #endregion

        #region Obter Completo

        /// <summary> 
        /// Executa a stored procedure para retornar um registro específico
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Usuario</returns> 
        /// <user>mazevedo</user>
        public MLUsuarioGrupo ObterCompleto(decimal pdecCodigo)
        {

            MLUsuarioGrupo objRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWK_S_USUARIO_GRUPO_P1");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("USU_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["USU_N_CODIGO"].Value = pdecCodigo;

            // Retorno do Curso
            cmdCommand.Parameters.Add(new FWParameter("RCT1", FWDbType.Cursor));
            cmdCommand.Parameters["RCT1"].Direction = ParameterDirection.Output;

            IDataReader idrRetorno = null;
            try
            {
                objRetorno = new MLUsuarioGrupo();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {

                    if (idrRetorno["USU_N_CODIGO"] != DBNull.Value)
                    {
                        objRetorno.Codigo = Convert.ToDecimal(idrRetorno["USU_N_CODIGO"]);
                    }
                    if (idrRetorno["USU_C_NOME"] != DBNull.Value)
                    {
                        objRetorno.Nome = idrRetorno["USU_C_NOME"].ToString();
                    }
                    if (idrRetorno["USU_C_LOGIN"] != DBNull.Value)
                    {
                        objRetorno.Login = idrRetorno["USU_C_LOGIN"].ToString();
                    }
                    if (idrRetorno["USU_C_SENHA"] != DBNull.Value)
                    {
                        objRetorno.Senha = idrRetorno["USU_C_SENHA"].ToString();
                    }
                    if (idrRetorno["USU_C_EMAIL"] != DBNull.Value)
                    {
                        objRetorno.Email = idrRetorno["USU_C_EMAIL"].ToString();
                    }
                    if (idrRetorno["USU_D_CADASTRO"] != DBNull.Value)
                    {
                        objRetorno.DataCadastro = Convert.ToDateTime(idrRetorno["USU_D_CADASTRO"]);
                    }
                    if (idrRetorno["USU_B_STATUS"] != DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(idrRetorno["USU_B_STATUS"]);
                    }
                    if (idrRetorno["USU_B_ALTERARSENHA"] != DBNull.Value)
                    {
                        objRetorno.IsAlterarSenha = Convert.ToBoolean(idrRetorno["USU_B_STATUS"]);
                    }
                    if (idrRetorno["USU_C_PAGINA_ACESSO"] != DBNull.Value)
                    {
                        objRetorno.ListaGrupoFromString(idrRetorno["USU_C_PAGINA_ACESSO"].ToString());
                    }
                    if (idrRetorno["USU_C_CODIGO_GRUPO"] != DBNull.Value)
                    {
                        objRetorno.ListaPaginaFromString(idrRetorno["USU_C_CODIGO_GRUPO"].ToString());
                    }

                }
            }
            catch (Exception)
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

            cmdCommand.CommandText = "USP_FWK_S_USUARIO_GRUPO_P2";

            idrRetorno = null;
            try
            {
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    MLFuncionalidadeGrupo objPermissao = new MLFuncionalidadeGrupo();

                    if (idrRetorno["FUN_N_CODIGO"] != DBNull.Value)
                    {
                        objPermissao.Codigo = Convert.ToDecimal(idrRetorno["FUN_N_CODIGO"]);
                    }
                    if (idrRetorno["FUN_C_NOME"] != DBNull.Value)
                    {
                        objPermissao.Nome = idrRetorno["FUN_C_NOME"].ToString();
                    }
                    if (idrRetorno["FUN_C_CAMINHO_PAGINA"] != DBNull.Value)
                    {
                        objPermissao.CaminhoPagina = idrRetorno["FUN_C_CAMINHO_PAGINA"].ToString();
                    }
                    if (idrRetorno["FUN_B_STATUS"] != DBNull.Value)
                    {
                        objPermissao.IsAtivo = Convert.ToBoolean(idrRetorno["FUN_B_STATUS"]);
                    }
                    if (idrRetorno["FUN_B_ALTERAR"] != DBNull.Value)
                    {
                        objPermissao.GrupoPermissao.IsPermissaoAlterar = Convert.ToBoolean(idrRetorno["FUN_B_ALTERAR"]);
                    }
                    if (idrRetorno["FUN_B_INCLUIR"] != DBNull.Value)
                    {
                        objPermissao.GrupoPermissao.IsPermissaoIncluir = Convert.ToBoolean(idrRetorno["FUN_B_INCLUIR"]);
                    }
                    if (idrRetorno["FUN_B_EXCLUIR"] != DBNull.Value)
                    {
                        objPermissao.GrupoPermissao.IsPermissaoExcluir = Convert.ToBoolean(idrRetorno["FUN_B_EXCLUIR"]);
                    }
                    if (idrRetorno["FUN_B_LISTAR"] != DBNull.Value)
                    {
                        objPermissao.GrupoPermissao.IsPermissaoListar = Convert.ToBoolean(idrRetorno["FUN_B_LISTAR"]);
                    }

                    objRetorno.ListaPermissoes.Add(objPermissao);

                }
            }
            catch (Exception)
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

            return objRetorno;
        }

        #endregion

        #region Excluir

        /// <summary> 
        /// Executa a Stored Procedure de Exclusão
        /// </summary> 
        /// <param name="pdecCodigo">Codigo</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>mazevedo</user>
        public bool Excluir(decimal pdecCodigo)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWK_D_USUARIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("USU_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["USU_N_CODIGO"].Value = pdecCodigo;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                blnRetorno = true;

            }
            catch (Exception)
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
        /// <param name="pobjMLUsuario">Usuario para alterar</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>mazevedo</user>
        public bool Alterar(MLUsuario pobjMLUsuario)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWK_U_USUARIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLUsuario.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["USU_N_CODIGO"].Value = pobjMLUsuario.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLUsuario.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_C_NOME", FWDbType.Varchar, 100));
                cmdCommand.Parameters["USU_C_NOME"].Value = pobjMLUsuario.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLUsuario.Login))
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_C_LOGIN", FWDbType.Varchar, 50));
                cmdCommand.Parameters["USU_C_LOGIN"].Value = pobjMLUsuario.Login;
            }
            if (!string.IsNullOrEmpty(pobjMLUsuario.Senha))
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_C_SENHA", FWDbType.Varchar, 50));
                cmdCommand.Parameters["USU_C_SENHA"].Value = pobjMLUsuario.Senha;
            }
            if (!string.IsNullOrEmpty(pobjMLUsuario.Email))
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_C_EMAIL", FWDbType.Varchar, 200));
                cmdCommand.Parameters["USU_C_EMAIL"].Value = pobjMLUsuario.Email;
            }
            if (pobjMLUsuario.DataCadastro.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_D_CADASTRO", FWDbType.DateTime));
                cmdCommand.Parameters["USU_D_CADASTRO"].Value = pobjMLUsuario.DataCadastro.Value;
            }
            if (pobjMLUsuario.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["USU_B_STATUS"].Value = pobjMLUsuario.IsAtivo.Value;
            }
            if (pobjMLUsuario.IsAlterarSenha.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_B_ALTERARSENHA", FWDbType.Boolean));
                cmdCommand.Parameters["USU_B_ALTERARSENHA"].Value = pobjMLUsuario.IsAlterarSenha.Value;
            }

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                blnRetorno = true;

            }
            catch (Exception)
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
        /// <param name="pobjMLUsuario">Usuario para inserir</param>
        /// <returns>Código Usuario</returns> 
        /// <user>mazevedo</user>
        public int Inserir(MLUsuario pobjMLUsuario)
        {

            int intRetorno = 0;

            FWCommand cmdCommand = new FWCommand("USP_FWK_I_USUARIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (!string.IsNullOrEmpty(pobjMLUsuario.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_C_NOME", FWDbType.Varchar, 100));
                cmdCommand.Parameters["USU_C_NOME"].Value = pobjMLUsuario.Nome;
            }
            if (!string.IsNullOrEmpty(pobjMLUsuario.Login))
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_C_LOGIN", FWDbType.Varchar, 50));
                cmdCommand.Parameters["USU_C_LOGIN"].Value = pobjMLUsuario.Login;
            }
            if (!string.IsNullOrEmpty(pobjMLUsuario.Senha))
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_C_SENHA", FWDbType.Varchar, 50));
                cmdCommand.Parameters["USU_C_SENHA"].Value = pobjMLUsuario.Senha;
            }
            if (!string.IsNullOrEmpty(pobjMLUsuario.Email))
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_C_EMAIL", FWDbType.Varchar, 200));
                cmdCommand.Parameters["USU_C_EMAIL"].Value = pobjMLUsuario.Email;
            }
            if (pobjMLUsuario.DataCadastro.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_D_CADASTRO", FWDbType.DateTime));
                cmdCommand.Parameters["USU_D_CADASTRO"].Value = pobjMLUsuario.DataCadastro.Value;
            }
            if (pobjMLUsuario.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["USU_B_STATUS"].Value = pobjMLUsuario.IsAtivo.Value;
            }
            if (pobjMLUsuario.IsAlterarSenha.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("USU_B_ALTERARSENHA", FWDbType.Boolean));
                cmdCommand.Parameters["USU_B_ALTERARSENHA"].Value = pobjMLUsuario.IsAlterarSenha.Value;
            }

            cmdCommand.Parameters.Add(new FWParameter("USU_N_CODIGO", FWDbType.Int32));
            cmdCommand.Parameters["USU_N_CODIGO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters["USU_N_CODIGO"] != null)
                    intRetorno = Convert.ToInt32(cmdCommand.Parameters["USU_N_CODIGO"].Value);

            }
            catch (Exception)
            {
                throw;
            }
            return intRetorno;
        }

        #endregion

        #region Inserir Grupos

        /// <summary>
        /// Insere os grupos do usuario
        /// </summary>
        /// <param name="pdecCodigoUsuario"></param>
        /// <param name="strGruposUsuario"></param>
        /// <user>mazevedo</user>      
        public void InserirGrupos(decimal pdecCodigoUsuario, string strGruposUsuario)
        {
            FWCommand cmdCommand = new FWCommand("USP_FWK_U_GRUPO_USUARIO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            cmdCommand.Parameters.Add(new FWParameter("GXU_USU_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["GXU_USU_N_CODIGO"].Value = pdecCodigoUsuario;

            cmdCommand.Parameters.Add(new FWParameter("GXU_GRP_N_CODIGO", FWDbType.Varchar));
            cmdCommand.Parameters["GXU_GRP_N_CODIGO"].Value = strGruposUsuario;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Inserir Auditoria Acesso
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pobjMLLogAcesso"></param>
        /// <returns></returns>
        public decimal InserirAuditoriaAcesso(MLLogAcesso pobjMLLogAcesso)
        {
            decimal decRetorno = 0;

            FWCommand cmdCommand = new FWCommand("USP_FWK_I_LOG_ACESSO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLLogAcesso.Data.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("LAC_D_DATA", FWDbType.DateTime));
                cmdCommand.Parameters["LAC_D_DATA"].Value = pobjMLLogAcesso.Data.Value;
            }
            if (pobjMLLogAcesso.CodigoUsuario.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("LAC_USU_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["LAC_USU_N_CODIGO"].Value = pobjMLLogAcesso.CodigoUsuario.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLLogAcesso.Descricao))
            {
                cmdCommand.Parameters.Add(new FWParameter("LAC_C_DESCRICAO", FWDbType.Varchar, 4000));
                cmdCommand.Parameters["LAC_C_DESCRICAO"].Value = pobjMLLogAcesso.Descricao;
            }

            cmdCommand.Parameters.Add(new FWParameter("LAC_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["LAC_N_CODIGO"].Direction = ParameterDirection.Output;

            conProvider.ExecuteNonQuery(cmdCommand);

            if ((cmdCommand.Parameters["LAC_N_CODIGO"] != null) && cmdCommand.Parameters["LAC_N_CODIGO"].Value != null && cmdCommand.Parameters["LAC_N_CODIGO"].Value != System.DBNull.Value)
                decRetorno = Convert.ToDecimal(cmdCommand.Parameters["LAC_N_CODIGO"].Value);
            
            return decRetorno;

        }

        #endregion

        #region Listar Auditoria Acesso

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLLogAcesso">Parametros para filtro</param>
        /// <returns>Lista de LogAcesso</returns> 
        /// <user>GeradorVm2 [2.2.0.0]</user>
        public List<MLLogAcesso> ListarAuditoriaAcesso(Decimal pdecCodigoUsuario, DateTime? pdtDataInicio, DateTime? pdtDataFinal)
        {

            List<MLLogAcesso> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWK_L_LOG_ACESSO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;


            if (pdtDataInicio.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("LAC_D_DATA_INICIO", FWDbType.DateTime));
                cmdCommand.Parameters["LAC_D_DATA_INICIO"].Value = pdtDataInicio.Value;
            }
            if (pdtDataFinal.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("LAC_D_DATA_FIM", FWDbType.DateTime));
                cmdCommand.Parameters["LAC_D_DATA_FIM"].Value = pdtDataFinal.Value;
            }
            if (pdecCodigoUsuario > 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("LAC_USU_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["LAC_USU_N_CODIGO"].Value = pdecCodigoUsuario;
            }
          
            cmdCommand.Parameters.Add(new FWParameter("RCT1", FWDbType.Cursor));
            cmdCommand.Parameters["RCT1"].Direction = ParameterDirection.Output;

            IDataReader idrRetorno = null;
            try
            {
                MLLogAcesso objRetorno = null;
                lstRetorno = new List<MLLogAcesso>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLLogAcesso();
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


