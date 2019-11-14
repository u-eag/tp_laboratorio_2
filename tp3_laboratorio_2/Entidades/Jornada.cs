using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Universidad; // para que funcione el objeto EClases
using EntidadesAbstractas;
using Archivos;

namespace Entidades
{
    public class Jornada
    {
        #region Campos

        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;

        #endregion

        #region Propiedades

        /// <summary>
        /// 
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                // a completar
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {

            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// Inicializará la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor que recibe 2 parámetros
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Guardará los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto txt = new Texto(); // donde se van a guardar los datos
            
            if (!(txt is null && jornada is null))
            {
                retorno = txt.Guardar(AppDomain.CurrentDomain.BaseDirectory + "\\Jornada.txt", jornada.ToString());
            }

            return retorno;
        }

        /// <summary>
        /// Retornará los datos de la Jornada como string.
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            string retorno = ""; // limpio la variable
            Texto txt = new Texto();
            
            if (!(txt is null))
            {
                txt.Leer(AppDomain.CurrentDomain.BaseDirectory + "\\Jornada.txt", out retorno);
            }

            return retorno;
        }

        /// <summary>
        /// Una Jornada será distinta de un Alumno si el mismo NO participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            bool retorno = true;

            if (a == j.clase) // uso el override del == de alumno que me dice si participa en la clase o no
            {
                retorno = false;
            }

            return retorno;
        }

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return !(j != a);
        }

        /// <summary>
        /// Agrega un alumno al listado si es que no está contenido previamente.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(!j.alumnos.Contains(a)) // si el alumno no está contenido en el listado...
            {
                j.alumnos.Add(a); // ...lo agrego
            }

            return j;
        }

        /// <summary>
        /// Muestra todos los datos de la jornada
        /// [clase] [instructor] [alumno]
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            // acá está el formato de toda la salida por pantalla

            retorno.AppendFormat("CLASE DE {0}", this.clase);
            retorno.AppendFormat(" POR {0}", this.instructor.ToString());
            retorno.AppendLine("ALUMNOS:");

            foreach(Alumno a in this.alumnos)
            {
                retorno.AppendLine(a.ToString());
            }

            retorno.Append("<---------------------------------------------->\n\n");

            return retorno.ToString();
        }

        #endregion
    }
}
