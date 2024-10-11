using DevStory.Gameplay.GameTimer;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace DevStory.GameEventSystem
{
    [DefaultExecutionOrder(2)]
    public class GameEventBus : MonoBehaviour
    {
        public static GameEventBus Instance = null;

        [SerializeField] private List<GameEventSO> gameEvents = new List<GameEventSO>();

        private GameTimerManager gameTimerManager;
        private int nextEventIndex = 0;
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
            gameTimerManager  =  GameTimerManager.Instance;

            if(gameEvents.Count > 0)
            {
                SortEvents();
            }
        }

        private void Update()
        {
            if (nextEventIndex < gameEvents.Count)
            {
                GameEventSO nextEvent = gameEvents[nextEventIndex];
                if (gameTimerManager.CurrentTime >= nextEvent.eventData.eventFireTime)
                {
                    nextEvent.Execute();
                    nextEventIndex++;
                }
            }
        }

        public void SortEvents()
        {
            gameEvents = gameEvents.OrderBy(evt => evt.eventData.eventFireTime).ToList();
        }

        private void PrintEvents()
        {
            int index = 0;
            foreach (var evt in gameEvents)
            {
                Debug.Log($"Position:{index}, {evt.eventData.eventCode} and {evt.eventData.eventFireTime}");
                index++;
            }
        }
    }
}
