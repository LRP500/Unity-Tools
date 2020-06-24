using System.Collections;
using UnityEngine;

namespace Tools.UI
{
    public static class FadeEffect
    {
        public static IEnumerator FadeCanvas(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration, bool unscaled = false)
        {
            float startTime = GetTime(unscaled);
            float endTime = startTime + duration;
            float elapsed = 0f;

            canvasGroup.alpha = startAlpha;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            while (GetTime(unscaled) <= endTime)
            {
                elapsed = GetTime(unscaled) - startTime;
                float percentage = 1 / (duration / elapsed);

                // Fading out
                if (startAlpha > endAlpha)
                {
                    canvasGroup.alpha = startAlpha - percentage;
                }
                // Fading in
                else
                {
                    canvasGroup.alpha = startAlpha + percentage;
                }

                yield return new WaitForEndOfFrame();
            }

            canvasGroup.alpha = endAlpha;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        private static float GetTime(bool unscaled = false)
        {
            return unscaled ? Time.unscaledTime : Time.time;
        }
    }
}
