using System;
using System.Collections.Generic;
using System.Text;
using VM2.Framework.Model.Menu;

namespace VM2.Framework.DataLayer.Menu
{

    /// <summary>
    ///     Interface com os metodos relacionados as operacoes realizadas com a base de dados
    /// </summary>
    /// <user>mazevedo</user>
    public interface IDLMenu
    {

        List<MLMenu> Listar(MLMenu pobjMLMenu);
        MLMenu Obter(decimal pdecCodigo);
        MLMenuCompleto ObterCompleto(decimal pdecCodigo, decimal pdecCodigoIdioma, bool? pblStatus);

    }
}
