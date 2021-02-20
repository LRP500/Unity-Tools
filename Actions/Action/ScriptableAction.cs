using UnityEngine;

namespace Tools
{
    public abstract class ScriptableAction : ScriptableObject
    {
        public abstract void Execute();
    }

    public abstract class ScriptableAction<T> : ScriptableObject
    {
        public abstract void Execute(T parameter);
    }
}