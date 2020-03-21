using System;
using System.Collections.Generic;

using System.Text;

namespace Framework.AtendimentoOnline.Model.Exceptions
{
    public class GUIDAtendimentoInvalido : Exception
    {
        public GUIDAtendimentoInvalido(string pstrMessage, Exception pobjInnerException)
            : base(pstrMessage,  pobjInnerException)
        {

        }
    }
}
