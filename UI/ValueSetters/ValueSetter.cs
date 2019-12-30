using Tools.References;
using UnityEngine;

namespace Tools.UI
{
    public abstract class ValueSetter : MonoBehaviour
    {
        public enum ValueSetterMode
        {
            OnUpdate,
            OnValueChanged
        }

        [SerializeField]
        private FloatReference _min = null;
        public float Min => _min;

        [SerializeField]
        private FloatReference _max = null;
        public float Max => _max;

        [SerializeField]
        private FloatReference _value = null;
        public float Value => _value;

        [SerializeField]
        private ValueSetterMode _updateMode = ValueSetterMode.OnUpdate;

        private void Update()
        {
            if (_updateMode == ValueSetterMode.OnUpdate)
            {
                Refresh();
            }
        }

        protected abstract void Refresh();

        public void SetMin(float value)
        {
            _min.SetValue(value);
        }

        public void SetMax(float value)
        {
            _max.SetValue(value);
        }

        public void SetValue(float value)
        {
            _value.SetValue(value);

            if (_updateMode == ValueSetterMode.OnValueChanged)
            {
                Refresh();
            }
        }
    }
}
