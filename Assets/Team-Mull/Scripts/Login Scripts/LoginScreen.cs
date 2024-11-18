using DevStory.Gameplay.GameTimer;
using DevStory.Managers;
using UnityEngine;

namespace DevStory.UI
{
    [DefaultExecutionOrder(5)]
    public class LoginScreen : Screen
    {
        [SerializeField]
        private GameTimerManager gameTimerManager;

        [SerializeField]
        private GameObject content;

        [Header("Audio Section")]
        [SerializeField]
        private AudioClip onLoginSfx;


        private void Awake()
        {
            gameTimerManager = GameTimerManager.Instance;

            if (gameTimerManager != null)
            {
                gameTimerManager.OnDayStartedEvent += OnDayStartedEventHandler;

                gameTimerManager.OnDayEndedEvent += OnDayEndedEventHandler;
            }
        }

        private void OnDestroy()
        {
            if (gameTimerManager != null)
            {
                gameTimerManager.OnDayStartedEvent -= OnDayStartedEventHandler;

                gameTimerManager.OnDayEndedEvent -= OnDayEndedEventHandler;
            }
        }

        private void OnDayStartedEventHandler()
        {
            Close();
        }

        private void OnDayEndedEventHandler()
        {
            Open();
            PlayBackgroundAudio();
        }

        public void OnLoginButtonClicked()
        {
            GameTimerManager.Instance.StartDay();

            ScreenManager.Instance.ScreenChange(MetaConstants.EnumManager.EnumManager.GameScreens.MAIN);
        }

        public void OnQuitGameButtonClicked()
        {
            Application.Quit();
        }

        private void PlayBackgroundAudio()
        {
            if (onLoginSfx != null)
            {
                AudioManager.Instance.PlayBackgroundMusic(onLoginSfx);
            }
        }

        public override void Open()
        {
            base.Open();
            content.SetActive(true);
            PlayBackgroundAudio();
        }

        public override void Close()
        {
            base.Close();
            content.SetActive(false);
        }
    }
}
