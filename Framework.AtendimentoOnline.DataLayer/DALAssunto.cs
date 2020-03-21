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
    public class DALAssunto
    {

        #region Listar
        /// <summary>
        /// Lista todos
        /// </summary>
        /// <param name="blnAtivo">Status do ou não do Assunto</param>
        /// <param name="blnVenda">Indicador de Assuntos restritos a vendas</param>
        /// <returns>Lista de assunstos</returns>
        /// <user>vnacizo</user>
        public List<ModelAssunto> Listar(bool? blnAtivo, bool? blnVenda)
        {
            ModelAssunto objMLAssunto;
            List<ModelAssunto> lstAssunto = new List<ModelAssunto>();
            FileStream fs = null;
            string caminho = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.CaminhoXMLAssunto"].ToString());

            try
            {
                fs = new FileStream(caminho, FileMode.Open, FileAccess.Read);

                XmlDocument xdcDocument = new XmlDocument();
                xdcDocument.Load(fs);

                XmlNodeList xndNodes = xdcDocument.SelectNodes("assuntoSistema/assunto");

                foreach (XmlNode xndAssunto in xndNodes)
                {
                    int intId;
                    bool pblnAtivo;
                    bool pblnVendas;
                    
                    bool.TryParse(xndAssunto.Attributes["ativo"].Value, out pblnAtivo);
                    bool.TryParse(xndAssunto.Attributes["vendas"].Value, out pblnVendas);

                    if ((blnAtivo == null || blnAtivo.Value == pblnAtivo) && (blnVenda == null || blnVenda == pblnVendas))
                    {
                        objMLAssunto = new ModelAssunto();

                        int.TryParse(xndAssunto.Attributes["id"].Value, out intId);
                        objMLAssunto.Id = intId;

                        objMLAssunto.Descricao = xndAssunto.Attributes["descricao"].Value;

                        objMLAssunto.Ativo = pblnAtivo;
                        objMLAssunto.Vendas = pblnVendas;

                        //Adicionando na lista
                        lstAssunto.Add(objMLAssunto);
                    }
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

        #region Inserir
        /// <summary>
        /// Insere novos assuntos no xml
        /// </summary>
        /// <param name="objMLAssunto">Model a ser inserida</param>
        /// <returns>Status da inserção</returns>
        /// <user>vnarcizo</user>
        public bool Inserir(ModelAssunto objMLAssunto)
        {
            bool retorno = false;
            string caminho = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.CaminhoXMLAssunto"].ToString());
            FileStream fs = new FileStream(caminho, FileMode.Open, FileAccess.ReadWrite);

            try
            {
                XmlDocument xdcDocument = new XmlDocument();
                xdcDocument.Load(fs);

                XmlNode xndNodeAssunto = xdcDocument.SelectSingleNode("assuntoSistema");
                XmlNode xndNovoAssunto = xdcDocument.CreateElement("assunto");
                XmlAttribute xmaIdAssunto = xdcDocument.CreateAttribute("id");
                XmlAttribute xmaDescricao = xdcDocument.CreateAttribute("descricao");
                XmlAttribute xmaAtivo = xdcDocument.CreateAttribute("ativo");
                XmlAttribute xmaVendas = xdcDocument.CreateAttribute("vendas");

                XmlNode ultimoNo = xndNodeAssunto.ChildNodes[xndNodeAssunto.ChildNodes.Count - 1];

                xmaIdAssunto.Value = (Convert.ToInt32(ultimoNo.Attributes["id"].Value) + 1).ToString();
                xmaDescricao.Value = objMLAssunto.Descricao;
                xmaAtivo.Value = objMLAssunto.Ativo.ToString();
                xmaVendas.Value = objMLAssunto.Vendas.ToString();

                xndNovoAssunto.Attributes.Append(xmaIdAssunto);
                xndNovoAssunto.Attributes.Append(xmaDescricao);
                xndNovoAssunto.Attributes.Append(xmaAtivo);
                xndNovoAssunto.Attributes.Append(xmaVendas);

                xndNodeAssunto.AppendChild(xndNovoAssunto);


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

        #region Alterar
        /// <summary>
        /// Altera os dados de um determinado assunto
        /// </summary>
        /// <param name="objModelAssunto">Assunto a ser inserido</param>
        /// <returns>Status do Assunto</returns>
        /// <user>vnarcizo</user>
        public bool Alterar(ModelAssunto objModelAssunto)
        {
            bool retorno = false;
            string caminho = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.CaminhoXMLAssunto"].ToString());

            File.SetAttributes(caminho, FileAttributes.Normal);
            var fs = new FileStream(caminho, FileMode.Open, FileAccess.ReadWrite);

            try
            {
                var xdcDocument = new XmlDocument();
                xdcDocument.Load(fs);

                var xndNodeAssunto = xdcDocument.SelectSingleNode("assuntoSistema");

                foreach (XmlNode node in xndNodeAssunto.ChildNodes)
                {
                    if (Convert.ToInt32(node.Attributes["id"].Value) == objModelAssunto.Id)
                    {
                        node.Attributes["descricao"].Value = objModelAssunto.Descricao;
                        node.Attributes["ativo"].Value = objModelAssunto.Ativo.ToString();
                        node.Attributes["vendas"].Value = objModelAssunto.Vendas.ToString();
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
        /// Obter Assunto de um determinado codigo
        /// </summary>
        /// <param name="CodigoRegistro">Codigo do assunto</param>
        /// <returns>ModelAssunto</returns>
        /// <user>vnarcizo</user>
        public ModelAssunto Obter(decimal? CodigoRegistro)
        {
            ModelAssunto objModelAssunto = null;
            string caminho = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.CaminhoXMLAssunto"].ToString());

            File.SetAttributes(caminho, FileAttributes.Normal);
            var fs = new FileStream(caminho, FileMode.Open, FileAccess.ReadWrite);

            try
            {
                var xdcDocument = new XmlDocument();
                xdcDocument.Load(fs);

                var xndNodeAssunto = xdcDocument.SelectSingleNode("assuntoSistema");

                foreach (XmlNode node in xndNodeAssunto.ChildNodes)
                {
                    if (Convert.ToInt32(node.Attributes["id"].Value) == CodigoRegistro)
                    {
                        objModelAssunto = new ModelAssunto();

                        objModelAssunto.Descricao = node.Attributes["descricao"].Value;
                        objModelAssunto.Ativo = Convert.ToBoolean(node.Attributes["ativo"].Value);
                        objModelAssunto.Vendas = Convert.ToBoolean(node.Attributes["vendas"].Value);
                        objModelAssunto.Id = Convert.ToInt32(CodigoRegistro);
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

            return objModelAssunto;
        }
        #endregion

    }
}
