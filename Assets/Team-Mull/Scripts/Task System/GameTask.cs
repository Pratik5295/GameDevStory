using DevStory.Gameplay.GameTimer;
using DevStory.Managers;
using System;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;


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

        public TaskStatus Status;
        public TaskSO GetData => Data;  

        public Action OnTaskCompleted;

        [SerializeField]
        private TaskResultSaver CurrentResult;


        public void AddTaskToManager(TaskSO _taskData)
        {
            Data = _taskData;
            TaskManager.Instance.AddNewTask(this);

            Status = TaskStatus.TODO;

            var data = Data.TaskData;
            CurrentResult = new TaskResultSaver(data.TaskName, Status, data.Deadline);
        }

        public void TaskCompleted()
        {
            Status = TaskStatus.COMPLETED;

            CurrentResult.Status = Status;
            CurrentResult.SubmissionTime = GameTimerManager.Instance.CurrentTime;

            OnTaskCompleted?.Invoke();
        }
    }
}
