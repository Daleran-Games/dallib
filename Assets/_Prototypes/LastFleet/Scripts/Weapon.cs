using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.IO;

namespace DaleranGames.LastFleet
{
    public class Weapon : MonoBehaviour
    {

        [SerializeField]
        GameObject projectile;

        [SerializeField]
        float roundsPerSecond;
        float fireDelay;
        float nextFire = 0f;

        RayPositionReporter AimingCursor;


        // Use this for initialization
        void Start()
        {
            fireDelay = 1f / roundsPerSecond;
            AimingCursor = GameObject.FindGameObjectWithTag("MouseCursor").GetRequiredComponent<RayPositionReporter>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
                FireRound();

            float angle = Vector2.SignedAngle(transform.up, AimingCursor.WorldPosition - transform.position);
            transform.Rotate(0f, 0f, angle);
        }

        void FireRound()
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireDelay;
                Instantiate(projectile, transform.position, transform.rotation);
            }
        }

        

    }
}
