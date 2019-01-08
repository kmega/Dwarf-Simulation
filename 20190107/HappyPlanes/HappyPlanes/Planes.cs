using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes
{
   public class PlanesMain
    {
        
        private List<int> AllPlanesId = new List<int>();
        public Dictionary<int,int> AllPlanesIdsAndFuel = new Dictionary<int,int>();
        public Dictionary<int, int> AllPlanesIdsAndRunway = new Dictionary<int, int>();
        public Dictionary<int, int> AllPlanesIdsAndState = new Dictionary<int, int>();

        public class Planes
        {
            private int PlaneId;
            private int PlaneFuel;
            private int PlaneState;

            PlanesMain main = new PlanesMain();

            public Planes(int id)
            {
                if (main.AllPlanesId.Count == 0)
                {
                    this.PlaneId = id;
                    this.PlaneFuel = 200;
                    this.PlaneState = 0;
                    main.AllPlanesIdsAndFuel.Add(id, 200);
                    main.AllPlanesIdsAndState.Add(id, 0);
                }
                else
                {
                    foreach (int planeId in main.AllPlanesId)
                    {
                        if (planeId == id)
                            throw new Exception("Plane with such ID already exists");
                        else
                        {
                            this.PlaneId = id;
                    this.PlaneFuel = 200;
                    this.PlaneState = 0;
                    main.AllPlanesIdsAndFuel.Add(id, 200);
                    main.AllPlanesIdsAndState.Add(id, 0);
                        }
                    }
                }

                
            }

            public Planes(int id, int fuel)
            {
                foreach (int planeId in main.AllPlanesId)
                {
                    if (planeId == id)
                        throw new Exception("Plane with such ID already exists");
                    else
                    {
                        this.PlaneId = id;
                        this.PlaneFuel = fuel;
                        main.AllPlanesIdsAndFuel.Add(id, fuel);
                        main.AllPlanesIdsAndState.Add(id, 0);
                    }
                }

            }
            public void DecreasePlaneFuelByFlying()
            {
                this.PlaneFuel--;
                UpDateMain();
            }

            public void SetPlaneState()
            {
                this.PlaneState = 5;
                UpDateMain();
            }

            public void SetPlaneState(int state)
            {
                this.PlaneState = state;
                UpDateMain();
            }

            public int GetPlaneState()
            {
                return this.PlaneState;
            }

            public int GetPlaneFuel()
            {
                return this.PlaneFuel;
            }

            public int GetPlaneId()
            {
                return this.PlaneId;
            }


            private void UpDateMain()
            {
                main.AllPlanesIdsAndState[this.PlaneId] = this.PlaneState;
                main.AllPlanesIdsAndFuel[this.PlaneId] = this.PlaneFuel;
            }

        }

    }
}
