using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea;

namespace UnitTestProject1
{
    [TestClass]
    public class Task2
    {

        [TestMethod]

        public void IsTeaBuilderWork()
        {
            string input = "Herbata, kolorowa, 33333, 4444";
            TeaBuilder tb = new TeaBuilder();
            var item = tb.AddTea(input);

            Assert.AreEqual("Herbata", item.name);
            Assert.AreEqual("kolorowa", item.type);
            Assert.AreEqual(33333, item.temperature);
            Assert.AreEqual(4444, item.time);


        }

        [TestMethod]
        public void IsTypeSort()
        {

            string input = "Herbata, kolorowa, 33333, 4444";
            string input2 = "HerbataFajna, inaczejkolorowa, 33333, 4444";

            TeaBuilder tb = new TeaBuilder();
            List<TeaObj> list = new List<TeaObj>()
            {
                tb.AddTea(input),
            tb.AddTea(input2)
            };

          list=  list.OrderBy(x => x.type).ToList();

            Assert.AreEqual(input2, list[0].ToString());
            Assert.AreEqual(input, list[1].ToString());
            
            


        }
    }
}
