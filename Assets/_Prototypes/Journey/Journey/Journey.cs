using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.Journey
{
    public class Journey : MonoBehaviour
    {
        [SerializeField]
        bool traveling;
        public bool Traveling
        {
            get { return traveling; }
            set
            {
                if (traveling != value)
                {
                    traveling = value;
                    TravelChange?.Invoke(value);
                }
            }
        }
        Action<bool> TravelChange;


        public List<Node> Nodes;
        public int CurrentNodeIndex = 0;

        public List<Incident> Incidents;

        // Use this for initialization
        protected void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
