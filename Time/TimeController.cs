using Tools.Variables;
using UnityEngine;

namespace Tools.Time
{
    public class TimeController : MonoBehaviour
    {
        public static event System.Action<float> OnUpdateTick;

        [SerializeField]
        private BoolVariable _gamePaused = null;
        public bool IsGamePaused => _gamePaused.Value;

        [SerializeField]
        private float _tickInterval = 1f;

        [SerializeField]
        private bool _unscaledTick = false;

        [SerializeField]
        private TimeControllerVariable _runtimeReference = null;

        private static float _frameDelta = 0;
        private static float _tickDelta = 0;

        private static float _lastFrameTime = 0;
        private static float _lastTickTime = 0;

        private float _timer = 0;

        public float CurrentSpeedMultiplier { get; private set; } = 1;

        protected virtual void Awake()
        {
            _lastFrameTime = GetTime();
            _lastTickTime = GetTime();
            _timer = _tickInterval;

            _gamePaused.SetValue(false);
        }

        protected virtual void Update()
        {
            _frameDelta = GetTime() - _lastFrameTime;
            _lastFrameTime = GetTime();

            if (_gamePaused == false)
            {
                _timer += _frameDelta;
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
            _tickDelta = GetTime() - _lastTickTime; 
            _lastTickTime = GetTime();

            OnUpdateTick?.Invoke(_tickDelta);
        }

        public virtual void Pause()
        {
            UnityEngine.Time.timeScale = 0;
            _gamePaused.SetValue(true);
        }

        public virtual void Resume()
        {
            UnityEngine.Time.timeScale = CurrentSpeedMultiplier;
            _gamePaused.SetValue(false);
        }

        public virtual void SetSpeedMultiplier(float multiplier)
        {
            CurrentSpeedMultiplier = multiplier;
            UnityEngine.Time.timeScale = CurrentSpeedMultiplier;
        }

        public void RegisterOnTick(System.Action<float> callback)
        {
            OnUpdateTick += callback;
        }

        public void UnregisterOnTick(System.Action<float> callback)
        {
            OnUpdateTick -= callback;
        }

        private float GetTime()
        {
            return _unscaledTick ? UnityEngine.Time.realtimeSinceStartup : UnityEngine.Time.time;
        }
    }
}
