using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public class Vector3Follower : MonoBehaviour
    {
        [SerializeField]
        Vector3Reference target;
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
            transform.position = target.Value;
        }
    }

}
