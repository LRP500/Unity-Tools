using UnityEngine;

namespace Tools.Persistence
{
    [System.Serializable]
    public class Table<T> : ScriptableObject
    {
        [System.Serializable]
        public class Entry
        {
            public string Key;
            public T Value;
        }
    }
}