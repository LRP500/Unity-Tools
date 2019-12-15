using UnityEngine;

namespace Tools.Variables
{
    public abstract class VariableEvaluator : ScriptableObject
    {
        public abstract bool Evaluate();
    }
}
