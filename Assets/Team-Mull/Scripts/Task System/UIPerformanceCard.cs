using TMPro;
using UnityEngine;

namespace DevStory.TaskSystem
{
    /// <summary>
    /// This script will added on the performance card prefab 
    /// to populate its display
    /// </summary>
    public class UIPerformanceCard : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI taskTitle;
        [SerializeField] private TextMeshProUGUI taskStatus;
        [SerializeField] private TextMeshProUGUI taskDeadline;

        [SerializeField]
        private TaskResultSaver result;

        public void SetTaskResult(TaskResultSaver _result)
        {
            result = _result;
            Populate(result);

        }

        public void Populate(TaskResultSaver _result)
        {
            taskTitle.text = _result.TaskName;
            taskStatus.text = _result.Status.ToString();
            taskDeadline.text = _result.Deadline.ToString();
        }

    }
}
