using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.IO;

namespace DaleranGames.LastFleet
{
    public class Weapon : MonoBehaviour
    {
        RayPositionReporter AimingCursor;

        private void Start()
        {
            AimingCursor = GameObject.FindGameObjectWithTag("MouseCursor").GetRequiredComponent<RayPositionReporter>();
        }

        // Update is called once per frame
        void Update()
        {
            float angle = Vector2.SignedAngle(transform.up,AimingCursor.WorldPosition-transform.position);
            transform.Rotate(0f, 0f, angle);
        }
    }
}
