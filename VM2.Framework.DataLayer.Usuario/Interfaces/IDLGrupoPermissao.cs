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
    public interface IDLGrupoPermissao
    {

        List<MLGrupoPermissao> Listar(MLGrupoPermissao pobjParametro);
        MLGrupoPermissao Obter(decimal pdecCodigoGrupo, decimal pdecCodigoFuncionalidade);
        bool Excluir(decimal pdecCodigoGrupo, decimal pdecCodigoFuncionalidade);
        bool ExcluirTodos(decimal pdecCodigoFuncionalidade);
        bool Alterar(MLGrupoPermissao pobjPermissao);
        bool Inserir(MLGrupoPermissao pobjPermissao);

    }
}
