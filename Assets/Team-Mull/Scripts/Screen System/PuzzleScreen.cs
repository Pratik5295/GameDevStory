using DevStory.Interfaces;
using DevStory.TaskSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevStory.UI
{
    /// <summary>
    /// This script will be used extensively for screens that are the 
    /// UI screens for Puzzle tasks
    /// </summary>

    public class PuzzleScreen : Screen, ISubmitable
    {
        //Reference to Game Task
        [SerializeField]
        protected GameTask gameTask;

        [SerializeField]
        protected Button submitButton;

        //Temporary text and variables
        [SerializeField]
        protected TextMeshProUGUI statusText;

        [SerializeField] private GameObject content;

        //For puzzle screen we also showcase the submit button screen
        [SerializeField]
        private Screen submitScreen;

        private void Start()
        {
            submitButton.onClick.AddListener(OnSubmitButtonClicked);
        }

        public void SetTaskOnScreen(GameTask _gameTask)
        {
            gameTask = _gameTask;
        }

        private void OnDestroy()
        {
            submitButton.onClick.RemoveAllListeners();
        }

        public virtual void OnSubmitButtonClicked()
        {
        }

        public virtual void SubmitTask(float _currentTime)
        {
            gameTask.TaskCompleted();
        }


        /// <summary>
        /// The task puzzles will set the content at runtime
        /// </summary>
        /// <param name="_content"></param>
        public void SetContent(GameObject _content)
        {
            content = _content;
        }

        private void OnEnable()
        {
            if (content == null) return;
            //Check for any puzzles available to display
            content.SetActive(true);

            if (submitScreen == null) return;
            submitScreen.Open();
        }

        private void OnDisable()
        {
            if (content == null) return;
            content.SetActive(false);

            if (submitScreen == null) return;
            submitScreen.Close();
        }
    }
}
