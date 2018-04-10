using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DaleranGames.LastFleet
{
    public class SupplyCounter : MonoBehaviour
    {

        [SerializeField]
        TextMeshProUGUI label;
        [SerializeField]
        Supplies supplySystem;

        private void OnEnable()
        {
            supplySystem.SuppliesChanged += UpdateSupplies;
            UpdateSupplies(supplySystem.Current);
        }

        private void OnDisable()
        {
            supplySystem.SuppliesChanged -= UpdateSupplies;
        }


        void UpdateSupplies(float amt)
        {
            label.text = supplySystem.Current.ToString();
        }
    }
}

