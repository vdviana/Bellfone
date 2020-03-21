using System;
using System.Collections.Generic;
using System.Text;
using VM2.Framework.Model.Utilitarios;

namespace VM2.Framework.DataLayer.Utilitarios
{
    public interface IDLConfiguracao
    {
        List<MLConfiguracao> Listar(MLConfiguracao pobjMLConfiguracao);
        MLConfiguracao Obter(string pstrChave);
        bool Alterar(MLConfiguracao pobjMLConfiguracao);
    }
}
