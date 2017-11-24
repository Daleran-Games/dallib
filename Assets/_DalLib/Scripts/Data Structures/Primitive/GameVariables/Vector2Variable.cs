using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    [CreateAssetMenu(fileName = "NewVector2Variable", menuName = "DalLib/Variables/Vector2", order = 35)]
    public class Vector2Variable : GameVariable<Vector2>
    {
        public static implicit operator Vector2(Vector2Variable reference)
        {
            return reference.Value;
        }
    }

}
