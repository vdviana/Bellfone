using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;



namespace VM2.Framework.DataLayer.Noticia
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

        #region Noticia
        /// <summary>
        ///     Retorna a DL de Noticia de acordo com o provider
        /// </summary>
        /// <returns>DL de Noticia</returns>
        /// <user>mazevedo</user>
        public IDLNoticia ObterDLNoticia()
        {

            switch (enmProvider)
            {
                case ProviderType.OracleClient:
                    gobjDLAtual = new Oracle.DLNoticia();
                    break;
                case ProviderType.SqlClient:
                    gobjDLAtual = new Sql.DLNoticia();
                    break;
            }

            return (IDLNoticia)gobjDLAtual;

        }
        #endregion


        #region NoticiaCategoria
        /// <summary>
        ///     Retorna a DL de NoticiaCategoria de acordo com o provider
        /// </summary>
        /// <returns>DL de NoticiaCategoria</returns>
        /// <user>mazevedo</user>
        public IDLNoticiaCategoria ObterDLNoticiaCategoria()
        {

            switch (enmProvider)
            {
                case ProviderType.OracleClient:
                    gobjDLAtual = new Oracle.DLNoticiaCategoria();
                    break;
                case ProviderType.SqlClient:
                    gobjDLAtual = new Sql.DLNoticiaCategoria();
                    break;
            }

            return (IDLNoticiaCategoria)gobjDLAtual;

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
