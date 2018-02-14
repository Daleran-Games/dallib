using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastFleet
{
    public class WeaponMount : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField]
        Vector2 weaponArc;
        public Vector2 WeaponArc { get { return weaponArc; } }
        [SerializeField]
        bool isFixed = false;
        public bool IsFixed { get { return isFixed; } }

    }

}