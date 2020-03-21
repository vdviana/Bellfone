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
    public class DALAtendente
    {

        #region Listar
        /// <summary>
        ///  Lista todos os atendentes cadastrados
        /// </summary>
        /// <returns>Lista de Atendentes</returns>
        /// <user>vnarcizo</user>
        public List<ModelAtendente> Listar()
        {
            ModelAtendente objMLAssunto;
            List<ModelAtendente> lstAssunto = new List<ModelAtendente>();
            FileStream fs = null;
            string caminho = ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.CaminhoXMLAtendente"].ToString();

            try
            {
                fs = new FileStream(caminho, FileMode.Open, FileAccess.Read);

                XmlDocument xdcDocument = new XmlDocument();
                xdcDocument.Load(fs);

                XmlNodeList xndNodes = xdcDocument.SelectNodes("atendenteSistema/Atendente");

                foreach (XmlNode xndAssunto in xndNodes)
                {
                    objMLAssunto = new ModelAtendente();
                    
                    int intId;
                    bool blnAtivo;

                    int.TryParse(xndAssunto.Attributes["id"].Value, out intId);
                    objMLAssunto.Id = intId;
                    
                    objMLAssunto.Nome = xndAssunto.Attributes["nome"].Value;

                    objMLAssunto.Login = xndAssunto.Attributes["login"].Value;

                    objMLAssunto.Senha = xndAssunto.Attributes["senha"].Value;

                    objMLAssunto.CodVendedor = xndAssunto.Attributes["codVendedor"].Value;

                    //Adicionando na lista
                    lstAssunto.Add(objMLAssunto);
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
        /// Insere um novo atendente no xml de atendentes
        /// </summary>
        /// <param name="objModelAtendente">Model Atendente</param>
        /// <returns>Status da inserção</returns>
        /// <user>vnarcizo</user>
        public bool Inserir(ModelAtendente objModelAtendente)
        {
            var retorno = false;           
            
            var caminho = ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.CaminhoXMLAtendente"].ToString();
            var fs = new FileStream(caminho, FileMode.Open, FileAccess.ReadWrite);

            try
            {
                var xdcDocument = new XmlDocument();
                xdcDocument.Load(fs);

                var xndNodeAtendente = xdcDocument.SelectSingleNode("atendenteSistema");
                var xndNovoAtendente = xdcDocument.CreateElement("Atendente");
                var xmaIdAtendente = xdcDocument.CreateAttribute("id");
                var xmaNome = xdcDocument.CreateAttribute("nome");
                var xmaLogin = xdcDocument.CreateAttribute("login");
                var xmaSenha = xdcDocument.CreateAttribute("senha");
                var xmaVendedor = xdcDocument.CreateAttribute("codVendedor");

                var ultimoNo = xndNodeAtendente.ChildNodes[xndNodeAtendente.ChildNodes.Count - 1];

                xmaIdAtendente.Value = objModelAtendente.Id.ToString();
                xmaNome.Value = objModelAtendente.Nome;
                xmaLogin.Value = objModelAtendente.Login;
                xmaSenha.Value = objModelAtendente.Senha;
                xmaVendedor.Value = objModelAtendente.CodVendedor.ToString();

                xndNovoAtendente.Attributes.Append(xmaIdAtendente);
                xndNovoAtendente.Attributes.Append(xmaNome);
                xndNovoAtendente.Attributes.Append(xmaLogin);
                xndNovoAtendente.Attributes.Append(xmaSenha);
                xndNovoAtendente.Attributes.Append(xmaVendedor);

                xndNodeAtendente.AppendChild(xndNovoAtendente);


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
        /// Altera um atendente
        /// </summary>
        /// <param name="objModelAtendente">Model Atendente</param>
        /// <returns>Status do atendimento</returns>
        /// <user>vnarcizo</user>
        public bool Alterar(ModelAtendente objModelAtendente)
        {
            bool retorno = false;
            string caminho = ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.CaminhoXMLAtendente"].ToString();

            File.SetAttributes(caminho, FileAttributes.Normal);
            var fs = new FileStream(caminho, FileMode.Open, FileAccess.ReadWrite);

            try
            {
                var xdcDocument = new XmlDocument();
                xdcDocument.Load(fs);

                var xndNodeAssunto = xdcDocument.SelectSingleNode("atendenteSistema");

                foreach (XmlNode node in xndNodeAssunto.ChildNodes)
                {
                    if (Convert.ToInt32(node.Attributes["id"].Value) == objModelAtendente.Id)
                    {
                        node.Attributes["nome"].Value = objModelAtendente.Nome;
                        node.Attributes["login"].Value = objModelAtendente.Login;
                        node.Attributes["codVendedor"].Value = objModelAtendente.CodVendedor.ToString();
                        
                        if (!string.IsNullOrEmpty(objModelAtendente.Senha))
                            node.Attributes["senha"].Value = objModelAtendente.Senha;

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
        /// Obter atendente
        /// </summary>
        /// <param name="CodigoRegistro">Codigo do atendente</param>
        /// <returns>Model atendente</returns>
        /// <user>vnarcizo</user>
        public ModelAtendente Obter(decimal? CodigoRegistro)
        {
            ModelAtendente objModelAtendente = null;
            string caminho = ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.CaminhoXMLAtendente"].ToString();

            File.SetAttributes(caminho, FileAttributes.Normal);
            var fs = new FileStream(caminho, FileMode.Open, FileAccess.ReadWrite);

            try
            {
                var xdcDocument = new XmlDocument();
                xdcDocument.Load(fs);

                var xndNodeAssunto = xdcDocument.SelectSingleNode("atendenteSistema");

                foreach (XmlNode node in xndNodeAssunto.ChildNodes)
                {
                    if (Convert.ToInt32(node.Attributes["id"].Value) == CodigoRegistro)
                    {
                        objModelAtendente = new ModelAtendente();

                        objModelAtendente.Nome = node.Attributes["nome"].Value;
                        objModelAtendente.Login = node.Attributes["login"].Value;
                        objModelAtendente.CodVendedor =node.Attributes["codVendedor"].Value;
                        objModelAtendente.Id = Convert.ToInt32(CodigoRegistro);
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

            return objModelAtendente;
        }
        #endregion
    }
}
