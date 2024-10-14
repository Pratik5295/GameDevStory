using DevStory.Data;
using DevStory.DialogueSystem;
using System.Collections;
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

        //Data to come from SO and hide if the email doesnt have task
        [SerializeField]
        private UIScreenButton taskButton;

        //UI for options
        public Button[] optionButtons;

        [Space(10)]
        [Header("Dialogue Variables")]

        public GameEmail activeEmail;

        [SerializeField] private GameObject emailPrefab;
        [SerializeField] private Transform emailContent;

        [SerializeField]
        private ScrollRect threadScroll;
        public float scrollSpeed = 1.0f;


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

            var emailDisplay = CreateNewMessage();
            emailDisplay.Populate(currentMessage, activeEmail,this);

            StartCoroutine(ScrollToEnd());

            //ScrollDown();

            //StartCoroutine(ScrollToBottomNextFrame());

        }

        private EmailDisplay CreateNewMessage()
        {
            var created = Instantiate(emailPrefab);
            created.transform.SetParent(emailContent.transform, false);

            return created.GetComponent<EmailDisplay>();
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

        private IEnumerator ScrollToEnd()
        {
            float time = 0f;
            float targetPosition = 0f; // Scroll to the bottom

            while (time < scrollSpeed)
            {
                time += Time.deltaTime;
                threadScroll.verticalNormalizedPosition = Mathf.Lerp(threadScroll.verticalNormalizedPosition, targetPosition, time / scrollSpeed);
                yield return null;
            }
        }
      }
    }
