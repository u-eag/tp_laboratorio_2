using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using EntidadesAbstractas;
using Excepciones;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// test unitario que valida la excepción DniInvalidoException al instanciar un Profesor
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ProfesorConDniInvalido()
        {
            Profesor profesor = new Profesor(1, "Fede", "Davila", "100123000", Persona.ENacionalidad.Argentino);
                                                                // el dni es mayor a 100 millones
        }

        /// <summary>
        /// test unitario que valida la excepción NacionalidadInvalidaException
        /// cargando un dni menor a 90 millones y nacionalidad extranjero
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void AlumnoConNacionalidadInvalida()
        {
            Alumno alumno = new Alumno(1, "Lucas", "Rodriguez", "12345678", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
        }

        /// <summary>
        /// test unitario que valida que valida el valor numérico de un dni
        /// </summary>
        [TestMethod]
        public void TestDniStringToInt()
        {
            Profesor profesor = new Profesor(1, "Fede", "Davila", "30123000", Persona.ENacionalidad.Argentino);
            int dniEsperado = 30123000;
            Assert.AreEqual(profesor.DNI, dniEsperado);
        }

        /// <summary>
        /// test unitario que valida que no haya valores nulos en algún atributo de la clase
        /// </summary>
        [TestMethod]
        public void TestCamposUniversidadNotNull()
        {
            Universidad utn = new Universidad();

            Assert.IsNotNull(utn.Alumnos);
            Assert.IsNotNull(utn.Instructores);
            Assert.IsNotNull(utn.Jornadas);

        }
    }
}
