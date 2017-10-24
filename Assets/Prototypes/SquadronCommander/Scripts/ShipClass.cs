using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.SquadronCommander
{
    [CreateAssetMenu(fileName ="NewShipClass",menuName ="Squadron Commander/Ship Class",order = 1)]
    public class ShipClass : ScriptableObject 
    {

        [Header("Information")]
        [SerializeField]
        string shipName = "Default Ship Class";

        
        [Header("Movement")]
        [SerializeField]
        float maxSpeed = 10f;
        [SerializeField]
        float turningForce = 0.2f;
        [SerializeField]
        float rotationSpeed = 5f;
        [SerializeField]
        float turningTilt = 15f;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public enum ShipType
    {
        Fighter,
        Capital
    }
}

