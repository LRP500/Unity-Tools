using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tools.Navigation
{
    [CreateAssetMenu(menuName = "Tools/Navigation/Navigation Manager")]
    public class NavigationManager : SingletonScriptableObject<NavigationManager>
    {
        [SerializeField]
        private SceneReference _master = null;

        [SerializeField]
        private SceneReference _loadingScreen = null;

        public IEnumerator FastLoad(SceneReference scene)
        {
            yield return LoadAdditive(scene);

            yield return UnloadAllScenes(new List<Scene>
            {
                SceneManager.GetSceneByPath(scene.path)
            });
        }

        public IEnumerator DeepLoad(SceneReference scene, System.Action loadingScreenCallback)
        {
            if (_loadingScreen == null || string.IsNullOrEmpty(_loadingScreen.path))
            {
                Debug.LogWarning("Couldn't deep load : loading scene path is set to null", this);
                yield return FastLoad(scene);
            }
            else
            {
                List<Scene> exceptions = new List<Scene>
                {
                    SceneManager.GetSceneByPath(_master.path),
                    SceneManager.GetSceneByPath(_loadingScreen.path)
                };

                yield return LoadAdditive(_loadingScreen);

                loadingScreenCallback?.Invoke();
            }
        }

        public IEnumerator LoadAdditive(SceneReference scene)
        {
            if (!SceneManager.GetSceneByPath(scene.path).isLoaded)
            {
                yield return SceneManager.LoadSceneAsync(scene.path, LoadSceneMode.Additive);
                SceneManager.SetActiveScene(SceneManager.GetSceneByPath(scene.path));
            }
        }

        private Scene[] GetLoadedScenes()
        {
            int sceneCount = SceneManager.sceneCount;
            Scene[] loadedScenes = new Scene[sceneCount];

            for (int i = 0, length = SceneManager.sceneCount; i < length; i++)
            {
                loadedScenes[i] = SceneManager.GetSceneAt(i);
            }

            return loadedScenes;
        }

        public IEnumerator UnloadAllScenes(List<Scene> exceptions = null)
        {
            foreach (Scene loadedScene in GetLoadedScenes())
            {
                /// Active scene
                if (loadedScene == SceneManager.GetActiveScene())
                {
                    continue;
                }

                /// Master scene
                if (loadedScene.path == _master.path)
                {
                    continue;
                }

                /// Exceptions
                if (exceptions != null && exceptions.Contains(loadedScene))
                {
                    continue;
                }

                yield return SceneManager.UnloadSceneAsync(loadedScene);
            }
        }

        public static void QuitGame()
        {
#if UNITY_EDITOR
            Debug.Log("Application.Quit()");
            UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
        }
    }
}
