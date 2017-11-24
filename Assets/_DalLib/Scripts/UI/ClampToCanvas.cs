using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.UI
{
    public class ClampToCanvas : MonoBehaviour
    {
        [SerializeField]
        Canvas canvas;

        // Update is called once per frame
        void Update()
        {
            transform.position = Clamp(transform.position);
        }

        public Vector3 Clamp(Vector3 newPos)
        {
            float x = newPos.x;
            float y = newPos.y;

            if (newPos.x < 0f)
                x = 0f;
            else if (newPos.x > canvas.pixelRect.width)
                x = canvas.pixelRect.width;

            if (newPos.y < 0f)
                y = 0f;
            else if (newPos.y > canvas.pixelRect.height)
                y = canvas.pixelRect.height;

            return new Vector3(x, y, newPos.z);
        }
    }
}

