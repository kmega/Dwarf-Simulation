using BetterBattleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestBetterBattleships
{
    [TestClass]
    public class TestsPlayerFactory
    {
        //[TestMethod]
        //public void Creates_New_Player_With_Name_And_Empty_Board()
        //{
        //    //given
        //    Mock<IPlayer> objPlayer = new Mock<IPlayer>();
        //    Mock<IInput> objInput = new Mock<IInput>();
        //    objInput.Setup(x => x.SetNameForNewPlayer()).Returns("AmazedPlayer");

        //    //when
        //    IPlayer player = new Player(objInput.Object);

        //    //then
        //    Assert.AreEqual("AmazedPlayer", player.Name);
        //    Assert.AreEqual(CellStatus.EMPTY, player.GetCurrentCellStatus(new int[] { 0, 0 }));
        //}

        //[TestMethod]
        //public void Creates_Player_And_Sets_Ship_Up()
        //{
        //    //given
        //    Mock<IPlayer> objPlayer = new Mock<IPlayer>();
        //    Mock<IInput> objInput = new Mock<IInput>();

        //    objPlayer.Setup(x => x.GetDirectionsForCoordinates()).Returns("w");
        //    objPlayer.Setup(x => x.GetCoordinatesToSetShip()).Returns(new int[] { 4, 0 });
        //    objPlayer.Setup(x => x.GetPlayerName()).Returns("QWE");
        //    objInput.Setup(x => x.SetNameForNewPlayer()).Returns("QWE");

        //    IPlayer player = new Player(objInput.Object);
        //    //when
        //    player.SetShipsOnBoard(objPlayer.Object);

        //    //then
        //    Assert.AreEqual(CellStatus.DECK, player.GetCurrentCellStatus(new int[] { 4, 0 }));
        //    Assert.AreEqual(CellStatus.DECK, player.GetCurrentCellStatus(new int[] { 3, 0 }));
        //    Assert.AreEqual(CellStatus.DECK, player.GetCurrentCellStatus(new int[] { 2, 0 }));
        //    Assert.AreEqual(CellStatus.DECK, player.GetCurrentCellStatus(new int[] { 1, 0 }));
        //    Assert.AreEqual(CellStatus.DECK, player.GetCurrentCellStatus(new int[] { 0, 0 }));
        //    Assert.AreEqual("QWE", player.Name);
        //}

        
        [TestMethod]
        public void CreatesPlayerWithDefaultName()
        {
            //given
            PlayerFactory playerFactory = new PlayerFactory();

            //when
            var player = playerFactory.ProducePlayer();

            //then
            Assert.AreEqual(player.Name, "defaultName");
        }

        [TestMethod]
        public void CreatesPlayerWithCustomName()
        {
            //given
            PlayerFactory playerFactory = new PlayerFactory();

            //when
            var player = playerFactory.ProducePlayer("Fryderyk Komciur");

            //then
            Assert.AreEqual(player.Name, "Fryderyk Komciur");
        }




    }

    //public class FakePlayer : IPlayer
    //{


    //    public string Name => throw new System.NotImplementedException();

    //    public void DisplayBoard()
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public int[] GetCoordinatesToSetShip()
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public CellStatus GetCurrentCellStatus(int[] coords)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public string GetDirectionsForCoordinates()
    //    {
    //        return "d";
    //    }

    //    public string GetPlayerName()
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public CellStatus SetCellEmptyStatus()
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public void SetShipsOnBoard(IPlayer player)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}
}
