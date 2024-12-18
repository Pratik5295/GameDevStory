using DevStory.Interfaces;
using DevStory.Managers;
using DevStory.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace DevStory.UI
{
    public class TaskSubmitScreen : Screen, ISubmitable
    {
        [SerializeField]
        protected Button submitButton;

        [SerializeField]
        private PuzzleScreen activePuzzleScreen;

        [SerializeField]
        private ToggleHandler submitToggle;


        private void Start()
        {
            submitButton.onClick.AddListener(OnSubmitButtonClicked);
        }


        private void OnDestroy()
        {
            submitButton.onClick.RemoveAllListeners();
        }

        public virtual void OnSubmitButtonClicked()
        {
            SubmitTask();
        }


        public void SubmitTask()
        {
            Debug.Log("Submitting task");

            //Fire Validity check on active puzzle screen
            activePuzzleScreen.OnTaskSubmitted();

            //Close();

            //Submit task through the task manager
            TaskManager.Instance.OnTaskSubmittedButtonClicked();
        }

        public void OpenTaskScreen(PuzzleScreen puzzleScreen)
        {
            activePuzzleScreen = puzzleScreen;

            Open();

            submitToggle.SetInActive();
        }

        public override void Close()
        {
            base.Close();
            activePuzzleScreen = null;  
        }
    }
}
