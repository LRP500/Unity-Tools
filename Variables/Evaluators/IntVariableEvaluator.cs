using UnityEngine;

namespace Tools.Variables
{
    [CreateAssetMenu(menuName = "Tools/Variables/Evaluators/Int Evaluator")]
    public class IntVariableEvaluator : VariableEvaluator
    {
        [SerializeField]
        private IntVariable _target = null;

        [SerializeField]
        private NumericalEvaluation _evaluation = NumericalEvaluation.EqualTo;

        [SerializeField]
        private int _value = 0;

        public override bool Evaluate()
        {
            var evaluator = new NumericalEvaluator<int>();
            return evaluator.Evaluate(_target, _evaluation, _value);
        }
    }
}
