using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DaleranGames.LastFleet
{
    public class AutoTargeting : TargetingController
    {

        [Header("Parameters")]
        [SerializeField]
        float accuracyTolerance = 10f;

        [Header("Dependecies")]
        [SerializeField]
        protected SensorSystem sensors;

        [Header("Output")]
        [SerializeField]
        [ReadOnly]
        Rigidbody2D target;
        Vector2 targetDirection;
        [SerializeField]
        float targetDistance;


        public override Vector2 GetAimPoint(Weapon weapon)
        {
            target = sensors.GetClosestContact(weapon.transform.position);
            if (target != null)
            {
                targetDirection = target.transform.position - weapon.transform.position;
                targetDistance = targetDirection.magnitude;
                Vector2 projV = (Vector2)weapon.transform.up * weapon.ProjectileSpeed;
                float projTravelTime = targetDistance / projV.magnitude;
                return target.position + target.velocity * projTravelTime;
            }
            return weapon.transform.up;
        }

        public override bool ShouldFire(Weapon weapon)
        {
            if (target != null)
            {
                if (targetDistance < weapon.Range)
                {
                    return true;
                }
            }
            return false;
        }

    } 
}
