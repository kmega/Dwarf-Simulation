using System;
using BattleShip;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TestGame
    {
        [TestMethod]
        public void T01CheckDidAfterHitFieldsChangeToFieldEnumF()
        {
            Fight game = new Fight();
            Player player1 = new Player(1);
            Player player2 = new Player(2);
            string coordinatesPlayer1 = "a1";
            string coordinatesPlayer2 = "a1";
            game.TryHitShip(player1, player2, coordinatesPlayer1, coordinatesPlayer2);
            int counter = 0;
            if (player1.Opponent_Board.Fields[0, 0] == Field.F)
            {
                counter++;
            }
            Assert.AreEqual(counter, 1);
        }

        [TestMethod]
        public void T02CheckDidAfterHitFieldsChangeToFieldEnumH()
        {
            Fight game = new Fight();
            Player player1 = new Player(1);
            Player player2 = new Player(2);
            PutShipOnTheBoard putShipOnTheBoard = new PutShipOnTheBoard();
            //Player player, string Coordinates, bool horizontal, int id_ship)
            string cordinatesShipPlayer1= "a1";
            bool horizontal = true;
            int id_ship = 1;
            putShipOnTheBoard.PutShip(player1, cordinatesShipPlayer1, horizontal, id_ship);


            string coordinatesPlayer1 = "a1";
            string coordinatesPlayer2 = "a1";
            game.TryHitShip(player1, player2, coordinatesPlayer1, coordinatesPlayer2);
            int counter = 0;
            if (player2.Opponent_Board.Fields[0, 0] == Field.H)
            {
                counter++;
            }
            Assert.AreEqual(counter, 1);
        }

        [TestMethod]
        public void T03CheckDidTwoPlayerHitShipsEnemyGetResult2()
        {
            Fight game = new Fight();
            Player player1 = new Player(1);
            Player player2 = new Player(2);
            PutShipOnTheBoard putShipOnTheBoard = new PutShipOnTheBoard();
            //Player1 put ship in board
            string cordinatesShipPlayer = "a1";
            bool horizontal = true;
            int id_ship = 1;
            putShipOnTheBoard.PutShip(player1, cordinatesShipPlayer, horizontal, id_ship);
            //Player2 put ship in board
            cordinatesShipPlayer = "b3";
            horizontal = true;
            id_ship = 1;
            putShipOnTheBoard.PutShip(player2, cordinatesShipPlayer, horizontal, id_ship);


            string coordinatesPlayer1 = "b3";
            string coordinatesPlayer2 = "a1";
            game.TryHitShip(player1, player2, coordinatesPlayer1, coordinatesPlayer2);
            int counter = 0;
            if (player2.Opponent_Board.Fields[0, 0] == Field.H)
            {
                counter++;
            }
            if (player1.Opponent_Board.Fields[2, 1] == Field.H)
            {
                counter++;
            }
            Assert.AreEqual(counter, 2);
        }
    }
}
