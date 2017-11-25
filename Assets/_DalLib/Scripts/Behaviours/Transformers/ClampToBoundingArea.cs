using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public class ClampToBoundingArea : MonoBehaviour
    {
        public Rect BoundingArea = new Rect(0f, 0f, 10f, 10f);
        public bool UseLateUpdate = false;

        // Update is called once per frame
        void Update()
        {
            if (!UseLateUpdate)
                Clamp();
        }

        void LateUpdate()
        {
            if (UseLateUpdate)
                Clamp();
        }

        private void Clamp()
        {
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, BoundingArea.xMin, BoundingArea.xMax), Mathf.Clamp(transform.position.y, BoundingArea.yMin, BoundingArea.yMax));
        }
    }
}
