using UnityEngine;
using System.Collections.Generic;

namespace DevStory.GameEventSystem
{
    public class GameEventBus : MonoBehaviour
    {
        public static GameEventBus Instance = null;

        [SerializeField] private List<GameEventSO> gameEvents = new List<GameEventSO>();

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
    }
}
