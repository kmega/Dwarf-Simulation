using System;
using System.Collections.Generic;
using System.Linq;

namespace Mine2._0
{
    public class Mine
    {
        public List<Schaft> _schafts { get; }
        public TeamSplitter _teamSplitter;
        public List<E_Minerals> Stats = new List<E_Minerals>();
        private IRandomizer _mineRandomizer;

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

                if(_schafts[0].SchaftStatus == E_SchaftStatus.Operational)
                {
                    _schafts[0].SchaftWorkers = _teamSplitter.SplitWorkersIntoTeam(workers);
                    _schafts[0].SchaftWorkers.ForEach(x => x.Work(_schafts[0], _mineRandomizer));
                }

                if (_schafts[1].SchaftStatus == E_SchaftStatus.Operational)
                {
                    _schafts[1].SchaftWorkers = _teamSplitter.SplitWorkersIntoTeam(workers);
                    _schafts[1].SchaftWorkers.ForEach(x => x.Work(_schafts[1], _mineRandomizer));
                }

                workers.AddRange(_schafts[0].SchaftWorkers);
                workers.AddRange(_schafts[1].SchaftWorkers);

                foreach (var schaft in _schafts)
                {
                    if (schaft.SchaftStatus == E_SchaftStatus.Broken)
                        _presenter.WriteLine($"Schaft was destroyed, all dwarves died :(");
                }

                foreach (var schaft in _schafts)
                {
                    if(schaft.SchaftWorkers.All(x => x.GetIsAliveStatus()))
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
