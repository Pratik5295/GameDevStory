using DevStory.Managers;
using DG.Tweening;
using System;
using UnityEngine;

namespace DevStory.Gameplay.GameTimer
{
    [DefaultExecutionOrder(-1)]
    public class GameTimerManager : MonoBehaviour
    {
        public static GameTimerManager Instance = null;

        [Header("Day details")]
        [SerializeField]
        private int day = 0;

        [SerializeField] private int finalDayInt;

        public int Day => day;

        public int FinalDay => finalDayInt + 1;

        [Space(3)]
        [Header("Time of day details")]
        [SerializeField]
        private float currentTime = 0;


        public float CurrentTime => currentTime;

        [SerializeField]
        private bool PauseTime = false;


        //Maximum number of seconds in a day 480f
        [SerializeField]
        private float maxDayTime = 60f;

        public float MaxDayTime => maxDayTime;  

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

            //Initializing Do Tween
            DOTween.Init();
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

        /// <summary>
        /// Helper function to skip certain amount of time in the day
        /// </summary>
        /// <param name="_amount"></param>
        public void SkipTimeBy(float _amount)
        {
            currentTime += _amount;
        }

        private void Update()
        {
            if (!isDayRunning) return;

            if (PauseTime) return;

            currentTime += Time.deltaTime;

            if (currentTime > maxDayTime + 1)
            {
                DayEnds();
            }
        }

        public void PauseGame()
        {
            PauseTime = true;
        }

        public void ResumeGame()
        {
            PauseTime = false;
        }

        public void ForceDayEnd()
        {
            currentTime = maxDayTime;
        }

        public void GameOverHandling()
        {
            if(day == FinalDay)
            {
                isDayRunning = false;
                PauseGame();

                GameManager.Instance.GameCompletedCheck();
            }
        }
    }
}
