using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    [AddComponentMenu("Rendering/Step Camera Zoom")]
    public class StepZoom : MonoBehaviour
    {
        [SerializeField]
        float zoomStep = 16f;
        [SerializeField]
        float min = 4f;
        [SerializeField]
        float max = 128f;
        [SerializeField]
        float startZoom = 20f;
        [SerializeField]
        FloatReference mouseWheelControl;

        private Vector3 offset;
        private Camera cam;

        void Start()
        {
            offset = new Vector3(0f, 0f, -10f);
            cam = gameObject.GetRequiredComponent<Camera>();
            cam.orthographicSize = startZoom;

        }

        void LateUpdate()
        {
            if (mouseWheelControl > 0)
                ZoomCameraIn();
            else if (mouseWheelControl < 0)
                ZoomCameraOut();
        }

        void ZoomCameraIn()
        {
            cam.orthographicSize -= zoomStep;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, min, max);
        }

        void ZoomCameraOut()
        {
            cam.orthographicSize += zoomStep;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, min, max);
        }
    }
}
