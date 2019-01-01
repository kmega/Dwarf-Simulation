using CardsWar.GameEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardsWar.UI
{
    class SummaryUI
    {
        public void DisplayContent(string stepsGame)
        {
            char choice = ' ';

                do
                {

                    Console.WriteLine("1 - Display all steps");
                    Console.WriteLine("2 - New Game");
                    Console.WriteLine("3 - End the Game");
                    Console.Write(": ");
                    choice = Console.ReadKey().KeyChar;

                    switch (choice)
                    {
                        case '1':
                            {
                                Console.Clear();                                
                                Process.Start("gameSteps.txt");
                                break;
                            }
                        case '2':
                            {
                                Console.Clear();
                                Game.Run(true);
                                break;
                            }
                        case '3':
                            {
                            File.Delete("gameSteps.txt");
                            Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("\nUnknown option!");
                                Thread.Sleep(2000);
                                Console.Clear();
                                break;
                            }


                    }

                } while (choice != '3');           
        }
    }
}
