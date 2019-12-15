using Sirenix.OdinInspector;
using UnityEngine;

namespace Tools
{
    /// <summary>
    /// State machine's controller base class.
    /// </summary>
    public abstract class AStateController : MonoBehaviour
    {
        /// <summary>
        /// Starting state.
        /// </summary>
        [Space]
        [SerializeField]
        private AState _initialState = null;
        public AState InitialState => _initialState;

        /// <summary>
        /// Currently running state.
        /// </summary>
        [ReadOnly]
        [SerializeField]
        private AState _currentState = null;
        public AState CurrentState => _currentState;

        /// <summary>
        /// Previously visited state.
        /// </summary>
        [ReadOnly]
        [SerializeField]
        private AState _previousState = null;
        public AState PreviousState => _previousState;

        [Space]
        [SerializeField]
        protected bool _autoStart = true;

        private void Start()
        {
            if (_autoStart)
            {
                Run();
            }
        }

        /// <summary>
        /// Launch state machine's initial state.
        /// </summary>
        public void Run()
        {
            RunState(_initialState);
        }

        /// <summary>
        /// Switches currently running state with given state.
        /// </summary>
        /// <param name="state"></param>
        public virtual void RunState(AState state)
        {
            _previousState = _currentState;
            _currentState = state;
            StartCoroutine(state.Run(this));
        }

        /// <summary>
        /// Switches to default next state.
        /// </summary>
        public void RunNextState()
        {
            RunState(_currentState.NextState);
        }
    }
}
