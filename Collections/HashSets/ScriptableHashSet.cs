using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Tools.Collections
{
    public abstract class ScriptableHashSet<T> : SerializedScriptableObject
    {
        [SerializeField] private HashSet<T> _items;
        public HashSet<T> Items => _items;

        private System.Action OnValueChanged;

        public void Subscribe(System.Action callback)
        {
            OnValueChanged += callback;
        }

        public void Unsubscribe(System.Action callback)
        {
            OnValueChanged -= callback;
        }

        public void Add(T item)
        {
            _items = _items ?? new HashSet<T>();
            _items.Add(item);
            OnValueChanged?.Invoke();
        }

        public void Remove(T item)
        {
            _items.Remove(item);
            OnValueChanged?.Invoke();
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void Clear()
        {
            _items.Clear();
            OnValueChanged?.Invoke();
        }
    }
}
