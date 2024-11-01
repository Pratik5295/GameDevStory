using System.Collections.Generic;
using System;
using UnityEngine;

namespace DevStory.Gameplay.DragDrop
{
    public class IteratorClicker : Clicker
    {
        [SerializeField]
        protected int currentValue = 0;

        [SerializeField]
        private int maxValue;

        public int CurrentValue => currentValue;
        public Action<int> OnClickerValueUpdated;

        [SerializeField]
        private int CorrectResponseInteger;

        public bool HasCorrectResponse => currentValue == CorrectResponseInteger;

        [SerializeField]
        private SpriteRenderer CurrentSprite;

        public List<Sprite> allValues = new List<Sprite>();

        private void Start()
        {
            CurrentSprite = GetComponent<SpriteRenderer>();

            maxValue = allValues.Count;
            UpdateSprite();
        }


        public override void IterateValue()
        {
            currentValue++;
            if (currentValue >= maxValue)
            {
                currentValue = 0;
            }

            OnClickerValueUpdated?.Invoke(currentValue);
            UpdateSprite();

        }

        private void UpdateSprite()
        {
            CurrentSprite.sprite = allValues[currentValue];

            Debug.Log($"Iterator puzzle correct response: {HasCorrectResponse}");
        }
    }
}
