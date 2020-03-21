using System;
using System.Collections.Generic;

using System.Text;

namespace Framework.AtendimentoOnline.Model.Exceptions
{
    public class ArquivoConversaNaoCriadoAguarde : Exception
    {
        public ArquivoConversaNaoCriadoAguarde(string pstrMessage, Exception pobjInnerException)
            : base(pstrMessage, pobjInnerException)
        {

        }
    }
}
