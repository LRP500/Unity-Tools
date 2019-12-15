using UnityEngine;

namespace Tools.Variables
{
    public abstract class VariableModifier : ScriptableObject
    {
        public abstract void Modify();
    }

    public enum NumericalOperator
    {
        AddValue,
        AddPercentage,
        SetEqualTo,
        MultiplyBy,
        DivideBy
    }

    public enum BooleanOperator
    {
        Set,
        And,
        Or,
        Not
    }
}