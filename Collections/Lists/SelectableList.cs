using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class SelectableList<T> : ScriptableObject
    {
        [AssetList]
        [SerializeField]
        private List<T> _items = null;
        public List<T> Items => _items;

        public T Random()
        {
            return _items[UnityEngine.Random.Range(0, _items.Count)];
        }
    }
}
