using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;

namespace VM2.Framework.DataLayer.Utilitarios.Sql
{
    /// <summary>
    ///     Classe de acesso a dados para Log de Erro
    /// </summary>
    /// <user>mazevedo</user>
    public class DLUtilitario : DLFWBase, IDLUtilitario
    {
        /// <summary>
        ///     Contrutor da classe inicializa as conexões
        /// </summary>
        /// <user>mazevedo</user>
        public DLUtilitario()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }

        #region VerificarBancoDados

        /// <summary>
        ///     Verifica a Conexão com o Banco de Dados
        /// </summary>
        /// <returns>Condicional de disponibilidade com o Banco de Dados</returns>
        /// <user>mazevedo</user>
        public bool VerificarBancoDados()
        {

            FWCommand cmdCommand = new FWCommand("sp_help");
            cmdCommand.CommandType = CommandType.Text;
            cmdCommand.CommandTimeout = intCommandTimeOut;
            try
            {
                conProvider.ExecuteScalar(cmdCommand);

            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

    }
}
