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
            SortEvents(gameEvents);
        }

        private void Update()
        {
            
        }

        public List<GameEventSO> SortEvents(List<GameEventSO> events)
        {
            events.OrderBy(evt => evt.eventData.eventFireTime);
            return events;
        }
    }
}
