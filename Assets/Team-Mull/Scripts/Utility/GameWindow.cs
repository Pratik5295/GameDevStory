using UnityEngine;

namespace DevStory.Utility
{
    public class GameWindow : MonoBehaviour
    {
        public static GameWindow Instance = null;

        public Vector2 horizontalLimits = new Vector2(-9.5f, 9.5f);
        public Vector2 verticalLimits = new Vector2(6f, -4f);

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
