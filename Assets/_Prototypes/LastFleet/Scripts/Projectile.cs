using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastFleet
{
    public class Projectile : MonoBehaviour
    {

        [SerializeField]
        float velocity;
        [SerializeField]
        float damage;
        [SerializeField]
        float burnOutDistance;

        Vector3 firedPosition;
        Rigidbody2D rb;

        float distance;

        private void Start()
        {
            rb = gameObject.GetRequiredComponent<Rigidbody2D>();
            firedPosition = transform.position;
            rb.velocity = rb.velocity + (Vector2)(transform.up * velocity);
        }

        // Update is called once per frame
        void Update()
        {
            distance = Vector2.Distance(firedPosition, transform.position);

            if (distance > burnOutDistance)
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Condition otherCond = collision.gameObject.GetComponent<Condition>();

            if (otherCond != null)
            {
                otherCond.DealDamage(damage);
                Destroy(this);
            }
        }

    }
}

