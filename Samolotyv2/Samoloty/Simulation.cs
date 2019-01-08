using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PlanesTestsUnit")]

namespace Samoloty
{
    internal class Simulation
    {
        public int numberOfPlanesCrashed = 0, numberOfPlanesThatHasLanded = 0;
        public bool landingPad1 = true, landingPad2 = true;

        public Simulation(int number_planes)
        {
         
            int counter = 0;
            List<Plane> planes = new List<Plane>();

            do
            {
                if (counter < number_planes)
                {
                    planes.Add(new Plane(number_planes, 5));
                }

                if (counter <= 2)
                {
                    if (CheckIfCanLand(planes))
                    {
                        planes = LoadFuel(planes, landingPad1);
                        planes = LoadFuel(planes, landingPad2);

                        if (landingPad1 == true)
                        {
                            planes = HasLanded(planes);
                            landingPad1 = false;
                        }
                        else if (landingPad2 == true)
                        {
                            planes = HasLanded(planes);
                            landingPad2 = false;
                        }

                        planes = SubstractFuel(planes);


                    }
                }

                counter++;
            }
            while (planes.Count == 0);
            Console.WriteLine("Planes that landed: " + numberOfPlanesThatHasLanded);
            Console.WriteLine("Planes that crashed: " + numberOfPlanesCrashed);
        }

        internal List<Plane> LoadFuel(List<Plane> planes, bool landingPad)
        {
            if (landingPad == false)
            {
                List<Plane> modify_plane = new List<Plane>();
                foreach (var plane in planes)
                {
                    if (plane.hasLanded == true)
                    {
                        plane.fuel++;
                        if (plane.fuel >= 5)
                        {
                            numberOfPlanesThatHasLanded++;
                            if (plane.landingPadNumber==1)
                            {
                                landingPad1 = true;
                            }
                            else
                            {
                                landingPad2 = true;
                            }
                        }
                        else
                        {
                            modify_plane.Add(plane);
                        }
                    }
                    else
                    {
                        modify_plane.Add(plane);
                    }
                }
                return modify_plane;
            }
            return planes;
        }

        internal List<Plane> SubstractFuel(List<Plane> planes)
        {
            List<Plane> modify_plane = new List<Plane>();

            foreach (var plane in planes)
            {
                plane.fuel--;
                if (plane.fuel <= 0)
                {
                    numberOfPlanesCrashed++;
                }
                else
                {
                    modify_plane.Add(plane);
                }
            }
            return modify_plane;
        }

        internal List<Plane> HasLanded(List<Plane> planes)
        {
            foreach (var plane in planes)
            {
                if (plane.fuel<=2)
                {
                    plane.hasLanded = true;
                    if (landingPad1 == true)
                    {
                        plane.landingPadNumber = 1;
                    }
                    else if (landingPad2 == true)
                    {
                        plane.landingPadNumber = 2;
                    }
                    break;
                }
            }
            return planes;
        }

        internal bool CheckIfCanLand(List<Plane> planes)
        {
            bool canLand = false;
            foreach (var plane in planes)
            {
                if (plane.fuel<=2)
                {
                    canLand = true;
                }
            }
            return canLand;
        }
    }
}