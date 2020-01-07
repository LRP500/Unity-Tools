using UnityEngine;

namespace Tools.Shaders
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    public class ReplacementShaderEffect : MonoBehaviour
    {
        [SerializeField]
        private Shader _shader = null;

        [SerializeField]
        private string _tag = string.Empty;

        private Camera _camera = null; 

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void OnEnable()
        {
            if (_shader != null)
            {
                _camera.SetReplacementShader(_shader, _tag);
            }
        }

        private void OnDisable()
        {
            _camera.ResetReplacementShader();
        }
    }
}
