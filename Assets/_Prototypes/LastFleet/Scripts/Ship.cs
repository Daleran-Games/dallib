using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastFleet
{
    public class Ship : MonoBehaviour
    {
        public Fleet Fleet;

        public float MaxSpeed;
        public float MaxAcceleration;

        Rigidbody2D rb;
        Vector2 offset;


        // Use this for initialization
        void Start()
        {
            if (Fleet.MaxSpeed > MaxSpeed)
                Fleet.MaxSpeed = MaxSpeed;

            if (Fleet.MaxAcceleration > MaxAcceleration)
                Fleet.MaxAcceleration = MaxAcceleration;

            offset = Fleet.transform.position - transform.position;
            rb = gameObject.GetRequiredComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
 
        }
    }
}
