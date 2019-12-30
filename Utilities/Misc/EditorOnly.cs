using UnityEngine;

namespace Tools.Editor
{
    public class EditorOnly : MonoBehaviour
    {
        public bool disableOnStart = true;

        private void Start()
        {
#if !UNITY_EDITOR
            Destroy(this.gameObject);
#else
            gameObject.SetActive(!disableOnStart);
#endif
        }
    }
}
