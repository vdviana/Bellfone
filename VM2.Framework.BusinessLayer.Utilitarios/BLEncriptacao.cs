using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.IO;
using System.Security.Cryptography;

namespace VM2.Framework.BusinessLayer.Utilitarios
{

    /// <summary>
    ///     Classe de regra de negócio para encriptação.
    /// </summary>
    /// <user>mazevedo</user>
    public class BLEncriptacao
    {

        #region Variáveis Privadas

        private static string gstrChaveEncriptacao = "!#$a54?3";
        private static byte[] garrRangeBytes = { 10, 20, 30, 40, 50, 60, 70, 80 };


        #endregion

        #region Encriptar Senha

        /// <summary>
        ///     Encripta uma senha para uso
        /// </summary>
        /// <param name="pstrSenha">Senha a ser encriptada</param>
        /// <returns>Senha Endriptada</returns>
        /// <user>mazevedo</user>
        public static string EncriptarSenha(string pstrSenha)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pstrSenha, "SHA1");
        }

        #endregion

        #region Desncriptar Senha

        /// <summary>
        ///     Desncripta uma senha para uso
        /// </summary>
        /// <param name="pstrSenha">Senha a ser encriptada</param>
        /// <returns>Senha Endriptada</returns>
        /// <user>mazevedo</user>
        public static string DescriptarSenha(string pstrSenha)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pstrSenha, "SHA1");
        }

        #endregion

        #region Query String

        #region Encriptar Query String

        /// <summary>
        ///     Criptografa valores para serem usados na querystring
        /// </summary>
        /// <param name="pstrValor">Valor a ser criptografado</param>
        /// <returns>String criptografada</returns>
        /// <user>mazevedo</user>
        public static string EncriptarQueryString(string pstrValor)
        {

            byte[] arrChave = { };
            byte[] arrBytesValor;
            MemoryStream msmStreamCriptografia = null;
            CryptoStream csmCriptografia = null;
            DESCryptoServiceProvider dscProvider = new DESCryptoServiceProvider();

            try
            {
                arrChave = Encoding.UTF8.GetBytes(gstrChaveEncriptacao.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                arrBytesValor = Encoding.UTF8.GetBytes(pstrValor);
                msmStreamCriptografia = new MemoryStream();
                csmCriptografia = new CryptoStream(msmStreamCriptografia, dscProvider.CreateEncryptor(arrChave, garrRangeBytes), CryptoStreamMode.Write);
                csmCriptografia.Write(arrBytesValor, 0, arrBytesValor.Length);
                csmCriptografia.FlushFinalBlock();
                return Convert.ToBase64String(msmStreamCriptografia.ToArray());
            }
            catch (Exception)
            {
                return pstrValor;
            }

        }

        #endregion

        #region Desencriptar QueryString

        /// <summary>
        ///     Desencripta um valor string
        /// </summary>
        /// <param name="pstrValor">Valor encriptado</param>
        /// <returns>Valor descriptado</returns>
        /// <user>mazevedo</user>
        public static string DesencriptarQueryString(string pstrValor)
        {

            byte[] arrChave = { };
            byte[] arrValor = new byte[pstrValor.Length];
            DESCryptoServiceProvider dscProvider = new DESCryptoServiceProvider();
            MemoryStream msmStreamCriptografia = null;
            CryptoStream csmCriptografia = null;

            try
            {
                arrChave = Encoding.UTF8.GetBytes(gstrChaveEncriptacao.Substring(0, 8));
                pstrValor = pstrValor.Replace(" ", "+");
                arrValor = Convert.FromBase64String(pstrValor);
                msmStreamCriptografia = new MemoryStream();
                csmCriptografia = new CryptoStream(msmStreamCriptografia, dscProvider.CreateDecryptor(arrChave, garrRangeBytes), CryptoStreamMode.Write);
                csmCriptografia.Write(arrValor, 0, arrValor.Length);
                csmCriptografia.FlushFinalBlock();

                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(msmStreamCriptografia.ToArray());
            }
            catch (Exception)
            {
                return pstrValor;
            }

        }

        #endregion

        #endregion

    }
}
