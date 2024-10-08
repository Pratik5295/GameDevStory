using DevStory.Data;
using DevStory.Managers;
using DevStory.UI;
using DevStory.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevStory.TaskSystem
{
    /// <summary>
    /// This script will represent the full card dialog box of the task
    /// It will contain all the details and the button to change the screen
    /// </summary>
    public class TaskDialog : MonoBehaviour
    {
        [SerializeField] private GameTaskData currentTaskData;

        [SerializeField] private TextMeshProUGUI taskTitle;
        [SerializeField] private Image taskHeaderImage;

        [SerializeField] private Image supervisorFaceCard;
        [SerializeField] private TextMeshProUGUI supervisorName;

        [SerializeField] private TextMeshProUGUI descriptionText;

        [SerializeField] private UIScreenButton taskButton;

        public void SetTaskData(GameTaskData _taskData)
        {
            currentTaskData = _taskData;
            PopulateDisplay();
        }

        private void PopulateDisplay()
        {
            taskTitle.text = currentTaskData.TaskName;

            taskHeaderImage.color
                = ColorCoder.GetColorFromPriority(currentTaskData.Priority);

            supervisorFaceCard.sprite = currentTaskData.SupervisorSprite;

            supervisorName.text = currentTaskData.SupervisorName;

            descriptionText.text = currentTaskData.Description;

            int screenValue
                = UtilityHelper.GetScreenIntegerFromTaskType(currentTaskData.Type);

            //Create new screen data change type
            ScreenChangeData screenChangeData = new ScreenChangeData()
            {
                Message = "Go to Paint",
                OpenScreen = screenValue
            };

            taskButton.PopulateDisplay(screenChangeData);

        }

        public void OnCloseButtonClicked()
        {
            //Close the dialog box
            TaskManager.Instance.Close();
        }

        /// <summary>
        /// Have the game load your puzzle at runtime and assign it with 
        /// the relevant screen manager
        /// </summary>
        public void LoadActivity()
        {
            if (currentTaskData.TaskPrefab == null) return;

            GameObject go =
                Instantiate(currentTaskData.TaskPrefab,
                Vector3.zero,
                Quaternion.identity);
        }

    }
}
