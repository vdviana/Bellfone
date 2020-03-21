using System;
using VM2.Framework.Model.Arquivo;
namespace VM2.Framework.DataLayer.Arquivo
{
    public interface IDLCategoriaArquivo
    {
        bool Alterar(MLCategoriaArquivo pobjMLCategoriaArquivo);
        bool Excluir(decimal pdecCodigo);
        int Inserir(MLCategoriaArquivo pobjMLCategoriaArquivo);
        System.Collections.Generic.List<MLCategoriaArquivo> Listar(MLCategoriaArquivo pobjMLCategoriaArquivo);
        MLCategoriaArquivo Obter(decimal pdecCodigo);
    }
}
