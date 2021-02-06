using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tools.Utilities
{
    public static class AbbreviationUtility
    {
        private static readonly SortedDictionary<long, string> abbrevations = new SortedDictionary<long, string>
        {
            {1000,"K"},
            {1000000, "M" },
            {1000000000, "B" },
            {1000000000000,"T"}
        };

        public static string Format(float number, string format = "0.00")
        {
            for (int i = abbrevations.Count - 1; i >= 0; i--)
            {
                KeyValuePair<long, string> pair = abbrevations.ElementAt(i);

                if (Mathf.Abs(number) >= pair.Key)
                {
                    return (number / pair.Key).ToString(format) + pair.Value;
                }
            }

            return number.ToString();
        }
    }
}
