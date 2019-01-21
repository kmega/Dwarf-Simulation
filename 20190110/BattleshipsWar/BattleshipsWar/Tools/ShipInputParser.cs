using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar.Tools
{
    public class ShipInputParser
    {


        public Dictionary<KindOfShip,string> MakeHarborOrder(string directory)
        {

            //1.directory ->Parser -> one line string
            //2. one line string -> MakeShip -> Ship
            //3.Add ship to list
            string line;
            StreamReader sr = new StreamReader(directory);
            Dictionary<KindOfShip,string> harbororder = new Dictionary<KindOfShip,string>();

            while ((line=sr.ReadLine()) != null)
            {
                if (line=="")
                {
                    continue;
                }
               
               
                AddShip(harbororder, line);

            }
            return harbororder;


        }

        public void AddShip (Dictionary<KindOfShip,string> harbororder, string line)
        {
            string[] temp = line.Split(':');
            for (int i = 0; i < Int32.Parse(temp[1]); i++)
            {
                if ((Enum.TryParse<KindOfShip>(temp[0], out KindOfShip result)))
                {
                    harbororder.Add(result,temp[2]);
                }
                else
                {
                    Console.WriteLine("Nie da się zbudować statku {}-elementowego", temp[0]);
                }

            }

        }
    }
}