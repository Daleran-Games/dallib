using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    [CreateAssetMenu(fileName = "NewStringVariable", menuName = "DalLib/Variables/String", order = 31)]
    public class StringVariable : GameVariable<string>
    {
        public static implicit operator string(StringVariable reference)
        {
            return reference.Value;
        }
    }

}
