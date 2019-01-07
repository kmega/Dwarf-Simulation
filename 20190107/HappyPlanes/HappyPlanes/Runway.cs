using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes
{
    public class Runway
    {
        private int Id;
        private bool StateFree;
        private List<int> AllRunwaysId = new List<int>();
        public Dictionary<int, bool> AllRunwaysIdAndState = new Dictionary<int, bool>();

        public Runway(int id)
        {
            foreach(int runwayId in this.AllRunwaysId)
            {
                if (runwayId == id)
                    throw new Exception("This runway ID already exists");
                else
                {
                    this.Id = id;
                    this.StateFree = true;
                    this.AllRunwaysIdAndState.Add(id, true);
                }
            }
        }
    }
}
