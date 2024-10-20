using System.Collections.Generic;
using UnityEngine;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.TaskSystem
{
    /// <summary>
    /// This structure will be used as reference on
    /// what data about the task would be saved in backend
    /// </summary>
    [System.Serializable]
    public struct TaskResultSaver
    {
        public string TaskName;
        public TaskStatus Status;
        public float Deadline;
        public float SubmissionTime;

        public TaskResultSaver(string _taskName, TaskStatus _status, float _deadline)
        {
            TaskName = _taskName;
            Status = _status;
            Deadline = _deadline;
            SubmissionTime = -1;    //-1 reflects the task wasnt submitted yet
        }
    }

    public class PerformanceReviewer : MonoBehaviour
    {
        public Dictionary<GameTask,TaskResultSaver> taskResults = new Dictionary<GameTask,TaskResultSaver>();

        #region Task Results Data Handling
        /// <summary>
        /// This function will be entry point for any data update in the dictionary
        /// Updating any existing result value will also pass through this function
        /// </summary>
        /// <param name="_task"></param>
        /// <param name="_saver"></param>
        public void UpdateResult(GameTask _task, TaskResultSaver _saver)
        {
            if (!taskResults.ContainsKey(_task))
            {
                taskResults.Add(_task, _saver);
            }
            else
            {
                UpdateResultValue(_task, _saver);
            }
        }

        public void RemoveResult(GameTask _task)
        {
            if (taskResults.ContainsKey(_task))
            {
                taskResults.Remove(_task);
            }
        }

        public void ClearAll()
        {
            taskResults.Clear();
        }

        public void UpdateResultValue(GameTask _task, TaskResultSaver _saver)
        {
            taskResults[_task] = _saver;
        }

        #endregion

        #region Task Results Display Handling

        public void ShowAllTaskResults()
        {
            foreach(var kvp in taskResults)
            {
                Debug.Log($"{kvp.Value.TaskName}, {kvp.Value.Status} & {kvp.Value.SubmissionTime}");
            }
        }

        #endregion
    }
}
