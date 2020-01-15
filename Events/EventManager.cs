using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Tools
{
    [CreateAssetMenu(menuName = "Tools/Events/Event Manager")]
    public class EventManager : SingletonScriptableObject<EventManager>
    {
        public class GameEvent : UnityEvent<object>
        {
            public GameEvent(UnityAction<object> listener)
            {
                AddListener(listener);
            }
        }

        private Dictionary<string, GameEvent> _events = null;
        public Dictionary<string, GameEvent> Events
        {
            get
            {
                _events = _events ?? new Dictionary<string, GameEvent>();
                return _events;
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        public void Reset()
        {
            Events?.Clear();
        }

        public void Subscribe(string eventName, UnityAction<object> listener)
        {
            if (Events.TryGetValue(eventName, out GameEvent target))
            {
                target.AddListener(listener);
            }
            else
            {
                Events.Add(eventName, new GameEvent(listener));
            }
        }

        public void Unsubscribe(string eventName, UnityAction<object> listener)
        {
            if (Events.TryGetValue(eventName, out GameEvent target))
            {
                target.RemoveListener(listener);
            }
        }

        public void Trigger(string eventName)
        {
            Trigger(eventName, null);
        }

        public void Trigger(string eventName, object parameter)
        {
            if (Events.TryGetValue(eventName, out GameEvent target))
            {
                target.Invoke(parameter);
            }
        }
    }
}
