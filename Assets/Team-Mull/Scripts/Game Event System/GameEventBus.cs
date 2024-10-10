using UnityEngine;

namespace DevStory.GameEventSystem
{
    public class GameEventBus : MonoBehaviour
    {
        public static GameEventBus Instance = null;

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
