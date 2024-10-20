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

        public TaskResultSaver(float _deadline)
        {
            TaskName = "TaskName";
            Status = TaskStatus.DEFAULT;
            Deadline = _deadline;
            SubmissionTime = -1;
        }
    }

    public class PerformanceReviewer : MonoBehaviour
    {

    }
}
