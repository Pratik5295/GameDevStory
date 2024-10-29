using DevStory.Gameplay.GameTimer;
using DevStory.Gameplay.Puzzles;
using DevStory.Managers;
using DevStory.UI;
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
        public TaskPriority Priority;
        public TaskSO GetData => Data;  

        public Action OnTaskCompleted;

        [SerializeField]
        private TaskResultSaver CurrentResult;

        public TaskResultSaver GetResult => CurrentResult;

        //Reference to the active puzzle screen based on the task?
        [SerializeField]
        private PuzzleScreen puzzleScreen;

        //Local reference for each of the task object
        [SerializeField]
        private GameObject puzzleObject;

        //Public reference to be used for Puzzle Object
        public Puzzle Puzzle => puzzleObject.GetComponent<Puzzle>();


        public void AddTaskToManager(TaskSO _taskData,GameObject _taskObject)
        {
            Data = _taskData;

            Status = TaskStatus.TODO;
            Priority = Data.TaskData.Priority;

            var data = Data.TaskData;
            CurrentResult = 
                new TaskResultSaver(data.TaskName, 
                Status, Priority, data.Deadline);

            //Setting local reference for the task object
            puzzleObject = _taskObject;

            TaskManager.Instance.AddNewTask(this, _taskObject, CurrentResult);
        }

        public void TaskCompleted()
        {
            Status = TaskStatus.COMPLETED;

            CurrentResult.Status = Status;
            CurrentResult.SubmissionTime = GameTimerManager.Instance.CurrentTime;
            CurrentResult.SubmissionDay = GameTimerManager.Instance.Day;

            OnTaskCompleted?.Invoke();

            TaskManager.Instance.UpdateTaskResult(this,CurrentResult);


        }
    }
}
