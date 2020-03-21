using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using VM2.Framework.Model;
using VM2.Framework.Model.Noticia;

namespace VM2.Framework.DataLayer.Noticia.Oracle
{
    /// <summary> 
    /// Classe de conexão de dados para Noticia 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLNoticia : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2</user> 
        public DLNoticia()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }



        #region Alterar

        public bool Alterar(MLNoticiaCategoria pobjMLNoticiaCategoria)
        {
            throw new NotImplementedException();
        }
        #endregion

        # region Excluir
        public bool Excluir(decimal pdecCodigo)
        {
            throw new NotImplementedException();
        }
        # endregion

        #region Inserir
        public int Inserir(MLNoticiaCategoria pobjMLNoticiaCategoria)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region Listar
        public List<MLNoticiaCategoria> Listar(MLNoticiaCategoria pobjMLNoticiaCategoria)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region Obter
        public MLNoticiaCategoria Obter(decimal pdecCodigo)
        {
            throw new NotImplementedException();
        }
        # endregion
    }
}


