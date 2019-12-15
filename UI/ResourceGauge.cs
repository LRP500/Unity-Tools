using System.Collections;
using TMPro;
using Tools.References;
using UnityEngine;
using UnityEngine.UI;

namespace Tools.UI
{
    public abstract class ResourceGauge : MonoBehaviour
    {
        [SerializeField]
        private Slider _mainSlider = null;

        [SerializeField]
        private Slider _subSlider = null;

        [SerializeField]
        private TextMeshProUGUI _valueText = null;

        [Space]

        [SerializeField]
        private float _lerpTime = 0f;

        [SerializeField]
        private float _lerpDelay = 0f;

        [Space]

        [SerializeField]
        private ColorReference _mainColor = null;

        [SerializeField]
        private ColorReference _positiveColor = null;

        [SerializeField]
        private ColorReference _negativeColor = null;

        private Coroutine _coroutine = null;

        private void Start()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            _mainSlider.targetGraphic.color = _mainColor;
        }

        protected void RefreshText()
        {
            _valueText.text = string.Join("/", _mainSlider.value, _mainSlider.maxValue);
        }

        public void SetCurrent(float value, bool animate)
        {
            if (value != _mainSlider.value)
            {
                if (animate == false)
                {
                    _mainSlider.value = value;
                    _subSlider.value = value;
                }
                else
                {
                    if (_coroutine != null)
                    {
                        StopCoroutine(_coroutine);
                    }

                    if (value > _mainSlider.value)
                    {
                        _subSlider.value = value;
                        _subSlider.targetGraphic.color = _positiveColor.Value;
                        _coroutine = StartCoroutine(AnimateSlider(_mainSlider, value, _lerpTime, _lerpDelay));
                    }
                    else
                    {
                        _mainSlider.value = value;
                        _subSlider.targetGraphic.color = _negativeColor.Value;
                        _coroutine = StartCoroutine(AnimateSlider(_subSlider, value, _lerpTime, _lerpDelay));
                    }
                }

                RefreshText();
            }
        }

        public void SetMax(float value)
        {
            if (value != _mainSlider.maxValue)
            {
                _mainSlider.maxValue = value;
                _subSlider.maxValue = value;

                RefreshText();
            }
        }

        private IEnumerator AnimateSlider(Slider slider, float value, float lerpTime, float lerpDelay)
        {
            if (lerpDelay != 0)
            {
                yield return new WaitForSeconds(lerpDelay);
            }

            if (lerpTime == 0)
            {
                slider.value = value;
            }
            else
            {
                float elapsed = 0f;

                while (elapsed < lerpTime)
                {
                    elapsed += Time.deltaTime;
                    float lerpValue = elapsed / lerpTime;
                    slider.value = Mathf.Lerp(slider.value, value, lerpValue);
                    yield return null;
                }
            }
        }
    }
}
