using UnityEngine;

namespace Tools.Variables
{
    [CreateAssetMenu(menuName = "Tools/Variables/Modifiers/Float Modifier")]
    public class FloatVariableModifier : VariableModifier
    {
        [SerializeField]
        private FloatVariable _variable = null;

        [SerializeField]
        private float _value = 0f;

        public override void Modify()
        {
            _variable.SetValue(_value);
        }
    }
}
