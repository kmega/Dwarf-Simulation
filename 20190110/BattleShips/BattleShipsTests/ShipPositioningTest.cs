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
        public void ShouldProperlyPlaceSingleShip()
        {
            //given:
            string type = "c";
            string startPosition = "B5";
            string direction = "d";
            Ship actual = new ShipFactory().PlaceSingleShip(type, startPosition, direction);

            Assert.IsTrue(actual.OccupiedPositions[0] == startPosition);
            Assert.IsTrue(actual.OccupiedPositions.Contains("B9"));
        }
    }
}