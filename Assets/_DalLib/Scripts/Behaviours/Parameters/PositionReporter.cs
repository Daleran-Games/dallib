using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public class PositionReporter : MonoBehaviour
    {
        public Vector3Reference position;

        void Update()
        {
            position.Value = transform.position;
        }
    }
}

