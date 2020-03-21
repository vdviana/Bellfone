using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;


namespace VM2.Framework.DataLayer.Utilitarios
{

    /// <summary>
    ///     Classe que gerencia a conexao com os bancos de dados
    /// </summary>
    /// <user>mazevedo</user>
    public class Connector
    {

        #region Variáveis Privadas
        private DLFWBase gobjDLAtual;
        private ProviderType enmProvider = ProviderType.SqlClient;
        #endregion

        /// <summary>
        ///     Construtor instancia 
        /// </summary>
        /// <user>mazevedo</user>
        public Connector()
        {
            this.enmProvider = (ProviderType)Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.ProviderType"]);
        }

        #region Metodos

        #region Log
        /// <summary>
        ///     Retorna a DL de log de acordo com o provider
        /// </summary>
        /// <returns>DL de log</returns>
        /// <user>mazevedo</user>
        public IDLLog ObterDLLog()
        {

            switch (enmProvider)
            {
                case ProviderType.OracleClient:
                    gobjDLAtual = new Oracle.DLLog();
                    break;
                case ProviderType.SqlClient:
                    gobjDLAtual = new Sql.DLLog();
                    break;
            }

            return (IDLLog)gobjDLAtual;

        }
        #endregion

        #region Configuracao
        /// <summary>
        ///     Retorna a DL de Conbfiguracao de acordo com o provider
        /// </summary>
        /// <returns>DL de Configuracao</returns>
        /// <user>tprohaska</user>
        public IDLConfiguracao ObterDLConfiguracao()
        {

            switch (enmProvider)
            {
                case ProviderType.OracleClient:
                    gobjDLAtual = new Oracle.DLConfiguracao();
                    break;
                case ProviderType.SqlClient:
                    gobjDLAtual = new Sql.DLConfiguracao();
                    break;
            }

            return (IDLConfiguracao)gobjDLAtual;

        }
        #endregion

        #region Utilitário
        /// <summary>
        ///     Retorna a DL de Utilitário de acordo com o provider
        /// </summary>
        /// <returns>DL de Utilitario</returns>
        /// <user>mazevedo</user>
        public IDLUtilitario ObterDLUtilitario()
        {

            switch (enmProvider)
            {
                case ProviderType.OracleClient:
                    gobjDLAtual = new Oracle.DLUtilitario();
                    break;
                case ProviderType.SqlClient:
                    gobjDLAtual = new Sql.DLUtilitario();
                    break;
            }

            return (IDLUtilitario)gobjDLAtual;

        }
        #endregion


        #endregion

        #region Transacao e Fechamento

        /// <summary>
        ///     Finaliza a conexao
        /// </summary>
        /// <user>mazevedo</user>
        public void Finalizar()
        {
            if (this.gobjDLAtual != null)
            {
                this.gobjDLAtual.Finalizar();
            }
        }

        /// <summary>
        ///     ID da Transacao
        /// </summary>
        /// <user>mazevedo</user>
        public string TransactionID
        {
            get
            {
                if (this.gobjDLAtual != null)
                {
                    return this.gobjDLAtual.TransacaoID;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (this.gobjDLAtual != null)
                {
                    this.gobjDLAtual.TransacaoID = value;
                }
            }
        }

        /// <summary>
        ///     Inicia uma transação
        /// </summary>
        /// <user>mazevedo</user>
        public void BeginTransaction()
        {
            if (this.gobjDLAtual != null)
            {
                this.gobjDLAtual.BeginTransaction();
            }
        }

        /// <summary>
        ///     Confirma as operações da transação
        /// </summary>
        /// <user>mazevedo</user>
        public void CommitTransaction()
        {
            if (this.gobjDLAtual != null)
            {
                this.gobjDLAtual.CommitTransaction();
            }
        }

        /// <summary>
        ///     Desfaz as operações da transação
        /// </summary>
        /// <user>mazevedo</user>
        public void RollBackTransaction()
        {
            if (this.gobjDLAtual != null)
            {
                this.gobjDLAtual.RollBackTransaction();
            }
        }

        #endregion

    }
}
