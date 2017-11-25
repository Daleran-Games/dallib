using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.IO
{
    [AddComponentMenu("Input/Control Axis")]
    public class ControlAxis : MonoBehaviour
    {
        [SerializeField]
        string axisName;

        [SerializeField]
        FloatReference axisValue;
        [SerializeField]
        FloatReference rawValue;

        public bool IsInUse
        {
            get
            {
                if (Input.GetAxis(axisName) != 0)
                    return true;
                else
                    return false;
            }
        }

        public bool IsPositiveAndInUse
        {
            get
            {
                if (Input.GetAxis(axisName) > 0 && IsInUse)
                    return true;
                else
                    return false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (axisValue != null)
                axisValue.Value = Input.GetAxis(axisName);

            if (rawValue != null)
                rawValue.Value = Input.GetAxisRaw(axisName);
        }
    }
}

