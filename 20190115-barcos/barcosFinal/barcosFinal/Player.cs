using System;
using System.Collections.Generic;
using barcosFinal.Enums;
using barcosFinal.Interfaces;

namespace barcosFinal
{
    public class Player : IPlayer
    {
        public List<IShip> Ships { get; set; }
        public int AllMasts { get; set; }
        public IBattleField BattleField { get; set; }
        public IBattleField BattleFieldToDisplay { get; set; }
        public bool OnRage { get; set; }
        public string Name { get ; set ; }
        public UI ShowBoard = new UI();
        public char[,] GetCurrentBattleField()
        {
            
            return BattleField.Board;
        }

        public Player()
        {
            AllMasts = 23;
        }

        public char[,] Shoot(Player enemyPlayer, int x, int y, char[,] enemyBoard)
        {
            OnRage = false;
            try
            {
                if (enemyBoard[x - 1, y - 1] == '^')
                {
                    enemyPlayer.BattleField.Board[x - 1, y - 1] = 'x';
                    BattleFieldToDisplay.Board[x - 1, y - 1] = 'x';//here blad, rzuca wyjatkiem
                    OnRage = true;

                }
                else if (BattleFieldToDisplay.Board[x - 1, y - 1] == 'x' || BattleFieldToDisplay.Board[x - 1, y - 1] == ' ')
                {
                    OnRage = true;
                }

                else BattleFieldToDisplay.Board[x - 1, y - 1] = ' ';
            }

            catch (Exception)
            {

                Console.WriteLine("You didn't shoot on board, try again");
                OnRage = true;
            }
            

            return BattleFieldToDisplay.Board;
        }

        public void AddShip(string[] content)
        {
            UI ui = new UI();
            Ships = new List<IShip>();
            for (int i = 0; i < content.Length; i++)
            {
                string[] firstLine = content[i].Split(new string[] { "," }, StringSplitOptions.None);
                int masts = int.Parse(firstLine[1]);

                //string[] firstLine = content[i].Split(new string[] { "," }, StringSplitOptions.None);

                //int masts = 0;

                //switch (firstLine[1])
                //{
                //    case "cross":
                //        masts = (int)ShipShapes.Cross_ship;
                //        break;
                //    case "L":
                //        masts = (int)ShipShapes.L_ship;
                //        break;
                //    default:
                //        masts = int.Parse(firstLine[1]);
                //        break;
                //}

                for (int j = 0; j < int.Parse(firstLine[0]); j++)
                {
                    Console.WriteLine("Locate ship with {0} masts on Your board on coordinate X:", masts);

                    int x = 0;
                    int y = 0;

                    while (x == 0)
                    {
                        try
                        {
                            int tmpX = int.Parse(Console.ReadLine());
                            if (tmpX > 0 && tmpX < 11)
                            {
                                x = tmpX;
                            }
                            else
                            {
                                Console.WriteLine("Readed value is not a number between 1 - 10.");
                                Console.WriteLine("Try again...");
                            }
                        }

                        catch
                        {
                            Console.WriteLine("Readed value is not a number between 1 - 10.");
                            Console.WriteLine("Try again...");
                        }
                    }

                    Console.WriteLine("Locate ship with {0} masts on Your board on coordinate Y:", masts);

                    while (y == 0)
                    {
                        try
                        {
                            int tmpY = int.Parse(Console.ReadLine());
                            if (tmpY > 0 && tmpY < 11)
                            {
                                y = tmpY;
                            }
                            else
                            {
                                Console.WriteLine("Readed value is not a number between 1 - 10.");
                                Console.WriteLine("Try again...");
                            }
                        }

                        catch
                        {
                            Console.WriteLine("Readed value is not a number between 1 - 10.");
                            Console.WriteLine("Try again...");
                        }
                    }

                    Console.WriteLine("Locate ship with {0} masts on Your board vertically(0) or horizontally(1)", masts);
                    int orientation = 2;

                    while (orientation == 2)
                    {
                        try
                        {
                            int tmpOrientation = int.Parse(Console.ReadLine());
                            if (tmpOrientation is 0 || tmpOrientation is 1)
                            {
                                orientation = tmpOrientation;
                            }
                            else
                            {
                                Console.WriteLine("Readed value is not 0 or 1");
                                Console.WriteLine("Try again...");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Readed value is not 0 or 1");
                            Console.WriteLine("Try again...");
                        }
                    }

                    Orientation shipOrientation = (orientation == 0) ? Orientation.vertical : Orientation.horizontal;

                    IShip ship = new Ship(masts, x, y, shipOrientation);
                    Ships.Add(ship);



                    for (int z = 0; z < masts; z++)
                    {
                        if (shipOrientation == Orientation.vertical)
                            BattleField.Board[y + z - 1, x - 1] = '^';
                        else
                            BattleField.Board[y - 1, x - 1 + z] = '^';

                    }


                    Console.Clear();
                    ui.ShowBoard(GetCurrentBattleField());
                }
            }
        }

        public void AddShip()
        {
            UI ui = new UI();
            Ships = new List<IShip>();
            for (int i = 0; i < 7; i++)
            {
                int masts = 0;
                switch(i)
                {
                    case 1:
                    case 0:
                        masts = 2;
                        break;
                    case 3:
                    case 2:
                        masts = 3;
                        break;
                    case 4:
                    case 5:
                        masts = 4;
                        break;
                    case 6:
                        masts = 5;
                        break;
                }
                Console.WriteLine("Locate ship with {0} masts on Your board on coordinate X:", masts);

                int x = 0;
                int y = 0;

                while (x == 0)
                {
                    try
                    {
                        int tmpX = int.Parse(Console.ReadLine());
                        if (tmpX > 0 && tmpX < 11)
                        {
                            x = tmpX;
                        }
                        else
                        {
                            Console.WriteLine("Readed value is not a number between 1 - 10.");
                            Console.WriteLine("Try again...");
                        }
                    }

                    catch
                    {
                        Console.WriteLine("Readed value is not a number between 1 - 10.");
                        Console.WriteLine("Try again...");
                    }
                }

                Console.WriteLine("Locate ship with {0} masts on Your board on coordinate Y:", masts);

                while (y == 0)
                {
                    try
                    {
                        int tmpY = int.Parse(Console.ReadLine());
                        if (tmpY > 0 && tmpY < 11)
                        {
                            y = tmpY;
                        }
                        else
                        {
                            Console.WriteLine("Readed value is not a number between 1 - 10.");
                            Console.WriteLine("Try again...");
                        }
                    }

                    catch
                    {
                        Console.WriteLine("Readed value is not a number between 1 - 10.");
                        Console.WriteLine("Try again...");
                    }
                }

                Console.WriteLine("Locate ship with {0} masts on Your board vertically(0) or horizontally(1)", masts);
                int orientation = 2;

                while (orientation == 2)
                {
                    try
                    {
                        int tmpOrientation = int.Parse(Console.ReadLine());
                        if (tmpOrientation is 0 || tmpOrientation is 1)
                        {
                            orientation = tmpOrientation;
                        }
                        else
                        {
                            Console.WriteLine("Readed value is not 0 or 1");
                            Console.WriteLine("Try again...");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Readed value is not 0 or 1");
                        Console.WriteLine("Try again...");
                    }
                }

                Orientation shipOrientation = (orientation == 0) ? Orientation.vertical : Orientation.horizontal;

                IShip ship = new Ship(masts,x,y,shipOrientation);
                Ships.Add(ship);

              
                
                for (int j = 0; j < masts; j++)
                {
                    if (shipOrientation == Orientation.vertical)
                        BattleField.Board[y+j-1,x-1] = '^'; 
                    else 
                        BattleField.Board[y-1,x-1+j] = '^'; 

                }


                Console.Clear();
                ui.ShowBoard(GetCurrentBattleField());
                

                
            }
        }
    }
}