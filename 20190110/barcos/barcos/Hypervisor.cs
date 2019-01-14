using System;
using System.Collections.Generic;
using barcos.Enums;

namespace barcos
{
    public class Hypervisor
    {
        public int TurnCounter; // ??????
        public GameState GameState;
        public List<Player> Players;

        public Hypervisor()
        {
            Players = new List<Player>();
        }


        public void CheckPlayersShipsState()
        {

        }

        public void CheckIfPlayerHitsShip()
        {

        }

        public void ChangeActivePlayer()
        {

        }


        public void InitiatePlayers(string playerName_1, string playerName_2)
        {
            string[] players = new string[2] { playerName_1, playerName_2 };
            int i = 0;

            foreach(Player player in Players)
            {
                player.Name = players[i];

                Console.ForegroundColor = (player.Name == playerName_1) ? ConsoleColor.Red : ConsoleColor.Green;

                Console.WriteLine("{0} locate Your ships on the board:", player.Name);

                foreach (var ship in player.Ships)
                {
                    Console.WriteLine("Set ship {0} masts coordinate X: ", ship.Masts);
                    int x = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Set ship {0} masts coordinate Y: ", ship.Masts);
                    int y = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Would You like to place Your ship horizontally(0) or vertically(1)?");
                    int orientation = Convert.ToInt32(Console.ReadLine());

                    if (orientation == 0)
                    player.SetShipsOnBoard(ship, x, y, ShipOrientation.horizontally);
                    else player.SetShipsOnBoard(ship, x, y, ShipOrientation.vertically);

                    UpDateBoard(player);
                }

                i++;
            }
        }

        public void RegisterPlayer(Player player)
        {
            Players.Add(player);
        }

        public void UpDateBoard(Player player)
        {
            char markToDisplay;
            int i = 1;

            
            foreach(FieldsStatus boardField in player.Board.Fields)
            {
                for (int j = 0; j < 7; j++)
                {
                    if(player.Ships[j].CoordinatesY>0)
                    LocateShipsOnPlayersBoard(j, player);
                }

                Console.ForegroundColor = (boardField == FieldsStatus.empty) ? ConsoleColor.White : ConsoleColor.Yellow;
                markToDisplay = (char)boardField;
                if (i % 10 == 0 ) { Console.WriteLine(markToDisplay + "   |   "); }
                else { Console.Write(markToDisplay + "   |   "); }
                i++;
            }
        }

        private void LocateShipsOnPlayersBoard(int i, Player player)
        {
            int j = i;
            if(player.Ships[i].Orientation == ShipOrientation.vertically)
            {
                switch(player.Ships[i].CoordinatesY)
                {
                    case 1:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j] = FieldsStatus.ship;
                            j+= 10;
                        }
                        break;

                    case 2:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[i+10] = FieldsStatus.ship;
                            j+= 10;
                        }
                        break;

                    case 3:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 20] = FieldsStatus.ship;
                            j+= 10;
                        }
                        break;

                    case 4:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 30] = FieldsStatus.ship;
                            j+= 10;
                        }
                        break;

                    case 5:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 40] = FieldsStatus.ship;
                            j+= 10;
                        }
                        break;

                    case 6:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 50] = FieldsStatus.ship;
                            j+= 10;
                        }
                        break;

                    case 7:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 60] = FieldsStatus.ship;
                            j+= 10;
                        }
                        break;

                    case 8:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 70] = FieldsStatus.ship;
                            j+= 10;
                        }
                        break;

                    case 9:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 80] = FieldsStatus.ship;
                            j+= 10;
                        }
                        break;

                    case 10:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 90] = FieldsStatus.ship;
                            j+= 10;
                        }
                        break;
                }
  
            }

            else
            {
                switch (player.Ships[i].CoordinatesY)
                {
                    case 1:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j] = FieldsStatus.ship;
                            j++;
                        }
                        break;

                    case 2:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 10] = FieldsStatus.ship;
                            j++;
                        }
                        break;

                    case 3:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 20] = FieldsStatus.ship;
                            j++;
                        }
                        break;

                    case 4:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 30] = FieldsStatus.ship;
                            j++;
                        }
                        break;

                    case 5:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 40] = FieldsStatus.ship;
                            j++;
                        }
                        break;

                    case 6:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 50] = FieldsStatus.ship;
                            j++;
                        }
                        break;

                    case 7:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 60] = FieldsStatus.ship;
                            j++;
                        }
                        break;

                    case 8:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 70] = FieldsStatus.ship;
                            j++;
                        }
                        break;

                    case 9:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 80] = FieldsStatus.ship;
                            j++;
                        }
                        break;

                    case 10:
                        for (int m = 0; m < (int)player.Ships[i].Masts; m++)
                        {
                            player.Board.Fields[j+ 90] = FieldsStatus.ship;
                            j++;
                        }
                        break;
                }
            }
            
        }
    }
}
