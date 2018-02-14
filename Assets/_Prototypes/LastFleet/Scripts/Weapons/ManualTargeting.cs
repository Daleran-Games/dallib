using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.IO;

namespace DaleranGames.LastFleet
{
    public class ManualTargeting : TargetingController
    {
        RayPositionReporter AimingCursor;

        private void Start()
        {
            AimingCursor = GameObject.FindGameObjectWithTag("MouseCursor").GetRequiredComponent<RayPositionReporter>();
        }

        public override Vector2 GetAimPoint(Weapon weapon)
        {
            return AimingCursor.WorldPosition; ;
        }

        public override bool ShouldFire(Weapon weapon)
        {
            if (Input.GetMouseButton(0))
                return true;
            else
                return false;
        }


    }
}
