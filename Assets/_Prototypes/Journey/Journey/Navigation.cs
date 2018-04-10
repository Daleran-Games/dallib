using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Journey
{
    public class Navigation : MonoBehaviour
    {
        [SerializeField]
        float location;

        [SerializeField]
        float speed;
        public float Speed
        {
            get { return speed; }
            set { }
        }

        [SerializeField]
        float MaxSpeed;

        public Fuel FuelTank;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

