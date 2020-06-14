using System.Collections;
using UnityEngine;

namespace Tools.UI
{
    public static class FadeEffect
    {
        public static IEnumerator FadeCanvas(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
        {
            float startTime = Time.unscaledTime;
            float endTime = Time.unscaledTime + duration;
            float elapsed = 0f;

            canvasGroup.alpha = startAlpha;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            while (Time.time <= endTime)
            {
                elapsed = Time.unscaledTime - startTime;
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
        }
    }
}
