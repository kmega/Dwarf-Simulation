using System.Xml.Linq;
using barcos;
using barcos.Enums;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class ShipTests
    {
        [Test]
        public void CreateTwoMastShipAndCheckHisState()
        {
            ShipFactory shipFactory = new ShipFactory();
            
            IShip newShip = shipFactory.CreateTwoMastsShip(ShipOrientation.horizontally, 1,2);
            Assert.IsTrue(newShip.GetCurrentState() == 2);
        }
        [Test]
        public void CreateThreeMastShipAndCheckHisState()
        {
            ShipFactory shipFactory = new ShipFactory();
            
            IShip newShip = shipFactory.CreateThreeMastsShip(ShipOrientation.horizontally, 1,2);
            Assert.IsTrue(newShip.GetCurrentState() == 3);
        }
        [Test]
        public void CreateFourMastShipAndCheckHisState()
        {
            ShipFactory shipFactory = new ShipFactory();
            
            IShip newShip = shipFactory.CreateFourMastsShip(ShipOrientation.horizontally, 1,2);
            Assert.IsTrue(newShip.GetCurrentState() == 4);
        }
        [Test]
        public void CreateFourFiveShipAndCheckHisState()
        {
            ShipFactory shipFactory = new ShipFactory();
            
            IShip newShip = shipFactory.CreateFiveMastsShip(ShipOrientation.horizontally, 1,2);
            Assert.IsTrue(newShip.GetCurrentState() == 5);
        }

        [Test]
        public void FiveMastShipGetOneHit()
        {
            ShipFactory shipFactory = new ShipFactory();
            
            IShip newShip = shipFactory.CreateFiveMastsShip(ShipOrientation.horizontally, 1,2);
            
            newShip.HasHit();
            
            Assert.IsTrue(newShip.GetCurrentState() == 4);
        }
        [Test]
        public void FiveMastShipGetsFiveHitsAndDestroy()
        {
            ShipFactory shipFactory = new ShipFactory();
            
            IShip newShip = shipFactory.CreateFiveMastsShip(ShipOrientation.horizontally, 1,2);

            for (int i = 0; i < 5; i++)
            {
                newShip.HasHit();
            }
            
            Assert.IsTrue(newShip.Destroyed);
        }
        [Test]
        public void FightTest()
        {
            FieldsStatus[,] Fields = new FieldsStatus[9,9];

            ShipFactory shipFactory = new ShipFactory();
            
            IShip newShip = shipFactory.CreateFiveMastsShip(ShipOrientation.vertically, 1,2);

            if (newShip.Orientation == ShipOrientation.vertically)
            {
                for (int i = newShip.CoordinatesX; i < (int)newShip.Masts; i++)
                {
                    Fields[i,newShip.CoordinatesY] = FieldsStatus.ship;
                }
            }

            Assert.IsTrue(Shoot(2, 2, Fields, newShip));
            
                       
        }

        public bool Shoot(int x, int y, FieldsStatus[,] fieldsStatuses, IShip ship)
        {
            if (fieldsStatuses[x, y] == FieldsStatus.ship)
            {
                fieldsStatuses[x, y] = FieldsStatus.hit;
                ship.HasHit();

                return true;
            }

            return false;
        }
        
        
    }
}