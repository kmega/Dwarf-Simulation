using DwarfsTown;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace DwarfsTownTests
{
    [TestClass]
    public class HospitalTests
    {        
        City city = new City();

        [TestMethod]
        public void IsBornDwarf()
        {
            var mock = new Mock<Randomizer>();
            mock.Setup(x => x.GetRandomNumber()).Returns(1);

            List<Dwarf> dwarfs = new List<Dwarf>();
            Hospital hospital = new Hospital(dwarfs);
            hospital.BirthDwarf(dwarfs, mock.Object);

            int expected = 11;
            int result = dwarfs.Count();

            Assert.AreEqual(expected,result);
        }
        [TestMethod]
        public void IsBorn10Dwarfs()
        {
            List<Dwarf> dwarfs = new List<Dwarf>();
            Hospital hospital = new Hospital(dwarfs);
            
            int expected = 10;
            int result = dwarfs.Count();

            Assert.AreEqual(expected, result);
        }
    }
}
