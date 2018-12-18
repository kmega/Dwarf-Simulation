using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheWorldOfCards
{
    public class CardPoolBuilder
    {
        Dictionary<HandStrength, int[]> _handStrengths;
        Dictionary<DifficultyLevel, int[]> _difficultyLevels;

        public CardPoolBuilder()
        {
            _handStrengths = new Dictionary<HandStrength, int[]>()
            {
                { HandStrength.Weak, new int[] {3,0,0 } },
                { HandStrength.Normal, new int[] {6,0,0 } },
                { HandStrength.Strong, new int[] {9,0,0 } }
            };

            _difficultyLevels = new Dictionary<DifficultyLevel, int[]>()
            {
                { DifficultyLevel.Easy, new [] {2,4,3} },
                { DifficultyLevel.Typical, new [] {0,6,3} },
                { DifficultyLevel.Risky, new [] {-2,8,3} }
            };
        }

        public Card[] BuildPool(HandStrength handStrength, 
            DifficultyLevel difficultyLevel)
        {
            int[] handPool = _handStrengths[handStrength];
            int[] difficultyPool = _difficultyLevels[difficultyLevel];

            List<int> mergedPool = new List<int>();
            for(int i=0;i<handPool.Length;i++)
            {
                int result = handPool[i] + difficultyPool[i];
                mergedPool.Add(result);
            }

            int[] xxx = mergedPool.ToArray();
            List<int> yyy = xxx.ToList();
            throw new NotImplementedException("I hate you");
        }
    }
}
