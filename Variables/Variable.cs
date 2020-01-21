using UnityEngine;

namespace Tools.Variables
{
    /// <summary>
    /// ScriptableObject Variable's base class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Variable<T> : ScriptableObject
    {
        public static event System.Action OnValueChanged;

        [SerializeField]
        protected T _value = default;
        public T Value => _value;

        public void SetValue(T value)
        {
            T oldValue = _value;
            _value = value;

            if ((_value == null && oldValue != null) ||
                (_value != null && !_value.Equals(oldValue)))
            {
                OnValueChanged?.Invoke();
            }
        }

        /// <summary>
        /// Reset variable to it's default value.
        /// </summary>
        public void Clear()
        {
            SetValue(default);
        }

        private void OnValidate()
        {
            OnValueChanged?.Invoke();
        }

        public void Subscribe(System.Action callback)
        {
            OnValueChanged += callback;
        }

        public void Unsubscribe(System.Action callback)
        {
            OnValueChanged -= callback;
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public static implicit operator T(Variable<T> variable)
        {
            return variable.Value;
        }
    }
}
