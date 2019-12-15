using Tools.Variables;
using UnityEngine;

namespace Tools.Cinematics
{
    public class RegisterCamera : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera = null;

        [SerializeField]
        private CameraVariable _cameraVariable = null;

        private void Awake()
        {
            _cameraVariable.SetValue(_camera);
        }
    }
}
