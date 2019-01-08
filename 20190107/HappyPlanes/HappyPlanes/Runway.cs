using System;
using System.Collections.Generic;
using System.Text;

namespace HappyPlanes
{
    public class RunwayMain
    {
        
        private List<int> AllRunwaysId = new List<int>();
        public Dictionary<int, bool> AllRunwaysIdAndState = new Dictionary<int, bool>();

        public class Runway
        {
            private int Id;
            private bool StateFree;

            RunwayMain main = new RunwayMain();
            public Runway(int id)
            {
                if (main.AllRunwaysId.Count == 0)
                {
                    this.Id = id;
                    this.StateFree = true;
                    main.AllRunwaysIdAndState.Add(id, true);
                }
                else
                {
                    foreach (int runwayId in main.AllRunwaysId)
                {
                    if (runwayId == id)
                        throw new Exception("This runway ID already exists");
                    else
                        {
                            this.Id = id;
                            this.StateFree = true;
                            main.AllRunwaysIdAndState.Add(id, true);
                        }

                    }
                }
                
            }
        }
        
    }
}
