using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DaleranGames.PixelArt
{
    [AddComponentMenu("Rendering/Pixel Perfect Camera")]
    public class PixelPerfectCamera : MonoBehaviour
    {
        public int PixelsPerUnit = 1;
        public float UnitsInPixels = 1 / PixelsPerUnit;

        int scale = 1;
        public int Scale
        {
            get { return scale; }
            set
            {
                if (value > 0)
                {
                    scale = value;
                    ScaleChanged?.Invoke(scale);
                }
            }
        }
        public event Action<int> ScaleChanged;

        protected Camera cam;
        // Use this for initialization
        void Start()
        {
            ScaleCamera();
        }

        private void OnEnable()
        {
            PixelPerfect.ScaleChanged += ScaleCamera;
        }

        private void OnDisable()
        {
            PixelPerfect.ScaleChanged -= ScaleCamera;
        }

        protected virtual float CalculateOrthographicSize(float scale)
        {
            return Screen.height / (scale * PixelPerfect.PixelsPerUnit) * 0.5f;
        }

        [ContextMenu("Scale Camera")]
        public void ScaleCamera()
        {
            ScaleCamera(PixelPerfect.Scale);
        }

        public void ScaleCamera(int scale)
        {
            cam = gameObject.GetRequiredComponent<Camera>();
            cam.orthographicSize = CalculateOrthographicSize(scale);
        }

    }
}

