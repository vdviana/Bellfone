using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using VM2.Framework.DataLayer.Arquivo;



namespace VM2.Framework.DataLayer.Arquivo
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

        #region Arquivo
        /// <summary>
        ///     Retorna a DL de Arquivo de acordo com o provider
        /// </summary>
        /// <returns>DL de Arquivo</returns>
        /// <user>mazevedo</user>
        public IDLArquivo ObterDLArquivo()
        {

            switch (enmProvider)
            {
                case ProviderType.OracleClient:
                    gobjDLAtual = new Oracle.DLArquivo();
                    break;
                case ProviderType.SqlClient:
                    gobjDLAtual = new Sql.DLArquivo();
                    break;
            }

            return (IDLArquivo)gobjDLAtual;

        }
        #endregion


        #region CategoriaArquivo
        /// <summary>
        ///     Retorna a DL de CategoriaArquivo de acordo com o provider
        /// </summary>
        /// <returns>DL de CategoriaArquivo</returns>
        /// <user>mazevedo</user>
        public IDLCategoriaArquivo ObterDLCategoriaArquivo()
        {

            switch (enmProvider)
            {
                case ProviderType.OracleClient:
                    gobjDLAtual = new Oracle.DLCategoriaArquivo();
                    break;
                case ProviderType.SqlClient:
                    gobjDLAtual = new Sql.DLCategoriaArquivo();
                    break;
            }

            return (IDLCategoriaArquivo)gobjDLAtual;

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
