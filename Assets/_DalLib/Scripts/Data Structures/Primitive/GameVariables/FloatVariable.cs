using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    [CreateAssetMenu(fileName = "NewFloatVariable", menuName = "DalLib/Variables/Float", order = 34)]
    public class FloatVariable : GameVariable<float>
    {
        public static implicit operator float(FloatVariable reference)
        {
            return reference.Value;
        }
    }

}
