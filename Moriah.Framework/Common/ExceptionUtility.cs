using System;
using System.IO;
using System.Text;
using System.Web;
using Moriah.Framework.Communication;

namespace Moriah.Framework.Common
{
    // Create our own utility for exceptions
    public sealed class ExceptionUtility
    {
        private ExceptionUtility()
        { }

        public static void LogException(Exception exc, string source)
        {

            string logFile = HttpRuntime.AppDomainAppPath + "App_Data\\ErrorLog.txt";
            string txtError = ExceptionToText(exc, source);
            if (!File.Exists(logFile)) { File.Create(logFile); }

            StreamWriter sw = new StreamWriter(logFile, true);

            //Email.SendEmailErroLog(txtError);

            sw.Write(txtError);
            sw.Close();
            sw.Dispose();
        }

        private static string ExceptionToText(Exception exc, string source = "", bool isInnerException = false)
        {
            StringBuilder sb = new StringBuilder();
            string inner = "";
            if (isInnerException)
                inner = "Inner ";
            else
                sb.AppendFormatLine("********** {0} **********", DateTime.Now);

            if (exc.InnerException != null)
                sb.AppendLine(ExceptionToText(exc.InnerException, null, true));

            sb.AppendLine();
            sb.AppendFormatLine("{0}Tipo: {1}", inner, exc.GetType().ToString());
            sb.AppendFormatLine("{0}Mensagem: {1}", inner, exc.Message);
            sb.AppendFormatLine("{0}Origem: {1}", inner, (source != null ? source : exc.Source));
            sb.AppendLine();

            if (exc.StackTrace != null)
            {
                sb.AppendFormatLine("{0}Stack Trace: {1}", inner, exc.StackTrace);
                sb.AppendLine();
            }

            return sb.ToString();
        }

    }
}