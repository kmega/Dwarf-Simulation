using BattleShips;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldPlaceVerticallyCarrierShipWithDirectionDown()
        {
            //given:
            string type = "c";
            string startPosition = "B5";
            string direction = "d";

            Ship actual = new ShipFactory().PlaceSingleShip(type, startPosition, direction);

            Assert.IsTrue(actual.OccupiedPositions[0] == startPosition);
            Assert.IsTrue(actual.OccupiedPositions.Contains("B9"));
            Assert.IsTrue(actual.Type == BattleShips.Enums.ShipType.Carrier);
        }
        [Test]
        public void ShouldPlaceVerticallyBattleShipWithDirectionUp()
        {
            //given:
            string type = "B";
            string startPosition = "G9";
            string direction = "u";

            Ship actual = new ShipFactory().PlaceSingleShip(type, startPosition, direction);

            Assert.IsTrue(actual.OccupiedPositions[0] == startPosition);
            Assert.IsTrue(actual.OccupiedPositions.Contains("G6"));
            Assert.IsTrue(actual.Type == BattleShips.Enums.ShipType.BattleShip);
        }

    }
}