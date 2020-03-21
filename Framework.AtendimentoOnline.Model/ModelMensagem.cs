using System;

namespace Framework.AtendimentoOnline.Model
{
    public class ModelMensagem
    {
        #region Atributos

        private string strMensagem;        
        private bool blnIsAtendente;       
        private DateTime dtiOcorrencia;

        #endregion

        #region Propriedades

        /// <summary>
        /// Mensagem enviada por um usuário do atendimento
        /// </summary>
        /// <author>vnarcizo</author>
        /// <createdDate>28/01/2009</createdDate>
        public string Mensagem
        {
            get { return strMensagem; }
            set { strMensagem = value; }
        }

        /// <summary>
        /// Indica se a menssagem foi enviada pelo atendente.
        /// </summary>
        /// <author>vnarcizo</author>
        /// <createdDate>28/01/2009</createdDate>
        public bool IsAtendente
        {
            get { return blnIsAtendente; }
            set { blnIsAtendente = value; }
        }


        /// <summary>
        /// Ocorrência da mensagem.
        /// </summary>
        /// <author>vnarcizo</author>
        /// <createdDate>28/01/2009</createdDate>
        public DateTime Ocorrencia
        {
            get { return dtiOcorrencia; }
            set { dtiOcorrencia = value; }
        }

        /// <summary>
        /// NomeAtendente
        /// </summary>
        /// <author>vnarcizo</author>
        /// <createdDate>28/01/2009</createdDate>
        public string NomeAtendente{get;set;}

        /// <summary>
        /// NomeUsuario
        /// </summary>
        /// <author>vnarcizo</author>
        /// <createdDate>28/01/2009</createdDate>
        public string NomeUsuario { get; set; }

        /// <summary>
        /// NomeUsuario
        /// </summary>
        /// <author>vnarcizo</author>
        /// <createdDate>28/01/2009</createdDate>
        public string EmailUsuario { get; set; }

        /// <summary>
        /// Email do cliente.
        /// </summary>
        /// <author>vnarcizo</author>
        /// <dateCreated>28/01/2009</dateCreated>
        public int CodigoReferenciaCliente { get; set; }

        /// <summary>
        /// Email do cliente.
        /// </summary>
        /// <author>vnarcizo</author>
        /// <dateCreated>28/01/2009</dateCreated>
        public int CodigoAssunto { get; set; }


        #endregion

        #region Métodos Estáticos

        public static ModelMensagem CriarNovaMensagem(bool pblnIsAtendente, string pstrMensagem,string nomeAtendente,string nomeCliente,int codAssunto)
        {
            //Cria e seta os valores da mensagem
            var objMensagem = new ModelMensagem
                                            {
                                                blnIsAtendente = pblnIsAtendente,
                                                strMensagem = pstrMensagem,
                                                dtiOcorrencia = DateTime.Now,
                                                CodigoAssunto = codAssunto
                                            };

            
            if(!string.IsNullOrEmpty(nomeAtendente))
                objMensagem.NomeAtendente = nomeAtendente;

            if (!string.IsNullOrEmpty(nomeCliente))
                objMensagem.NomeUsuario = nomeCliente;

                return objMensagem;


        }

        public static ModelMensagem CriarNovaMensagem(bool pblnIsAtendente, string pstrMensagem,string nome,int codAssunto, DateTime pdtiOcorrencia)
        {
            //Cria e seta os valores da mensagem
            var objMensagem = new ModelMensagem
                                  {
                                      blnIsAtendente = pblnIsAtendente,
                                      strMensagem = pstrMensagem,
                                      dtiOcorrencia = pdtiOcorrencia,
                                      CodigoAssunto = codAssunto
                                  };

            if (pblnIsAtendente)
                objMensagem.NomeAtendente = nome;
            else
                objMensagem.NomeUsuario = nome;

            return objMensagem;


        }

        #endregion
    }
}
