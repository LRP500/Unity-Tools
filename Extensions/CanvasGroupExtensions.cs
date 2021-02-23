using UnityEngine;

namespace Tools.Extensions
{
    public static class CanvasGroupExtensions
    {
        /// <summary>
        /// Set the canvas group visibility and interactability.
        /// </summary>
        /// <param name="group">The canvas group.</param>
        /// <param name="visible">The visibile state.</param>
        public static void SetVisible(this CanvasGroup group, bool visible)
        {
            group.alpha = visible ? 1 : 0;
            group.blocksRaycasts = visible;
            group.interactable = visible;
        }

        /// <summary>
        /// Returns true if canvas group is visible, else returns false.
        /// </summary>
        /// <param name="group">The canvas group.</param>
        /// <returns></returns>
        public static bool IsVisible(this CanvasGroup group)
        {
            return group.alpha == 1;
        }
    }
}
