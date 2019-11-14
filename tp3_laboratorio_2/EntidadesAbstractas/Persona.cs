using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; // para validar nombre y apellido
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Campos

        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        #endregion

        #region Propiedades

        /// <summary>
        /// [get] Devuelve el apellido
        /// [set] Valida que el apellido sea una cadena con caracteres válidos. 
        ///       Caso contrario, no se carga.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if ( ValidarNombreApellido(value) != "")
                {
                    this.apellido = value;
                }
            }
        }

        /// <summary>
        /// [get] Devuelve el dni
        /// [set] Valida que el dni sea correcto [1-99999999] 
        ///       para la nacionalidad [Argentino] [Extranjero]
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// [get] Devuelve la nacionalidad [Argentino] [Extranjero]
        /// [set] Setea la nacionalidad [Argentino] [Extranjero]
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// [get] Devuelve el nombre
        /// [set] Valida que el nombre sea una cadena con caracteres válidos. 
        ///       Caso contrario, no se carga.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (ValidarNombreApellido(value) != "")
                {
                    this.nombre = value;
                }
            }
        }

        /// <summary>
        /// [set] Recibe el dni en formato string y valida que sea esté ok
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor que recibe 3 parámetros
        /// y settea los campos a través de las propiedades
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor con todos los parámetros [4]
        /// y settea los campos a través de las propiedades
        /// [dni] es de tipo entero
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor con todos los parámetros [4]
        /// y settea los campos a través de las propiedades
        /// [dni] es de tipo string
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Sobrecarga con los datos que se van a imprimir por pantalla de una Persona
        /// [nombre] [apellido] [nacionaldiad]
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.apellido, this.nombre);
            retorno.AppendFormat("\nNACIONALIDAD: {0}\n", this.nacionalidad);
            

            return retorno.ToString();
        }

        /// <summary>
        /// Valida que el [int]dni sea válido en sí mismo y también para la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno;

            if(nacionalidad == ENacionalidad.Argentino
                && dato >= 1 && dato <= 89999999)
            {
                retorno = dato;
            }
            else if (nacionalidad == ENacionalidad.Extranjero
                && dato >= 90000000 && dato <= 99999999)
            {
                retorno = dato;
            }
            else if (dato >= 1 && dato <= 99999999) // lanza la excepción NacionalidadInvalidaException
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                // el DNI no es correcto, teniendo en cuenta su nacionalidad
            }
            else // lanza la excepción DniInvalidoException
            {
                throw new DniInvalidoException();
                // error de formato (más caracteres de los permitidos, letras, etc.)    
            }

            return retorno;
        }

        /// <summary>
        /// Valida que el [string]dni sea válido en sí mismo y también para la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno;

            if ( int.TryParse(dato, out int datoInt) )
            {
                retorno = ValidarDni(nacionalidad, datoInt);
            }
            else // lanza la excepción DniInvalidoException
            {
                throw new DniInvalidoException();
                // error de formato (más caracteres de los permitidos, letras, etc.)    
            }

            return retorno;
        }

        /// <summary>
        /// Valida que los nombres sean caractéres válidos:
        /// [mayúsculas] [minúsculas] [acentos] [espacios] [apóstrofes] [guión medio]
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = ""; // por defecto retorna un string vacío
            string validar = "^[A-Za-zÁ-ú\x20\x2D\x27]"; // [\x20]=espacio [\x2D]=guión medio [\x27]=apóstrofe

            if (Regex.IsMatch(dato, validar))
            {
                retorno = dato;
            }

            return retorno;
        }

        #endregion

        #region Tipos anidados

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        #endregion
    }
}
