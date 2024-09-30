using UnityEngine;


namespace DevStory.UI.TaskBar
{
    /// <summary>
    /// The UI task bar functionality handler
    /// </summary>
    public class UITaskBarButton : MonoBehaviour
    {
        [SerializeField] private int screenRef;

        public void OnTaskBarButtonClicked()
        {
            ScreenManager.Instance.OnChangeActiveScreen(screenRef);
        }
    }
}
