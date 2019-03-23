using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ExtensionsMethods
    {
        public static string Descricao<T>(this T acao) where T : struct, IConvertible
        {
            if (typeof(T).IsEnum)
            {
                var type = typeof(T);
                var memInfo = type.GetMember(acao.ToString());
                var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Count() > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }
            return "";

        }


        public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
        {

            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                    .Where(x => x.CanWrite)
                    .ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    p.SetValue(dest, sourceProp.GetValue(source, null), null);
                }

            }

        }




        public static DateTime DiaUm(this DateTime data)
        {
            return new DateTime(data.Year, data.Month, 1);
        }

        public static string ParaTexto(this bool? data)
        {

            string txt = "false";

            if (data.HasValue && data.Value)
                txt = "true";


            return txt;
        }

        public static string ParaTexto(this DateTime? data)
        {
            string txt;

            if (data.HasValue)
                txt = data.Value.ToString("dd/MM/yyyy");
            else
                txt = "";


            return txt;
        }
        public static string ParaTextoValor(this DateTime? data)
        {
            string txt;

            if (data.HasValue)
                txt = data.Value.ToString("MM/dd/yyyy");
            else
                txt = "";


            return txt;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static string OnlyNumbers(this string str)
        {
            List<char> numbers = new List<char>("0123456789");
            StringBuilder toReturn = new StringBuilder(str.Length);
            CharEnumerator enumerator = str.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (numbers.Contains(enumerator.Current))
                    toReturn.Append(enumerator.Current);
            }

            return toReturn.ToString();
        }

        public static DateTime MesAno(this string str)
        {
            string[] mesesAbreviados = "JAN,FEV,MAR,ABR,MAI,JUN,JUL,AGO,SET,OUT,NOV,DEZ".Split(',');
            string[] meses = "JANEIRO,FEVEREIRO,MARÇO,ABRIL,MAIO,JUNHO,JULHO,AGOSTO,SETEMBRO,OUTUBRO,NOVEMBRO,DEZEMBRO".Split(',');
            int mes = 0, ano = 0;

            for (int i = 0; i < meses.Length; i++)
            {
                if (str.IndexOf(mesesAbreviados[i]) >= 0)
                {
                    str = str.Remove(str.IndexOf(mesesAbreviados[i]), mesesAbreviados[i].Length);
                    mes = i + 1;
                    break;
                }

                if (str.IndexOf(meses[i]) >= 0)
                {
                    str = str.Remove(str.IndexOf(meses[i]), meses[i].Length);
                    mes = i + 1;
                    break;
                }

            }

            for (int i = 1900; i < 2100; i++)
            {
                if (str.Contains(i.ToString()))
                {
                    ano = i;
                    break;
                }
            }

            return (ano.Equals(0) || mes.Equals(0) ? DateTime.MinValue : new DateTime(ano, mes, 1));


        }

        public static string TodasAsMensagens(this Exception ex)
        {
            StringBuilder mensagens = new StringBuilder();

            Exception exception = ex;

            do
            {
                if (!string.IsNullOrEmpty(exception.Message)) mensagens.AppendLine(exception.Message);

                exception = exception.InnerException;

            } while (exception != null);

            return mensagens.ToString();
        }

        public static string TodasAsMensagensHTML(this Exception ex)
        {
            StringBuilder mensagens = new StringBuilder();

            Exception exception = ex;

            do
            {
                if (!string.IsNullOrEmpty(exception.Message)) mensagens.AppendFormat("{0}{1}", exception.Message, "<br/>");

                exception = exception.InnerException;

            } while (exception != null);

            return mensagens.ToString();
        }


        public static bool EFinalDeSemana(this DateTime data)
        {
            return data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday;

        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Retorna os caracteres da direita para esquerda uma string.
        /// </summary>
        /// <param name="str">String.</param>
        /// <param name="lenght">Tamanho a ser recuperado.</param>
        /// <returns></returns>
        public static string Right(this string str, int lenght)
        {
            return str.Substring(str.Length - lenght, lenght);
        }

        /// <summary>
        /// Retorna os caracteres da esquerda para direita uma string.
        /// </summary>
        /// <param name="str">String.</param>
        /// <param name="lenght">Tamanho a ser recuperado.</param>
        /// <returns></returns>
        public static string Left(this string str, int lenght)
        {
            return str.Substring(0, lenght);
        }

        public static string Format(this string str, params object[] args)
        {
            return string.Format(str, args);
        }

        public static string DecimalSeparator(this decimal numero, string separador)
        {
            return numero.ToString(new NumberFormatInfo() { NumberDecimalSeparator = separador });
        }

        public static string ToObjJS(this DateTime data)
        {
            return string.Format("new Date({0}, {1}, {2}, {3}, {4}, {5}, {6})", data.Year, data.Month - 1, data.Day, data.Hour, data.Minute, data.Second, data.Millisecond);
        }

        public static DateTime AddBusinessDay(this DateTime data, int businessDays)
        {
            int diasUteisEncontrados = 0;
            while (diasUteisEncontrados < businessDays)
            {
                data = data.AddDays(1);
                if (data.DayOfWeek != DayOfWeek.Sunday && data.DayOfWeek != DayOfWeek.Saturday)
                    diasUteisEncontrados++;
            }
            return data;
        }

        public static bool IsLastDayOfMonth(this DateTime data)
        {
            int mes = data.Month;
            int mes2 = data.AddDays(1).Month;

            return mes != mes2;
        }


    }
}
