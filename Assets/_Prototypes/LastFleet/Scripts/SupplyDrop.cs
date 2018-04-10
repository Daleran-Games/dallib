using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DaleranGames.LastFleet
{
    public class SupplyDrop : MonoBehaviour
    {
        [SerializeField]
        float amount;

        Supplies playerSupply;

        private void Start()
        {
            playerSupply = GameObject.FindGameObjectWithTag("Player").GetRequiredComponent<Supplies>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            playerSupply.AddSupplies(amount);
            Destroy(gameObject);
        }
    }
}

