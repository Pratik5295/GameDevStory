using DevStory.Experience;
using DevStory.Gameplay.GameTimer;
using DevStory.Gameplay.Puzzles;
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
        public TaskPriority Priority;
        public TaskSO GetData => Data;  

        public Action OnTaskCompleted;

        [SerializeField]
        private int EventFireDay;

        [SerializeField]
        private TaskResultSaver CurrentResult;

        public TaskResultSaver GetResult => CurrentResult;

        //Local reference for each of the task object
        [SerializeField]
        private GameObject puzzleObject;

        //Public reference to be used for Puzzle Object
        public Puzzle Puzzle => puzzleObject.GetComponent<Puzzle>();


        public void AddTaskToManager(TaskSO _taskData,GameObject _taskObject, int eventFireDay)
        {
            EventFireDay = eventFireDay;

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

            bool Solved = Puzzle.ValidityCheck();

            float Deadline = Data.TaskData.Deadline;

            int Today = GameTimerManager.Instance.Day;
            float SubmissionTime = GameTimerManager.Instance.CurrentTime;

            //Calculate Puzzle Task result and update
            TaskResult result = TaskResultCalculator.GetTaskResult(Solved, EventFireDay, Deadline, Today, SubmissionTime);

            CurrentResult.Status = Status;
            CurrentResult.SubmissionTime = GameTimerManager.Instance.CurrentTime;
            CurrentResult.SubmissionDay = GameTimerManager.Instance.Day;
            CurrentResult.Result = result;
            CurrentResult.ExperienceGained = ExperiencePointCalculator.GetExperience(CurrentResult);


            OnTaskCompleted?.Invoke();

            TaskManager.Instance.UpdateTaskResult(this,CurrentResult);

            //Destroy the puzzle object after submission
            RemovePuzzleObject();
        }

        private void RemovePuzzleObject()
        {
            Destroy(puzzleObject);
            puzzleObject = null;
        }
    }
}
