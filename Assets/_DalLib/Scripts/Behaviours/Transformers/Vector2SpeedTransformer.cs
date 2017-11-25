using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public class DirectionSpeedTransformer : MonoBehaviour
    {
        [SerializeField]
        Vector2Reference moveVector;
        public float speed = 15f;
        public bool UseLateUpdate = false;

        void Update()
        {
            if (!UseLateUpdate)
                Move();
        }

        void LateUpdate()
        {
            if (UseLateUpdate)
               Move();
        }

        // Update is called once per frame
        void Move()
        {
            transform.position += (Vector3)moveVector.Value.normalized * speed * Time.deltaTime;
        }
    }
}

