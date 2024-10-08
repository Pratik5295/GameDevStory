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
    public class PaintScreen : Screen,ISubmitable
    {
        [SerializeField] private PaintPuzzle puzzle;

        [SerializeField]
        private Button submitButton;

        //Temporary text and variables
        [SerializeField]
        private TextMeshProUGUI statusText;

        private void Start()
        {
            submitButton.onClick.AddListener(SubmitPuzzleCheck);
        }

        private void OnDestroy()
        {
            submitButton.onClick.RemoveAllListeners();
        }

        public void SubmitPuzzleCheck()
        {
            var res = puzzle.CheckPuzzleValidation() ? "Solved" : "Unsolved";
            var message = $"Puzzle Result is: {res}";

            Debug.Log(message);
            statusText.text = message;

            //Call the submit task interface 
            SubmitTask();
        }

        public void SubmitTask()
        {
            Debug.Log("Submitting the task");
        }
    }
}
