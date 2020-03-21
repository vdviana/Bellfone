using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using VM2.Framework.Model.FAQ;

namespace VM2.Framework.DataLayer.FAQ.Oracle
{
    public class DLPerguntaFrequenteCategoria : DLFWBase, IDLPerguntaFrequenteCategoria
    {

        public DLPerguntaFrequenteCategoria()
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
