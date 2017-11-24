using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public class TransformFollower : MonoBehaviour
    {
        [SerializeField]
        Transform target;
        [SerializeField]
        Vector3 offset = new Vector3(0f, 0f, -10f);

        // Update is called once per frame
        void Update()
        {
            if (target != null)
                transform.position = target.transform.position + offset;
        }
    }
}

