using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    [CreateAssetMenu(fileName = "NewGameEvent",menuName="DalLib/Events/Game Event",order = 30)]
    public class GameEvent : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<GameEventListener> eventListeners = new List<GameEventListener>();
        public event System.Action EventRaised;

        [ContextMenu("Raise")]
        public void Raise()
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
            
            EventRaised?.Invoke();
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}

