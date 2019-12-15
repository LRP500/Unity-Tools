using UnityEngine;

namespace Tools.Variables
{
    [CreateAssetMenu(menuName = "Tools/Variables/Evaluators/Bool Evaluator")]
    public class BoolVariableEvaluator : VariableEvaluator
    {
        [SerializeField]
        private BoolVariable _target = null;

        [SerializeField]
        private BooleanEvaluation _evaluation = BooleanEvaluation.EqualTo;

        [SerializeField]
        private bool _value = false;

        public override bool Evaluate()
        {
            var evaluator = new BooleanEvaluator();
            return evaluator.Evaluate(_target, _evaluation, _value);
        }
    }
}