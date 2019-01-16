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
        public UI ShowBoard = new UI();
        public char[,] GetCurrentBattleField()
        {
            
            return BattleField.Board;
        }

        public Player()
        {
            AllMasts = 23;
        }

        public char[,] Shoot(int x, int y, char[,] board)
        {
            if (board[x-1, y-1] == '^')
                board[x-1, y-1] = 'x';

            AllMasts--;
            
            return board;
        }

        public void AddShip()
        {
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
                int x = int.Parse(Console.ReadLine());

                Console.WriteLine("Locate ship with {0} masts on Your board on coordinate Y:", masts);
                int y = int.Parse(Console.ReadLine());

                Console.WriteLine("Locate ship with {0} masts on Your board vertically(0) or horizontally(1)", masts);
                int orientation = int.Parse(Console.ReadLine());
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

                UI ui = new UI();
                
                ui.ShowBoard(GetCurrentBattleField());
                

                
            }
        }
    }
}