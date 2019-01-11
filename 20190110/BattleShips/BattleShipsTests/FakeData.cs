using BattleShips;
using System.Collections.Generic;

namespace BattleShipsTests
{
    internal class FakeData
    {
        public static List<Player> CreateFakeData()
        {
            Player player1 = new Player();
            Player player2 = new Player();
            List<Player> players = new List<Player>();
            player1.FieldWithShips.Add("A1");
            player1.FieldWithShips.Add("A2");
            player1.FieldWithShips.Add("A3");

            player2.FieldWithShips.Add("B1");
            player2.FieldWithShips.Add("B2");
            player2.FieldWithShips.Add("B3");

            players.Add(player1);
            players.Add(player2);

            return players;
        }
    }
}