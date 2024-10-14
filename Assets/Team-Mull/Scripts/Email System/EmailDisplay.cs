using DevStory.Data;
using DevStory.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace DevStory.UI
{
    /// <summary>
    /// This script will handle the UI representation of the emails 
    /// in UI
    /// </summary>

    public class EmailDisplay : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI emailSenderName;

        [SerializeField]
        private TextMeshProUGUI emailBody;

        [SerializeField]
        private ScreenChangeData buttonChangeData;

        //Data to come from SO and hide if the email doesnt have task
        [SerializeField]
        private UIScreenButton taskButton;

        [SerializeField]
        private GameObject taskButtonParent;

        //UI for options
        public Button[] optionButtons;

        public GameEmail activeEmail;


        public void SetScreenChangeData(ScreenChangeData _newData)
        {
            buttonChangeData = _newData;
            taskButton.PopulateDisplay(_newData);
        }


        public void Populate(DialogueMessageSO currentMessage, GameEmail currentEmail, GameEmailScreen _screen)
        {
            activeEmail = currentEmail;

            emailBody.text = currentMessage.Message;
            emailSenderName.text = currentMessage.Speaker;

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

                            //Make it create next message
                            activeEmail.TraverseMessageCounterTo(nextIndex);
                            activeEmail.GetMessage();

                            //Hide all options
                            HideAllOptions();
                            _screen.DisplayNextMessage();
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

            //Check if the go to task needs to be populated
            if (taskButton != null)
            {
                taskButtonParent.SetActive(currentMessage.hasTask);
            }
            else
            {
                Debug.LogError("Task button parent reference is missing");
            }
        }

        public void HideAllOptions()
        {
            foreach(var option in optionButtons)
            {
                option.gameObject?.SetActive(false);
            }
        }

    }
}
