using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.IO;

namespace DaleranGames.LastFleet
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        SensorSystem sensors;

        [SerializeField]
        GameObject projectile;

        [SerializeField]
        float roundsPerSecond;
        float fireDelay;
        float nextFire = 0f;

        [SerializeField]
        float range;
        [SerializeField]
        float damage;
        float sqrRange;
        [SerializeField]
        float projectileVelocity;


        [SerializeField]
        float suppliesPerShot;
        [SerializeField]
        Supplies supplySystem;

        Rigidbody2D shipRB;

        Rigidbody2D target;

        [SerializeField]
        Vector2 aimPoint;

        // Use this for initialization
        void Start()
        {
            shipRB = GetComponentInParent<Rigidbody2D>();
            fireDelay = 1f / roundsPerSecond;
            sqrRange = range * range;
        }

        // Update is called once per frame
        void Update()
        {
            target = sensors.GetClosestContact(transform.position);
            if (target != null)
            {
                Vector2 direction = target.transform.position - transform.position;
                float distance = direction.magnitude;
                if (distance < range)
                {
                    Vector2 projV = shipRB.velocity + (Vector2)transform.up * projectileVelocity;
                    float targetSpeed = target.velocity.magnitude;

                    if (targetSpeed < 0.5f)
                    {
                        aimPoint = target.position;
                        float angle = Vector2.SignedAngle(transform.up, direction);
                        transform.Rotate(0f, 0f, angle);
                    } else
                    {
                        float projTravelTime = distance / projV.magnitude;
                        aimPoint = target.position + target.velocity * projTravelTime;
                        float angle = Vector2.SignedAngle(transform.up, aimPoint - (Vector2)transform.position);
                        transform.Rotate(0f, 0f, angle);
                    }
                    FireRound(projV);
                }
            } else
                transform.Set2DRotation(0, Space.Self);
        }

        void FireRound(Vector2 projVelocity)
        {
            if (Time.time > nextFire)
            {
                
                if (supplySystem == null || supplySystem.UseSupplies(suppliesPerShot))
                {
                    nextFire = Time.time + fireDelay;
                    GameObject go = Instantiate(projectile, transform.position, transform.rotation);
                    Projectile proj = go.GetComponent<Projectile>();
                    proj.Initialize(projVelocity, damage, range);
                }
            }
        }
                     

    }
}
