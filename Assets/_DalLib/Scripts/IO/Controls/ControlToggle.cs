using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.IO
{
    [AddComponentMenu("Input/Control Toggle")]
    public class ControlToggle : MonoBehaviour
    {
        [SerializeField]
        string axisName;

        [SerializeField]
        bool toggleState = false;
        public bool ToggleState { get { return toggleState; } }
        public GameEvent Enabled;
        public GameEvent Disabled;

        // Update is called once per frame
        void Update()
        {
            CheckToggleState();
        }

        public void CheckToggleState()
        {
            if (Input.GetButtonUp(axisName))
            {
                toggleState = !toggleState;

                if (toggleState == true)
                    Enabled?.Raise();
                else
                    Disabled?.Raise();
            }
        }
    }
}