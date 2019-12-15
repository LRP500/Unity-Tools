using UnityEngine;

namespace Tools.Random
{
    public class WeightedChance
    {
        public int Weight { get; }

        public System.Action OnExecute;

        public WeightedChance(int weight, System.Action callback)
        {
            Weight = weight;
            OnExecute = callback;
        }
    }
}
