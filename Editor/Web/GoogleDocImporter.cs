using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace Tools
{
    [CreateAssetMenu(menuName = "Tools/Data Importer")]
    public class GoogleDocImporter : ScriptableObject
    {
        /// <summary>
        /// Base GoogleSheets URL.
        /// </summary>
        public static readonly string baseURL = "https://docs.google.com/spreadsheets/d/";

        public static readonly string exportURL = "/export?format=csv";

        [SerializeField]
        private List<GoogleDoc> _googleDocs = null;

        [Button]
        public void ImportAll()
        {
            foreach (var doc in _googleDocs)
            {
                foreach (var sheet in doc.sheets)
                {
                    var path = $"{Path.GetDirectoryName(AssetDatabase.GetAssetPath(this))}/";
                    EditorCoroutine.Start(DownloadCSV(doc.ID, Parse, sheet.ID, true, path, sheet.name));
                }
            }

            AssetDatabase.Refresh();
        }

        /// <summary>
        /// Downloads a sheet from doc ID.
        /// </summary>
        /// <param name="docID"></param>
        /// <param name="callback"></param>
        /// <param name="saveAsset"></param>
        /// <param name="assetName"></param>
        /// <param name="sheetID"></param>
        /// <returns></returns>
        public IEnumerator DownloadCSV(string docID,
            Action<string> callback,
            string sheetID = null,
            bool saveAsset = false,
            string destinationPath = null,
            string assetName = null)
        {
            /// Create URL
            string url = $"{baseURL}{docID}{exportURL}";
            if (!string.IsNullOrEmpty(sheetID))
            {
                url += $"&gid={sheetID}";
            }

            /// Send web request
            UnityWebRequest webRequest = UnityWebRequest.Get(url);
            yield return webRequest.SendWebRequest();

            /// Log results
            if (webRequest.isNetworkError)
            {
                Debug.Log($"Error: {webRequest.error}: {url}");
            }
            else
            {
                if (saveAsset)
                {
                    SaveAsset(webRequest.downloadHandler.text, assetName ?? sheetID, destinationPath);
                }

                callback?.Invoke(webRequest.downloadHandler.text);
            }
        }

        /// <summary>
        /// Saves text data as .csv asset.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="assetName"></param>
        /// <param name="destinationPath"></param>
        private void SaveAsset(string text, string assetName, string destinationPath)
        {
            File.WriteAllText($"{destinationPath}{assetName}.csv", text);
            AssetDatabase.Refresh();
        }

        private void Parse(string data)
        {
        }
    }

    [InlineEditor]
    [Serializable]
    public class GoogleDoc
    {
        public string ID;
        public List<GoogleSheet> sheets;

        [Tooltip("If not path is given, assets are instanciated at current position")]
        public string assetPath;

        [Button]
        public void OpenURL()
        {
            Application.OpenURL(GoogleDocImporter.baseURL + ID);
        }
    }

    [InlineEditor]
    [Serializable]
    public class GoogleSheet
    {
        public string name;
        public string ID;
    }
}
