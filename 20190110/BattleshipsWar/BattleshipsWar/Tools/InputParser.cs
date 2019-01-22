using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BattleshipsWar
{
     public class InputParser
    {
        public int[] ChangeCordsToIndexes(string coords)
        {
            if (coords.Length > 3 || coords.Length <=1)
            {
                int[] wrongCoords = { -1, -1 };
                return wrongCoords;
            }

            else
            {               
                Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
                Match result = re.Match(coords);

                string alphaPart = result.Groups[1].Value;
                alphaPart = alphaPart.ToLower();
               
                string numberPart = result.Groups[2].Value;

                int firstIndex = AdjustAlphaPartToNumber(alphaPart);
                int secondIndex = int.Parse(numberPart) - 1;

                int[] changedCoords = { firstIndex, secondIndex };

                return changedCoords;
            }
        }

        private int AdjustAlphaPartToNumber(string alphaPart)
        {
            switch (alphaPart[0])
            {
                case 'a':
                    return 0;
                case 'b':
                    return 1;
                case 'c':
                    return 2;
                case 'd':
                    return 3;
                case 'e':
                    return 4;
                case 'f':
                    return 5;
                case 'g':
                    return 6;
                case 'h':
                    return 7;
                case 'i':
                    return 8;
                case 'j':
                    return 9;
                default:
                    {
                        return -1;
                    }


            }
            throw new NotImplementedException();
        }
    }
}
