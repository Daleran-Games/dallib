using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastFleet
{
    public class Sensor : MonoBehaviour
    {
        [SerializeField]
        SensorSystem system;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            system.AddContact(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            system.RemoveContact(collision);
        }


        /*
        [SerializeField]
        float range = 400f;

        [SerializeField]
        float frequency = 0.5f;
        float startTime;

        [SerializeField]
        public Collider2D[] Contacts = new Collider2D[MaxSensorContacts];

        [SerializeField]
        LayerMask mask;
        int numMask;

        public const int MaxSensorContacts = 255;

        IEnumerator sensorCoroutine;

        // Use this for initialization
        void Start()
        {
            numMask = mask.value;
            startTime = Random.Float(0f, frequency);
            sensorCoroutine = CheckForSensorContacts(startTime, frequency);
            StartCoroutine(sensorCoroutine);
        }

        IEnumerator CheckForSensorContacts(float startTime, float frequency)
        {
            yield return new WaitForSeconds(startTime);

            while(true)
            {
                Physics2D.OverlapCircleNonAlloc(transform.position, range, Contacts, numMask);
                yield return new WaitForSeconds(frequency);
            }
        }

        public void StopSensorUpdates()
        {
            StopCoroutine(sensorCoroutine);
        }
        */
    }
}

