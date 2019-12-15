using UnityEngine;

namespace Extensions
{
    /// <summary>
    /// Extension methods for UnityEngine.Transform
    /// </summary>
    public static class TransformExtensions
    {
        /// <summary>
        /// Sets the x component of the transform's position
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="x"></param>
        public static void SetPosX(this Transform transform, float x)
        {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        /// <summary>
        /// Sets the y component of the transform's position
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="y"></param>
        public static void SetPosY(this Transform transform, float y)
        {
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }

        /// <summary>
        /// Sets the z component of the transform's position
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="z"></param>
        public static void SetPosZ(this Transform transform, float z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, z);
        }

        /// <summary>
        /// Sets the x component of the transform's rotation
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="x"></param>
        public static void SetRotX(this Transform transform, float x)
        {
            transform.localEulerAngles = new Vector3(x, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }

        /// <summary>
        /// Sets the y component of the transform's rotation
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="y"></param>
        public static void SetRotY(this Transform transform, float y)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, y, transform.localEulerAngles.z);
        }


        /// <summary>
        /// Sets the z component of the transform's rotation
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="z"></param>
        public static void SetRotZ(this Transform transform, float z)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, z);
        }

        /// <summary>
        /// Sets the x component of the transform's local scale
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="x"></param>
        public static void SetScaleX(this Transform transform, float x)
        {
            transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        }

        /// <summary>
        /// Sets the y component of the transform's local scale
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="y"></param>
        public static void SetScaleY(this Transform transform, float y)
        {
            transform.localScale = new Vector3(transform.localScale.x, y, transform.localScale.z);
        }

        /// <summary>
        /// Sets the z component of the transform's local scale
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="z"></param>
        public static void SetScaleZ(this Transform transform, float z)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, z);
        }
    }
}