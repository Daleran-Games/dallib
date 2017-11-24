using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public class GameVariable<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField]
        protected T value;
        protected T originalValue;
        [TextArea(1,3)]
        protected string description = "";
        public string Description { get { return description; } }

        public GameEvent Changed;

        public virtual T Value
        {
            get { return value; }
            set { this.value = value; Changed?.Raise(); }
        }

        protected virtual void OnEnable()
        {
            originalValue = value;
        }

        protected virtual void OnDisable()
        {
            value = originalValue;
        }

        T cachedValue;

        public virtual void OnAfterDeserialize()
        {
            cachedValue = value;
        }

        public virtual void OnBeforeSerialize()
        {
            if (!cachedValue.Equals(value))
            {
                Changed?.Raise();
            }
        }


    }
}

