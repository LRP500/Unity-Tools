using UnityEngine;

namespace Tools.Time
{
    public static class TimeUtility
    {
        public static string Format(float time, bool includeMilliseconds = false)
        {
            int minutes = (int)time / 60;
            int seconds = (int)time - 60 * minutes;
            int milliseconds = (int)(1000 * (time - minutes * 60 - seconds));

            string formatter = includeMilliseconds ? "{0:00}:{1:00}:{2:000}" : "{0:00}:{1:00}";
            return string.Format(formatter, minutes, seconds, milliseconds);
        }
    }
}
