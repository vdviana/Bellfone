using System;
using VM2.Framework.Model.Enquete;
namespace VM2.Framework.DataLayer.Enquete.Sql
{
 public   interface IDLEnquete
    {
        bool Alterar(MLEnquete pobjMLEnquete);
        bool Excluir(decimal pdecCodigo);
        int Inserir(MLEnquete pobjMLEnquete);
        System.Collections.Generic.List<MLEnquete> Listar(MLEnquete pobjMLEnquete);
        MLEnquete Obter(decimal pdecCodigo);
    }
}
