using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.IO;


namespace DaleranGames.LastFleet
{
    public class FormationSpot : MonoBehaviour
    {
        SpriteRenderer rend;
        CircleCollider2D col;

        Color standard = Color.white;
        Color placeValid = Color.green;
        Color placeInvalid = Color.red;

        public event System.Action SpotPlaced;

        RayPositionReporter Cursor;

        public const int maxNumberOfFormationSponts = 128;

        Vector3 lastGoodPosition;
        bool waitFrame = true;

        int layerMask = 1 << 15;
        
        // Use this for initialization
        public void Initialize(Sprite sprite, float colliderRadius)
        {
            rend = GetComponent<SpriteRenderer>();
            col = GetComponent<CircleCollider2D>();


            ToggleSpotGhost(false);
            this.enabled = false;
            Cursor = GameObject.FindGameObjectWithTag("MouseCursor").GetRequiredComponent<RayPositionReporter>();
            rend.sprite = sprite;
            col.radius = colliderRadius;
        }

        private void Update()
        {

            transform.position = Cursor.WorldPosition;
            CheckForValidPlacement();

            if (!waitFrame)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (this.enabled == true && CheckForValidPlacement())
                    {
                        rend.color = standard;
                        rend.enabled = false;
                        col.enabled = false;
                        SpotPlaced?.Invoke();
                        this.enabled = false;
                    }
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    transform.position = lastGoodPosition;
                    rend.color = standard;
                    rend.enabled = false;
                    col.enabled = false;
                    SpotPlaced?.Invoke();
                    this.enabled = false;
                }
            } else
                waitFrame = false;
        }

        public void ToggleSpotGhost(bool enable)
        {
            if (enable)
            {
                rend.color = standard;
                rend.enabled = true;
                col.enabled = true;
            } else
            {
                rend.color = standard;
                rend.enabled = false;
                col.enabled = false;
            }
        }

        public void MoveFormationSpot()
        {
            lastGoodPosition = transform.position;
            this.enabled = true;
            rend.color = placeValid;
            rend.enabled = true;
            col.enabled = true;
            waitFrame = true;
        }

        bool CheckForValidPlacement()
        {
            ContactPoint2D[] points = new ContactPoint2D[maxNumberOfFormationSponts];

            if (col.IsTouchingLayers(layerMask))
            {
                rend.color = placeInvalid;
                return false;
            }
            else
            {
                rend.color = placeValid;
                return true;
            }
        }


    }
}

