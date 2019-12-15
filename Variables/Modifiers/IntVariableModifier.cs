using UnityEngine;

namespace Tools.Variables
{
    [CreateAssetMenu(menuName = "Tools/Variables/Modifiers/Int Modifier")]
    public class IntVariableModifier : VariableModifier
    {
        [SerializeField]
        private IntVariable _variable = null;

        [SerializeField]
        private NumericalOperator _operator = NumericalOperator.AddValue;

        [SerializeField]
        private int _value = 0;

        public override void Modify()
        {
            switch (_operator)
            {
                case NumericalOperator.AddValue:
                    _variable.Add(_value); break;
                case NumericalOperator.AddPercentage:
                    _variable.Add(_variable.Value * _value / 100); break;
                case NumericalOperator.SetEqualTo:
                    _variable.SetValue(_value); break;
                case NumericalOperator.MultiplyBy:
                    _variable.MultiplyBy(_value); break;
                case NumericalOperator.DivideBy:
                    _variable.DivideBy(_value); break;
                default: break;
            }
        }
    }
}
