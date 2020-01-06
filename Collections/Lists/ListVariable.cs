using System.Collections.Generic;
using UnityEngine;

namespace Tools.Collections
{
    public abstract class ListVariable<T> : ScriptableObject
    {
        [SerializeField]
        private List<T> _items = null;
        public List<T> Items => _items;

        public T this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }

        public void Add(T item)
        {
            _items = _items ?? new List<T>();
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public T Random()
        {
            return _items[UnityEngine.Random.Range(0, _items.Count)];
        }
    }
}
