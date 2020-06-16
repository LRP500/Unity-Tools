using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tools.UI
{
    public class ToggleGroup : MonoBehaviour
    {
        [SerializeField]
        private Toggle _firstSelected = null;

        private Toggle _lastSelectedToggle = null;
        private Toggle _currentSelectedToggle = null;

        private List<Toggle> _toggles = null;

        private void Start()
        {
            _toggles = GetComponentsInChildren<Toggle>().ToList();

            for (int i = 0; i < _toggles.Count; i++)
            {
                _toggles[i].ToggleGroup = this;
            }

            if (_toggles.Contains(_firstSelected))
            {
                _firstSelected.SetSelected(true);
            }
        }

        public void SetCurrentlySelected(Toggle value)
        {
            if (_currentSelectedToggle != null)
            {
                if (_currentSelectedToggle != value)
                {
                    _currentSelectedToggle.SetSelected(false);
                    _lastSelectedToggle = _currentSelectedToggle;
                }
            }

            _currentSelectedToggle = value;
        }

        public void DeselectEverything()
        {
            if (_currentSelectedToggle != null)
            {
                _lastSelectedToggle = _currentSelectedToggle;
                _currentSelectedToggle = null;
            }

            for (int i = 0; i < _toggles.Count; i++)
            {
                _toggles[i].SetSelected(false);
            }
        }
    }
}