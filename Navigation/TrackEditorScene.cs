using UnityEngine;

namespace Tools.Navigation
{
    public class TrackEditorScene : MonoBehaviour
    {
        [SerializeField]
        private SceneReference _currentScene = null;

        private void Awake()
        {
            NavigationManager.Instance.TrackScene(_currentScene);
        }
    }
}
