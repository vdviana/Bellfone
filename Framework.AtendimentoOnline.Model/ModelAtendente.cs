using System;

namespace Framework.AtendimentoOnline.Model
{
    [Serializable]
    public class ModelAtendente
    {
        #region Propriedades

        /// <user>vnarcizo</user>
        public int Id {get;set;}

        /// <user>vnarcizo</user>
        public string Nome { get; set; }

        /// <user>vnarcizo</user>
        public string Login { get; set; }

        /// <user>vnarcizo</user>
        public string Senha { get; set; }

        /// <user>lmascarenhas</user>
        public string CodVendedor { get; set; }

        /// <user>mazevedo</user>
        public bool IsVendedor{
                get { return !string.IsNullOrEmpty(CodVendedor); }
        }

        #endregion
    }
}
