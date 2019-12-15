using UnityEngine;

namespace Tools.Variables
{
    [CreateAssetMenu(menuName = "Tools/Variables/Evaluators/Float Evaluator")]
    public class FloatVariableEvaluator : VariableEvaluator
    {
        [SerializeField]
        private FloatVariable _target = null;

        [SerializeField]
        private NumericalEvaluation _evaluation = NumericalEvaluation.EqualTo;

        [SerializeField]
        private float _value = 0;

        public override bool Evaluate()
        {
            var evaluator = new NumericalEvaluator<float>();
            return evaluator.Evaluate(_target, _evaluation, _value);
        }
    }
}
