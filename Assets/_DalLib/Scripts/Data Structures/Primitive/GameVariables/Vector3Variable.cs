using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    [CreateAssetMenu(fileName = "Newvector3Variable", menuName = "DalLib/Variables/Vector3", order = 36)]
    public class Vector3Variable : GameVariable<Vector3>
    {
        public static implicit operator Vector3(Vector3Variable reference)
        {
            return reference.Value;
        }
    }

}
