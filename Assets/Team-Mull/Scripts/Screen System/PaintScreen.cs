using DevStory.Gameplay.GameTimer;
using DevStory.Gameplay.Puzzles;
using DevStory.Interfaces;
using DevStory.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevStory.UI
{
    /// <summary>
    /// This class extends the base screen class to build the 
    /// paint screen where the paint puzzles will take place
    /// </summary>
    public class PaintScreen :PuzzleScreen
    {
        [SerializeField] private PaintPuzzle puzzle;

        public override void SubmitPuzzleCheck()
        {
            //Call the submit task interface 
            SubmitTask(GameTimerManager.Instance.CurrentTime);
           
        }

        public override void SubmitTask(float _currentTime)
        {
            var currentTime = GameTimerManager.Instance.CurrentTime;
            string formatCurrTime = UtilityHelper.ConvertTimeFormat(currentTime);

            var deadlineTime = gameTask.GetData.TaskData.Deadline;
            string formatDeadline = UtilityHelper.ConvertTimeFormat(deadlineTime);

            var res = puzzle.CheckPuzzleValidation() ? "Solved" : "Unsolved";

            var message = $"Submitting the task at {formatCurrTime} and Deadline: {formatDeadline} and result: {res}";

            Debug.Log(message);
            statusText.text = message;
        }
    }
}
