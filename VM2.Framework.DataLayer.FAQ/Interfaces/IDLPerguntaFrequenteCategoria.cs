using System;
using VM2.Framework.Model.FAQ;
namespace VM2.Framework.DataLayer.FAQ
{
   public interface IDLPerguntaFrequenteCategoria
    {
        bool Alterar(MLPerguntaFrequenteCategoria pobjMLPerguntaFrequenteCategoria);
        bool Excluir(decimal pdecCodigo);
        int Inserir(MLPerguntaFrequenteCategoria pobjMLPerguntaFrequenteCategoria);
        System.Collections.Generic.List<MLPerguntaFrequenteCategoria> Listar(MLPerguntaFrequenteCategoria pobjMLPerguntaFrequenteCategoria);
        MLPerguntaFrequenteCategoria Obter(decimal pdecCodigo);
    }
}
