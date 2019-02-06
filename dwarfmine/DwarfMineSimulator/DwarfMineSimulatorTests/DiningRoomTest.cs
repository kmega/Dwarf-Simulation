using NUnit.Framework;
using DwarfMineSimulator;
using System.Collections.Generic;

namespace DiningRoomTest
{
    public class DiningRoomTest
    {

        public List<Dwarf> Setup()
        {
            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf() { Alive = true, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay =  10},
                new Dwarf() { Alive = true, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 10 },
                new Dwarf() { Alive = true, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 10 },
                new Dwarf() { Alive = true, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 10 }
            };
            return DwarfsPopulation;
        }
        public List<Dwarf> Setup1()
        {
            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf() { Alive = true, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay =  10},
                new Dwarf() { Alive = true, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 10 },
                new Dwarf() { Alive = true, Type = DwarfTypes.Father, Money = 0, MoneyEarndedThisDay = 10 },
                new Dwarf() { Alive = true, Type = DwarfTypes.Lazy, Money = 0, MoneyEarndedThisDay = 0 }
            };
            return DwarfsPopulation;
        }

        [Test]
        public void AllDwarfsEat()
        {
            //Given
            List<Dwarf> DwarfsPopulation = Setup();
            DiningRoom diningRoom = new DiningRoom();
            int Food = 200;

            //When
            int result = diningRoom.DwarfsEat(Food, DwarfsPopulation);

            Assert.AreEqual(result, 196);
        }

        [Test]
        public void NotAllDwarfsEat()
        {
            //Given
            List<Dwarf> DwarfsPopulation = Setup1();
            DiningRoom diningRoom = new DiningRoom();
            int Food = 200;

            //When
            int result = diningRoom.DwarfsEat(Food, DwarfsPopulation);

            Assert.AreEqual(result, 197);
        }

        [Test]
        public void ReturnFalseWhenMoreDwarfsCanEatThanFood()
        {
            //Given
            List<Dwarf> DwarfsPopulation = Setup1();
            DiningRoom diningRoom = new DiningRoom();
            int Food = 2;

            //When
            bool result = diningRoom.CanEat(Food, DwarfsPopulation);

            Assert.AreEqual(result, false);
        }

        [Test]
        public void ReturnTrueWhenLessDwarfsCanEatThanFoodIs()
        {
            //Given
            List<Dwarf> DwarfsPopulation = Setup1();
            DiningRoom diningRoom = new DiningRoom();
            int Food = 200;

            //When
            bool result = diningRoom.CanEat(Food, DwarfsPopulation);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void OrderedFood()
        {
            //Given
            List<Dwarf> DwarfsPopulation = Setup1();
            DiningRoom diningRoom = new DiningRoom();
            int Food = 9;

            //When
            int result = diningRoom.DwarfsEat(Food, DwarfsPopulation);

            Assert.AreEqual(result, 36);
        }




    }
}