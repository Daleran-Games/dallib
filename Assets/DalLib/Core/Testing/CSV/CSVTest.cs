using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.IO;

namespace DaleranGames.Testing
{
    public class CSVTest : MonoBehaviour
    {
        [ContextMenu("Print Single Header CSV")]
        void PrintSingleHeader()
        {
            CSVData csv = new CSVData("Single", Application.dataPath + "/DalLib/Core/Testing/CSV/singleHeader.txt");

            foreach (CSVEntry ent in csv.Entries)
            {
                Debug.Log(ent.ID);

                foreach (KeyValuePair<string,string> val in ent.Data)
                {
                    Debug.Log(val.Key + ": " + val.Value);
                }

            }
        }

        [ContextMenu("Print Multiple Header CSV")]
        void PrintMultipleHeader()
        {

        }
    }
}

