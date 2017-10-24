using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace DaleranGames.Effects
{
    public class CinemachineZoom : MonoBehaviour
    {
        [SerializeField]
        List<CinemachineVirtualCamera> cameras;
        [SerializeField]
        int startingCamera = 1;
        [SerializeField]
        int currentCamera;

        // Use this for initialization
        void Start()
        {
            currentCamera = startingCamera;
            ToggleCamera(startingCamera);
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                ZoomCameraIn();
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
                ZoomCameraOut();
        }

        protected virtual void ZoomCameraIn()
        {
            if (currentCamera > 0)
            {
                currentCamera--;
                ToggleCamera(currentCamera);
            }
        }

        protected virtual void ZoomCameraOut()
        {
            if (currentCamera < cameras.Count)
            {
                currentCamera++;
                ToggleCamera(currentCamera);
            }
        }

        void ToggleCamera(int number)
        {
            for (int i = 0; i < cameras.Count; i++)
            {
                if (i <= number)
                    cameras[i].enabled = true;
                else
                    cameras[i].enabled = false;
            }
        }
    }
}
