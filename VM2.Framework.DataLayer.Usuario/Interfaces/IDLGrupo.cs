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
    public interface IDLGrupo
    {

        List<MLGrupo> Listar(MLGrupo pobjGrupo);
        MLGrupo Obter(decimal pdecCodigo);
        bool Excluir(decimal pdecCodigo);
        bool Alterar(MLGrupo pobjMLGrupo);
        int Inserir(MLGrupo pobjMLGrupo);

    }

}
