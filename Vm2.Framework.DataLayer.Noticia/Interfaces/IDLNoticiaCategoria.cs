using System;
using System.Collections.Generic;
using System.Text;
using VM2.Framework.Model.Noticia;

namespace VM2.Framework.DataLayer.Noticia
{

    /// <summary>
    ///     Interface com os metodos relacionados as operacoes realizadas com a base de dados
    /// </summary>
    /// <user>mazevedo</user>
    public interface IDLNoticiaCategoria
    {

        List<MLNoticiaCategoria> Listar(MLNoticiaCategoria pobjMLNoticiaCategoria);
        MLNoticiaCategoria Obter(decimal pdecCodigo);
        bool Excluir(decimal pdecCodigo);
        bool Alterar(MLNoticiaCategoria pobjMLNoticiaCategoria);
        int Inserir(MLNoticiaCategoria pobjMLNoticiaCategoria);
  
    }
}
