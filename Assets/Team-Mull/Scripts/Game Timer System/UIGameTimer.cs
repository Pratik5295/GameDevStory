using UnityEngine;
using TMPro;
using DevStory.Utility;
using DevStory.VFX;

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

        [SerializeField]
        private ScaleWithColorChange scalingVfx;

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

            string timeString =
                               UtilityHelper.ConvertTimeFormat(gameTimerManager.CurrentTime);


            timerText.text = $"Day: {gameTimerManager.Day}, {timeString}";

        }

        private void OnTimerSkipAnimation()
        {
            scalingVfx.ScaleTween();
        }
    }
}
