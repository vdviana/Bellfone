using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;


namespace VM2.Framework.DataLayer.Usuario
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

        #region Grupo
        /// <summary>
        ///     Retorna a DL de grupo de acordo com o provider
        /// </summary>
        /// <returns>DL de grupo</returns>
        /// <user>mazevedo</user>
        public IDLGrupo ObterDLGrupo()
        {

            switch (enmProvider)
            {
                case ProviderType.OracleClient:
                    gobjDLAtual = new Oracle.DLGrupo();
                    break;
                case ProviderType.SqlClient:
                    gobjDLAtual = new Sql.DLGrupo();
                    break;
            }

            return (IDLGrupo)gobjDLAtual;

        }
        #endregion

        #region Usuario
        /// <summary>
        ///     Retorna a DL de usuario de acordo com o provider
        /// </summary>
        /// <returns>DL de usuario</returns>
        /// <user>mazevedo</user>
        public IDLUsuario ObterDLUsuario()
        {

            switch (enmProvider)
            {
                case ProviderType.OracleClient:
                    gobjDLAtual = new Oracle.DLUsuario();
                    break;
                case ProviderType.SqlClient:
                    gobjDLAtual = new Sql.DLUsuario();
                    break;
            }

            return (IDLUsuario)gobjDLAtual;

        }
        #endregion

        #region Funcionalidade
        /// <summary>
        ///     Retorna a DL de funcionalidade de acordo com o provider
        /// </summary>
        /// <returns>DL de funcionalidade</returns>
        /// <user>mazevedo</user>
        public IDLFuncionalidade ObterDLFuncionalidade()
        {

            switch (enmProvider)
            {
                case ProviderType.OracleClient:
                    gobjDLAtual = new Oracle.DLFuncionalidade();
                    break;
                case ProviderType.SqlClient:
                    gobjDLAtual = new Sql.DLFuncionalidade();
                    break;
            }

            return (IDLFuncionalidade)gobjDLAtual;

        }
        #endregion

        #region GrupoPermissao
        /// <summary>
        ///     Retorna a DL de grupopermissao de acordo com o provider
        /// </summary>
        /// <returns></returns>
        /// <user>mazevedo</user>
        public IDLGrupoPermissao ObterDLGrupoPermissao()
        {

            switch (enmProvider)
            {
                case ProviderType.OracleClient:
                    gobjDLAtual = new Oracle.DLGrupoPermissao();
                    break;
                case ProviderType.SqlClient:
                    gobjDLAtual = new Sql.DLGrupoPermissao();
                    break;
            }

            return (IDLGrupoPermissao)gobjDLAtual;

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
