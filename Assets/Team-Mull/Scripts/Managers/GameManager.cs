using DevStory.PressureSystem;
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
        private PressureManager PressureManager;

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

        private void OnPressureMaxedOutEventHandler()
        {
            //Pressure maxed out, check if game over or game completed
        }
    }
}
