using System;
using BetterBattleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBetterBattleships
{
    [TestClass]
    public class TestsSettingShipsOnBoard
    {
        [TestMethod]
        public void SetCarrierUpWithProvidedGiven()
        {
            //given
            BoardFactory Board = new BoardFactory();
            CellStatus[,] defaultBoard = Board.Create();
            ShipTypes ship = ShipTypes.Carrier;
            string direction = "w";
            int[] coords = { 5, 5 };
            IBoardPlacer boardPlacer = new BoardPlacer();

            //when
            new BoardPlacer().ExecuteShipPlacement(direction, coords, ship, defaultBoard);

            //then
            Assert.AreEqual(CellStatus.DECK, boardPlacer.GetCurrentCellStatus(new int[] { 5, 5 }, defaultBoard));
            Assert.AreEqual(CellStatus.DECK, boardPlacer.GetCurrentCellStatus(new int[] { 4, 5 }, defaultBoard));
            Assert.AreEqual(CellStatus.DECK, boardPlacer.GetCurrentCellStatus(new int[] { 3, 5 }, defaultBoard));
            Assert.AreEqual(CellStatus.DECK, boardPlacer.GetCurrentCellStatus(new int[] { 2, 5 }, defaultBoard));
            Assert.AreEqual(CellStatus.DECK, boardPlacer.GetCurrentCellStatus(new int[] { 1, 5 }, defaultBoard));
        }

        [TestMethod]
        public void SetCarrierDownWithProvidedGiven()
        {
            //given
            BoardFactory Board = new BoardFactory();
            CellStatus[,] defaultBoard = Board.Create();
            ShipTypes ship = ShipTypes.Carrier;
            string direction = "s";
            int[] coords = { 5, 5 };
            IBoardPlacer boardPlacer = new BoardPlacer();

            //when
            new BoardPlacer().ExecuteShipPlacement(direction, coords, ship, defaultBoard);

            //then
            Assert.AreEqual(CellStatus.DECK, boardPlacer.GetCurrentCellStatus(new int[] { 5, 5 }, defaultBoard));
            Assert.AreEqual(CellStatus.DECK, boardPlacer.GetCurrentCellStatus(new int[] { 6, 5 }, defaultBoard));
            Assert.AreEqual(CellStatus.DECK, boardPlacer.GetCurrentCellStatus(new int[] { 7, 5 }, defaultBoard));
            Assert.AreEqual(CellStatus.DECK, boardPlacer.GetCurrentCellStatus(new int[] { 8, 5 }, defaultBoard));
            Assert.AreEqual(CellStatus.DECK, boardPlacer.GetCurrentCellStatus(new int[] { 9, 5 }, defaultBoard));
        }

        [TestMethod]
        public void SetCarrierLeftWithProvidedGiven()
        {
            //given
            BoardFactory Board = new BoardFactory();
            CellStatus[,] defaultBoard = Board.Create();
            ShipTypes ship = ShipTypes.Subarine;
            string direction = "a";
            int[] coords = { 5, 5 };
            IBoardPlacer boardPlacer = new BoardPlacer();

            //when
            new BoardPlacer().ExecuteShipPlacement(direction, coords, ship, defaultBoard);

            //then
            Assert.AreEqual(CellStatus.DECK, boardPlacer.GetCurrentCellStatus(new int[] { 5, 5 }, defaultBoard));
            Assert.AreEqual(CellStatus.DECK, boardPlacer.GetCurrentCellStatus(new int[] { 5, 4 }, defaultBoard));
        }

        [TestMethod]
        public void SetCarrierRightWithProvidedGiven()
        {
            //given
            BoardFactory Board = new BoardFactory();
            CellStatus[,] defaultBoard = Board.Create();
            ShipTypes ship = ShipTypes.Subarine;
            string direction = "d";
            int[] coords = { 5, 5 };
            IBoardPlacer boardPlacer = new BoardPlacer();

            //when
            new BoardPlacer().ExecuteShipPlacement(direction, coords, ship, defaultBoard);

            //then
            Assert.AreEqual(CellStatus.DECK, boardPlacer.GetCurrentCellStatus(new int[] { 5, 5 }, defaultBoard));
            Assert.AreEqual(CellStatus.DECK, boardPlacer.GetCurrentCellStatus(new int[] { 5, 6 }, defaultBoard));
        }

    }
}
