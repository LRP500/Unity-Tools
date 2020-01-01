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

        public IEnumerator SwitchScenes(SceneReference scene)
        {
            List<Scene> exceptions = new List<Scene>
            {
                SceneManager.GetSceneByPath(_master.path),
                SceneManager.GetSceneByPath(scene.path)
            };

            yield return LoadScene(scene);
            yield return UnloadAllScenes(exceptions);
        }

        public IEnumerator LoadScene(SceneReference scene)
        {
            yield return SceneManager.LoadSceneAsync(scene.path, LoadSceneMode.Additive);

            SceneManager.SetActiveScene(SceneManager.GetSceneByPath(scene.path));
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

        private IEnumerator UnloadAllScenes(List<Scene> exceptions = null)
        {
            foreach (Scene loadedScene in GetLoadedScenes())
            {
                if (exceptions != null && !exceptions.Contains(loadedScene))
                {
                    yield return SceneManager.UnloadSceneAsync(loadedScene);
                }
            }
        }

        public void QuitGame()
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
