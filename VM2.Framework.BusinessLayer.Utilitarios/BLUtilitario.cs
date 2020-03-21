using System;
using System.Collections.Generic;
using System.Text;
using VM2.Framework.DataLayer.Utilitarios;

namespace VM2.Framework.BusinessLayer.Utilitarios
{
    /// <summary>
    ///     Classe de Utilitário do FrameWork
    /// </summary>
    /// <user>mazevedo</user>
    public class BLUtilitario
    {

        #region VerificarBancoDados

        /// <summary>
        ///     Verificar a disponibilidade do Banco de Dados
        /// </summary>
        /// <returns>Condicional de disponibilidade com o Banco de Dados</returns>
        /// <user>mazevedo</user>
        public static bool VerificarBancoDados()
        {
            if (BLConfiguracao.IsVerificarBancoDados)
            {
                Connector conUtilitario = new Connector();
                IDLUtilitario objDLUtilitario = conUtilitario.ObterDLUtilitario();
                try
                {
                    return objDLUtilitario.VerificarBancoDados();
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conUtilitario.Finalizar();
                }
            }
            return true;

        }

        #endregion

        /// <summary>
        /// Randonizar um numero
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Número</returns>
        /// <user>mazevedo</user>
        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        /// <summary>
        /// Randonizar um caracter
        /// </summary>
        /// <param name="size"></param>
        /// <param name="lowerCase"></param>
        /// <returns>Letra</returns>
        /// <user>mazevedo</user>
        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        /// <summary>
        /// Randonizar um novo Password
        /// </summary>
        /// <returns>Strinfg Password</returns>
        /// <user>mazevedo</user>
        public static string GetNewPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        } 

    }
}
