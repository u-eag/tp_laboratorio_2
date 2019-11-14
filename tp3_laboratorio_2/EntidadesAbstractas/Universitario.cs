using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Campos

        private int legajo;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario() : base()
        {

        }

        /// <summary>
        /// Constructor que recibe los 5 parámetros
        /// [legajo] [nombre] [apellido] [dni] [nacionalidad]
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Compara el objeto this con el objeto pasado por parámetro.
        /// Retorna [true] si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if(this == (Universitario)obj)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Retorna todos los datos del Universitario
        /// [legajo] [nombre] [apellido] [dni] [nacionalidad]
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.ToString());
            retorno.AppendFormat("LEGAJO NÚMERO: {0}", this.legajo);

            return retorno.ToString();
        }

        /// <summary>
        /// Método protegido y abstracto sin implementación de base.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Compara dos universitarios.
        /// Retorna [false] si NO son del mismo Tipo y su Legajo o DNI son distintos.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            bool retorno = true;

            if (pg1.GetType() == pg2.GetType()
                && pg1.legajo == pg2.legajo
                || pg1.DNI == pg2.DNI)
            {
                retorno = false;
            }

            return retorno;
        }

        /// <summary>
        /// Compara dos universitarios.
        /// Retorna [true] si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return !(pg1 != pg2);
        }

        #endregion
    }
}
