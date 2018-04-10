using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DaleranGames.LastFleet
{
    public class Condition : MonoBehaviour
    {

        [SerializeField]
        float max;
        public float Max { get { return max; } }

        [SerializeField]
        float current;
        public float Current
        {
            get { return current; }
            protected set
            {
                current = Mathf.Clamp(value, 0f, max);
                ConditionChanged?.Invoke(current);
            }
        }

        public UnityEvent ObjectDestroyed;
        public event System.Action<float> ConditionChanged;

        // Use this for initialization
        void Awake()
        {
            current = max;
        }

        public void DealDamage(float amount)
        {
            if (amount > 0)
            {
                if (amount > current)
                {
                    current = 0;
                    ObjectDestroyed?.Invoke();
                    ObjectDestroyed.RemoveAllListeners();
                    Destroy(this.gameObject);
                }
                else
                {
                    Current -= amount;
                }
            }
        }

        public bool RepairDamage(float amount)
        {
            if (current < max && amount > 0)
            {
                Current += amount;
                return true;
            }
            return false;
        }
    }

}
