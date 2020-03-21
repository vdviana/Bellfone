using System;
using System.Collections.Generic;
using System.Collections;

namespace Framework.AtendimentoOnline.Model
{
    /// <summary>
    /// Classe para armazenar informações de uma conversa. Desde os participantes até suas  menssagens.
    /// </summary>
    /// <author>vnarcizo</author>
    /// <dateCreated>28/01/2009</dateCreated>
    public class ModelConversa
    {
        #region Atributos

        private string strGUID;
        private int intCodigoAssunto;
        private int intCodigoAtendente;
        private string strNomeCliente;
        private string strNomeAtendente;
        private string strEmailCliente;
        private List<ModelMensagem> lstMensagens;

        private string strCodigoRevendedor;

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor da classe Model Conversa
        /// </summary>
        /// <param name="pstrGUID">GUID indentificador da conversa.</param>
        /// <param name="pintCodigoAssunto">Código do assunto.</param>
        /// <param name="pstrNomeCliente">Nome do cliente.</param>
        /// <param name="pstrEmailCliente">Email do cliente.</param>
        /// <param name="pstrCodigoRevendedor">Codigo do Revendedor.</param>
        /// <author>vnarcizo</author>
        /// <dateCreated>28/01/2009</dateCreated>
        public ModelConversa(string pstrGUID,
                                int pintCodigoAssunto,                                
                                string pstrNomeCliente,                                
                                string pstrEmailCliente,
                                string pstrCodigoRevendedor)
        {
            strGUID = pstrGUID;
            intCodigoAssunto = pintCodigoAssunto;            
            strNomeCliente = pstrNomeCliente;
            strEmailCliente = pstrEmailCliente;
            DataRequisicao = DateTime.Now;
            strCodigoRevendedor = pstrCodigoRevendedor;
        }

        /// <summary>
        /// Construtor da classe Model Conversa
        /// </summary>
        /// <param name="pstrGUID">GUID indentificador da conversa.</param>
        /// <param name="pintCodigoAssunto">Código do assunto.</param>
        /// <param name="pintCodigoAtendente">Código do Atendente.</param>
        /// <param name="pstrNomeCliente">Nome do cliente.</param>
        /// <param name="pstrNomeAtendente">Nome do atendente.</param>
        /// <param name="pstrEmailCliente">Email do cliente.</param>
        /// <author>vnarcizo</author>
        /// <dateCreated>28/01/2009</dateCreated>
        public ModelConversa(string pstrGUID,
                                int pintCodigoAssunto,
                                int pintCodigoAtendente,
                                string pstrNomeCliente,
                                string pstrNomeAtendente,
                                string pstrEmailCliente,
                                int pintCodigoReferencia)
        {
            strGUID = pstrGUID;
            intCodigoAssunto = pintCodigoAssunto;
            intCodigoAtendente = pintCodigoAtendente;
            strNomeCliente = pstrNomeCliente;
            strNomeAtendente = pstrNomeAtendente;
            strEmailCliente = pstrEmailCliente;
            CodigoReferenciaCliente = pintCodigoReferencia;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Adiciona uma nova mensagem na conversa.
        /// </summary>
        /// <param name="objMensagem">Mensagem a ser adicionada.</param>
        /// <author>vnarcizo</author>
        /// <dateCreated>28/01/2009</dateCreated>
        public void AdicionarMensagem(ModelMensagem objMensagem)
        {
            Mensagens.Add(objMensagem);
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// GUID da conversa.
        /// </summary>
        /// <author>vnarcizo</author>
        /// <dateCreated>28/01/2009</dateCreated>
        public string GUID
        {
            get { return strGUID; }
            set { strGUID = value; }
        }

        /// <summary>
        /// Código do assunto da conversa.
        /// </summary>
        /// <author>vnarcizo</author>
        /// <dateCreated>28/01/2009</dateCreated>
        public int CodigoAssunto
        {
            get { return intCodigoAssunto; }
            set { intCodigoAssunto = value; }
        }

        /// <summary>
        /// Código do atendente.
        /// </summary>
        /// <author>vnarcizo</author>
        /// <dateCreated>28/01/2009</dateCreated>
        public int CodigoAtendente
        {
            get { return intCodigoAtendente; }
            set { intCodigoAtendente = value; }
        }

        /// <summary>
        /// Código do cliente.
        /// </summary>
        /// <author>vnarcizo</author>
        /// <dateCreated>28/01/2009</dateCreated>
        public string NomeCliente
        {
            get { return strNomeCliente; }
            set { strNomeCliente = value; }
        }

        /// <summary>
        /// Nome do atendente.
        /// </summary>
        /// <author>vnarcizo</author>
        /// <dateCreated>28/01/2009</dateCreated>
        public string NomeAtendente
        {
            get { return strNomeAtendente; }
            set { strNomeAtendente = value; }
        }

        /// <summary>
        /// Email do cliente.
        /// </summary>
        /// <author>vnarcizo</author>
        /// <dateCreated>28/01/2009</dateCreated>
        public string EmailCliente
        {
            get { return strEmailCliente; }
            set { strEmailCliente = value; }
        }

        /// <summary>
        /// Email do cliente.
        /// </summary>
        /// <author>vnarcizo</author>
        /// <dateCreated>28/01/2009</dateCreated>
        public int CodigoReferenciaCliente{get; set;}

        /// <summary>
        /// Data ultima Requisição
        /// </summary>
        /// <author>vnarcizo</author>
        /// <dateCreated>02/03/2009</dateCreated>
        public DateTime DataRequisicao {get; set;}

        /// <summary>
        ///         /// <summary>
        /// NomeUsuario
        /// </summary>
        /// <author>vnarcizo</author>
        /// <createdDate>28/01/2009</createdDate>
        public string UltimaMensagem { get; set; }

        /// Mensagens trocadas nesta conversa   .
        /// </summary>
        /// <author>vnarcizo</author>
        /// <dateCreated>28/01/2009</dateCreated>
        public List<ModelMensagem> Mensagens
        {
            get
            {
                if (lstMensagens == null)
                    lstMensagens = new List<ModelMensagem>();
                return lstMensagens;
            }
        }



        /// <summary>
        /// Código do Revendedor.
        /// </summary>
        /// <author>lmascarenhas</author>
        /// <dateCreated>17/10/2009</dateCreated>
        public string CodigoRevendedor
        {
            get { return strCodigoRevendedor; }
            set { strCodigoRevendedor = value; }
        }
       


        #endregion
    }
}
