using System;
using System.Data;

namespace VM2.Framework.Model.Usuario
{

    /// <summary>
    ///     Classe de transporte para grupo permissao
    /// </summary>
    /// <user>mazevedo</user>
    [Serializable]
    public class MLGrupoPermissao
    {

        #region Propriedades

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Recebe o valor de GPE_GRP_N_CODIGO 
        /// </summary> 
        /// <value>decimal</value> 
        /// <history> 
        /// [mazevedo] 20/08/2008 Created 
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public decimal CodigoGrupo { get; set; }

        /// <summary>
        ///     Nome da Funcionalidade
        /// </summary>
        /// <user>mazevedo</user>
        public string NomeFuncionalidade { get; set; }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Recebe o valor de GPE_FUN_N_CODIGO 
        /// </summary> 
        /// <value>decimal</value> 
        /// <history> 
        /// [mazevedo] 20/08/2008 Created 
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public decimal CodigoFuncionalidade { get; set; }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Recebe o valor de GPE_B_ALTERAR 
        /// </summary> 
        /// <value>bool</value> 
        /// <history> 
        /// [mazevedo] 20/08/2008 Created 
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public bool? IsPermissaoAlterar { get; set; }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Recebe o valor de GPE_B_INCLUIR 
        /// </summary> 
        /// <value>bool</value> 
        /// <history> 
        /// [mazevedo] 20/08/2008 Created 
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public bool? IsPermissaoIncluir { get; set; }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Recebe o valor de GPE_B_EXCLUIR 
        /// </summary> 
        /// <value>bool</value> 
        /// <history> 
        /// [mazevedo] 20/08/2008 Created 
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public bool? IsPermissaoExcluir { get; set; }

        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Recebe o valor de GPE_B_LISTAR 
        /// </summary> 
        /// <value>bool</value> 
        /// <history> 
        /// [mazevedo] 20/08/2008 Created 
        /// </history>
        /// ----------------------------------------------------------------------------- 
        public bool? IsPermissaoListar { get; set; }

        #endregion

        #region Collections DataReader

        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {

            if (pobjIDataReader["GPE_GRP_N_CODIGO"] != DBNull.Value)
                CodigoGrupo = Convert.ToDecimal(pobjIDataReader["GPE_GRP_N_CODIGO"]);

            if (pobjIDataReader["GPE_FUN_N_CODIGO"] != DBNull.Value)
                CodigoFuncionalidade = Convert.ToDecimal(pobjIDataReader["GPE_FUN_N_CODIGO"]);

            if (pobjIDataReader["GPE_B_ALTERAR"] != DBNull.Value)
                IsPermissaoAlterar = Convert.ToBoolean(pobjIDataReader["GPE_B_ALTERAR"]);

            if (pobjIDataReader["GPE_B_INCLUIR"] != DBNull.Value)
                IsPermissaoIncluir = Convert.ToBoolean(pobjIDataReader["GPE_B_INCLUIR"]);

            if (pobjIDataReader["GPE_B_EXCLUIR"] != DBNull.Value)
                IsPermissaoExcluir = Convert.ToBoolean(pobjIDataReader["GPE_B_EXCLUIR"]);

            if (pobjIDataReader["GPE_B_LISTAR"] != DBNull.Value)
                IsPermissaoListar = Convert.ToBoolean(pobjIDataReader["GPE_B_LISTAR"]);

            if (pobjIDataReader["FUN_C_CAMINHO_PAGINA"] != DBNull.Value)
                NomeFuncionalidade = Convert.ToString(pobjIDataReader["FUN_C_CAMINHO_PAGINA"]);
        }

        #endregion

    }
}


