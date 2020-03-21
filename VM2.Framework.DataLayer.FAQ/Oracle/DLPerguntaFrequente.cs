using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

using VM2.Framework.Model.FAQ;

namespace VM2.Framework.DataLayer.FAQ.Oracle
{
    /// <summary> 
    /// Classe de conexão de dados para PerguntaFrequente 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLPerguntaFrequente : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2</user> 
        public DLPerguntaFrequente()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }



        #region Alterar

        public bool Alterar(MLPerguntaFrequenteCategoria pobjMLPerguntaFrequenteCategoria)
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
        public int Inserir(MLPerguntaFrequenteCategoria pobjMLPerguntaFrequenteCategoria)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region Listar
        public List<MLPerguntaFrequenteCategoria> Listar(MLPerguntaFrequenteCategoria pobjMLPerguntaFrequenteCategoria)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region Obter
        public MLPerguntaFrequenteCategoria Obter(decimal pdecCodigo)
        {
            throw new NotImplementedException();
        }
        # endregion

       
    }
}


