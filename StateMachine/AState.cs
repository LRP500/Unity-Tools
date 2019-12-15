using System.Collections;
using UnityEngine;

namespace Tools
{
    /// <summary>
    /// State machine state's base class.
    /// </summary>
    public abstract class AState : ScriptableObject
    {
        [SerializeField]
        private AState _nextState = null;
        public AState NextState => _nextState;

        /// <summary>
        /// Runs state's base behavior.
        /// </summary>
        /// <param name="args"></param>
        public virtual IEnumerator Run(AStateController controller)
        {
            yield return controller.StartCoroutine(RunExtend());
        }

        /// <summary>
        /// Extends state's base behavior.
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerator RunExtend();

        /// <summary>
        /// Checks state's end conditions.
        /// </summary>
        /// <returns></returns>
        protected abstract bool CheckEndConditions();
    }
}
