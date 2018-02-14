using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public class LootDropper : MonoBehaviour
    {

        [Range(0f,1f)]
        public float DropChance = 1f;
        [Tooltip("Must be greater than 0")]
        public Vector2Int DropAmount;
        public GameObject Drop;

        public void DropLoot()
        {
            int dropAmount = Random.Int(DropAmount.x, DropAmount.y);

            for (int i=0; i<dropAmount; i++)
            {
                if (Random.Bool(DropChance))
                    Instantiate(Drop,transform.position,transform.rotation);
            }
        }
        
    }
}

