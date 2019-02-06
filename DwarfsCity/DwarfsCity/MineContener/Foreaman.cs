using System;
using System.Collections.Generic;
using System.Linq;
using DwarfsCity.DwarfContener;

namespace DwarfsCity.MineContener
{
    public class Foreaman: IForeman
    {

        public void SendDwarfsToShaft(List<Dwarf> dwarfs, Shaft shaft)
        {
            List<Dwarf> sendedDwarfs = new List<Dwarf>();
            Cementary cementary = new Cementary();
            shaft.ShaftExploded += cementary.OnShaftExploded;  

            foreach (var dwarf in dwarfs)
            {
                if (shaft.dwarfs.Count >= 5) break;

                shaft.dwarfs.Add(dwarf);
                sendedDwarfs.Add(dwarf);
            }

            //Remove from all dwarfs sended dwarfs
            dwarfs.RemoveAll(i => sendedDwarfs.Contains(i));

            //If on the list sended dwarfs is a sabouteur 
            if (sendedDwarfs.Select(x => x.Attribute).Contains(DwarfContener.Type.Saboteur))
            {
                shaft.ChangeShaftExistStatusToDestroyed();                
            }
        }

        public List<Dwarf> LetTheDwarfsOutTheShaft(Shaft shaft)
        {
            List<Dwarf> dwarfsThatWasWorked = new List<Dwarf>();
            foreach (var dwarf in shaft.dwarfs)
            {
                dwarfsThatWasWorked.Add(dwarf);
            }

            shaft.dwarfs.Clear();

            return dwarfsThatWasWorked;
        }
    }
}