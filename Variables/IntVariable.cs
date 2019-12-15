using System;
using UnityEngine;

namespace Tools.Variables
{
    [CreateAssetMenu(menuName = "Tools/Variables/Int")]
    public class IntVariable : Variable<int>
    {
        public void Increment()
        {
            SetValue(_value + 1);
        }

        public void Decrement()
        {
            SetValue(_value - 1);
        }

        public void Add(int value)
        {
            SetValue(_value + value);
        }

        public void Substract(int value)
        {
            SetValue(_value - value);
        }

        public void MultiplyBy(int value)
        {
            SetValue(_value * value);
        }

        public void DivideBy(int value)
        {
            SetValue(value == 0 ? _value : _value / value);
        }

        public void Reset()
        {
            SetValue(default);
        }
    }
}
