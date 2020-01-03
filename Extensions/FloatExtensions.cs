using UnityEngine;

namespace Tools.Extensions
{
    /// <summary>
    /// Extension methods for UnityEngine.Float
    /// </summary>
    public static class FloatExtensions
    {
        /// <summary>
        /// Return true if float is almost equal to value, return false otherwise. 
        /// </summary>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool AlmostEqual(this float self, float value, float tolerance)
        {
            return Mathf.Abs(self - value) < tolerance;
        }

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

        /// <summary>
        /// Remap value to another range.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="from1"></param>
        /// <param name="to1"></param>
        /// <param name="from2"></param>
        /// <param name="to2"></param>
        /// <returns></returns>
        public static float Convert(this float value, float minA, float maxA, float minB, float maxB)
        {
            float normal = Mathf.InverseLerp(minA, maxA, value);
            return Mathf.Lerp(minB, maxB, normal);
        }
    }
}