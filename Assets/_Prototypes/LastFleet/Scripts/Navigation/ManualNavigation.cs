using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastFleet
{
    public class ManualNavigation : MonoBehaviour
    {

        [Header("Dependecies")]
        [SerializeField]
        NavTarget nav;
        [SerializeField]
        Rigidbody2D rb;
        [SerializeField]
        Movement movement;


        [Header("Ouput")]
        [SerializeField]
        [ReadOnly]
        Vector2 desiredVelocity = Vector2.zero;
        public Vector2 DesiredVelocity { get { return desiredVelocity; } }


        // Use this for initialization
        void Start()
        {
            if (rb == null)
                rb = gameObject.GetRequiredComponent<Rigidbody2D>();

            if (movement == null)
                movement = gameObject.GetRequiredComponent<Movement>();
        }

        // Update is called once per frame
        void Update()
        {
            float desiredSpeed = movement.MaxSpeed * nav.Throttle;
            desiredVelocity = nav.Heading.normalized * desiredSpeed;
            movement.DesiredVelocity = desiredVelocity;
        }
    }

}