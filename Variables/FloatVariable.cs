using UnityEngine;

namespace Tools.Variables
{
    [CreateAssetMenu(menuName = "Tools/Variables/Float")]
    public class FloatVariable : Variable<float>
    {
        public void Add(float value)
        {
            SetValue(_value + value);
        }

        public void Substract(float value)
        {
            SetValue(_value - value);
        }

        public void MultiplyBy(float value)
        {
            SetValue(_value * value);
        }

        public void DivideBy(float value)
        {
            SetValue(value == 0 ? _value : _value / value);
        }
    }
}
