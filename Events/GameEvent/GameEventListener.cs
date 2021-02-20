using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Tools.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField]
        private GameEvent _event;

        [Space]
        
        [SerializeField]
        private List<ScriptableCondition> _conditions;

        [SerializeField]
        private List<ScriptableAction> _reactions;

        [Space]

        [SerializeField]
        private UnityEvent _reaction;

        private void OnEnable()
        {
            _event.RegisterListener(this);
        }

        private void OnDisable()
        {
            _event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            foreach (ScriptableCondition condition in _conditions)
            {
                if (!condition.Evaluate())
                {
                    return;
                }
            }

            foreach (ScriptableAction reaction in _reactions)
            {
                reaction.Execute();
            }

            _reaction.Invoke();
        }
    }
}
