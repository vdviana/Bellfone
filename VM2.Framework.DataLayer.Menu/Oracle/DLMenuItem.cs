using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model.Menu;

namespace VM2.Framework.DataLayer.Menu.Oracle
{
    /// <summary> 
    /// Classe de conexão de dados para MenuItem 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLMenuItem : DLFWBase, IDLMenuItem
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>mazevedo</user> 
        public DLMenuItem()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }

        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLMenuItem">Parametros para filtro</param>
        /// <returns>Lista de MenuItem</returns> 
        /// <user>mazevedo</user>
        public List<MLMenuItem> Listar(MLMenuItem pobjMLMenuItem)
        {

            List<MLMenuItem> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWK_L_MENU_ITEM");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLMenuItem.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_N_CODIGO"].Value = pobjMLMenuItem.Codigo.Value;
            }
            if (pobjMLMenuItem.CodigoMenu.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_MEN_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_MEN_N_CODIGO"].Value = pobjMLMenuItem.CodigoMenu.Value;
            }
            if (pobjMLMenuItem.CodigoMenuIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_MEN_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_MEN_IDI_N_CODIGO"].Value = pobjMLMenuItem.CodigoMenuIdioma.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMenuItem.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_C_NOME", FWDbType.Varchar, 100));
                cmdCommand.Parameters["MNI_C_NOME"].Value = pobjMLMenuItem.Nome;
            }
            if (pobjMLMenuItem.CodigoPai.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_N_CODIGO_PAI", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_N_CODIGO_PAI"].Value = pobjMLMenuItem.CodigoPai.Value;
            }
            if (pobjMLMenuItem.CodigoFuncionalidade.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_FUN_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_FUN_N_CODIGO"].Value = pobjMLMenuItem.CodigoFuncionalidade.Value;
            }
            if (pobjMLMenuItem.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["MNI_B_STATUS"].Value = pobjMLMenuItem.IsAtivo.Value;
            }
            if (pobjMLMenuItem.Ordem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_N_ORDEM", FWDbType.Int32));
                cmdCommand.Parameters["MNI_N_ORDEM"].Value = pobjMLMenuItem.Ordem.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMenuItem.CaminhoPagina))
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_C_CAMINHO_PAGINA", FWDbType.Varchar, 300));
                cmdCommand.Parameters["MNI_C_CAMINHO_PAGINA"].Value = pobjMLMenuItem.CaminhoPagina;
            }

            // Retorno do Curso
            cmdCommand.Parameters.Add(new FWParameter("RCT1", FWDbType.Cursor));
            cmdCommand.Parameters["RCT1"].Direction = ParameterDirection.Output;


            IDataReader idrRetorno = null;
            try
            {
                MLMenuItem objRetorno = null;
                lstRetorno = new List<MLMenuItem>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLMenuItem();
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
        /// <param name="pdecCodigo">Código do Item do Menu</param>
        /// <returns>MenuItem</returns> 
        /// <user>mazevedo</user>
        public MLMenuItem Obter(decimal pdecCodigo)
        {

            MLMenuItem objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWK_S_MENU_ITEM");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("MNI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["MNI_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("OUT_MNI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["OUT_MNI_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_MNI_MEN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["OUT_MNI_MEN_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_MNI_MEN_IDI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["OUT_MNI_MEN_IDI_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_MNI_C_NOME", FWDbType.Varchar, 100));
            cmdCommand.Parameters["OUT_MNI_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_MNI_N_CODIGO_PAI", FWDbType.Decimal));
            cmdCommand.Parameters["OUT_MNI_N_CODIGO_PAI"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_MNI_FUN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["OUT_MNI_FUN_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_MNI_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["OUT_MNI_B_STATUS"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_MNI_N_ORDEM", FWDbType.Int32));
            cmdCommand.Parameters["OUT_MNI_N_ORDEM"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_MNI_C_CAMINHO_PAGINA", FWDbType.Varchar, 300));
            cmdCommand.Parameters["OUT_MNI_C_CAMINHO_PAGINA"].Direction = ParameterDirection.Output;

            try
            {
                objRetorno = new MLMenuItem();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["OUT_MNI_N_CODIGO"] != null) && cmdCommand.Parameters["OUT_MNI_N_CODIGO"].Value != null && cmdCommand.Parameters["OUT_MNI_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["OUT_MNI_N_CODIGO"].Value);
                    if ((cmdCommand.Parameters["OUT_MNI_MEN_N_CODIGO"] != null) && cmdCommand.Parameters["OUT_MNI_MEN_N_CODIGO"].Value != null && cmdCommand.Parameters["OUT_MNI_MEN_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoMenu = Convert.ToDecimal(cmdCommand.Parameters["OUT_MNI_MEN_N_CODIGO"].Value);
                    }
                    if ((cmdCommand.Parameters["OUT_MNI_MEN_IDI_N_CODIGO"] != null) && cmdCommand.Parameters["OUT_MNI_MEN_IDI_N_CODIGO"].Value != null && cmdCommand.Parameters["OUT_MNI_MEN_IDI_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoMenuIdioma = Convert.ToDecimal(cmdCommand.Parameters["OUT_MNI_MEN_IDI_N_CODIGO"].Value);
                    }
                    if ((cmdCommand.Parameters["OUT_MNI_C_NOME"] != null) && cmdCommand.Parameters["OUT_MNI_C_NOME"].Value != null && cmdCommand.Parameters["OUT_MNI_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.Nome = cmdCommand.Parameters["OUT_MNI_C_NOME"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["OUT_MNI_N_CODIGO_PAI"] != null) && cmdCommand.Parameters["OUT_MNI_N_CODIGO_PAI"].Value != null && cmdCommand.Parameters["OUT_MNI_N_CODIGO_PAI"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoPai = Convert.ToDecimal(cmdCommand.Parameters["OUT_MNI_N_CODIGO_PAI"].Value);
                    }

                    if ((cmdCommand.Parameters["OUT_MNI_FUN_N_CODIGO"] != null) && cmdCommand.Parameters["OUT_MNI_FUN_N_CODIGO"].Value != null && cmdCommand.Parameters["OUT_MNI_FUN_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoFuncionalidade = Convert.ToDecimal(cmdCommand.Parameters["OUT_MNI_FUN_N_CODIGO"].Value);
                    }

                    if ((cmdCommand.Parameters["OUT_MNI_B_STATUS"] != null) && cmdCommand.Parameters["OUT_MNI_B_STATUS"].Value != null && cmdCommand.Parameters["OUT_MNI_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["OUT_MNI_B_STATUS"].Value);
                    }

                    if ((cmdCommand.Parameters["OUT_MNI_N_ORDEM"] != null) && cmdCommand.Parameters["OUT_MNI_N_ORDEM"].Value != null && cmdCommand.Parameters["OUT_MNI_N_ORDEM"].Value != System.DBNull.Value)
                    {
                        objRetorno.Ordem = Convert.ToInt32(cmdCommand.Parameters["OUT_MNI_N_ORDEM"].Value);
                    }

                    if ((cmdCommand.Parameters["OUT_MNI_C_CAMINHO_PAGINA"] != null) && cmdCommand.Parameters["OUT_MNI_C_CAMINHO_PAGINA"].Value != null && cmdCommand.Parameters["OUT_MNI_C_CAMINHO_PAGINA"].Value != System.DBNull.Value)
                    {
                        objRetorno.CaminhoPagina = cmdCommand.Parameters["OUT_MNI_C_CAMINHO_PAGINA"].Value.ToString();
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
        /// <param name="pdecCodigo">Código do Item do Menu</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>mazevedo</user>
        public bool Excluir(String pstrCodigoItens)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWK_D_MENU_ITEM");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("MNI_C_CODIGO", FWDbType.Varchar));
            cmdCommand.Parameters["MNI_C_CODIGO"].Value = pstrCodigoItens;

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
        /// Executa a Stored Procedure de Alteração
        /// </summary> 
        /// <param name="pobjMLMenuItem">MenuItem para alterar</param>
        /// <returns>Resultado da Operação</returns> 
        /// <user>mazevedo</user>
        public bool Alterar(MLMenuItem pobjMLMenuItem)
        {

            bool blnRetorno;
            FWCommand cmdCommand = new FWCommand("USP_FWK_U_MENU_ITEM");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLMenuItem.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_N_CODIGO"].Value = pobjMLMenuItem.Codigo.Value;
            }
            if (pobjMLMenuItem.CodigoMenu.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_MEN_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_MEN_N_CODIGO"].Value = pobjMLMenuItem.CodigoMenu.Value;
            }
            if (pobjMLMenuItem.CodigoMenuIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_MEN_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_MEN_IDI_N_CODIGO"].Value = pobjMLMenuItem.CodigoMenuIdioma.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMenuItem.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_C_NOME", FWDbType.Varchar, 100));
                cmdCommand.Parameters["MNI_C_NOME"].Value = pobjMLMenuItem.Nome;
            }
            if (pobjMLMenuItem.CodigoPai.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_N_CODIGO_PAI", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_N_CODIGO_PAI"].Value = pobjMLMenuItem.CodigoPai.Value;
            }
            if (pobjMLMenuItem.CodigoFuncionalidade.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_FUN_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_FUN_N_CODIGO"].Value = pobjMLMenuItem.CodigoFuncionalidade.Value;
            }
            if (pobjMLMenuItem.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["MNI_B_STATUS"].Value = pobjMLMenuItem.IsAtivo.Value;
            }
            if (pobjMLMenuItem.Ordem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_N_ORDEM", FWDbType.Int32));
                cmdCommand.Parameters["MNI_N_ORDEM"].Value = pobjMLMenuItem.Ordem.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMenuItem.CaminhoPagina))
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_C_CAMINHO_PAGINA", FWDbType.Varchar, 300));
                cmdCommand.Parameters["MNI_C_CAMINHO_PAGINA"].Value = pobjMLMenuItem.CaminhoPagina;
            }

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

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Executa a Stored Procedure de Inserção
        /// </summary> 
        /// <param name="pobjMLMenuItem">MenuItem para inserir</param>
        /// <returns>Código MenuItem</returns> 
        /// <user>mazevedo</user>
        public int Inserir(MLMenuItem pobjMLMenuItem)
        {

            int intRetorno = 0;
            FWCommand cmdCommand = new FWCommand("USP_FWK_I_MENU_ITEM");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pobjMLMenuItem.CodigoMenu.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_MEN_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_MEN_N_CODIGO"].Value = pobjMLMenuItem.CodigoMenu.Value;
            }
            if (pobjMLMenuItem.CodigoMenuIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_MEN_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_MEN_IDI_N_CODIGO"].Value = pobjMLMenuItem.CodigoMenuIdioma.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMenuItem.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_C_NOME", FWDbType.Varchar, 100));
                cmdCommand.Parameters["MNI_C_NOME"].Value = pobjMLMenuItem.Nome;
            }
            if (pobjMLMenuItem.CodigoPai.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_N_CODIGO_PAI", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_N_CODIGO_PAI"].Value = pobjMLMenuItem.CodigoPai.Value;
            }
            if (pobjMLMenuItem.CodigoFuncionalidade.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_FUN_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_FUN_N_CODIGO"].Value = pobjMLMenuItem.CodigoFuncionalidade.Value;
            }
            if (pobjMLMenuItem.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["MNI_B_STATUS"].Value = pobjMLMenuItem.IsAtivo.Value;
            }
            if (pobjMLMenuItem.Ordem.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_N_ORDEM", FWDbType.Int32));
                cmdCommand.Parameters["MNI_N_ORDEM"].Value = pobjMLMenuItem.Ordem.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMenuItem.CaminhoPagina))
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_C_CAMINHO_PAGINA", FWDbType.Varchar, 300));
                cmdCommand.Parameters["MNI_C_CAMINHO_PAGINA"].Value = pobjMLMenuItem.CaminhoPagina;
            }

            cmdCommand.Parameters.Add(new FWParameter("MNI_N_CODIGO", FWDbType.Int32));
            cmdCommand.Parameters["MNI_N_CODIGO"].Direction = ParameterDirection.Output;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);

                if (cmdCommand.Parameters["MNI_N_CODIGO"] != null)
                    intRetorno = Convert.ToInt32(cmdCommand.Parameters["MNI_N_CODIGO"].Value);

            }
            catch
            {
                throw;
            }
            return intRetorno;
        }

        #endregion

        #region Alterar Ordem
        /// <summary>
        /// Alterar a ordem de exibição do item do menu
        /// </summary>
        /// <param name="pdecCodigoOrigem"></param>
        /// <param name="pdecCodigoDestino"></param>
        /// <user>mazevedo</user>
        public void AlterarOrdem(decimal pdecCodigoOrigem, decimal? pdecCodigoDestino, decimal pdecCodigoPaiDestino)
        {
            FWCommand cmdCommand = new FWCommand("USP_FWK_U_MENU_ITEM_ORDENAR");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            cmdCommand.Parameters.Add(new FWParameter("MNI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["MNI_N_CODIGO"].Value = pdecCodigoOrigem;

            if (pdecCodigoDestino.HasValue && pdecCodigoDestino.Value > 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("MNI_N_CODIGO_DESTINO_ANTERIOR", FWDbType.Decimal));
                cmdCommand.Parameters["MNI_N_CODIGO_DESTINO_ANTERIOR"].Value = pdecCodigoDestino;
            }

            cmdCommand.Parameters.Add(new FWParameter("MNI_N_CODIGO_PAI_DESTINO", FWDbType.Decimal));
            cmdCommand.Parameters["MNI_N_CODIGO_PAI_DESTINO"].Value = pdecCodigoPaiDestino;

            try
            {
                conProvider.ExecuteNonQuery(cmdCommand);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Listar Pais

        /// <summary>
        ///     Execura a procedure de listagem de pais de itens
        /// </summary>
        /// <user>mazevedo</user>
        public List<MLMenuItem> ListarPais(decimal pdecCodigo)
        {
            List<MLMenuItem> lstRetorno = new List<MLMenuItem>();
            FWCommand cmdCommand = new FWCommand("USP_FWK_L_MENU_ITEM_PAIS");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pdecCodigo > 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("PAG_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["PAG_N_CODIGO"].Value = pdecCodigo;
            }

            // Retorno do Curso
            cmdCommand.Parameters.Add(new FWParameter("RCT1", FWDbType.Cursor));
            cmdCommand.Parameters["RCT1"].Direction = ParameterDirection.Output;

            IDataReader idrRetorno = null;
            try
            {
                MLMenuItem objRetorno = null;
                lstRetorno = new List<MLMenuItem>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLMenuItem();
                    if (idrRetorno["MNI_C_NOME"] != System.DBNull.Value)
                    {
                        objRetorno.Nome = idrRetorno.GetValue(idrRetorno.GetOrdinal("MNI_C_NOME")).ToString();
                    }
                    if (idrRetorno["MNI_C_CAMINHO_PAGINA"] != System.DBNull.Value)
                    {
                        objRetorno.CaminhoPagina = idrRetorno.GetValue(idrRetorno.GetOrdinal("MNI_C_CAMINHO_PAGINA")).ToString();
                    }
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

        #region Lista Filhos

        /// <summary>
        ///     Execura a procedure de listagem de filhos de itens
        /// </summary>
        /// <user>mazevedo</user>
        public List<MLMenuItem> ListarFilhos(decimal pdecCodigo)
        {
            List<MLMenuItem> lstRetorno = new List<MLMenuItem>();
            FWCommand cmdCommand = new FWCommand("USP_FWK_L_MENU_ITEM_FILHOS");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            if (pdecCodigo > 0)
            {
                cmdCommand.Parameters.Add(new FWParameter("PAG_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["PAG_N_CODIGO"].Value = pdecCodigo;
            }

            // Retorno do Curso
            cmdCommand.Parameters.Add(new FWParameter("RCT1", FWDbType.Cursor));
            cmdCommand.Parameters["RCT1"].Direction = ParameterDirection.Output;

            try
            {
                IDataReader idrRetorno = null;
                try
                {
                    MLMenuItem objRetorno = null;
                    lstRetorno = new List<MLMenuItem>();
                    idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                    while (idrRetorno.Read())
                    {
                        objRetorno = new MLMenuItem();
                        if (idrRetorno["MNI_C_NOME"] != System.DBNull.Value)
                        {
                            objRetorno.Nome = idrRetorno.GetValue(idrRetorno.GetOrdinal("MNI_C_NOME")).ToString();
                        }
                        if (idrRetorno["MNI_C_CAMINHO_PAGINA"] != System.DBNull.Value)
                        {
                            objRetorno.CaminhoPagina = idrRetorno.GetValue(idrRetorno.GetOrdinal("MNI_C_CAMINHO_PAGINA")).ToString();
                        }
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
            }
            catch
            {
                throw;
            }

            return lstRetorno;

        }

        #endregion
    }
}


