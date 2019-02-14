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
        Dwarf dwarf;
        City city = new City();
        


        [TestMethod]
        public void IsBornFatherDwarf()
        {
            var mock = new Mock<Randomizer>();
            mock.Setup(x => x.GetRandomNumber()).Returns(1);

            List<Dwarf> dwarfs = new List<Dwarf>();
            Hospital hospital = new Hospital(dwarfs);
            //City city = new City();

            hospital.BirthDwarf(dwarfs, mock.Object);
            //hospital.BirthDwarf(dwarfs)

            //mock.Setup(x => x.GetRandomNumber()).Returns(1);

            int expected = 11;
            int result = dwarfs.Count();
            //City.randomizer.IsDwarfBorn()
            //randomizer.RandomNumber = 1;
            //Dwarf dwarf = ;
            ////expected
            //TypeEnum expected = TypeEnum.Father;
            ////result           
            //TypeEnum result = dwarf.Type;           

            Assert.AreEqual(expected,result);
        }

        //[TestMethod]
        //public void IsTenDwarfsBorn()
        //{           
        //    int expected = 10;
        //    int result = city.dwarfs.Count;
        //    Assert.AreEqual(expected, result);
        //}
    }
}
