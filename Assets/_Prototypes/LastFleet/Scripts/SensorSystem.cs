using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastFleet
{
    public class SensorSystem : MonoBehaviour
    {
        [SerializeField]
        List<Rigidbody2D> Contacts = new List<Rigidbody2D>();

        public void AddContact(Collider2D obj)
        {
            Contacts.Add(obj.gameObject.GetRequiredComponent<Rigidbody2D>());
        }

        public void RemoveContact(Collider2D obj)
        {
            Contacts.Remove(obj.gameObject.GetRequiredComponent<Rigidbody2D>());
        }

        public Rigidbody2D GetClosestContact (Vector3 position)
        {
            Rigidbody2D result = null;
            float closestSoFar = float.MaxValue;

            for (int i=0; i<Contacts.Count; i++)
            {
                float dist = Vector2.SqrMagnitude(Contacts[i].transform.position - position);

                if (dist < closestSoFar)
                {
                    closestSoFar = dist;
                    result = Contacts[i];
                }
            }

            return result;
        }

        public List<Rigidbody2D> GetAllContactsInRange(Vector3 position, float sqrRange)
        {
            List<Rigidbody2D> results = new List<Rigidbody2D>();

            for (int i = 0; i < Contacts.Count; i++)
            {
                float dist = Vector2.SqrMagnitude(Contacts[i].transform.position - position);

                if (dist <= sqrRange)
                {
                    results.Add(Contacts[i]);
                }
            }

            return results;
        }

    }
}

