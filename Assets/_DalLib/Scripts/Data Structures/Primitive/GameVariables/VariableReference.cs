using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    [System.Serializable]
    public class VariableReference<T,V> where V : GameVariable<T>
    {
        [SerializeField]
        protected bool useConstant = true;
        [SerializeField]
        protected T constantValue;
        [SerializeField]
        protected V variable;

        public VariableReference()
        { }

        public VariableReference(T value)
        {
            useConstant = true;
            constantValue = value;
        }

        public virtual T Value
        {
            get { return useConstant ? constantValue : variable.Value; }
            set { if (useConstant) constantValue = value; else variable.Value = value; }
        }

    }

}
