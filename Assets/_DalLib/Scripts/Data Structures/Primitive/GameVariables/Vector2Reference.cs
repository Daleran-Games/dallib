using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    [System.Serializable]
    public class Vector2Reference : VariableReference<Vector2, Vector2Variable>
    {
        public static implicit operator Vector2(Vector2Reference reference)
        {
            return reference.Value;
        }
    }
}
