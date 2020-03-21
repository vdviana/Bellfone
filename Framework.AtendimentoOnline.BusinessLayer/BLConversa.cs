using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Web;
using Framework.AtendimentoOnline.DataLayer;
using Framework.AtendimentoOnline.Model;
using Framework.AtendimentoOnline.Model.Exceptions;

namespace Framework.AtendimentoOnline.BusinessLayer
{
    /// <summary>
    /// Classe para manipulação da conversa.
    /// </summary>
    /// <author>vnarcizo</author>
    /// <createdDate>28/01/2009</createdDate>
    public class BLConversa
    {
        #region Atributos Estáticos

        private static string pstrCaminhoXMLConversas;
        
        #endregion

        #region Atributos

        private string strGUIDConversa;
        private string strCaminhoFisicoConversa;

        #endregion

        #region Construtor
        /// <summary>
        /// Contrutor
        /// </summary>
        /// <param name="pstrGUIDConversa"></param>
        /// <param name="nomeUsuario"></param>
        /// <param name="data"></param>
        /// <user>vnarcizo</user>
        public BLConversa(string pstrGUIDConversa,string nomeUsuario,DateTime data)
        { 
            strGUIDConversa = pstrGUIDConversa;

            if (nomeUsuario.EndsWith("."))
            {
                nomeUsuario = nomeUsuario.Remove(nomeUsuario.Length - 1);
            }            

            strCaminhoFisicoConversa = HttpContext.Current.Request.MapPath(CaminhoXMLConversas + nomeUsuario + "//" + data.ToString("yyyy-MM-dd") + "//" + strGUIDConversa);
        }
        #endregion

        #region Métodos

        #region Inserir Mensagem

        /// <summary>
        /// Inserir uma nova mensagem na conversa.
        /// </summary>
        /// <param name="pobjMensagem">Mensagem a ser adicionada</param>
        /// <returns>Model Conversa com mensagens atualizadas.</returns>
        /// <author>vnarcizo</author>
        /// <createdDate>28/01/2009</createdDate>
        public ModelConversa InserirMensagem(ModelMensagem pobjMensagem)
        {

            //Instancia a conversa para inserir uma nova mensagem
            DALConversa objDALConversa = new DALConversa(strCaminhoFisicoConversa);            
            objDALConversa.InserirMensagem(pobjMensagem);

            ModelConversa objModelConversa =  objDALConversa.ListarMensagens();

            return objModelConversa;

        }
        #endregion

        #region Listar  Mensagens
            
        /// <summary>
        /// Listar Mensagens da conversa
        /// </summary>
        /// <returns>Model com os dados da conversa e suas mensagens.</returns>
        /// <author>vnarcizo</author>
        /// <createdDate>28/01/2009</createdDate>
        public ModelConversa ListarMensagens()
        {
            var objDALConversa = new DALConversa(strCaminhoFisicoConversa);
            return objDALConversa.ListarMensagens();
        }

        #endregion

        #endregion

        #region Propriedades Estáticas

        /// <summary>
        /// Caminho dos XML do atendimento online.
        /// </summary>
        public static string CaminhoXMLConversas
        {
            get 
            {
                if (string.IsNullOrEmpty(pstrCaminhoXMLConversas))
                {
                    try
                    {
                        pstrCaminhoXMLConversas = ConfigurationManager.AppSettings["VM2.Framework.AtendimentoOnline.CaminhoXMLConversas"];
                    }
                    catch (Exception ex)
                    {
                        throw new ConfiguracaoNaoDefinida(ex, "A chave VM2.Framework.AtendimentoOnline.CaminhoXMLConversas não foi definida.");
                    }
                }
                return BLConversa.pstrCaminhoXMLConversas; 
            }            
        }

        

        

        public ModelConversa BuscarInicioConversa()
        {
            
            try
            {   
                return ListarMensagens();
            }
            catch (FileNotFoundException ex)
            {
                throw new ArquivoConversaNaoCriadoAguarde("Arquivo de conversa não criada neste instante.", ex);
            }
            
        }

        #endregion

        #region Atendimentos Correntes

        /// <summary>
        /// Busca atendimento de um determinado atendente.
        /// </summary>
        /// <param name="pintIdAtendente">Código do atendente.</param>
        /// <returns>Atendimento do Atendente</returns>
        /// <author>vnarcizo</author>
        /// <createdDate>06/01/2009</createdDate>
        public Collection<ModelConversa> Atendimentos(int pintIdAtendente)
        {
            if (HttpContext.Current.Cache["ssFWAtendimentos" + pintIdAtendente] == null)
            {
                HttpContext.Current.Cache["ssFWAtendimentos" + pintIdAtendente] = new Collection<ModelConversa>();
            }

            return HttpContext.Current.Cache["ssFWAtendimentos" + pintIdAtendente] as Collection<ModelConversa>;
        }


        #endregion
    }
}
