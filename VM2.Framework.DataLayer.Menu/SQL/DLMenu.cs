using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model.Menu;

namespace VM2.Framework.DataLayer.Menu.Sql
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
        /// <user>GeradorVm2</user> 
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
        /// <user>GeradorVm2</user>
        public List<MLMenu> Listar(MLMenu pobjMLMenu)
        {

            List<MLMenu> lstRetorno = null;

            FWCommand cmdCommand = new FWCommand("USP_FWK_L_MENU");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;

            if (pobjMLMenu.Codigo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MEN_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@MEN_N_CODIGO"].Value = pobjMLMenu.Codigo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMenu.Nome))
            {
                cmdCommand.Parameters.Add(new FWParameter("@MEN_C_NOME", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@MEN_C_NOME"].Value = pobjMLMenu.Nome;
            }
            if (pobjMLMenu.IsAtivo.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MEN_B_STATUS", FWDbType.Boolean));
                cmdCommand.Parameters["@MEN_B_STATUS"].Value = pobjMLMenu.IsAtivo.Value;
            }
            if (!string.IsNullOrEmpty(pobjMLMenu.Skin))
            {
                cmdCommand.Parameters.Add(new FWParameter("@MEN_C_SKIN", FWDbType.Varchar, 50));
                cmdCommand.Parameters["@MEN_C_SKIN"].Value = pobjMLMenu.Skin;
            }
            if (pobjMLMenu.CodigoIdioma.HasValue)
            {
                cmdCommand.Parameters.Add(new FWParameter("@MEN_IDI_N_CODIGO", FWDbType.Decimal));
                cmdCommand.Parameters["@MEN_IDI_N_CODIGO"].Value = pobjMLMenu.CodigoIdioma.Value;
            }

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
        /// <user>GeradorVm2</user>
        public MLMenu Obter(decimal pdecCodigo)
        {

            MLMenu objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWK_S_MENU");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@MEN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@MEN_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MEN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_MEN_N_CODIGO"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MEN_C_NOME", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_MEN_C_NOME"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MEN_B_STATUS", FWDbType.Boolean));
            cmdCommand.Parameters["@OUT_MEN_B_STATUS"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MEN_C_SKIN", FWDbType.Varchar, 50));
            cmdCommand.Parameters["@OUT_MEN_C_SKIN"].Direction = ParameterDirection.Output;
            cmdCommand.Parameters.Add(new FWParameter("@OUT_MEN_IDI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@OUT_MEN_IDI_N_CODIGO"].Direction = ParameterDirection.Output;

            try
            {
                objRetorno = new MLMenu();

                conProvider.ExecuteNonQuery(cmdCommand);

                if ((cmdCommand.Parameters["@OUT_MEN_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_MEN_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_MEN_N_CODIGO"].Value != System.DBNull.Value)
                {
                    objRetorno.Codigo = Convert.ToDecimal(cmdCommand.Parameters["@OUT_MEN_N_CODIGO"].Value);
                    if ((cmdCommand.Parameters["@OUT_MEN_C_NOME"] != null) && cmdCommand.Parameters["@OUT_MEN_C_NOME"].Value != null && cmdCommand.Parameters["@OUT_MEN_C_NOME"].Value != System.DBNull.Value)
                    {
                        objRetorno.Nome = cmdCommand.Parameters["@OUT_MEN_C_NOME"].Value.ToString();
                    }
                    if ((cmdCommand.Parameters["@OUT_MEN_B_STATUS"] != null) && cmdCommand.Parameters["@OUT_MEN_B_STATUS"].Value != null && cmdCommand.Parameters["@OUT_MEN_B_STATUS"].Value != System.DBNull.Value)
                    {
                        objRetorno.IsAtivo = Convert.ToBoolean(cmdCommand.Parameters["@OUT_MEN_B_STATUS"].Value);
                    }
                    if ((cmdCommand.Parameters["@OUT_MEN_C_SKIN"] != null) && cmdCommand.Parameters["@OUT_MEN_C_SKIN"].Value != null && cmdCommand.Parameters["@OUT_MEN_C_SKIN"].Value != System.DBNull.Value)
                    {
                        objRetorno.Skin = cmdCommand.Parameters["@OUT_MEN_C_SKIN"].Value.ToString();
                    }
                    if ((cmdCommand.Parameters["@OUT_MEN_IDI_N_CODIGO"] != null) && cmdCommand.Parameters["@OUT_MEN_IDI_N_CODIGO"].Value != null && cmdCommand.Parameters["@OUT_MEN_IDI_N_CODIGO"].Value != System.DBNull.Value)
                    {
                        objRetorno.CodigoIdioma = Convert.ToDecimal(cmdCommand.Parameters["@OUT_MEN_IDI_N_CODIGO"].Value);
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

            DataSet dtsRetorno = null;
            MLMenuCompleto objRetorno = null;
            FWCommand cmdCommand = new FWCommand("USP_FWK_S_MENU_COMPLETO");
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            cmdCommand.Parameters.Add(new FWParameter("@MEN_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@MEN_N_CODIGO"].Value = pdecCodigo;
            cmdCommand.Parameters.Add(new FWParameter("@MEN_IDI_N_CODIGO", FWDbType.Decimal));
            cmdCommand.Parameters["@MEN_IDI_N_CODIGO"].Value = pdecCodigoIdioma;

            cmdCommand.Parameters.Add(new FWParameter("@MNI_B_STATUS", FWDbType.Boolean));

            if (pblStatus.HasValue)
            {
                cmdCommand.Parameters["@MNI_B_STATUS"].Value = pblStatus.Value;
            }
            else
            {
                cmdCommand.Parameters["@MNI_B_STATUS"].Value = DBNull.Value;
            }

            try
            {
                objRetorno = new MLMenuCompleto();

                dtsRetorno = conProvider.ExecuteDataSet(cmdCommand);

                if (dtsRetorno != null)
                {
                    if (dtsRetorno.Tables[0] != null && dtsRetorno.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dtrRow in dtsRetorno.Tables[0].Rows)
                        {
                            if (dtrRow["MEN_N_CODIGO"] != DBNull.Value)
                            {
                                objRetorno.Codigo = Convert.ToDecimal(dtrRow["MEN_N_CODIGO"]);
                            }
                            if (dtrRow["MEN_C_NOME"] != DBNull.Value)
                            {
                                objRetorno.Nome = dtrRow["MEN_C_NOME"].ToString();
                            }
                            if (dtrRow["MEN_B_STATUS"] != DBNull.Value)
                            {
                                objRetorno.IsAtivo = Convert.ToBoolean(dtrRow["MEN_B_STATUS"]);
                            }
                            if (dtrRow["MEN_C_SKIN"] != DBNull.Value)
                            {
                                objRetorno.Skin = dtrRow["MEN_C_SKIN"].ToString();
                            }
                            if (dtrRow["MEN_IDI_N_CODIGO"] != DBNull.Value)
                            {
                                objRetorno.CodigoIdioma = Convert.ToDecimal(dtrRow["MEN_IDI_N_CODIGO"]);
                            }

                        }
                    }

                    if (dtsRetorno.Tables[1] != null && dtsRetorno.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dtrRow in dtsRetorno.Tables[1].Rows)
                        {
                            MLMenuItem objItem = new MLMenuItem();

                            if (dtrRow["MNI_N_CODIGO"] != DBNull.Value)
                            {
                                objItem.Codigo = Convert.ToDecimal(dtrRow["MNI_N_CODIGO"]);
                            }
                            if (dtrRow["MNI_FUN_N_CODIGO"] != DBNull.Value)
                            {
                                objItem.CodigoFuncionalidade = Convert.ToDecimal(dtrRow["MNI_FUN_N_CODIGO"]);
                            }
                            if (dtrRow["MNI_MEN_N_CODIGO"] != DBNull.Value)
                            {
                                objItem.CodigoMenu = Convert.ToDecimal(dtrRow["MNI_MEN_N_CODIGO"]);
                            }
                            if (dtrRow["MNI_MEN_IDI_N_CODIGO"] != DBNull.Value)
                            {
                                objItem.CodigoMenuIdioma = Convert.ToDecimal(dtrRow["MNI_MEN_IDI_N_CODIGO"]);
                            }
                            if (dtrRow["MNI_N_CODIGO_PAI"] != DBNull.Value)
                            {
                                objItem.CodigoPai = Convert.ToDecimal(dtrRow["MNI_N_CODIGO_PAI"]);
                            }
                            if (dtrRow["MNI_C_NOME"] != DBNull.Value)
                            {
                                objItem.Nome = dtrRow["MNI_C_NOME"].ToString();
                            }
                            if (dtrRow["MNI_B_STATUS"] != DBNull.Value)
                            {
                                objItem.IsAtivo = Convert.ToBoolean(dtrRow["MNI_B_STATUS"]);
                            }
                            if (dtrRow["FUN_C_CAMINHO_PAGINA"] != DBNull.Value)
                            {
                                objItem.CaminhoPagina = dtrRow["FUN_C_CAMINHO_PAGINA"].ToString();
                            }

                            objRetorno.ItensMenu.Add(objItem);
                        }
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


