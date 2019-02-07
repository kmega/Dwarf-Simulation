using System;
using System.Collections.Generic;
using DwarfMineSimulator.Dwarfs;
using DwarfMineSimulator.Enums;
using System.Linq;

namespace DwarfMineSimulator.Building.Mine
{
    internal class Shaft : IShaft
    {
        string Name;
        List<Dwarf> DwarfsInShaft;
        List<Dwarf> ShaftQueue;
        bool Collapsed;
        int MaxDwarfsInShaft;

        public Shaft(string name, int maxDwarfsInShaft = 5)
        {
            Name = name;
            ShaftQueue = new List<Dwarf>();
            DwarfsInShaft = new List<Dwarf>();
            Collapsed = false;
            SetMaxNumberOfDwarfsInShaft(maxDwarfsInShaft);
        }

        public void SetMaxNumberOfDwarfsInShaft(int maxNumber)
        {
            MaxDwarfsInShaft = maxNumber;
        }

        public bool IsFullOfDwarfes()
        {
            return DwarfsInShaft.Count > MaxDwarfsInShaft ? true : false;
        }

        public void DwarfGoIntoShaftQueue(Dwarf worker)
        {
            if (worker.IsAlive())
            {
                ShaftQueue.Add(worker);
                Console.WriteLine("Dwart no {0} goes to {1}", worker.GetId(), Name);
            }

            DwarfesMineMinerals();
        }

        private void DwarfesMineMinerals()
        {
            DwarfsInShaft = new List<Dwarf>();

            while (ShaftQueue.Count > 0)
            {
                foreach (var miner in ShaftQueue.ToList())
                {
                    if (!IsFullOfDwarfes() && !Collapsed)
                    {
                        if (miner.IsAlive())
                            DwarfsInShaft.Add(miner);

                        if (miner.GetDwarfType().Equals(DwarfTypes.Suicider))
                        {
                            DwarfsInShaft.ForEach(deadDwarfs =>
                            {
                                deadDwarfs.SummonDeath();
                            });

                            Collapsed = true;
                        }

                        if (miner.MaxHitsInShaft() > 0)
                        {
                            miner.MineMinerals();
                        }

                        if (miner.MaxHitsInShaft() == 0)
                        {
                            miner.EndOfShift();
                            ShaftQueue.Remove(miner);
                        }
                    }
                }
            }

            //ShaftQueue.ForEach(dwarf =>
            //{
            //    if(!IsFullOfDwarfes())
            //    {
            //        DwarfsInShaft.Add(dwarf);

            //        if(dwarf.GetDwarfType().Equals(DwarfTypes.Suicider))
            //        {
            //            DwarfsInShaft.ForEach(deadDwarfs =>
            //            {
            //                deadDwarfs.SummonDeath();
            //            });

            //            DwarfsInShaft.RemoveAll(x => dwarf.IsAlive() == false);
            //        }

            //        DwarfsInShaft.ForEach(miner =>
            //        {
            //            miner.MineMinerals();
            //        });
            //    }
            //});

            //DwarfsInShaft = new List<Dwarf>();
        }

        public string ShaftName()
        {
            return Name;
        }

        public bool IsCollapsed()
        {
            return Collapsed;
        }
    }
}
