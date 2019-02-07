using NUnit.Framework;
using DwarfMineSimulator;
using System.Collections.Generic;

namespace GraveyardTest
{
    public class GraveyardTest
    {
        public List<Dwarf> Setup()
        {
            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf() { Alive = true, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = true, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = true, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 }
            };
            return DwarfsPopulation;
        }

        public List<Dwarf> Setup1()
        {
            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf() { Alive = true, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 }
            };
            return DwarfsPopulation;
        }

        public List<Dwarf> Setup2()
        {
            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 }
            };
            return DwarfsPopulation;
        }

        public List<Dwarf> Setup3()
        {
            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf() { Alive = false, Type = DwarfTypes.Suicider, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 },
                new Dwarf() { Alive = false, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 0 }
            };
            return DwarfsPopulation;
        }


        [Test]
        public void DeleteOneDeadDwarfFromList()
        {
            //Given
            List<Dwarf> DwarfsPopulation = Setup();
            Graveyard graveyard = new Graveyard();

            //When
            DwarfsPopulation = graveyard.DeleteDeadDwarfFromList(DwarfsPopulation);

            //Then
            foreach (var dwarf in DwarfsPopulation)
            {
                Assert.AreEqual(dwarf.Alive, true);
            }

            Assert.AreEqual(graveyard.HowManyDead(), 1);
        }

        [Test]
        public void DeleteManyDeadDwarfFromList()
        {
            //Given
            List<Dwarf> DwarfsPopulation = Setup1();
            Graveyard graveyard = new Graveyard();

            //When
            DwarfsPopulation = graveyard.DeleteDeadDwarfFromList(DwarfsPopulation);

            //Then
            foreach (var dwarf in DwarfsPopulation)
            {
                Assert.AreEqual(dwarf.Alive, true);
            }
            Assert.AreEqual(graveyard.HowManyDead(), 3);
        }

        [Test]
        public void DeleteAllDeadDwarfFromList()
        {
            //Given
            List<Dwarf> DwarfsPopulation = Setup2();
            Graveyard graveyard = new Graveyard();

            //When
            DwarfsPopulation = graveyard.DeleteDeadDwarfFromList(DwarfsPopulation);

            //Then
            foreach (var dwarf in DwarfsPopulation)
            {
                Assert.AreEqual(dwarf.Alive, true);
            }
            Assert.AreEqual(graveyard.HowManyDead(), 4);
        }

        [Test]
        public void DeleteAllDeadDwarfFromListAndSuicider()
        {
            //Given
            List<Dwarf> DwarfsPopulation = Setup3();
            Graveyard graveyard = new Graveyard();

            //When
            DwarfsPopulation = graveyard.DeleteDeadDwarfFromList(DwarfsPopulation);

            //Then
            foreach (var dwarf in DwarfsPopulation)
            {
                Assert.AreEqual(dwarf.Alive, true);
            }
            Assert.AreEqual(graveyard.HowManyDead(), 4);
            Assert.IsEmpty(DwarfsPopulation);
        }

    }
}