using System;
using System.Collections.Generic;

namespace VM2.Framework.Model.Usuario
{

    /// <summary>
    ///     Classe complementar do usuario
    /// </summary>
    /// <user>mazevedo</user>
    public class MLUsuarioGrupo : MLUsuario
    {
        /// <summary>
        ///     Construtor Inicializa as Variáveis
        /// </summary>
        /// <user>mazevedo</user>
        public MLUsuarioGrupo()
        {
            ListaGrupo = new List<decimal>();
            ListaPaginasAcesso = new List<string>();
            ListaPermissoes = new List<MLFuncionalidadeGrupo>();
        }

        #region Propriedades

        /// <summary>
        ///     Lista de grupos do usuário
        /// </summary>
        /// <user>mazevedo</user>
        public List<decimal> ListaGrupo { get; set; }

        /// <summary>
        ///     Lista de páginas do usuário
        /// </summary>
        /// <user>mazevedo</user>
        public List<string> ListaPaginasAcesso { get; set; }

        /// <summary>
        ///     Lista de permissões do usuário
        /// </summary>
        /// <user>mazevedo</user>
        public List<MLFuncionalidadeGrupo> ListaPermissoes { get; set; }

        #endregion

        #region Conversores Lista

        /// <summary>
        ///     Converte a string concatenada em decimais
        /// </summary>
        /// <param name="pstrCodigo">Lista de codigos</param>
        /// <returns>Lista de codigos convertida</returns>
        /// <user>mazevedo</user>
        public void ListaGrupoFromString(string pstrCodigo)
        {

            var strArrayCodigo = pstrCodigo.Split(Convert.ToChar(","));

            for (var intContador = 0; intContador < strArrayCodigo.Length; intContador++)
            {
                if (!string.IsNullOrEmpty(strArrayCodigo[intContador]))
                    ListaGrupo.Add(Convert.ToDecimal(strArrayCodigo[intContador]));
            }

        }

        /// <summary>
        ///     Converte a string concatenada
        /// </summary>
        /// <param name="pstrCodigo">Lista de codigos</param>
        /// <returns>Lista de codigos convertida</returns>
        /// <user>mazevedo</user>
        public void ListaPaginaFromString(string pstrCodigo)
        {

            var strArrayCodigo = pstrCodigo.Split(Convert.ToChar(","));

            for (var intContador = 0; intContador < strArrayCodigo.Length; intContador++)
            {
                if (!string.IsNullOrEmpty(strArrayCodigo[intContador]))
                    ListaPaginasAcesso.Add(strArrayCodigo[intContador]);
            }

        }

        #endregion
    }
}
