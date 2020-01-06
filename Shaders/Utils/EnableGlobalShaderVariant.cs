using UnityEngine;

namespace Tools
{
    /// <summary>
    /// Enable/Disable global shader variant
    /// </summary>
    public class EnableGlobalShaderVariant : MonoBehaviour
    {
        [SerializeField]
        private string _variantName = string.Empty;

        [SerializeField]
        private bool _enableOnAwake = true;

        private void Awake()
        {
            if (_enableOnAwake)
            {
                EnableVariant(_variantName);
            }
        }

        private void OnDestroy()
        {
            Shader.DisableKeyword(_variantName);            
        }

        public void EnableVariant(string variantName)
        {
            Shader.EnableKeyword(_variantName);
        }
    }
}
