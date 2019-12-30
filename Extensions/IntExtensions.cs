namespace Tool.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Returns true if value is between min and max, else returns false.
        /// </summary>
        /// <param name="self">self</param>
        /// <param name="min">min value</param>
        /// <param name="max">max value</param>
        /// <param name="include">include bounds</param>
        /// <returns></returns>
        public static bool InRange(this int self, int min, int max, bool include = false)
        {
            return include ? self >= min && self <= max : self > min && self < max;
        }
    }
}
