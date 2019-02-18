using System;
using System.Collections.Generic;
using System.Linq;

namespace Mine2._0
{
    public class Mine
    {
        public List<Schaft> _schafts { get; }
        public TeamSplitter _teamSplitter;
        public List<E_Minerals> Stats { get; private set; } = new List<E_Minerals>();
        private readonly IRandomizer _mineRandomizer;

        public Mine(IRandomizer randomizer)
        {
            _schafts = new List<Schaft>() { new Schaft(), new Schaft() };
            _teamSplitter = new TeamSplitter();
            _mineRandomizer = randomizer;
        }

        public void PerformMining(List<IWork> allWorkers, IOutputWriter _presenter)
        {
            while (allWorkers.Exists(x => x.GetIsAliveStatus() == true && x.GetBackpackQunatity() == 0 ))
            {
                var workers = allWorkers.Where(x => x.GetIsAliveStatus() == true && x.GetBackpackQunatity() == 0).ToList();

                foreach (var schaft in _schafts)
                {
                    if (schaft.SchaftStatus == E_SchaftStatus.Operational)
                    {
                        schaft.SchaftWorkers = _teamSplitter.SplitWorkersIntoTeam(workers);
                        schaft.SchaftWorkers.ForEach(x => x.Work(schaft, _mineRandomizer));
                    }
                }

                _schafts.ForEach(x => workers.AddRange(x.SchaftWorkers));

                foreach (var schaft in _schafts)
                {
                    if (schaft.SchaftStatus == E_SchaftStatus.Broken)
                        _presenter.WriteLine($"Schaft was destroyed, all dwarves died :(");

                    if (schaft.SchaftWorkers.All(x => x.GetIsAliveStatus()))
                        Stats.AddRange(schaft.SchaftStats);
                }

                _schafts.ForEach(x => x.SchaftStats.Clear());
                _schafts.ForEach(x => x.SchaftWorkers.Clear());
            }
        }

        public void UpdateStats(List<E_Minerals> allExtractedMinerals)
        {
            allExtractedMinerals.AddRange(Stats);
            Stats.Clear();
        }

        public void FixAllSchafts()
        {
            _schafts.ForEach(x => x.SchaftStatus = E_SchaftStatus.Operational);
        }
    }
}
