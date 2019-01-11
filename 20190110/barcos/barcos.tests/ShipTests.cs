using barcos;
using barcos.Enums;
using NUnit.Framework;

namespace Tests
{
    public class ShipTests
    {
        [Test]
        public void CreateTwoMastShipAndCheckHisState()
        {
            ShipFactory shipFactory = new ShipFactory();
            
            IShip newShip = shipFactory.CreateTwoMastsShip(ShipOrientation.horizontally, 1);
            Assert.IsTrue(newShip.GetCurrentState() == 2);
        }
        [Test]
        public void CreateThreeMastShipAndCheckHisState()
        {
            ShipFactory shipFactory = new ShipFactory();
            
            IShip newShip = shipFactory.CreateThreeMastsShip(ShipOrientation.horizontally, 1);
            Assert.IsTrue(newShip.GetCurrentState() == 3);
        }
        [Test]
        public void CreateFourMastShipAndCheckHisState()
        {
            ShipFactory shipFactory = new ShipFactory();
            
            IShip newShip = shipFactory.CreateFourMastsShip(ShipOrientation.horizontally, 1);
            Assert.IsTrue(newShip.GetCurrentState() == 4);
        }
        [Test]
        public void CreateFourFiveShipAndCheckHisState()
        {
            ShipFactory shipFactory = new ShipFactory();
            
            IShip newShip = shipFactory.CreateFiveMastsShip(ShipOrientation.horizontally, 1);
            Assert.IsTrue(newShip.GetCurrentState() == 5);
        }

        [Test]
        public void FiveMastShipGetOneHit()
        {
            ShipFactory shipFactory = new ShipFactory();
            
            IShip newShip = shipFactory.CreateFiveMastsShip(ShipOrientation.horizontally, 1);
            
            newShip.HasHit();
            
            Assert.IsTrue(newShip.GetCurrentState() == 4);
        }
        [Test]
        public void FiveMastShipGetsFiveHitsAndDestroy()
        {
            ShipFactory shipFactory = new ShipFactory();
            
            IShip newShip = shipFactory.CreateFiveMastsShip(ShipOrientation.horizontally, 1);

            for (int i = 0; i < 5; i++)
            {
                newShip.HasHit();
            }
            
            Assert.IsTrue(newShip.Destroyed);
        }
    }
}