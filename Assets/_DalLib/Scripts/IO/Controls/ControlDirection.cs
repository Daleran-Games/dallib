using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.IO
{
    [AddComponentMenu("Input/Control Direction")]
    public class ControlDirection : MonoBehaviour
    {
        [SerializeField]
        string xAxisName;
        [SerializeField]
        string yAxisName;
        [SerializeField]
        bool normalize = false;

        [SerializeField]
        Vector2Reference axisDirection;
        [SerializeField]
        Vector2Reference axisDirectionRaw;

        public bool IsInUse
        {
            get
            {
                if (Input.GetAxis(xAxisName) != 0 || Input.GetAxis(yAxisName) != 0)
                    return true;
                else
                    return false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (axisDirection != null)
                axisDirection.Value = new Vector2(Input.GetAxis(xAxisName), Input.GetAxis(yAxisName));

            if (axisDirectionRaw != null)
                axisDirectionRaw.Value = new Vector2(Input.GetAxisRaw(xAxisName), Input.GetAxisRaw(yAxisName));

            if (normalize)
            {
                axisDirection.Value.Normalize();
                axisDirectionRaw.Value.Normalize();
            }
        }
    }
}