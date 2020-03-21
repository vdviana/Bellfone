using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Xml;
using Framework.AtendimentoOnline.Model;

namespace Framework.AtendimentoOnline.DataLayer
{
    /// <summary>
    /// Classe para acesso aos dados do Assunto
    /// </summary>
    /// <author>vnarcizo</author>
    /// <createdDate>27/02/2009</createdDate>
    public class DALAtendimento
    {

        #region Inserir
        /// <summary>
        ///  Insere um novo atendimento
        /// </summary>
        /// <param name="guid">Guid do atendimento</param>
        /// <param name="caminhoArquivo">Caminho do arquivo</param>
        /// <returns>Status da inserção</returns>
        /// <user>vnarcizo</user>
        public bool Inserir(string guid, string caminhoArquivo)
        {
            bool retorno = false;

            string arquivo = caminhoArquivo + "\\xmlAtendimento.xml";

            if (!File.Exists(arquivo))
            {
                try
                {
                    Directory.CreateDirectory(arquivo.Substring(0, arquivo.LastIndexOf("\\")));
                    File.Copy(HttpContext.Current.Server.MapPath("../../AtendimentoOnline/arquivos/atendimento/xmlAtendimento.xml"), arquivo, true);
                    File.SetAttributes(arquivo, FileAttributes.Normal);
                }
                catch (Exception)
                {

                    throw;
                }

            }

            try
            {

                var xdcDocumentConvertsation = new XmlDocument();
                File.SetAttributes(arquivo, FileAttributes.Normal);
                var fs = new StreamReader(arquivo, true);
                xdcDocumentConvertsation.Load(fs);

                var xndNodeConversation = xdcDocumentConvertsation.SelectSingleNode("atendimentoSistema");

                var xndNovaAtendimento = xdcDocumentConvertsation.CreateElement("atendimento");

                var xmaGuid = xdcDocumentConvertsation.CreateAttribute("GUID");
                var xmaOcorrencia = xdcDocumentConvertsation.CreateAttribute("ocorrencia");

                xmaGuid.Value = guid;
                xmaOcorrencia.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                xndNovaAtendimento.Attributes.Append(xmaGuid);
                xndNovaAtendimento.Attributes.Append(xmaOcorrencia);

                xndNodeConversation.AppendChild(xndNovaAtendimento);
                fs.Close();
                fs.Dispose();
                //File.SetAttributes(arquivo, FileAttributes.Normal);
                var streamWrite = new StreamWriter(arquivo, false);
                streamWrite.Write(xdcDocumentConvertsation.OuterXml);
                streamWrite.Close();
                streamWrite.Dispose();

            }
            catch (Exception)
            {

            }

            return retorno;
        }

        public bool Alterar(string guid, string caminhoArquivo)
        {
            bool retorno = false;

            string arquivo = HttpContext.Current.Server.MapPath(caminhoArquivo + "\\xmlAtendimento.xml");

            try
            {

                var xdcDocumentConvertsation = new XmlDocument();
                File.SetAttributes(arquivo, FileAttributes.Normal);
                var fs = new StreamReader(arquivo, true);
                xdcDocumentConvertsation.Load(fs);

                var xndNodeConversation = xdcDocumentConvertsation.SelectSingleNode("atendimentoSistema");

                if (xndNodeConversation != null && xndNodeConversation.ChildNodes.Count > 0)
                {

                    foreach (XmlNode item in xndNodeConversation.ChildNodes)
                    {
                        if (item.Attributes["GUID"].Value == guid)
                        {
                            item.Attributes["ocorrencia"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            break;
                        }
                    }
                }

                fs.Close();
                fs.Dispose();
                //File.SetAttributes(arquivo, FileAttributes.Normal);
                var streamWrite = new StreamWriter(arquivo, false);
                streamWrite.Write(xdcDocumentConvertsation.OuterXml);
                streamWrite.Close();
                streamWrite.Dispose();

            }
            catch (Exception)
            {

            }

            return retorno;
        }

        #endregion

        #region Remover
        /// <summary>
        ///  Remove um determinado atendimento
        /// </summary>
        /// <param name="guid">Guid Do atendimento</param>
        /// <param name="caminhoArquivo">Caminho do arquivo</param>
        /// <returns>Status da remoção</returns>
        /// <user>vnarcizo</user>
        public bool Remover(string guid, string caminhoArquivo)
        {
            bool retorno = false;

            //string arquivo = HttpContext.Current.Server.MapPath(caminhoArquivo + "\\xmlAtendimento.xml");
            string arquivo = HttpContext.Current.Server.MapPath(caminhoArquivo + "\\" + guid);

            if (!File.Exists(arquivo))
            {
                Directory.CreateDirectory(arquivo.Substring(0, arquivo.LastIndexOf("\\")));
                File.Copy(HttpContext.Current.Server.MapPath("../../AtendimentoOnline/arquivos/atendimento/ConversaTemplate.xml"), arquivo, true);
                File.SetAttributes(arquivo, FileAttributes.Normal);
            }

            try
            {

                var xdcDocumentConvertsation = new XmlDocument();
                File.SetAttributes(arquivo, FileAttributes.Normal);
                var fs = new StreamReader(arquivo, true);
                xdcDocumentConvertsation.Load(fs);

                var xndNodeConversation = xdcDocumentConvertsation.SelectSingleNode("atendimentoSistema");

                if (xndNodeConversation != null)
                {
                    for (int i = 0; i < xndNodeConversation.ChildNodes.Count; i++)
                    {

                        if (xndNodeConversation.ChildNodes[i].Attributes["GUID"].Value == guid)
                        {
                            xndNodeConversation.RemoveChild(xndNodeConversation.ChildNodes[i]);
                            break;
                        }
                    }
                }

                fs.Close();
                fs.Dispose();
                //File.SetAttributes(arquivo, FileAttributes.Normal);
                var streamWrite = new StreamWriter(arquivo, false);
                streamWrite.Write(xdcDocumentConvertsation.OuterXml);
                streamWrite.Close();
                streamWrite.Dispose();

            }
            catch (Exception)
            {

            }

            return retorno;
        }

        #endregion

        #region Listar
        /// <summary>
        ///  Lista os atendimentos correntes
        /// </summary>
        /// <param name="caminhoArquivo">Caminho do arquivo que contem os atendimentos</param>
        /// <returns>Lista de atendimentos</returns>
        /// <user>vnarcizo</user>
        public List<ModelAtendimento> Listar(string caminhoArquivo)
        {
            ModelAtendimento objModelAtendimento;
            var lstAssunto = new List<ModelAtendimento>();
            FileStream fs = null;
            var arquivo = caminhoArquivo + "\\xmlAtendimento.xml";

            try
            {
                if (File.Exists(arquivo))
                {

                    fs = new FileStream(arquivo, FileMode.Open, FileAccess.Read);

                    var xdcDocument = new XmlDocument();
                    xdcDocument.Load(fs);

                    double tempoEspera = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.TempoEsperaInatividadeCliente"]) * 2.1;

                    var xndNodeConversation = xdcDocument.SelectSingleNode("atendimentoSistema");


                    for (int i = xndNodeConversation.ChildNodes.Count; i > 0; i--)
                    {
                        DateTime tempo = Convert.ToDateTime(xndNodeConversation.ChildNodes[i - 1].Attributes["ocorrencia"].Value);

                        if (DateTime.Now.Subtract(tempo).TotalMinutes > tempoEspera)
                        {
                            xndNodeConversation.RemoveChild(xndNodeConversation.ChildNodes[i - 1]);
                        }
                    }


                    var xndNodes = xdcDocument.SelectNodes("atendimentoSistema/atendimento");

                    foreach (XmlNode xndAtendimento in xndNodes)
                    {

                        objModelAtendimento = new ModelAtendimento
                                                  {
                                                      Guid = xndAtendimento.Attributes["GUID"].Value,
                                                      Ocorrencia =
                                                          Convert.ToDateTime(
                                                          xndAtendimento.Attributes["ocorrencia"].Value)
                                                  };

                        //Adicionando na lista
                        lstAssunto.Add(objModelAtendimento);
                    }

                    fs.Close();
                    fs.Dispose();
                    File.SetAttributes(arquivo, FileAttributes.Normal);
                    File.Delete(arquivo);
                    var streamWrite = new StreamWriter(arquivo);
                    streamWrite.Write(xdcDocument.OuterXml);
                    streamWrite.Close();
                    streamWrite.Dispose();
                }
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            return lstAssunto;
        }

        #endregion

        #region Historico de Atendimentos
        /// <summary>
        ///  Lista do Historico de atendimentos
        /// </summary>
        /// <param name="pobjModelAtendimentoHistorico">ModelAntendimentoHistorico para a pesquisa</param>
        /// <returns>Lista de Atendimentos</returns>
        /// <user>vnarcizo</user>
        public List<ModelAtendimentoHistorico> Historico(ModelAtendimentoHistorico pobjModelAtendimentoHistorico)
        {
            var caminhoArquivos = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.CaminhoXMLAtendimento"]);

            var caminhoDatasAtendente = caminhoArquivos + pobjModelAtendimentoHistorico.NomeAtendente;

            var objDALAssunto = new DALAssunto();
            var lstModelAssunto = objDALAssunto.Listar(null,null);

            var lstRetorno = new List<ModelAtendimentoHistorico>();

            if (!string.IsNullOrEmpty(pobjModelAtendimentoHistorico.NomeAtendente))
            {
                if (Directory.Exists(caminhoDatasAtendente))
                {
                    foreach (string datas in Directory.GetDirectories(caminhoDatasAtendente))
                    {
                        var dataArquivo = Convert.ToDateTime(datas.Substring(datas.LastIndexOf("\\") + 1));

                        if (!pobjModelAtendimentoHistorico.DataInicio.HasValue)
                            pobjModelAtendimentoHistorico.DataInicio = DateTime.MinValue;
                        if (!pobjModelAtendimentoHistorico.DataFim.HasValue)
                            pobjModelAtendimentoHistorico.DataFim = DateTime.MaxValue;

                        if (dataArquivo >= pobjModelAtendimentoHistorico.DataInicio &&
                            dataArquivo <= pobjModelAtendimentoHistorico.DataFim)
                        {
                            foreach (string xmls in Directory.GetFiles(datas))
                            {
                                var fs = new FileStream(xmls, FileMode.Open);

                                var xmlDocumento = new XmlDocument();
                                xmlDocumento.Load(fs);

                                var xmlConversation = xmlDocumento.SelectSingleNode("conversation");


                                var xmlNo = xmlConversation.ChildNodes[xmlConversation.ChildNodes.Count - 1];

                                var objModelAtendimentoHistorico = new ModelAtendimentoHistorico
                                                                       {
                                                                           NomeAtendente =
                                                                               pobjModelAtendimentoHistorico.
                                                                               NomeAtendente,
                                                                           DataAtendimento =
                                                                               Convert.ToDateTime(
                                                                               xmlNo.ChildNodes[
                                                                                   xmlNo.ChildNodes.Count - 1].
                                                                                   Attributes["ocorrencia"].Value),
                                                                           NomeCliente =
                                                                               xmlConversation.Attributes["NomeCliente"]
                                                                               .
                                                                               Value,
                                                                           GuidAtendimento =
                                                                               xmlConversation.Attributes["GUID"].Value,
                                                                           Assunto =
                                                                               lstModelAssunto.Find(
                                                                               obj => obj.Id == Convert.ToInt32(
                                                                                                    xmlConversation.
                                                                                                        Attributes[
                                                                                                        "idAssunto"]
                                                                                                        .
                                                                                                        Value)).Descricao
                                                                       };

                                if (!string.IsNullOrEmpty(pobjModelAtendimentoHistorico.Assunto))
                                {
                                    if (xmlConversation.Attributes["idAssunto"].Value == pobjModelAtendimentoHistorico.Assunto)
                                    {
                                        lstRetorno.Add(objModelAtendimentoHistorico);
                                    }
                                }
                                else
                                {
                                    lstRetorno.Add(objModelAtendimentoHistorico);
                                }

                                fs.Close();
                                fs.Dispose();
                            }
                        }
                    }
                }
            }
            return lstRetorno;
        }
        #endregion
    }
}
