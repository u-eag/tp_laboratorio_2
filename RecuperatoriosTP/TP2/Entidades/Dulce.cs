using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region Propiedades

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor que recibe 3 parámetros y llama al constructor de la clase base
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Dulce(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {

        }

        #endregion

        #region Métodos

        /// <summary>
        /// Publica todos los datos del Dulce.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar()); // llamo al método Mostrar de la base 
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

    }
}
