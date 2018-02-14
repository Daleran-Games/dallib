using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastFleet
{
    public abstract class TargetingController : MonoBehaviour
    {

        public abstract Vector2 GetAimPoint(Weapon weapon);
        public abstract bool ShouldFire(Weapon weapon);

    }

}
