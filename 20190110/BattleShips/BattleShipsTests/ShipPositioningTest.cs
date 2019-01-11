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
            Player player = new Player()
            {
                PlayerName = "Marcin"
            };
            //when
            ShipFactory actual = new ShipFactory();
            actual.PlaceSingleShip(type, startPosition, direction, player);
            //then
            Assert.IsTrue(player.PlayerName == "Marcin");
            Assert.IsTrue(player.FieldWithShips.Contains("B9"));
        }
        [Test]
        public void ShouldPlaceVerticallyBattleShipWithDirectionUp()
        {
            //given:
            string type = "B";
            string startPosition = "G9";
            string direction = "u";
            Player player = new Player()
            {
                PlayerName = "Marcin"
            };
            //when
            ShipFactory actual = new ShipFactory();
            actual.PlaceSingleShip(type, startPosition, direction, player);
            //then
            Assert.IsTrue(player.PlayerName == "Marcin");
            Assert.IsTrue(player.FieldWithShips.Contains("G6"));
        }

    }
}