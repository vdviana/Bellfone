using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

using VM2.Framework.Model.Enquete;

namespace VM2.Framework.DataLayer.Enquete.Oracle
{
    /// <summary> 
    /// Classe de conexão de dados para PerguntaFrequente 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLEnquete : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2</user> 
        public DLEnquete()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }



        #region Alterar

        public bool Alterar(MLEnquete pobjMLPerguntaFrequenteCategoria)
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
        public int Inserir(MLEnquete pobjMLPerguntaFrequenteCategoria)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region Listar
        public List<MLEnquete> Listar(MLEnquete pobjEnquete)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region Obter
        public MLEnquete Obter(decimal pdecCodigo)
        {
            throw new NotImplementedException();
        }
        # endregion

       
    }
}


