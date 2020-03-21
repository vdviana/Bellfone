using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using Framework.AtendimentoOnline.Model;

namespace Framework.AtendimentoOnline.DataLayer
{
    /// <summary>
    /// Classe para acesso aos dados de conversa.
    /// </summary>
    /// <author>vnarcizo</author>
    /// <createdDate>28/01/2009</createdDate>
    public class DALConversa
    {
        #region Atributos
        private string strFileConversation;
        private static string pstrSchemaFile;
        #endregion

        #region Construtor

        /// <summary>
        /// Contrutor da classe Conversa que faz acesso a dados.
        /// </summary>
        /// <param name="pstrFileConversation">Caminho do arquivo da conversa</param>
        /// <author>vnarcizo</author>
        /// <createdDate>27/01/2009</createdDate>
        public DALConversa(string pstrFileConversation)
        {
            strFileConversation = pstrFileConversation;
        }

        #endregion

        #region Métodos

        #region Inserir Mensagem

        /// <summary>
        /// Inseri uma nova mensagem no arquivo de conversação.
        /// </summary>
        /// <param name="pobjMensagem">Mensagem a ser adicionada</param>
        /// <author>vnarcizo</author>
        /// <createdDate>27/01/2009</createdDate>
        public void InserirMensagem(ModelMensagem pobjMensagem)
        {

            if (!File.Exists(strFileConversation))
            {
                Directory.CreateDirectory(strFileConversation.Substring(0, strFileConversation.LastIndexOf("\\")) + "\\");
                File.Copy(HttpContext.Current.Server.MapPath("../../AtendimentoOnline/arquivos/atendimento/ConversaTemplate.xml"), strFileConversation, true);
                File.SetAttributes(strFileConversation, FileAttributes.Normal);
            }

            try
            {

                var xdcDocumentConvertsation = new XmlDocument();
                File.SetAttributes(strFileConversation, FileAttributes.Normal);
                var fs = new StreamReader(strFileConversation, true);
                xdcDocumentConvertsation.Load(fs);

                var xndNodeConversation = xdcDocumentConvertsation.SelectSingleNode("conversation");

                xndNodeConversation.Attributes["GUID"].Value = strFileConversation.Substring(strFileConversation.LastIndexOf("\\") + 1).Replace(".xml", "");
                xndNodeConversation.Attributes["idAssunto"].Value = pobjMensagem.CodigoAssunto.ToString();

                if (!string.IsNullOrEmpty(pobjMensagem.NomeAtendente))
                    xndNodeConversation.Attributes["NomeAtendente"].Value = pobjMensagem.NomeAtendente;

                if (!string.IsNullOrEmpty(pobjMensagem.NomeUsuario))
                    xndNodeConversation.Attributes["NomeCliente"].Value = pobjMensagem.NomeUsuario;

                if (!string.IsNullOrEmpty(pobjMensagem.NomeAtendente))
                    xndNodeConversation.Attributes["EmailCliente"].Value = pobjMensagem.EmailUsuario;

                if (pobjMensagem.CodigoReferenciaCliente != 0)
                    xndNodeConversation.Attributes["CodigoReferencia"].Value = pobjMensagem.CodigoReferenciaCliente.ToString();


                var xndNodeMessages = xndNodeConversation.SelectSingleNode("messages");

                //cria o no da nova mensagem
                var xndNovaMensagem = xdcDocumentConvertsation.CreateElement("menssage");

                //Cria os atributos e armazena valores do novo nó de mensagem
                var xmaOcorrencia = xdcDocumentConvertsation.CreateAttribute("ocorrencia");
                var xmaIsAtendente = xdcDocumentConvertsation.CreateAttribute("isAtendente");
                xmaOcorrencia.Value = pobjMensagem.Ocorrencia.ToString("yyyy-MM-dd HH:mm:ss");
                xmaIsAtendente.Value = pobjMensagem.IsAtendente.ToString();

                xndNovaMensagem.Attributes.Append(xmaOcorrencia);
                xndNovaMensagem.Attributes.Append(xmaIsAtendente);
                xndNovaMensagem.InnerText = pobjMensagem.Mensagem;

                xndNodeMessages.AppendChild(xndNovaMensagem);
                fs.Close();
                fs.Dispose();
                File.SetAttributes(strFileConversation, FileAttributes.Normal);
                var streamWrite = new StreamWriter(strFileConversation, false);
                streamWrite.Write(xdcDocumentConvertsation.OuterXml);
                streamWrite.Close();
                streamWrite.Dispose();

            }
            catch (Exception)
            {

            }


        }

        #endregion

        #region ListarMensagens
        /// <summary>
        ///  Lista as mensagens
        /// </summary>
        /// <returns>Model Conversa</returns>
        /// <user>vnarcizo</user>
        public ModelConversa ListarMensagens()
        {
            ModelConversa objModelConversa = null;
            List<ModelMensagem> lstMensagens = new List<ModelMensagem>();

            FileStream fs = null;

            if (!File.Exists(strFileConversation))
                return objModelConversa;

            try
            {

                fs = new FileStream(strFileConversation, FileMode.Open, FileAccess.Read);


                XmlDocument xdcDocumentConvertsation = new XmlDocument();
                xdcDocumentConvertsation.Load(fs);

                //Busca participantes da conversa
                XmlNode xndConversa = xdcDocumentConvertsation.SelectSingleNode("conversation");

                //Carrega informações da  conversa
                string strGUIDConversa = xndConversa.Attributes["GUID"].Value;
                string strCliente = xndConversa.Attributes["NomeCliente"].Value;
                string strAtendente = xndConversa.Attributes["NomeAtendente"].Value;
                string strEmailCliente = xndConversa.Attributes["EmailCliente"].Value;
                int intCodigoAssunto = Convert.ToInt32(xndConversa.Attributes["idAssunto"].Value); 
                int intCodigoAtendente = Convert.ToInt32(xndConversa.Attributes["idAtendente"].Value);

                int intCodigoReferencia = 0;
                if (xndConversa.Attributes["CodigoReferencia"] != null && xndConversa.Attributes["CodigoReferencia"].Value != "")
                {
                    intCodigoReferencia = Convert.ToInt32(xndConversa.Attributes["CodigoReferencia"].Value);
                }

                objModelConversa = new ModelConversa(strGUIDConversa,
                                                     intCodigoAssunto,
                                                     intCodigoAtendente,
                                                     strCliente,
                                                     strAtendente,
                                                     strEmailCliente, intCodigoReferencia);



                //Busca menssagens
                XmlNodeList xndNodesMessages = xdcDocumentConvertsation.SelectNodes("conversation/messages");

                if (xndNodesMessages.Count > 0)
                {
                    foreach (XmlNode xndMensagem in xndNodesMessages[0].ChildNodes)
                    {
                        bool blnIsAtendente;
                        DateTime dtiOcorrencia;
                        bool.TryParse(xndMensagem.Attributes["isAtendente"].Value, out blnIsAtendente);
                        DateTime.TryParse(xndMensagem.Attributes["ocorrencia"].Value, out dtiOcorrencia);

                        string strMenssagem = xndMensagem.InnerText;

                        ModelMensagem objMensagem = ModelMensagem.CriarNovaMensagem(blnIsAtendente, strMenssagem, strCliente,intCodigoAssunto,
                                                                                    dtiOcorrencia);
                        //TODO: Ocorrencia inatividade
                        objModelConversa.DataRequisicao = dtiOcorrencia;
                        objModelConversa.UltimaMensagem = strMenssagem;
                        objModelConversa.AdicionarMensagem(objMensagem);
                    }

                }

            }
            catch (Exception ex)
            {
                throw;

            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

            return objModelConversa;

        }

        #endregion

        #endregion
    }
}
