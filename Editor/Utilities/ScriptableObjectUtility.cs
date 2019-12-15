using System.IO;
using UnityEditor;
using UnityEngine;

namespace Tools.Utilities
{
    public static class ScriptableObjectUtility
    {
        /// <summary>
        /// Creates an instance of the given scriptable object type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assetPath"></param>
        /// <param name="assetName"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public static T CreateAsset<T>(string assetPath = null, string assetName = null, bool overwrite = false)
            where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();

            /// Path
            string path = assetPath == "" ? AssetDatabase.GetAssetPath(Selection.activeObject) : assetPath;
            if (string.IsNullOrEmpty(path))
            {
                path = "Assets";
            }
            else if (Path.GetExtension(path) != "")
            {
                /// Removes extension.
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            }

            /// Name
            var name = assetName ?? $"New {typeof(T).Name}";
            if (overwrite && File.Exists($"{path}/{name}.asset"))
            {
                DeleteAsset($"{path}/{name}.asset");
            }

            string fullPath = AssetDatabase.GenerateUniqueAssetPath($"{path}/{name}.asset");

            AssetDatabase.CreateAsset(asset, fullPath);
            AssetDatabase.Refresh();

            return asset;
        }

        /// <summary>
        /// Deletes asset at path from asset database.
        /// </summary>
        /// <param name="assetPath"></param>
        public static void DeleteAsset(string assetPath)
        {
            AssetDatabase.DeleteAsset(assetPath);
            AssetDatabase.Refresh();
        }
    }
}
