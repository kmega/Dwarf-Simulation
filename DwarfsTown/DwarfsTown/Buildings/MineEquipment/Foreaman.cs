using System;
using System.Collections.Generic;

namespace DwarfsTown
{
    public class Foreaman
    {
        public delegate void ExplodedShaftEventHandler(object o, ExplodedEventArgs e);
        public event ExplodedShaftEventHandler ExplodedShaft;

        public void SendDwarfsToShaft(List<Dwarf> dwarfsThatShouldBeWorking, Shaft shaft)
        {

            foreach (var dwarf in dwarfsThatShouldBeWorking)
            {
                if (shaft.dwarfs.Count == 5) break;
                shaft.dwarfs.Add(dwarf);
            }



            //Remove from dwarfs who should be working sended dwarfs
            dwarfsThatShouldBeWorking.RemoveAll(x => shaft.dwarfs.Contains(x));

        }

        public List<Dwarf> LetGoDwarfs(Shaft shaft)
        {
            List<Dwarf> dwarfsThatGoToSurface = new List<Dwarf>();
            dwarfsThatGoToSurface.AddRange(shaft.dwarfs);

            shaft.dwarfs.Clear();
            return dwarfsThatGoToSurface;
        }

        public int SumAllDiggedMaterials(List<Dwarf> dwarfsThatWasWorked)
        {
            int allDiggedMaterials = 0;
            foreach (var dwarf in dwarfsThatWasWorked)
            {
                allDiggedMaterials += dwarf.Backpack.Materials.Count;
            }

            return allDiggedMaterials;
        }

        protected virtual void OnExplodedShaft(List<Dwarf> _killedDwarfs)
        {
            if (ExplodedShaft != null)
                ExplodedShaft(this, new ExplodedEventArgs() {killedDwarfs = _killedDwarfs});
        }

        public void CallToGravedigger(List<Dwarf> _killedDwarfs)
        {
            OnExplodedShaft(_killedDwarfs);
        }
    }
}