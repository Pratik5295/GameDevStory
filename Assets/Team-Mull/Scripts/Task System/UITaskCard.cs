using DevStory.Managers;
using DevStory.Utility;
using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.UI;

namespace DevStory.TaskSystem
{
    /// <summary>
    /// This script will represent the task's values into the UI
    /// It will be used on the card
    /// </summary>


    public class UITaskCard : MonoBehaviour
    {
        [SerializeField] private GameTaskData taskData;

        [SerializeField] private GameTask gameTask;

        [Space(10)]
        [Header("Task Card UI References")]
        [SerializeField] private Image priorityImage;
        [SerializeField] private TextMeshProUGUI taskTitle;

        public void SetTaskData(GameTask _gameTask)
        {
            gameTask = _gameTask;
            taskData = gameTask.GetData.TaskData;

            PopulateTaskData();
        }

        private void PopulateTaskData()
        {
            taskTitle.text = taskData.TaskName;
            priorityImage.color = ColorCoder.GetColorFromPriority(taskData.Priority);
        }

        public void OnTaskButtonClicked()
        {
            Debug.Log("Loading task on the dialog");
            TaskManager.Instance.OpenTaskDialogBox(gameTask);
        }
    }
}
