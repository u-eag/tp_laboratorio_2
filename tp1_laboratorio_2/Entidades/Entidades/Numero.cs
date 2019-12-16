using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero; // atributo privado

        /// <summary>
        /// constructor por defecto sin parámetros:
        /// </summary>
        public Numero ()
        {
            numero = 0;
        }

        /// <summary>
        /// constructor con parámetro: recibe el número en double
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// constructor con parámetro: recibe el número en string
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            double.TryParse(strNumero, out numero);
        }

        /// <summary>
        /// Este método asignara un valor al atributo número, previa validación.
        /// </summary>
        public string SetNumero // propiedad pública para atributo privado
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Valida que el valor ingresado sea un número
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
        /// Convierte un número binario a decimal, en caso de ser posible. Caso contrario retorna "Valor inválido".
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            // recibo el número en string, lo trabajo en char[] y lo vuelvo a convertir a string para retornar el resultado
            string retorno = "Valor inválido"; // por defecto retorna error 
            int aux;
            string auxStr;
            char[] arrayStr;
            int i;
            int acumulador = 0;

            // 1. Me quedo con la parte entera y el valor absoluto del número recibido:
            int.TryParse(binario, out aux); // me quedo con la parte entera y con el signo
            Math.Abs(aux); // me quedo con el valor absoluto

            if(aux == 0)
            {
                retorno = "0";
            }
            else
            {
                // 2. Paso el  número a decimal:
                auxStr = aux.ToString(); // paso el int aux a string aux
                arrayStr = auxStr.ToCharArray(); // para recorrer cada char con un for
                Array.Reverse(arrayStr);

                for (i=0; i<arrayStr.Length; i++)
                {
                    if(arrayStr[i] == '1') // solo multiplico los 1, porque los 0 van a dar 0
                    {
                        acumulador += (int)Math.Pow(2, i);
                    }
                }
                retorno = Convert.ToString(acumulador);
            }
            return retorno;
        }

        public string DecimalBinario(double numero)
        {
            // recibo el número en double, lo trabajo en char[] y lo convierto a string para retornar el resultado
            string retorno = "Valor inválido"; // por defecto retorna error 
            int aux;
            string auxStr;
            string strBinario = "";
            char[] arrayBinario;

            // 1. Me quedo con la parte entera y el valor absoluto del número recibido:
            auxStr = numero.ToString();
            int.TryParse(auxStr, out aux); // me quedo con la parte entera y con el signo
            Math.Abs(aux); // me quedo con el valor absoluto

            // 2. Paso el número a binario:
            if(aux == 0)
            {
                retorno = "0";
            }
            else
            { 
                while (aux > 1)
                {
                    if(aux % 2 == 0)
                    {
                        strBinario += "0";
                    }
                    else
                    {
                        strBinario += "1";
                    }
                    aux /= 2; // actualizo el número
                }
                auxStr = aux.ToString(); // es el último número indivisibe (0 ó 1)
                strBinario += auxStr; // lo concateno
                arrayBinario = strBinario.ToCharArray(); // paso todo el string a array para revertirlo
                Array.Reverse(arrayBinario); // lo revierto
                retorno = new string (arrayBinario); // una vez ordenado lo paso a string y lo retorno
            }

            return retorno;
        }

        public string DecimalBinario(string numero)
        {
            string retorno = "Valor inválido";
            double dblNumero;

            if(double.TryParse(numero, out dblNumero))
            {
                Numero num = new Numero(dblNumero); // necesito el constructor para poder invocar al método
                retorno = num.DecimalBinario(dblNumero);
            }

            return retorno;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero; // para restar accedo al campo numero del objeto Numero
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero; // para multiplicar accedo al campo numero del objeto Numero
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue; // por defecto retorna MinValue

            if (n2.numero != 0) // si el divisor es distinto de 0, opero y retorno el resultado
            {
                retorno = n1.numero / n2.numero;
            }

            return retorno;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero; // para sumar accedo al campo numero del objeto Numero
        }
    }
}
