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
            while (worker.IsWorkDone() == false)
            {
                if (worker.IsAlive())
                {
                    if (ShaftQueue.Count > 0)
                    {
                        DwarfsInShaft.Add(ShaftQueue.First());
                        ShaftQueue.Remove(ShaftQueue.First());
                    }

                    if (!IsFullOfDwarfes() && !IsCollapsed())
                    {
                        DwarfsInShaft.Add(worker);
                        Console.WriteLine("Dwart no {0} goes to {1}", worker.GetId(), Name);
                    }
                    else
                    {
                        if (!ShaftQueue.Exists(x => x == worker))
                        {
                            ShaftQueue.Add(worker);
                            Console.WriteLine("Dwart no {0} waiting...", worker.GetId());
                        }

                    }
                }


                //while (DwarfsInShaft.Any(x => x.IsWorkDone() == false))
                //{
                //    Mine(DwarfsInShaft);
                //}

                Mine(DwarfsInShaft);
            }
        }

        private void Mine(List<Dwarf> miners)
        {

            List<Dwarf> actualMiners = miners.ToList();

            actualMiners.ForEach(dwarf =>
            {
                if (dwarf.MaxHitsInShaft() > 0)
                {
                    dwarf.MineMinerals();


                }

                if (dwarf.MaxHitsInShaft() == 0)
                {
                    dwarf.EndOfShift();
                }
            });

            //miners.RemoveAll(x => x.IsWorkDone() == true);
        }

        public void MineMinerals(Dwarf worker)
        {

            //DwarfsInShaft = new List<Dwarf>();

            //while (ShaftQueue.Count > 0)
            //{
            //    foreach (var miner in ShaftQueue.ToList())
            //    {
            //        if (!IsFullOfDwarfes() && !Collapsed)
            //        {
            //            if (miner.IsAlive())
            //                DwarfsInShaft.Add(miner);

            //            if (miner.GetDwarfType().Equals(DwarfTypes.Suicider))
            //            {
            //                DwarfsInShaft.ForEach(deadDwarfs =>
            //                {
            //                    deadDwarfs.SummonDeath();
            //                });

            //                Collapsed = true;
            //            }

            //            if (miner.MaxHitsInShaft() > 0)
            //            {
            //                miner.MineMinerals();
            //            }

            //            if (miner.MaxHitsInShaft() == 0)
            //            {
            //                miner.EndOfShift();
            //                ShaftQueue.Remove(miner);
            //            }
            //        }
            //    }
            //}
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
