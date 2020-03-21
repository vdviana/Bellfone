using System;
using VM2.Framework.Model.Arquivo;
namespace VM2.Framework.DataLayer.Arquivo
{
   public interface IDLArquivo
    {
        bool Alterar(MLArquivo pobjMLArquivo);
        bool Excluir(decimal pdecCodigo);
        int Inserir(MLArquivo pobjMLArquivo);
        System.Collections.Generic.List<MLArquivo> Listar(MLArquivo pobjMLArquivo);
        MLArquivo Obter(decimal pdecCodigo);
    }
}
