using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace DaleranGames.UI
{
    public class UIHighlighter : MonoBehaviour
    {
        [SerializeField]
        Image sprite;
        [SerializeField]
        Color32 defaultColor = ColorExtensions.white;
        [SerializeField]
        Color32 highlightColor = ColorExtensions.gray;

        // Update is called once per frame
        void Update()
        {
            CheckIfOverUI();
        }

        void CheckIfOverUI()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                sprite.color = highlightColor;
            }
            else
                sprite.color = defaultColor;
        }
    }
}

