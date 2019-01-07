using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroplaneSymulation
{
    public class Simulation
    {
        public string simulate(List<int> planes, List<bool> places, int turn)
        {
            WiezaKontrolna wieza = new WiezaKontrolna();
            List<bool> place = places;
            List<int> aeroplanes = planes;


            for (int i = 0; i <= turn-1; i++)
            {
                bool flag = true;
                foreach (var aeroplane in aeroplanes)
                {

                    if (wieza.check(place))
                    {
                        place = wieza.change_to_full(place);
                        aeroplanes.Remove(0);
                        flag = false;
                        Console.WriteLine("Samolot wyladowal");
                        break;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Nie ma miejsca musze czekac");
                }
                if (aeroplanes[0] == null)
                {
                    Console.WriteLine("Wszystkie samoloty wyladowaly");
                    return "Koniec";
                }

            }

            return "Koniec";
        }
    }
}
