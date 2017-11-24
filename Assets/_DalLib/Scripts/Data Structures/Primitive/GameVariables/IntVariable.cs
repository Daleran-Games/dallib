using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    [CreateAssetMenu(fileName = "NewIntVariable", menuName = "DalLib/Variables/Int", order = 33)]
    public class IntVariable : GameVariable<int>
    {
        public static implicit operator int(IntVariable reference)
        {
            return reference.Value;
        }
    }

}
