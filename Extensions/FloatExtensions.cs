using UnityEngine;

namespace Tools.Extensions
{
    /// <summary>
    /// Extension methods for UnityEngine.Float
    /// </summary>
    public static class FloatExtensions
    {
        /// <summary>
        /// Return true if value is between min and max, return false otherwise
        /// </summary>
        /// <param name="self">self</param>
        /// <param name="min">min value</param>
        /// <param name="max">max value</param>
        /// <param name="include">include bounds</param>
        /// <returns></returns>
        public static bool InRange(this float self, float min, float max, bool include = true)
        {
            return include ? (self >= min && self <= max) : (self > min && self < max);
        }
    }
}
