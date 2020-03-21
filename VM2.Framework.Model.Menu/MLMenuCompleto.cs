using System;
using System.Collections.Generic;

namespace VM2.Framework.Model.Menu
{
    /// <summary>
    ///     Model que extende a model de Menu e contempla as listas
    /// </summary>
    /// <user>mazevedo</user>
    [Serializable]
    public class MLMenuCompleto : MLMenu
    {
        /// <summary>
        ///     Construtor da classe, inicializa as variáveis
        /// </summary>
        /// <user>mazevedo</user>
        public MLMenuCompleto()
        {
            if (ItensMenu == null) ItensMenu = new List<MLMenuItem>();
        }

        #region Propriedades

        /// <summary>
        ///     Itens do Menu
        /// </summary>
        /// <user>mazevedo</user>
        public List<MLMenuItem> ItensMenu { get; set;}

        #endregion
    }
}
