using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace DaleranGames.IO
{
    [CreateAssetMenu(fileName ="NewCSVObject",menuName ="DalLib/IO/CSV Object",order = 40)]
    public class CSVObject : SerializedScriptableObject
    {
        [FilePath(Extensions = "txt")]
        public string CSVFilePath;

        public CSVData Data;

        private void OnEnable()
        {
            Data = new CSVData(name, CSVFilePath);
        }

    }
}

