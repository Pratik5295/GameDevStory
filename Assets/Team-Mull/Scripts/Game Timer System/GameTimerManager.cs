using System;
using UnityEngine;

namespace DevStory.Gameplay.GameTimer
{

    public class GameTimerManager : MonoBehaviour
    {
        public static GameTimerManager Instance = null;

        [Header("Day details")]
        [SerializeField]
        private int day = 0;

        public int Day => day;

        [Space(3)]
        [Header("Time of day details")]
        [SerializeField]
        private float currentTime = 0;


        public float CurrentTime => currentTime;


        //Maximum number of seconds in a day 480f
        [SerializeField]
        private float maxDayTime = 60f;

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

        /// <summary>
        /// The button listener function to start the game day
        /// Link this to the login button we would have in the game
        /// </summary>
        public void StartDay()
        {
            currentTime = 0;

            isDayRunning = true;

            day++;

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
