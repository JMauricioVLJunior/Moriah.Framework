using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plivo.API;
using RestSharp;

namespace Moriah.Framework.Communication
{
    public class SMSPlivo
    {
        public static Dictionary<string, string> Enviar(Telefone numeroDestino, Telefone numeroOrigem, string texto, Config.Plivo config)
        {
            RestAPI plivo = new RestAPI(config.AuthID, config.AuthToken);

            IRestResponse<MessageResponse> resp = plivo.send_message(new Dictionary<string, string>()
            {
                { "src", numeroOrigem.NumeroCompleto }, 
                { "dst", numeroDestino.NumeroCompleto }, 
                { "text", texto }, 
                { "url", config.URLReturn },
                { "method", config.Method } 
            });


            var data = resp.Data;

            return new Dictionary<string, string>()
            {
                { "API_ID" , data.api_id },
                { "ERROR" , data.error },
                { "MESSAGE" , data.message},
                { "UID" , (data.message_uuid != null ? data.message_uuid[0] : "") },
            };
        }
    }
}
