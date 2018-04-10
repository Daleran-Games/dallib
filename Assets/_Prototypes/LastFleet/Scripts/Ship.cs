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
        public float VelocityError = 0.1f;
        public float FuelBurnRate;


        Rigidbody2D rb;
        Vector2 desiredVelocity;
        Vector2 speedAndAccel;
        SpriteRenderer rend;
        Collider2D col;

        [SerializeField]
        GameObject spotPrefab;
        FormationSpot formation;

        private void OnEnable()
        {
            rend = GetComponent<SpriteRenderer>();
            col = GetComponent<Collider2D>();

            GameObject newSpot = Instantiate(spotPrefab, transform.position, Fleet.gameObject.transform.rotation, Fleet.gameObject.transform);
            formation = newSpot.GetComponent<FormationSpot>();
            newSpot.name = gameObject.name + "Formation Spot";


            formation.Initialize(rend.sprite,(col.bounds.max-transform.position).magnitude);

            speedAndAccel = new Vector2(MaxSpeed, MaxAcceleration);
            Fleet.AddShip(speedAndAccel,formation);
        }

        // Use this for initialization
        void Start()
        {
            
            Fleet.SupplyUse += FuelBurnRate;
            rb = gameObject.GetRequiredComponent<Rigidbody2D>();
        }

        private void OnDisable()
        {
            Destroy(formation);
            Fleet.SupplyUse -= FuelBurnRate;
            Fleet.RemoveShip(speedAndAccel,formation);
        }

        private void Update()
        {
            desiredVelocity = Fleet.DesiredVelocity + (Vector2)(formation.transform.position - transform.position);
        }

        private void FixedUpdate()
        {
            Vector2 steering = Vector2.ClampMagnitude(desiredVelocity - rb.velocity, MaxAcceleration);

            if (steering.magnitude > VelocityError)
            {
                rb.AddForce(steering);
            }
        }

        private void OnMouseDown()
        {
            formation.MoveFormationSpot();
            Fleet.ChangeFormation(formation, true);
            formation.SpotPlaced += OnFormationChangeComplete;
        }

        void OnFormationChangeComplete()
        {
            Fleet.ChangeFormation(formation, false);
            formation.SpotPlaced -= OnFormationChangeComplete;
        }

    }
}
