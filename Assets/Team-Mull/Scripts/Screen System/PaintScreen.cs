using UnityEngine;

namespace DevStory.UI
{
    /// <summary>
    /// This class extends the base screen class to build the 
    /// paint screen where the paint puzzles will take place
    /// </summary>
    public class PaintScreen : Screen
    {
        [SerializeField] private GameObject content;

        private void OnEnable()
        {
            //Check for any puzzles available to display
            content.SetActive(true);
        }

        private void OnDisable()
        {
            content.SetActive(false);
        }
    }
}
