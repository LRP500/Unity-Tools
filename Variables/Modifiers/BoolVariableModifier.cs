using UnityEngine;

namespace Tools.Variables
{
    [CreateAssetMenu(menuName = "Tools/Variables/Modifiers/Bool Modifier")]
    public class BoolVariableModifier : VariableModifier
    {
        [SerializeField]
        private BoolVariable _variable = null;

        [SerializeField]
        private BooleanOperator _type = BooleanOperator.Set;

        [SerializeField]
        private bool _value = false;

        public override void Modify()
        {
            switch (_type)
            {
                case BooleanOperator.Set:
                    _variable.SetValue(_value); break;
                case BooleanOperator.And:
                    _variable.SetValue(_variable.Value && _value); break;
                case BooleanOperator.Or:
                    _variable.SetValue(_variable.Value || _value); break;
                case BooleanOperator.Not:
                    _variable.SetValue(!_variable.Value); break;
                default: break;
            }
        }
    }
}
