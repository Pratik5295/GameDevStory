using DevStory.Gameplay.Puzzles;
using DevStory.TaskSystem;
using UnityEngine;

namespace DevStory.UI
{
    /// <summary>
    /// This script will be used extensively for screens that are the 
    /// UI screens for Puzzle tasks
    /// </summary>

    public class PuzzleScreen : Screen
    {
        //Reference to Game Task
        [SerializeField]
        protected GameTask gameTask;

        [SerializeField]
        private GameObject content;

        [SerializeField] 
        protected Puzzle puzzle;

        //For puzzle screen we also showcase the submit button screen
        [SerializeField]
        private TaskSubmitScreen submitScreen;

        //Empty screens for no task
        [SerializeField]
        private GameObject emptyState;

      

        public virtual void SetTaskOnScreen(GameTask _gameTask)
        {
            gameTask = _gameTask;
            puzzle = _gameTask.Puzzle;
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
            submitScreen.OpenTaskScreen(this);

            //Check for empty state
            if(emptyState == null) return;
            NullCheckValidation();

        }

        private void OnDisable()
        {
            if (content == null) return;
            content.SetActive(false);

            if (submitScreen == null) return;
            submitScreen.Close();

        }

        public void OnTaskSubmitted()
        {
            var res = puzzle.ValidityCheck() ? "Solved" : "Unsolved";

            var message = $"Submitting the task result: {res}";
        }

        public void NullCheckValidation()
        {
            emptyState.SetActive(gameTask == null);
        }
    }
}
