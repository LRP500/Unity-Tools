﻿using UnityEngine;

namespace Tools
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// Check to see if we're about to be destroyed.
        private static bool _shuttingDown = false;
        private static object _Lock = new object();
        private static T _instance;

        /// <summary>
        /// Access singleton instance through this propriety.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_shuttingDown)
                {
                    Debug.LogWarning("Instance '" + typeof(T) + "' already destroyed.");
                    return null;
                }

                lock (_Lock)
                {
                    if (_instance == null)
                    {
                        /// Search for existing instance.
                        _instance = (T)FindObjectOfType(typeof(T));

                        /// Create new instance if one doesn't already exist.
                        if (_instance == null)
                        {
                            /// Need to create a new GameObject to attach the singleton to.
                            var singletonObject = new GameObject();
                            _instance = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T).ToString() + " (Singleton)";

                            /// Make instance persistent.
                            DontDestroyOnLoad(singletonObject);
                        }
                    }

                    return _instance;
                }
            }
        }

        private void OnApplicationQuit()
        {
            _shuttingDown = true;
        }

        private void OnDestroy()
        {
            _shuttingDown = true;
        }
    }
}
