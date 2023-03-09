using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Tests
{
    [TestClass()]
    public class OperacionesTests
    {
        [TestMethod()]
        public void DividirTest()
        {
            int num1 = 10;
            int num2 = 5;
            int resultadoObtenido = 0;
            int resultadoEsperado = 2;

            Operaciones operaciones = new Operaciones();

            resultadoObtenido = operaciones.Dividir(num1, num2);
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }
    }
}