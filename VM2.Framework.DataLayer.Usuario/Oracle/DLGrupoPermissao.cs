using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using VM2.Framework.Model.Usuario;

namespace VM2.Framework.DataLayer.Usuario.Oracle
{

    /// <summary>
    ///     Classe de acesso a dados para Permissao
    /// </summary>
    /// <user>mazevedo</user>
    public class DLGrupoPermissao : DLFWBase, IDLGrupoPermissao
    {

        /// <summary>
        ///     Contrutor da classe inicializa as conexoes
        /// </summary>
        /// <user>mazevedo</user>
        public DLGrupoPermissao()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }

        #region Listar

        /// <summary>
        ///     Lista as permissoes
        /// </summary>
        /// <param name="pobjParametro">Parametros para filtro</param>
        /// <returns>Lista de Permissoes</returns>
        /// <user>mazevedo</user>
        public List<MLGrupoPermissao> Listar(MLGrupoPermissao pobjParametro)
        {

            List<MLGrupoPermissao> colRetorno = null;

            // Cria os objetos de conexão ao banco de dados
            FWCommand cmdCommand = new FWCommand("USP_FWK_L_GRUPO_PERMISSAO");
            // Monta cmdCommand como Stored Procedure
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            //Parâmetros de entrada

            if (pobjParametro.CodigoGrupo > 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("GPE_GRP_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["GPE_GRP_N_CODIGO"].Value = pobjParametro.CodigoGrupo;
            }

            if (pobjParametro.CodigoFuncionalidade > 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("GPE_FUN_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["GPE_FUN_N_CODIGO"].Value = pobjParametro.CodigoFuncionalidade;
            }

            if (pobjParametro.IsPermissaoAlterar != null)
            {
                cmdCommand.Parameters.Add(new FWParameter("GPE_B_ALTERAR", FWDbType.Boolean));
                cmdCommand.Parameters["GPE_B_ALTERAR"].Value = pobjParametro.IsPermissaoAlterar;
            }

            if (pobjParametro.IsPermissaoIncluir != null)
            {
                cmdCommand.Parameters.Add(new FWParameter("GPE_B_INCLUIR", FWDbType.Boolean));
                cmdCommand.Parameters["GPE_B_INCLUIR"].Value = pobjParametro.IsPermissaoIncluir;
            }

            if (pobjParametro.IsPermissaoExcluir != null)
            {
                cmdCommand.Parameters.Add(new FWParameter("GPE_B_EXCLUIR", FWDbType.Boolean));
                cmdCommand.Parameters["GPE_B_EXCLUIR"].Value = pobjParametro.IsPermissaoExcluir;
            }

            if (pobjParametro.IsPermissaoListar != null)
            {
                cmdCommand.Parameters.Add(new FWParameter("GPE_B_LISTAR", FWDbType.Boolean));
                cmdCommand.Parameters["GPE_B_LISTAR"].Value = pobjParametro.IsPermissaoListar;
            }

            // Retorno do Curso
            cmdCommand.Parameters.Add(new FWParameter("RCT1", FWDbType.Cursor));
            cmdCommand.Parameters["RCT1"].Direction = ParameterDirection.Output;

            try
            {
                IDataReader idrRetorno;
                MLGrupoPermissao objRetorno = null;
                colRetorno = new List<MLGrupoPermissao>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLGrupoPermissao();
                    objRetorno.FromIDataReader(idrRetorno);
                    colRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }
            return colRetorno;
        }

        #endregion

        #region Obter

        /// <summary>
        ///     Obtem uma permissao
        /// </summary>
        /// <param name="pdecCodigoGrupo">Codigo do grupo</param>
        /// <param name="pdecCodigoFuncionalidade">Codigo da funcionalidade</param>
        /// <returns>Permissao</returns>
        /// <user>mazevedo</user>
        public MLGrupoPermissao Obter(decimal pdecCodigoGrupo,
                                               decimal pdecCodigoFuncionalidade)
        {

            MLGrupoPermissao objRetorno = null;
            // Cria os objetos de conexão ao banco de dados
            FWCommand cmdCommand = new FWCommand("USP_FWK_S_GRUPO_PERMISSAO");
            // Monta cmdCommand como Stored Procedure
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            //Parâmetros de entrada
            cmdCommand.Parameters.Add(new FWParameter("GPE_GRP_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["GPE_GRP_N_CODIGO"].Value = pdecCodigoGrupo;
            cmdCommand.Parameters.Add(new FWParameter("GPE_FUN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["GPE_FUN_N_CODIGO"].Value = pdecCodigoFuncionalidade;
            //Parâmetros de Saída
            cmdCommand.Parameters.Add(new FWParameter("OUT_GPE_GRP_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["OUT_GPE_GRP_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_GPE_FUN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["OUT_GPE_FUN_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_GPE_B_ALTERAR", FWDbType.Boolean));
            cmdCommand.Parameters["OUT_GPE_B_ALTERAR"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_GPE_B_INCLUIR", FWDbType.Boolean));
            cmdCommand.Parameters["OUT_GPE_B_INCLUIR"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_GPE_B_EXCLUIR", FWDbType.Boolean));
            cmdCommand.Parameters["OUT_GPE_B_EXCLUIR"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_GPE_B_LISTAR", FWDbType.Boolean));
            cmdCommand.Parameters["OUT_GPE_B_LISTAR"].Direction = ParameterDirection.Output;

            // Executa o comando da stored procedure
            try
            {
                objRetorno = new MLGrupoPermissao();

                conProvider.ExecuteNonQuery(cmdCommand);

                //Populo o objeto
                if ((cmdCommand.Parameters["OUT_GPE_GRP_N_CODIGO"] != null) && cmdCommand.Parameters["OUT_GPE_GRP_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.CodigoGrupo = Convert.ToDecimal(cmdCommand.Parameters["OUT_GPE_GRP_N_CODIGO"].Value.ToString());
                    if ((cmdCommand.Parameters["OUT_GPE_FUN_N_CODIGO"] != null) && cmdCommand.Parameters["OUT_GPE_FUN_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoFuncionalidade = Convert.ToDecimal(cmdCommand.Parameters["OUT_GPE_FUN_N_CODIGO"].Value.ToString());
                    }

                    if ((cmdCommand.Parameters["OUT_GPE_B_ALTERAR"] != null) && cmdCommand.Parameters["OUT_GPE_B_ALTERAR"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsPermissaoAlterar = Convert.ToBoolean(cmdCommand.Parameters["OUT_GPE_B_ALTERAR"].Value);
                    }

                    if ((cmdCommand.Parameters["OUT_GPE_B_INCLUIR"] != null) && cmdCommand.Parameters["OUT_GPE_B_INCLUIR"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsPermissaoIncluir = Convert.ToBoolean(cmdCommand.Parameters["OUT_GPE_B_INCLUIR"].Value);
                    }

                    if ((cmdCommand.Parameters["OUT_GPE_B_EXCLUIR"] != null) && cmdCommand.Parameters["OUT_GPE_B_EXCLUIR"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsPermissaoExcluir = Convert.ToBoolean(cmdCommand.Parameters["OUT_GPE_B_EXCLUIR"].Value);
                    }

                    if ((cmdCommand.Parameters["OUT_GPE_B_LISTAR"] != null) && cmdCommand.Parameters["OUT_GPE_B_LISTAR"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsPermissaoListar = Convert.ToBoolean(cmdCommand.Parameters["OUT_GPE_B_LISTAR"].Value);
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
        ///     Exclui um registro
        /// </summary>
        /// <param name="pdecCodigoGrupo">Codigo do grupo</param>
        /// <param name="pdecCodigoFuncionalidade">Codigo da Funcionalidade</param>
        /// <returns>Resultado da operação</returns>
        /// <user>mazevedo</user>
        public bool Excluir(decimal pdecCodigoGrupo,
                                               decimal pdecCodigoFuncionalidade)
        {

            bool blnRetorno;
            // Cria os objetos de conexão ao banco de dados
            FWCommand cmdCommand = new FWCommand("USP_FWK_D_GRUPO_PERMISSAO");
            // Monta cmdCommand como Stored Procedure
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            //Parâmetros de entrada
            cmdCommand.Parameters.Add(new FWParameter("GPE_GRP_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["GPE_GRP_N_CODIGO"].Value = pdecCodigoGrupo;
            cmdCommand.Parameters.Add(new FWParameter("GPE_FUN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["GPE_FUN_N_CODIGO"].Value = pdecCodigoFuncionalidade;

            // Executa o comando da stored procedure
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

        #region Excluir Todos

        /// <summary>
        ///     Exclui todos os registros de uma funcionalidade
        /// </summary>
        /// <param name="pdecCodigoGrupo">Codigo do grupo</param>
        /// <param name="pdecCodigoFuncionalidade">Codigo da Funcionalidade</param>
        /// <returns>Resultado da operação</returns>
        /// <user>mazevedo</user>
        public bool ExcluirTodos(decimal pdecCodigoFuncionalidade)
        {

            bool blnRetorno;
            // Cria os objetos de conexão ao banco de dados
            FWCommand cmdCommand = new FWCommand("USP_FWK_D_GRUPO_PERMISSAO_ALL");
            // Monta cmdCommand como Stored Procedure
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            //Parâmetros de entrada          
            cmdCommand.Parameters.Add(new FWParameter("GPE_FUN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["GPE_FUN_N_CODIGO"].Value = pdecCodigoFuncionalidade;

            // Executa o comando da stored procedure
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
        ///     Altera uma permissao
        /// </summary>
        /// <param name="pobjPermissao">Permissao com as alteracoes</param>
        /// <returns>Resultado da operação</returns>
        /// <user>mazevedo</user>
        public bool Alterar(MLGrupoPermissao pobjPermissao)
        {

            bool blnRetorno;
            // Cria os objetos de conexão ao banco de dados
            FWCommand cmdCommand = new FWCommand("USP_FWK_U_GRUPO_PERMISSAO");
            // Monta cmdCommand como Stored Procedure
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            //Parâmetros de entrada
            cmdCommand.Parameters.Add(new FWParameter("GPE_GRP_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["GPE_GRP_N_CODIGO"].Value = pobjPermissao.CodigoGrupo;
            cmdCommand.Parameters.Add(new FWParameter("GPE_FUN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["GPE_FUN_N_CODIGO"].Value = pobjPermissao.CodigoFuncionalidade;
            cmdCommand.Parameters.Add(new FWParameter("GPE_B_ALTERAR", FWDbType.Boolean));
            cmdCommand.Parameters["GPE_B_ALTERAR"].Value = pobjPermissao.IsPermissaoAlterar;
            cmdCommand.Parameters.Add(new FWParameter("GPE_B_INCLUIR", FWDbType.Boolean));
            cmdCommand.Parameters["GPE_B_INCLUIR"].Value = pobjPermissao.IsPermissaoIncluir;
            cmdCommand.Parameters.Add(new FWParameter("GPE_B_EXCLUIR", FWDbType.Boolean));
            cmdCommand.Parameters["GPE_B_EXCLUIR"].Value = pobjPermissao.IsPermissaoExcluir;
            cmdCommand.Parameters.Add(new FWParameter("GPE_B_LISTAR", FWDbType.Boolean));
            cmdCommand.Parameters["GPE_B_LISTAR"].Value = pobjPermissao.IsPermissaoListar;

            // Executa o comando da stored procedure
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

        /// <summary>
        ///     Insere uma permissao
        /// </summary>
        /// <param name="pobjPermissao">Permissao a ser inserida</param>
        /// <returns>Resultado da Operação</returns>
        /// <user>mazevedo</user>
        public bool Inserir(MLGrupoPermissao pobjPermissao)
        {

            bool blnRetorno;
            // Cria os objetos de conexão ao banco de dados
            FWCommand cmdCommand = new FWCommand("USP_FWK_I_GRUPO_PERMISSAO");
            // Monta cmdCommand como Stored Procedure
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            //Parâmetros de entrada
            cmdCommand.Parameters.Add(new FWParameter("GPE_GRP_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["GPE_GRP_N_CODIGO"].Value = pobjPermissao.CodigoGrupo;
            cmdCommand.Parameters.Add(new FWParameter("GPE_FUN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["GPE_FUN_N_CODIGO"].Value = pobjPermissao.CodigoFuncionalidade;
            cmdCommand.Parameters.Add(new FWParameter("GPE_B_ALTERAR", FWDbType.Boolean));
            cmdCommand.Parameters["GPE_B_ALTERAR"].Value = pobjPermissao.IsPermissaoAlterar;
            cmdCommand.Parameters.Add(new FWParameter("GPE_B_INCLUIR", FWDbType.Boolean));
            cmdCommand.Parameters["GPE_B_INCLUIR"].Value = pobjPermissao.IsPermissaoIncluir;
            cmdCommand.Parameters.Add(new FWParameter("GPE_B_EXCLUIR", FWDbType.Boolean));
            cmdCommand.Parameters["GPE_B_EXCLUIR"].Value = pobjPermissao.IsPermissaoExcluir;
            cmdCommand.Parameters.Add(new FWParameter("GPE_B_LISTAR", FWDbType.Boolean));
            cmdCommand.Parameters["GPE_B_LISTAR"].Value = pobjPermissao.IsPermissaoListar;

            // Executa o comando da stored procedure
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
    }
}


