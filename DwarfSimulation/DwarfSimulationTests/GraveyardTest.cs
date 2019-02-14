using NUnit.Framework;
using DwarfSimulation;
using System.Collections.Generic;

namespace GrabeyardTest
{
    public class GrabeyardTest
    {
         List<Dwarf> Setup()
        {
            Builder builder = new Builder();
            return builder.CreateDwarves(10);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}