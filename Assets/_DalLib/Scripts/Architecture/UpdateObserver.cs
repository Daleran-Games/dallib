using System;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public class UpdateObserver : MonoBehaviour
    {
        public enum UpdateType
        {
            FixedUpdate,
            Update,
            LateUpdate
        }

        public GameEvent FixedUpdateEvent;
        public GameEvent UpdateEvent;
        public GameEvent LateUpdateEvent;


        void FixedUpdate()
        {
            FixedUpdateEvent.Raise();
        }

        void Update()
        {
            UpdateEvent.Raise();
        }

        void LateUpdate()
        {
            LateUpdateEvent.Raise();
        }

    }
}

