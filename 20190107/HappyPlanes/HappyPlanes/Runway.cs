using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes
{


    public class Runway
    {
        private int Id;
        private bool StateFree;


        public Runway(int id)
        {
            this.Id = id;
            this.StateFree = true;
        }

        public int GetRunwayId()
        {
            return this.Id;
        }

        public bool GetRunwayStateFree()
        {
            return this.StateFree;
        }

        public void SetRunwayStateFree()
        {
            this.StateFree = true;
        }

        public void SetRunwayStateBusy()
        {
            this.StateFree = false;
        }

    }
}



