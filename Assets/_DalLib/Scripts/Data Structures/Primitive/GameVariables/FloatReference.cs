using UnityEngine;
using System;

namespace DaleranGames
{
    public class FloatReference
    {
        [SerializeField]
        bool useConstant = true;
        [SerializeField]
        float constantValue;
        [SerializeField]
        FloatVariable variable;

        public FloatReference()
        { }

        public FloatReference(float value)
        {
            useConstant = true;
            constantValue = value;
        }

        public float Value
        {
            get { return useConstant ? constantValue : variable.Value; }
            set { if (useConstant) constantValue = value; else variable.Value = value; }
        }

        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }
    }
}
