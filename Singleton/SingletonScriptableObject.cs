using UnityEngine;

namespace Tools
{
    public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        public static T Instance { get; set; } = null;

        protected virtual void OnEnable()
        {
            Instance = this as T;
        }
    }
}