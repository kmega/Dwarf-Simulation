using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models
{
    public static class TextParser
    {
        public static void FillArrayWithShip(string[,] array, string field)
        {
            int x, y;
            ParseFieldToInt(field, out x, out y);
            array[x, y] = "X ";
        }
        public static void DrawArray(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine("");
            }
        }
        public static void ParseFieldToInt(string field, out int x, out int y)
        {
            x = field[0] - 65;
            y = Convert.ToInt32(field[1]) - 49;
        }
        public static string ParseIntToString(int x, int y)
        {
            char xPos = Convert.ToChar(x + 65);
            char yPos = Convert.ToChar(y + 49);
            return $"{xPos}{yPos}";
        }
        public static void FillArray(string[,] array, string symbol)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = symbol;
                }
            }
        }
    }
}
