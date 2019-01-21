using System;
using System.IO;
using barcosFinal.Interfaces;

namespace barcosFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine startGame = new GameEngine();

            if (File.Exists("ships.txt"))
            {
                string[] shipsFromFile = File.ReadAllLines("ships.txt");
                startGame.StartGame(shipsFromFile); 
            }
            else
            {
                startGame.StartGame();
            }
        }
    }
}
