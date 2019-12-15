using System.Collections.Generic;
using UnityEngine;

namespace Tools.Random
{
    [CreateAssetMenu(menuName = "Tools/Random/Weighted Randomizer")]
    public class WeightedRandomizer : ScriptableObject
    {
        [SerializeField]
        private List<WeightedChance> _entries = null;

        public void AddWeight(WeightedChance weight)
        {
            _entries = _entries ?? new List<WeightedChance>();
            _entries.Add(weight);
        }

        public void Execute()
        {
            /// Get total weight of all choice entries
            int totalWeight = 0;
            foreach (var entry in _entries)
            {
                totalWeight += entry.Weight;
            }

            /// Get a random value between 0 and 100
            var rand = UnityEngine.Random.Range(0, 100);

            /// Run chances for each entry
            float totalPercentage = 0f;
            for (int i = 0, length = _entries.Count; i < length; i++)
            {
                totalPercentage += _entries[i].Weight * 100 / totalWeight;

                if (rand <= totalPercentage)
                {
                    _entries[i].OnExecute.Invoke();
                    return;
                }
            }
        }
    }
}

