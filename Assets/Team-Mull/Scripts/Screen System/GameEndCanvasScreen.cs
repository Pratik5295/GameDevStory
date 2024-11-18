using DevStory.Gameplay.GameTimer;
using UnityEngine;

namespace DevStory.UI
{
    /// <summary>
    /// This script will sit on Game End Canvas screen and just fire the skip time UI
    /// </summary>
    /// 
    [DefaultExecutionOrder(3)]  
    public class GameEndCanvasScreen : MonoBehaviour
    {

        [SerializeField]
        private GameTimerManager gameTimerManager;

        [SerializeField]
        private GameObject skipTimeCanvas;

        [SerializeField]
        private float hideSkipTimerAfter;

        private void Start()
        {
            gameTimerManager = GameTimerManager.Instance;

            if (gameTimerManager != null)
            {
                gameTimerManager.OnTimeSkipEvent += OnTimeSkipEventHandler;
            }

            HideSkipTimer();
        }

        private void OnDestroy()
        {
            if (gameTimerManager != null)
            {
                gameTimerManager.OnTimeSkipEvent -= OnTimeSkipEventHandler;
            }
        }


        private void OnTimeSkipEventHandler()
        {
            skipTimeCanvas.SetActive(true);

            Invoke("HideSkipTimer", hideSkipTimerAfter);
        }

        private void HideSkipTimer()
        {
            skipTimeCanvas.SetActive(false);
        }

    }
}
