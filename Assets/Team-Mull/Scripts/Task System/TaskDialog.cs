using DevStory.Data;
using DevStory.Managers;
using DevStory.UI;
using DevStory.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static MetaConstants.EnumManager.EnumManager;

namespace DevStory.TaskSystem
{
    /// <summary>
    /// This script will represent the full card dialog box of the task
    /// It will contain all the details and the button to change the screen
    /// </summary>
    public class TaskDialog : MonoBehaviour
    {
        [SerializeField] private GameTaskData currentTaskData;
        [SerializeField] private GameTask selectedTaskObject;

        [SerializeField] private TextMeshProUGUI taskTitle;
        [SerializeField] private Image taskHeaderImage;

        [SerializeField] private Image supervisorFaceCard;
        [SerializeField] private TextMeshProUGUI supervisorName;

        [SerializeField] private TextMeshProUGUI descriptionText;

        [SerializeField] private UIScreenButton taskButton;

        [SerializeField] private TextMeshProUGUI completeByText;

        public void SetTaskData(GameTask _taskObject)
        {
            selectedTaskObject = _taskObject;
            currentTaskData = _taskObject.GetData.TaskData;
            PopulateDisplay();
        }

        public void ResetTaskData()
        {
            selectedTaskObject = null;
            currentTaskData = default;
        }

        private void PopulateDisplay()
        {
            taskTitle.text = currentTaskData.TaskName;

            taskHeaderImage.color
                = ColorCoder.GetColorFromPriority(currentTaskData.Priority);

            supervisorFaceCard.sprite = currentTaskData.SupervisorData.Data.CharacterSprite;

            supervisorName.text = currentTaskData.SupervisorData.Data.CharacterName;

            descriptionText.text = currentTaskData.Description;

            completeByText.text
                = $"Deadline: {UtilityHelper.ConvertTimeFormat(currentTaskData.Deadline)}";

            var screenValue
                = UtilityHelper.GetScreenIntegerFromTaskType(currentTaskData.Type);

            //Create new screen data change type
            ScreenChangeData screenChangeData = new ScreenChangeData()
            {
                Message = "Go to Task",
                OpenScreen = screenValue
            };

            taskButton.PopulateDisplay(screenChangeData);

            taskButton.OnSwitchScreenEventFired += OnTaskScreenButtonClicked;

            //Set reference to puzzle screen 
            SetTaskOnPuzzleScreen(screenValue);

        }

        public void OnCloseButtonClicked()
        {
            //Close the dialog box
            TaskManager.Instance.Close();

            ResetTaskData();
        }

        private void OnTaskScreenButtonClicked()
        {
            OnCloseButtonClicked();
            taskButton.OnSwitchScreenEventFired -= OnTaskScreenButtonClicked;
        }

        

        /// <summary>
        /// Sets reference to the local task object on puzzle screen
        /// </summary>
        public void SetTaskOnPuzzleScreen(GameScreens screenValue)
        {
            //On Start task button clicked
            var screen = ScreenManager.Instance.GetScreen(screenValue);

            if(screen.gameObject.TryGetComponent<PuzzleScreen>(out var puzzleScreen))
            {
                puzzleScreen.SetTaskOnScreen(selectedTaskObject);
            }
        }

    }
}

