using UnityEngine;
using UnityEngine.UI;

namespace DevStory.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        public DialogueMessage[] messages;

        //UI for options
        public Button[] optionButtons;
        private int currentMessageIndex = 0;

        private void Start()
        {
            DisplayNextMessage(currentMessageIndex);
        }

        public void DisplayNextMessage(int _messageIndex)
        {
            if (messages.Length == 0) return;

            DialogueMessage currentMessage = messages[currentMessageIndex];

            //Populate your options if any
            if(currentMessage.Options != null && currentMessage.Options.Length > 0)
            {
                for (int i = 0; i < optionButtons.Length; i++)
                {
                    if (i < currentMessage.Options.Length)
                    {
                        optionButtons[i].gameObject.SetActive(true);
                        optionButtons[i].GetComponentInChildren<Text>().text = currentMessage.Options[i].optionMessage;
                        int nextIndex = currentMessage.Options[i].nextMessageIndex;
                        optionButtons[i].onClick.RemoveAllListeners();
                        optionButtons[i].onClick.AddListener(() => DisplayNextMessage(nextIndex));
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
