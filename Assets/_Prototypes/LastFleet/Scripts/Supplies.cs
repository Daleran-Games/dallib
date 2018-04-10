using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.LastFleet
{
    public class Supplies : MonoBehaviour
    {
        public float startingSupplies;

        float current;
        public float Current
        {
            get { return current; }
            protected set
            {
                current = MathTools.ClampPositive(value);
                SuppliesChanged?.Invoke(current);
            }
        }

        public event System.Action<float> SuppliesChanged;

        // Use this for initialization
        void Start()
        {
            Current = startingSupplies;
        }

        public bool UseSupplies(float amount)
        {
            if (amount > 0)
            {
                if (amount > current)
                {
                    current = 0;
                    return false;
                }
                else
                {
                    Current -= amount;
                    return true;
                }
            }
            return true;
        }

        public void AddSupplies(float amount)
        {
            if (amount > 0)
            {
                Current += amount;
            }
        }


    }
}
