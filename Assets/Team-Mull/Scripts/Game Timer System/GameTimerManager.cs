using System;
using UnityEngine;

namespace DevStory.Gameplay.GameTimer
{

    public class GameTimerManager : MonoBehaviour
    {
        public static GameTimerManager Instance = null;

        [SerializeField]
        private float currentTime = 0;

        public float CurrentTime => currentTime;

        //Maximum number of seconds in a day
        [SerializeField]
        private float maxDayTime = 480f;

        [SerializeField]
        private bool isDayRunning = false;

        public Action OnDayStartedEvent;
        public Action OnDayEndedEvent;

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void StartDay()
        {
            currentTime = 0;

            isDayRunning = true;

            OnDayStartedEvent?.Invoke();
        }

        private void DayEnds()
        {
            isDayRunning = false;

            OnDayEndedEvent?.Invoke();
        }

        private void Update()
        {
            if (!isDayRunning) return;

            currentTime += Time.deltaTime;

            if (currentTime > maxDayTime + 1)
            {
                DayEnds();
            }
        }
    }
}
