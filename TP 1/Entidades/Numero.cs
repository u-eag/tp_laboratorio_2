// .NET Framework 4.7.2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Fields

        private double numero;

        #endregion

        #region Properties

        /// <summary>
        /// asignará un valor al atributo número, previa validación
        /// </summary>
        private string SetNumero
        {
            set 
            {
                this.numero = ValidarNumero(value);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// El constructor por defecto (sin parámetros) asignará valor 0 al atributo numero.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Comprobará que el valor recibido sea numérico, y lo retornará en formato double. 
        /// Caso contrario, retornará 0.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;

            double.TryParse(strNumero, out retorno);

            return retorno;
        }

        /// <summary>
        /// Convertirá un número binario a decimal, en caso de ser posible. 
        /// Caso contrario retornará "Valor inválido".
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            binario.ToCharArray();

            foreach (char letter in binario)
            {
                if(letter != 0 || letter != 1)
                {
                    return "Valor inválido";
                } 
            }

            binario.Reverse();

            double decimalNumber = 0;
            foreach (char number in binario)
            {
                double digit = 0;
                double pow = 0;

                double.TryParse(number.ToString(), out digit);

                if(digit == 1)
                {
                    decimalNumber += Math.Pow(2, pow);
                    pow++; 
                }
            }

            return decimalNumber.ToString();
        }

        /// <summary>
        /// Convertirá un número decimal a binario, en caso de ser posible. 
        /// Caso contrario retornará "Valor inválido".
        /// Trabajará con enteros positivos, quedándose para esto con el valor absoluto y entero del numero recibido.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            if(numero == "0")
            {
                return "0";
            }
            else
            {
                SetNumero = numero; // valida que sea un número y lo guarda como double en this.numero

                if (this.numero == 0) // si a esta altura vale 0 es porque no funcionó el double.TryParse
                {
                    return "Valor inválido";
                }
                else // es un número decimal válido y puedo convertir su valor absoluto a binario
                {
                    Math.Abs(this.numero);          // le quito el signo
                    Math.Truncate(this.numero);     // le quito los decimales

                    string binario = "";
                    while ((this.numero / 2) >= 2)
                    {
                        string digit = (this.numero % 2).ToString();
                        binario += digit;
                    }
                    binario.ToCharArray();
                    binario.Reverse();

                    return binario.ToString();
                }
            }
        }

        /// <summary>
        /// Convertirá un número decimal a binario, en caso de ser posible. 
        /// Caso contrario retornará "Valor inválido".
        /// Trabajará con enteros positivos, quedándose para esto con el valor absoluto y entero del numero recibido.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }

        #endregion

        #region Operators

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Si se tratara de una división por 0, retornará double.MinValue
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;

            if(n2.numero != 0)
            {
                retorno = n1 / n2;
            }

            return retorno;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        #endregion
    }
}