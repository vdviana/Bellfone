using System;
using System.Collections.Generic;
using System.Text;
using VM2.Framework.Model.Noticia;
using System.Configuration;
using VM2.Framework.DataLayer.Noticia;

namespace VM2.Framework.DataLayer.Noticia.Oracle
{
    public class DLNoticiaCategoria :DLFWBase, IDLNoticiaCategoria
    {

        public DLNoticiaCategoria()
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
