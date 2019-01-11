using System;

namespace barcos
{
    public class Player
    {
        public Ship[] Ships;
        public Board[] Board;
        public string Name;

        public Player(Hypervisor hypervisor)
        {
            hypervisor.RegisterPlayer(this);
        }

        public void SetShipsOnBoard(Board board, Ship ship)
        {

        }

        public void AttackShipAtCoordinates()
        {

        }
    }
}
