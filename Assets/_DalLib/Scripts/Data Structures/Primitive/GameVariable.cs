using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public class GameVariable<T> : ScriptableObject
    {
        [TextArea(1,3)]
        string DeveloperDescription = "";

    }
}

