using NUnit.Framework;
using DwarfSimulation;
using System.Collections.Generic;

namespace DiningRoomTest
{
    public class DiningRoomTest
    {
        List<Dwarf> CreateDwarves(int howManyDwarves)
        {
            Builder builder = new Builder();
            return builder.CreateDwarves(howManyDwarves);
        }

        [Test]
        public void OneDwarfEatInDinningRoom()
        {
            //given
            List<Dwarf> dwarves = CreateDwarves(1);
            dwarves[0].Wallet = 10;
            Raport raport = new Raport();
            raport.FoodInDiningRoom = 200;
            DiningRoom diningRoom = new DiningRoom();

            //when
            Assert.AreEqual(diningRoom.CanEat(dwarves, raport), true);
            diningRoom.DwarfsEat(dwarves, raport);

            //then
            Assert.AreEqual(raport.FoodInDiningRoom, 199);
            Assert.AreEqual(raport.FoodEaten, 1);
        }

        [Test]
        public void TwoDwarvesEatInDinningRoomTwoDwarvesDontEat()
        {
            //given
            List<Dwarf> dwarves = CreateDwarves(4);
            dwarves[0].Wallet = 10;
            dwarves[1].Wallet = 10;
            dwarves[2].Wallet = 0;
            dwarves[3].Wallet = 0;
            Raport raport = new Raport();
            raport.FoodInDiningRoom = 200;
            DiningRoom diningRoom = new DiningRoom();

            //when
            Assert.AreEqual(diningRoom.CanEat(dwarves, raport), true);
            diningRoom.DwarfsEat(dwarves, raport);

            //then
            Assert.AreEqual(raport.FoodInDiningRoom, 198);
            Assert.AreEqual(raport.FoodEaten, 2);
        }

        [Test]
        public void ReturnFalseWhenDwarvesCantEat()
        {
            //given
            List<Dwarf> dwarves = CreateDwarves(4);
            dwarves[0].Wallet = 10;
            dwarves[1].Wallet = 10;
            dwarves[2].Wallet = 10;
            dwarves[3].Wallet = 10;
            Raport raport = new Raport();
            raport.FoodInDiningRoom = 3;
            DiningRoom diningRoom = new DiningRoom();

            //when
            bool result = diningRoom.CanEat(dwarves, raport);
;

            //then
            Assert.AreEqual(result, false);
        }

        [Test]
        public void AllDwarvesEatInDiningRoom()
        {
            //given
            List<Dwarf> dwarves = CreateDwarves(5);
            dwarves[0].Wallet = 10;
            dwarves[1].Wallet = 10;
            dwarves[2].Wallet = 5;
            dwarves[3].Wallet = 5;
            dwarves[4].Wallet = 5;
            Raport raport = new Raport();
            raport.FoodInDiningRoom = 200;
            DiningRoom diningRoom = new DiningRoom();

            //when
            Assert.AreEqual(diningRoom.CanEat(dwarves, raport), true);
            diningRoom.DwarfsEat(dwarves, raport);

            //then
            Assert.AreEqual(raport.FoodInDiningRoom, 195);
            Assert.AreEqual(raport.FoodEaten, 5);
        }

        [Test]
        public void NobodyEatInDiningRoom()
        {
            //given
            List<Dwarf> dwarves = CreateDwarves(5);
            dwarves[0].Wallet = 0;
            dwarves[1].Wallet = 0;
            dwarves[2].Wallet = 0;
            dwarves[3].Wallet = 0;
            dwarves[4].Wallet = 0;
            Raport raport = new Raport();
            raport.FoodInDiningRoom = 200;
            DiningRoom diningRoom = new DiningRoom();

            //when
            Assert.AreEqual(diningRoom.CanEat(dwarves, raport), true);
            diningRoom.DwarfsEat(dwarves, raport);

            //then
            Assert.AreEqual(raport.FoodInDiningRoom, 200);
            Assert.AreEqual(raport.FoodEaten, 0);
        }

    }
}