using System;
using System.Collections.Generic;

namespace DwarfsTown
{
    public class Bar 
    {
        public int SupplyOfFood { get; set; } = 200;
     
        public void FeedDwarfs(List<Dwarf> dwarfs)
        {
                SubstractSupply(dwarfs);    
        }

        private void SubstractSupply(List<Dwarf> dwarfs)
        {
            SupplyOfFood -= dwarfs.Count;
            if (SupplyOfFood < 0)
            {
                AddInformation("Bar","The Simulation is over!");
                Console.WriteLine("THE END OF SIMULATION");
            }
            else if (SupplyOfFood < 10 && SupplyOfFood >=0)
            {
                SupplyOfFood += 30;
                AddInformation("Bar", "There is a delivery to Bar.");
            }
            else
            {
                AddInformation("Bar", "All Dwarfs eat a dinner.");
            }
        }
        public void AddInformation(string idBuilding, string message)
        {
            City.newsPaper.Add(idBuilding + ": " + message);
        }
    }
}