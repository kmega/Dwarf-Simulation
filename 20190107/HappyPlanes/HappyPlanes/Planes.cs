using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes
{
   public class Planes
    {
        private int PlaneId;
        private int PlaneFuel;
        private int PlaneState;
        private List<int> AllPlanesId = new List<int>();
        public Dictionary<int,int> AllPlanesIdsAndFuel = new Dictionary<int,int>();
        public Dictionary<int, int> AllPlanesIdsAndRunway = new Dictionary<int, int>();

        public Planes(int id)
        {
            foreach (int planeId in this.AllPlanesId)
            {
                if (planeId == id)
                    throw new Exception("Plane with such ID already exists");
                else
                {
                    this.PlaneId = id;
                    this.PlaneFuel = 200;
                    this.PlaneState = 0;
                    this.AllPlanesIdsAndFuel.Add(id, 200);
                    this.AllPlanesIdsAndFuel.Add(id, 0);
                }
            }
        }

        public Planes(int id, int fuel)
        {
            foreach(int planeId in this.AllPlanesId)
            {
                if (planeId == id)
                    throw new Exception("Plane with such ID already exists");
                else
                {
                    this.PlaneId = id;
                    this.PlaneFuel = fuel;
                    this.AllPlanesIdsAndFuel.Add(id, fuel);
                    this.AllPlanesIdsAndFuel.Add(id, 0);
                }
            }

        }

        public void SetPlaneState()
        {
            this.PlaneState = 5;
        }

        public int GetPlaneState()
        {
            return this.PlaneState;
        }

        public int GetPlaneFuel()
        {
            return this.PlaneFuel;
        }


    }
}
