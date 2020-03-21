using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model.Menu;

namespace VM2.Framework.DataLayer.Menu.Oracle
{
    /// <summary> 
    /// Classe de conexão de dados para Menu 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLMenu : DLFWBase, IDLMenu
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>mazevedo</user> 
        public DLMenu()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }


        #region Listar

        /// <summary> 
        /// Executa a Stored Procedure de Listagem
        /// </summary> 
        /// <param name="pobjMLMenu">Parametros para filtro</param>
        /// <returns>Lista de Menu</returns> 
        /// <user>mazevedo</user>
        public List<MLMenu> Listar(MLMenu pobjMLMenu)
        {

            List<MLMenu> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWK_L_MENU");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLMenu.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MEN_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["MEN_N_CODIGO"].Value = pobjMLMenu.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMenu.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("MEN_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["MEN_C_NOME"].Value = pobjMLMenu.Nome;
            }
            if (pobjMLMenu.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MEN_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["MEN_B_STATUS"].Value = pobjMLMenu.IsAtivo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMenu.Skin))
            {
                cmdCommand.Parameters.Add(new FWParameter("MEN_C_SKIN", FWDbType.Varchar, 50));
                cmdCommand.Parameters["MEN_C_SKIN"].Value = pobjMLMenu.Skin;
            }
            if (pobjMLMenu.CodigoIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("MEN_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["MEN_IDI_N_CODIGO"].Value = pobjMLMenu.CodigoIdioma.Value;
            }


            // Retorno do Curso
            cmdCommand.Parameters.Add(new FWParameter("RCT1", FWDbType.Cursor));
            cmdCommand.Parameters["RCT1"].Direction = ParameterDirection.Output;

            IDataReader idrRetorno = null;
            try
            {
                MLMenu objRetorno = null;
                lstRetorno = new List<MLMenu>();
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    objRetorno = new MLMenu();
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
        /// <param name="pdecCodigo">Código do Menu</param>
        /// <returns>Menu</returns> 
        /// <user>mazevedo</user>
        public MLMenu Obter(decimal pdecCodigo)
        {

            MLMenu objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWK_S_MENU");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("MEN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["MEN_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("OUT_MEN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["OUT_MEN_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_MEN_C_NOME", FWDbType.Varchar, 50));
            cmdCommand.Parameters["OUT_MEN_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_MEN_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["OUT_MEN_B_STATUS"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_MEN_C_SKIN", FWDbType.Varchar, 50));
            cmdCommand.Parameters["OUT_MEN_C_SKIN"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("OUT_MEN_IDI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["OUT_MEN_IDI_N_CODIGO"].Direction = ParameterDirection.Output;

            try
            {
                objRetorno = new MLMenu();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["OUT_MEN_N_CODIGO"] != null) && cmdCommand.Parameters["OUT_MEN_N_CODIGO"].Value != null && cmdCommand.Parameters["OUT_MEN_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["OUT_MEN_N_CODIGO"].Value);
                    if ((cmdCommand.Parameters["OUT_MEN_C_NOME"] != null) && cmdCommand.Parameters["OUT_MEN_C_NOME"].Value != null && cmdCommand.Parameters["OUT_MEN_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.Nome = cmdCommand.Parameters["OUT_MEN_C_NOME"].Value.ToString();
                    }

                    if ((cmdCommand.Parameters["OUT_MEN_B_STATUS"] != null) && cmdCommand.Parameters["OUT_MEN_B_STATUS"].Value != null && cmdCommand.Parameters["OUT_MEN_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["OUT_MEN_B_STATUS"].Value);
                    }

                    if ((cmdCommand.Parameters["OUT_MEN_C_SKIN"] != null) && cmdCommand.Parameters["OUT_MEN_C_SKIN"].Value != null && cmdCommand.Parameters["OUT_MEN_C_SKIN"].Value != System.DBNull.Value)
                    {
                        objRetorno.Skin = cmdCommand.Parameters["OUT_MEN_C_SKIN"].Value.ToString();
                    }
                    if ((cmdCommand.Parameters["OUT_MEN_IDI_N_CODIGO"] != null) && cmdCommand.Parameters["OUT_MEN_IDI_N_CODIGO"].Value != null && cmdCommand.Parameters["OUT_MEN_IDI_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoIdioma = Convert.ToDecimal(cmdCommand.Parameters["OUT_MEN_IDI_N_CODIGO"].Value);
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

        #region Obter Completo

        /// <summary> 
        /// Executa a stored procedure para retornar um registro específico
        /// </summary> 
        /// <param name="pdecCodigo">Código do Menu</param>
        /// <returns>Menu</returns> 
        /// <user>mazevedo</user>
        public MLMenuCompleto ObterCompleto(decimal pdecCodigo, decimal pdecCodigoIdioma, bool? pblStatus)
        {

            MLMenuCompleto objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWK_S_MENU_COMPLETO_P1");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("MEN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["MEN_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("MEN_IDI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["MEN_IDI_N_CODIGO"].Value = pdecCodigoIdioma;

            cmdCommand.Parameters.Add(new FWParameter("MNI_B_STATUS", FWDbType.Boolean));

            if (pblStatus.HasValue)
            {
                cmdCommand.Parameters["MNI_B_STATUS"].Value = pblStatus.Value;
            }
            else
            {
                cmdCommand.Parameters["MNI_B_STATUS"].Value = DBNull.Value;
            }

            // Retorno do Curso
            cmdCommand.Parameters.Add(new FWParameter("RCT1", FWDbType.Cursor));
            cmdCommand.Parameters["RCT1"].Direction = ParameterDirection.Output;

            objRetorno = new MLMenuCompleto();

            IDataReader idrRetorno = null;
            try
            {
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    if (idrRetorno["MEN_N_CODIGO"] != DBNull.Value)
                    {
                        objRetorno.Codigo = Convert.ToDecimal(idrRetorno["MEN_N_CODIGO"]);
                    }
                    if (idrRetorno["MEN_C_NOME"] != DBNull.Value)
                    {
                        objRetorno.Nome = idrRetorno["MEN_C_NOME"].ToString();
                    }
                    if (idrRetorno["MEN_B_STATUS"] != DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(idrRetorno["MEN_B_STATUS"]);
                    }
                    if (idrRetorno["MEN_C_SKIN"] != DBNull.Value)
                    {
                        objRetorno.Skin = idrRetorno["MEN_C_SKIN"].ToString();
                    }
                    if (idrRetorno["MEN_IDI_N_CODIGO"] != DBNull.Value)
                    {
                        objRetorno.CodigoIdioma = Convert.ToDecimal(idrRetorno["MEN_IDI_N_CODIGO"]);
                    }

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

            cmdCommand.CommandText = "USP_FWK_S_MENU_COMPLETO_P2";
            idrRetorno = null;
            try
            {
                idrRetorno = conProvider.ExecuteDataReader(cmdCommand);
                while (idrRetorno.Read())
                {
                    MLMenuItem objItem = new MLMenuItem();

                    if (idrRetorno["MNI_N_CODIGO"] != DBNull.Value)
                    {
                        objItem.Codigo = Convert.ToDecimal(idrRetorno["MNI_N_CODIGO"]);
                    }
                    if (idrRetorno["MNI_FUN_N_CODIGO"] != DBNull.Value)
                    {
                        objItem.CodigoFuncionalidade = Convert.ToDecimal(idrRetorno["MNI_FUN_N_CODIGO"]);
                    }
                    if (idrRetorno["MNI_MEN_N_CODIGO"] != DBNull.Value)
                    {
                        objItem.CodigoMenu = Convert.ToDecimal(idrRetorno["MNI_MEN_N_CODIGO"]);
                    }
                    if (idrRetorno["MNI_MEN_IDI_N_CODIGO"] != DBNull.Value)
                    {
                        objItem.CodigoMenuIdioma = Convert.ToDecimal(idrRetorno["MNI_MEN_IDI_N_CODIGO"]);
                    }
                    if (idrRetorno["MNI_N_CODIGO_PAI"] != DBNull.Value)
                    {
                        objItem.CodigoPai = Convert.ToDecimal(idrRetorno["MNI_N_CODIGO_PAI"]);
                    }
                    if (idrRetorno["MNI_C_NOME"] != DBNull.Value)
                    {
                        objItem.Nome = idrRetorno["MNI_C_NOME"].ToString();
                    }
                    if (idrRetorno["MNI_B_STATUS"] != DBNull.Value)
                    {
                        objItem.IsAtivo = Convert.ToBoolean(idrRetorno["MNI_B_STATUS"]);
                    }
                    if (idrRetorno["FUN_C_CAMINHO_PAGINA"] != DBNull.Value)
                    {
                        objItem.CaminhoPagina = idrRetorno["FUN_C_CAMINHO_PAGINA"].ToString();
                    }

                    objRetorno.ItensMenu.Add(objItem);
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

            return objRetorno;
        }

        #endregion
    }
}


