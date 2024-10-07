using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevStory.DialogueSystem
{

    /// <summary>
    /// Extend this to 4 different UI classes
    /// </summary>
    public class DialogueScreen: MonoBehaviour
    {
        public GameEmail activeDialogue;

        [SerializeField] private TextMeshProUGUI speakerText;
        [SerializeField] private TextMeshProUGUI dialogueText;


        //UI for options
        public Button[] optionButtons;

        //Reference to the next message button
        [SerializeField] private GameObject nextButton;

        private void Start()
        {
            //Only for testing, will be removed once dialogue manager is in place
            if(activeDialogue != null)
                SetActiveDialogue(activeDialogue);
        }

        /// <summary>
        /// Move to manager afterwards
        /// </summary>
        public void SetActiveDialogue(GameEmail _newDialogue)
        {
            activeDialogue = _newDialogue;

            DisplayNextMessage();
        }

        public void DisplayNextMessage()
        {
            var currentMessage = activeDialogue.GetMessage();
            

            Debug.Log($"Message:{currentMessage.Message} and Speaker: {currentMessage.Speaker}");

            dialogueText.text = currentMessage.Message;
            speakerText.text = currentMessage.Speaker;

            //Populate your options if any
            if (currentMessage.Options != null && currentMessage.Options.Length > 0)
            {
                nextButton.SetActive(false);
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
                            activeDialogue.TraverseMessageCounterTo(nextIndex);
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
                nextButton.SetActive(true);
                //Hide all your options
                foreach (var option in optionButtons)
                {
                    option.gameObject.SetActive(false);
                }
            }
        }

        public void ShowNextMessage()
        {
            if (activeDialogue.LastMessageShown())
            {
                DialogueManager.Instance.Close();
            }
            else
            {
                activeDialogue.TraverseMessageCounter();
                DisplayNextMessage();
            }
        }
       
    }
}
