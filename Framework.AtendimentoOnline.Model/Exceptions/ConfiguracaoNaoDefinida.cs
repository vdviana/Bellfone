using System;
using System.Collections.Generic;

using System.Text;

namespace Framework.AtendimentoOnline.Model.Exceptions
{
    public class ConfiguracaoNaoDefinida : Exception
    {
        public ConfiguracaoNaoDefinida(Exception pobjInnerException, string pstrMessage) 
            : base(pstrMessage,pobjInnerException)
        {

        }
    }
}
