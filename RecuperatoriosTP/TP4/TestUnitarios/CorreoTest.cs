using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class CorreoTest
    {
        /// <summary>
        /// Test que verifica que la lista de Paquetes del Correo esté instanciada.
        /// </summary>
        [TestMethod]
        public void TestListaPaquetesInstanciada()
        {
            // instancio un objeto de tipo Correo
            Correo c = new Correo();

            // el constructor debería haber inicializado la lista
            Assert.IsNotNull(c.Paquetes); // chequeo que no sea nula
        }

        /// <summary>
        /// Test que verifica que no se puedan cargar dos Paquetes con el mismo Tracking ID.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestPaqueteRepetido()
        {
            Correo c = new Correo();

            // instancio dos objetos de tipo Paquete con el mismo tracking id:
            Paquete p1 = new Paquete("direccion1", "123");
            Paquete p2 = new Paquete("direccion2", "123");

            // agrego los paquetes a la lista:
            c += p1;
            c += p2;
        }
    }
}
