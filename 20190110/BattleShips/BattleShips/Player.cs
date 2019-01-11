using System;
using System.Collections.Generic;

namespace BattleShips
{
    public class Player
    {
<<<<<<< HEAD
=======
        public Player()
        {
            FieldUsedByPlayer = new List<string>();
            FieldWithDestroyedShips = new List<string>();
            FieldWithShips = new List<string>();
        }
        public string PlayerName { get; set; }
>>>>>>> 20190110/GPS-MPochrzest
        public List<string> FieldUsedByPlayer { get; set; }

        public List<string> FieldWithDestroyedShips { get; set; }

        public List<string> FieldWithShips { get; set; }

        public bool IsActive { get; set; }

        public string PlayerName { get; set; }

        public Player()
        {
            FieldUsedByPlayer = new List<string>();
            FieldWithDestroyedShips = new List<string>();
            FieldWithShips = new List<string>();
        }

        public override bool Equals(object obj)
        {
            var player = obj as Player;
            return player != null &&
                   EqualityComparer<List<string>>.Default.Equals(FieldUsedByPlayer, player.FieldUsedByPlayer) &&
                   EqualityComparer<List<string>>.Default.Equals(FieldWithDestroyedShips, player.FieldWithDestroyedShips) &&
                   EqualityComparer<List<string>>.Default.Equals(FieldWithShips, player.FieldWithShips) &&
                   IsActive == player.IsActive &&
                   PlayerName == player.PlayerName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FieldUsedByPlayer, FieldWithDestroyedShips, FieldWithShips, IsActive, PlayerName);
        }
    }
}