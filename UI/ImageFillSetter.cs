using Tools.References;
using UnityEngine;
using UnityEngine.UI;

namespace Tools.UI
{
    public class ImageFillSetter : MonoBehaviour
    {
        [SerializeField]
        private Image _slider = null;

        [SerializeField]
        private FloatReference _min = null;

        [SerializeField]
        private FloatReference _max = null;

        [SerializeField]
        private FloatReference _value = null;

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
        }

        private void Update()
        {
            _slider.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(_min, _max, _value));
        }
    }
}
