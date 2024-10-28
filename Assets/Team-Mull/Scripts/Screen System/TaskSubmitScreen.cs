using DevStory.Interfaces;
using UnityEngine;

namespace DevStory.UI
{
    public class TaskSubmitScreen : Screen, ISubmitable
    {
        public void SubmitTask(float _currentTime)
        {
            Debug.Log("Submitting task");
        }
    }
}
