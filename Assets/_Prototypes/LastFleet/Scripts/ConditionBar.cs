using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DaleranGames.LastFleet
{
    public class ConditionBar : MonoBehaviour
    {
        public Slider Slider;
        public Condition Condition;

        private void OnEnable()
        {
            Condition.ConditionChanged += UpdateSlider;
            Slider.minValue = 0;
            Slider.maxValue = Condition.Max;
            UpdateSlider(Condition.Current);
        }

        private void OnDisable()
        {
            Condition.ConditionChanged -= UpdateSlider;
        }

        void UpdateSlider(float val)
        {
            Slider.value = val; 
        }
    }
}

