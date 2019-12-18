using UnityEngine;

namespace Tools.Editor
{
    public class EditorOnly : MonoBehaviour
    {
        public bool disableOnPlay = true;

        private void Awake()
        {
#if !UNITY_EDITOR
       Destroy(this.gameObject);
#else
            gameObject.SetActive(!disableOnPlay);
#endif
        }
    }
}
