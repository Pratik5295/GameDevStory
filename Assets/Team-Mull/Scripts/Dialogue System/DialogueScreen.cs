using DevStory.Interfaces.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevStory.Dialogue
{

    /// <summary>
    /// Extend this to 4 different UI classes
    /// </summary>
    public class DialogueScreen: MonoBehaviour, IScreen
    {
        public Dialogue activeDialogue;
        public DialogueMessageSO[] Messages;

        [SerializeField] private TextMeshProUGUI speakerText;
        [SerializeField] private TextMeshProUGUI dialogueText;


        //UI for options
        public Button[] optionButtons;
        [SerializeField] private int currentMessageIndex = 0;

        [SerializeField] private int lastMessageIndex;

        //Reference to the next message button
        [SerializeField] private GameObject nextButton;

        private void Start()
        {
            SetActiveDialogue();
        }

        /// <summary>
        /// Move to manager afterwards
        /// </summary>
        public void SetActiveDialogue()
        {
            lastMessageIndex = activeDialogue.Messages.Length;

            Messages = activeDialogue.Messages;

            DisplayNextMessage(currentMessageIndex);

            Open();
        }

        public void DisplayNextMessage(int _messageIndex)
        {
            DialogueMessageSO currentMessage = Messages[currentMessageIndex];

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
                            currentMessageIndex = nextIndex;
                            DisplayNextMessage(currentMessageIndex);
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
            if (ShownLastMessage())
            {
                Close();
            }
            else
            {
                currentMessageIndex++;
                DisplayNextMessage(currentMessageIndex);
            }
        }

        public bool ShownLastMessage()
        {
            return currentMessageIndex == lastMessageIndex - 1;
        }


        #region IScreen interface methods
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}
