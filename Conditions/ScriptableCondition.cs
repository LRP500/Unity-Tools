using UnityEngine;

namespace Tools.Events
{
    public abstract class ScriptableCondition : ScriptableObject
    {
        public abstract bool Evaluate();
    }

    public abstract class ScriptableCondition<T> : ScriptableObject
    {
        public abstract bool Evaluate(T parameter);
    }
}