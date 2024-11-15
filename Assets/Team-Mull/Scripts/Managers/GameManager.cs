using DevStory.PressureSystem;
using DevStory.TaskSystem;
using UnityEngine;

namespace DevStory.Managers
{
    /// <summary>
    /// This script will be responsible for determing the end state of the game
    /// LOSE: GAME OVER, WIN: BECOME A DEMON
    /// </summary>
    /// 
    [DefaultExecutionOrder(1)]
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance = null;

        [SerializeField]
        private GameSettingsSO gameSettingsData;

        [SerializeField]
        private PressureManager PressureManager;

        [SerializeField]
        private GameObject gameOverObject;

        [SerializeField]
        private GameObject gameWonObject;

        [Space(10)]
        [Header("Game Settings Data - Local Cache")]
        [SerializeField]
        private WinConditionsData WinConditionsData;

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

        private void Start()
        {
            LoadSettings();

            PressureManager = PressureManager.Instance;

            if (PressureManager != null)
            {
                PressureManager.OnPressureMaxedOutEvent += OnPressureMaxedOutEventHandler;
            }

        }

        private void OnDestroy()
        {
            if (PressureManager != null)
            {
                PressureManager.OnPressureMaxedOutEvent -= OnPressureMaxedOutEventHandler;
            }
        }

        private void LoadSettings()
        {
            if(gameSettingsData == null)
            {
                Debug.LogError("Game Settings SO is missing");
                return;
            }
            else
            {
                WinConditionsData = gameSettingsData.WinConditions;
            }
        }

        private void OnPressureMaxedOutEventHandler()
        {
            //Pressure maxed out, LOSEE
            LoseCondition();
        }

        public void GameCompletedCheck()
        {
            //85% experience from total pts & stress is below 50% => Win State

            if(PressureManager.Instance.GetCurrentPressure <= WinConditionsData.StressThreshold)
            {
                //Check if experience is greater than 85%
                float passingExp = (TaskManager.Instance.GetExperienceSystem.CurrentXP / WinConditionsData.MaximumExperienceInGame) * 100;

                if(passingExp >= WinConditionsData.ExperienceRequiredThreshold)
                {
                    WinCondition();
                }
                else
                {
                    LoseCondition();
                }


            }
            else
            {
                LoseCondition();
            }

        }

        private void LoseCondition()
        {
            gameOverObject.SetActive(true);
        }

        private void WinCondition()
        {
            gameWonObject.SetActive(true);
        }
    }
}
