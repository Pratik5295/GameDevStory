using DevStory.Data;
using DevStory.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace DevStory.UI
{
    /// <summary>
    /// This script extends the screen and represents
    /// all the communications the player would receive
    /// from the supervisors or the game
    /// </summary>
    public class GameEmailScreen : Screen
    {
        [Space(10)]
        [Header("Email Content Details")]
        [SerializeField]
        private TextMeshProUGUI emailHeader;

        [SerializeField]
        private TextMeshProUGUI emailSenderName;

        [SerializeField]
        private TextMeshProUGUI emailBody;

        [SerializeField]
        private ScreenChangeData buttonChangeData;

        [SerializeField]
        private UIScreenButton taskButton;

        //UI for options
        public Button[] optionButtons;

        [Space(10)]
        [Header("Dialogue Variables")]

        public GameEmail activeEmail;

        public void SetScreenChangeData(ScreenChangeData _newData)
        {
            buttonChangeData = _newData;
            taskButton.PopulateDisplay(_newData);
        }

        private void Start()
        {
            SetActiveDialogue(activeEmail); 
        }

        /// <summary>
        /// Move to manager afterwards
        /// </summary>
        public void SetActiveDialogue(GameEmail _newDialogue)
        {
            activeEmail = _newDialogue;
            emailHeader.text = _newDialogue.EmailTitle;
            DisplayNextMessage();
        }

        public void DisplayNextMessage()
        {
            var currentMessage = activeEmail.GetMessage();


            Debug.Log($"Message:{currentMessage.Message} and Speaker: {currentMessage.Speaker}");

            emailBody.text = currentMessage.Message;
            emailSenderName.text = currentMessage.Speaker;

            //Populate your options if any
            if (currentMessage.Options != null && currentMessage.Options.Length > 0)
            {
                for (int i = 0; i < optionButtons.Length; i++)
                {
                    if (i < currentMessage.Options.Length)
                    {
                        optionButtons[i].gameObject.SetActive(true);
                        optionButtons[i].GetComponent<UIDialogueOption>().SetOption(currentMessage.Options[i].optionMessage);
                        int nextIndex = currentMessage.Options[i].nextMessageIndex;
                        optionButtons[i].onClick.RemoveAllListeners();
                        optionButtons[i].onClick.AddListener(() =>
                        {
                            activeEmail.TraverseMessageCounterTo(nextIndex);
                            DisplayNextMessage();
                        });
                    }
                    else
                    {
                        optionButtons[i].gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                //Hide all your options
                foreach (var option in optionButtons)
                {
                    option.gameObject.SetActive(false);
                }
            }
        }

        public void ShowNextMessage()
        {
            if (activeEmail.LastMessageShown())
            {
                //DialogueManager.Instance.Close();
            }
            else
            {
                activeEmail.TraverseMessageCounter();
                DisplayNextMessage();
            }
        }


    }
}
