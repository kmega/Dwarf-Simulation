using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models
{
    public static class FieldBlocker
    {
        public static List<string> BlockUpOrientedShipArea(int[] x, int[] y)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                result.Add(TextParser.ParseIntToString(x[0] - 1 + i, y[0] + 1));
                result.Add(TextParser.ParseIntToString(x[x.Length - 1] - 1 + i, y[y.Length - 1] - 1));
            }
            result.AddRange(BlockVerticallyOrientedSideOfShip(x, y));
            return result;
        }
        public static List<string> BlockDownOrientedShipArea(int[] x, int[] y)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                result.Add(TextParser.ParseIntToString(x[0] - 1 + i, y[0] - 1));
                result.Add(TextParser.ParseIntToString(x[x.Length - 1] - 1 + i, y[y.Length - 1] + 1));
            }
            result.AddRange(BlockVerticallyOrientedSideOfShip(x, y));
            return result;
        }
        public static List<string> BlockRightOrientedShipArea(int[] x, int[] y)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                result.Add(TextParser.ParseIntToString(x[0] - 1 , y[0] - 1 + i));
                result.Add(TextParser.ParseIntToString(x[x.Length - 1] + 1, y[y.Length - 1] -1+i));
            }
            result.AddRange(BlockHorizontallyOrientedSideOfShip(x, y));
            return result;
        }
        public static List<string> BlockLeftOrientedShipArea(int[] x, int[] y)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                result.Add(TextParser.ParseIntToString(x[0] + 1, y[0] - 1 + i));
                result.Add(TextParser.ParseIntToString(x[x.Length - 1] - 1, y[y.Length - 1] - 1+i));
            }
            result.AddRange(BlockHorizontallyOrientedSideOfShip(x, y));
            return result;
        }

        private static List<string> BlockVerticallyOrientedSideOfShip(int[] x, int[] y)
        {
            List<string> result = new List<string>();
            foreach (int coord in y)
            {
                result.Add(TextParser.ParseIntToString(x[0] + 1, coord));
                result.Add(TextParser.ParseIntToString(x[0] - 1, coord));
            }
            return result;
        }
        private static List<string> BlockHorizontallyOrientedSideOfShip(int[] x, int[] y)
        {
            List<string> result = new List<string>();
            foreach (int coord in x)
            {
                result.Add(TextParser.ParseIntToString(coord, y[0] - 1));
                result.Add(TextParser.ParseIntToString(coord, y[0] + 1));
            }
            return result;
        }
    }
}
