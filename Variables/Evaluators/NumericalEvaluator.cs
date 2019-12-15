using System;

namespace Tools
{
    public class NumericalEvaluator<T> where T : IComparable
    {
        public bool HasValue { get; private set; } = false;
        public bool Result { get; private set; }

        public bool Evaluate(T valueA, NumericalEvaluation evaluation, T valueB)
        {
            switch (evaluation)
            {
                case NumericalEvaluation.EqualOrLesserThan:
                    Result = valueA.CompareTo(valueB) <= 0;
                    break;
                case NumericalEvaluation.EqualOrGreaterThan:
                    Result = valueA.CompareTo(valueB) >= 0;
                    break;
                case NumericalEvaluation.NotEqualTo:
                    Result = valueA.CompareTo(valueB) != 0;
                    break;
                case NumericalEvaluation.EqualTo:
                    Result = valueA.CompareTo(valueB) == 0;
                    break;
                default: return false;
            }
            HasValue = true;
            return Result;
        }
    }

    public enum NumericalEvaluation
    {
        EqualOrLesserThan,
        EqualOrGreaterThan,
        NotEqualTo,
        EqualTo
    }
}
