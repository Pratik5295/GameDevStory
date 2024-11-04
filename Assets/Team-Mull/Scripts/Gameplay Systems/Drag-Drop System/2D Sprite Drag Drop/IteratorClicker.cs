using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace DevStory.Gameplay.DragDrop
{
    public class IteratorClicker : Clicker
    {
        [SerializeField]
        protected int currentValue = 0;

        [SerializeField]
        private int maxValue;

        public int CurrentValue => currentValue;
        public Action<IteratorClicker,bool> OnClickerValueUpdated;

        [SerializeField]
        private int CorrectResponseInteger;

        public bool HasCorrectResponse => currentValue == CorrectResponseInteger;

        [SerializeField]
        private SpriteRenderer CurrentSprite;

        public List<Sprite> allValues = new List<Sprite>();

        public UnityEvent OnRevealingResponseEvent;

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

            if (currentValue == CorrectResponseInteger)
            {
                OnRevealingResponseEvent?.Invoke();
            }

            UpdateSprite();

            OnClickerValueUpdated?.Invoke(this,HasCorrectResponse);

        }

        private void UpdateSprite()
        {
            CurrentSprite.sprite = allValues[currentValue];

            Debug.Log($"Iterator puzzle correct response: {HasCorrectResponse}");
        }
    }
}
