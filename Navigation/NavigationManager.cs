using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tools.Navigation
{
    [CreateAssetMenu(menuName = "Tools/Navigation/Navigation Manager")]
    public class NavigationManager : SingletonScriptableObject<NavigationManager>
    {
        public IEnumerator LoadScene(SceneReference scene)
        {
            yield return SceneManager.LoadSceneAsync(scene.path, LoadSceneMode.Single);
        }

        public IEnumerator LoadSceneAdditive(SceneReference scene)
        {
            yield return SceneManager.LoadSceneAsync(scene.path, LoadSceneMode.Additive);

            SceneManager.SetActiveScene(SceneManager.GetSceneByPath(scene.path));
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
