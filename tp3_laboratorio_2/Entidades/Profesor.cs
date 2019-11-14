using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static Entidades.Universidad; // para que funcione el objeto EClases

namespace Entidades
{
    public sealed class Profesor : Universitario
    {
        #region Campos

        private Queue<EClases> clasesDelDia;
        private static Random random;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor privado de instancia.
        /// Sin parámetros. Llama a la base, también sin parámetros.
        /// Está para poder usar los archivos, que requieren constructores por defecto.
        /// </summary>
        private Profesor() : base()
        {

        }

        /// <summary>
        /// Constructor estático.
        /// Inicializa al campo random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor que recibe 5 parámetros de 7
        /// [id/legajo] [nombre] [apellido] [dni] [nacionalidad]
        /// Inicializará ClasesDelDia.
        /// Se asignarán dos clases al azar al Profesor mediante el método randomClases.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();

            int clasesPorProfesor = 2; // cantidad de clases que se van a asignar al azar a un Profesor

            for (int i = 0; i < clasesPorProfesor; i++)
            {
                this._randomClases(); // llamo al método que asigna una clase al azar
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Asigna una clase al azar a un Profesor
        /// [Programacion] [Laboratorio] [Legislacion] [SPD]
        /// </summary>
        private void _randomClases()
        {
           int claseAlAzar = random.Next(1, 4); // elijo una clase según su índice

           this.clasesDelDia.Enqueue((EClases)claseAlAzar); // agrega la clase elegida al azar a la cola de clases del día
        }

        /// <summary>
        /// Retorna la cadena "CLASES DEL DÍA" junto al nombre de la clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("CLASES DEL DÍA:");

            foreach (EClases clase in this.clasesDelDia)
            {
                retorno.AppendFormat("{0}\n", clase);
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Sobreescribe el método MostrarDatos de Universitario.
        /// Muestra todos los campos de Profesor.
        /// [legajo] [nombre] [apellido] [dni] [nacionalidad] [claseDelDia]
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendLine(this.ParticiparEnClase()); // carga las clases del día en formato string

            return retorno.ToString();
        }

        /// <summary>
        /// Sobreescribe el método ToString() para mostrar todos los datos de un Profesor.
        /// [legajo] [nombre] [apellido] [dni] [nacionalidad] [claseDelDia] [Random]
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Profesor será disdinto de un EClase si NO da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            bool retorno = true;

            if (i.clasesDelDia.Contains(clase)) // pregunto si la clase está contenida en la Queue clasesDelDia de ese Profesor
            {
                retorno = false;
            }

            return retorno;
        }

        /// <summary>
        /// Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            return !(i != clase);
        }

        #endregion
    }
}
