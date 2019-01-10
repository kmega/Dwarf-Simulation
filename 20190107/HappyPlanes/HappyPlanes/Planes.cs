using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes
{

    public class Planes
    {

        private int PlaneId;
        private int PlaneFuel;
        private bool PlaneInAir;
        private int PlaneFuelMax;
        private bool WishToLand { get; set; }

        public Planes(int id,int fuel)
        {

            this.PlaneId = id;
            this.PlaneFuel = fuel;
            this.PlaneFuelMax = fuel;
            this.PlaneInAir = true;

        }

        public void DecreasePlaneFuelByFlying()
        {
            this.PlaneFuel--;
        }

        public void IncreasePlaneFuelByTankingUp()
        {
            this.PlaneFuel++;
        }

        public bool GetPlaneInAir()
        {
            return this.PlaneInAir;
        }

        public int GetPlaneFuel()
        {
            return this.PlaneFuel;
        }

        public int GetPlaneFuelMax()
        {
            return this.PlaneFuelMax;
        }

        public int GetPlaneId()
        {
            return this.PlaneId;
        }

        public bool GetWishToLand()
        {
            return WishToLand;
        }

        public void SetPlaneOnRunway()
        {
            this.PlaneInAir = false;
        }

        public void SetPlaneInAir()
        {
            this.PlaneInAir = true;
        }

        public void SetWishToLand()
        {
            this.WishToLand = true;
        }

        public void RemoveWishToLand()
        {
            this.WishToLand = false;
        }



    }

}






