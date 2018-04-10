using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastFleet
{
    public class Fleet : MonoBehaviour
    {
        public string FleetName = "Last Fleet";
        public string AdmiralName = "Daleran";


        public NavTarget Nav;
        Rigidbody2D rb;

        [SerializeField]
        float maxSpeed = 999f;
        public float MaxSpeed { get { return maxSpeed; } }

        [SerializeField]
        float maxAcceleration = 999f;
        public float MaxAcceleration { get { return maxAcceleration; } }

        public Supplies SupplySystem;
        public float SupplyUse = 0;

        public float VelocityError = 0.1f;

        Vector2 desiredVelocity;
        public Vector2 DesiredVelocity { get { return desiredVelocity; } }
        List<Vector2> velocities = new List<Vector2>();

        List<FormationSpot> formation = new List<FormationSpot>();

        // Use this for initialization
        void Start()
        {
            rb = gameObject.GetRequiredComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            float desiredSpeed = maxSpeed * Nav.Throttle;


            if (SupplySystem.UseSupplies(SupplyUse * Time.deltaTime * Nav.Throttle))
            {
                desiredVelocity = Nav.Heading.normalized * desiredSpeed;
            }
            else
                desiredVelocity = Vector2.zero;

        }

        private void FixedUpdate()
        {
            Vector2 steering = Vector2.ClampMagnitude( desiredVelocity - rb.velocity,maxAcceleration);

            if (steering.magnitude > VelocityError)
            {
                rb.AddForce(steering);
            }
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }

        public void AddShip(Vector2 velocityAndAcceleration, FormationSpot spot)
        {
            formation.Add(spot);
            velocities.Add(velocityAndAcceleration);
            RecalculateAverageVelocityAndAcceleration();
        }

        public void RemoveShip(Vector2 velocityAndAcceleration, FormationSpot spot)
        {
            formation.Remove(spot);
            velocities.Remove(velocityAndAcceleration);
            RecalculateAverageVelocityAndAcceleration();
        }

        void RecalculateAverageVelocityAndAcceleration()
        {
            float avgV=0;
            float avgA=0;

            for (int i=0;i<velocities.Count;i++)
            {
                avgV += velocities[i].x;
                avgA += velocities[i].y;
            }

            maxSpeed = avgV / velocities.Count;
            maxAcceleration = avgA / velocities.Count;
        }

        public void ChangeFormation(FormationSpot changingSpot, bool enable)
        {
            for (int i=0;i<formation.Count;i++)
            {
                if (formation[i] != changingSpot)
                {
                    formation[i].ToggleSpotGhost(enable);
                }
            }
        }

        void ToggleFormationGhosts(bool enable)
        {
            for (int i = 0; i < formation.Count; i++)
            {
                formation[i].ToggleSpotGhost(enable);
            }
        }

    }
}

