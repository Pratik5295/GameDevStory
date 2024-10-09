using DevStory.Gameplay.GameTimer;
using DevStory.Gameplay.Puzzles;
using DevStory.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevStory.UI
{
    /// <summary>
    /// This script extends the base class screen and
    /// holds the functionality of all programming screen puzzles
    /// </summary>
    public class ProgrammingScreen : PuzzleScreen
    {
        //Will later be improved to handle programming puzzles only
        [SerializeField] private Puzzle puzzle;

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

            var res = puzzle.ValidityCheck() ? "Solved" : "Unsolved";

            var message = $"Submitting the task at {formatCurrTime} and Deadline: {formatDeadline} and result: {res}";

            Debug.Log(message);
            statusText.text = message;
        }
    }
}
