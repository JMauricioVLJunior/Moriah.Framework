using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Mail
{
    public static class ExtensionsMethods
    {
        public static string JoinMailAddress(this IEnumerable<MailAddress> listaEmail, string separador)
        {
            if (listaEmail.Count() > 0)
            {
                return string.Join(separador, listaEmail.Select(x => x.Address));
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Retorna a união da coleção de e-mail no padrão: NOME <usuario@email.com>
        /// </summary>
        /// <param name="separador">Qual separador deverá ser usado na união da coleção.</param>
        /// <returns></returns>
        public static string JoinNameMailAddress(this IEnumerable<MailAddress> listaEmail, string separador)
        {
            if (listaEmail.Count() > 0)
            {
                return string.Join(separador, listaEmail.Select(x => string.Format("{0} <{1}>", x.DisplayName, x.Address)));
            }
            else
            {
                return "";
            }
        }
    }
}
