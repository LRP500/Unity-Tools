using Tools.Variables;
using UnityEngine;

namespace Tools.Time
{
    public class TimeController : MonoBehaviour
    {
        public static event System.Action OnUpdateTick;

        [SerializeField]
        private float _tickInterval = 1f;

        [SerializeField]
        private BoolVariable _gamePaused = null;
        public bool IsGamePaused => _gamePaused.Value;

        private static float _deltaTime = 0;

        private static float _lastFrameTime = 0;

        private float _timer = 0;

        protected virtual void Awake()
        {
            _lastFrameTime = UnityEngine.Time.realtimeSinceStartup;
            _gamePaused.SetValue(false);
        }

        protected virtual void Update()
        {
            _deltaTime = UnityEngine.Time.realtimeSinceStartup - _lastFrameTime;
            _lastFrameTime = UnityEngine.Time.realtimeSinceStartup;

            if (_gamePaused == false)
            {
                _timer += _deltaTime;
                if (_timer >= _tickInterval)
                {
                    UpdateTick();
                    _timer = 0;
                }
            }
        }

        protected virtual void OnDestroy()
        {
            OnUpdateTick = null;
        }

        protected virtual void UpdateTick()
        {
            OnUpdateTick?.Invoke();
        }

        public virtual void Pause()
        {
            UnityEngine.Time.timeScale = 0;
            _gamePaused.SetValue(true);
        }

        public virtual void Resume()
        {
            UnityEngine.Time.timeScale = 1;
            _gamePaused.SetValue(false);
        }

        public void RegisterOnTick(System.Action callback)
        {
            OnUpdateTick += callback;
        }

        public void UnregisterOnTick(System.Action callback)
        {
            OnUpdateTick -= callback;
        }
    }
}
