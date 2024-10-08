using System;
using UnityEngine;


namespace DevStory.TaskSystem
{
    /// <summary>
    /// This script will be responsible for connecting taskSO backend data
    /// with front end.
    /// This script will communicate with the task manager to send task progress.
    /// This script will hold events to update the task progress and completion
    /// </summary>
    public class GameTask : MonoBehaviour
    {
        [SerializeField]
        private TaskSO Data;

        public TaskSO GetData => Data;  

        public Action OnTaskCompleted;

        //Only for testing
        [SerializeField] private UITaskCard taskCard;

        private void Start()
        {
            taskCard.SetTaskData(this);
        }
    }
}
