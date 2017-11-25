using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public class ScreenPanTransformer : MonoBehaviour
    {
        public float PanSpeed = 15f;
        public float PanBorderThickness = 20f;
        [SerializeField]
        Vector2Reference mousePosition;
        public bool UseLateUpdate = false;

        void Update()
        {
            if (!UseLateUpdate)
                Move();
        }

        void LateUpdate()
        {
            if (UseLateUpdate)
                Move();
        }

        // Update is called once per frame
        void Move()
        {
            Vector2 moveDir = new Vector2();

            if (mousePosition.Value.x > Screen.width - PanBorderThickness)
                moveDir.x = PanSpeed;
            if (mousePosition.Value.x < PanBorderThickness)
                moveDir.x = -PanSpeed;
            if (mousePosition.Value.y > Screen.height - PanBorderThickness)
                moveDir.y = PanSpeed;
            if (mousePosition.Value.y < PanBorderThickness)
                moveDir.y = -PanSpeed;

            transform.position += (Vector3)moveDir.normalized * PanSpeed * Time.deltaTime;
        }
    }

}
