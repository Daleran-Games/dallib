using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastFleet
{
    public class Movement : MonoBehaviour
    {
        [Header("Parameters")]
        public float MaxSpeed = 95f;
        public float MaxForce = 35f;
        public float FuelBurnRate = 1f;

        [Header("Dependecies")]
        [SerializeField]
        Supplies supplies;
        [SerializeField]
        Rigidbody2D rb;


        [Header("Control")]
        public Vector2 DesiredVelocity = Vector2.zero;

        [Header("Ouput")]
        [SerializeField]
        [ReadOnly]
        Vector2 activeForce = Vector2.zero;
        public Vector2 ActiveForce { get { return activeForce; } }

        //Compile Time Settings
        public const float FORCE_TOLERANCE = 0.1f;
        public const float FORCE_TOLERANCE_SQR = FORCE_TOLERANCE * FORCE_TOLERANCE;



        // Use this for initialization
        void Start()
        {
            if (rb == null)
                rb = gameObject.GetRequiredComponent<Rigidbody2D>();

            if(supplies == null)
                supplies = gameObject.GetRequiredComponent<Supplies>();
        }

        private void FixedUpdate()
        {
            float throttle = rb.velocity.sqrMagnitude / (MaxSpeed * MaxSpeed);
            if (supplies.UseSupplies(FuelBurnRate * Time.fixedDeltaTime * throttle))
            {
                activeForce = Vector2.ClampMagnitude(DesiredVelocity - rb.velocity, MaxForce);

                if (activeForce.sqrMagnitude > FORCE_TOLERANCE_SQR)
                    rb.AddForce(activeForce);
                else
                    activeForce = Vector2.zero;
            }
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
        }
    } 
}
