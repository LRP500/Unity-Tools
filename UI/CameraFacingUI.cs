using Tools.Variables;
using UnityEngine;

namespace Tools.UI
{
    public class CameraFacingUI : MonoBehaviour
    {
        [SerializeField]
        private CameraVariable _camera = null;

        private void Update()
        {
            RotateTowardCamera();
        }

        private void RotateTowardCamera()
        {
            Vector3 worldPosition = transform.position + _camera.Value.transform.rotation * Vector3.back;
            Vector3 worldUp = _camera.Value.transform.rotation * Vector3.up;
            transform.LookAt(worldPosition, worldUp);
            transform.Rotate(0, 180, 0);
        }
    }
}
