using System;
using System.Collections.Generic;
using System.Linq;
using DwarfsCity.DwarfContener;
using DwarfsCity.Reports;

namespace DwarfsCity.MineContener
{
    public class Foreaman: IForeman, IReport
    {
        public List<string> Reports { get; set; } = new List<string>();

        public void SendDwarfsToShaft(List<Dwarf> dwarfs, Shaft shaft)
        {
            List<Dwarf> sendedDwarfs = new List<Dwarf>();

            shaft.ShaftExploded += Cementary.OnShaftExploded;  

            foreach (var dwarf in dwarfs)
            {
                if (shaft.dwarfs.Count >= 5) break;

                shaft.dwarfs.Add(dwarf);
                sendedDwarfs.Add(dwarf);
            }

            GiveReport("Foreman send " + sendedDwarfs.Count + " dwarfs to shaft");

            //Remove from all dwarfs sended dwarfs
            dwarfs.RemoveAll(i => sendedDwarfs.Contains(i));

            //If on the list sended dwarfs is a sabouteur 
            if (sendedDwarfs.Select(x => x.Attribute).Contains(DwarfContener.Type.Saboteur))
            {
                GiveReport("Oh no! in the shaft is a saboteur, the shaft will exploding for a few times");
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

        public void GiveReport(string message)
        {
            Reports.Add(message);
        }
    }
}