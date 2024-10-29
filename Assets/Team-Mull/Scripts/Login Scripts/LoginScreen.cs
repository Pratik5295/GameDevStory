using DevStory.Gameplay.GameTimer;
using UnityEngine;

[DefaultExecutionOrder(5)]
public class LoginScreen : MonoBehaviour
{
    [SerializeField]
    private GameTimerManager gameTimerManager;

    [SerializeField]
    private GameObject content;


    private void Awake()
    {
        gameTimerManager = GameTimerManager.Instance;

        if(gameTimerManager != null)
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
        content.SetActive(false);
    }

    private void OnDayEndedEventHandler()
    {
        content.SetActive(true);
    }

    public void OnLoginButtonClicked()
    {
        GameTimerManager.Instance.StartDay();
    }

    public void OnQuitGameButtonClicked()
    {
        Application.Quit();
    }
}
