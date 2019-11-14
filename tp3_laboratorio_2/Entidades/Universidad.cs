using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace Entidades
{
    public class Universidad
    {
        #region Campos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto.
        /// Inicializa las 3 listas:
        /// [alumnos] [jornada] [profesores]
        /// </summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// [get] devuelve el listado de alumnos
        /// [set] agrega un listado de alumnos a la universidad
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// [get] devuelve el listado de profesores
        /// [set] agrega un listado de profesores a la universidad
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// [get] devuelve el listado de jornadas
        /// [set] agrega un listado de jornadas a la universidad
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Propiedad para acceder a una jornada específica a través de un indexador.
        /// Se la invoca escribiendo Universidad u[i]
        /// [get] Retorna la jornada en el indice [i]
        /// [set] Setea la jornada en el indie [i]
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i]; // retorno la jornada en el índice solicitado
            }
            set
            {
                this.jornada[i] = value;
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Guardará los datos de la Jornada en un archivo xml.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;

            if (!(uni is null))
            {
                Xml<Universidad> xml = new Xml<Universidad>();
                retorno = xml.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", uni);
            }

            return retorno;
        }

        /// <summary>
        /// Retornará los datos de la Jornada como tipo genérico.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad retorno = null;

            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", out retorno);

            return retorno;
        }

        /// <summary>
        /// Devuelve un string con todos los datos de Universidad
        /// [alumnos] [jornada] [profesores]
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder retorno = new StringBuilder();

            // solo recorro Jornada porque ahí se imprimen TODOS los datos:
            retorno.AppendLine("JORNADA:"); // esta línea se imprime solo una vez por universidad
            foreach (Jornada jornada in uni.jornada)
            {
                retorno.Append(jornada.ToString());
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Devuelve un string con todos los datos de Universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Un Universidad será distinto de un Alumno si el mismo NO está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            bool retorno = true;

            if(g.alumnos.Contains(a)) // si el alumno a está contenido en la lista de alumnos de universidad g
            {
                retorno = false; // es falso que g es distinto de a
            }

            return retorno;
        }

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            return !(g != a);
        }

        /// <summary>
        /// Un Universidad será distinto de un Profesor si el mismo NO está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            bool retorno = true;            
            
            if(g.profesores.Contains(i))
            {
                retorno = false;
            }

            return retorno;
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            return !(g != i);
        }

        /// <summary>
        /// Retornará el primer Profesor capaz de dar esa clase.
        /// Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            // recorro la lista de profesores en u y me fijo si ese profesor es capaz de dar la clase pasada por parámetro:

            foreach(Profesor profe in u.profesores)
            {
                if (profe == clase) // en la sobrecarga == de Profesor: un Profesor será igual a un EClase si da esa clase
                {
                    return profe;
                }
            }

            throw new SinProfesorException(); // si llega hasta acá es porque no encontró un profe que de esa clase
        }

        /// <summary>
        /// Retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach(Profesor profe in u.profesores)
            {
                if(profe != clase)
                {
                    return profe;
                }
            }

            throw new SinProfesorException(); // si llega hasta acá es porque todos los profes pueden dar esa clase (?
        }

        /// <summary>
        /// Agrega una clase a un Universidad.
        /// Genera y agrega: 
        /// 1) una nueva Jornada indicando la clase y
        /// 2) un Profesor que pueda darla (según su atributo ClasesDelDia). 
        /// 3) La lista de alumnos que la toman (todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            // genero una nueva Jornada indicando la clase y un profe disponible
            Jornada nuevaJornada = new Jornada(clase, g == clase);
                                            // g == clase retorna el primer profesor capaz de darla, usando clasesDelDia, porque:
                                            // 1) g == clase usa profe == clase
                                            // 2) profe == clase usa clasesDelDia

            // lista de alumnos que toman la clase (todos los que coincidan en su campo ClaseQueToma):
            foreach(Alumno alumno in g.alumnos) // recorro el listado de alumnos
            {
                if(alumno == clase) // el == usa claseQueToma
                {
                    nuevaJornada.Alumnos.Add(alumno); // agrego cada alumno que esté tomando esa clase
                }
            }

            // por último, agrego la nueva jornada a la universidad g:
            g.Jornadas.Add(nuevaJornada);

            return g;
        }

        /// <summary>
        /// Agrega alumnos validando que no estén previamente cargados.
        /// Si ya figura en la lista, lanza la excepción AlumnoRepetidoException.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a) // si no está cargado...
            {
                u.alumnos.Add(a); // ...lo cargo
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// Agrega profesores validando que no estén previamente cargados.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        #endregion

        #region Tipos Anidados

        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        #endregion
    }
}
