using UnityEngine;


namespace DevStory.UI
{
    /// <summary>
    /// Generic class to show an element on click & hide after a certain duration
    /// </summary>
    public class UIShowOnClick : MonoBehaviour
    {

        [SerializeField]
        private bool isShown = false;

        [SerializeField]
        private GameObject content;

        [SerializeField]
        private float duration;

        private void Start()
        {
            //By default hide the item
            HideAfterDuration();
        }

        public void OnItemClicked()
       {
            if (isShown) return;

            content.SetActive(true);
            isShown = true;

            Invoke("HideAfterDuration", duration);
       }

        private void HideAfterDuration()
        {
            content.SetActive(false);
            isShown = false;
        }
    }
}
