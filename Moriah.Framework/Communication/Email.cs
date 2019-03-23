using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading;
using System.ComponentModel;

namespace Moriah.Framework.Communication
{
    public class Email
    {
        private MailMessage mail = new MailMessage();
        private Guid idEmail;
        private Config.Email config;// = new Config.Email("", "", "", "", "", "", "", "", 0, false);

        private static SmtpClient Cliente(Config.Email config)
        {
            SmtpClient clienteSMTP = new SmtpClient(config.Host, config.Port);

            clienteSMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
            clienteSMTP.EnableSsl = config.Ssl;
            clienteSMTP.UseDefaultCredentials = false;
            clienteSMTP.Credentials = new NetworkCredential(config.User, config.Pass);

            return clienteSMTP;
        }

        public Email(Config.Email config, List<MailAddress> para, List<MailAddress> cc, List<MailAddress> cco, string assunto, string body, bool HTML = true)
        {
            this.config = config;

            if (para.Count > 0 || cc.Count > 0 || cco.Count > 0)
            {

                idEmail = Guid.NewGuid();

                body += string.Format("\r\n\r\nChave de Identificação do E-mail: {0}", idEmail.ToString());

                if (HTML) body = body.Replace("\n", "<br/>");

                mail.From = config.From;
                mail.To.AddRange(para);
                mail.CC.AddRange(cc);
                mail.Bcc.AddRange(cco);
                mail.ReplyToList.Add(config.ReplyTo);
                mail.Subject = assunto;
                mail.Body = body;
                mail.IsBodyHtml = HTML;
            }
            else
            {
                throw new Exception("Nenhum destinatário para envio do e-mail!");
            }
        }

        /// <summary>
        /// Log de Erro! (Usar este construtor apenas para erro!)
        /// </summary>
        /// <param name="erro">Erro em texto.</param>
        public static void SendEmailErroLog(string erro, Config.Email config, string assunto = "Erro no Sistema!")
        {
            MailMessage mail = new MailMessage();
            mail.From = config.From;
            mail.To.Add(config.EmailSuporte);
            mail.Subject = assunto;
            mail.Body = erro;
            mail.IsBodyHtml = false;
            Enviar(mail, config);
        }

        private static void _Enviar(object parametros)
        {
            Config.Email config = ((Parametros)parametros).config;
            MailMessage mail = ((Parametros)parametros).email;
            SmtpClient cliente = Cliente(config);

            try
            {
                using (mail)
                {
                    cliente.Send(mail);
                }
            }
            catch (SmtpFailedRecipientException ex)
            {
                throw ex;
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public Guid Enviar()
        {            
            Enviar(mail, config);
            return idEmail;
        }

        private static void Enviar(MailMessage mail, Config.Email config)
        {
            Parametros param = new Parametros()
            {
                email = mail,
                config = config
            };

            new Thread(new ParameterizedThreadStart(_Enviar)).Start(param);

        }

        private class Parametros
        {
            public MailMessage email { get; set; }
            public Config.Email config { get; set; }
        }
    }
}
