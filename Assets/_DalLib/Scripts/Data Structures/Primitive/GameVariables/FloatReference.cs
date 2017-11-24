using System;
using UnityEngine;

namespace DaleranGames
{
    [Serializable]
    public class FloatReference : VariableReference<float,FloatVariable>
    {
        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }

    }
}