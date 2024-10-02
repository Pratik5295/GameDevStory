using DevStory.Interfaces;
using UnityEngine;

namespace DevStory.Managers
{
    /// <summary>
    /// This singleton will handle all the mouse clicked related features
    /// and hold references to selected/processed sprites in the game
    /// </summary>
    public class PointManager : MonoBehaviour
    {
        public static PointManager Instance = null;

        [SerializeField] private ISelected selected;

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

        public void ResetSelected()
        {
            selected = null;
            Debug.Log("Selection is now null");
        }

        public void SelectSprite(ISelected _selection)
        {
            selected = _selection;
            Debug.Log($"Selected sprite is: {selected}");
        }
    }
}
