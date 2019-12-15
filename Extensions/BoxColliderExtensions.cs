using UnityEngine;

namespace Tools.Extensions
{
    public static class BoxColliderExtensions
    {
        /// <summary>
        /// Sets bounds size and center.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="bounds"></param>
        public static void SetBounds(this BoxCollider self, Bounds bounds)
        {
            self.size = bounds.size;
            self.center = bounds.center;
        }
    }
}
