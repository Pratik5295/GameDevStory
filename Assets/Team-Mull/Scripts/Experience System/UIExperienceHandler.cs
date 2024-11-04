using DevStory.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace DevStory.Experience
{
    /// <summary>
    /// This script will be attached to the experience slider bar
    /// The script will listen to any changes/updates in the experience gained 
    /// by the user and update the UI accordingly
    /// </summary>
    /// 
    [DefaultExecutionOrder(5)]
    public class UIExperienceHandler : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;

        [SerializeField]
        private TaskManager taskManager;

        private void Start()
        {
            taskManager = TaskManager.Instance;

            if(taskManager != null)
            {
                taskManager.GetExperienceSystem.OnExperienceGainedEvent +=
                    OnExperienceGainedHandler;
            }
        }

        private void OnDestroy()
        {
            if (taskManager != null)
            {
                taskManager.GetExperienceSystem.OnExperienceGainedEvent -=
                    OnExperienceGainedHandler;
            }

        }

        private void OnExperienceGainedHandler(int _addedXp,int _totalXp)
        {
            slider.value += _addedXp;
        }
    }
}
