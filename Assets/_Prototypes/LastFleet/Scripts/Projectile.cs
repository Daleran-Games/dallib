using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastFleet
{
    public class Projectile : MonoBehaviour
    {


        float damage;
        float burnOutDistance = float.PositiveInfinity;

        Vector3 firedPosition;
        Rigidbody2D rb;

        float distance;
        bool initialized = false;

        public void Initialize(Vector2 velocity,float damage, float range)
        {
            rb = gameObject.GetRequiredComponent<Rigidbody2D>();
            firedPosition = transform.position;
            rb.velocity = velocity;
            burnOutDistance = range;
            this.damage = damage;
            initialized = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (initialized)
            {
                distance = Vector2.Distance(firedPosition, transform.position);
                if (distance > burnOutDistance)
                    Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Condition otherCond = collision.gameObject.GetComponent<Condition>();

            if (otherCond != null)
            {
                otherCond.DealDamage(damage);
                Destroy(this.gameObject);
            }

        }

    }
}

