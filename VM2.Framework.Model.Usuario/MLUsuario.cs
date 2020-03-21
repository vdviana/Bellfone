using System;
using System.Data;

namespace VM2.Framework.Model.Usuario
{
    /// <summary> 
    /// Model da Entidade Usuario 
    /// </summary> 
    /// <user>mazevedo</user> 
    public class MLUsuario
    {
        #region Propriedades

        /// <summary> 
        /// Recebe o valor de USU_N_CODIGO 
        /// </summary> 
        /// <user>mazevedo</user>
        public decimal? Codigo { get; set; }

        /// <summary> 
        /// Recebe o valor de USU_C_NOME 
        /// </summary> 
        /// <user>mazevedo</user>
        public string Nome { get; set; }

        /// <summary> 
        /// Recebe o valor de USU_C_LOGIN 
        /// </summary> 
        /// <user>mazevedo</user>
        public string Login { get; set; }

        /// <summary> 
        /// Recebe o valor de USU_C_SENHA 
        /// </summary> 
        /// <user>mazevedo</user>
        public string Senha { get; set; }

        /// <summary> 
        /// Recebe o valor de USU_C_EMAIL 
        /// </summary> 
        /// <user>mazevedo</user>
        public string Email { get; set; }

        /// <summary> 
        /// Recebe o valor de USU_D_CADASTRO 
        /// </summary> 
        /// <user>mazevedo</user>
        public DateTime? DataCadastro { get; set; }

        /// <summary> 
        /// Recebe o valor de USU_B_STATUS 
        /// </summary> 
        /// <user>mazevedo</user>
        public bool? IsAtivo { get; set; }

        /// <summary> 
        /// Recebe o valor de USU_B_ALTERARSENHA 
        /// </summary> 
        /// <user>mazevedo</user>
        public bool? IsAlterarSenha { get; set; }

        /// <summary> 
        /// Recebe o valor do Tipo de Usuário
        /// </summary> 
        /// <user>mazevedo</user>
        public enmTipoUsuario TipoUsuario { get; set; }

        /// <summary> 
        /// Recebe o valor de USU_B_CADASTROSTATUS 
        /// </summary> 
        /// <user>mazevedo</user>
        public string IsCadastroAtivo { get; set; }

        #endregion

        #region Conversor DataReader

        /// <summary>
        /// Metodo que popula a Model com Base em uma Interface DataReader
        /// </summary>
        /// <param name=pobjIDataReader>Interface DataReader</param>
        public void FromIDataReader(IDataReader pobjIDataReader)
        {
            if (pobjIDataReader["USU_N_CODIGO"] != DBNull.Value)
                Codigo = Convert.ToDecimal(pobjIDataReader["USU_N_CODIGO"]);

            if (pobjIDataReader["USU_C_NOME"] != DBNull.Value)
                Nome = Convert.ToString(pobjIDataReader["USU_C_NOME"]);
            
            if (pobjIDataReader["USU_C_LOGIN"] != DBNull.Value)
                Login = Convert.ToString(pobjIDataReader["USU_C_LOGIN"]);

            if (pobjIDataReader["USU_C_SENHA"] != DBNull.Value)
                Senha = Convert.ToString(pobjIDataReader["USU_C_SENHA"]);

            if (pobjIDataReader["USU_C_EMAIL"] != DBNull.Value)
                Email = Convert.ToString(pobjIDataReader["USU_C_EMAIL"]);

            if (pobjIDataReader["USU_D_CADASTRO"] != DBNull.Value)
                DataCadastro = Convert.ToDateTime(pobjIDataReader["USU_D_CADASTRO"]);

            if (pobjIDataReader["USU_B_STATUS"] != DBNull.Value)
                IsAtivo = Convert.ToBoolean(pobjIDataReader["USU_B_STATUS"]);

            if (pobjIDataReader["USU_B_ALTERARSENHA"] != DBNull.Value)
                IsAlterarSenha = Convert.ToBoolean(pobjIDataReader["USU_B_ALTERARSENHA"]);

           /* if (pobjIDataReader["USU_B_CADASTROSTATUS"] != DBNull.Value)
                IsCadastroAtivo = Convert.ToString(pobjIDataReader["USU_B_CADASTROSTATUS"]);
            else
                IsCadastroAtivo = "ativo";
            */
        }

        #endregion
    }

    /// <summary>
    ///     Define os tipos de usuários 
    /// </summary>
    /// <user>mazevedo</user>
    public enum enmTipoUsuario
    {
        Revendedor = 0,
        Vendedor = 1,
        Administrador = 2
    }
}


