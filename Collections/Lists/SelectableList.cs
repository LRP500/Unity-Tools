using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Collections
{
    public abstract class SelectableList<T> : ScriptableObject
    {
        [SerializeField]
        [AssetList(CustomFilterMethod = nameof(CustomFilter))]
        private List<T> _items = null;
        public List<T> Items => _items;

        public T Random()
        {
            return _items[UnityEngine.Random.Range(0, _items.Count)];
        }

        protected virtual bool CustomFilter(T item)
        {
            return true;
        }
    }
}