using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samoloty
    // WERSJA Z ODLATUJĄCYM JEDNYM SAMOLOTEM CO 5TĄ TURĘ
{
    public class AirPort
    {
        public List<int> Airplanes = new List<int> { 1, 2, 3, 4, 5, 6 };
        public List<int> AirStrip = new List<int> { 1, 2, 3, 4, 5 };
        bool isplace;
        int oneplacefree = 0;
        int landsuccess = 0;
        public bool IsLand(List<int> airplanes, List<int> airstrip)
        { ControlTower(Airplanes, AirStrip);

            for (int i = 0; i < Airplanes.Count; i++)

            { if (i % 5 == 0)
                {
                    oneplacefree++;

                }
                if (Airplanes[i] == AirStrip[i] || oneplacefree > 0)
                {
                    isplace = true;
                }
                else if (AirStrip[i] == 0)
                {

                }
                else
                {
                    isplace = false;
                }
            }

            return isplace;
        }

        public int IsLand2(List<int> airplanes, List<int> airstrip)
        {
            List<int> Airplanes = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            List<int> AirStrip = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ControlTower(Airplanes, AirStrip);

            for (int i = 0; i < Airplanes.Count; i++)

            {
                if (i > 5)
                {
                    oneplacefree++;

                }
                if (Airplanes[i] == AirStrip[i])
                {
                    isplace = true;
                    landsuccess++;
                }
                else if (Airplanes[i] > 10 & oneplacefree > 0)
                {
                    isplace = true;
                    oneplacefree--;
                    landsuccess++;
                }
                else
                {
                    isplace = false;
                }

            }

            return landsuccess;
        }
        public int IsLand3(List<int> airplanes, List<int> airstrip)
        {
            List<int> Airplanes = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50 };
            List<int> AirStrip = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int timeofalllanding = 0;
            ControlTower(Airplanes, AirStrip);

            for (int i = 0; i < Airplanes.Count; i++)

            {
                if (i % 5 == 0)
                {

                    oneplacefree++;

                }
                if (Airplanes[i] == AirStrip[i])
                {
                    isplace = true;
                    landsuccess++;
                }
                else if (Airplanes[i] > 10 & oneplacefree > 0)
                {
                    isplace = true;
                    oneplacefree--;
                    landsuccess++;
                }
                else
                {
                    isplace = false;
                }
            }

            timeofalllanding = landsuccess + 5 * (Airplanes.Count - landsuccess);
            return timeofalllanding;
        }
        public void ControlTower(List<int> AP, List<int> AS)
        {
            while (AS.Count < AP.Count)
            {
                AS.Add(0);
            }
        }
    }
}
