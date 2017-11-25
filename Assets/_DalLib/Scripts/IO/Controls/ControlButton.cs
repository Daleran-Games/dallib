using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.IO
{
    [AddComponentMenu("Input/Control Button")]
    public class ControlButton : MonoBehaviour
    {
        [SerializeField]
        string axisName;

        public GameEvent Pressed;
        public GameEvent Down;
        public GameEvent Up;

        // Update is called once per frame
        void Update()
        {
            CheckForPresses();
        }

        public bool IsPressed()
        {
            return Input.GetButton(axisName);
        }

        public bool IsDown()
        {
            return Input.GetButtonDown(axisName);
        }

        public bool IsUp()
        {
            return Input.GetButtonUp(axisName);
        }

        public void CheckForPresses()
        {
            if (IsDown())
                Pressed?.Raise();

            if (IsUp())
                Down?.Raise();

            if (IsPressed())
                Up?.Raise();
        }
    }
}
