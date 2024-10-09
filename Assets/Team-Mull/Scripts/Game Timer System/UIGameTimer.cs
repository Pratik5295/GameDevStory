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

        private void Start()
        {
            gameTimerManager = GameTimerManager.Instance;

            if(gameTimerManager != null)
            {
                gameTimerManager.OnDayStartedEvent += OnGameDayStartedHandler;
                gameTimerManager.OnDayEndedEvent += OnGameDayEndedHandler;
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
            timerText.text = timeString;
        }
    }
}
