using DevStory.Gameplay.GameTimer;
using DevStory.Gameplay.Puzzles;
using DevStory.Interfaces;
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

            var res = puzzle.CheckPuzzleValidation() ? "Solved" : "Unsolved";
            var message = $"Puzzle Result is: {res}";

            Debug.Log(message);
            statusText.text = message;
        }

        public override void SubmitTask(float _currentTime)
        {
            Debug.Log("Submitting the task");
        }
    }
}
