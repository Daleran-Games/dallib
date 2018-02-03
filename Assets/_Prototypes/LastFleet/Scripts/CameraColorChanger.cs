using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastFleet
{
    public class CameraColorChanger : MonoBehaviour
    {
        [SerializeField]
        Camera cam;
        [SerializeField]
        Transform tracked;
        [SerializeField]
        Gradient color;
        [SerializeField]
        Vector2 minMaxDistance;

        // Update is called once per frame
        void Update()
        {
            float distance = tracked.position.magnitude;

            if (distance < minMaxDistance.x)
                cam.backgroundColor = color.Evaluate(0f);
            else if (distance > minMaxDistance.y)
                cam.backgroundColor = color.Evaluate(1f);
            else
                cam.backgroundColor = color.Evaluate((distance - minMaxDistance.x)/(minMaxDistance.y - minMaxDistance.x));
        }
    }
}

