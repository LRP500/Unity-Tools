using System.Collections;
using UnityEngine;

namespace Tools
{
    /// <summary>
    /// Pluggable behavior's base class.
    /// </summary>
    public abstract class ABehavior : ScriptableObject
    {
        /// <summary>
        /// Setups behavior on application start.
        /// </summary>
        /// <param name="controller"></param>
        public abstract void Initialize(IBehaviorController controller);

        /// <summary>
        /// Runs behavior.
        /// </summary>
        /// <param name="controller"></param>
        public abstract IEnumerator Run(IBehaviorController controller);
    }
}
