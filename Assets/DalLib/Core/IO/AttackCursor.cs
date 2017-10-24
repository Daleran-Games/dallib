using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.IO
{
    public class AttackCursor : MonoBehaviour
    {
        [SerializeField]
        GameObject target;
        [SerializeField]
        Color32 defaultColor = ColorExtensions.white;
        [SerializeField]
        [Range(0f,1f)]
        float distanceScaler = 1f;
        [SerializeField]
        float zLevel = -9;

        SpriteRenderer cursorRenderer;

        private void Awake()
        {
            cursorRenderer = gameObject.GetRequiredComponent<SpriteRenderer>();
        }


        // Use this for initialization
        void Start()
        {
            Cursor.visible = false;
            cursorRenderer.color = defaultColor;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (distanceScaler < 1)
            {
                Vector3 newPos = Vector3.MoveTowards(target.transform.position, mousePos, Vector3.Distance(target.transform.position, mousePos) * distanceScaler);
                transform.position = new Vector3(newPos.x, newPos.y, zLevel);
            }
            else
                transform.position = new Vector3(mousePos.x, mousePos.y, zLevel);
        }
    }
}
