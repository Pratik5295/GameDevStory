using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DevStory.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        public DialogueMessage[] messages;

        [SerializeField] private TextMeshProUGUI speakerText;
        [SerializeField] private TextMeshProUGUI dialogueText;


        //UI for options
        public Button[] optionButtons;
        [SerializeField] private int currentMessageIndex = 0;

        private void Start()
        {
            DisplayNextMessage(currentMessageIndex);
        }

        public void DisplayNextMessage(int _messageIndex)
        {
            DialogueMessage currentMessage = messages[currentMessageIndex];

            dialogueText.text = currentMessage.Message;
            speakerText.text = currentMessage.Speaker;

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
                //Hide all your options
                foreach (var option in optionButtons)
                {
                    option.gameObject.SetActive(false);
                }
            }
        }
    }
}
