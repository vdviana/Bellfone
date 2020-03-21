using System;
using System.Collections.Generic;
using System.Text;
using VM2.Framework.Model.Usuario;

namespace VM2.Framework.DataLayer.Usuario
{

    /// <summary>
    ///     Interface com os metodos relacionados as operacoes realizadas com a base de dados
    /// </summary>
    /// <user>mazevedo</user>
    public interface IDLFuncionalidade
    {
        List<MLFuncionalidade> Listar(MLFuncionalidade pobjMLFuncionalidade);
        MLFuncionalidade Obter(decimal pdecCodigo);
        bool Excluir(decimal pdecCodigo);
        bool Alterar(MLFuncionalidade pobjMLFuncionalidade);
        int Inserir(MLFuncionalidade pobjMLFuncionalidade);
    }
}
