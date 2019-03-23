using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moriah.Framework.Communication
{
    public enum eSMSStatus
    {
        [Description("Em Fila")] queued,
        [Description("Enviado")] sent,
        [Description("Falhou")] failed,
        [Description("Entregue")] delivered,
        [Description("Não Entregue")] undelivered,
        [Description("Rejeitado")] rejected,
        [Description("Status Não Identificado")] unidentified,
    }
}
