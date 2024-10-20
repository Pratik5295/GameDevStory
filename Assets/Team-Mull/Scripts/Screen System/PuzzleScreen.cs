using DevStory.Gameplay.GameTimer;
using DevStory.Gameplay.Puzzles;
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
    }
}
