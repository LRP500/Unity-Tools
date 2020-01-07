using UnityEngine;

namespace Tools.Shaders
{
    /// <summary>
    /// Enable/Disable local shader variant from material
    /// </summary>
    public class EnableLocalShaderVariant : MonoBehaviour
    {
        [SerializeField]
        private Material _material = null;

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
            _material.DisableKeyword(_variantName);
        }

        public void EnableVariant(string variantName)
        {
            _material.EnableKeyword(_variantName);
        }
    }
}
