using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    [CreateAssetMenu(fileName = "NewBoolVariable", menuName = "DalLib/Variables/Bool", order = 32)]
    public class BoolVariable : GameVariable<bool>
    {
        public static implicit operator bool(BoolVariable reference)
        {
            return reference.Value;
        }
    }

}
