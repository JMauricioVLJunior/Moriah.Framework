using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Moriah.Framework.Communication
{
    public class Config
    {
        public class Plivo
        { 
            public string AuthID { get; private set; }
            public string AuthToken { get; private set; }
            public string URLReturn { get; private set; }
            public string Method { get; private set; }

            public Plivo(string AUTH_ID, string AUTH_TOKEN, string URL_RETURN, string METHOD)
            {
                this.AuthID = AUTH_ID;
                this.AuthToken = AUTH_TOKEN;
                this.URLReturn = URL_RETURN;
                this.Method = METHOD;
            }
        }


        public class Email
        {
            public string EmailTI { get; private set; }
            public string EmailTIName { get; private set; }
            public string User { get; private set; }
            public string Name { get; private set; }
            public string Pass { get; private set; }
            public string Host { get; private set; }
            public int Port { get; private set; }
            public bool Ssl { get; private set; }
            private string _ReplyTo { get; set; }
            private string _ReplyToName { get; set; }
            public MailAddress EmailSuporte { get { return new MailAddress(EmailTI, EmailTIName); } }
            public MailAddress From { get { return new MailAddress(User, Name); } }
            public MailAddress ReplyTo { get { return new MailAddress(_ReplyTo,_ReplyToName); } }

            public Email(string EmailTI,
                         string EmailTIName,
                         string User,
                         string Name,
                         string ReplyTo,
                         string ReplyToName,
                         string Pass,
                         string Host,
                         int Port,
                         bool Ssl)
            {
                this.EmailTI = EmailTI;
                this.EmailTIName = EmailTIName;
                this.User = User;
                this.Name = Name;
                _ReplyTo = ReplyTo;
                _ReplyToName = ReplyToName;
                this.Pass = Pass;
                this.Host = Host;
                this.Port = Port;
                this.Ssl = Ssl;
            }
        }
    }
}
