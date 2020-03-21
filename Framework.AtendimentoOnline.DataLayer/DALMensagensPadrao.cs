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
    public class DALMensagensPadrao
    {

        #region Inserir
        /// <summary>
        ///  Insere um novo registro no xml
        /// </summary>
        /// <param name="objMLAssunto"></param>
        /// <returns></returns>
        /// <user>vnarcizo</user>
        public bool Inserir(ModelMensagensPadrao objMLAssunto)
        {
            bool retorno = false;
            string caminho = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.CaminhoXMLMensagensPadroes"].ToString());
            FileStream fs = new FileStream(caminho, FileMode.Open, FileAccess.ReadWrite);

            try
            {
                XmlDocument xdcDocument = new XmlDocument();
                xdcDocument.Load(fs);

                XmlNode xndNodeMensagem = xdcDocument.SelectSingleNode("mensagensSistema");

                XmlNode xndNovaMensagem = xdcDocument.CreateElement("mensagen");
                XmlAttribute xmlTitulo = xdcDocument.CreateAttribute("titulo");
                XmlAttribute xmlId = xdcDocument.CreateAttribute("id");
                XmlAttribute xmlDescricao = xdcDocument.CreateAttribute("descricao");
                XmlAttribute xmlAtivo = xdcDocument.CreateAttribute("ativo");

                XmlNode nodeUltimo = xndNodeMensagem.ChildNodes[xndNodeMensagem.ChildNodes.Count - 1];

                xmlTitulo.Value = objMLAssunto.Titulo;
                xmlDescricao.Value = objMLAssunto.Descricao;
                xmlAtivo.Value = objMLAssunto.Ativo.ToString();
                xmlId.Value = (Convert.ToInt32(nodeUltimo.Attributes["id"].Value) + 1).ToString();

                xndNovaMensagem.Attributes.Append(xmlTitulo);
                xndNovaMensagem.Attributes.Append(xmlDescricao);
                xndNovaMensagem.Attributes.Append(xmlAtivo);
                xndNovaMensagem.Attributes.Append(xmlId);

                xndNodeMensagem.AppendChild(xndNovaMensagem);
                
                fs.Close();
                fs.Dispose();

                var write = new StreamWriter(caminho,false);

                write.Write(xdcDocument.InnerXml);
                write.Close();
                write.Dispose();
                
                retorno = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            return retorno;
        }

        #endregion

        #region Listar
        /// <summary>
        ///  Lista os registros do xml por ou sem Status
        /// </summary>
        /// <param name="blnAtivo">Status</param>
        /// <returns>Lista de Mensagens padrões</returns>
        /// <user>vnarcizo</user>
        public List<ModelMensagensPadrao> Listar(bool? blnAtivo)
        {
            ModelMensagensPadrao objMLAssunto;
            var lstMensagem = new List<ModelMensagensPadrao>();
            FileStream fs = null;
            string caminho = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.CaminhoXMLMensagensPadroes"].ToString());

            try
            {
                fs = new FileStream(caminho, FileMode.Open, FileAccess.Read);

                var xdcDocument = new XmlDocument();
                xdcDocument.Load(fs);

                XmlNodeList xndNodes = xdcDocument.SelectNodes("mensagensSistema/mensagen");

                foreach (XmlNode xndAssunto in xndNodes)
                {
                    objMLAssunto = new ModelMensagensPadrao();

                   objMLAssunto.Id = Convert.ToInt32(xndAssunto.Attributes["id"].Value);
                   objMLAssunto.Titulo = xndAssunto.Attributes["titulo"].Value;
                   objMLAssunto.Descricao = xndAssunto.Attributes["descricao"].Value;
                   objMLAssunto.Ativo = Convert.ToBoolean(xndAssunto.Attributes["ativo"].Value);

                   if (blnAtivo == null || objMLAssunto.Ativo == blnAtivo)
                   {
                       lstMensagem.Add(objMLAssunto);
                   }
                }
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            return lstMensagem;
        }

        #endregion

        #region Alterar
        /// <summary>
        ///  Altera um determinado registro do xml
        /// </summary>
        /// <param name="objModelMensagensPadrao">model mensagem padrão</param>
        /// <returns>Status se conseguiu efetuar a alteração</returns>
        /// <user>vnarcizo</user>
        public bool Alterar(ModelMensagensPadrao objModelMensagensPadrao)
        {
            bool retorno = false;
            string caminho = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.CaminhoXMLMensagensPadroes"].ToString());

            File.SetAttributes(caminho, FileAttributes.Normal);
            var fs = new FileStream(caminho, FileMode.Open, FileAccess.ReadWrite);

            try
            {
                var xdcDocument = new XmlDocument();
                xdcDocument.Load(fs);

                var xndNodeAssunto = xdcDocument.SelectSingleNode("mensagensSistema");

                foreach (XmlNode node in xndNodeAssunto.ChildNodes)
                {
                    if (Convert.ToInt32(node.Attributes["id"].Value) == objModelMensagensPadrao.Id)
                    {
                        node.Attributes["descricao"].Value = objModelMensagensPadrao.Descricao;
                        node.Attributes["titulo"].Value = objModelMensagensPadrao.Titulo;
                        node.Attributes["ativo"].Value = objModelMensagensPadrao.Ativo.ToString();
                        break;
                    }
                }

                fs.Close();
                fs.Dispose();

                var write = new StreamWriter(caminho, false);

                write.Write(xdcDocument.InnerXml);

                write.Close();
                write.Dispose();

                retorno = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            return retorno;
        }
        #endregion

        #region Obter
        /// <summary>
        /// Obtem um determinado registro do xml
        /// </summary>
        /// <param name="CodigoRegistro">Codigo do registro</param>
        /// <returns>Model de Mensagem Padrao</returns>
        /// <user>vnarcizo</user>
        public ModelMensagensPadrao Obter(decimal? CodigoRegistro)
        {
            ModelMensagensPadrao objModelMensagensPadrao = null;
            string caminho = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.CaminhoXMLMensagensPadroes"].ToString());

            File.SetAttributes(caminho, FileAttributes.Normal);
            var fs = new FileStream(caminho, FileMode.Open, FileAccess.ReadWrite);

            try
            {
                var xdcDocument = new XmlDocument();
                xdcDocument.Load(fs);

                var xndNodemensagens = xdcDocument.SelectSingleNode("mensagensSistema");

                foreach (XmlNode node in xndNodemensagens.ChildNodes)
                {
                    if (Convert.ToInt32(node.Attributes["id"].Value) == CodigoRegistro)
                    {
                        objModelMensagensPadrao = new ModelMensagensPadrao();

                        objModelMensagensPadrao.Descricao = node.Attributes["descricao"].Value;
                        objModelMensagensPadrao.Titulo = node.Attributes["titulo"].Value;
                        objModelMensagensPadrao.Ativo = Convert.ToBoolean(node.Attributes["ativo"].Value);
                        objModelMensagensPadrao.Id = Convert.ToInt32(CodigoRegistro);
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            return objModelMensagensPadrao;
        }
        #endregion
    }
}
