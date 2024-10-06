using DevStory.Gameplay.Puzzles;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevStory.UI
{
    /// <summary>
    /// This script extends the base class screen and
    /// holds the functionality of all programming screen puzzles
    /// </summary>
    public class ProgrammingScreen : Screen
    {
        [SerializeField] private Button submitButton;

        //Will later be improved to handle programming puzzles only
        [SerializeField] private Puzzle puzzle;

        //Temporary text and variables
        [SerializeField]
        private TextMeshProUGUI statusText;

        private void Start()
        {
            submitButton.onClick.AddListener(OnSubmitClicked);
        }

        private void OnDestroy()
        {
            submitButton.onClick.RemoveAllListeners();
        }

        public void OnSubmitClicked()
        {
           bool res = puzzle.ValidityCheck();

            var message = $"Puzzle Result is: {res}";

            Debug.Log(message);
            statusText.text = message;
        }
    }
}
