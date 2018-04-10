using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastFleet
{
    public class Targetable : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer targetIndicator;

        [SerializeField]
        SensorSystem sensors;

        [SerializeField]
        Collider2D col;

        private void Start()
        {
            targetIndicator.enabled = false;
        }

        public void OnMouseDown()
        {
            targetIndicator.enabled = true;
            sensors.AddContact(col);
        }

        public void RemoveFromContacts()
        {
            sensors.RemoveContact(col);
        }

    }
}

