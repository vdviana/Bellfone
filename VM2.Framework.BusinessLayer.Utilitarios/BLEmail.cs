using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace VM2.Framework.BusinessLayer.Utilitarios
{

    /// <summary>
    ///     Classe com regras para envio de e-mail
    /// </summary>
    /// <user>mazevedo</user>
    public class BLEmail
    {

        #region EnviarEmail
        /// <summary>
        /// Envia um email com as configurações do sistema(Porte, email origem)
        /// </summary>
        /// <param name="strEmailDestino">Email destino</param>
        /// <param name="strAssunto">Assunto do Email</param>
        /// <param name="strBody">Corpo do Email</param>
        public static void EnviarEmail(string strEmailDestino, string strAssunto, string strCorpo)
        {
            try
            {
                string strEmail = BLConfiguracao.UsuarioEmail;
                string strSenha = BLConfiguracao.SenhaEmail;
                string strHost = BLConfiguracao.ServidorEmail;
                int intPorta = BLConfiguracao.PortaEmail;

                var mensagem = new MailMessage();
                var remetente = new MailAddress(strEmail);

                var lstDestinatarios = strEmailDestino.Split(',');

                foreach (var s in lstDestinatarios)
                {
                    var destinatario = new MailAddress(s);
                    mensagem.To.Add(destinatario);
                }

                mensagem.IsBodyHtml = true;
                mensagem.From = remetente;
                mensagem.Subject = strAssunto;
                mensagem.Body = strCorpo;

                SmtpClient stcEmail = new SmtpClient(strHost, intPorta);
                stcEmail.UseDefaultCredentials = false;
                stcEmail.Credentials = new System.Net.NetworkCredential(strEmail, strSenha);

                stcEmail.Send(mensagem);
            }
            catch
            {
                throw;
            }
        }

        #endregion

        public static void EnviarEmailComAnexo(string strEmailDestino, string strAssunto, string strCorpo, string arquivo)
        {
            try
            {
                string strEmail = BLConfiguracao.UsuarioEmail;
                string strSenha = BLConfiguracao.SenhaEmail;
                string strHost = BLConfiguracao.ServidorEmail;
                int intPorta = BLConfiguracao.PortaEmail;

                var mensagem = new MailMessage();
                var remetente = new MailAddress(strEmail);

                var lstDestinatarios = strEmailDestino.Split(',');

                foreach (var s in lstDestinatarios)
                {
                    var destinatario = new MailAddress(s);
                    mensagem.To.Add(destinatario);
                }

                mensagem.IsBodyHtml = true;
                mensagem.From = remetente;
                mensagem.Subject = strAssunto;
                mensagem.Body = strCorpo;

                // Cria o anexo
                Attachment att = new Attachment(arquivo);
                mensagem.Attachments.Add(att);

                SmtpClient stcEmail = new SmtpClient(strHost, intPorta);

                stcEmail.UseDefaultCredentials = false;
                stcEmail.Credentials = new System.Net.NetworkCredential(strEmail, strSenha);

                stcEmail.Send(mensagem);
            }
            catch
            {
                throw;
            }
        }

    }
}
