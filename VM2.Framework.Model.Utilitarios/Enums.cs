
namespace VM2.Framework.Model.Utilitarios
{
    public class Enums
    {
       
        /// <summary>
        ///     Define os tipos de view da página
        /// </summary>
        /// <user>tprohaska</user>
        public enum TipoView
        {
            Cadastro = 0,
            Listagem = 1
        }

        /// <summary>
        ///  Define os tipos de operações com relação a Model
        /// </summary>
        /// <user>tprohaska</user>
        public enum TipoOperacao
        {
            /// <summary>Popula a model com os dados da página</summary>
            Carregar = 0,

            /// <summary>Popula a página com os dados da Model</summary>
            Descarregar = 1
        }

        /// <summary>
        /// Define os tipos de mensagens a ser Exibida
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <user>larruda</user>
        public enum TipoMensagem
        {
            /// <summary>Mensagens que notificam o usuario para operacaoes bem sucedidas </summary>
            Atencao = 0,

            /// <summary>Menagens que informa algo ao usuário</summary>
            Info = 1,

            /// <summary>Menagens de operacoes bem sucedidas</summary>
            Aprovado =2,

            /// <summary>Mensagens quando houver qualquer tipo de erro</summary>
            Erro = 3
        }
       
    }
}
