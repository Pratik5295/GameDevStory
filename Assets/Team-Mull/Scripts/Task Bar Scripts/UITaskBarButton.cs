using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;


namespace DevStory.UI.TaskBar
{
    /// <summary>
    /// The UI task bar functionality handler
    /// </summary>
    public class UITaskBarButton : MonoBehaviour
    {
        [SerializeField] private GameScreens screenRef;

        public void OnTaskBarButtonClicked()
        {
            ScreenManager.Instance.ScreenChange(screenRef);
        }
    }
}
