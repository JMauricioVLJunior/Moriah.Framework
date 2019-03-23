using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moriah.Framework.Communication.Exceptions;

namespace Moriah.Framework.Communication
{
    public class Telefone
    {
        private string[] DDDs = { "11", "12", "13", "14", "15", "16", "17", "18", "19", "21", "22", "24", "27", "28", "31", "32", "33", "34", "35", "37", "38", "41", "42", "43", "44", "45", "46", "47", "48", "49", "51", "53", "54", "55", "61", "62", "63", "64", "65", "66", "67", "68", "69", "71", "73", "74", "75", "77", "79", "81", "82", "83", "84", "85", "86", "87", "88", "89", "91", "92", "93", "94", "95", "96", "97", "98", "99" };
        private string[] DigitosCelular = { "9", "8", "7", "6" };
        private string[] DigitosFixo = { "2", "3", "4", "5" };
        private string _pais = "+55";
        private string _DDD = "";
        private string _numero = "";

        public string NumeroCompleto
        {
            get
            {
                if (NumeroValido())
                    return string.Format("{0}{1}{2}", _pais, _DDD, _numero);
                else
                    throw new Exception("Número inválido!");
            }
        }

        private string DigitoInicial
        {
            get
            {
                return _numero.Substring(0, 1);
             
            }
        }

        public string DDD
        {
            get
            {
                return _DDD;
            }
        }

        private bool NumeroValido()
        {
            return true;
        }

        private bool ECelular()
        {
            return DigitosCelular.Contains(DigitoInicial);
        }

        /// <summary>
        /// Instancia o objeto com País como Padrão: Brasil (+55)
        /// </summary>
        /// <param name="telefone">Somente DDD e telefone juntos</param>
        public Telefone(string telefone)
        {
            ValidarTelefone(telefone);
        }

        /// <summary>
        /// Instacia o objeto definindo o pais e o telefone.
        /// </summary>
        /// <param name="pais">Podendo ser nos formatos: 55 ou +55</param>
        /// <param name="telefone">Telefone com código de longa distância até 11 dígitos numericos.</param>
        public Telefone(string pais, string telefone)
        {
            ValidarPais(pais);
            ValidarTelefone(telefone);
        }

        private void ValidarTelefone(string telefone)
        {
            telefone = telefone.OnlyNumbers();

            if (!telefone.Length.Equals(10) && !telefone.Length.Equals(11))
            {
                throw new FormatoInvalidoException("Formato correto: (99) 99999-9999 ou 9988887777!\nTelefone: " + telefone);
            }
            else
            {
                Configurar(telefone);
            }
        }

        private void ValidarPais(string pais)
        {
            pais = pais.OnlyNumbers();

            if (!pais.Length.Equals(2))
            {
                throw new FormatoPaisInvalidoException("Formato correto: +55 ou 55");
            }
            else
            {
                _pais = string.Format("+{0}", pais);
            }

        }

        private void ValidarDDD(string DDD)
        {
            if (DDDs.Contains(DDD))
                _DDD = DDD;
            else
                throw new DDDInvalidoException(string.Format("Código de longa distância inválido: {0}",DDD));
        }

        private void Configurar(string telefone)
        {
            ValidarDDD(telefone.Substring(0, 2));
            _numero = telefone.Substring(2, telefone.Length - 2);

        }

    }
}
