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

    }
}
