using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DaleranGames.Cameras;

namespace DaleranGames.LastFleet
{
    public class NavTarget : MonoBehaviour
    {
        [Header("Screen Settings")]
        [SerializeField]
        [Range(0f, 1f)]
        float stopCursorDistance = 0.1f;
        [SerializeField]
        [ReadOnly]
        float stopPixels;
        [SerializeField]
        [Range(0f, 1f)]
        float maxSpeedCursorDistance = 0.8f;
        [SerializeField]
        [ReadOnly]
        float maxPixels;

        [Header("Speed Indicators")]
        [SerializeField]
        Sprite stopSprite;
        [SerializeField]
        Color32 stopColor = ColorExtensions.magenta;
        [SerializeField]
        Sprite slowSprite;
        [SerializeField]
        Color32 slowColor = ColorExtensions.red;
        [SerializeField]
        Sprite medSprite;
        [SerializeField]
        Color32 medColor = ColorExtensions.yellow;
        [SerializeField]
        Sprite maxSprite;
        [SerializeField]
        Color32 maxColor = ColorExtensions.green;

        [Header("Output")]
        [ReadOnly]
        [SerializeField]
        float throttle;
        public float Throttle { get { return throttle; } }
        [ReadOnly]
        [SerializeField]
        Vector2 heading;
        public Vector2 Heading { get { return heading; } }


        RectTransform rect;
        Image sprite;
        Vector2 screenCenter;
        ScreenSizeObserver sizeObs;

        private void OnEnable()
        {
            sizeObs = GameObject.FindGameObjectWithTag("MainCamera").GetRequiredComponent<ScreenSizeObserver>();
            sizeObs.ScreenSizeChanged += UpdateScreenLimits;
        }

        void Start()
        {
            rect = GetComponent<RectTransform>();
            sprite = gameObject.GetRequiredComponent<Image>();
            UpdateScreenLimits(sizeObs.ScreenSize);
            rect.anchoredPosition = screenCenter;
            if (stopCursorDistance >= maxSpeedCursorDistance)
                Debug.LogError("Error: Stop Cursor Distance cannot be greater than the max speed cursor distance");
            
        }

        private void OnDisable()
        {
            sizeObs.ScreenSizeChanged -= UpdateScreenLimits;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(1))
            {
                Vector2 mousePos = Input.mousePosition;

                heading = mousePos - screenCenter;
                float distance = heading.magnitude;

                if (distance <= stopPixels)
                {
                    throttle = 0f;
                    rect.anchoredPosition = screenCenter;
                    heading = Vector2.zero;
                    rect.Set2DRotation(0f);
                } 
                else if (distance > maxPixels)
                {
                    throttle = 1f;
                    rect.anchoredPosition = screenCenter + heading.normalized * maxPixels;
                    RotateSprite();
                }
                else
                {
                    throttle = (distance - stopPixels) / (maxPixels - stopPixels);
                    rect.anchoredPosition = mousePos;
                    RotateSprite();
                }

                CheckSpriteAndColor();
            }
        }

        void UpdateScreenLimits(Vector2Int newSize)
        {
            screenCenter = new Vector2(newSize.x / 2, newSize.y / 2);
            stopPixels = (newSize.x * 0.5f) * stopCursorDistance;
            maxPixels = (newSize.y * 0.5f) * maxSpeedCursorDistance;
            
        }

        void CheckSpriteAndColor()
        {
            if (throttle <= 0)
            {
                sprite.sprite = stopSprite;
                sprite.color = stopColor;
            }
            else if (throttle > 0f && throttle <= 0.5f)
            {
                sprite.sprite = slowSprite;
                sprite.color = slowColor;
            }
            else if (throttle > 0.5f && throttle < 1f)
            {
                sprite.sprite = medSprite;
                sprite.color = medColor;
            }
            else
            {
                sprite.sprite = maxSprite;
                sprite.color = maxColor;
            }
        }

        void RotateSprite()
        {
            float angle = Vector2.SignedAngle(transform.up, heading);
            rect.Rotate(0f, 0f, angle);
        }

    }
}

