using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador (string operador)
        {
            string retorno = "+"; // por defecto retorna +

            if(operador == "-")
            {
                retorno = "-";
            }
            else if(operador == "/")
            {
                retorno = "/";
            }
            else if(operador == "*")
            {
                retorno = "*";
            }

            return retorno;
        }

        public static double Operar (Numero num1, Numero num2, string operador)
        {
            double retorno = 0;

            if (num1 != null && num2 != null)
            {
                ValidarOperador(operador);

                switch (operador)
                {
                    case "-":
                        retorno = num1 - num2;
                        break;

                    case "*":
                        retorno = num1 * num2;
                        break;

                    case "/":
                        retorno = num1 / num2; // dentro del operador se valida que num2 sea != 0
                        break;

                    case "+":
                        retorno = num1 + num2;
                        break;
                }
            }

            return retorno;
        }
    }
}
