using UnityEngine;
using TMPro;
using DevStory.Utility;

namespace DevStory.Gameplay.GameTimer
{
    /// <summary>
    /// This script will handle the UI representation of the timer
    /// </summary>
    /// 

    [DefaultExecutionOrder(1)]
    public class UIGameTimer : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI timerText;

        [SerializeField]
        private GameTimerManager gameTimerManager;

        [SerializeField]
        private bool updateTimer = false;

        [SerializeField]
        private float animationDuration;

        [SerializeField]
        private bool isAnimating = false;

        private float timer = 0f;
        private float storedTime;

        private void Start()
        {
            gameTimerManager = GameTimerManager.Instance;

            if(gameTimerManager != null)
            {
                gameTimerManager.OnDayStartedEvent += OnGameDayStartedHandler;
                gameTimerManager.OnDayEndedEvent += OnGameDayEndedHandler;
                gameTimerManager.OnTimeSkipEvent += OnTimerSkipAnimation;
            }
            else
            {
                Debug.LogError("Game Timer Manager is not found");
            }
        }

        private void OnDestroy()
        {
            if (gameTimerManager != null)
            {
                gameTimerManager.OnDayStartedEvent -= OnGameDayStartedHandler;
                gameTimerManager.OnDayEndedEvent -= OnGameDayEndedHandler;
                gameTimerManager.OnTimeSkipEvent -= OnTimerSkipAnimation;
            }
        }

        private void OnGameDayStartedHandler()
        {
            updateTimer = true;
        }

        private void OnGameDayEndedHandler()
        {
            updateTimer = false;
        }

        private void Update()
        {
            if (!updateTimer) return;

            if (!isAnimating)
            {

                string timeString =
                    UtilityHelper.ConvertTimeFormat(gameTimerManager.CurrentTime);


                timerText.text = $"Day: {gameTimerManager.Day}, {timeString}";
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= animationDuration)
                {
                    timer = animationDuration;  // Clamp timer to avoid going beyond the animation duration
                    isAnimating = false; // Stop the animation once finished
                }

            }
        }

        private void OnTimerSkipAnimation()
        {
            isAnimating = true;
            storedTime = gameTimerManager.CurrentTime;
        }

        private void UpdateTimerText(float timeInSeconds)
        {

            int hours = Mathf.FloorToInt(timeInSeconds / 3600f);
            int minutes = Mathf.FloorToInt((timeInSeconds % 3600) / 60f);
            string ampm = hours >= 12 ? "PM" : "AM";

            // Convert to 12-hour format
            hours = hours % 12;
            if (hours == 0) hours = 12;  // Convert 0 hour to 12 for AM/PM format

            // Format time string (e.g., "02:30 PM")
            string timeString = string.Format("{0:D2}:{1:D2} {2}", hours, minutes, ampm);
        }
    }
}
