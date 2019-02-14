using NUnit.Framework;
using DwarfSimulation;
using System.Collections.Generic;

namespace HospitalTests
{
    public class HospitalTests
    {

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
            Hospital hospital = new Hospital();

            //when
            dwarves = hospital.BornDwarf(dwarves, true);

            //then
            Assert.AreEqual(dwarves.Count, 11);
        }

        [Test]
        public void DwarfIsntBorn()
        {
            //given
            List<Dwarf> dwarves = CreateDwarves(10);
            Assert.AreEqual(dwarves.Count, 10);
            Hospital hospital = new Hospital();

            //when
            dwarves = hospital.BornDwarf(dwarves, false);

            //then
            Assert.AreEqual(dwarves.Count, 10);
        }
    }
}