using Sirenix.OdinInspector;
using System.Collections;
using TMPro;
using Tools.References;
using UnityEngine;
using UnityEngine.UI;

namespace Tools.UI
{
    public abstract class ResourceGauge : MonoBehaviour
    {
        [Required]
        [SerializeField]
        private Slider _mainSlider = null;

        [SerializeField]
        private TextMeshProUGUI _valueText = null;
        public TextMeshProUGUI ValueText => _valueText;

        [Space]
        [SerializeField]
        private ColorReference _mainSliderColor = null;

        [Space]
        [SerializeField]
        private bool _animate = false;

        [SerializeField]
        [ShowIf(nameof(_animate))]
        private float _lerpTime = 0f;

        [SerializeField]
        [ShowIf(nameof(_animate))]
        private float _lerpDelay = 0f;

        [SerializeField]
        [ShowIf(nameof(_animate))]
        private Slider _subSlider = null;

        [SerializeField]
        [ShowIf(nameof(_animate))]
        private ColorReference _subSliderIncrementColor = null;

        [SerializeField]
        [ShowIf(nameof(_animate))]
        private ColorReference _subSliderDecrementColor = null;

        [Space]
        [SerializeField]
        [LabelText("Critical Treshold (%)")]
        private float _criticalTreshold = 25f;

        [SerializeField]
        private Color _criticalSliderColor = Color.white;

        private Coroutine _coroutine = null;

        private float _maximumValue = 0f;
        private float _currentValue = 0f;

        private void Start()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            _maximumValue = 0;
            _currentValue = 0;
            _mainSlider.targetGraphic.color = _mainSliderColor;
        }

        protected virtual void RefreshText()
        {
            if (_valueText)
            {
                _valueText.text = string.Join("/", _currentValue, _maximumValue);
            }
        }

        protected virtual void RefreshColor()
        {
            _mainSlider.targetGraphic.color = IsCritical() ? _criticalSliderColor : _mainSliderColor;
        }

        public void SetCurrent(float value, bool animate)
        {
            if (value != _currentValue)
            {
                /// _animate = global configuration
                /// animate = Local configuration for specific cases
                /// e.g initialization on game start
                if (animate == false || _animate == false)
                {
                    _mainSlider.value = value;

                    if (_subSlider)
                    {
                        _subSlider.value = value;
                    }
                }
                else
                {
                    if (_coroutine != null)
                    {
                        StopCoroutine(_coroutine);
                    }

                    if (value > _currentValue)
                    {
                        if (_subSlider)
                        {
                            _subSlider.value = value;
                            _subSlider.targetGraphic.color = _subSliderIncrementColor.Value;
                        }

                        _coroutine = StartCoroutine(AnimateSlider(_mainSlider, value, _lerpTime, _lerpDelay));
                    }
                    else
                    {
                        _mainSlider.value = value;

                        if (_subSlider)
                        {
                            _subSlider.targetGraphic.color = _subSliderDecrementColor.Value;
                            _coroutine = StartCoroutine(AnimateSlider(_subSlider, value, _lerpTime, _lerpDelay));
                        }
                    }
                }

                _currentValue = value;

                RefreshText();
                RefreshColor();
            }
        }

        public void SetMax(float value)
        {
            if (value != _maximumValue)
            {
                _maximumValue = value;
                _mainSlider.maxValue = _maximumValue;

                if (_subSlider)
                {
                    _subSlider.maxValue = _maximumValue;
                }

                RefreshText();
                RefreshColor();
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

        protected bool IsCritical()
        {
            float ratio = 1 / (_maximumValue / _currentValue);
            return ratio < (_criticalTreshold / 100);
        }
    }
}
