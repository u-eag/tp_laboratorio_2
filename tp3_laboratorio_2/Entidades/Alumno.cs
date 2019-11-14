using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static Entidades.Universidad; // para que funcione el objeto EClases

namespace Entidades
{
    public sealed class Alumno : Universitario
    {
        #region Campos

        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno() : base()
        {

        }

        /// <summary>
        /// Constructor con 6 parámetros de 7
        /// [id/legajo] [nombre] [apellido] [dni] [nacionalidad] [claseQueToma]
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni,
            ENacionalidad nacionalidad, EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor con los 7 parámetros 
        /// [id/legajo] [nombre] [apellido] [dni] [nacionalidad] [claseQueToma] [estadoCuenta]
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni,
            ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Sobrecarga del método MostrarDatos de Universitario
        /// Muestra todos los campos en formato string
        /// [id/legajo] [nombre] [apellido] [dni] [nacionalidad] [claseQueToma] [estadoCuenta]
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendFormat("\nESTADO DE CUENTA: {0}", this.estadoCuenta); // otra opción: \r\n para salto de línea
            retorno.AppendLine(this.ParticiparEnClase()); // string de la clase que toma

            return retorno.ToString();
        }

        /// <summary>
        /// Retorna la cadena "TOMA CLASE DE " junto al nombre de la clase que toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendFormat("\nTOMA CLASE DE {0}", this.claseQueToma);

            return retorno.ToString();
        }

        /// <summary>
        /// Hace públicos los datos del Alumno.
        /// [id/legajo] [nombre] [apellido] [dni] [nacionalidad] [claseQueToma] [estadoCuenta]
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            bool retorno = true;

            if (a.claseQueToma == clase
                && a.estadoCuenta != EEstadoCuenta.Deudor) // solo evalúa esta condición si la primera da true
            {
                retorno = false;
            }

            return retorno;
        }

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            return !(a != clase);
        }

        #endregion

        #region Tipos Anidados

        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        #endregion
    }
}
