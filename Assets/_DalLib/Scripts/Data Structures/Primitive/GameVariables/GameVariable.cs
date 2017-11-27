using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public class GameVariable<T> : ScriptableObject
    {
        [SerializeField]
        protected T value;
        protected T originalValue;
        [TextArea(1,3)]
        [SerializeField]
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

        public static V Create<V>(T value) where V:GameVariable<T>
        {
            V newGameVar = CreateInstance<V>();
            newGameVar.Value = value;
            return newGameVar;
        }

    }
}

