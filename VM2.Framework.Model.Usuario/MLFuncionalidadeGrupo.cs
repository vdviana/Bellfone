
namespace VM2.Framework.Model.Usuario
{
    /// <summary>
    ///     Classe que complementa a classe de funcionalidade
    /// </summary>
    /// <user>mazevedo</user>
    public class MLFuncionalidadeGrupo : MLFuncionalidade
    {
        /// <summary>
        ///     Consturtor inicializa as variáveis
        /// </summary>
        /// <user>mazevedo</user>
        public MLFuncionalidadeGrupo()
        {
            GrupoPermissao = new MLGrupoPermissao();
        }

        #region Propriedades

        /// <summary>
        ///     Armazena as permissoes do usuario dentro da funcionalidade
        /// </summary>
        /// <user>mazevedo</user>
        public MLGrupoPermissao GrupoPermissao { get; set;}

        #endregion
    }
}
