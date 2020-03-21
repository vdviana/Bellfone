using System;
using VM2.Framework.Model.FAQ;

namespace VM2.Framework.DataLayer.FAQ
{
  public  interface IDLPerguntaFrequente
    {
        bool Alterar(MLPerguntaFrequente pobjMLPerguntaFrequente);
        bool Excluir(decimal pdecCodigo);
        int Inserir(MLPerguntaFrequente pobjMLPerguntaFrequente);
        System.Collections.Generic.List<MLPerguntaFrequente> Listar(MLPerguntaFrequente pobjMLPerguntaFrequente);
        MLPerguntaFrequente Obter(decimal pdecCodigo);
    }
}
