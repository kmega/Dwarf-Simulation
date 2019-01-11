using System.Collections.Generic;

namespace BattleShips
{
    public class Player
    {
        public List<string> FieldUsedByPlayer { get; set; }
        public List<string> FieldWithDestroyedShips { get; set; }
        public List<string> FieldWithShips { get; set; }
        public bool IsActive { get; set; }
    }
}