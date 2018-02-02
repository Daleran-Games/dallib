using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastFleet
{
    public class Fleet : MonoBehaviour
    {

        public NavTarget Nav;
        Rigidbody2D rb;

        public float MaxSpeed = 999f;
        public float MaxAcceleration = 999f;
        public float VelocityError = 0.1f;

        Vector2 desiredVelocity;
        public Vector2 DesiredVelocity { get { return desiredVelocity; } }

        // Use this for initialization
        void Start()
        {
            rb = gameObject.GetRequiredComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            float desiredSpeed = MaxSpeed * Nav.Throttle;
            desiredVelocity = Nav.Heading.normalized * desiredSpeed;

        }

        private void FixedUpdate()
        {
            Vector2 steering = Vector2.ClampMagnitude( desiredVelocity - rb.velocity,MaxAcceleration);

            if (steering.magnitude > VelocityError)
            {
                rb.AddForce(steering);
            }
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
        }
    }
}

