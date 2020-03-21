using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using VM2.Framework.Model.Usuario;

namespace VM2.Framework.DataLayer.Usuario.Oracle
{

    /// <summary>
    ///     Classe de acesso a dados para Grupo
    /// </summary>
    /// <user>mazevedo</user>
    public class DLGrupo : DLFWBase, IDLGrupo
    {

        /// <summary>
        ///     Contrutor da classe inicializa as strings de conexao
        /// </summary>
        /// <user>mazevedo</user>
        public DLGrupo()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary>
        ///     Executa a procedure para listagem de grupos
        /// </summary>
        /// <param name="pobjGrupo">Objeto com os filtros</param>
        /// <returns>Lista de grupos</returns>
        /// <user>mazevedo</user>
        public List<MLGrupo> Listar(MLGrupo pobjGrupo)
        {

            List<MLGrupo> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWK_L_GRUPO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjGrupo.Codigo.HasValue && pobjGrupo.Codigo.Value > 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("GRP_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["GRP_N_CODIGO"].Value = pobjGrupo.Codigo;
            }

            if (!string.IsNullOrEmpty(pobjGrupo.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("GRP_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["GRP_C_NOME"].Value = pobjGrupo.Nome;
            }

            if (pobjGrupo.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("GRP_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["GRP_B_STATUS"].Value = pobjGrupo.IsAtivo;
            }

            // Retorno do Curso
            cmdCommand.Parameters.Add(new FWParameter("RCT1", FWDbType.Cursor));
            cmdCommand.Parameters["RCT1"].Direction = ParameterDirection.Output;

            try
            {
                IDataReader idrRetorno;
                MLGrupo objRetorno = null;
                lstRetorno = new List<MLGrupo>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLGrupo();
                    objRetorno.FromIDataReader(idrRetorno);
                    lstRetorno.Add(objRetorno);
                }
            }
            catch
            {
                throw;
            }

            return lstRetorno;
        }

        #endregion

        #region Obter

        /// <summary>
        ///     Executa a stored procedure para obter um usuário
        /// </summary>
        /// <param name="pdecCodigo">Codigo do usuário</param>
        /// <returns>Grupo</returns>
        /// <user>mazevedo</user>
        public MLGrupo Obter(decimal pdecCodigo)
        {

            MLGrupo objRetorno = null;
            // Cria os objetos de conexão ao banco de dados
            FWCommand cmdCommand = new FWCommand("USP_FWK_S_GRUPO");
            // Monta cmdCommand como Stored Procedure
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            //Parâmetros de entrada
            cmdCommand.Parameters.Add(new FWParameter("GRP_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["GRP_N_CODIGO"].Value = pdecCodigo;
            //Parâmetros de Saída
            cmdCommand.Parameters.Add(new FWParameter("OUT_GRP_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["OUT_GRP_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_GRP_C_NOME", FWDbType.Varchar, 50));
            cmdCommand.Parameters["OUT_GRP_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_GRP_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["OUT_GRP_B_STATUS"].Direction = ParameterDirection.Output;

            // Executa o comando da stored procedure
            try
            {
                objRetorno = new MLGrupo();

                conProvider.ExecuteNonQuery(cmdCommand);

                //Populo o objeto
                if ((cmdCommand.Parameters["OUT_GRP_N_CODIGO"] != null) && cmdCommand.Parameters["OUT_GRP_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["OUT_GRP_N_CODIGO"].Value);
                    if ((cmdCommand.Parameters["OUT_GRP_C_NOME"] != null) && cmdCommand.Parameters["OUT_GRP_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.Nome = cmdCommand.Parameters["OUT_GRP_C_NOME"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["OUT_GRP_B_STATUS"] != null) && cmdCommand.Parameters["OUT_GRP_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["OUT_GRP_B_STATUS"].Value);
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
        ///     Executa a stored procedure para excluir um grupo
        /// </summary>
        /// <param name="pdecCodigo">Codigo do grupo</param>
        /// <returns>Resultado da operação</returns>
        /// <user>mazevedo</user>
        public bool Excluir(decimal pdecCodigo)
        {

            bool blnRetorno = false;
            // Cria os objetos de conexão ao banco de dados
            FWCommand cmdCommand = new FWCommand("USP_FWK_D_GRUPO");
            // Monta cmdCommand como Stored Procedure
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            //Parâmetros de entrada
            cmdCommand.Parameters.Add(new FWParameter("GRP_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["GRP_N_CODIGO"].Value = pdecCodigo;

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
        ///     Executa a stored procedure de alteração de grupo
        /// </summary>
        /// <param name="pobjMLGrupo">Grupo com as alterações</param>
        /// <returns>Resultado da operação</returns>
        /// <user>mazevedo</user>
        public bool Alterar(MLGrupo pobjMLGrupo)
        {

            bool blnRetorno = false;
            // Cria os objetos de conexão ao banco de dados
            FWCommand cmdCommand = new FWCommand("USP_FWK_U_GRUPO");
            // Monta cmdCommand como Stored Procedure
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            //Parâmetros de entrada
            cmdCommand.Parameters.Add(new FWParameter("GRP_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["GRP_N_CODIGO"].Value = pobjMLGrupo.Codigo;
            cmdCommand.Parameters.Add(new FWParameter("GRP_C_NOME", FWDbType.Varchar, 50));
            cmdCommand.Parameters["GRP_C_NOME"].Value = pobjMLGrupo.Nome;
            cmdCommand.Parameters.Add(new FWParameter("GRP_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["GRP_B_STATUS"].Value = pobjMLGrupo.IsAtivo;

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
        ///     Executa a stored procedure para inserir um grupo
        /// </summary>
        /// <param name="pobjMLGrupo">Grupo a ser inserido</param>
        /// <returns>Codigo do grupo inserido</returns>
        /// <user>mazevedo</user>
        public int Inserir(MLGrupo pobjMLGrupo)
        {

            int intRetorno = 0;
            // Cria os objetos de conexão ao banco de dados
            FWCommand cmdCommand = new FWCommand("USP_FWK_I_GRUPO");
            // Monta cmdCommand como Stored Procedure
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            //Parâmetros de entrada
            cmdCommand.Parameters.Add(new FWParameter("GRP_C_NOME", FWDbType.Varchar, 50));
            cmdCommand.Parameters["GRP_C_NOME"].Value = pobjMLGrupo.Nome;
            cmdCommand.Parameters.Add(new FWParameter("GRP_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["GRP_B_STATUS"].Value = pobjMLGrupo.IsAtivo;

            cmdCommand.Parameters.Add(new FWParameter("GRP_N_CODIGO", FWDbType.Int32));
            cmdCommand.Parameters["GRP_N_CODIGO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters["GRP_N_CODIGO"] != null)
                    intRetorno = Convert.ToInt32(cmdCommand.Parameters["GRP_N_CODIGO"].Value);

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


