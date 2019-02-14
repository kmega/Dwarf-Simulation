using NUnit.Framework;
using DwarfSimulation;
using System.Collections.Generic;

namespace GraveyardTest
{
    public class GraveyardTest
    {
         List<Dwarf> Setup(int howManyDwarves)
        {
            Builder builder = new Builder();
            return builder.CreateDwarves(howManyDwarves);
        }

        [Test]
        public void RemoveOneDeadDwarfFromListDwarvesAndAdd1ToRaportDeadCount()
        {
            //given
            List<Dwarf> dwarves = Setup(10);
            dwarves[2].IsAlive = false;
            Raport raport = new Raport();

            //when
            Graveyard graveyard = new Graveyard();
            dwarves = graveyard.DeleteDeadDwarfFromList(dwarves, raport);

            //then
            Assert.AreEqual(raport.DeathCount, 1);
            foreach (var dwarf in dwarves)
            {
                Assert.AreEqual(dwarf.IsAlive, true);
            }
            Assert.AreEqual(dwarves.Count, 9);
        }

        [Test]
        public void RemoveFiveDeadDwarvesFromListDwarvesAndAdd5ToRaportDeadCount()
        {
            //given
            List<Dwarf> dwarves = Setup(10);
            dwarves[2].IsAlive = false;
            dwarves[3].IsAlive = false;
            dwarves[4].IsAlive = false;
            dwarves[5].IsAlive = false;
            dwarves[6].IsAlive = false;
            Raport raport = new Raport();

            //when
            Graveyard graveyard = new Graveyard();
            dwarves = graveyard.DeleteDeadDwarfFromList(dwarves, raport);

            //then
            Assert.AreEqual(raport.DeathCount, 5);
            foreach (var dwarf in dwarves)
            {
                Assert.AreEqual(dwarf.IsAlive, true);
            }
            Assert.AreEqual(dwarves.Count, 5);
        }

        [Test]
        public void NobodyRemoveFromListDwarvesAndAdd0ToRaportDeadCount()
        {
            //given
            List<Dwarf> dwarves = Setup(10);
            Raport raport = new Raport();

            //when
            Graveyard graveyard = new Graveyard();
            dwarves = graveyard.DeleteDeadDwarfFromList(dwarves, raport);

            //then
            Assert.AreEqual(raport.DeathCount, 0);
            foreach (var dwarf in dwarves)
            {
                Assert.AreEqual(dwarf.IsAlive, true);
            }
            Assert.AreEqual(dwarves.Count, 10);
        }

        [Test]
        public void ReturnTrueWhenListIsntEmpty()
        {
            //given
            List<Dwarf> dwarves = Setup(10);

            //when
            Graveyard graveyard = new Graveyard();
            bool result = graveyard.AnybodyLives(dwarves);

            //then
            Assert.AreEqual(result, true);
        }

        [Test]
        public void ReturnFalseWhenListIsEmpty()
        {
            //given
            List<Dwarf> dwarves = Setup(0);

            //when
            Graveyard graveyard = new Graveyard();
            bool result = graveyard.AnybodyLives(dwarves);

            //then
            Assert.AreEqual(result, false);
        }

        [Test]
        public void DeleteAllDeadDwarvesFromListAndReturnFalseFromMethodAndybodyLive()
        {
            //given
            List<Dwarf> dwarves = Setup(3);
            Graveyard graveyard = new Graveyard();

            Assert.AreEqual(graveyard.AnybodyLives(dwarves), true);

            dwarves[0].IsAlive = false;
            dwarves[1].IsAlive = false;
            dwarves[2].IsAlive = false;
            Raport raport = new Raport();

            //when
            dwarves = graveyard.DeleteDeadDwarfFromList(dwarves, raport);
            bool result = graveyard.AnybodyLives(dwarves);

            //then
            Assert.AreEqual(raport.DeathCount, 3);
            Assert.AreEqual(dwarves.Count, 0);
        }
    }
}