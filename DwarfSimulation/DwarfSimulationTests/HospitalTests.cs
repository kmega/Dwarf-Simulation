using NUnit.Framework;
using DwarfSimulation;
using System.Collections.Generic;
using Moq;

namespace HospitalTests
{
    public class HospitalTests
    {
        Randomizer randomizer = new Randomizer();

        List<Dwarf> CreateDwarves(int howManyDwarves)
        {
            Builder builder = new Builder();
            return builder.CreateDwarves(howManyDwarves);
        }

        [Test]
        public void DwarfIsBorn()
        {
            //given
            List<Dwarf> dwarves = CreateDwarves(10);
            Assert.AreEqual(dwarves.Count, 10);
            Mock<IBornRandomizer> IsBorn = new Mock<IBornRandomizer>();
            IsBorn.Setup(b => b.IsBorn()).Returns(true);
            Raport raport = new Raport();
            Assert.AreEqual(raport.TotalBorn, 0);

            //when
            Hospital hospital = new Hospital(IsBorn.Object);
            dwarves = hospital.BornDwarf(dwarves, raport);

            //then
            Assert.AreEqual(dwarves.Count, 11);
            Assert.AreEqual(raport.TotalBorn, 1);
        }

        [Test]
        public void DwarfIsntBorn()
        {
            //given
            List<Dwarf> dwarves = CreateDwarves(10);
            Assert.AreEqual(dwarves.Count, 10);
            Mock<IBornRandomizer> IsBorn = new Mock<IBornRandomizer>();
            IsBorn.Setup(b => b.IsBorn()).Returns(false);
            Raport raport = new Raport();
            Assert.AreEqual(raport.TotalBorn, 0);

            //when
            Hospital hospital = new Hospital(IsBorn.Object);
            dwarves = hospital.BornDwarf(dwarves, raport);

            //then
            Assert.AreEqual(dwarves.Count, 10);
            Assert.AreEqual(raport.TotalBorn, 0);
        }


    }
}