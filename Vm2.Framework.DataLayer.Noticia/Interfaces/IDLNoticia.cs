using System;
using VM2.Framework.Model.Noticia;
namespace VM2.Framework.DataLayer.Noticia
{
   public interface IDLNoticia
    {
        bool Alterar(MLNoticia pobjMLNoticia);
        bool Excluir(decimal pdecCodigo);
        int Inserir(MLNoticia pobjMLNoticia);
        System.Collections.Generic.List<MLNoticia> Listar(MLNoticia pobjMLNoticia);
        MLNoticia Obter(decimal pdecCodigo);
    }
}
