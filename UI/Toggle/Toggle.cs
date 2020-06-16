using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Tools.UI
{
    public class Toggle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField]
        private Animator _animator = null;

        [SerializeField]
        private UnityEvent _onSelect = null;
        public UnityEvent OnSelect => _onSelect;

        public ToggleGroup ToggleGroup { get; set; } = null;

        public bool IsSelected { get; private set; } = false;
        public bool IsDisabled { get; private set; } = false;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (IsDisabled)
            {
                return;
            }

            if (IsSelected)
            {
                OnDeselect();
            }
            else
            {
                SetSelected(true);
            }
        }

        public void OnDeselect()
        {
            if (!IsDisabled)
            {
                return;
            }

            SetSelected(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (IsDisabled)
            {
                return;
            }

            if (!IsSelected)
            {
                _animator.SetTrigger("Highlighted");
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (IsDisabled)
            {
                return;
            }

            if (!IsSelected)
            {
                _animator.SetTrigger("Normal");
            }
        }

        public void SetSelected(bool value)
        {
            if (IsDisabled)
            {
                return;
            }

            IsSelected = value;

            if (IsSelected == true)
            {
                if (ToggleGroup)
                {
                    ToggleGroup.SetCurrentlySelected(this);
                }

                _animator.SetTrigger("Selected");
            }
            else
            {
                _animator.SetTrigger("Normal");
            }

            _onSelect?.Invoke();
        }

        public void SetDisabled(bool value)
        {
            IsDisabled = value;

            if (IsDisabled == true)
            {
                IsSelected = false;
                _animator.SetTrigger("Disabled");
            }
            else
            {
                _animator.SetTrigger("Normal");
            }
        }
    }
}
