using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips
{
    public class Game
    {
        public void StartGame(List<Player> players)
        {
            SetActivePlayerOne(players);



            while (players.Count > 1)
            {
                //field from UI
                //NextTurn(players, field);
            }


            
        }

        private void NextTurn(List<Player> players, string field)
        {
            if (CheckIfPlayersHasShips(players))
            {
                MakeShoot(field, players);

            } else {
                Player activePlayer = ActivePlayer(players);
                Console.WriteLine($"The winner is {activePlayer.PlayerName}");
            }



        }

        private bool CheckIfPlayersHasShips(List<Player> players)
        {
            return players.Any(p => p.FieldWithShips.Count > 0);
        }

        private void MakeShoot(string field, List<Player> players)
        {
            ActivePlayer(players).FieldUsedByPlayer.Add(field);

            if (field.Equals(players.Where(p => p.IsActive == false).First().FieldWithShips))
            {
                MoveFieldFromOneListToAnother(players[1].FieldWithShips, players[1].FieldWithDestroyedShips, field);
            }
            else
            {
                ChangeActivePlayer(players);
            }
        }

        private void ChangeActivePlayer(List<Player> players)
        {
            players.Select(p => !p.IsActive);
        }

        private static void SetActivePlayerOne(List<Player> players)
        {
            players[0].IsActive = true;
        }

        private static Player ActivePlayer(List<Player> players)
        {
            return players.Where(p => p.IsActive == true).First();
        }

        public bool IsFieldOnList(List<string> strings, string field)
        {
            return strings.Any(s => s.Equals(field));
        }

        public void MoveFieldFromOneListToAnother(List<string> sourceList, List<string> resultList, string field)
        {
            sourceList.Remove(field);
            resultList.Add(field);
        }
    }
}