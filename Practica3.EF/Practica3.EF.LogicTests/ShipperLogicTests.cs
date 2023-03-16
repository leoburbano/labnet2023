using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica3.EF.Data;
using Practica3.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3.EF.Logic.Tests
{
    [TestClass()]
    public class ShipperLogicTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            using (var contexto = new NorthwindContext())
            {
                var shippers = contexto.Shippers.ToList();

                Assert.AreEqual(3, shippers.Count);
                Assert.AreEqual("Speedy Express", shippers[0].CompanyName);
                Assert.AreEqual("United Package", shippers[1].CompanyName);
                Assert.AreEqual("Federal Shipping", shippers[2].CompanyName);
            }

          
        }
    }
}