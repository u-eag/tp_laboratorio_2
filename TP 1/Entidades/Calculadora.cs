// .NET Framework 4.7.2

namespace Entidades
{
    public static class Calculadora
    {
        #region Methods

        /// <summary>
        /// Deberá validar que el operador recibido sea +, -, / o *. Caso contrario retornará +.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";

            if(operador == "-" || operador == "/" || operador == "*")
            {
                retorno = operador;
            }

            return retorno;
        }

        /// <summary>
        /// Validará y realizará la operación pedida entre ambos números.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;

            operador = ValidarOperador(operador);

            switch(operador)
            {
                case "+":
                    retorno = num1 + num2;
                    break;

                case "-":
                    retorno = num1 - num2;
                    break;

                case "/":
                    retorno = num1 / num2;
                    break;

                case "*":
                    retorno = num1 * num2;
                    break;
            }

            return retorno;
        }

        #endregion
    }
}
