using UnityEngine;
using UnityEngine.UI;

namespace Tools.UI
{
    public class SliderValueSetter : ValueSetter
    {
        [SerializeField]
        private Slider _slider = null;

        protected override void Refresh()
        {
            _slider.value = Mathf.Clamp01(Mathf.InverseLerp(Min, Max, Value));
        }
    }
}