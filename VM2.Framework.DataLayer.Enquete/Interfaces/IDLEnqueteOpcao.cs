using System;
using VM2.Framework.Model;
using VM2.Framework.Model.Enquete;
namespace VM2.Framework.DataLayer.Enquete
{
   public interface IDLEnqueteOpcao
    {
        bool Alterar(MLEnqueteOpcao pobjMLEnqueteOpcao);
        bool Excluir(decimal pdecCodigo);
        int Inserir(MLEnqueteOpcao pobjMLEnqueteOpcao);
        System.Collections.Generic.List<MLEnqueteOpcao> Listar(MLEnqueteOpcao pobjMLEnqueteOpcao, decimal regAtual);
       MLEnqueteOpcao Obter(decimal pdecCodigo);
    }
}
