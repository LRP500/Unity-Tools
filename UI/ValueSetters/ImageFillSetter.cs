using UnityEngine;
using UnityEngine.UI;

namespace Tools.UI
{
    public class ImageFillSetter : ValueSetter
    {
        [SerializeField]
        private Image _slider = null;

        protected override void Refresh()
        {
            _slider.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(Min, Max, Value));
        }
    }
}
