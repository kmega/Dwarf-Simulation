using System.Collections.Generic;
using barcosFinal;
using barcosFinal.Enums;
using barcosFinal.Interfaces;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class PlayerTests
    {

        [Test]
        public void PlayerShotAndMiss()
        {

            var board1 = new char[9, 9];
            var board2 = new char[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board1[i, j] = 'o';
                    board2[i, j] = 'o';

                }
            }
            
            IPlayer player1 = new Player()
            {
                BattleField = new BattleField()
                {
                    Board = board1
                },
                Ships = new List<IShip>()
                {
                    new Ship(2, 1,2,Orientation.vertical)
                }
            };

            
            IPlayer player2 = new Player()
            {
                BattleField = new BattleField()
                {
                    Board = board1
                },
                Ships = new List<IShip>()
                {
                    new Ship(2, 1,2,Orientation.vertical)
                }
            };
            Assert.IsTrue('o' == player2.GetCurrentBattleField()[1,2]);
        }
        [Test]
        public void PlayerShotAndHit()
        {

            var board1 = new char[9, 9];
            var board2 = new char[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board1[i, j] = '^';
                    board2[i, j] = '^';

                }
            }
            
            IPlayer player1 = new Player()
            {
                BattleField = new BattleField()
                {
                    Board = board1
                },
                Ships = new List<IShip>()
                {
                    new Ship(2, 1,2,Orientation.vertical)
                }
            };

            
            IPlayer player2 = new Player()
            {
                BattleField = new BattleField()
                {
                    Board = board1
                },
                Ships = new List<IShip>()
                {
                    new Ship(2, 1,2,Orientation.vertical)
                }
            };


            Assert.IsTrue('X' == player2.GetCurrentBattleField()[1,2]);
        }
    }
}