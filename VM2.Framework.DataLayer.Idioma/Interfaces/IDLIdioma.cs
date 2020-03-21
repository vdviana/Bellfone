using System;
using System.Collections.Generic;
using System.Text;
using VM2.Framework.Model.Idioma;

namespace VM2.Framework.DataLayer.Idioma
{

    /// <summary>
    ///     Interface com os metodos relacionados as operacoes realizadas com a base de dados
    /// </summary>
    /// <user>mazevedo</user>
    public interface IDLIdioma
    {

        List<MLIdioma> Listar(MLIdioma pobjMLIdioma);
        MLIdioma Obter(decimal pdecCodigo);
        bool Excluir(decimal pdecCodigo);
        bool Alterar(MLIdioma pobjMLIdioma);
        int Inserir(MLIdioma pobjMLIdioma);

    }
}
