using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

using VM2.Framework.Model.Enquete;
using VM2.Framework.Model;

namespace VM2.Framework.DataLayer.Enquete.Oracle
{
    /// <summary> 
    /// Classe de conexão de dados para PerguntaFrequente 
    /// </summary> 
    /// <user>GeradorVm2</user> 
    public class DLEnqueteOpcao : DLFWBase
    {
        /// <summary> 
        /// Construtor, inicializa as variáveis de conexão 
        /// </summary> 
        /// <user>GeradorVm2</user> 
        public DLEnqueteOpcao()
        {
            strConnection = ConfigurationManager.AppSettings["VM2.Provider.ConnectionString"].ToString();
            conProvider = new DLProvider(strConnection);
            intCommandTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["VM2.Provider.CommandTimeOut"].ToString());
        }



        #region Alterar

        public bool Alterar(MLEnqueteOpcao pobjMLPerguntaFrequenteCategoria)
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
        public int Inserir(MLEnqueteOpcao pobjMLPerguntaFrequenteCategoria)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region Listar
        public List<MLEnqueteOpcao> Listar(MLEnqueteOpcao pobjOpcaoEnquete)
        {
            throw new NotImplementedException();
        }
        # endregion

        # region Obter
        public MLEnqueteOpcao Obter(decimal pdecCodigo)
        {
            throw new NotImplementedException();
        }
        # endregion


    }
}


