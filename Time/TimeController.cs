using Sirenix.OdinInspector;
using Tools.Variables;
using UnityEngine;

namespace Tools.Time
{
    public class TimeController : MonoBehaviour
    {
        public static event System.Action<float> OnUpdateTick;

        [SerializeField]
        private BoolVariable _gamePaused;

        [SerializeField]
        private bool _live = true;

        [SerializeField]
        [EnableIf(nameof(_live))]
        private float _tickInterval = 1f;

        [SerializeField]
        [EnableIf(nameof(_live))]
        private bool _unscaledTick;

        [SerializeField]
        [EnableIf(nameof(_live))]
        private TimeControllerVariable _runtimeReference;

        [Header("Info Display")]

        [DisplayAsString]
        public string _timeScale = string.Empty;

        [DisplayAsString]
        public string _speedMultiplier = string.Empty;

        private float _frameDelta;
        private float _tickDelta;

        private float _lastFrameTime;
        private float _lastTickTime;

        private float _timer;

        public float _lastSpeedMultiplier;

        public float CurrentSpeedMultiplier { get; private set; } = 1;

        protected virtual void Awake()
        {
            _runtimeReference?.SetValue(this);

            _lastFrameTime = GetTime();
            _lastTickTime = GetTime();
            _timer = _tickInterval;

            SetSpeedMultiplier(1);
        }

        protected virtual void Update()
        {
            if (_live)
            {
                _frameDelta = GetTime() - _lastFrameTime;
                _lastFrameTime = GetTime();

                if (_gamePaused == false)
                {
                    _timer += _frameDelta * CurrentSpeedMultiplier;
                    if (_timer >= _tickInterval)
                    {
                        UpdateTick();
                        _timer = 0;
                    }
                }
            }

            _timeScale = UnityEngine.Time.timeScale.ToString();
            _speedMultiplier = CurrentSpeedMultiplier.ToString();
        }

        protected virtual void OnDestroy()
        {
            OnUpdateTick = null;
        }

        protected virtual void UpdateTick()
        {
            float currentTime = GetTime();
            _tickDelta = currentTime - _lastTickTime;
            _lastTickTime = currentTime;

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
            _lastSpeedMultiplier = CurrentSpeedMultiplier;
            CurrentSpeedMultiplier = multiplier;
        }

        public static void RegisterOnTick(System.Action<float> callback)
        {
            OnUpdateTick += callback;
        }

        public static void UnregisterOnTick(System.Action<float> callback)
        {
            OnUpdateTick -= callback;
        }

        private float GetTime()
        {
            return _unscaledTick ? UnityEngine.Time.realtimeSinceStartup : UnityEngine.Time.time;
        }

        public void Freeze()
        {
            SetSpeedMultiplier(0);
        }

        public void Unfreeze()
        {
            SetSpeedMultiplier(_lastSpeedMultiplier);
        }
    }
}