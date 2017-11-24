using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    [System.Serializable]
    public class IntReference : VariableReference<int, IntVariable>
    {
        public static implicit operator int(IntReference reference)
        {
            return reference.Value;
        }
    }
}
