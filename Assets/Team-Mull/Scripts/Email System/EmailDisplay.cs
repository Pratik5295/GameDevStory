using DevStory.Data;
using DevStory.DialogueSystem;
using DevStory.Gameplay.GameTimer;
using DevStory.Utility;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static MetaConstants.EnumManager.EnumManager;


namespace DevStory.UI
{
    /// <summary>
    /// This script will handle the UI representation of the emails 
    /// in UI
    /// </summary>

    public class EmailDisplay : MonoBehaviour
    {
        [SerializeField]
        private GameEmailScreen emailScreen;

        [Space(5)]
        [Header("Email Sender Details")]
        [SerializeField] 
        private Image emailSenderSprite;

        [SerializeField]
        private TextMeshProUGUI emailSenderName;

        [SerializeField]
        private TextMeshProUGUI emailBody;

        [SerializeField]
        private ScreenChangeData buttonChangeData;

        [Space(5)]
        [Header("Task Variables")]
        //Data to come from SO and hide if the email doesnt have task
        [SerializeField]
        private UIScreenButton taskButton;

        [SerializeField]
        private GameObject taskButtonParent;

        //UI for options
        public Button[] optionButtons;

        public GameEmail activeEmail;

        private DialogueMessageSO currentMessage;



        public void SetScreenChangeData(ScreenChangeData _newData)
        {
            buttonChangeData = _newData;
            taskButton.PopulateDisplay(_newData);
        }

        public void PopulateWithoutTraverse(DialogueMessageSO _currentMessage, GameEmail currentEmail, GameEmailScreen _screen)
        {
            emailScreen = _screen;
            currentMessage = _currentMessage;
            activeEmail = currentEmail;
            
            emailBody.text = _currentMessage.Message;
            emailSenderName.text = _currentMessage.Speaker.Data.CharacterName;

            //Hide all your options
            HideAllOptions();

            //Show/Hide Task buttons
            PopulateTaskButton();
        }


        public void Populate(DialogueMessageSO _currentMessage, GameEmail currentEmail, GameEmailScreen _screen)
        {
            emailScreen = _screen;
            currentMessage = _currentMessage;
            activeEmail = currentEmail;

            if (_currentMessage.Speaker != null)
            {
                emailSenderSprite.sprite = _currentMessage.Speaker.Data.CharacterSprite;
              
                emailSenderName.text = _currentMessage.Speaker.Data.CharacterName;
            }
            else
            {
                Debug.LogWarning("Missing Sender info on the email!",gameObject);
            }
            emailBody.text = _currentMessage.Message;

            if (_currentMessage.Options != null && _currentMessage.Options.Length > 0)
            {
                for (int i = 0; i < optionButtons.Length; i++)
                {
                    if (i < _currentMessage.Options.Length)
                    {
                        optionButtons[i].gameObject.SetActive(true);
                        optionButtons[i].GetComponent<UIDialogueOption>().SetOption(_currentMessage.Options[i].optionMessage);
                        int nextIndex = _currentMessage.Options[i].nextMessageIndex;
                        optionButtons[i].onClick.RemoveAllListeners();
                        optionButtons[i].onClick.AddListener(() =>
                        {
                            //Check with type

                            if(_currentMessage.Type == DialogMessageType.SCAM)
                            {
                                //Hide all options
                                HideAllOptions();

                                GameTimerManager.Instance.SkipTimeBy(_currentMessage.skipTime);
                            }
                            else
                            {
                                //Make it create next message
                                activeEmail.TraverseMessageCounterTo(nextIndex);
                                activeEmail.GetMessage();

                                //Hide all options
                                HideAllOptions();
                                _screen.DisplayNextMessage();
                            }
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

                if (!activeEmail.LastMessageShown())
                {
                    //For mails without options, we add message by itself
                    StartCoroutine(ShowNextMessage());
                }
            }

            PopulateTaskButton();
        }

        private IEnumerator ShowNextMessage()
        {
            yield return new WaitForSeconds(2f);

            activeEmail.TraverseMessageCounterTo(currentMessage.nextIndex);
            activeEmail.GetMessage();

            emailScreen.DisplayNextMessage();
        }

        public void HideAllOptions()
        {
            foreach(var option in optionButtons)
            {
                option.gameObject?.SetActive(false);
            }
        }

        /// <summary>
        /// Helper function to populate task only if task exists on backend 
        /// for the particular message
        /// </summary>
        private void PopulateTaskButton()
        {
            //Check if the go to task needs to be populated
            if (taskButton != null)
            {
                if(currentMessage.hasTask)
                {
                    //Create new screen data change type
                    ScreenChangeData screenChangeData = new ScreenChangeData()
                    {
                        Message = "Go to Task",
                        OpenScreen = GameScreens.MAIN
                    };


                    SetScreenChangeData(screenChangeData);
                }
               

                taskButtonParent.SetActive(currentMessage.hasTask);
            }
            else
            {
                Debug.LogError("Task button parent reference is missing");
            }
        }

    }
}
