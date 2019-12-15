
namespace Tools
{
    public class BooleanEvaluator
    {
        public bool Evaluate(bool valueA, BooleanEvaluation evaluation, bool valueB)
        {
            switch (evaluation)
            {
                case BooleanEvaluation.EqualTo:
                    return valueA.CompareTo(valueB) == 0;
                case BooleanEvaluation.NotEqualTo:
                    return valueA.CompareTo(valueB) != 0;
                default: return false;
            }
        }
    }

    public enum BooleanEvaluation
    {
        EqualTo,
        NotEqualTo
    }
}
